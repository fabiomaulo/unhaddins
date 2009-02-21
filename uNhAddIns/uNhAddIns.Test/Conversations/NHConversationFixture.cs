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

		protected override IList<string> Mappings
		{
			get { return new[] { "Conversations.Silly.hbm.xml" }; }
		}

		#endregion

	    protected override void OnTearDown()
	    {
	        CommitInNewSession(session => session.Delete("from Silly"));
	    }

	    private void AssertExistsInDb(Silly persistedObject)
	    {
	        Assert.That(ExistsInDb<Silly>(persistedObject.Id), Is.True, "object expected to be in db");
	    }

	    private void AssertDoesNotExistInDb(Silly persistedObject)
	    {
	        Assert.That(ExistsInDb<Silly>(persistedObject.Id), Is.False, "object expected not to be in db");
	    }

	    private void AssertIsOpen(ISession s)
	    {
	        Assert.That(s, Is.Not.Null);
	        Assert.That(s.IsOpen);
	    }

	    private void AssertIsPaused(ISession s)
	    {
	        AssertIsOpen(s);
	        //Assert.That(s.IsConnected, Is.False); need something else in NH
	        Assert.That(!s.Transaction.IsActive);
	    }


	    private NhConversation NewConversation()
	    {
	        return new NhConversation(new SessionFactoryProviderStub(sessions), new NoWrappedSessionWrapper());
	    }

	    private NhConversation NewStartedConversation()
	    {
	        var c = NewConversation();
	        c.Start();
	        ISession s = c.GetSession(sessions);
	        Assert.That(s.IsOpen, Is.True, "UoW expected to be started");
	        return c;
	    }


	    private NhConversation NewPausedConversation()
	    {
	        var c = NewConversation();
	        c.Start();
	        c.Pause();
	        AssertIsPaused(c.GetSession(sessions));
	        return c;
	    }

	    [Test]
	    public void Ctor()
	    {
	        Assert.Throws<ArgumentNullException>(() => new NhConversation(null, null));
	        Assert.Throws<ArgumentNullException>(() => new NhConversation(null, null, "aKey"));
	        Assert.Throws<ArgumentNullException>(() => new NhConversation(new SessionFactoryProviderStub(sessions), null));
	        Assert.Throws<ArgumentNullException>(() => new NhConversation(new SessionFactoryProviderStub(sessions), null, "aKey"));
	    }

	    [Test]
		public void GetSessionsShouldThrowWhenConversationNotYetStarted()
		{
			var c = NewConversation();
		    Assert.Throws<ConversationException>(() => { ISession s = c.GetSession(sessions); });
		}

	    #region Start examples

	    [Test]
		public void StartShouldStartUnitOfWork()
		{
	        var c = NewConversation();

		    c.Start();
			ISession s = c.GetSession(sessions);
            AssertIsOpen(s);
		}

	    [Test]
	    public void StartedUnitOfWorkShouldNotFlushToDatabaseUntilEndOfConversation()
	    {
	        var c = NewStartedConversation();

            ISession s = c.GetSession(sessions);

	        Assert.That(s.FlushMode, Is.EqualTo(FlushMode.Never));
	    }

	    [Test]
	    public void StartCalledTwiceWithoutEndShouldNotStartAnotherUnitOfWork()
	    {
	        var c = NewConversation();
	        c.Start();
	        ISession s = c.GetSession(sessions);

	        c.Start();
	        Assert.That(c.GetSession(sessions), Is.SameAs(s),"ReStart of the same conversation should not change the session.");
	        Assert.That(s.IsOpen);
	    }

	    [Test]
	    public void StartAfterEndShouldStartAnotherUnitOfWork()
	    {
	        var c = NewStartedConversation();
	        ISession previousUoW = c.GetSession(sessions);
	        c.End();

	        c.Start();
	        ISession currentUoW = c.GetSession(sessions);
	        AssertIsOpen(currentUoW);
	        Assert.That(currentUoW, Is.Not.SameAs(previousUoW));
	    }

	    #endregion

	    #region End examples

	    [Test]
	    public void EndWithoutStartShouldNotThrow()
	    {
	        var c = NewConversation();
	        Assert.DoesNotThrow(c.End);
	    }

	    [Test]
	    public void EndShouldCloseStartedUnitOfWork()
	    {
	        NhConversation c = NewStartedConversation();

	        c.End();
	        ISession s = c.GetSession(sessions);
	        Assert.That(s, Is.Not.Null);
	        Assert.That(s.IsOpen, Is.False);
	    }

        [Test]
        public void EndShouldFlushStartedUnitOfWork()
        {
            NhConversation c = NewStartedConversation();
            ISession s = c.GetSession(sessions);
            var persistedObj = new Silly();
            s.Save(persistedObj);

            c.End();
            AssertExistsInDb(persistedObj);
        }


        [Test]
        public void EndShouldFlushResumedUnitOfWork()
        {
            NhConversation c = NewPausedConversation();
            c.Resume();
            ISession s = c.GetSession(sessions);
            var persistedObj = new Silly();
            s.Save(persistedObj);

            c.End();
            AssertExistsInDb(persistedObj);
        }

        [Test]
        public void EndShouldNotFlushPausedUnitOfWork()
        {
            NhConversation c = NewPausedConversation();
            ISession s = c.GetSession(sessions);
            var persistedObj = new Silly();
            s.Save(persistedObj);

            c.End();
            AssertDoesNotExistInDb(persistedObj);
        }

	    #endregion

	    #region Pause examples

	    [Test]
		public void PauseWithoutStartShouldNotThrow()
		{
	        var c = NewConversation();
            Assert.DoesNotThrow(c.Pause);
		}


	    [Test]
		public void PauseShouldDisconnectButNotCloseUnitOfWork()
		{
			var c = NewStartedConversation();

			c.Pause();
			ISession s = c.GetSession(sessions);
			AssertIsPaused(s);
		}

        [Test]
        public void PauseShouldNotFlushUnitOfWork()
        {
            var c = NewStartedConversation();
            var persistedObj = new Silly();
            c.GetSession(sessions).Save(persistedObj);

            c.Pause();
            AssertDoesNotExistInDb(persistedObj);
        }


	    #endregion

	    #region Resume examples

	    [Test]
		public void ResumeWithoutStartShouldNotThrow()
		{
		    var c = NewConversation();
            Assert.DoesNotThrow(c.Resume);
		}


	    [Test]
		public void ResumeWithoutPauseShouldNotThrow()
		{
		    var c = NewStartedConversation();
            Assert.DoesNotThrow(c.Resume);
		}


		[Test]
		public void ResumeShouldReconnectUnitOfWork()
		{
            var c = NewPausedConversation();

            c.Resume();
			ISession s = c.GetSession(sessions);
			AssertIsOpen(s);
			Assert.That(s.IsConnected);
		}


        [Test]
        public void ResumeAfterPauseShouldNotStatAnotherUnitOfWork()
        {
            var c = NewPausedConversation();
            ISession pausedUoW = c.GetSession(sessions);

            c.Resume();
            ISession currentUoW = c.GetSession(sessions);
            Assert.That(currentUoW, Is.SameAs(pausedUoW));
        }


        [Test]
        public void ResumeAfterStartShouldNotStatAnotherUnitOfWork()
        {
            var c = NewStartedConversation();
            ISession startedUoW = c.GetSession(sessions);

            c.Resume();
            ISession currentUoW = c.GetSession(sessions);
            Assert.That(currentUoW, Is.SameAs(startedUoW));
        }


		[Test]
		public void ResumeAfterEndShouldStartAnotherUnitOfWork()
		{
			var c = NewPausedConversation();
			c.Resume();
		    ISession previousUoW = c.GetSession(sessions);
			c.End();

			c.Resume();
			ISession currentUoW = c.GetSession(sessions);
		    AssertIsOpen(currentUoW);
		    Assert.That(currentUoW, Is.Not.SameAs(previousUoW));
		}

	    #endregion

	    [Test]
		public void ConversationUsage()
		{
	        CommitInNewSession(session =>
	                               {
	                                   var o = new Other() {Name = "some other silly"};
	                                   var e = new Silly() {Name = "somebody", Other = o};
	                                   session.Save(e);
	                               });

	        using (var c = NewConversation())
	        {
	            c.Start();
	            ISession s = c.GetSession(sessions);
                var sl = s.CreateQuery("from Silly").List<Silly>();
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

	        using (var c = NewConversation())
	        {
	            c.Start();
	            ISession s = c.GetSession(sessions);
                s.Delete("from Silly");
	            c.End();
	        }
		}

	    [Test]
	    public void Destructor()
	    {
	        var c = NewStartedConversation();
	        ISession s = c.GetSession(sessions);
	        c.Dispose();
	        Assert.That(s, Is.Not.Null);
	        Assert.That(s.IsOpen, Is.False);
	        Assert.Throws<ConversationException>(() => s = c.GetSession(sessions));
	    }
	}
}