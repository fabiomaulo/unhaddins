using System;
using Castle.Windsor;
using ChinookMediaManager.GuyWire.Configurators;
using uNhAddIns.Adapters;

namespace ChinookMediaManager.GuyWire
{
    public class ModelTestsGuyWire : IGuyWire, IContainerAccessor
    {
        private readonly IConfigurator[] configurators = new IConfigurator[]
                                                             {
                                                                 new NHibernateConfigurator(),
                                                                 new RepositoriesConfigurator(),
                                                                 new EntitiesConfigurator(),
                                                                 new ModelsConfigurator()
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
            container.Dispose();
        }

        #endregion

        public IWindsorContainer Container
        {
            get { return container; }
        }
    }
}