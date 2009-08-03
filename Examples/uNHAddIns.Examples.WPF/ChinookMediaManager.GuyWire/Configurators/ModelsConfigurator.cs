using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ChinookMediaManager.Domain.Model;

namespace ChinookMediaManager.GuyWire.Configurators
{
    public class ModelsConfigurator : IConfigurator
    {
        #region IConfigurator Members

        public void Configure(IWindsorContainer container)
        {
            IEnumerable<Type> repositoryServices = typeof (IAlbumManagerModel).Assembly
                .GetTypes().Where(t => t.IsInterface && t.Namespace.EndsWith("Model"));

            IEnumerable<Type> repositoryImpl = Assembly.Load("ChinookMediaManager.Domain.Impl").GetTypes()
                .Where(t => t.GetInterfaces().Any(i => repositoryServices.Contains(i)));

            foreach (Type service in repositoryServices)
                foreach (Type impl in repositoryImpl)
                    if (service.IsAssignableFrom(impl))
                        container.Register(Component.For(service).ImplementedBy(impl).LifeStyle.Transient);
        }

        #endregion
    }
}