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
			RegisterTerminalConverter("as", SymbolNodeConvert);
			RegisterTerminalConverter("ComparisonOperator", SymbolNodeConvert);
			RegisterTerminalConverter(".", IgnoreToken);
			RegisterTerminalConverter("class", IgnoreToken);
			RegisterTerminalConverter("select", IgnoreToken);
			RegisterTerminalConverter("from", IgnoreToken);
			RegisterTerminalConverter("in", IgnoreToken);
			RegisterTerminalConverter(",", IgnoreToken);
			RegisterTerminalConverter("IntegerLiteral", (token, owner) => new IntegerConstant(owner, token.Data.ToString()));
			RegisterTerminalConverter("FloatLiteral", (token, owner) => new FloatConstant(owner, token.Data.ToString()));
			RegisterTerminalConverter("HexLiteral", (token, owner) => new FloatConstant(owner, token.Data.ToString()));
			RegisterTerminalConverter("StringLiteral", (token, owner) => new StringConstant(owner, token.Data.ToString()));
			RegisterTerminalConverter("Parameter", ParameterConvert);
			RegisterTerminalConverter("Identifier", (token, owner) => new Identifier(owner, token.Data.ToString()));
			RegisterTerminalConverter("Path", (token, owner) => new IdentifierPath(owner, token.Data.ToString()));

			#endregion

			#region register Clauses

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
			RegisterClauseConverter("SelectClause", x => new SelectClause());
			RegisterClauseConverter("Statement", x => new NhqlStatement());
			
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

		#endregion
	}
}