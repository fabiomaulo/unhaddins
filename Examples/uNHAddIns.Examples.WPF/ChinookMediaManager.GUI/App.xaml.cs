using System.Windows;
using ChinookMediaManager.Infrastructure;
using ChinookMediaManager.ViewModels;
using Microsoft.Practices.ServiceLocation;
using uNhAddIns.Adapters;

namespace ChinookMediaManager.GUI
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IGuyWire guyWire = ApplicationConfiguration.GetGuyWire();

        public App()
        {
            guyWire.Wire();
            log4net.Config.XmlConfigurator.Configure();
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            var viewFactory = ServiceLocator.Current.GetInstance<IViewFactory>();
            viewFactory.ShowView<BrowseArtistViewModel>();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            guyWire.Dewire();
        }
    }
}