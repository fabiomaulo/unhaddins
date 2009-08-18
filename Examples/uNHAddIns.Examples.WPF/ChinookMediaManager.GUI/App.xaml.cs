using System.Windows;
using Castle.Windsor;
using ChinookMediaManager.GUI.ViewModels;
using ChinookMediaManager.GUI.Views;
using uNhAddIns.Adapters;

namespace ChinookMediaManager.GUI
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IGuyWire guyWire = ApplicationConfiguration.GetGuyWire();
        private IWindsorContainer container;

        public App()
        {
            guyWire.Wire();
            log4net.Config.XmlConfigurator.Configure();
            var containerAccessor = (IContainerAccessor)guyWire;
            container = containerAccessor.Container;
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            var browseArtistPresenter = container.Resolve<IBrowseArtistViewModel>();

            BrowseArtistView bav = new BrowseArtistView
                                       {
                                           DataContext = browseArtistPresenter
                                       };
            bav.Show();
        }
    }
}