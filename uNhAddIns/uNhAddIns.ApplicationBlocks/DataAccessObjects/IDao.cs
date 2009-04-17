using uNhAddIns.ApplicationBlocks.DataAccessObjects.TypeIdentifier;

namespace uNhAddIns.ApplicationBlocks.DataAccessObjects {
    public interface IDao<TEntity> : IDaoWithTypeId<TEntity, int> { }
}