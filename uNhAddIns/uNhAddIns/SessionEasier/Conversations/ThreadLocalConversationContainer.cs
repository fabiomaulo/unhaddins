using System;
using System.Collections.Generic;

namespace uNhAddIns.SessionEasier.Conversations
{
	public class ThreadLocalConversationContainer : AbstractConversationContainer
	{
		[ThreadStatic]
		protected static Dictionary<string, IConversation> store= new Dictionary<string, IConversation>(10);

		[ThreadStatic]
		protected static string currentId;

		#region Overrides of AbstractConversationContainer

		protected override string CurrentId
		{
			get { return currentId; }
			set { currentId = value; }
		}

		protected override IDictionary<string, IConversation> Store
		{
			get { return store; }
		}

		#endregion
	}
}