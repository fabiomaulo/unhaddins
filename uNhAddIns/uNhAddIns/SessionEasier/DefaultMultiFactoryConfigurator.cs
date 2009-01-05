using System;
using System.Collections.Generic;
using System.Configuration;
using Configuration=NHibernate.Cfg.Configuration;

namespace uNhAddIns.SessionEasier
{
	public class DefaultMultiFactoryConfigurator : IMultiFactoryConfigurator
	{
		private const string factoriesStart = "nhfactory";
		public event EventHandler<ConfigurationEventArgs> BeforeConfigure;
		public event EventHandler<ConfigurationEventArgs> AfterConfigure;

		public Configuration[] Configure()
		{
			var result = new List<Configuration>(4);
			foreach (string setting in ConfigurationManager.AppSettings.Keys)
			{
				if (setting.StartsWith(factoriesStart))
				{
					string nhConfigFilePath = ConfigurationManager.AppSettings[setting];
					var configuration = new Configuration();
					DoBeforeConfigure(configuration);
					configuration.Configure(nhConfigFilePath);
					DoAfterConfigure(configuration);
					result.Add(configuration);
				}
			}
			return result.ToArray();
		}

		private void DoAfterConfigure(Configuration cfg)
		{
			if (AfterConfigure != null)
			{
				AfterConfigure(this, new ConfigurationEventArgs(cfg));
			}
		}

		private void DoBeforeConfigure(Configuration cfg)
		{
			if (BeforeConfigure != null)
			{
				BeforeConfigure(this, new ConfigurationEventArgs(cfg));
			}
		}

	}
}