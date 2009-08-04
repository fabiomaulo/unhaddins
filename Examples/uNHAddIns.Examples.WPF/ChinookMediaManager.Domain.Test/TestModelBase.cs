using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NHibernate;
using NHibernate.Engine;
using NUnit.Framework;
using uNhAddIns.Adapters;
using uNhAddIns.SessionEasier.Conversations;

namespace ChinookMediaManager.Domain.Test
{
    public class TestModelBase
    {
        private readonly IGuyWire guyWire = ApplicationConfiguration.GetGuyWire();
        protected ISessionFactory sessions;

        protected IWindsorContainer container;
        
        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            guyWire.Wire();
            var containerAccessor = (IContainerAccessor)guyWire;
            
            container = containerAccessor.Container;
            
            container.Register(Component.For(typeof (IConversationCreationInterceptorConvention<>))
                                   .ImplementedBy(typeof (ConversationObserver<>)));

            sessions = container.Resolve<ISessionFactory>();

            OnSetup();
        }

        public virtual void OnSetup(){}
        public virtual void OnTeardown(){}

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            OnTeardown();
            guyWire.Dewire();
        }


        public void Assert_Was_Ended<T>(Action action, ConversationObserver<T> conversationObserver) where T : class
        {
            bool conversationWasEnded = false;
            conversationObserver.Ending += (sender, args) =>
            {
                conversationWasEnded = true;
            };
            action();
            conversationWasEnded.Should().Be.True();
        }
        public void Assert_Was_Aborted<T>(Action action, ConversationObserver<T> conversationObserver) where T : class
        {
            bool conversationWasAborted = false;
            conversationObserver.Aborting += (sender, args) =>
            {
                conversationWasAborted = true;
            };
            action();
            conversationWasAborted.Should().Be.True();
        }

    }
}