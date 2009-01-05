using System;
using System.Collections;
using System.Collections.Generic;
using log4net;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Util;

namespace uNhAddIns.SessionEasier
{
	[Serializable]
	public class SessionFactoryProvider : ISessionFactoryProvider
	{
		private static readonly ILog log = LogManager.GetLogger(typeof (SessionFactoryProvider));

		private IEnumerable<ISessionFactory> esf;
		private ISessionFactory sf;

		#region ISessionFactoryProvider Members

		public ISessionFactory GetFactory(string factoryId)
		{
			Initialize();
			return sf;
		}

		#endregion

		public event EventHandler<ConfigurationEventArgs> BeforeConfigure;
		public event EventHandler<ConfigurationEventArgs> AfterConfigure;

		public void Initialize()
		{
			if (sf == null)
			{
				log.Debug("Initialize a new session factory reading the configuration.");
				var cfg = new Configuration();
				DoBeforeConfigure(cfg);
				cfg.Configure();
				DoAfterConfigure(cfg);
				sf = cfg.BuildSessionFactory();
				esf = new SingletonEnumerable<ISessionFactory>(sf);
			}
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

		#region Implementation of IEnumerable

		public IEnumerator<ISessionFactory> GetEnumerator()
		{
			Initialize();
			return esf.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#endregion

		#region Implementation of IDisposable

		public void Dispose()
		{
			if (sf != null)
			{
				sf.Close();
				sf = null;
			}
		}

		#endregion
	}
}