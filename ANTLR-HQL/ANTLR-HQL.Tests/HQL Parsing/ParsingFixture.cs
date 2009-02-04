using System;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using NHibernate.Hql.Ast.ANTLR;
using NUnit.Framework;

namespace ANTLR_HQL.Tests.HQL_Parsing
{
	[TestFixture]
	public class ParsingFixture
	{
		[Test]
		public void BasicQuery()
		{
			// string input = "from o in class org.hibernate.test.Top";

			string input = "from Animal a where a.Legs > 7";

			HqlLexer lex = new HqlLexer(new ANTLRStringStream(input));
			CommonTokenStream tokens = new CommonTokenStream(lex);

			HqlParser parser = new HqlParser(tokens);

			HqlParser.statement_return ret = parser.statement();

			DumpTree((ITree)ret.Tree);
		}

		void DumpTree(ITree node)
		{
			DumpTree(node, 0);
		}

		void DumpTree(ITree node, int indent)
		{
			Console.WriteLine("{2}({0}:{1})", node.Text, HqlParser.tokenNames[node.Type], new string(' ', indent));

			if (node.ChildCount > 0)
			{
				Console.WriteLine("{0}(", new string(' ', indent));
				for (int i = 0; i < node.ChildCount; i++)
				{
					DumpTree(node.GetChild(i), indent + 3);
				}
				Console.WriteLine("{0})", new string(' ', indent));
			}
		}
	}
}
