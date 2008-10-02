using NHibernate.Cfg;
using NUnit.Framework;
using NUnit.Framework.Syntax.CSharp;
using uNhAddIns.SessionEasier;

namespace uNhAddIns.Test.SessionEasier
{
	[TestFixture]
	public class DefaultMultiFactoryConfiguratorFixture
	{
		[Test]
		public void Configure()
		{
			var mfc = new DefaultMultiFactoryConfigurator();
			Configuration[] actual = mfc.Configure();
			Assert.That(actual.Length, Is.EqualTo(2));
			Assert.That(actual[0].Properties.ContainsKey("query.substitutions"));
			Assert.That(!actual[1].Properties.ContainsKey("query.substitutions"));
		}
	}
}