using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ChinookMediaManager.Infrastructure;
using ChinookMediaManager.Presenters.Interfaces;

namespace ChinookMediaManager.GuyWire.Configurators
{
    public class PresentersConfigurator : IConfigurator
    {
        public void Configure(IWindsorContainer container)
        {
            IEnumerable<Type> presenterServices = typeof(IAlbumManagerPresenter).Assembly
                .GetTypes().Where(t => t.IsInterface && t.Namespace.EndsWith("Interfaces"));

            IEnumerable<Type> presenterImpl = typeof(IAlbumManagerPresenter).Assembly.GetTypes()
                .Where(t => t.GetInterfaces().Any(i => presenterServices.Contains(i)));

            foreach (Type service in presenterServices)
                foreach (Type impl in presenterImpl)
                    if (service.IsAssignableFrom(impl))
                        container.Register(Component.For(service).ImplementedBy(impl).LifeStyle.Transient);


            container.Register(Component.For<IPresenterFactory>().ImplementedBy<PresenterFactory>());
        }
    }
}