using System;
using System.Reflection;
using Castle.Core;
using Castle.Core.Interceptor;
using Castle.MicroKernel;
using uNhAddIns.Adapters;
using uNhAddIns.Adapters.Common;
using uNhAddIns.Extensions;
using uNhAddIns.SessionEasier.Conversations;

namespace uNhAddIns.CastleAdapters.AutomaticConversationManagement
{
	[Transient]
	public class ConversationInterceptor : IInterceptor, IOnBehalfAware
	{
		private readonly IConversationalMetaInfoStore infoStore;
		private readonly IKernel kernel;
		private string conversationId;
		private IConversationalMetaInfoHolder metaInfo;

		public ConversationInterceptor(IKernel kernel, IConversationalMetaInfoStore infoStore)
		{
			this.kernel = kernel;
			this.infoStore = infoStore;
		}

		#region Implementation of IInterceptor

		private static readonly Type BaseConventionType = typeof (IConversationCreationInterceptorConvention<>);

		public void Intercept(IInvocation invocation)
		{
			MethodInfo methodInfo = invocation.MethodInvocationTarget;

			if (metaInfo == null || !metaInfo.Contains(methodInfo))
			{
				invocation.Proceed();
				return;
			}
			else
			{
				IPersistenceConversationInfo att = metaInfo.GetConversationInfoFor(methodInfo);
				var cca = kernel[typeof (IConversationsContainerAccessor)] as IConversationsContainerAccessor;
				var cf = kernel[typeof (IConversationFactory)] as IConversationFactory;
				if (att == null || cca == null || cf == null)
				{
					invocation.Proceed();
					return;
				}
				string convId = GetConvesationId(metaInfo.Setting);
				IConversation c = cca.Container.Get(convId);
				if (c == null)
				{
					c = cf.CreateConversation(convId);
					// we are using the event because a custom eventHandler can prevent the rethrow
					// but we must Unbind the conversation from the container
					// and we must dispose the conversation itself (high probability UoW inconsistence).
					c.OnException += ((conversation, args) => cca.Container.Unbind(c.Id).Dispose());
					ConfigureConversation(c);
					cca.Container.SetAsCurrent(c);
					c.Start();
				}
				else
				{
					cca.Container.SetAsCurrent(c);
					c.Resume();
				}
				try
				{
					invocation.Proceed();

					switch (att.ConversationEndMode)
					{
						case EndMode.End:
							c.End();
							c.Dispose();
							break;
						case EndMode.Abort:
							c.Abort();
							c.Dispose();
							break;
						case EndMode.CommitAndContinue:
							c.FlushAndPause();
							break;
						default:
							c.Pause();
							break;
					}
				}
				catch (Exception)
				{
					cca.Container.Unbind(c.Id);
					c.Dispose();
					throw;
				}
			}
		}

		private void ConfigureConversation(IConversation conversation)
		{
			IConversationCreationInterceptor cci = null;
			Type creationInterceptorType = metaInfo.Setting.ConversationCreationInterceptor;
			if (creationInterceptorType != null)
			{
				if (creationInterceptorType.IsInterface)
				{
					cci = (IConversationCreationInterceptor) kernel[creationInterceptorType];
				}
				else
				{
					cci = creationInterceptorType.Instantiate<IConversationCreationInterceptor>();
				}
			}
			else
			{
				if (metaInfo.Setting.UseConversationCreationInterceptorConvention)
				{
					Type concreteImplementationType = BaseConventionType.MakeGenericType(metaInfo.ConversationalClass);
					if (kernel.HasComponent(concreteImplementationType))
					{
						cci = (IConversationCreationInterceptor) kernel[concreteImplementationType];
					}
				}
			}
			if (cci != null)
			{
				cci.Configure(conversation);
			}
		}

		#endregion

		#region Implementation of IOnBehalfAware

		public void SetInterceptedComponentModel(ComponentModel target)
		{
			metaInfo = infoStore.GetMetadataFor(target.Implementation);
		}

		#endregion

		private string GetConvesationId(IPersistenceConversationalInfo config)
		{
			if (conversationId == null)
			{
				if (!string.IsNullOrEmpty(config.ConversationId))
				{
					conversationId = config.ConversationId;
				}
				else if (!string.IsNullOrEmpty(config.IdPrefix))
				{
					conversationId = config.IdPrefix + Guid.NewGuid();
				}
				else
				{
					conversationId = Guid.NewGuid().ToString();
				}
			}
			return conversationId;
		}
	}
}