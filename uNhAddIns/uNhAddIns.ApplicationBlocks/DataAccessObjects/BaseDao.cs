using uNhAddIns.ApplicationBlocks.DataAccessObjects.TypeIdentifier;
using uNhAddIns.SessionEasier;

namespace uNhAddIns.ApplicationBlocks.DataAccessObjects {
    public class BaseDao<TEntity> : BaseDaoWithTypeId<TEntity, int> {
        protected BaseDao(ISessionFactoryProvider sessionFactoryProvider) : base(sessionFactoryProvider) {
        }
    }
}