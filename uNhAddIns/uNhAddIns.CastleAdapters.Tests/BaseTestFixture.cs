using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Castle.Core;
using log4net.Config;

namespace uNhAddIns.CastleAdapters.Tests
{
	public class BaseTestFixture: IContainerAccessor
	{
		private static readonly WindsorContainer container;
		static BaseTestFixture()
		{
			XmlConfigurator.Configure();

			container = new WindsorContainer(new XmlInterpreter());
			container.AddComponentLifeStyle<IContainerAccessor, BaseTestFixture>(LifestyleType.Singleton);
		}

		public IWindsorContainer Container
		{
			get { return container; }
		}
	}
}