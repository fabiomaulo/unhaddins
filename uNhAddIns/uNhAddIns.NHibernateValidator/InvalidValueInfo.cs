using System;
using System.Reflection;
using NHibernate.Validator.Engine;
using uNhAddIns.Adapters;

namespace uNhAddIns.NHibernateValidator
{
    public class InvalidValueInfo : IInvalidValueInfo
    {
        private readonly InvalidValue _invalidValue;

        public InvalidValueInfo(InvalidValue invalidValue)
        {
            _invalidValue = invalidValue;
        }

        /// <summary>
        /// This is the class type that the validation result is applicable to. For instance,
        /// if the validation result concerns a duplicate record found for an employee, then
        /// this property would hold the typeof(Employee). It should be expected that this
        /// property will never be null.
        /// </summary>
        public Type EntityType
        {
            get { return _invalidValue.EntityType; }
        }

        /// <summary>
        /// If the validation result is applicable to a specific property, then this
        /// <see cref="PropertyInfo" /> would be set to a property name.
        /// </summary>
        public string PropertyName
        {
            get { return _invalidValue.PropertyName; }
        }

        /// <summary>
        /// Holds the message describing the validation result for the EntityType and/or PropertyContext
        /// </summary>
        public string Message
        {
            get { return _invalidValue.Message; }
        }
    }
}