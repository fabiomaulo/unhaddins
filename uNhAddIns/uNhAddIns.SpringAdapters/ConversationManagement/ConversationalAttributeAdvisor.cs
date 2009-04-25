using System;
using System.Reflection;
using AopAlliance.Aop;
using Spring.Aop.Support;
using uNhAddIns.Adapters.Common;

namespace uNhAddIns.SpringAdapters.ConversationManagement
{
	public class ConversationalAttributeAdvisor : StaticMethodMatcherPointcutAdvisor
	{
		private readonly IConversationalMetaInfoStore store;
		private ConversationInterceptor interceptor;

	  public ConversationalAttributeAdvisor(IConversationalMetaInfoStore store)
		{
			this.store = store;
		}

		public override bool Matches(MethodInfo method, Type targetType)
		{
			var meta = store.GetMetadataFor(targetType);
			var info = meta.GetConversationInfoFor(method);
			return info != null && !info.Exclude;
		}
	}
}