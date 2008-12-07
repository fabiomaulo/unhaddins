using System;
using System.IO;
using System.Text;
using GoldParsing.Engine;

namespace NHibernate.Hql.Ast
{
	/// <summary>
	/// The responsibility of HqlParser is parse an HQL-string, using grammar, and create
	/// the correspondig HQL-syntax-tree
	/// </summary>
	public class HqlParser
	{
		private readonly ISyntaxNodeFactory<Reduction, Token> factory;
		private readonly Parser parser;

		public HqlParser(IGrammar grammar, ISyntaxNodeFactory<Reduction, Token> factory)
		{
			if (grammar == null)
			{
				throw new ArgumentNullException("grammar");
			}
			if (factory == null)
			{
				throw new ArgumentNullException("factory");
			}
			this.factory = factory;
			parser = new Parser(grammar);
		}

		public ISyntaxNode Parse(string hql)
		{
			if (hql == null)
			{
				throw new ArgumentNullException("hql");
			}
			if (hql.Equals(string.Empty))
			{
				throw new ArgumentException("Empty HQL to parse.", "hql");
			}

			using (var sr = new StringReader(hql))
			{
				bool done = false;

				parser.OpenStream(sr);

				while (!done)
				{
					ParseMessage result = parser.Parse();
					switch (result)
					{
						case ParseMessage.TokenRead:
							break;
						case ParseMessage.Reduction:
							break;
						case ParseMessage.Accept:
							done = true;
							break;
						case ParseMessage.LexicalError:
							// TODO manage Lexical Error
							throw new QueryParsingException("Lexical Error.", hql, parser.CurrentLineNumber, parser.CurrentColumnInLine);
						case ParseMessage.SyntaxError:
							throw new QuerySyntaxException("Syntax Error :", GetParsingInfo(hql));
						case ParseMessage.CommentError:
							// TODO manage comment error
							throw new QueryParsingException("Comment not closed.", hql, parser.CurrentLineNumber, parser.CurrentColumnInLine);
						case ParseMessage.InternalError:
							// TODO manage comment error
							throw new QueryParsingException("Internal parser Error.", hql, parser.CurrentLineNumber, parser.CurrentColumnInLine);
					}
				}
			}
			/*
			 * As a compilation process the syntaxTree is created using visitors at the end of
			 * parse process. 
			 * I'll check if an "interpretation process" (create the syntax tree during parse process)
			 * can give me better performance.
			 */
			var visitor = new SyntaxTreeConverterVisitor(factory);
			parser.CurrentReduction.Accept(visitor);
			return parser.CurrentReduction.Tag as ISyntaxNode;
		}

		private QuerySyntaxException.Info GetParsingInfo(string hql)
		{
			var expected = new StringBuilder(200);
			foreach (Token token in parser.ExpectedTokens)
			{
				expected.Append(" ").Append(token);
			}
			return new QuerySyntaxException.Info
			       	{
			       		Query = hql,
			       		Line = parser.CurrentLineNumber,
			       		Column = parser.CurrentColumnInLine,
			       		Found = parser.CurrentToken.Data.ToString(),
			       		Expected = expected.ToString()
			       	};
		}

		private class SyntaxTreeConverterVisitor: IVisitor
		{
			private readonly ISyntaxNodeFactory<Reduction, Token> factory;

			public SyntaxTreeConverterVisitor(ISyntaxNodeFactory<Reduction, Token> factory)
			{
				this.factory = factory;
			}

			#region Implementation of IVisitor

			public void Visit(Reduction reduction)
			{
				IClauseNode clauseNode = ConvertRule(reduction);
				reduction.Tag = clauseNode;
				foreach (var token in reduction.Tokens)
				{
					ISyntaxNode child=null;
					if (token.Kind == SymbolType.Terminal)
					{
						child = ConvertTerminal(token, clauseNode);
					}
					else
					{
						var cr = token.Data as Reduction;
						if (cr != null)
						{
							cr.Accept(this);
							var clause = (IClauseNode)cr.Tag;
							clause.SetParent(clauseNode);
							child = clause;
						}
					}
					clauseNode.AddChild(child);
				}
			}

			private ISyntaxNode ConvertTerminal(Token token, IClauseNode parentClause)
			{
				return factory.GetTerminal(token, parentClause);
			}

			private IClauseNode ConvertRule(Reduction reduction)
			{
				return factory.GetClause(reduction);
			}

			#endregion
		}
	}
}