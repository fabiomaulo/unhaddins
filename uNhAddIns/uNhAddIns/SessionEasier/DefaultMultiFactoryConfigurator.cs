using System.Collections.Generic;
using System.Configuration;
using Configuration=NHibernate.Cfg.Configuration;

namespace uNhAddIns.SessionEasier
{
	public class DefaultMultiFactoryConfigurator : IMultiFactoryConfigurator
	{
		private const string factoriesStart = "nhfactory";
		public Configuration[] Configure()
		{
			var result = new List<Configuration>(4);
			foreach (string setting in ConfigurationManager.AppSettings.Keys)
			{
				if (setting.StartsWith(factoriesStart))
				{
					string nhConfigFilePath = ConfigurationManager.AppSettings[setting];
					result.Add(new Configuration().Configure(nhConfigFilePath));
				}
			}
			return result.ToArray();
		}
	}
}