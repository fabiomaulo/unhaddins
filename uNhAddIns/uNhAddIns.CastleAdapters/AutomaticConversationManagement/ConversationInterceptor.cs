using System;
using System.Reflection;
using Castle.Core;
using Castle.Core.Interceptor;
using Castle.MicroKernel;
using uNhAddIns.Adapters.Common;
using uNhAddIns.SessionEasier.Conversations;

namespace uNhAddIns.CastleAdapters.AutomaticConversationManagement
{
	[Transient]
	public class ConversationInterceptor : AbstractConversationInterceptor, IInterceptor, IOnBehalfAware
	{
		private readonly IKernel kernel;
		private Type targetImplementation;

		public ConversationInterceptor(IKernel kernel, IConversationalMetaInfoStore metadataStore) 
			: base(metadataStore)
		{
			this.kernel = kernel;
		}

		#region Implementation of IInterceptor

		public void Intercept(IInvocation invocation)
		{
			MethodInfo methodInfo = invocation.MethodInvocationTarget;
			if (!ShouldBeIntercepted(methodInfo))
			{
				invocation.Proceed();
				return;
			}
			else
			{
				BeforeMethodExecution(methodInfo);
				try
				{
					invocation.Proceed();
					AfterMethodExecution(methodInfo);
				}
				catch (Exception)
				{
					DisposeConversationOnException();
					throw;
				}
			}
		}

		#endregion

		#region Implementation of IOnBehalfAware

		public void SetInterceptedComponentModel(ComponentModel target)
		{
			targetImplementation = target.Implementation;
		}

		#endregion

		protected override Type GetConversationalImplementor()
		{
			return targetImplementation;
		}

		protected override IConversationsContainerAccessor GetConversationsContainerAccessor()
		{
			return kernel[typeof (IConversationsContainerAccessor)] as IConversationsContainerAccessor;
		}

		protected override IConversationFactory GetConversationFactory()
		{
			return kernel[typeof (IConversationFactory)] as IConversationFactory;
		}

		protected override IConversationCreationInterceptor GetConversationCreationInterceptor(Type configuredConcreteType)
		{
			return kernel.HasComponent(configuredConcreteType)
			       	? (IConversationCreationInterceptor) kernel[configuredConcreteType]
			       	: null;
		}
	}
}