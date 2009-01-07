using System;

namespace uNhAddIns.Adapters
{
	/// <summary>
	/// Attribute to mark a mathod as involved in a persistence conversation
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class PersistenceConversationAttribute : Attribute
	{
		/// <summary>
		/// The action to take after finishing this part of the conversation.
		/// </summary>
		/// <remarks>
		/// Default: <see cref="EndMode.Continue"/>.
		/// </remarks>
		public EndMode ConversationEndMode { get; set; }
	}
}
