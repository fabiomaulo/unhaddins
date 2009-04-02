using NHibernate.Cfg;

namespace uNhAddIns.Cache
{
	public static class ConfigurationExtensions
	{
		public static IQueryCacheFactoryConfiguration QueryCache(this Configuration cfg)
		{
			return null;
		}
	}
}