using System.Collections.Generic;
using NHibernate.Cache;
using NHibernate.Cfg;

namespace uNhAddIns.Cache
{
	public class TolerantQueryCache: StandardQueryCache
	{
		public TolerantQueryCache(Settings settings, IDictionary<string, string> props, UpdateTimestampsCache updateTimestampsCache, string regionName) : base(settings, props, updateTimestampsCache, regionName)
		{
			ToleratedSpaces = props.GetQueryCacheRegionTolerance(regionName);
		}

		public IEnumerable<string> ToleratedSpaces { get; private set; }
	}
}