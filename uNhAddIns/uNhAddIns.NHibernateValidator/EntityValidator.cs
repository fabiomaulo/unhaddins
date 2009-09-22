using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate.Validator.Engine;
using uNhAddIns.Adapters;

namespace uNhAddIns.NHibernateValidator
{
    public class EntityValidator : IEntityValidator
    {
        private readonly ValidatorEngine _validatorEngine;

        public EntityValidator(ValidatorEngine validatorEngine)
        {
            _validatorEngine = validatorEngine;
        }

        ///<summary>
        /// Returns true if the entity is valid.
        ///</summary>
        ///<param name="entityInstance"></param>
        ///<returns></returns>
        public bool IsValid(object entityInstance)
        {
            return _validatorEngine.IsValid(entityInstance);
        }

        ///<summary>
        /// Validates an entity and returns the information about invalid values.
        /// </summary>
        ///<param name="entityInstance"></param>
        ///<returns></returns>
        public IList<IInvalidValueInfo> Validate(object entityInstance)
        {
            return _validatorEngine.Validate(entityInstance)
                                   .Select(iv => new InvalidValueInfo(iv) )
                                   .OfType<IInvalidValueInfo>().ToList();
        }

        ///<summary>
        /// Validates a property of the entity and returns the information about invalid values.
        ///</summary>
        ///<param name="entityInstance"></param>
        ///<param name="property"></param>
        ///<typeparam name="T"></typeparam>
        ///<typeparam name="TP"></typeparam>
        ///<returns></returns>
        public IList<IInvalidValueInfo> Validate<T, TP>(T entityInstance, Expression<Func<T, TP>> property) where T : class
        {
            return _validatorEngine.ValidatePropertyValue(entityInstance, property)
                                   .Select(iv => new InvalidValueInfo(iv))
                                   .OfType<IInvalidValueInfo>().ToList();
        }

        ///<summary>
        /// Validates a property of the entity and returns the information about invalid values.
        ///</summary>
        ///<param name="entityInstance"></param>
        ///<param name="property"></param>
        ///<typeparam name="T"></typeparam>
        ///<typeparam name="TP"></typeparam>
        ///<returns></returns>
        public IList<IInvalidValueInfo> Validate(object entityInstance, string property)
        {
            return _validatorEngine.ValidatePropertyValue(entityInstance, property)
                                   .Select(iv => new InvalidValueInfo(iv))
                                   .OfType<IInvalidValueInfo>()
                                   .ToList();
        }
    }
}