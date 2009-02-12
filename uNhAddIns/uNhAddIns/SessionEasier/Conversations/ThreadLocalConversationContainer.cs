using System;
using System.Collections.Generic;

namespace uNhAddIns.SessionEasier.Conversations
{
	public class ThreadLocalConversationContainer : AbstractConversationContainer
	{
		[ThreadStatic]
		protected static Dictionary<string, IConversation> store;

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
			get
			{
				if (store == null)
				{
					store = new Dictionary<string, IConversation>(10);
				}
				return store;
			}
		}

		#endregion
	}
}