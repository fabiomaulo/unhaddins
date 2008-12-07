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
			// register know converters
			#region register Terminals
			RegisterTerminalConverter("IntegerLiteral", IntegerLiteralConvert);
			#endregion
			#region register Clauses
			RegisterClauseConverter("Value", ValueClauseConvert);
			#endregion
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
		protected ISyntaxNode IntegerLiteralConvert(Token token, IClauseNode owner)
		{
			return new IntegerLiteral(owner) {OriginalText = ((string) token.Data)};
		}
		#endregion

		#region Clause Converters
		protected IClauseNode ValueClauseConvert(Reduction reduction)
		{
			return new ValueClause();
		}
		#endregion
	}
}