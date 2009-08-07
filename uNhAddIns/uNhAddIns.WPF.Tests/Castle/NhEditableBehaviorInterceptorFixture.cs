using System.Reflection;
using Castle.Core.Interceptor;
using Castle.Windsor;
using Moq;
using NHibernate;
using NHibernate.Engine;
using NUnit.Framework;
using uNhAddIns.WPF.Castle;
using uNhAddIns.WPF.Tests.SampleDomain;

namespace uNhAddIns.WPF.Tests.Castle
{
    [TestFixture]
    public class NhEditableBehaviorInterceptorFixture
    {
        [Test]
        public void endedit_should_call_session_persist()
        {
            var album = new Album();

            var sessionFactory = new Mock<ISessionFactoryImplementor>();
            var session = new Mock<ISession>();
            session.Setup(s => s.Persist(album)).AtMostOnce();
            sessionFactory.Setup(s => s.GetCurrentSession()).Returns(session.Object);

            
            var invocation = new Mock<IInvocation>();
            var method = new Mock<MethodInfo>();
            method.SetupGet(m => m.Name).Returns("EndEdit");
            invocation.SetupGet(inv => inv.Method).Returns(method.Object);
            invocation.SetupGet(inv => inv.InvocationTarget).Returns(album);
 

            var editableBehavior = new NhEditableBehaviorInterceptor(sessionFactory.Object);

            editableBehavior.Intercept(invocation.Object);

            session.Verify(s => s.Persist(album));

        }


        [Test]
        public void canceledit_should_call_session_refresh()
        {
            var album = new Album();

            var sessionFactory = new Mock<ISessionFactoryImplementor>();
            var session = new Mock<ISession>();
            session.Setup(s => s.Refresh(album)).AtMostOnce();
            sessionFactory.Setup(s => s.GetCurrentSession()).Returns(session.Object);


            var invocation = new Mock<IInvocation>();
            var method = new Mock<MethodInfo>();
            method.SetupGet(m => m.Name).Returns("CancelEdit");
            invocation.SetupGet(inv => inv.Method).Returns(method.Object);
            invocation.SetupGet(inv => inv.InvocationTarget).Returns(album);


            var editableBehavior = new NhEditableBehaviorInterceptor(sessionFactory.Object);

            editableBehavior.Intercept(invocation.Object);

            session.Verify(s => s.Refresh(album));

        }

        [Test]
        public void beginedit_should_not_proceed()
        {

            var sessionFactory = new Mock<ISessionFactoryImplementor>();

            var invocation = new Mock<IInvocation>();
            var method = new Mock<MethodInfo>();
            method.SetupGet(m => m.Name).Returns("BeginEdit");
            invocation.SetupGet(inv => inv.Method).Returns(method.Object);

            var editableBehavior = new NhEditableBehaviorInterceptor(sessionFactory.Object);

            editableBehavior.Intercept(invocation.Object);

            invocation.VerifyAll();

        }

        [Test]
        public void other_method_name_should_proceed()
        {
            var sessionFactory = new Mock<ISessionFactoryImplementor>();

            var invocation = new Mock<IInvocation>();
            var method = new Mock<MethodInfo>();
            method.SetupGet(m => m.Name).Returns("BeginEndCancelPropertyInfo");
            invocation.SetupGet(inv => inv.Method).Returns(method.Object);
            invocation.Setup(inv => inv.Proceed()).AtMostOnce();


            var editableBehavior = new NhEditableBehaviorInterceptor(sessionFactory.Object);

            editableBehavior.Intercept(invocation.Object);

            invocation.Verify(inv=> inv.Proceed());
        }

    }
}