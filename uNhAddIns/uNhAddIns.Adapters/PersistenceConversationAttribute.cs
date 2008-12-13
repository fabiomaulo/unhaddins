using System;

namespace uNhAddIns.Adapters
{
	/// <summary>
	/// Decorator tp mark a mathod as involved in a persistence conversation
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class PersistenceConversationAttribute : Attribute
	{
		/// <summary>
		/// The action to take after finishing this part of the conversation.
		/// </summary>
		/// <remarks>
		/// Default: <c>continue</c>.
		/// </remarks>
		public EndMode ConversationEndMode { get; set; }
	}
}
