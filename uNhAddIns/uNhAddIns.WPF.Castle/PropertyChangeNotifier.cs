using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Castle.Core.Interceptor;
using System.Linq;

namespace uNhAddIns.WPF.Castle
{
    public class PropertyChangeNotifier : PropertyChangeNotifierBase, IInterceptor
    {
        #region IInterceptor Members

        public void Intercept(IInvocation invocation)
        {
            string methodName = invocation.Method.Name;
            object[] arguments = invocation.Arguments;
            object proxy = invocation.Proxy;
            bool isEditableObject = proxy is IEditableObject;

            GrabEventsHandlers(methodName, arguments);

            if (!ShouldProceedWithInvocation(methodName))
                return;

            invocation.Proceed();

            NotifyPropertyChanged(methodName, proxy, isEditableObject);
        }

        #endregion
    }
}