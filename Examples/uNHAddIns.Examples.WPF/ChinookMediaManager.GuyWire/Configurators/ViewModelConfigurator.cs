using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ChinookMediaManager.GUI.ViewModels;
using ChinookMediaManager.Infrastructure;
using ChinookMediaManager.ViewModels;

namespace ChinookMediaManager.GuyWire.Configurators
{
    public class ViewModelConfigurator : IConfigurator
    {
        #region IConfigurator Members

        public void Configure(IWindsorContainer container)
        {
            container.Register(Component.For<IBrowseArtistViewModel>()
                                   .ImplementedBy<BrowseArtistViewModel>()
                                   .LifeStyle.Transient);

            container.Register(Component.For<IAlbumManagerViewModel>()
                                   .ImplementedBy<AlbumManagerViewModel>()
                                   .LifeStyle.Transient);

            container.Register(Component.For<IEditAlbumViewModel>()
                                       .ImplementedBy<EditAlbumViewModel>()
                                       .LifeStyle.Transient);
        }

        #endregion
    }
}