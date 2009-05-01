using System;
using NHibernate;
using uNhAddIns.Entities;

namespace uNhAddIns.DataAccessObjects.Impl {
	public class GenericCrudDao<TIdentity, TEntity> : GenericDao<TIdentity, TEntity>, IGenericCrudDao<TIdentity, TEntity> where TEntity : IGenericEntity<TIdentity> {
		public GenericCrudDao(ISessionFactory factory) : base(factory) {
		}

		public TEntity MakePersistent(TEntity entity) {
			var session = GetSession();
			session.SaveOrUpdate(entity);
			return entity;
		}

		public TEntity MakeTransient(TEntity entity) {
			var session = GetSession();
			session.Delete(entity);
			return entity;
		}

		public TEntity GetMerged(TEntity actualEntity) {
			throw new NotImplementedException();
		}
	}
}