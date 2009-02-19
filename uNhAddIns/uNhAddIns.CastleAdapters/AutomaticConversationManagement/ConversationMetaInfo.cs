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
			return GetMetaInfoIfAvailable(methodInfo) != null;
		}

		public void AddMethodMetadata(MethodInfo methodInfo)
		{
			lock (locker)
			{
				// Add all methods, even when is not involved,
				// to have better performance when the Interceptor call Contains method.
				info[methodInfo] = GetMetaInfoIfAvailable(methodInfo);
			}
		}

		private PersistenceConversationAttribute GetMetaInfoIfAvailable(MethodInfo methodInfo)
		{
			PersistenceConversationAttribute result;
			if(info.TryGetValue(methodInfo, out result))
			{
				// short cut
				return result;
			}

			object[] atts = methodInfo.GetCustomAttributes(typeof(PersistenceConversationAttribute), true);
			if (atts.Length != 0)
			{
				result = (PersistenceConversationAttribute) atts[0];
				if(result.Exclude)
				{
					return null;
				}
			}
			else
			{
				if(setting.MethodsIncludeMode == MethodsIncludeMode.Implicit)
				{
					result = new PersistenceConversationAttribute();
				}
			}
			if (result != null && result.ConversationEndMode == EndMode.Unspecified)
			{
				result.ConversationEndMode = setting.DefaultEndMode;
			}
			return result;
		}

		internal PersistenceConversationAttribute GetConversationAttributeFor(MethodInfo methodInfo)
		{
			return info[methodInfo];
		}
	}
}