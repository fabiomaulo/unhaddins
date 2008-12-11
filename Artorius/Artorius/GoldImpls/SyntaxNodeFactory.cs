using System;
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
			RegisterTerminalConverter(":", SymbolNodeConvert);
			RegisterTerminalConverter("?", SymbolNodeConvert);
			RegisterTerminalConverter("ALL", SymbolNodeConvert);
			RegisterTerminalConverter("AND", SymbolNodeConvert);
			RegisterTerminalConverter("ANY", SymbolNodeConvert);
			RegisterTerminalConverter("ASC", SymbolNodeConvert);
			RegisterTerminalConverter("ASCENDING", SymbolNodeConvert);
			RegisterTerminalConverter("AVG", SymbolNodeConvert);
			RegisterTerminalConverter("BETWEEN", SymbolNodeConvert);
			RegisterTerminalConverter("BY", SymbolNodeConvert);
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
			RegisterTerminalConverter("GROUP", SymbolNodeConvert);
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

			RegisterTerminalConverter("IN", InTerminalConvert);

			RegisterTerminalConverter(".", IgnoreToken);
			RegisterTerminalConverter("CLASS", IgnoreToken);
			RegisterTerminalConverter("SELECT", IgnoreToken);
			RegisterTerminalConverter("FROM", IgnoreToken);
			RegisterTerminalConverter(",", IgnoreToken);
			RegisterTerminalConverter("[", IgnoreToken);
			RegisterTerminalConverter("]", IgnoreToken);

			RegisterTerminalConverter("Identifier", (token, owner) => new Identifier(owner, token.Data.ToString()));
			RegisterTerminalConverter("Path", (token, owner) => new IdentifierPath(owner, token.Data.ToString()));
			RegisterTerminalConverter("StringLiteral", (token, owner) => new StringConstant(owner, token.Data.ToString()));
			RegisterTerminalConverter("IntegerLiteral", (token, owner) => new IntegerConstant(owner, token.Data.ToString()));
			RegisterTerminalConverter("FloatLiteral", (token, owner) => new FloatConstant(owner, token.Data.ToString()));
			RegisterTerminalConverter("HexLiteral", (token, owner) => new FloatConstant(owner, token.Data.ToString()));
			RegisterTerminalConverter("ComparisonOperator", SymbolNodeConvert);
			RegisterTerminalConverter("Parameter", ParameterConvert);

			#endregion

			#region register Clauses

			RegisterClauseConverter("Statement", x => new NhqlStatement());
			RegisterClauseConverter("SelectClause", x => new SelectClause());
			RegisterClauseConverter("Value", x => new ValueExpression());
			RegisterClauseConverter("MathAddExpression", x => new MathExpression());
			RegisterClauseConverter("MathMultExpression", x => new MathExpression());
			RegisterClauseConverter("MathNegateExpression", x => new MathNegateExpression());
			RegisterClauseConverter("Expression", x => new Expression());
			RegisterClauseConverter("EntityName", x => new EntityNameExpression());
			RegisterClauseConverter("AliasedEntityName", x => new AliasedEntityNameExpression());
			RegisterClauseConverter("AliasedEntityNameList", x => new AliasedEntityNameList());
			RegisterClauseConverter("AliasedExpression", x => new AliasedExpression());
			RegisterClauseConverter("AliasedExpressionList", x => new AliasedExpressionList());
			RegisterClauseConverter("FromClause", x => new FromClause());

			RegisterClauseConverter("AggregateExpression", x => new NoConvertedExpression());
			RegisterClauseConverter("AndExpression", x => new NoConvertedExpression());
			RegisterClauseConverter("CaseExpression", x => new NoConvertedExpression());
			RegisterClauseConverter("CaseResult", x => new NoConvertedExpression());
			RegisterClauseConverter("CollectionExpression", x => new NoConvertedExpression());
			RegisterClauseConverter("ElseClause", x => new NoConvertedExpression());
			RegisterClauseConverter("ExpressionList", x => new NoConvertedExpression());
			RegisterClauseConverter("FunctionExpression", x => new NoConvertedExpression());
			RegisterClauseConverter("GroupByClause", x => new NoConvertedExpression());
			RegisterClauseConverter("HavingClause", x => new NoConvertedExpression());
			RegisterClauseConverter("IndexedExpression", x => new NoConvertedExpression());
			RegisterClauseConverter("JoinClause", x => new NoConvertedExpression());
			RegisterClauseConverter("JoinClauseChain", x => new NoConvertedExpression());
			RegisterClauseConverter("JoinDefinition", x => new NoConvertedExpression());
			RegisterClauseConverter("MemberExpression", x => new NoConvertedExpression());
			RegisterClauseConverter("NotExpression", x => new NoConvertedExpression());
			RegisterClauseConverter("OrderByClause", x => new NoConvertedExpression());
			RegisterClauseConverter("OrderList", x => new NoConvertedExpression());
			RegisterClauseConverter("OrderType", x => new NoConvertedExpression());
			RegisterClauseConverter("PredicateExpression", x => new NoConvertedExpression());
			RegisterClauseConverter("QuantifiedExpression", x => new NoConvertedExpression());
			RegisterClauseConverter("Restriction", x => new NoConvertedExpression());
			RegisterClauseConverter("SearchedCaseExpression", x => new NoConvertedExpression());
			RegisterClauseConverter("SearchedWhenClause", x => new NoConvertedExpression());
			RegisterClauseConverter("SimpleCaseExpression", x => new NoConvertedExpression());
			RegisterClauseConverter("SimpleWhenClause", x => new NoConvertedExpression());
			RegisterClauseConverter("Tuple", x => new NoConvertedExpression());
			RegisterClauseConverter("WhereClause", x => new NoConvertedExpression());
			RegisterClauseConverter("WithClause", x => new NoConvertedExpression());
			RegisterClauseConverter("ExistsExpression", x => new NoConvertedExpression());
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

		#endregion
	}
}