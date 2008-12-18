using System;
using System.Linq;
using System.Collections.Generic;
using GoldParsing.Engine;
using NHibernate.Hql.Ast.Tree;

namespace NHibernate.Hql.Ast.GoldImpls
{
	public class SyntaxNodeFactory : ISyntaxNodeFactory<Reduction, Token>
	{
		private readonly Dictionary<string, Converter<Reduction, IClauseNode>> rconverters =
			new Dictionary<string, Converter<Reduction, IClauseNode>>();

		private readonly Dictionary<string, Func<Token, IClauseNode, ISyntaxNode>> tconverters =
			new Dictionary<string, Func<Token, IClauseNode, ISyntaxNode>>();

		public SyntaxNodeFactory()
		{
			// register know default converters

			#region register Terminals
			RegisterTerminalConverter("+", SymbolNodeConvert);
			RegisterTerminalConverter("-", SymbolNodeConvert);
			RegisterTerminalConverter("*", SymbolNodeConvert);
			RegisterTerminalConverter("/", SymbolNodeConvert);
			RegisterTerminalConverter("(", SymbolNodeConvert);
			RegisterTerminalConverter(")", SymbolNodeConvert);
			RegisterTerminalConverter("ALL", SymbolNodeConvert);
			RegisterTerminalConverter("AND", SymbolNodeConvert);
			RegisterTerminalConverter("ANY", SymbolNodeConvert);
			RegisterTerminalConverter("ASC", SymbolNodeConvert);
			RegisterTerminalConverter("ASCENDING", SymbolNodeConvert);
			RegisterTerminalConverter("AVG", SymbolNodeConvert);
			RegisterTerminalConverter("BETWEEN", SymbolNodeConvert);
			RegisterTerminalConverter("CASE", SymbolNodeConvert);
			RegisterTerminalConverter("CAST", SymbolNodeConvert);
			RegisterTerminalConverter("COUNT", SymbolNodeConvert);
			RegisterTerminalConverter("DESC", SymbolNodeConvert);
			RegisterTerminalConverter("DESCENDING", SymbolNodeConvert);
			RegisterTerminalConverter("DISTINCT", SymbolNodeConvert);
			RegisterTerminalConverter("ELEMENTS", SymbolNodeConvert);
			RegisterTerminalConverter("ELSE", SymbolNodeConvert);
			RegisterTerminalConverter("END", SymbolNodeConvert);
			RegisterTerminalConverter("EXISTS", SymbolNodeConvert);
			RegisterTerminalConverter("FETCH", SymbolNodeConvert);
			RegisterTerminalConverter("FULL", SymbolNodeConvert);
			RegisterTerminalConverter("HAVING", SymbolNodeConvert);
			RegisterTerminalConverter("INDICES", SymbolNodeConvert);
			RegisterTerminalConverter("INNER", SymbolNodeConvert);
			RegisterTerminalConverter("IS", SymbolNodeConvert);
			RegisterTerminalConverter("JOIN", SymbolNodeConvert);
			RegisterTerminalConverter("LEFT", SymbolNodeConvert);
			RegisterTerminalConverter("LIKE", SymbolNodeConvert);
			RegisterTerminalConverter("MAX", SymbolNodeConvert);
			RegisterTerminalConverter("MEMBER", SymbolNodeConvert);
			RegisterTerminalConverter("MIN", SymbolNodeConvert);
			RegisterTerminalConverter("NEW", SymbolNodeConvert);
			RegisterTerminalConverter("NOT", SymbolNodeConvert);
			RegisterTerminalConverter("NULL", SymbolNodeConvert);
			RegisterTerminalConverter("OF", SymbolNodeConvert);
			RegisterTerminalConverter("OR", SymbolNodeConvert);
			RegisterTerminalConverter("ORDER BY", SymbolNodeConvert);
			RegisterTerminalConverter("OUTER", SymbolNodeConvert);
			RegisterTerminalConverter("RIGHT", SymbolNodeConvert);
			RegisterTerminalConverter("SOME", SymbolNodeConvert);
			RegisterTerminalConverter("THEN", SymbolNodeConvert);
			RegisterTerminalConverter("WHEN", SymbolNodeConvert);
			RegisterTerminalConverter("WHERE", SymbolNodeConvert);
			RegisterTerminalConverter("WITH", SymbolNodeConvert); 
			RegisterTerminalConverter("AS", SymbolNodeConvert);
			RegisterTerminalConverter("||", SymbolNodeConvert);
			RegisterTerminalConverter("<", SymbolNodeConvert);
			RegisterTerminalConverter("<=", SymbolNodeConvert);
			RegisterTerminalConverter("=", SymbolNodeConvert);
			RegisterTerminalConverter(">", SymbolNodeConvert);
			RegisterTerminalConverter(">=", SymbolNodeConvert);
			RegisterTerminalConverter("EMPTY", SymbolNodeConvert);
			RegisterTerminalConverter("NotEqualOperator", SymbolNodeConvert);
			RegisterTerminalConverter("VERSIONED", SymbolNodeConvert);
			RegisterTerminalConverter("BOTH", SymbolNodeConvert);
			RegisterTerminalConverter("DAY", SymbolNodeConvert);
			RegisterTerminalConverter("EXTRACT", SymbolNodeConvert);
			RegisterTerminalConverter("HOUR", SymbolNodeConvert);
			RegisterTerminalConverter("LEADING", SymbolNodeConvert);
			RegisterTerminalConverter("MINUTE", SymbolNodeConvert);
			RegisterTerminalConverter("MONTH", SymbolNodeConvert);
			RegisterTerminalConverter("SECOND", SymbolNodeConvert);
			RegisterTerminalConverter("TIMEZONE_HOUR", SymbolNodeConvert);
			RegisterTerminalConverter("TIMEZONE_MINUTE", SymbolNodeConvert);
			RegisterTerminalConverter("TRAILING", SymbolNodeConvert);
			RegisterTerminalConverter("TRIM", SymbolNodeConvert);
			RegisterTerminalConverter("YEAR", SymbolNodeConvert);

			RegisterTerminalConverter("IN", InTerminalConvert);

			RegisterTerminalConverter(".", IgnoreToken);
			RegisterTerminalConverter("CLASS", IgnoreToken);
			RegisterTerminalConverter("SELECT", IgnoreToken);
			RegisterTerminalConverter("FROM", IgnoreToken);
			RegisterTerminalConverter("DELETE", IgnoreToken);
			RegisterTerminalConverter("ESCAPE", IgnoreToken);
			RegisterTerminalConverter("GROUP BY", IgnoreToken);
			RegisterTerminalConverter("INSERT", IgnoreToken);
			RegisterTerminalConverter("INTO", IgnoreToken);
			RegisterTerminalConverter("SET", IgnoreToken);
			RegisterTerminalConverter("UPDATE", IgnoreToken);

			RegisterTerminalConverter(",", IgnoreToken);
			RegisterTerminalConverter("[", SymbolNodeConvert);
			RegisterTerminalConverter("]", SymbolNodeConvert);

			RegisterTerminalConverter("Identifier", (token, owner) => new Identifier(owner, token.Data.ToString()));
			RegisterTerminalConverter("Path", (token, owner) => new IdentifierPath(owner, token.Data.ToString()));
			RegisterTerminalConverter("StringLiteral", (token, owner) => new ConstantExpression<string>(owner, token.Data.ToString()));
			RegisterTerminalConverter("IntegerLiteral", IntegerConstantConvert);
			RegisterTerminalConverter("FloatLiteral", FloatConstantConvert);
			RegisterTerminalConverter("HexLiteral", (token, owner) => new ConstantExpression<string>(owner, token.Data.ToString()));
			RegisterTerminalConverter("BooleanLiteral", (token, owner) => new ConstantExpression<bool>(owner, bool.Parse(token.Data.ToString())));
			RegisterTerminalConverter("Parameter", ParameterConvert);
			#endregion

			#region register Clauses
			RegisterClauseConverter("Expression", NotSupportedConverter);

			RegisterClauseConverter("Query", x => new NoConvertedExpression());
			RegisterClauseConverter("SelectStatement", x => new NhqlStatement());
			RegisterClauseConverter("UpdateStatement", x => new NoConvertedExpression());
			RegisterClauseConverter("DeleteStatement", x => new NoConvertedExpression());
			RegisterClauseConverter("InsertStatement", x => new NoConvertedExpression());

			RegisterClauseConverter("SelectClause", x => new SelectClause());
			RegisterClauseConverter("FromClause", x => new FromClause());
			RegisterClauseConverter("JoinClause", x => new NoConvertedExpression());
			RegisterClauseConverter("JoinClauseChain", x => new NoConvertedExpression());
			RegisterClauseConverter("WithClause", x => new NoConvertedExpression());
			RegisterClauseConverter("WhereClause", x => new NoConvertedExpression());
			RegisterClauseConverter("OrderByClause", x => new OrderByClause());
			RegisterClauseConverter("GroupByClause", x => new GroupByClause());
			RegisterClauseConverter("HavingClause", x => new NoConvertedExpression());

			RegisterClauseConverter("AndExpression", x => new LogicalExpression());
			RegisterClauseConverter("OrExpression", x => new LogicalExpression());
			RegisterClauseConverter("MathAddExpression", x => new MathExpression());
			RegisterClauseConverter("MathMultExpression", x => new MathExpression());
			RegisterClauseConverter("MathNegateExpression", x => new MathNegateExpression());
			RegisterClauseConverter("EntityName", x => new EntityNameExpression());
			RegisterClauseConverter("AliasedEntityName", x => new AliasedEntityNameExpression());
			RegisterClauseConverter("AliasedEntityNameList", x => new AliasedEntityNameList());
			RegisterClauseConverter("AliasedExpression", x => new AliasedExpression());
			RegisterClauseConverter("AliasedExpressionList", x => new AliasedExpressionList());
			RegisterClauseConverter("Value", x => new ValueExpression());
			RegisterClauseConverter("StringValueExpression", x => new NoConvertedExpression());

			RegisterClauseConverter("AggregateExpression", x => new FunctionExpression());
			RegisterClauseConverter("FunctionExpression", x => new FunctionExpression());
			RegisterClauseConverter("TrimFunctionExpression", x => new FunctionExpression());
			RegisterClauseConverter("ExtractFunctionExpression", x => new FunctionExpression());

			RegisterClauseConverter("CaseExpression", x => new NoConvertedExpression());
			RegisterClauseConverter("CaseResult", x => new NoConvertedExpression());
			RegisterClauseConverter("CollectionExpression", x => new NoConvertedExpression());
			RegisterClauseConverter("ElseClause", x => new NoConvertedExpression());
			RegisterClauseConverter("ExpressionList", x => new ExpressionList());
			RegisterClauseConverter("IndexedExpression", x => new NoConvertedExpression());
			RegisterClauseConverter("JoinDefinition", x => new NoConvertedExpression());
			RegisterClauseConverter("NotExpression", x => new NoConvertedExpression());
			RegisterClauseConverter("OrderList", x => new OrderByList());
			RegisterClauseConverter("OrderItem", x => new OrderByItem());
			RegisterClauseConverter("OrderType", x => new OrderingSpecification());
			RegisterClauseConverter("PredicateExpression", x => new NoConvertedExpression());
			RegisterClauseConverter("QuantifiedExpression", x => new NoConvertedExpression());
			RegisterClauseConverter("Restriction", x => new NoConvertedExpression());
			RegisterClauseConverter("SearchedCaseExpression", x => new NoConvertedExpression());
			RegisterClauseConverter("SearchedWhenClause", x => new NoConvertedExpression());
			RegisterClauseConverter("SimpleCaseExpression", x => new NoConvertedExpression());
			RegisterClauseConverter("SimpleWhenClause", x => new NoConvertedExpression());
			RegisterClauseConverter("Tuple", x => new NoConvertedExpression());
			RegisterClauseConverter("AssignList", x => new NoConvertedExpression());
			RegisterClauseConverter("ConcatenationExpression", x => new NoConvertedExpression());
			RegisterClauseConverter("EntityNameList", x => new NoConvertedExpression());
			RegisterClauseConverter("ExistsPredicate", x => new NoConvertedExpression());
			RegisterClauseConverter("LikeEscape", x => new NoConvertedExpression());
			RegisterClauseConverter("MemberPredicate", x => new NoConvertedExpression());
			RegisterClauseConverter("ExtractField", x => new NoConvertedExpression());
			RegisterClauseConverter("TrimOperands", x => new NoConvertedExpression());
			RegisterClauseConverter("TrimSpecification", x => new NoConvertedExpression());
			#endregion
		}

		public bool IsRegisterConverter(string key)
		{
			return tconverters.ContainsKey(key) || rconverters.ContainsKey(key);
		}

		public void RegisterTerminalConverter(string key, Func<Token, IClauseNode, ISyntaxNode> converter)
		{
			// allow override
			tconverters[key] = converter;
		}

		public void RegisterClauseConverter(string key, Converter<Reduction, IClauseNode> converter)
		{
			// allow override
			rconverters[key] = converter;
		}

		public IEnumerable<string> KnowConverters
		{
			get { return tconverters.Keys.Concat(rconverters.Keys); }
		}

		#region Implementation of ISyntaxNodeFactory<Reduction,Token>

		public IClauseNode GetClause(Reduction origin)
		{
			if (origin == null)
			{
				throw new ArgumentNullException("origin");
			}
			Converter<Reduction, IClauseNode> convert;

			if (rconverters.TryGetValue(origin.Parent.Head.Name, out convert))
			{
				return convert(origin);
			}
			throw new QueryParserException("Convertion from " + origin + " is not available.");
		}

		public ISyntaxNode GetTerminal(Token origin, IClauseNode owner)
		{
			if (origin == null)
			{
				throw new ArgumentNullException("origin");
			}
			if (owner == null)
			{
				throw new ArgumentNullException("owner");
			}
			Func<Token, IClauseNode, ISyntaxNode> convert;

			if (tconverters.TryGetValue(origin.Name, out convert))
			{
				return convert(origin, owner);
			}
			throw new QueryParserException("Convertion from terminal " + origin + " is not available.");
		}

		#endregion

		#region Terminals Converters

		protected static ISyntaxNode IgnoreToken(Token token, IClauseNode owner)
		{
			return null;
		}

		protected static ISyntaxNode SymbolNodeConvert(Token token, IClauseNode owner)
		{
			return new SymbolNode(owner, token.Data.ToString());
		}

		protected virtual ISyntaxNode ParameterConvert(Token token, IClauseNode owner)
		{
			if ("?".Equals(token.Data))
			{
				return new PositionalParameter(owner);
			}
			else
			{
				return new NamedParameter(owner, token.Data.ToString());
			}
		}

		protected virtual ISyntaxNode InTerminalConvert(Token token, IClauseNode owner)
		{
			if (owner is AliasedEntityNameExpression)
			{
				return null;
			}
			else
			{
				return new SymbolNode(owner, token.Data.ToString());
			}
		}

		protected virtual ISyntaxNode IntegerConstantConvert(Token token, IClauseNode owner)
		{
			var originalText = token.Data.ToString();
			if (originalText.EndsWith("l", StringComparison.InvariantCultureIgnoreCase))
			{
				return new ConstantExpression<long>(owner, long.Parse(originalText), originalText);
			}
			else
			{
				return new ConstantExpression<int>(owner, int.Parse(originalText), originalText);
			}
		}

		protected virtual ISyntaxNode FloatConstantConvert(Token token, IClauseNode owner)
		{
			var originalText = token.Data.ToString();
			if (originalText.EndsWith("f", StringComparison.InvariantCultureIgnoreCase))
			{
				return new ConstantExpression<float>(owner, float.Parse(originalText), originalText);
			}
			else
			{
				return new ConstantExpression<double>(owner, double.Parse(originalText), originalText);
			}
		}
		#endregion

		#region Clauses converters
		private static IClauseNode NotSupportedConverter(Reduction x)
		{
			throw new NotSupportedException("The converter is not available; GOLD parser Reduction:" + x);
		}
		#endregion
	}
}