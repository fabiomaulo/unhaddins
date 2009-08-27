using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ChinookMediaManager.Domain;
using ChinookMediaManager.Infrastructure;
using uNhAddIns.WPF.Castle;

namespace ChinookMediaManager.GuyWire.Configurators
{
    public class EntitiesConfigurator : IConfigurator
    {
        public void Configure(IWindsorContainer container)
        {
            container.AddFacility<WpfFacility>();

            container.Register(Component.For<Album>()
                                    .NhibernateEntity()
                                    .AddWpfValidationCompatibility()
                                    .AddNotificableBehavior()
                                    .LifeStyle.Transient);

            container.Register(Component.For<IEntityFactory>()
                                        .ImplementedBy<EntityFactory>());
        }
    }
}