using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace uNhAddIns.PostSharpAdapters
{
	public class ConversationalMethodInspector
	{
		private readonly Type type;
		private readonly PersistenceConversationalAttribute aspect;

		public ConversationalMethodInspector(Type type, PersistenceConversationalAttribute aspect)
		{
			this.type = type;
			this.aspect = aspect;
		}

		public IEnumerable<MethodInfo> GetMethods()
		{
			const BindingFlags bindingFlags =
				BindingFlags.NonPublic | BindingFlags.Public
				| BindingFlags.Instance | BindingFlags.Static;

			return type.GetMethods(bindingFlags).Where(IsConversationalMethod);
		}

		private bool IsConversationalMethod(MethodInfo methodInfo)
		{
			//todo delete this when the next hotfixes get released.

			if (methodInfo == null
			    || methodInfo.DeclaringType == null
			    || type == null
			    || (!methodInfo.DeclaringType.Equals(type)
			        && !type.IsAssignableFrom(methodInfo.DeclaringType)))
			{
				return false;
			}


			var persistenceConversation =
				methodInfo.GetCustomAttributes(typeof(PersistenceConversationAttribute), true)
					.OfType<PersistenceConversationAttribute>().FirstOrDefault();
			if(persistenceConversation == null && (methodInfo.Name.StartsWith("set_") || methodInfo.Name.StartsWith("get_")))
			{
				persistenceConversation = GetProperty(methodInfo).GetCustomAttributes(typeof(PersistenceConversationAttribute), true)
					.OfType<PersistenceConversationAttribute>().FirstOrDefault();
			}
			if (aspect.MethodsIncludeMode == MethodsIncludeMode.Implicit && methodInfo.IsPublic)
			{
				return persistenceConversation == null || !persistenceConversation.Exclude;
			}
			return persistenceConversation != null && !persistenceConversation.Exclude;
		}

		static PropertyInfo GetProperty(MethodInfo method)
		{
			bool takesArg = method.GetParameters().Length == 1;
			bool hasReturn = method.ReturnType != typeof(void);
			if (takesArg == hasReturn) return null;
			if (takesArg)
			{
				return method.DeclaringType.GetProperties()
					.Where(prop => prop.GetSetMethod() == method).FirstOrDefault();
			}
			else
			{
				return method.DeclaringType.GetProperties()
					.Where(prop => prop.GetGetMethod() == method).FirstOrDefault();
			}
		}
	}
}