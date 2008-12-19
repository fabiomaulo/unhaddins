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
			// This test shows what happens using something else than identity
			var scm1 = Container.Resolve<ISillyCrudModel>();
			var scm2 = Container.Resolve<ISillyCrudModel>();
			Assert.That(scm1, Is.Not.SameAs(scm2),"The model is expected to be configured to return a new instance for every ISillyCrudModel.");

			var l1 = scm1.GetEntirelyList();
			Assert.That(l1.Count, Is.EqualTo(0));

			// We save in a conversation, and then retrieve the results from a different one.
			Silly s = new Silly { Name = "fiamma" };
			scm1.Save(s);
			Assert.That(s.Id, Is.Not.EqualTo(0));
			int savedId = s.Id;
			scm1.AcceptAll(); // <== To have a result available to other conversation you must end yours

			var l2 = scm2.GetEntirelyList();
			Assert.That(l2.Count, Is.EqualTo(1));
			Assert.That("fiamma", Is.EqualTo(l2[0].Name));
			Assert.That(l2[0], Is.Not.SameAs(s), "the two instances of Silly should be of a different session");
			scm2.Delete(l2[0]);
			scm2.AcceptAll();

			// the conversation should resume and the entity should not be associated to the current session
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
			Assert.That(s.Id, Is.Not.EqualTo(0), "The entity didn't receive the hilo id!?!");
			int savedId = s.Id;
			scm1.Abort();

			var scm2 = Container.Resolve<ISillyCrudModel>();
			Assert.That(scm2.GetIfAvailable(savedId), Is.Null, "If it was aborted then it is not present in another conversation");
			scm2.AcceptAll();
		}
	}
}