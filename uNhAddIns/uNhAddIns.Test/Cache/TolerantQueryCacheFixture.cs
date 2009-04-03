using NHibernate.Cfg;
using NHibernate.Engine;
using NUnit.Framework;
using uNhAddIns.Cache;
using NHibernate.Cache;

namespace uNhAddIns.Test.Cache
{
	[TestFixture]
	public class TolerantQueryCacheFixture
	{
		const string regionName = "RefineSearchStatistics";
		const string regionName1 = "Statistics";
		ISessionFactoryImplementor sfi;

		[TestFixtureSetUp]
		public void ConfigureNh()
		{
			var nhcfg = new Configuration().Configure();
			nhcfg.SetProperty(Environment.CacheProvider, typeof(HashtableCacheProvider).AssemblyQualifiedName);
			nhcfg.QueryCache().ResolveRegion(regionName).Using<TolerantQueryCache>().TolerantWith("ATable");
			nhcfg.QueryCache().ResolveRegion(regionName1).Using<TolerantQueryCache>().TolerantWith("ATable", "ATable2", "ATable1");

			sfi = (ISessionFactoryImplementor)nhcfg.BuildSessionFactory();			
		}

		[TestFixtureTearDown]
		public void ShutdownNh()
		{
			sfi.Dispose();
		}

		[Test]
		public void ShouldBeTolerant()
		{
			var tqc = (TolerantQueryCache) sfi.GetQueryCache(regionName);
			Assert.That(tqc.IsTolerated(new[] {"ATable"}));

			tqc = (TolerantQueryCache)sfi.GetQueryCache(regionName1);
			Assert.That(tqc.IsTolerated(new[] { "ATable" }));
			Assert.That(tqc.IsTolerated(new[] { "ATable1" }));
			Assert.That(tqc.IsTolerated(new[] { "ATable", "ATable2" }));
			Assert.That(tqc.IsTolerated(new[] { "ATable", "ATable2", "ATable1" }));
		}

		[Test]
		public void ShouldNotBeTolerant()
		{
			var tqc = (TolerantQueryCache)sfi.GetQueryCache(regionName);
			Assert.That(!tqc.IsTolerated(new[] { "ATable1" }));

			tqc = (TolerantQueryCache)sfi.GetQueryCache(regionName1);
			Assert.That(!tqc.IsTolerated(new[] { "BTable" }));
			Assert.That(!tqc.IsTolerated(new[] { "ATable", "ATable2", "BTable" }));
		}
	}
}