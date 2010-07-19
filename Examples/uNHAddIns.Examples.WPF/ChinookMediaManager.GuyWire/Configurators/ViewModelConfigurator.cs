using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ChinookMediaManager.GUI.Artifacts;
using ChinookMediaManager.ViewModels;

namespace ChinookMediaManager.GuyWire.Configurators
{
    public class ViewModelConfigurator : IConfigurator
    {
        #region IConfigurator Members

        public void Configure(IWindsorContainer container)
        {
            container.Register(Component.For<BrowseArtistViewModel>()
                                   .LifeStyle.Transient);

            container.Register(Component.For<AlbumManagerViewModel>()
                                   .LifeStyle.Transient);

            container.Register(Component.For<EditAlbumViewModel>()
                                       .LifeStyle.Transient);

        	container.Register(Component.For<IViewModelFactory>().AsFactory());
        }

        #endregion
    }
}