using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using Caliburn.Castle;
using Caliburn.PresentationFramework;
using Caliburn.PresentationFramework.ApplicationModel;
using Castle.Facilities.FactorySupport;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ChinookMediaManager.Data.Repositories;
using ChinookMediaManager.Domain;
using ChinookMediaManager.Domain.Model;
using ChinookMediaManager.Infrastructure;
using ChinookMediaManager.Presenters.Interfaces;
using ChinookMediaManager.Presenters.ModelInterfaces;
using Microsoft.Practices.ServiceLocation;
using NHibernate;
using uNhAddIns.CastleAdapters;
using uNhAddIns.CastleAdapters.AutomaticConversationManagement;
using uNhAddIns.CastleAdapters.EnhancedBytecodeProvider;
using uNhAddIns.SessionEasier;
using uNhAddIns.SessionEasier.Conversations;
using uNhAddIns.WPF.EntityNameResolver;
using Environment=NHibernate.Cfg.Environment;
using uNhAddIns.WPF.Castle;

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
            ConfigureEntities(container);
            return new WindsorAdapter(container);
        }

        protected override void ConfigurePresentationFramework(PresentationFrameworkModule module)
        {
            base.ConfigurePresentationFramework(module);
            module.UsingViewStrategy<ViewStrategy>();
        }

        private static void ConfigurePresenters(IWindsorContainer container)
        {
            IEnumerable<Type> presenterServices = typeof (IAlbumManagerPresenter).Assembly
                .GetTypes().Where(t => t.IsInterface && t.Namespace.EndsWith("Interfaces"));

            IEnumerable<Type> presenterImpl = typeof (IAlbumManagerPresenter).Assembly.GetTypes()
                .Where(t => t.GetInterfaces().Any(i => presenterServices.Contains(i)));

            foreach (Type service in presenterServices)
                foreach (Type impl in presenterImpl)
                    if (service.IsAssignableFrom(impl))
                        container.Register(Component.For(service).ImplementedBy(impl).LifeStyle.Transient);


            container.Register(Component.For<IPresenterFactory>().ImplementedBy<PresenterFactory>());
        }

        private static void ConfigureModels(IWindsorContainer container)
        {
            IEnumerable<Type> repositoryServices = typeof (IAlbumManagerModel).Assembly
                .GetTypes().Where(t => t.IsInterface && t.Namespace.EndsWith("Model"));

            IEnumerable<Type> repositoryImpl = Assembly.Load("ChinookMediaManager.Domain.Impl").GetTypes()
                .Where(t => t.GetInterfaces().Any(i => repositoryServices.Contains(i)));

            foreach (Type service in repositoryServices)
                foreach (Type impl in repositoryImpl)
                    if (service.IsAssignableFrom(impl))
                        container.Register(Component.For(service).ImplementedBy(impl).LifeStyle.Transient);
        }

        private static void ConfigureRepositories(IWindsorContainer container)
        {
            IEnumerable<Type> repositoryServices =
                typeof (IAlbumRepository).Assembly.GetTypes().Where(t => t.IsInterface);
            IEnumerable<Type> repositoryImpl = Assembly.Load("ChinookMediaManager.Data.Impl").GetTypes()
                .Where(t => t.GetInterfaces().Any(i => repositoryServices.Contains(i)));

            foreach (Type service in repositoryServices)
                foreach (Type impl in repositoryImpl)
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
            container.Register(
                Component.For<IConversationsContainerAccessor>().ImplementedBy<NhConversationsContainerAccessor>());
        }

        private static void ConfigureEntities(IWindsorContainer container)
        {
            container.AddFacility<WpfFacility>();

            container.Register(Component.For<Album>()
                                        .AddEditableBehavior()
                                        .AddNotificableBehavior()
                                        .NhibernateEntity()
                                        .Proxy.AdditionalInterfaces(typeof(IEditableAlbum)).LifeStyle.Transient);
        }

        private void ConfigureViews(IWindsorContainer container)
        {
            container.Register(AllTypes.FromAssemblyContaining(GetType())
                                   .Where(t => typeof (Window).IsAssignableFrom(t))
                                   .Configure(c => c.LifeStyle.Transient));
        }

        protected override object CreateRootModel()
        {
            return Container.GetInstance<IBrowseArtistPresenter>();
        }
    }
}