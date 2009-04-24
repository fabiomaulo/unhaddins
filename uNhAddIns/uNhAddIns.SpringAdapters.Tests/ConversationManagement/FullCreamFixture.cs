using CommonServiceLocator.SpringAdapter;
using Microsoft.Practices.ServiceLocation;
using NUnit.Framework;
using Spring.Context;
using uNhAddIns.Adapters.CommonTests.Integration;
using Spring.Context.Support;

namespace uNhAddIns.SpringAdapters.Tests.ConversationManagement
{
	[TestFixture, Ignore("Not implemented yet")]
	public class FullCreamFixture : FullCreamFixtureBase
	{
		#region Overrides of FullCreamFixtureBase

		protected override void InitializeServiceLocator()
		{
			IConfigurableApplicationContext context = new XmlApplicationContext();
			var objectFactory = context.ObjectFactory;
			var sl = new SpringServiceLocatorAdapter(objectFactory);
			objectFactory.RegisterInstance<IServiceLocator>(sl);

			ServiceLocator.SetLocatorProvider(() => sl);
		}

		#endregion
	}
}