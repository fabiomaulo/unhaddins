using System;
using System.Collections.Generic;
using System.Reflection;
using uNhAddIns.Adapters;

namespace uNhAddIns.CastleAdapters.AutomaticConversationManagement
{
	public class ConversationMetaInfo
	{
		private readonly Dictionary<MethodInfo, PersistenceConversationAttribute> info =
			new Dictionary<MethodInfo, PersistenceConversationAttribute>(20);

		private readonly Type conversationalClass;
		private readonly PersistenceConversationalAttribute setting;
		private readonly object locker = new object();

		public ConversationMetaInfo(Type conversationalClass, PersistenceConversationalAttribute setting)
		{
			this.conversationalClass = conversationalClass;
			this.setting = setting;
		}

		public Type ConversationalClass
		{
			get { return conversationalClass; }
		}

		public PersistenceConversationalAttribute Setting
		{
			get { return setting; }
		}

		public IEnumerable<MethodInfo> Methods
		{
			get { return info.Keys; }
		}

		public bool Contains(MethodInfo methodInfo)
		{
			lock (locker)
			{
				return info.ContainsKey(methodInfo) || IsMethodConversational(methodInfo);
			}
		}

		public void AddIfSupported(MethodInfo methodInfo)
		{
			IsMethodConversational(methodInfo);
		}

		private bool IsMethodConversational(MethodInfo methodInfo)
		{
			object[] atts = methodInfo.GetCustomAttributes(typeof(PersistenceConversationAttribute), true);

			if (atts.Length != 0)
			{
				var conversationAttribute = (PersistenceConversationAttribute) atts[0];
				if (conversationAttribute.ConversationEndMode == EndMode.Unspecified)
				{
					conversationAttribute.ConversationEndMode = setting.DefaultEndMode;
				}
				info[methodInfo] = conversationAttribute;
				return true;
			}

			return false;
		}

		internal PersistenceConversationAttribute GetConversationAttributeFor(MethodInfo methodInfo)
		{
			return info[methodInfo];
		}
	}
}