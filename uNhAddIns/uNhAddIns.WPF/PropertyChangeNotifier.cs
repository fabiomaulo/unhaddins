using System;
using System.ComponentModel;
using Castle.Core.Interceptor;

namespace uNhAddIns.WPF
{
    public class PropertyChangeNotifier : PropertyChangeNotifierBase, IInterceptor
    {
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

            if (invocation.MethodInvocationTarget.Name.StartsWith("set_"))
            {
                //if (typeof(INotifyPropertyChanged).IsAssignableFrom(invocation.Proxy.GetType()))
                //{
                var args = new PropertyChangedEventArgs(methodName.Substring(4));
                OnPropertyChanged(invocation.Proxy, args);
                //}
            }
        }

        #endregion
    }
}