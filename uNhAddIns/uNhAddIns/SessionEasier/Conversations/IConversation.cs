using System;
using System.Collections.Generic;

namespace uNhAddIns.SessionEasier.Conversations
{
	/// <summary>
	/// Contract of a pesistence conversation.
	/// </summary>
	public interface IConversation : IDisposable, IEqualityComparer<IConversation>
	{
		/// <summary>
		/// Conversation identifier.
		/// </summary>
		string Id { get; }

		/// <summary>
		/// Conversation context.
		/// </summary>
		IDictionary<string, object> Context { get; }

		/// <summary>
		/// Start the conversation.
		/// </summary>
		void Start();

		/// <summary>
		/// Pause the conversation.
		/// </summary>
		void Pause();

		/// <summary>
		/// Resume the conversation.
		/// </summary>
		void Resume();

		/// <summary>
		/// Finalize the conversation.
		/// </summary>
		void End();

		/// <summary>
		/// Abort the conversation
		/// </summary>
		void Abort();

		/// <summary>
		/// Fired before start the conversation.
		/// </summary>
		event EventHandler<EventArgs> Starting;

		/// <summary>
		/// Fired after pause the conversation.
		/// </summary>
		event EventHandler<EventArgs> Paused;

		/// <summary>
		/// Fired before resume the conversation.
		/// </summary>
		event EventHandler<EventArgs> Resuming;

		/// <summary>
		/// Fired after end the conversation.
		/// </summary>
		event EventHandler<EventArgs> Ended;
	}
}