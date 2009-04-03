using System.Collections.Generic;
using Iesi.Collections.Generic;
using NHibernate.Cache;
using NHibernate.Cfg;

namespace uNhAddIns.Cache
{
	public class TolerantQueryCache : StandardQueryCache
	{
		private readonly HashSet<string> toleratedSpaces;

		public TolerantQueryCache(Settings settings, IDictionary<string, string> props,
		                          UpdateTimestampsCache updateTimestampsCache, string regionName)
			: base(settings, props, updateTimestampsCache, regionName)
		{
			toleratedSpaces = new HashSet<string>(props.GetQueryCacheRegionTolerance(regionName));
		}

		public IEnumerable<string> ToleratedSpaces
		{
			get { return toleratedSpaces; }
		}

		protected override bool IsUpToDate(ISet<string> spaces, long timestamp)
		{
			if (spaces.Count > 0 && IsTolerated(spaces))
			{
				return true;
			}
			else
			{
				return base.IsUpToDate(spaces, timestamp);
			}
		}

		public virtual bool IsTolerated(IEnumerable<string> spaces)
		{
			return toleratedSpaces.IsSupersetOf(spaces);
		}
	}
}