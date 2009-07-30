using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.Core;
using Castle.Core.Interceptor;

namespace uNhAddIns.WPF.Castle
{
    public class EditableBehaviorInterceptor : EditableBehaviorBase, IInterceptor, IOnBehalfAware
    {
        private Dictionary<string, PropertyInfo> _properties;

        #region IInterceptor Members

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

            if (!invocation.Method.Name.StartsWith("get_") &&
                !invocation.Method.Name.StartsWith("set_"))
            {
                invocation.Proceed();
                return;
            }

            if (!base.IsEditing)
            {
                invocation.Proceed();
                return;
            }

            bool isSet = invocation.Method.Name.StartsWith("set_");
            string propertyName = invocation.Method.Name.Substring(4);
            PropertyInfo property;
            if(!_properties.TryGetValue(propertyName, out property))
            {
                invocation.Proceed();
                return;
            }
            
            if (isSet)
            {
                StoreTempValue(property, invocation.Arguments[0]);
            }
            else
            {
                invocation.Proceed();
                invocation.ReturnValue = GetTempValue(property) ?? invocation.ReturnValue;
            }
        }

        #endregion

        #region IOnBehalfAware Members

        
        public void SetInterceptedComponentModel(ComponentModel target)
        {
            //I take advantage of the target.Properties of the component model.
            _properties = target.Properties
                        .ToDictionary(p => p.Property.Name, p => p.Property);
        }

        #endregion

    }
}