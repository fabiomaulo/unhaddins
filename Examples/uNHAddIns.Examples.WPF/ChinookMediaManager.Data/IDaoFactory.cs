namespace ChinookMediaManager.Data
{
    public interface IDaoFactory
    {
        IDaoReadOnly<TEntity> GetDaoReadOnlyOf<TEntity>();
        IDao<TEntity> GetDaoOf<TEntity>();
        TDao GetSpecializedDao<TDao, TEntity>() where TDao : class, IDao<TEntity>; 
    }
}