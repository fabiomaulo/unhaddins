using System;
using System.Collections.Generic;
using System.Reflection;

namespace uNhAddIns.WPF
{
    public class EditableBehaviorBase
    {
        private bool _isInEditMode;
        private const string ErrorNotInEditMode = "The current object is not in editable mode.";
        public void BeginEdit()
        {
            _isInEditMode = true;
        }

        public void CancelEdit()
        {
            _tempValues.Clear();
            _isInEditMode = false;
        }

        public void EndEdit(object target)
        {
            _isInEditMode = false;
            foreach(var property in _tempValues.Keys)
            {
                property.SetValue(target, _tempValues[property], null);
            }
        }

        public void StoreTempValue(PropertyInfo property, object propertyValue)
        {
            if (!_isInEditMode)
            {
                throw new InvalidOperationException(ErrorNotInEditMode);
            }
            _tempValues[property] = propertyValue;
        }

        public object GetTempValue(PropertyInfo property)
        {
            object value;
            _tempValues.TryGetValue(property, out value);
            return value;
        }

        public virtual bool IsEditing
        {
            get
            {
                return _isInEditMode;    
            }
        }

        private readonly IDictionary<PropertyInfo, object> _tempValues 
            = new Dictionary<PropertyInfo, object>();
    }
}