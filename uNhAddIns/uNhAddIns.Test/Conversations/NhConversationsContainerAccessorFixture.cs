using System;
using Castle.Core.Interceptor;
using NUnit.Framework;
using NUnit.Framework.Syntax.CSharp;
using uNhAddIns.SessionEasier;
using uNhAddIns.SessionEasier.Conversations;
using NHibernate;
using NHibernate.Engine;

namespace uNhAddIns.Test.Conversations
{
	[TestFixture]
	public class NhConversationsContainerAccessorFixture
	{
		[Test]
		public void Ctor()
		{
			Assert.Throws<ArgumentNullException>(() => new NhConversationsContainerAccessor(null));
			Assert.Throws<ConversationException>(() => new NhConversationsContainerAccessor(new ISessionFactory[0]));
			var invalidSFmock =
				(ISessionFactory)
				Commons.ProxyGenerator.CreateInterfaceProxyWithoutTarget(typeof(ISessionFactory), new InvalidSessionFactory());
			Assert.Throws<ConversationException>(() => new NhConversationsContainerAccessor(new[] { invalidSFmock }));

			var notvalidSFmock =
				(ISessionFactory)
				Commons.ProxyGenerator.CreateInterfaceProxyWithoutTarget(
				typeof(ISessionFactory), 
				new[] { typeof(ISessionFactory), typeof(ISessionFactoryImplementor) }, 
				new MayValidSessionFactory(null));
			Assert.Throws<ConversationException>(() => new NhConversationsContainerAccessor(new[] { notvalidSFmock }));

			var container = new ThreadLocalConversationalSessionContext(null);
			var validSFmock =
				(ISessionFactoryImplementor)
				Commons.ProxyGenerator.CreateInterfaceProxyWithoutTarget(
				typeof(ISessionFactoryImplementor), 
				new[] { typeof(ISessionFactory), typeof(ISessionFactoryImplementor) },
				new MayValidSessionFactory(container));
			var ca = new NhConversationsContainerAccessor(new[] { validSFmock });
			Assert.That(ca.Container, Is.SameAs(container));
		}

		private class InvalidSessionFactory : Castle.Core.Interceptor.IInterceptor
		{
			public void Intercept(IInvocation invocation) { }
		}

		private class MayValidSessionFactory : Castle.Core.Interceptor.IInterceptor
		{
			private readonly IConversationContainer container;

			public MayValidSessionFactory(IConversationContainer container)
			{
				this.container = container;
			}

			public void Intercept(IInvocation invocation)
			{
				invocation.ReturnValue = null;
				if ("get_CurrentSessionContext".Equals(invocation.Method.Name))
					invocation.ReturnValue = container;
			}
		}
	}
}