using System.Collections.ObjectModel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ChinookMediaManager.Domain;
using ChinookMediaManager.Infrastructure;
using uNhAddIns.ComponentBehaviors;
using uNhAddIns.ComponentBehaviors.Castle;
using uNhAddIns.ComponentBehaviors.Castle.Configuration;

namespace ChinookMediaManager.GuyWire.Configurators
{
	public class EntitiesConfigurator : IConfigurator
	{
		#region IConfigurator Members

		public void Configure(IWindsorContainer container)
		{
			container.AddFacility<ComponentBehaviorsFacility>();
            var config = new BehaviorDictionary();
			config.For<Album>().Add<DataErrorInfoBehavior>()
							.Add<NotifyPropertyChangedBehavior>();
			container.Register(Component.For<IBehaviorStore>().Instance(config));

			container.Register(Component.For<Album>()
								.OnCreate((kernel, album) => album.Tracks = new ObservableCollection<Track>())
								.LifeStyle.Transient);

			container.Register(Component.For<IEntityFactory>()
			                   	.ImplementedBy<EntityFactory>());
		}

		#endregion
	}
}