namespace uNhAddIns.ApplicationBlocks.DataAccessObjects.TypeIdentifier {
    public interface ICrudDaoWithTypeId<TEntity, TIdentifier> : IDaoWithTypeId<TEntity, TIdentifier> {
        TEntity MakePersistent(TEntity entity);
        void MakeTransient(TEntity entity);
    }
}