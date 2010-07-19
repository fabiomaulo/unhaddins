namespace ChinookMediaManager.Data
{
    public interface IDao<T> : IDaoReadOnly<T>
    {
        T MakePersistent(T entity);
        void MakeTransient(T entity);
    }
}