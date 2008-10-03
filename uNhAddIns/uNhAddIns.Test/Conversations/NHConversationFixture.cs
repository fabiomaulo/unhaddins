using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NUnit.Framework;
using NUnit.Framework.Syntax.CSharp;
using uNhAddIns.SessionEasier;
using NHibernate.Util;
using uNhAddIns.SessionEasier.Conversations;

namespace uNhAddIns.Test.Conversations
{
	[TestFixture]
	public class NHConversationFixture: TestCase
	{
		private class SessionFactoryProviderStub: ISessionFactoryProvider
		{
			private readonly ISessionFactory factory;
			private readonly IEnumerable<ISessionFactory> esf;

			public SessionFactoryProviderStub(ISessionFactory factory)
			{
				this.factory = factory;
				esf = new SingletonEnumerable<ISessionFactory>(factory);
			}

			#region Implementation of IInitializable

			public void Initialize()
			{
			}

			#endregion

			#region Implementation of IEnumerable

			public IEnumerator<ISessionFactory> GetEnumerator()
			{
				return esf.GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}

			#endregion

			#region Implementation of IDisposable

			public void Dispose()
			{
				
			}

			public ISessionFactory GetFactory(string factoryId)
			{
				return factory;
			}

			#endregion
		}

		#region Overrides of TestCase

		protected override IList Mappings
		{
			get { return new[] { "Conversations.Silly.hbm.xml" }; }
		}

		#endregion

		[Test]
		public void Ctor()
		{
			Assert.Throws<ArgumentNullException>(() => new NhConversation(null));
			Assert.Throws<ArgumentNullException>(() => new NhConversation(null, "aKey"));
		}

		[Test]
		public void Start()
		{
			var c = new NhConversation(new SessionFactoryProviderStub(sessions));
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
			var c = new NhConversation(new SessionFactoryProviderStub(sessions));
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
			var c = new NhConversation(new SessionFactoryProviderStub(sessions));
			c.Pause(); // Pause without start don't throw exception
			c.Start();
			c.Pause();
			ISession s = c.GetSession(sessions);
			Assert.That(s, Is.Not.Null);
			Assert.That(s.IsOpen);
			Assert.That(s.IsConnected, Is.False);
		}

		[Test]
		public void Resume()
		{
			var c = new NhConversation(new SessionFactoryProviderStub(sessions));
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
			var c = new NhConversation(new SessionFactoryProviderStub(sessions));
			c.Start();
			ISession s = c.GetSession(sessions);
			c.Dispose();
			Assert.That(s, Is.Not.Null);
			Assert.That(s.IsOpen, Is.False);
			Assert.Throws<ConversationException>(() => s = c.GetSession(sessions));
		}
	}
}