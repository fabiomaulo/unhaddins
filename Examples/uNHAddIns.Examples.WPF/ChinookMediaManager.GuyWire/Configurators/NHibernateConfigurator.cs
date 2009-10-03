using Castle.Facilities.FactorySupport;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NHibernate;
using NHibernate.Engine;
using NHibernate.Validator.Cfg;
using uNhAddIns.CastleAdapters;
using uNhAddIns.CastleAdapters.AutomaticConversationManagement;
using uNhAddIns.CastleAdapters.EnhancedBytecodeProvider;
using uNhAddIns.NHibernateTypeResolver;
using uNhAddIns.SessionEasier;
using uNhAddIns.SessionEasier.Conversations;
using uNhAddIns.WPF.Collections;
using Environment=NHibernate.Cfg.Environment;

namespace ChinookMediaManager.GuyWire.Configurators
{
	public class NHibernateConfigurator : IConfigurator
	{
		#region IConfigurator Members

		public void Configure(IWindsorContainer container)
		{
			container.AddFacility<PersistenceConversationFacility>();

			Environment.BytecodeProvider = new EnhancedBytecode(container);


			var nhConfigurator = new DefaultSessionFactoryConfigurationProvider();
			nhConfigurator.BeforeConfigure += (sender, e) =>
				{
					ValidatorInitializer.Initialize(e.Configuration);
					e.Configuration.RegisterEntityNameResolver();
					e.Configuration.Properties[Environment.CollectionTypeFactoryClass]
						= typeof (WpfCollectionTypeFactory).AssemblyQualifiedName;
				};

			var sfp = new SessionFactoryProvider(nhConfigurator);

			container.Register(Component.For<ISessionFactoryProvider>()
			                   	.Instance(sfp));
			container.Register(
				Component.For<ISessionFactory>().UsingFactoryMethod(
					() => container.Resolve<ISessionFactoryProvider>().GetFactory(null)));

			container.Register(
				Component.For<ISessionFactoryImplementor>().UsingFactoryMethod(
					() => (ISessionFactoryImplementor) container.Resolve<ISessionFactoryProvider>().GetFactory(null)));

			container.Register(Component.For<ISessionWrapper>().ImplementedBy<SessionWrapper>());
			container.Register(Component.For<IConversationFactory>().ImplementedBy<DefaultConversationFactory>());
			container.Register(
				Component.For<IConversationsContainerAccessor>().ImplementedBy<NhConversationsContainerAccessor>());
		}

		#endregion
	}
}