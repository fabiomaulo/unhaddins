using System;
using NHibernate.Hql.Ast.ANTLR.Tree;
using NHibernate.Persister.Entity;
using NHibernate.SqlCommand;
using NHibernate.Type;
using NHibernate.Util;

namespace NHibernate.Hql.Ast.ANTLR.Util
{
	public class LiteralProcessor
	{
		public const string ErrorCannotFetchWithIterate = "fetch may not be used with scroll() or iterate()";
		public const string ErrorNamedParameterDoesNotAppear = "Named parameter does not appear in Query: ";
		public const string ErrorCannotDetermineType = "Could not determine type of: ";
		public const string ErrorCannotFormatLiteral = "Could not format constant value to SQL literal: ";

		Logger log = new Logger();

		private readonly HqlSqlWalker _walker;
		private static readonly IDecimalFormatter[] _formatters = new IDecimalFormatter[] {
			new ExactDecimalFormatter(),
			new ApproximateDecimalFormatter()
		};

		/// <summary>
		///  Indicates that Float and Double literal values should
		/// be treated using the SQL "exact" format (i.e., '.001')
		/// </summary>
		public static readonly int EXACT = 0;

		/// <summary>
		/// Indicates that Float and Double literal values should
		/// be treated using the SQL "approximate" format (i.e., '1E-3')
		/// </summary>
		public static readonly int APPROXIMATE = 1;

		/// <summary>
		/// In what format should Float and Double literal values be sent
		/// to the database?
		/// See #EXACT, #APPROXIMATE
		/// </summary>
		public static readonly int DECIMAL_LITERAL_FORMAT = EXACT;


		public LiteralProcessor(HqlSqlWalker walker)
		{
			_walker = walker;
		}

		public void LookupConstant(DotNode node)
		{
			string text = ASTUtil.GetPathText(node);
			IQueryable persister = _walker.SessionFactoryHelper.FindQueryableUsingImports(text);
			if (persister != null)
			{
				// the name of an entity class
				string discrim = persister.DiscriminatorSQLValue;
				node.DataType = persister.DiscriminatorType;

				if (InFragment.Null == discrim || InFragment.NotNull == discrim)
				{
					throw new InvalidPathException("subclass test not allowed for null or not null discriminator: '" + text + "'");
				}
				else
				{
					SetSQLValue(node, text, discrim); //the class discriminator value
				}
			}
			else
			{
				// TODO - this will crash.  Need to get the System.Type from somewhere
				Object value = ReflectHelper.GetConstantValue(null, text);
				if (value == null)
				{
					throw new InvalidPathException("Invalid path: '" + text + "'");
				}
				else
				{
					SetConstantValue(node, text, value);
				}
			}
		}

		public void ProcessNumericLiteral(SqlNode literal)
		{
			if (literal.Type == HqlSqlWalker.NUM_INT || literal.Type == HqlSqlWalker.NUM_LONG)
			{
				literal.SetText(DetermineIntegerRepresentation(literal.Text, literal.Type));
			}
			else if (literal.Type == HqlSqlWalker.NUM_FLOAT || literal.Type == HqlSqlWalker.NUM_DOUBLE)
			{
				literal.SetText(DetermineDecimalRepresentation(literal.Text, literal.Type));
			}
			else
			{
				log.warn("Unexpected literal token type [" + literal.Type + "] passed for numeric processing");
			}
		}

		public bool IsAlias(string alias)
		{
			FromClause from = _walker.CurrentFromClause;
			while (from.IsSubQuery)
			{
				if (from.ContainsClassAlias(alias))
				{
					return true;
				}
				from = from.ParentFromClause;
			}
			return from.ContainsClassAlias(alias);
		}

		public void ProcessConstant(SqlNode constant, bool resolveIdent)
		{
			// If the constant is an IDENT, figure out what it means...
			bool isIdent = (constant.Type == HqlSqlWalker.IDENT || constant.Type == HqlSqlWalker.WEIRD_IDENT);

			if (resolveIdent && isIdent && IsAlias(constant.Text))
			{
				// IDENT is a class alias in the FROM.
				IdentNode ident = (IdentNode)constant;
				// Resolve to an identity column.
				ident.Resolve(false, true);
			}
			else
			{
				// IDENT might be the name of a class.
				IQueryable queryable = _walker.SessionFactoryHelper.FindQueryableUsingImports(constant.Text);
				if (isIdent && queryable != null)
				{
					constant.SetText(queryable.DiscriminatorSQLValue);
				}
				// Otherwise, it's a literal.
				else
				{
					ProcessLiteral(constant);
				}
			}
		}

		public string DetermineDecimalRepresentation(string text, int type)
		{
			string literalValue = text;
			if (type == HqlSqlWalker.NUM_FLOAT)
			{
				if (literalValue.EndsWith("f") || literalValue.EndsWith("F"))
				{
					literalValue = literalValue.Substring(0, literalValue.Length - 1);
				}
			}
			else if (type == HqlSqlWalker.NUM_DOUBLE)
			{
				if (literalValue.EndsWith("d") || literalValue.EndsWith("D"))
				{
					literalValue = literalValue.Substring(0, literalValue.Length - 1);
				}
			}

			Decimal number;
			try
			{
				number = Decimal.Parse(literalValue);
			}
			catch (Exception t)
			{
				throw new HibernateException("Could not parse literal [" + text + "] as big-decimal", t);
			}

			return _formatters[DECIMAL_LITERAL_FORMAT].Format(number);
		}

		private string DetermineIntegerRepresentation(string text, int type)
		{
			try
			{
				if (type == HqlSqlWalker.NUM_INT)
				{
					try
					{
						return int.Parse(text).ToString();
					}
					catch (FormatException e)
					{
						log.trace("could not format incoming text [" + text + "] as a NUM_INT; assuming numeric overflow and attempting as NUM_LONG");
					}
				}

				String literalValue = text;
				if (literalValue.EndsWith("l") || literalValue.EndsWith("L"))
				{
					literalValue = literalValue.Substring(0, literalValue.Length - 1);
				}
				return long.Parse(literalValue).ToString();
			}
			catch (Exception t)
			{
				throw new HibernateException("Could not parse literal [" + text + "] as integer", t);
			}
		}

		private void ProcessLiteral(SqlNode constant)
		{
			string replacement = _walker.TokenReplacements[constant.Text];

			if (replacement != null)
			{
				if (log.isDebugEnabled())
				{
					log.debug("processConstant() : Replacing '" + constant.Text + "' with '" + replacement + "'");
				}
				constant.SetText(replacement);
			}
		}

		private void SetSQLValue(DotNode node, string text, string value)
		{
			if (log.isDebugEnabled())
			{
				log.debug("setSQLValue() " + text + " -> " + value);
			}
			node.Children.Clear(); // Chop off the rest of the tree.
			node.SetType(HqlSqlWalker.SQL_TOKEN);
			node.SetText(value);
			node.SetResolvedConstant(text);
		}

		private void SetConstantValue(DotNode node, string text, object value)
		{
			if (log.isDebugEnabled())
			{
				log.debug("setConstantValue() " + text + " -> " + value + " " + value.GetType().Name);
			}

			node.Children.Clear();	// Chop off the rest of the tree.

			if (value is string)
			{
				node.SetType(HqlSqlWalker.QUOTED_String);
			}
			else if (value is char)
			{
				node.SetType(HqlSqlWalker.QUOTED_String);
			}
			else if (value is byte)
			{
				node.SetType(HqlSqlWalker.NUM_INT);
			}
			else if (value is short)
			{
				node.SetType(HqlSqlWalker.NUM_INT);
			}
			else if (value is int)
			{
				node.SetType(HqlSqlWalker.NUM_INT);
			}
			else if (value is long)
			{
				node.SetType(HqlSqlWalker.NUM_LONG);
			}
			else if (value is double)
			{
				node.SetType(HqlSqlWalker.NUM_DOUBLE);
			}
			else if (value is float)
			{
				node.SetType(HqlSqlWalker.NUM_FLOAT);
			}
			else
			{
				node.SetType(HqlSqlWalker.CONSTANT);
			}

			IType type;
			try
			{
				type = TypeFactory.HeuristicType(value.GetType().Name);
			}
			catch (MappingException me)
			{
				throw new QueryException(me);
			}

			if (type == null)
			{
				throw new QueryException(LiteralProcessor.ErrorCannotDetermineType + node.Text);
			}
			try
			{
				ILiteralType literalType = (ILiteralType)type;
				NHibernate.Dialect.Dialect dialect = _walker.SessionFactoryHelper.Factory.Dialect;
				node.SetText(literalType.ObjectToSQLString(value, dialect));
			}
			catch (Exception e)
			{
				throw new QueryException(LiteralProcessor.ErrorCannotFormatLiteral + node.Text, e);
			}

			node.DataType = type;
			node.SetResolvedConstant(text);
		}

		interface IDecimalFormatter
		{
			string Format(Decimal number);
		}

		class ExactDecimalFormatter : IDecimalFormatter
		{
			public string Format(Decimal number)
			{
				return number.ToString();
			}
		}

		class ApproximateDecimalFormatter : IDecimalFormatter
		{
			private static readonly string FORMAT_STRING = "#0.0E0";

			public string Format(Decimal number)
			{
				try
				{
					return number.ToString(FORMAT_STRING);

				}
				catch (Exception t)
				{
					throw new HibernateException("Unable to format decimal literal in approximate format [" + number.ToString() + "]", t);
				}
			}
		}
	}
}
