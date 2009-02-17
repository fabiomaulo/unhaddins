using System;
using System.Reflection;
using Castle.Core;
using Castle.Core.Interceptor;
using Castle.MicroKernel;
using uNhAddIns.Adapters;
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
				IConversation c = cca.Container.Get(convId) ?? cf.CreateConversation(convId);
				cca.Container.SetAsCurrent(c);
				c.Resume();
				try
				{
					invocation.Proceed();

					if (att.ConversationEndMode == EndMode.End)
					{
						c.End();
					}
					else
					{
						if (att.ConversationEndMode == EndMode.Abort)
						{
							c.Dispose();
						}
						else
						{
							c.Pause();
						}
					}
				}
				catch (Exception)
				{
					cca.Container.Unbind(c.Id).Dispose();
					throw;
				}
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