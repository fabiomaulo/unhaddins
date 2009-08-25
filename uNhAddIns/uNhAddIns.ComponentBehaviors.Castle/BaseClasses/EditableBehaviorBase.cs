using System;
using System.Collections.Generic;
using System.Reflection;

namespace uNhAddIns.ComponentBehaviors.Castle.BaseClasses
{
    public class EditableBehaviorBase
    {
        private const string ErrorNotInEditMode = "The current object is not in editable mode.";

        private readonly IDictionary<PropertyInfo, object> _tempValues
            = new Dictionary<PropertyInfo, object>();

        private bool _isInEditMode;

        public virtual bool IsEditing
        {
            get { return _isInEditMode; }
        }

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
            foreach (PropertyInfo property in _tempValues.Keys)
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
    }
}