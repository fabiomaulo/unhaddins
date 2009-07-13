//using NHibernate;

using System;
using System.Linq;
using System.Reflection;
using Castle.Core.Interceptor;

namespace uNhAddIns.WPF
{
    //Todo: move to another assembly and remove castle references.

    public class EditableBehaviorInterceptor : EditableBehaviorBase, IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {

            switch (invocation.Method.Name)
            {
                case "BeginEdit":
                    BeginEdit();
                    return;
                case "CancelEdit":
                    CancelEdit();
                    return;
                case "EndEdit":
                    EndEdit(invocation.InvocationTarget);
                    return;
                default:
                    break;
            }

            if(!invocation.Method.Name.StartsWith("get_") && 
                !invocation.Method.Name.StartsWith("set_"))
            {
                invocation.Proceed();
                return;
            }

            if(!base.IsEditing)
            {
                invocation.Proceed();
                return;
            }

            var isSet = invocation.Method.Name.StartsWith("set_");
            string propertyName = invocation.Method.Name.Substring(4);
            PropertyInfo property = invocation.TargetType.GetProperties()
                                        .FirstOrDefault(prop => prop.Name == propertyName);

            if(isSet)
            {
                StoreTempValue(property, invocation.Arguments[0]);
            }else
            {
                invocation.Proceed();
                invocation.ReturnValue = GetTempValue(property) ?? invocation.ReturnValue;                
            }
        }
    }
}