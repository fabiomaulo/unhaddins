namespace uNhAddIns.ApplicationBlocks.DataAccessObjects.TypeIdentifier {
    public interface IDaoWithTypeId<TEntity, TIdentifier> {
        TEntity Get(TIdentifier id);
    }
}