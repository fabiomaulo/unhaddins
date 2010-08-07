using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ChinookMediaManager.ViewModels;

namespace ChinookMediaManager.GuyWire.Configurators
{
	public class PresenterInstaller : IWindsorInstaller
	{
		#region IWindsorInstaller Members

		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Component.For<BrowseArtistViewModel>()
										.LifeStyle.Transient);

			container.Register(Component.For<AlbumManagerViewModel>()
										.LifeStyle.Transient);

			container.Register(Component.For<EditAlbumViewModel>()
										.LifeStyle.Transient);
		}

		#endregion
	}
}