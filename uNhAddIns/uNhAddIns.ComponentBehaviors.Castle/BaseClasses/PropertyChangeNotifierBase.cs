using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace uNhAddIns.ComponentBehaviors.Castle.BaseClasses
{
    public class PropertyChangeNotifierBase
    {
        private readonly List<string> _editedProperties = new List<string>();
        private PropertyChangedEventHandler _handler;
        private bool _isInEditMode;

        protected void OnPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler eventHandler = _handler;
            if (eventHandler != null) eventHandler(sender, e);
        }

        protected void RemoveHandler(Delegate @delegate)
        {
            _handler = (PropertyChangedEventHandler) Delegate.Remove(_handler, @delegate);
        }

        protected void StoreHandler(Delegate @delegate)
        {
            _handler = (PropertyChangedEventHandler) Delegate.Combine(_handler, @delegate);
        }

        protected void CancelEditMode(object obj)
        {
            _isInEditMode = false;
            _editedProperties.ForEach(p => OnPropertyChanged(obj, new PropertyChangedEventArgs(p)));
        }

        protected void BeginEditMode()
        {
            _isInEditMode = true;
        }

        protected void NotifyPropertyChanged(string methodName, object proxy, bool isEditableObject)
        {
            if ("BeginEdit".Equals(methodName) && isEditableObject)
            {
                BeginEditMode();
            }
            if ("CancelEdit".Equals(methodName) && isEditableObject)
            {
                CancelEditMode(proxy);
            }

            if (methodName.StartsWith("set_"))
            {
                string propertyName = methodName.Substring(4);

                if (_isInEditMode)
                {
                    _editedProperties.Add(propertyName);
                }

                var args = new PropertyChangedEventArgs(propertyName);
                OnPropertyChanged(proxy, args);
            }
        }

        protected void GrabEventsHandlers(string methodName, object[] arguments)
        {
            if (methodName == "add_PropertyChanged")
            {
                StoreHandler((Delegate) arguments[0]);
            }
            if (methodName == "remove_PropertyChanged")
            {
                RemoveHandler((Delegate) arguments[0]);
            }
        }

        protected bool ShouldProceedWithInvocation(string methodName)
        {
            var methodsWithoutTarget = new[] {"add_PropertyChanged", "remove_PropertyChanged"};
            if (methodsWithoutTarget.Contains(methodName))
                return false;
            return true;
        }
    }
}