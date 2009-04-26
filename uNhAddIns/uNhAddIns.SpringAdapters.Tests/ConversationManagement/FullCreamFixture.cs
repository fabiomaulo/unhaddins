using CommonServiceLocator.SpringAdapter;
using Microsoft.Practices.ServiceLocation;
using NUnit.Framework;
using Spring.Context;
using uNhAddIns.Adapters.CommonTests;
using uNhAddIns.Adapters.CommonTests.Integration;
using Spring.Context.Support;
using uNhAddIns.SessionEasier;

namespace uNhAddIns.SpringAdapters.Tests.ConversationManagement
{
	[TestFixture]
	public class FullCreamFixture : FullCreamFixtureBase
	{
		#region Overrides of FullCreamFixtureBase

		protected override void InitializeServiceLocator()
		{
			// TODO: Make it work trough XML
			IConfigurableApplicationContext context = new StaticApplicationContext();
			var objectFactory = context.ObjectFactory;
			objectFactory.RegisterDefaultConversationAop();
			objectFactory.RegisterDefaultPersistentConversationServices();
			var sl = new SpringServiceLocatorAdapter(objectFactory);
			objectFactory.RegisterInstance<IServiceLocator>(sl);
			ServiceLocator.SetLocatorProvider(() => sl);

			objectFactory.RegisterInstance(ServiceLocator.Current.GetInstance<ISessionFactoryProvider>().GetFactory(null));
			objectFactory.Register<IDaoFactory, DaoFactory>();
			objectFactory.Register<ISillyDao, SillyDao>();
			objectFactory.RegisterPrototype<ISillyCrudModel, Adapters.CommonTests.SillyCrudModel>();
		}

		#endregion
	}
}