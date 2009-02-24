using System;
using System.Collections.Generic;
using NHibernate.Cfg;

namespace uNhAddIns.SessionEasier
{
	public interface IConfigurationProvider
	{
		IEnumerable<Configuration> Configure();
		event EventHandler<ConfigurationEventArgs> BeforeConfigure;
		event EventHandler<ConfigurationEventArgs> AfterConfigure;
	}
}