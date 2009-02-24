using System.Linq;
using NHibernate.Cfg;
using NUnit.Framework;
using uNhAddIns.SessionEasier;

namespace uNhAddIns.Test.SessionEasier
{
	[TestFixture]
	public class DefaultMultiFactoryConfiguratorFixture
	{
		[Test]
		public void Configure()
		{
			var mfc = new DefaultMultiFactoryConfigurationProvider();
			var actual = (Configuration[]) mfc.Configure();
			Assert.That(actual.Count(), Is.EqualTo(2));
			Assert.That(actual[0].Properties.ContainsKey("query.substitutions"));
			Assert.That(!actual[1].Properties.ContainsKey("query.substitutions"));
		}
	}
}