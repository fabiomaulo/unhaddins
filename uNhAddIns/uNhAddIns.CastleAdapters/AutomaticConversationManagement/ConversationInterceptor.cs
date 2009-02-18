using System;
using System.Reflection;
using Castle.Core;
using Castle.Core.Interceptor;
using Castle.MicroKernel;
using uNhAddIns.Adapters;
using uNhAddIns.Extensions;
using uNhAddIns.SessionEasier.Conversations;

namespace uNhAddIns.CastleAdapters.AutomaticConversationManagement
{
	[Transient]
	public class ConversationInterceptor : IInterceptor, IOnBehalfAware
	{
		private readonly IKernel kernel;
		private readonly ConversationMetaInfoStore infoStore;
		private ConversationMetaInfo metaInfo;
		private string conversationId;

		public ConversationInterceptor(IKernel kernel, ConversationMetaInfoStore infoStore)
		{
			this.kernel = kernel;
			this.infoStore = infoStore;
		}

		#region Implementation of IInterceptor

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
				var att = metaInfo.GetConversationAttributeFor(methodInfo);
				var cca = kernel[typeof(IConversationsContainerAccessor)] as IConversationsContainerAccessor;
				var cf = kernel[typeof(IConversationFactory)] as IConversationFactory;
				if (cca == null || cf == null)
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
			Type creationInterceptorType = metaInfo.Setting.ConversationCreationInterceptor;
			if (creationInterceptorType != null)
			{
				IConversationCreationInterceptor cci;
				if (creationInterceptorType.IsInterface)
				{
					cci = (IConversationCreationInterceptor) kernel[creationInterceptorType];
				}
				else
				{
					cci = ReflectionExtensions.Instantiate<IConversationCreationInterceptor>(creationInterceptorType);
				}
				cci.Configure(conversation);
			}
		}

		#endregion

		#region Implementation of IOnBehalfAware

		public void SetInterceptedComponentModel(ComponentModel target)
		{
			metaInfo = infoStore.GetMetaFor(target.Implementation);
		}

		#endregion

		private string GetConvesationId(PersistenceConversationalAttribute config)
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