using System.Collections.Generic;
using System.Linq;
using NHibernate.Cfg;
using uNhAddIns.Cache.ConfigurationImpl;
using System;

namespace uNhAddIns.Cache
{
	public static class ConfigurationExtensions
	{
		private const string QueryCacheResolverKeyPrefix = "uNhAddIns.Cache_";
		private const string QueryCacheToleranceKeyPrefix = "uNhAddIns.CacheTolerance_";

		public static IQueryCacheFactoryConfiguration QueryCache(this Configuration cfg)
		{
			return new QueryCacheFactoryConfiguration(cfg);
		}

		public static Type GetQueryCacheRegionResolver(this Configuration cfg, string regionName)
		{
			return Type.GetType(cfg.GetProperty(GetResolverConfigurationKey(regionName)));
		}

		public static IEnumerable<string> GetQueryCacheRegionTolerance(this Configuration cfg, string regionName)
		{
			return GetDisassembledSpacesString(cfg.GetProperty(GetToleranceConfigurationKey(regionName)));
		}

		internal static void SetQueryCacheRegionResolver(this Configuration cfg, string regionName, Type type)
		{
			cfg.SetProperty(GetResolverConfigurationKey(regionName), type.AssemblyQualifiedName);
		}

		internal static void SetQueryCacheRegionTolerance(this Configuration cfg, string regionName, IEnumerable<string> spaces)
		{
			cfg.SetProperty(GetToleranceConfigurationKey(regionName), GetAssembledSpacesString(spaces));
		}

		private static string GetResolverConfigurationKey(string regionName)
		{
			return string.Concat(QueryCacheResolverKeyPrefix, regionName);
		}

		private static string GetToleranceConfigurationKey(string regionName)
		{
			return string.Concat(QueryCacheToleranceKeyPrefix, regionName);
		}

		private static string GetAssembledSpacesString(IEnumerable<string> spaces)
		{
			return string.Join(";", spaces.ToArray());
		}

		private static IEnumerable<string> GetDisassembledSpacesString(string assembledSpacesString)
		{
			return assembledSpacesString.Split(';');
		}
	}
}