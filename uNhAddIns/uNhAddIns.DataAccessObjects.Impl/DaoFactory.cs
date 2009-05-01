using System;
using Microsoft.Practices.ServiceLocation;

namespace uNhAddIns.DataAccessObjects.Impl {
	public class DaoFactory : IDaoFactory {

		public DaoFactory(IServiceLocator serviceLocator) {
			sc = serviceLocator;
		}

		private readonly IServiceLocator sc;

		public TDao GetDao<TDao>() where TDao : class {
			return sc.GetInstance<TDao>();
		}
	}
}