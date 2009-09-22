using System.ComponentModel;
using Castle.Core;
using Castle.MicroKernel.Registration;
using uNhAddIns.NHibernateTypeResolver;

namespace uNhAddIns.ComponentBehaviors.Castle.Configuration
{
    public static class RegistrationExtensions
    {
        /// <summary>
        /// Add the interface IEditableObject and the basic editable behavior.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="componentRegistration"></param>
        /// <returns></returns>
        public static ComponentRegistration<T> AddEditableBehavior<T>(
            this ComponentRegistration<T> componentRegistration)
        {
            return componentRegistration.Proxy.AdditionalInterfaces(typeof (IEditableObject))
                .Interceptors(new InterceptorReference(typeof (EditableBehaviorInterceptor))).Last;
        }

        /// <summary>
        /// Add the interface IEditableObject and a nhibernate editable behavior.
        /// CancelEdit force a refresh of the entity.
        /// EndEdit persist the object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="componentRegistration"></param>
        /// <returns></returns>
        public static ComponentRegistration<T> AddNhEditableBehavior<T>(
            this ComponentRegistration<T> componentRegistration)
        {
            return componentRegistration.Proxy.AdditionalInterfaces(typeof (IEditableObject))
                .Interceptors(new InterceptorReference(typeof (NhEditableBehaviorInterceptor))).Last;
        }

        /// <summary>
        /// Add the interface INotifyPropertyChanged and the corresponding behavior.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="componentRegistration"></param>
        /// <returns></returns>
        public static ComponentRegistration<T> AddNotificableBehavior<T>(
            this ComponentRegistration<T> componentRegistration)
        {
            return componentRegistration.Proxy.AdditionalInterfaces(typeof (INotifyPropertyChanged))
                .Interceptors(new InterceptorReference(typeof (PropertyChangedInterceptor))).First;
        }

        /// <summary>
        /// Add the interface IDataErrorInfo and the expected behavior through the common validator.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="componentRegistration"></param>
        /// <returns></returns>
        public static ComponentRegistration<T> AddDataErrorInfoBehavior<T>(
            this ComponentRegistration<T> componentRegistration)
        {
            return componentRegistration.Proxy.AdditionalInterfaces(typeof (IDataErrorInfo))
                .Interceptors(new InterceptorReference(typeof (DataErrorInfoInterceptor))).Last;
        }

        public static ComponentRegistration<T> NhibernateEntity<T>(this ComponentRegistration<T> componentRegistration)
        {
            return componentRegistration.Proxy.AdditionalInterfaces(typeof(IWellKnownProxy))
                .Interceptors(new InterceptorReference(typeof(GetEntityNameInterceptor))).Anywhere;
        }
    }
}