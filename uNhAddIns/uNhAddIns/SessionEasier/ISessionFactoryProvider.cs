using System;
using Castle.Core;
using NHibernate;
using System.Collections.Generic;

namespace uNhAddIns.SessionEasier
{
	public interface ISessionFactoryProvider : IInitializable, IEnumerable<ISessionFactory>, IDisposable
	{
		ISessionFactory GetFactory(string factoryId);
	}
}