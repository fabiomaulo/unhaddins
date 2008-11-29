using System;
using System.Collections;
using System.Collections.Generic;
using log4net;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Engine;

namespace uNhAddIns.SessionEasier
{
	[Serializable]
	public class MultiSessionFactoryProvider : ISessionFactoryProvider
	{
		private static readonly ILog log = LogManager.GetLogger(typeof (MultiSessionFactoryProvider));

		[NonSerialized] private readonly IMultiFactoryConfigurator mfc;
		private string defaultSessionFactoryName;
		private Dictionary<string, ISessionFactory> sfs = new Dictionary<string, ISessionFactory>(4);

		public MultiSessionFactoryProvider() : this(new DefaultMultiFactoryConfigurator()) {}

		public MultiSessionFactoryProvider(IMultiFactoryConfigurator multiFactoryConfigurator)
		{
			if (multiFactoryConfigurator == null)
			{
				throw new ArgumentNullException("multiFactoryConfigurator");
			}
			mfc = multiFactoryConfigurator;
		}

		#region Implementation of IInitializable

		public void Initialize()
		{
			if (sfs.Count != 0)
			{
				return;
			}
			log.Debug("Initialize new session factories reading the configuration.");
			foreach (Configuration cfg in mfc.Configure())
			{
				var sf = (ISessionFactoryImplementor) cfg.BuildSessionFactory();
				if (string.IsNullOrEmpty(defaultSessionFactoryName))
				{
					defaultSessionFactoryName = sf.Settings.SessionFactoryName.Trim();
				}
				sfs.Add(sf.Settings.SessionFactoryName.Trim(), sf);
			}
		}

		#endregion

		#region Implementation of IDisposable

		public void Dispose()
		{
			foreach (ISessionFactory sessionFactory in sfs.Values)
			{
				if (sessionFactory != null)
				{
					sessionFactory.Close();
				}
			}
			sfs = new Dictionary<string, ISessionFactory>(4);
		}

		#endregion

		#region ISessionFactoryProvider Members

		public ISessionFactory GetFactory(string factoryId)
		{
			Initialize();
			return string.IsNullOrEmpty(factoryId)
			       	? InternalGetFactory(defaultSessionFactoryName)
			       	: InternalGetFactory(factoryId);
		}

		#endregion

		private ISessionFactory InternalGetFactory(string factoryId)
		{
			try
			{
				return sfs[factoryId];
			}
			catch (KeyNotFoundException)
			{
				throw new ArgumentException("The session-factory-id was not register", "factoryId");
			}
			catch (ArgumentNullException)
			{
				throw new ArgumentException("The session-factory-id was not register; do you forgot the appSettings section ?");
			}
		}

		#region Implementation of IEnumerable

		public IEnumerator<ISessionFactory> GetEnumerator()
		{
			Initialize();
			return sfs.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#endregion
	}
}