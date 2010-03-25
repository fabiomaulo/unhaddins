using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.ServiceLocation;
using PostSharp.Extensibility;
using PostSharp.Laos;
using uNhAddIns.Extensions;
using uNhAddIns.SessionEasier.Conversations;

namespace uNhAddIns.PostSharpAdapters
{
	[Serializable]
	public class PersistenceConversationalBase : OnMethodBoundaryAspect
	{
		private const string ConversationalIdFieldName = "conversationalId";
		protected static readonly Type BaseConventionType = typeof (IConversationCreationInterceptorConvention<>);
		protected static readonly ConversationPausedWatcher ConversationPausedWatcher = new ConversationPausedWatcher();
		protected static readonly object NestedMethodMarker = new object();

		private static readonly IDictionary<object, string>
			IdContainer = new Dictionary<object, string>();

		/// <summary>
		/// Initializes a new instance of the <see cref="PersistenceConversationalBase"/> class.
		/// </summary>
		public PersistenceConversationalBase()
		{
			EndMode = EndMode.Continue;
			UseConversationCreationInterceptorConvention = true;
			AttributeInheritance = MulticastInheritance.Strict;
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
		/// The action to take after finishing this part of the conversation.
		/// </summary>
		/// <remarks>
		/// Optional, default <see cref="EndMode.Continue"/>
		/// </remarks>
		public EndMode EndMode { get; set; }

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
		public bool AllowOutsidePersistentCall { get; set; }

		protected IConversationsContainerAccessor ConversationsContainerAccessor
		{
			get { return ServiceLocator.Current.GetInstance<IConversationsContainerAccessor>(); }
		}

		protected IConversationFactory ConversationFactory
		{
			get { return ServiceLocator.Current.GetInstance<IConversationFactory>(); }
		}

		private static bool IsNoopConversationalMarkerActive
		{
			get
			{
				NoopConversationalMarker noopServiceMarker = ServiceLocator
					.Current
					.GetAllInstances<NoopConversationalMarker>().FirstOrDefault();

				return noopServiceMarker != null && noopServiceMarker.Noop;
			}
		}

		public override void OnException(MethodExecutionEventArgs eventArgs)
		{
			if (IsNoopConversationalMarkerActive) return;
			if (eventArgs.Exception is ConversationException)
			{
				string conversationId = GetConversationId(eventArgs.Instance);
				eventArgs.InstanceTag = conversationId; //this prevent the field gets erased.
				ConversationsContainerAccessor.Container.Unbind(conversationId);
			}
			eventArgs.FlowBehavior = FlowBehavior.RethrowException;
		}

		public override InstanceTagRequest GetInstanceTagRequest()
		{
			var instanceTagRequest = new InstanceTagRequest(
				ConversationalIdFieldName,
				new Guid("33DA05FA-A756-4312-AD22-EDA8FA849476"),
				false);
			return instanceTagRequest;
		}

		public override void OnEntry(MethodExecutionEventArgs eventArgs)
		{
			if (IsNoopConversationalMarkerActive) return;
			string conversationId = GetConversationId(eventArgs.Instance);

			if (string.IsNullOrEmpty(conversationId))
			{
				conversationId = GenerateConvesationId();
				SetConversationId(eventArgs.Instance, conversationId);
			}
			eventArgs.InstanceTag = conversationId; //this prevent the field gets erased.
			IConversation c = ConversationsContainerAccessor.Container.Get(conversationId);
			if (c == null)
			{
				IConversationFactory cf = ConversationFactory;
				if (cf == null)
				{
					return;
				}
				c = cf.CreateConversation(conversationId);
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
				if (ConversationPausedWatcher.IsPaused(c))
				{
					c.Resume();
				}
				else
				{
					eventArgs.MethodExecutionTag = NestedMethodMarker;
				}
			}
		}

		private void ConfigureConversation(IConversation conversation, object instance)
		{
			IConversationCreationInterceptor cci = null;
			Type creationInterceptorType = ConversationCreationInterceptor;
			if (creationInterceptorType != null)
			{
				cci = creationInterceptorType.IsInterface
				      	?
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

		public override void OnSuccess(MethodExecutionEventArgs eventArgs)
		{
			if (IsNoopConversationalMarkerActive) return;
			string conversationId = GetConversationId(eventArgs.Instance);
			eventArgs.InstanceTag = conversationId; //this prevent the field gets erased.
			if (eventArgs.MethodExecutionTag == NestedMethodMarker) return;
			IConversationsContainerAccessor cca = ConversationsContainerAccessor;
			IConversation c = cca.Container.Get(conversationId);
			switch (EndMode)
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

		protected virtual string GenerateConvesationId()
		{
			//object instance
			string conversationId;
			//if (!IdContainer.TryGetValue(instance, out conversationId))
			//{
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
			//IdContainer[instance] = conversationId;
			//}
			return conversationId;
		}

		#region "Instance tag doesn't work when subclasing the class

		private static string GetConversationId(object instance)
		{
			return (string) GetConversationalIdField(instance).GetValue(instance);
		}

		private static FieldInfo GetConversationalIdField(object instance)
		{
			return instance.GetType().GetField(
				ConversationalIdFieldName,
				BindingFlags.NonPublic | BindingFlags.Instance);
		}

		private static void SetConversationId(object instance, string conversationId)
		{
			GetConversationalIdField(instance).SetValue(instance, conversationId);
		}

		#endregion
	}
}