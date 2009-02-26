using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using log4net.Config;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Engine;
using NHibernate.Hql.Ast.ANTLR;
using NUnit.Framework;

namespace ANTLR_HQL.Tests.HQL_Parsing
{
	[TestFixture]
	public class ParsingFixture
	{
		[Test, TestCaseSource(typeof(QueryFactoryClass), "TestCases")]
		public string HqlParse(string query)
		{
			var p = new HqlParseEngine(query, false);
			p.Parse();

			return " " + p.Ast.ToStringTree();
		}

		[Test]
		public void ParseTest()
		{
			var p = new HqlParseEngine("from bar in class Bar where bar.count=667", false);
			p.Parse();
		}		

		[Test, Ignore]
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
		}

		ISessionFactoryImplementor SetupSFI()
		{
			Configuration cfg = new Configuration();
			cfg.AddAssembly(this.GetType().Assembly);
			return (ISessionFactoryImplementor)cfg.BuildSessionFactory();
		}

		public class QueryFactoryClass
		{
			public static IEnumerable<TestCaseData> TestCases
			{
				get
				{
					XDocument doc = XDocument.Load(@"HQL Parsing\TestQueriesWithResults.xml");

					foreach (XElement testGroup in doc.Element("Tests").Elements("TestGroup"))
					{
						string category = testGroup.Attribute("Name").Value;

						foreach (XElement test in testGroup.Elements("Test"))
						{
							string query = test.Element("Query").Value;
							string result = test.Element("Result") != null ? test.Element("Result").Value : "barf";
							string name = test.Element("Name") != null ? test.Element("Description").Value : null;
							string description = test.Element("Description") != null ? test.Element("Description").Value : null;
							bool ignore = test.Attribute("Ignore") != null ? bool.Parse(test.Attribute("Ignore").Value) : false;

							// TODO - need to handle Ignore better (it won't show in results...)
							if (!ignore)
							{
								yield return new TestCaseData(query)
									.Returns(result)
									.SetCategory(category)
									.SetName(name)
									.SetDescription(description);
							}
						}
					}


				}
			}

			/*
			static IEnumerable<TestCaseData> ArrayExpressions
			{
				get
				{
					yield return new
						TestCaseData("from Order ord where ord.items[0].id = 1234")
						.Returns("( query ( SELECT_FROM ( from ( RANGE Order ord ) ) ) ( where ( = ( . ( [ ( . ord items ) 0 ) id ) 1234 ) ) )");
				}
			}

			static IEnumerable<TestCaseData> ComplexConstructor
			{
				get
				{
					yield return new
						TestCaseData("select new Foo(count(bar)) from bar")
						.Returns("( query ( SELECT_FROM ( from ( RANGE bar ) ) ( select ( ( Foo ( count bar ) ) ) ) )");
					yield return new
						TestCaseData("select new Foo(count(bar),(select count(*) from doofus d where d.gob = 'fat' )) from bar")
						.Returns("( query ( SELECT_FROM ( from ( RANGE bar ) ) ( select ( ( Foo ( count bar ) ( query ( SELECT_FROM ( from ( RANGE doofus d ) ) ( select ( count * ) ) ) ( where ( = ( . d gob ) 'fat' ) ) ) ) ) ) )");
				}
			}*/
		}
	}
}
