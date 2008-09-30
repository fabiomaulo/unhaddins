using System;
using NHibernate;
using System.Collections.Generic;

namespace uNhAddIns.SessionEasier
{
	public class SessionFactoryManager
	{
		private readonly ISessionFactoryProvider sfProvider;

		public SessionFactoryManager(ISessionFactoryProvider sfProvider)
		{
			if (sfProvider == null)
			{
				throw new ArgumentNullException("sfProvider");
			}
			this.sfProvider = sfProvider;
		}

		public ISessionFactory Default
		{
			get { return GetSessionFactory(null); }
		}

		public ISessionFactory GetSessionFactory(string factoryId)
		{
			return sfProvider.GetFactory(factoryId);
		}

		public IEnumerable<ISessionFactory> GetFactories()
		{
			return sfProvider;
		}

		public void Shutdown()
		{
			sfProvider.Dispose();
		}
	}
}