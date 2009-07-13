using Castle.Core;
using Castle.Core.Interceptor;

namespace uNhAddIns.WPF.EntityNameResolver
{
    public class GetEntityNameInterceptor : IInterceptor, IOnBehalfAware
    {
        private string _entityName;

        #region IInterceptor Members

        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method.Name == "get_EntityName")
            {
                invocation.ReturnValue = _entityName;
            }else
            {
                invocation.Proceed();
            }
        }

        #endregion

        #region IOnBehalfAware Members

        public void SetInterceptedComponentModel(ComponentModel target)
        {
            _entityName = target.Implementation.FullName;
        }

        #endregion
    }
}