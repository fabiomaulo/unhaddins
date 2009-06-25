using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CommonServiceLocator.WindsorAdapter;
using Microsoft.Practices.ServiceLocation;
using NHibernate;
using uNhAddIns.CastleAdapters;
using uNhAddIns.CastleAdapters.AutomaticConversationManagement;
using uNhAddIns.Example.AopConversationUsage.BusinessLogic;
using uNhAddIns.Example.AopConversationUsage.DataAccessObjects;
using uNhAddIns.Example.AopConversationUsage.Entities;
using uNhAddIns.SessionEasier;
using uNhAddIns.SessionEasier.Conversations;

namespace uNhAddIns.Example.AopConversationUsage
{
	public class ServiceLocatorProvider
	{
		public static void Initialize()
		{
			var container = new WindsorContainer();
			container.AddFacility<PersistenceConversationFacility>();

			var sfp = new SessionFactoryProvider();
			container.Register(Component.For<ISessionFactoryProvider>().Instance(sfp));

			// This is because AFIK the programmatic conf of Windsor does not support the factory-method feature
			// the equivalent XML conf should look like
			/*
			  <component id="uNhAddIns.sessionFactory"
					type="NHibernate.ISessionFactory, NHibernate"
					factoryId="sessionFactoryProvider"
					factoryCreate="GetFactory">
					<parameters>
						<factoryId>null</factoryId>
					</parameters>
				</component>
			 */
			container.Register(Component.For<ISessionFactory>().Instance(sfp.GetFactory(null)));
			//********************

			container.Register(Component.For<ISessionWrapper>().ImplementedBy<SessionWrapper>());
			container.Register(Component.For<IConversationFactory>().ImplementedBy<DefaultConversationFactory>());
			container.Register(Component.For<IConversationsContainerAccessor>().ImplementedBy<NhConversationsContainerAccessor>());

			container.Register(Component.For<IDaoFactory>().ImplementedBy<DaoFactory>());

			RegisterNaturalnessDaos<Reptile>(container);
			RegisterNaturalnessDaos<Human>(container);

			container.Register(
				Component.For(typeof (IFamilyCrudModel<>)).ImplementedBy(typeof (FamilyCrudModel<>)).LifeStyle.Transient);

			var sl = new WindsorServiceLocator(container);
			container.Register(Component.For<IServiceLocator>().Instance(sl));
			ServiceLocator.SetLocatorProvider(() => sl);
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