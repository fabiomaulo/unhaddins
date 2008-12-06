using System;
using System.IO;
using System.Text;
using GoldParsing.Engine;

namespace NHibernate.Hql.Ast
{
	public class HqlParser
	{
		private readonly Parser parser;

		public HqlParser(IGrammar grammar)
		{
			parser = new Parser(grammar);
		}

		public INode Parse(string hql)
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
							break;
						case ParseMessage.CommentError:
							// TODO manage comment error
							throw new QueryParsingException("Comment not closed.", hql, parser.CurrentLineNumber, parser.CurrentColumnInLine);
						case ParseMessage.InternalError:
							// TODO manage comment error
							throw new QueryParsingException("Internal parser Error.", hql, parser.CurrentLineNumber, parser.CurrentColumnInLine);
					}
				}
			}
			return null;
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
	}
}