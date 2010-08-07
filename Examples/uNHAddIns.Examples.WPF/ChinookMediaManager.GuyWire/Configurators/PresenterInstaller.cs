using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ChinookMediaManager.GUI.Albums.Browse;

namespace ChinookMediaManager.GuyWire.Configurators
{
	public class PresenterInstaller : IWindsorInstaller
	{
		#region IWindsorInstaller Members

		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Component.For<AlbumsBrowseViewModel>()
										.LifeStyle.Transient);

		}

		#endregion
	}
}