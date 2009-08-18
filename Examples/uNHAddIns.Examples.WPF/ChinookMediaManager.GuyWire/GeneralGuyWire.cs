using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ChinookMediaManager.GuyWire.Configurators;
using uNhAddIns.Adapters;

namespace ChinookMediaManager.GuyWire
{
    public class GeneralGuyWire : IGuyWire, IContainerAccessor
    {
        private readonly IConfigurator[] configurators = new IConfigurator[]
                                                             {
                                                                 new NHibernateConfigurator(),
                                                                 new RepositoriesConfigurator(),
                                                                 new EntitiesConfigurator(),
                                                                 new ModelsConfigurator(),
                                                                 new ViewModelConfigurator(),
                                                                 new ViewsConfigurator()
                                                             };

        private IWindsorContainer container;

        #region IContainerAccessor Members

        public IWindsorContainer Container
        {
            get { return container; }
        }

        #endregion

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
            
            container.Register(Component.For<IWindsorContainer>().Instance(container));

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