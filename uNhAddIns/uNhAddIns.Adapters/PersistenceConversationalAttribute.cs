using System;

namespace uNhAddIns.Adapters
{
	/// <summary>
	/// Decorate a class as involved in a persistentes conversation.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class PersistenceConversationalAttribute : Attribute
	{
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
	}
}