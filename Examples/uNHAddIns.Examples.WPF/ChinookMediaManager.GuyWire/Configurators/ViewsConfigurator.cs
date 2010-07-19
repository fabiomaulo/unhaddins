using System.Windows;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ChinookMediaManager.GUI.Artifacts;
using ChinookMediaManager.Infrastructure;

namespace ChinookMediaManager.GuyWire.Configurators
{
    public class ViewsConfigurator : IConfigurator
    {
        #region IConfigurator Members

        public void Configure(IWindsorContainer container)
        {
            container.Register(AllTypes.FromAssemblyNamed("ChinookMediaManager.GUI")
                                   .Where(t => typeof (Window).IsAssignableFrom(t))
                                   .Configure(c => c.LifeStyle.Transient));

            container.Register(Component.For<IViewFactory>()
                                        .ImplementedBy<ViewFactory>());

		}

        #endregion
    }
}