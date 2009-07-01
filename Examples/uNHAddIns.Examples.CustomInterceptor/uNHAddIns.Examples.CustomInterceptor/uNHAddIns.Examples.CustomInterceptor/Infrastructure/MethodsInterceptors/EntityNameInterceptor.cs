using System;
using Castle.Core;
using Castle.Core.Interceptor;

namespace uNHAddIns.Examples.CustomInterceptor.Infrastructure.MethodsInterceptors
{
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