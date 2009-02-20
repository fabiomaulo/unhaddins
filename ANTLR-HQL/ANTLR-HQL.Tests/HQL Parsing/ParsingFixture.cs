using System;
using System.Collections.Generic;
using System.Reflection;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Engine;
using NHibernate.Hql;
using NHibernate.Hql.Ast.ANTLR;
using NHibernate.Hql.Ast.ANTLR.Tree;
using NUnit.Framework;

namespace ANTLR_HQL.Tests.HQL_Parsing
{
	[TestFixture]
	public class ParsingFixture
	{
		[Test]
		public void BasicQuery()
		{
			string input = "from ANTLR_HQL.Tests.Animal a where a.Legs > 7";

			ISessionFactoryImplementor sfi = SetupSFI();

			IQueryTranslatorFactory factory = new ASTQueryTranslatorFactory();
			IQueryTranslator qti = factory.CreateQueryTranslator(null, input, new Dictionary<string, IFilter>(), sfi);

			qti.Compile(null, false);

			/*
			// string input = "from o in class org.hibernate.test.Top";


			// Phase 1
			HqlLexer lex = new HqlLexer(new ANTLRStringStream(input));
			CommonTokenStream tokens = new CommonTokenStream(lex);

			HqlParser parser = new HqlParser(tokens);

			HqlParser.statement_return ret = parser.statement();

			Console.WriteLine(((ITree)ret.Tree).ToStringTree());

			// Phase 2
			CommonTreeNodeStream nodes = new CommonTreeNodeStream(ret.Tree);
			nodes.TokenStream = tokens;

			QueryTranslatorImpl qti = new QueryTranslatorImpl();
			HqlSqlWalker p2 = new HqlSqlWalker(qti, sfi, nodes, new Dictionary<string, string>(), null);
			p2.TreeAdaptor = new HqlTreeAdaptor(p2);

			HqlSqlWalker.statement_return ret2 = p2.statement();

			DumpTree((ITree)ret2.Tree);*/
		}

		ISessionFactoryImplementor SetupSFI()
		{
			Configuration cfg = new Configuration();
			cfg.AddAssembly(this.GetType().Assembly);
			return (ISessionFactoryImplementor)cfg.BuildSessionFactory();
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
