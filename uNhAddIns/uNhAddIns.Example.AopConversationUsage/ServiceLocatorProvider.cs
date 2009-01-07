using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using uNhAddIns.CastleAdapters;
using uNhAddIns.CastleAdapters.AutomaticConversationManagement;
using uNhAddIns.Example.AopConversationUsage.BusinessLogic;
using uNhAddIns.Example.AopConversationUsage.DataAccessObjects;
using uNhAddIns.Example.AopConversationUsage.Entities;
using uNhAddIns.Example.AopConversationUsage.MultiTiers;
using uNhAddIns.SessionEasier;
using uNhAddIns.SessionEasier.Conversations;

namespace uNhAddIns.Example.AopConversationUsage
{
	public class ServiceLocatorProvider
	{
		public IServiceLocator GetServiceLocator()
		{
			var container = new WindsorContainer();
			container.AddFacility<PersistenceConversationFacility>();
			var sfp = new SessionFactoryProvider();
			sfp.AfterConfigure += ((sender, e) => new SchemaExport(e.Configuration).Create(false, true));
			container.Register(Component.For<ISessionFactoryProvider>().Instance(sfp));
			container.Register(Component.For<ISessionWrapper>().ImplementedBy<SessionWrapper>());
			container.Register(Component.For<IConversationFactory>().ImplementedBy<DefaultConversationFactory>());
			container.Register(Component.For<IConversationsContainerAccessor>().ImplementedBy<NhConversationsContainerAccessor>());

			container.Register(Component.For<IDaoFactory>().ImplementedBy<DaoFactory>());
			container.Register(Component.For<ISessionFactory>().Instance(sfp.GetFactory(null)));

			RegisterNaturalnessDaos<Reptile>(container);
			RegisterNaturalnessDaos<Human>(container);

			container.Register(
				Component.For(typeof (IFamilyCrudModel<>)).ImplementedBy(typeof (FamilyCrudModel<>)).LifeStyle.Transient);
			return new WindsorServiceLocator(container);
		}

		private static void RegisterNaturalnessDaos<T>(IWindsorContainer cont) where T : Animal
		{
			var animalDao = new AnimalDao<T>(cont.Resolve<ISessionFactory>());
			cont.Register(
				Component.For<IAnimalReadOnlyDao<T>>().Instance(animalDao).Named(
					typeof (IAnimalReadOnlyDao<T>).AssemblyQualifiedName));
			cont.Register(Component.For<ICrudDao<T>>().Instance(animalDao).Named(typeof (ICrudDao<T>).AssemblyQualifiedName));
			cont.Register(Component.For<IDao<T>>().Instance(animalDao).Named(typeof (IDao<T>).AssemblyQualifiedName));

			var familyDao = new FamilyDao<T>(cont.Resolve<ISessionFactory>());
			cont.Register(Component.For<IFamilyDao<T>>().Instance(familyDao).Named(typeof (IFamilyDao<T>).AssemblyQualifiedName));
			cont.Register(
				Component.For<ICrudDao<Family<T>>>().Instance(familyDao).Named(typeof (ICrudDao<Family<T>>).AssemblyQualifiedName));
			cont.Register(
				Component.For<IDao<Family<T>>>().Instance(familyDao).Named(typeof (IDao<Family<T>>).AssemblyQualifiedName));
		}
	}
}