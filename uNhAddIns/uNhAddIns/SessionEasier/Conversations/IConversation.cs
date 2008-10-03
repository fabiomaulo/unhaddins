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
		/// Fiered before start the conversation.
		/// </summary>
		event EventHandler<EventArgs> Starting;

		/// <summary>
		/// Fiered after pause the conversation.
		/// </summary>
		event EventHandler<EventArgs> Paused;

		/// <summary>
		/// Fiered before resume the conversation.
		/// </summary>
		event EventHandler<EventArgs> Resuming;

		/// <summary>
		/// Fiered after end the conversation.
		/// </summary>
		event EventHandler<EventArgs> Ended;
	}
}