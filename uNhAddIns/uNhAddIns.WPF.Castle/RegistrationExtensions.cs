using System;
using System.ComponentModel;
using Castle.Core;
using Castle.MicroKernel.Registration;
using uNhAddIns.WPF.EntityNameResolver;

namespace uNhAddIns.WPF.Castle
{
    public static class RegistrationExtensions
    {
        public static ComponentRegistration<T> NhibernateEntity<T>(this ComponentRegistration<T> componentRegistration)
        {
            return componentRegistration.Proxy.AdditionalInterfaces(typeof (INamedEntity))
                .Interceptors(new InterceptorReference(typeof (GetEntityNameInterceptor))).Anywhere;
        }

        public static ComponentRegistration<T> AddEditableBehavior<T>(
            this ComponentRegistration<T> componentRegistration)
        {
            return componentRegistration.Proxy.AdditionalInterfaces(typeof (IEditableObject))
                .Interceptors(new InterceptorReference(typeof (EditableBehaviorInterceptor))).Last;
        }

        public static ComponentRegistration<T> AddNotificableBehavior<T>(
            this ComponentRegistration<T> componentRegistration)
        {
            return componentRegistration.Proxy.AdditionalInterfaces(typeof (INotifyPropertyChanged))
                .Interceptors(new InterceptorReference(typeof (PropertyChangeNotifier))).First;
        }
    }
}