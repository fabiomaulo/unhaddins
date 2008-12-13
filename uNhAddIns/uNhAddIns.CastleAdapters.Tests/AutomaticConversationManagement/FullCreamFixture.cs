using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using NUnit.Framework.Syntax.CSharp;

namespace uNhAddIns.CastleAdapters.Tests.AutomaticConversationManagement
{
	[TestFixture]
	public class FullCreamFixture : BaseTestFixture
	{
		[TestFixtureSetUp]
		public void CreateDb()
		{
			Configuration cfg = new Configuration().Configure();
			new SchemaExport(cfg).Create(false, true);
		}

		[Test]
		public void BasicUsage()
		{
			// This test show the what happen using something else than identity
			var scm1 = Container.Resolve<ISillyCrudModel>();
			var scm2 = Container.Resolve<ISillyCrudModel>();
			Assert.That(scm1, Is.Not.SameAs(scm2),"El model estaría mal configurado porque devuelve siempre la misma instancia.");

			var l1 = scm1.GetEntirelyList();
			Assert.That(l1.Count, Is.EqualTo(0));

			// Guardo con una conversation y levanto con otra y las modificaciones estan
			Silly s = new Silly { Name = "fiamma" };
			scm1.Save(s);
			Assert.That(s.Id, Is.Not.EqualTo(0));
			int savedId = s.Id;
			scm1.AcceptAll(); // <== To have a result available to other conversation you must end your

			var l2 = scm2.GetEntirelyList();
			Assert.That(l2.Count, Is.EqualTo(1));
			Assert.That("fiamma", Is.EqualTo(l2[0].Name));
			Assert.That(l2[0], Is.Not.SameAs(s), "las dos instancias no deberían ser de la misma session");
			scm2.Delete(l2[0]);
			scm2.AcceptAll();

			// la conversation tendría que volver a empezar y la session.cache debería estar limpia
			Assert.That(scm1.GetIfAvailable(savedId), Is.Null);
			scm1.AcceptAll();
		}

		[Test]
		public void ConversationAbort()
		{
			var scm1 = Container.Resolve<ISillyCrudModel>();
			
			var l1 = scm1.GetEntirelyList();
			Assert.That(l1.Count, Is.EqualTo(0));

			Silly s = new Silly { Name = "fiamma" };
			scm1.Save(s);
			Assert.That(s.Id, Is.Not.EqualTo(0));
			int savedId = s.Id;
			scm1.Abort();

			var scm2 = Container.Resolve<ISillyCrudModel>();
			Assert.That(scm2.GetIfAvailable(savedId), Is.Null);
			scm2.AcceptAll();
		}
	}
}