using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace uNhAddIns.Adapters
{
    ///<summary>
    /// Contract for the common entity validator.
    ///</summary>
    public interface IEntityValidator
    {
        ///<summary>
        /// Returns true if the entity is valid.
        ///</summary>
        ///<param name="entityInstance"></param>
        ///<returns></returns>
        bool IsValid(object entityInstance);

        ///<summary>
        /// Validates an entity and returns the information about invalid values.
        /// </summary>
        ///<param name="entityInstance"></param>
        ///<returns></returns>
        IList<IInvalidValueInfo> Validate(object entityInstance);

        ///<summary>
        /// Validates a property of the entity and returns the information about invalid values.
        ///</summary>
        ///<param name="entityInstance"></param>
        ///<param name="property"></param>
        ///<typeparam name="T"></typeparam>
        ///<typeparam name="TP"></typeparam>
        ///<returns></returns>
        IList<IInvalidValueInfo> Validate<T, TP>(T entityInstance, Expression<Func<T, TP>> property) where T : class;


        ///<summary>
        /// Validates a property of the entity and returns the information about invalid values.
        ///</summary>
        ///<param name="entityInstance"></param>
        ///<param name="property"></param>
        ///<typeparam name="T"></typeparam>
        ///<typeparam name="TP"></typeparam>
        ///<returns></returns>
        IList<IInvalidValueInfo> Validate(object entityInstance, string property);


    }
}