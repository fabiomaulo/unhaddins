using Caliburn.Castle;
using Caliburn.PresentationFramework;
using Caliburn.PresentationFramework.ApplicationModel;
using Castle.Windsor;
using ChinookMediaManager.Infrastructure;
using ChinookMediaManager.Presenters.Interfaces;
using Microsoft.Practices.ServiceLocation;
using uNhAddIns.Adapters;

namespace ChinookMediaManager.GUI
{
    
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : CaliburnApplication
    {
        //private ApplicationConfiguration appConfig
        //    = new ApplicationConfiguration();

        private readonly IGuyWire guyWire = ApplicationConfiguration.GetGuyWire();

        protected override IServiceLocator CreateContainer()
        {
            guyWire.Wire();

            var containerAccessor = (IContainerAccessor)guyWire;
            return new WindsorAdapter(containerAccessor.Container);
        }

        protected override void ConfigurePresentationFramework(PresentationFrameworkModule module)
        {
            base.ConfigurePresentationFramework(module);
            module.UsingViewStrategy<ViewStrategy>();
        }

        protected override object CreateRootModel()
        {
            return Container.GetInstance<IBrowseArtistPresenter>();
        }

        protected override void OnExit(System.Windows.ExitEventArgs e)
        {
            base.OnExit(e);
            guyWire.Dewire();
        }
    }
}