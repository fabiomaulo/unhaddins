using System;
using LinFu.DynamicProxy;
using NHibernate;
using NHibernate.Engine;
using NUnit.Framework;
using NUnit.Framework.Syntax.CSharp;
using uNhAddIns.SessionEasier.Conversations;
using IInterceptor=LinFu.DynamicProxy.IInterceptor;

namespace uNhAddIns.Test.Conversations
{
	[TestFixture]
	public class NhConversationsContainerAccessorFixture
	{
		private static readonly ProxyFactory proxyGenerator = new ProxyFactory();

		private class InvalidSessionFactory : IInterceptor
		{
			#region IInterceptor Members

			public object Intercept(InvocationInfo info)
			{
				return null;
			}

			#endregion
		}

		private class MayValidSessionFactory : IInterceptor
		{
			private readonly IConversationContainer container;

			public MayValidSessionFactory(IConversationContainer container)
			{
				this.container = container;
			}

			#region IInterceptor Members

			public object Intercept(InvocationInfo info)
			{
				return "get_CurrentSessionContext".Equals(info.TargetMethod.Name) ? container : null;
			}

			#endregion
		}

		[Test]
		public void Ctor()
		{
			Assert.Throws<ArgumentNullException>(() => new NhConversationsContainerAccessor(null));
			Assert.Throws<ConversationException>(() => new NhConversationsContainerAccessor(new ISessionFactory[0]));
			var invalidSFmock = proxyGenerator.CreateProxy<ISessionFactory>(new InvalidSessionFactory());
			Assert.Throws<ConversationException>(() => new NhConversationsContainerAccessor(new[] {invalidSFmock}));

			var notvalidSFmock = proxyGenerator.CreateProxy<ISessionFactoryImplementor>(new MayValidSessionFactory(null),
			                                                                 new[]
			                                                                 	{
			                                                                 		typeof (ISessionFactory)
			                                                                 	});
			Assert.Throws<ConversationException>(() => new NhConversationsContainerAccessor(new[] {notvalidSFmock}));

			var container = new ThreadLocalConversationalSessionContext(null);
			var validSFmock = proxyGenerator.CreateProxy<ISessionFactoryImplementor>(new MayValidSessionFactory(container),
			                                                              new[]
			                                                              	{
			                                                              		typeof (ISessionFactory)
			                                                              	});
			var ca = new NhConversationsContainerAccessor(new[] {validSFmock});
			Assert.That(ca.Container, Is.SameAs(container));
		}
	}
}