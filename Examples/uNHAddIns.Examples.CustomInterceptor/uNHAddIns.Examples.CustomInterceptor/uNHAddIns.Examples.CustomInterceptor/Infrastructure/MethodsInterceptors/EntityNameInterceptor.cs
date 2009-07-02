using System;
using Castle.Core;
using Castle.Core.Interceptor;

namespace uNHAddIns.Examples.CustomInterceptor.Infrastructure.MethodsInterceptors
{
    /// <summary>
    /// Intercepts get_EntityName and retrieve the primary entity name.
    /// The type.Name of a proxy should be something like this: "IProxy2313213123131221".
    /// But the EntityName is = "IProduct" or "ICustomer".
    /// </summary>
    public class EntityNameInterceptor : IInterceptor
    {
        private readonly string _entityName;

        public EntityNameInterceptor(string entityName)
        {
            _entityName = entityName;
        }
        public void Intercept(IInvocation invocation)
        {
            var methodName = invocation.Method.Name;

            if ("get_EntityName".Equals(methodName))
            {
                invocation.ReturnValue = _entityName;
                return;
            }
            invocation.Proceed();
        }

    }
}