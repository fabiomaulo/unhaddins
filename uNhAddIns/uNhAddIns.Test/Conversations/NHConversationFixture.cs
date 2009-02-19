using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NUnit.Framework;
using uNhAddIns.SessionEasier.Conversations;
using uNhAddIns.SessionEasier;

namespace uNhAddIns.Test.Conversations
{
	[TestFixture]
	public class NHConversationFixture: TestCase
	{
		#region Overrides of TestCase

		protected override IList Mappings
		{
			get { return new[] { "Conversations.Silly.hbm.xml" }; }
		}

		#endregion

		[Test]
		public void Ctor()
		{
			Assert.Throws<ArgumentNullException>(() => new NhConversation(null, null));
			Assert.Throws<ArgumentNullException>(() => new NhConversation(null, null, "aKey"));
			Assert.Throws<ArgumentNullException>(() => new NhConversation(new SessionFactoryProviderStub(sessions), null));
			Assert.Throws<ArgumentNullException>(() => new NhConversation(new SessionFactoryProviderStub(sessions), null, "aKey"));
		}

		[Test]
		public void Start()
		{
			var c = new NhConversation(new SessionFactoryProviderStub(sessions), new NoWrappedSessionWrapper());
			ISession s;
			Assert.Throws<ConversationException>(() => s = c.GetSession(sessions));
			c.Start();
			s = c.GetSession(sessions);
			Assert.That(s, Is.Not.Null);
			Assert.That(s.IsOpen);
			c.Start();
			Assert.That(c.GetSession(sessions), Is.SameAs(s),"ReStart of the same conversation should not change the session.");
			Assert.That(s.IsOpen);
		}

		[Test]
		public void End()
		{
			var c = new NhConversation(new SessionFactoryProviderStub(sessions), new NoWrappedSessionWrapper());
			c.End(); // end without start don't throw exception
			c.Start();
			c.End();
			ISession s = c.GetSession(sessions);
			Assert.That(s, Is.Not.Null);
			Assert.That(s.IsOpen, Is.False);
			c.Start();
			ISession s1 = c.GetSession(sessions);
			Assert.That(s1, Is.Not.Null);
			Assert.That(s1.IsOpen);
			Assert.That(s1, Is.Not.SameAs(s));
		}

		[Test]
		public void Pause()
		{
			var c = new NhConversation(new SessionFactoryProviderStub(sessions), new NoWrappedSessionWrapper());
			c.Pause(); // Pause without start don't throw exception
			c.Start();
			c.Pause();
			ISession s = c.GetSession(sessions);
			Assert.That(s, Is.Not.Null);
			Assert.That(s.IsOpen);
			//Assert.That(s.IsConnected, Is.False); need something else in NH
			Assert.That(!s.Transaction.IsActive);
		}

		[Test]
		public void Resume()
		{
			var c = new NhConversation(new SessionFactoryProviderStub(sessions), new NoWrappedSessionWrapper());
			c.Resume(); // Resume without start don't throw exception
			ISession s = c.GetSession(sessions);
			Assert.That(s, Is.Not.Null);
			Assert.That(s.IsOpen);
			Assert.That(s.IsConnected);

			// Resume after a Resume or Start don't change the session
			c.Resume();
			ISession s1 = c.GetSession(sessions);
			Assert.That(s1, Is.SameAs(s));
			Assert.That(s1.IsOpen);
			Assert.That(s1.IsConnected);

			c.Pause();
			c.Resume();
			s1 = c.GetSession(sessions);
			Assert.That(s1, Is.SameAs(s));
			Assert.That(s1.IsOpen);
			Assert.That(s1.IsConnected);

			c.End();
			c.Resume();
			s1 = c.GetSession(sessions);
			Assert.That(s1, Is.Not.SameAs(s));
			Assert.That(s1.IsOpen);
			Assert.That(s1.IsConnected);
		}

		[Test]
		public void Destructor()
		{
			var c = new NhConversation(new SessionFactoryProviderStub(sessions), new NoWrappedSessionWrapper());
			c.Start();
			ISession s = c.GetSession(sessions);
			c.Dispose();
			Assert.That(s, Is.Not.Null);
			Assert.That(s.IsOpen, Is.False);
			Assert.Throws<ConversationException>(() => s = c.GetSession(sessions));
		}

		[Test]
		public void ConversationUsage()
		{
			using (ISession s = OpenSession())
			using (ITransaction tx = s.BeginTransaction())
			{
				var o = new Other {Name = "some other silly"};
				var e = new Silly {Name = "somebody", Other = o};
				s.Save(e);
				tx.Commit();
			}

			using (var c = new NhConversation(new SessionFactoryProviderStub(sessions), new NoWrappedSessionWrapper()))
			{
				c.Start();
				ISession s = c.GetSession(sessions);
				IList<Silly> sl = s.CreateQuery("from Silly").List<Silly>();
				c.Pause();
				Assert.That(sl.Count == 1);
				Assert.That(!NHibernateUtil.IsInitialized(sl[0].Other));
				// working with entities, even using lazy loading
				Assert.That(!s.Transaction.IsActive);
				Assert.That("some other silly", Is.EqualTo(sl[0].Other.Name));
				Assert.That(NHibernateUtil.IsInitialized(sl[0].Other));
				sl[0].Other.Name = "nobody";
				c.Resume();
				s = c.GetSession(sessions);
				s.SaveOrUpdate(sl[0]);
				// the dispose auto-end the conversation
			}

			using (var c = new NhConversation(new SessionFactoryProviderStub(sessions), new NoWrappedSessionWrapper()))
			{
				c.Start();
				ISession s = c.GetSession(sessions);
				s.Delete("from Silly");
				c.End();
			}
		}
	}
}