using Castle.Facilities.FactorySupport;
using Castle.MicroKernel.Facilities.OnCreate;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ChinookMediaManager.GuyWire.Configurators;
using CommonServiceLocator.WindsorAdapter;
using Microsoft.Practices.ServiceLocation;
using uNhAddIns.Adapters;

namespace ChinookMediaManager.GuyWire
{
    public class GeneralGuyWire : IGuyWire
    {
        private readonly IConfigurator[] configurators = new IConfigurator[]
                                                             {
                                                                 new NHibernateConfigurator(),
                                                                 new RepositoriesConfigurator(),
																 new NHVConfigurator(),
                                                                 new EntitiesConfigurator(),
                                                                 new ModelsConfigurator(),
                                                                 new ViewModelConfigurator(),
                                                                 new ViewsConfigurator()
                                                             };

        private IWindsorContainer container;

        #region IGuyWire Members

        /// <summary>
        /// Application wire.
        /// </summary>
        /// <remarks>
        /// IoC container configuration (more probably conf. by code).
        /// </remarks>
        public void Wire()
        {
            if (container != null)
                Dewire();
            container = new WindsorContainer();
        	container.AddFacility<OnCreateFacility>();
        	container.AddFacility<FactorySupportFacility>();

            //container.Register(Component.For<IWindsorContainer>().Instance(container));

            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));
            container.Register(Component.For<IServiceLocator>().Instance(ServiceLocator.Current));

            foreach (IConfigurator configurator in configurators)
            {
                configurator.Configure(container);
            }
        }

        /// <summary>
        /// Application dewire
        /// </summary>
        /// <remarks>
        /// IoC container dispose.
        /// </remarks>
        public void Dewire()
        {
            if (container != null)
                container.Dispose();
        }

        #endregion
    }
}