using System;
using System.Collections.Generic;
using NHibernate.Cfg;
using NHibernate.Util;

namespace uNhAddIns.SessionEasier
{
	public class DefaultSessionFactoryConfigurationProvider : IConfigurationProvider
	{
		#region Implementation of IConfigurationProvider

		public IEnumerable<Configuration> Configure()
		{
			var cfg = new Configuration();
			DoBeforeConfigure(cfg);
			cfg.Configure();
			DoAfterConfigure(cfg);
			return new SingletonEnumerable<Configuration>(cfg);
		}

		public event EventHandler<ConfigurationEventArgs> BeforeConfigure;
		public event EventHandler<ConfigurationEventArgs> AfterConfigure;

		#endregion

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