using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ChinookMediaManager.Domain;
using ChinookMediaManager.Infrastructure;
using uNhAddIns.ComponentBehaviors.Castle;


namespace ChinookMediaManager.GuyWire.Configurators
{
    public class EntitiesConfigurator : IConfigurator
    {
        public void Configure(IWindsorContainer container)
        {
            container.AddFacility<ComponentBehaviorsFacility>();

            container.Register(Component.For<Album>()
                                    .NhibernateEntity()
                                    .AddDataErrorInfoBehavior()
                                    .AddNotificableBehavior()
                                    .LifeStyle.Transient);

            container.Register(Component.For<IEntityFactory>()
                                        .ImplementedBy<EntityFactory>());
        }
    }
}