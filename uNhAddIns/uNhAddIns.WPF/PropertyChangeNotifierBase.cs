using System;
using System.ComponentModel;

namespace uNhAddIns.WPF
{
    public class PropertyChangeNotifierBase
    {
        private PropertyChangedEventHandler _handler;

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
    }
}