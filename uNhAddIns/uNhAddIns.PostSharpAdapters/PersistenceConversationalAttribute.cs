using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.ServiceLocation;
using PostSharp.Extensibility;
using PostSharp.Laos;
using uNhAddIns.Adapters;
using uNhAddIns.Extensions;
using uNhAddIns.SessionEasier.Conversations;

namespace uNhAddIns.PostSharpAdapters
{
	[Serializable]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Method, Inherited = true)]
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
			DefaultEndMode = EndMode.Continue;
			UseConversationCreationInterceptorConvention = true;
			MethodsIncludeMode = MethodsIncludeMode.Implicit;
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

		/// <summary>
		/// Define the way each method, of the target class, will be included in a persistent conversation.
		/// In implicit mode only the public methods will be intercepted.
		/// </summary>
		/// <remarks>
		/// Optional, default <see cref="uNhAddIns.Adapters.MethodsIncludeMode.Implicit"/>
		/// </remarks>
		public MethodsIncludeMode MethodsIncludeMode { get; set; }

		/// <summary>
		/// Define the <see cref="EndMode"/> of each method where not explicity declared.
		/// </summary>
		/// <remarks>
		/// Optional, default <see cref="EndMode.Continue"/>
		/// </remarks>
		public EndMode DefaultEndMode { get; set; }

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
			if(eventArgs.Exception is ConversationException)
			{
				ConversationsContainerAccessor.Container.Unbind(GetConvesationId(eventArgs.Instance));	
			}
			eventArgs.FlowBehavior = FlowBehavior.RethrowException;
		}

		public override void OnEntry(MethodExecutionEventArgs eventArgs)
		{
			if (!ShouldBeIntercepted(eventArgs.Method)) return;
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
		
		private bool IsNoopConversationalMarkerActive
		{
			get
			{
				return ServiceLocator.Current
									.GetAllInstances<NoopConversationalMarker>()
									.Any();
			}

		}
		
		private bool ShouldBeIntercepted(MethodBase method)
		{
			if (IsNoopConversationalMarkerActive) return false;

			var conversationInfo = method.GetCustomAttributes(typeof (PersistenceConversationAttribute), true)
										.OfType<PersistenceConversationAttribute>()
										.FirstOrDefault();



			var attribute = this;

			if(attribute.MethodsIncludeMode == MethodsIncludeMode.Implicit 
				&& (conversationInfo == null || !conversationInfo.Exclude))
			{
				if (conversationInfo != null && !conversationInfo.Exclude) return true;
				return method.IsPublic && !method.IsConstructor;
			}

			if (attribute.MethodsIncludeMode == MethodsIncludeMode.Explicit 
				&& conversationInfo != null && !conversationInfo.Exclude)
			{
				return true;
			}

			return false;
		}

		private EndMode GetEndMode(MethodBase method)
		{
			var conversationInfo = method.GetCustomAttributes(typeof(PersistenceConversationAttribute), true)
										.OfType<PersistenceConversationAttribute>().FirstOrDefault();

			var psPersistenceConversationalAttribute = this;

			var methodsIncludeMode = psPersistenceConversationalAttribute.MethodsIncludeMode;

			if (methodsIncludeMode == MethodsIncludeMode.Implicit)
			{
				if (conversationInfo == null || conversationInfo.ConversationEndMode == EndMode.Unspecified)
				{
					return psPersistenceConversationalAttribute.DefaultEndMode;	
				}
				return conversationInfo.ConversationEndMode;
			}

			if (methodsIncludeMode == MethodsIncludeMode.Explicit 
				&& conversationInfo != null)
			{
				return conversationInfo.ConversationEndMode;
			}

			throw new InvalidOperationException("Missing endmode");
		}

		public override void OnSuccess(MethodExecutionEventArgs eventArgs)
		{
			if(!ShouldBeIntercepted(eventArgs.Method)) return;
			if(eventArgs.MethodExecutionTag == NestedMethodMarker) return;
			var endMode = GetEndMode(eventArgs.Method);
			var cca = ConversationsContainerAccessor;
			IConversation c = cca.Container.Get(GetConvesationId(eventArgs.Instance));
			switch (endMode)
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
