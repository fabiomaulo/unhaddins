using System;
using NHibernate.Cfg;

namespace uNhAddIns.SessionEasier
{
	public class ConfigurationEventArgs: EventArgs
	{
		public ConfigurationEventArgs(Configuration configuration)
		{
			Configuration = configuration;
		}

		public Configuration Configuration { get; private set; }
	}
}