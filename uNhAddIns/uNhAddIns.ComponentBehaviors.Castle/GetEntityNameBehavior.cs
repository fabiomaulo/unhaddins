using Castle.DynamicProxy;
using uNhAddIns.NHibernateTypeResolver;

namespace uNhAddIns.ComponentBehaviors.Castle
{
	[Behavior(1, typeof (IWellKnownProxy))]
	public class GetEntityNameBehavior : IInterceptor
	{
		#region IInterceptor Members

		public void Intercept(IInvocation invocation)
		{
			if (invocation.Method.DeclaringType.Equals(typeof (IWellKnownProxy)))
			{
				if (invocation.Method.Name == "get_EntityName")
				{
					invocation.ReturnValue = invocation.Proxy.GetType().BaseType.FullName;
				}
				else if (invocation.Method.Name == "get_EntityType")
				{
					invocation.ReturnValue = invocation.Proxy.GetType().BaseType;
				}
			}
			else
			{
				invocation.Proceed();
			}
		}

		#endregion
	}
}