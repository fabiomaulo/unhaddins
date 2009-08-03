using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ChinookMediaManager.Domain;
using ChinookMediaManager.Presenters.ModelInterfaces;
using uNhAddIns.WPF.Castle;

namespace ChinookMediaManager.GuyWire.Configurators
{
    public class EntitiesConfigurator : IConfigurator
    {
        public void Configure(IWindsorContainer container)
        {
            container.AddFacility<WpfFacility>();

            container.Register(Component.For<Album>()
                                   .AddEditableBehavior()
                                   .AddNotificableBehavior()
                                   .NhibernateEntity()
                                   .Proxy.AdditionalInterfaces(typeof(IEditableAlbum)).LifeStyle.Transient);
        }
    }
}