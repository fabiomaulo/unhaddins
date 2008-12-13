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
		/// The conversation will end at the end of method execution.
		/// </summary>
		/// <remarks>
		/// Default: <c>false</c>.
		/// </remarks>
		public bool EndConversation { get; set; }

		/// <summary>
		/// The conversation will abort at the end of method execution.
		/// </summary>
		/// <remarks>
		/// Default: <c>false</c>.
		/// </remarks>
		public bool AbortConversation { get; set; }
	}
}
