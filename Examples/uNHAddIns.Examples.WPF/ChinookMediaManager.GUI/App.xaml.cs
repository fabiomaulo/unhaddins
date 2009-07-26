using System.Linq;
using System.Reflection;
using System.Windows;
using Caliburn.Castle;
using Caliburn.PresentationFramework.ApplicationModel;
using Castle.Facilities.FactorySupport;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ChinookMediaManager.Data.Repositories;
using ChinookMediaManager.Domain.Model;
using ChinookMediaManager.Infrastructure;
using ChinookMediaManager.Presenters.Interfaces;
using Microsoft.Practices.ServiceLocation;
using NHibernate;
using NHibernate.Cfg;
using uNhAddIns.CastleAdapters;
using uNhAddIns.CastleAdapters.AutomaticConversationManagement;
using uNhAddIns.CastleAdapters.EnhancedBytecodeProvider;
using uNhAddIns.SessionEasier;
using uNhAddIns.SessionEasier.Conversations;
using uNhAddIns.WPF.EntityNameResolver;

namespace ChinookMediaManager.GUI
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : CaliburnApplication
    {
        protected override IServiceLocator CreateContainer()
        {
            var container = new WindsorContainer();

            ConfigureNhibernate(container);
            ConfigureRepositories(container);
            ConfigureModels(container);
            ConfigurePresenters(container);
            ConfigureViews(container);

            return new WindsorAdapter(container);
        }

        protected override void ConfigurePresentationFramework(Caliburn.PresentationFramework.PresentationFrameworkModule module)
        {
            base.ConfigurePresentationFramework(module);
            module.UsingViewStrategy<ViewStrategy>();
        }

        private static void ConfigurePresenters(IWindsorContainer container)
        {
            var presenterServices = typeof(IAlbumManagementPresenter).Assembly
                        .GetTypes().Where(t => t.IsInterface && t.Namespace.EndsWith("Interfaces"));

            var presenterImpl = typeof(IAlbumManagementPresenter).Assembly.GetTypes()
                        .Where(t => t.GetInterfaces().Any(i => presenterServices.Contains(i)));

            foreach (var service in presenterServices)
                foreach (var impl in presenterImpl)
                    if (service.IsAssignableFrom(impl))
                        container.Register(Component.For(service).ImplementedBy(impl).LifeStyle.Transient);
        }

        private static void ConfigureModels(IWindsorContainer container)
        {
            var repositoryServices = typeof(IAlbumManagementModel).Assembly
                        .GetTypes().Where(t => t.IsInterface && t.Namespace.EndsWith("Model"));

            var repositoryImpl = Assembly.Load("ChinookMediaManager.Domain.Impl").GetTypes()
                        .Where(t => t.GetInterfaces().Any(i => repositoryServices.Contains(i)));

            foreach (var service in repositoryServices)
                foreach (var impl in repositoryImpl)
                    if (service.IsAssignableFrom(impl))
                        container.Register(Component.For(service).ImplementedBy(impl).LifeStyle.Transient);
        }

        private static void ConfigureRepositories(IWindsorContainer container)
        {
            var repositoryServices = typeof(IAlbumRepository).Assembly.GetTypes().Where(t => t.IsInterface);
            var repositoryImpl = Assembly.Load("ChinookMediaManager.Data.Impl").GetTypes()
                .Where(t => t.GetInterfaces().Any(i => repositoryServices.Contains(i)));

            foreach (var service in repositoryServices)
                foreach (var impl in repositoryImpl)
                    if (service.IsAssignableFrom(impl))
                        container.Register(Component.For(service).ImplementedBy(impl).LifeStyle.Transient);
        }
        
        private static void ConfigureNhibernate(IWindsorContainer container)
        {
            container.AddFacility<PersistenceConversationFacility>();
            container.AddFacility<FactorySupportFacility>();

            Environment.BytecodeProvider = new EnhancedBytecode(container);

            var nhConfigurator = new DefaultSessionFactoryConfigurationProvider();
            nhConfigurator.BeforeConfigure += (sender, e) => e.Configuration.RegisterEntityNameResolver();
            var sfp = new SessionFactoryProvider(nhConfigurator);

            container.Register(Component.For<ISessionFactoryProvider>()
                                   .Instance(sfp));
            container.Register(
                Component.For<ISessionFactory>().UsingFactoryMethod(
                    () => container.Resolve<ISessionFactoryProvider>().GetFactory(null)));


            container.Register(Component.For<ISessionWrapper>().ImplementedBy<SessionWrapper>());
            container.Register(Component.For<IConversationFactory>().ImplementedBy<DefaultConversationFactory>());
            container.Register(Component.For<IConversationsContainerAccessor>().ImplementedBy<NhConversationsContainerAccessor>());
        }

        private void ConfigureViews(IWindsorContainer container)
        {
            container.Register(AllTypes.FromAssemblyContaining(GetType())
                                       .Where(t => typeof(Window).IsAssignableFrom(t))
                                       .Configure(c => c.LifeStyle.Transient));
        }

        protected override object CreateRootModel()
        {
            return Container.GetInstance<IBrowseArtistPresenter>();
        }
    }
}