using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace uNhAddIns.Adapters.CommonTests.Integration
{
	public abstract class FullCreamFixtureBase
	{
		/// <summary>
		/// Initialize the ServiceLocator registering all services needed by this test.
		/// </summary>
		/// <remarks>
		/// The initialization must include the initialization of <see cref="ServiceLocator"/>.
		/// 
		/// Services needed, in this test, are:
		/// 
		/// - uNhAddIns.SessionEasier.ISessionFactoryProvider 
		///		This is a factory where we need to use GetFactory
		///		Implementation: uNhAddIns.SessionEasier.SessionFactoryProvider
		/// 
		/// - uNhAddIns.SessionEasier.ISessionWrapper
		///		Implementation: uNhAddIns.YourAdapter.SessionWrapper if available
		/// 
		/// - uNhAddIns.SessionEasier.Conversations.IConversationFactory
		///		Implementation: uNhAddIns.SessionEasier.Conversations.DefaultConversationFactory
		/// 
		/// - uNhAddIns.SessionEasier.Conversations.IConversationsContainerAccessor
		///		Implementation: uNhAddIns.SessionEasier.Conversations.NhConversationsContainerAccessor
		/// 
		/// - NHibernate.ISessionFactory
		///		Taking the instance using ISessionFactoryProvider.GetFactory with a string parameter setted
		///		using the name of session-factory-configuration (from available template the name is "uNhAddIns")
		/// 
		/// - Microsoft.Practices.ServiceLocation.IServiceLocator
		///		The service locator itself is used by the implementation of DaoFactory
		/// 
		/// - uNhAddIns.Adapters.CommonTests.IDaoFactory
		///		Implementation: uNhAddIns.Adapters.CommonTests.Integration.DaoFactory
		/// 
		/// - uNhAddIns.Adapters.CommonTests.ISillyDao
		///		Implementation : uNhAddIns.Adapters.CommonTests.Integration.SillyDao
		/// 
		/// - uNhAddIns.Adapters.CommonTests.ISillyCrudModel
		///		Implementation : uNhAddIns.Adapters.CommonTests.Integration.SillyCrudModel
		///		Lyfe : Transient
		/// </remarks>
		protected abstract void InitializeServiceLocator();

		[TestFixtureSetUp]
		public void CreateDb()
		{
			Configuration cfg = new Configuration().Configure();
			new SchemaExport(cfg).Create(false, true);
			InitializeServiceLocator();
		}

		[Test]
		public void BasicUsage()
		{
			// This test shows what happens using something else than identity
			var scm1 = ServiceLocator.Current.GetInstance<ISillyCrudModel>();
			var scm2 = ServiceLocator.Current.GetInstance<ISillyCrudModel>();
			Assert.That(scm1, Is.Not.SameAs(scm2),
			            "The model is expected to be configured to return a new instance for every ISillyCrudModel.");

			IList<Silly> l1 = scm1.GetEntirelyList();
			Assert.That(l1.Count, Is.EqualTo(0));

			// We save in a conversation, and then retrieve the results from a different one.
			var s = new Silly {Name = "fiamma"};
			scm1.Save(s);
			Assert.That(s.Id, Is.Not.EqualTo(0));
			int savedId = s.Id;
			scm1.AcceptAll(); // <== To have a result available to other conversation you must end yours

			IList<Silly> l2 = scm2.GetEntirelyList();
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
			var scm1 = ServiceLocator.Current.GetInstance<ISillyCrudModel>();

			IList<Silly> l1 = scm1.GetEntirelyList();
			Assert.That(l1.Count, Is.EqualTo(0));

			var s = new Silly {Name = "fiamma"};
			scm1.Save(s);
			Assert.That(s.Id, Is.Not.EqualTo(0), "The entity didn't receive the hilo id!?!");
			int savedId = s.Id;
			scm1.Abort();

			var scm2 = ServiceLocator.Current.GetInstance<ISillyCrudModel>();
			Assert.That(scm2.GetIfAvailable(savedId), Is.Null, "If it was aborted then it is not present in another conversation");
			scm2.AcceptAll();
		}

		[Test]
		public void ConversationCommitAndContinue()
		{
			var scm1 = ServiceLocator.Current.GetInstance<ISillyCrudModel>();

			IList<Silly> l1 = scm1.GetEntirelyList();
			Assert.That(l1.Count, Is.EqualTo(0));

			var s = new Silly {Name = "fiamma"};
			scm1.Save(s);
			Assert.That(s.Id, Is.Not.EqualTo(0), "The entity didn't receive the hilo id!?!");
			scm1.AcceptAll();
			int savedId = s.Id;

			scm1.ImmediateDelete(s);

			var scm2 = ServiceLocator.Current.GetInstance<ISillyCrudModel>();
			Silly silly = scm2.GetIfAvailable(savedId);
			Assert.That(silly, Is.Null, "Silly was supposed to be removed immediately");
		}
	}
}