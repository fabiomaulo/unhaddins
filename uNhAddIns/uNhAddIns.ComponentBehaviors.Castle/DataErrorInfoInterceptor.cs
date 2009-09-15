using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Castle.Core;
using Castle.Core.Interceptor;
using uNhAddIns.Adapters;

namespace uNhAddIns.ComponentBehaviors.Castle
{
   
    public class DataErrorInfoInterceptor : IInterceptor, IOnBehalfAware
    {
        private readonly IEntityValidator _entityValidator;

        public DataErrorInfoInterceptor(IEntityValidator entityValidator)
        {
            _entityValidator = entityValidator;
        }

        #region IInterceptor Members



        public void Intercept(IInvocation invocation)
        {
            if(invocation.Method.DeclaringType.Equals(targetType))
            {
                //invocation.Proceed();
                SendInvocationToTargetDouble(invocation);
            }else if (invocation.Method.DeclaringType.Equals(typeof(IDataErrorInfo)))
            {
                if ("get_Item".Equals(invocation.Method.Name))
                {
                    string[] invalidvalues = _entityValidator
                        .Validate(targetDouble, (string) invocation.Arguments[0])
                        .Select(iv => iv.Message)
                        .ToArray();

                    invocation.ReturnValue = string.Join(Environment.NewLine, invalidvalues);
                }
                else if ("get_Error".Equals(invocation.Method.Name))
                {
                    string[] invalidValues = _entityValidator.Validate(targetDouble)
                        .Select(iv => iv.Message)
                        .ToArray();

                    invocation.ReturnValue = string.Join(Environment.NewLine, invalidValues);
                }
            }
            else
            {
                invocation.Proceed();
            }
        }


        private void SendInvocationToTargetDouble(IInvocation invocation)
        {
            if (targetDouble == null)
                targetDouble = Activator.CreateInstance(targetType);
            invocation.ReturnValue = invocation
                                     .MethodInvocationTarget
                                     .Invoke(targetDouble, invocation.Arguments);
        }

        #endregion


        //DynamicProxy doesn't support clasproxy with target.
        private object targetDouble;
        private Type targetType;
        //TODO: find a better way.

        public void SetInterceptedComponentModel(ComponentModel target)
        {
            targetType = target.Service;
        }
        
    }
}