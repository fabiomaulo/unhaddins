using System;
using NHibernate;
using uNhAddIns.Entities;

namespace uNhAddIns.DataAccessObjects.Impl {
	public class GenericDao<TIdentity, TEntity> : IGenericDao<TIdentity, TEntity> where TEntity : IGenericEntity<TIdentity> {
		readonly ISessionFactory factory;

		public GenericDao(ISessionFactory factory) {
			if (factory == null) {
				throw new ArgumentNullException("factory");
			}
			this.factory = factory;
		}

		protected ISession GetSession() {
			return factory.GetCurrentSession();
		}

		public TEntity Get(TIdentity id) {
			var session = GetSession();
			return session.Get<TEntity>(id);
		}

		public TEntity GetProxy(TIdentity id) {
			var session = GetSession();
			return session.Load<TEntity>(id);
		}

		public TEntity Refresh(TEntity entity) {
			var session = GetSession();
			session.Refresh(entity);
			return entity;
		}
	}
}
