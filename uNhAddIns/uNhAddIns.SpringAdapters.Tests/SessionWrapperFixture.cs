using CommonServiceLocator.SpringAdapter;
using Microsoft.Practices.ServiceLocation;
using NUnit.Framework;
using Spring.Context.Support;
using uNhAddIns.Adapters.CommonTests.Integration;
using uNhAddIns.SessionEasier;

namespace uNhAddIns.SpringAdapters.Tests
{
	[TestFixture]
	public class SessionWrapperFixture : SessionWrapperFixtureBase
	{

		#region Overrides of SessionWrapperFixtureBase

		protected override IServiceLocator NewServiceLocator()
		{
			var context = new StaticApplicationContext();
			var objectFactory = context.DefaultListableObjectFactory;
			objectFactory.RegisterSingleton(typeof(ISessionWrapper).FullName, new SessionWrapper());

			return new SpringServiceLocatorAdapter(objectFactory);
		}

		#endregion
	}
}