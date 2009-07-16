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
            PropertyInfo property = _properties[propertyName];

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
            StoreProperties(target.Implementation);
        }

        #endregion

        private void StoreProperties(Type targetType)
        {
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;
            _properties = targetType.GetProperties(flags)
                .ToDictionary(p => p.Name, p => p);
        }
    }
}