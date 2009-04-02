using System.Collections.Generic;
using NHibernate.Cache;
using NHibernate.Cfg;
using NUnit.Framework;
using uNhAddIns.Cache;

namespace uNhAddIns.Test.Cache
{
	[TestFixture]
	public class ConfigurationExtensionsFixture
	{
		public class CustomQcStub : StandardQueryCache
		{
			public CustomQcStub(Settings settings, IDictionary<string, string> props, UpdateTimestampsCache updateTimestampsCache, string regionName) : base(settings, props, updateTimestampsCache, regionName) { }
		}


		[Test]
		public void FluentConfigurationUsage()
		{
			const string regionName = "RefineSearchStatistics";
			const string regionName1 = "Statistics";
			var nhcfg = new Configuration();

			nhcfg.QueryCache()
				.ResolveRegion(regionName).Using<CustomQcStub>().TolerantWith("ATable");

			nhcfg.GetQueryCacheRegionResolver(regionName)
				.Should().Be.Equal(typeof(CustomQcStub));

			nhcfg.GetQueryCacheRegionTolerance(regionName)
				.Should().Have.SameSequenceAs(new[] { "ATable" });

			nhcfg.QueryCache()
				.ResolveRegion(regionName1).Using<StandardQueryCache>().TolerantWith("ATable", "ATable2", "ATable1");

			nhcfg.GetQueryCacheRegionResolver(regionName1)
				.Should().Be.Equal(typeof(StandardQueryCache));

			nhcfg.GetQueryCacheRegionTolerance(regionName1)
				.Should().Have.SameSequenceAs(new[] { "ATable", "ATable2", "ATable1" });
		}
	}
}