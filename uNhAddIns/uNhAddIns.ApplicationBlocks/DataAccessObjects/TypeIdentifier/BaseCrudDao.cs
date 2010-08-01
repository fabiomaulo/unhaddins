using uNhAddIns.SessionEasier;

namespace uNhAddIns.ApplicationBlocks.DataAccessObjects.TypeIdentifier {
    public class BaseCrudDaoWithTypeId<TEntity, TId> : BaseDaoWithTypeId<TEntity, TId> {
        protected BaseCrudDaoWithTypeId(ISessionFactoryProvider sessionFactoryProvider) : base(sessionFactoryProvider) {
        }

        public TEntity MakePersistent(TEntity entity) {
            GetSession().SaveOrUpdate(entity);
            return entity;
        }

        public void MakeTransient(TEntity entity) {
            GetSession().Delete(entity);
        }


    }
}