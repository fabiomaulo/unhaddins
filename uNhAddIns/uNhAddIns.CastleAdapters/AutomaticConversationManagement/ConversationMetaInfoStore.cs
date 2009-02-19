using System;
using System.Collections.Generic;
using System.Reflection;
using uNhAddIns.Adapters;

namespace uNhAddIns.CastleAdapters.AutomaticConversationManagement
{
	public class ConversationMetaInfoStore
	{
		private readonly IDictionary<Type, ConversationMetaInfo> typeInfo = new Dictionary<Type, ConversationMetaInfo>(100);

		public ConversationMetaInfo CreateMetaFromType(Type implementation)
		{
			if (!implementation.IsDefined(typeof(PersistenceConversationalAttribute), true))
				return null;
			object[] atts = implementation.GetCustomAttributes(typeof (PersistenceConversationalAttribute), true);
			var metaInfo = new ConversationMetaInfo(implementation, atts[0] as PersistenceConversationalAttribute);

			PopulateMetaInfoFromType(metaInfo, implementation);

			typeInfo[implementation] = metaInfo;

			return metaInfo;
		}

		private static void PopulateMetaInfoFromType(ConversationMetaInfo metaInfo, Type implementation)
		{
			if (implementation == typeof(object) || implementation == typeof(MarshalByRefObject)) return;

			MethodInfo[] methods = implementation.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);

			foreach (MethodInfo method in methods)
			{
				metaInfo.AddMethodMetadata(method);
			}

			PopulateMetaInfoFromType(metaInfo, implementation.BaseType);
		}

		public ConversationMetaInfo GetMetaFor(Type implementation)
		{
			ConversationMetaInfo result;
			typeInfo.TryGetValue(implementation, out result);
			return result;
		}
	}
}