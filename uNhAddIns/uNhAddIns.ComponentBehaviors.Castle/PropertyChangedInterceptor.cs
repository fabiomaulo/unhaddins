using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Castle.Core.Interceptor;

namespace uNhAddIns.ComponentBehaviors.Castle
{
    public class PropertyChangedInterceptor : IInterceptor
    {
        private PropertyChangedEventHandler _handler;

        #region IInterceptor Members

        public void Intercept(IInvocation invocation)
        {
            string methodName = invocation.Method.Name;

            if (invocation.Method.DeclaringType.Equals(typeof(INotifyPropertyChanged)))
            {
                if (methodName == "add_PropertyChanged")
                    _handler =
                        (PropertyChangedEventHandler)Delegate.Combine(_handler,
                                                     (Delegate)invocation.Arguments[0]);
                if (methodName == "remove_PropertyChanged")
                    _handler = (PropertyChangedEventHandler)Delegate.Remove(_handler,
                                                    (Delegate)invocation.Arguments[0]);
                return;
            }

            if(!invocation.Method.Name.StartsWith("set_"))
            {
                invocation.Proceed();
                return;
            }

            //remove the "set_" from the method name (for isntance set_Title)
            string propertyName = invocation.Method.Name.Substring(4);

            //The lastvalue is the NEW val. 
            //This is important when you are setting INDEXED properties.
            var indexes = invocation.Arguments
                          .Where((obj, index) =>
                                 index < invocation.Arguments.Length - 1)
                          .ToArray();

            //store the current value.
            var oldValue = GetCurrentValueForProperty(invocation.Proxy,
                                                      propertyName, indexes);

            //store the new value
            var newValue = invocation.Arguments.Last();

            //FIRST TIME - FIRST SET we grab readonly properties with values.
            if (_readOnlyProperties == null)
                GrabReadOnlyProperties(invocation.Proxy);

            //proceed with the set
            invocation.Proceed();

            //if the value has changed, notify
            if (oldValue != newValue)
                OnPropertyChanged(invocation.Proxy, propertyName);

            NotifyReadOnlyPropertiesChanges(invocation.Proxy);
        }

        private void NotifyReadOnlyPropertiesChanges(object proxy)
        {
            foreach (var property in _readOnlyProperties)
            {
                object oldValue = _readOnlyPropertiesValues[property.Key];
                object newValue = property.Value.GetValue(proxy, null);
                if(oldValue != newValue)
                {
                    _readOnlyPropertiesValues[property.Key] = newValue;
                    OnPropertyChanged(proxy, property.Key);
                }
            }
        }

        private void GrabReadOnlyProperties(object proxy)
        {
            _readOnlyProperties = proxy.GetType().GetProperties()
                                       .Where(p => p.CanWrite == false)
                                       .ToDictionary(p => p.Name, p => p);

            _readOnlyPropertiesValues = _readOnlyProperties
                                        .ToDictionary(p => p.Key, p => p.Value.GetValue(proxy, null));
        }

        #endregion

        private readonly IDictionary<string, PropertyInfo> _propertyInfos =
                    new Dictionary<string, PropertyInfo>();

        private IDictionary<string, PropertyInfo> _readOnlyProperties;
        private IDictionary<string, object> _readOnlyPropertiesValues; 

        private object GetCurrentValueForProperty(object proxy,string propertyName,object[] indexes)
        {
            PropertyInfo propertyInfo;
            _propertyInfos.TryGetValue(propertyName, out propertyInfo);

            if(propertyInfo == null)
            {
                propertyInfo = proxy.GetType().GetProperties()
                                              .First(p => p.Name == propertyName);
                _propertyInfos.Add(propertyName, propertyInfo);
            }

            return propertyInfo.GetValue(proxy, indexes);
        }

        protected void OnPropertyChanged(Object sender, string propertyName)
        {
            PropertyChangedEventHandler eventHandler = _handler;
            if (eventHandler != null) eventHandler(sender, new PropertyChangedEventArgs(propertyName));
        }
    }
}