using uNhAddIns.ApplicationBlocks.DataAccessObjects.TypeIdentifier;
using uNhAddIns.SessionEasier;

namespace uNhAddIns.ApplicationBlocks.DataAccessObjects {
    public class BaseCrudDao<TEntity> : BaseCrudDaoWithTypeId<TEntity, int> {
        protected BaseCrudDao(ISessionFactoryProvider sessionFactoryProvider) : base(sessionFactoryProvider) {
        }
    }
}