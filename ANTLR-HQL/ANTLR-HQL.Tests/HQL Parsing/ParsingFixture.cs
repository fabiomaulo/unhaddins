using System;
using log4net.Config;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Engine;
using NUnit.Framework;

namespace ANTLR_HQL.Tests.HQL_Parsing
{
	[TestFixture]
	public class ParsingFixture
	{
		[Test]
		public void BasicQuery()
		{
			XmlConfigurator.Configure();

			string input = "from ANTLR_HQL.Tests.Animal a where a.Legs > 7";

			ISessionFactoryImplementor sfi = SetupSFI();

			ISession session = sfi.OpenSession();

			foreach (Animal o in session.CreateQuery(input).Enumerable())
			{
				Console.WriteLine(o.Description);
			}

			/*
			IQueryTranslatorFactory factory = new ASTQueryTranslatorFactory();
			IQueryTranslator qti = factory.CreateQueryTranslator(null, input, new Dictionary<string, IFilter>(), sfi);

			qti.Compile(null, false);
			*/
			/*
			// string input = "from o in class org.hibernate.test.Top";


			// Phase 1
			HqlLexer lex = new HqlLexer(new ANTLRStringStream(input));
			CommonTokenStream tokens = new CommonTokenStream(lex);

			HqlParser parser = new HqlParser(tokens);

			HqlParser.statement_return ret = parser.statement();

			Console.WriteLine(((IASTNode)ret.Tree).ToStringTree());

			// Phase 2
			CommonTreeNodeStream nodes = new CommonTreeNodeStream(ret.Tree);
			nodes.TokenStream = tokens;

			QueryTranslatorImpl qti = new QueryTranslatorImpl();
			HqlSqlWalker p2 = new HqlSqlWalker(qti, sfi, nodes, new Dictionary<string, string>(), null);
			p2.TreeAdaptor = new HqlTreeAdaptor(p2);

			HqlSqlWalker.statement_return ret2 = p2.statement();

			DumpTree((IASTNode)ret2.Tree);*/
		}

		ISessionFactoryImplementor SetupSFI()
		{
			Configuration cfg = new Configuration();
			cfg.AddAssembly(this.GetType().Assembly);
			return (ISessionFactoryImplementor)cfg.BuildSessionFactory();
		}
	}
}
