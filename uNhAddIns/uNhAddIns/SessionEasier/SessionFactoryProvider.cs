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
		private static readonly ILog log = LogManager.GetLogger(typeof(SessionFactoryProvider));

		private ISessionFactory sf;
		private IEnumerable<ISessionFactory> esf;
		#region Implementation of IDisposable

		public void Dispose()
		{
			if (sf != null)
			{
				sf.Close();
				sf = null;
			}
		}

		public ISessionFactory GetFactory(string factoryId)
		{
			Initialize();
			return sf;
		}

		#endregion

		#region Implementation of IInitializable

		public void Initialize()
		{
			if (sf == null)
			{
				log.Debug("Initialize a new session factory reading the configuration.");
				Configuration cfg = new Configuration().Configure();
				sf = cfg.BuildSessionFactory();
				esf = new SingletonEnumerable<ISessionFactory>(sf);
			}
		}

		#endregion

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
	}
}