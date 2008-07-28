namespace uNhAddIns.Validation {
    using System;
    using NHibernate.Cfg;
    using NHibernate.Event;
    using NHibernate.Util;

    /// <summary>
    /// EventListener that raise the event on pre Save and Update
    /// in order to validate. Need to be configurated with some validator
    /// that implements <seealso cref="IValidator"/>
    /// If a object 
    /// </summary>
    public class ValidateEventListener :
        IPreInsertEventListener,
        IPreUpdateEventListener,
        IInitializable {
        private IValidator validator;

        #region IInitializable Members

        /// <summary>
        /// Initialize the EventListener.
        /// </summary>
        /// <param name="cfg">Configuration of NHibernate</param>
        public void Initialize(Configuration cfg) {
            validator = InstantiateValidatorProvider(cfg);
        }

        #endregion

        #region IPreInsertEventListener Members

        /// <summary>
        /// Action executed before an Insert.
        /// If a entity invalid is intented to save, throw an <see cref="ValidationException"/>
        /// </summary>
        /// <param name="event">Event on Insert</param>
        /// <returns>true if the Insert is vetoed, false in order case</returns>
        public bool OnPreInsert(PreInsertEvent @event) {
            
            if (validator.IsValid(@event)) return false;

            throw new ValidationException("Could not save a not valid entity");
        }

        #endregion

        #region IPreUpdateEventListener Members

        /// <summary>
        /// Action executed before an Update.
        /// If a entity invalid is intented to save, throw an <see cref="ValidationException"/>
        /// </summary>
        /// <param name="event">Event on Insert</param>
        /// <returns>true if the Update is vetoed, false in order case</returns>
        public bool OnPreUpdate(PreUpdateEvent @event) {
            
            if (validator.IsValid(@event)) return false;

            throw new ValidationException("Could not save a not valid entity");
        }

        #endregion

        /// <summary>
        /// Create an instance of the validator to be inyected.
        /// This is called at Startup.
        /// </summary>
        /// <param name="cfg"></param>
        /// <returns></returns>
        private IValidator InstantiateValidatorProvider(Configuration cfg) {
            string providerName = cfg.GetProperty(Environment.HibernateValidationProvider);
            return (IValidator)Activator.CreateInstance(ReflectHelper.ClassForName(providerName));
        }
    }
}