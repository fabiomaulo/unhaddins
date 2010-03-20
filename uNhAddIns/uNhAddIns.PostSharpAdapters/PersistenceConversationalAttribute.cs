using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using PostSharp.Extensibility;
using PostSharp.Laos;
using uNhAddIns.Adapters;
using uNhAddIns.Extensions;
using uNhAddIns.SessionEasier.Conversations;

namespace uNhAddIns.PostSharpAdapters
{
	[Serializable]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true)]
	[MulticastAttributeUsage(MulticastTargets.Method)]
	public class PsPersistenceConversationalAttribute : OnMethodBoundaryAspect
	{
		protected static readonly Type BaseConventionType = typeof(IConversationCreationInterceptorConvention<>);
		protected static readonly ConversationPausedWatcher ConversationPausedWatcher = new ConversationPausedWatcher();
		protected static readonly object NestedMethodMarker = new object();

		/// <summary>
		/// Initializes a new instance of the <see cref="PersistenceConversationalAttribute"/> class.
		/// </summary>
		public PsPersistenceConversationalAttribute()
		{
			ConversationEndMode = EndMode.Continue;
			UseConversationCreationInterceptorConvention = true;
			//MethodsIncludeMode = MethodsIncludeMode.Implicit;
			AttributeTargetElements = MulticastTargets.Method;
			AttributeTargetTypeAttributes = MulticastAttributes.Public;
		}

		/// <summary>
		/// Fixed Conversation's Id for the target class.
		/// </summary>
		/// <remarks>
		/// Optional.
		/// <para>
		/// Only use it when multiple instances of the target class must work in the same conversation.
		/// </para>
		/// </remarks>
		public string ConversationId { get; set; }

		/// <summary>
		/// Conversation's Id prefix.
		/// </summary>
		/// <remarks>
		/// Optional.
		/// <para>
		/// The result conversation's Id will be composed by IdPrefix + UniqueId
		/// </para>
		/// </remarks>
		public string IdPrefix { get; set; }

		
		///// <summary>
		///// Define the <see cref="EndMode"/> of each method where not explicity declared.
		///// </summary>
		///// <remarks>
		///// Optional, default <see cref="EndMode.Continue"/>
		///// </remarks>
		//public EndMode DefaultEndMode { get; set; }
		public EndMode ConversationEndMode { get; set; }

		///<summary>
		/// Define the class where conversation's events handlers are implemented.
		///</summary>
		/// <remarks>
		/// The class must implements IConversationCreationInterceptor.
		/// </remarks>
		public Type ConversationCreationInterceptor { get; set; }

		/// <summary>
		/// Use the IoC container to discover the implementor of IConversationCreationInterceptorConvention{T}
		/// where T is the class indicated by <seealso cref="PersistenceConversationalAttribute"/>.
		/// </summary>
		public bool UseConversationCreationInterceptorConvention { get; set; }

		/// <summary>
		/// Allow persistent call outside of the service scope.	Usefull in combination with linq queries.
		/// </summary>
		/// <remarks>
		/// Optional, default false
		/// </remarks>
		public bool AllowOutsidePersistentCall { get; set;}


		protected IConversationsContainerAccessor ConversationsContainerAccessor
		{
			get
			{
				return ServiceLocator.Current.GetInstance<IConversationsContainerAccessor>();
			}
		}

		protected IConversationFactory ConversationFactory
		{
			get
			{
				return ServiceLocator.Current.GetInstance<IConversationFactory>();
			}
		}


		public override void OnException(MethodExecutionEventArgs eventArgs)
		{
			if (IsNoopConversationalMarkerActive) return;
			if(eventArgs.Exception is ConversationException)
			{
				ConversationsContainerAccessor.Container.Unbind(GetConvesationId(eventArgs.Instance));	
			}
			eventArgs.FlowBehavior = FlowBehavior.RethrowException;
		}

		public override void OnEntry(MethodExecutionEventArgs eventArgs)
		{
			if(IsNoopConversationalMarkerActive) return;
			string convId = GetConvesationId(eventArgs.Instance);
			IConversation c = ConversationsContainerAccessor.Container.Get(convId);
			if (c == null)
			{
				var cf = ConversationFactory;
				if (cf == null)
				{
					return;
				}
				c = cf.CreateConversation(convId);
				// we are using the event because a custom eventHandler can prevent the rethrow
				// but we must Unbind the conversation from the container
				// and we must dispose the conversation itself (high probability UoW inconsistence).
				c.OnException += ((conversation, args) => ConversationsContainerAccessor.Container.Unbind(c.Id).Dispose());
				ConfigureConversation(c, eventArgs.Instance);
				ConversationsContainerAccessor.Container.SetAsCurrent(c);
				c.Start();
				ConversationPausedWatcher.Watch(c);
			}
			else
			{
				ConversationsContainerAccessor.Container.SetAsCurrent(c);
				if(ConversationPausedWatcher.IsPaused(c))
				{
					c.Resume();	
				}else
				{
					eventArgs.MethodExecutionTag = NestedMethodMarker;
				}
			}
		}

		private void ConfigureConversation(IConversation conversation, object instance)
		{
			IConversationCreationInterceptor cci = null;
			Type creationInterceptorType = this.ConversationCreationInterceptor;
			if (creationInterceptorType != null)
			{
				cci = creationInterceptorType.IsInterface ? 
						GetConversationCreationInterceptor(creationInterceptorType) 
						: creationInterceptorType.Instantiate<IConversationCreationInterceptor>();
			}
			else
			{
				if (UseConversationCreationInterceptorConvention)
				{
					Type concreteImplementationType = BaseConventionType.MakeGenericType(instance.GetType());
					cci = GetConversationCreationInterceptor(concreteImplementationType);
				}
			}
			if (cci != null)
			{
				cci.Configure(conversation);
			}
			if (AllowOutsidePersistentCall)
			{
				var conversationWithOpc = conversation as ISupportOutsidePersistentCall;
				if (conversationWithOpc == null)
				{
					throw new InvalidOperationException("The conversation doesn't support outside persistent call");
				}
				conversationWithOpc.UseSupportForOutsidePersistentCall = true;
			}
		}

		private static IConversationCreationInterceptor GetConversationCreationInterceptor(Type creationInterceptorType)
		{
			return (IConversationCreationInterceptor) ServiceLocator
								.Current
								.GetAllInstances(creationInterceptorType)
								.FirstOrDefault();
	
		}
		//TODO: this approach is wrong.
		private bool IsNoopConversationalMarkerActive
		{
			get
			{
				var noopServiceMarker = ServiceLocator
					.Current
					.GetAllInstances<NoopConversationalMarker>().FirstOrDefault();

				return noopServiceMarker != null && noopServiceMarker.Noop;
			}
		}
		
		public override void OnSuccess(MethodExecutionEventArgs eventArgs)
		{
			if (IsNoopConversationalMarkerActive) return;
			
			if(eventArgs.MethodExecutionTag == NestedMethodMarker) return;
			var cca = ConversationsContainerAccessor;
			IConversation c = cca.Container.Get(GetConvesationId(eventArgs.Instance));
			switch (ConversationEndMode)
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


		private static readonly IDictionary<object, string> 
			IdContainer = new Dictionary<object, string>();

		protected virtual string GetConvesationId(object instance)
		{
			string conversationId;
			if (!IdContainer.TryGetValue(instance, out conversationId))
			{
				if (!string.IsNullOrEmpty(ConversationId))
				{
					conversationId = ConversationId;
				}
				else if (!string.IsNullOrEmpty(IdPrefix))
				{
					conversationId = IdPrefix + Guid.NewGuid();
				}
				else
				{
					conversationId = Guid.NewGuid().ToString();
				}
				IdContainer[instance] = conversationId;
			}
			return conversationId;
		}
	}
}
