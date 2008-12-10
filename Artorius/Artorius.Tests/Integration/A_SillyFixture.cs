using System.Collections.Generic;
using log4net.Config;
using NHibernate.Cfg;
using NHibernate.Engine;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace Artorius.Tests.Integration
{
	[TestFixture, Ignore("Not supported yet.")]
	public class A_SillyFixture
	{
		protected Configuration cfg;
		protected ISessionFactoryImplementor sessions;

		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			XmlConfigurator.Configure();
			cfg = new Configuration();
			cfg.Configure();
			cfg.SetProperty(Environment.QueryTranslator, typeof(NHibernate.Hql.Ast.GoldImpls.QueryTranslatorFactory).AssemblyQualifiedName);
			cfg.AddResource("Artorius.Tests.Integration.Silly.hbm.xml", typeof(Silly).Assembly);
			new SchemaExport(cfg).Create(false, true);
			sessions = (ISessionFactoryImplementor)cfg.BuildSessionFactory();
		}

		[TestFixtureTearDown]
		public void TestFixtureTearDown()
		{
			new SchemaExport(cfg).Drop(false, true);
			sessions.Close();
			sessions = null;
			cfg = null;
		}

		[Test]
		public void FirstSimpleQuery()
		{
			object savedId;

			using (var session = sessions.OpenSession())
			using (var tx = session.BeginTransaction())
			{
				var animal = new Silly { Description = "Artorius fight behind me." };
				savedId=session.Save(animal);
				tx.Commit();
			}

			using (var session = sessions.OpenSession())
			{
				IList<Silly> l = session.CreateQuery("from Silly").List<Silly>();
				Assert.That(l.Count, Is.EqualTo(1));
			}

			using (var session = sessions.OpenSession())
			using (var tx = session.BeginTransaction())
			{
				var animal = session.Get<Silly>(savedId);
				session.Delete(animal);
				tx.Commit();
			}
		}
	}
}