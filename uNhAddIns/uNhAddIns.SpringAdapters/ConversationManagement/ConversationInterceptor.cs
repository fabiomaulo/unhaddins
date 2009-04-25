using System;
using System.Collections;
using System.Reflection;
using AopAlliance.Intercept;
using Spring.Objects.Factory;
using uNhAddIns.Adapters.Common;
using uNhAddIns.SessionEasier.Conversations;

namespace uNhAddIns.SpringAdapters.ConversationManagement
{
	public class ConversationInterceptor : AbstractConversationInterceptor, IMethodInterceptor
	{
		private readonly IListableObjectFactory factory;

		public ConversationInterceptor(IListableObjectFactory factory, IConversationalMetaInfoStore metadataStore,
		                               IConversationsContainerAccessor conversationsContainerAccessor,
		                               IConversationFactory conversationFactory)
			: base(metadataStore, conversationsContainerAccessor, conversationFactory)
		{
			this.factory = factory;
		}

		#region IMethodInterceptor Members

		public object Invoke(IMethodInvocation invocation)
		{
			MethodInfo methodInfo = invocation.Method;
			if (!ShouldBeIntercepted(methodInfo))
			{
				return invocation.Proceed();
			}
			else
			{
				BeforeMethodExecution(methodInfo);
				try
				{
					object result = invocation.Proceed();
					AfterMethodExecution(methodInfo);
					return result;
				}
				catch (Exception)
				{
					DisposeConversationOnException();
					throw;
				}
			}
		}

		#endregion

		protected override Type GetConversationalImplementor()
		{
			throw new NotImplementedException();
		}

		protected override IConversationCreationInterceptor GetConversationCreationInterceptor(Type configuredConcreteType)
		{
			var convCtorInterceptors = factory.GetObjectsOfType(configuredConcreteType).Values;
			IEnumerator it = convCtorInterceptors.GetEnumerator();
			if (it.MoveNext())
			{
				return (IConversationCreationInterceptor) it.Current;
			}
			return null;
		}
	}
}