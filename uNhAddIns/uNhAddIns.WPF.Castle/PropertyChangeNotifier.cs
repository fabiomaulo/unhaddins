using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Castle.Core.Interceptor;

namespace uNhAddIns.WPF.Castle
{
    public class PropertyChangeNotifier : PropertyChangeNotifierBase, IInterceptor
    {
        private bool _isInEditMode = false;
        private readonly List<string> _editedProperties = new List<string>();

        #region IInterceptor Members

        public void Intercept(IInvocation invocation)
        {
            string methodName = invocation.Method.Name;
            if (methodName == "add_PropertyChanged")
            {
                StoreHandler((Delegate) invocation.Arguments[0]);
                return;
            }
            if (methodName == "remove_PropertyChanged")
            {
                RemoveHandler((Delegate) invocation.Arguments[0]);
                return;
            }

            invocation.Proceed();

            if("BeginEdit".Equals(methodName) && invocation.Proxy is IEditableObject)
            {
                _isInEditMode = true;
            }
            if("CancelEdit".Equals(methodName) && invocation.Proxy is IEditableObject)
            {
                _isInEditMode = false;
                _editedProperties.ForEach(p => OnPropertyChanged(invocation.Proxy, new PropertyChangedEventArgs(p)));
            }
            
            if (invocation.MethodInvocationTarget.Name.StartsWith("set_"))
            {
                string propertyName = methodName.Substring(4);

                if(_isInEditMode)
                {
                    _editedProperties.Add(propertyName);
                }
                
                var args = new PropertyChangedEventArgs(propertyName);
                OnPropertyChanged(invocation.Proxy, args);
            }
        }

        #endregion
    }
}