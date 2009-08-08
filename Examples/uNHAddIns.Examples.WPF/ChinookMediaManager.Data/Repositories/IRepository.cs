using System.Linq;

namespace ChinookMediaManager.Data.Repositories
{
    public interface IRepository<T> : IQueryable<T>
    {
        T Get(object id);
        T Load(object id);
        T MakePersistent(T entity);
        void Refresh(T entity);
        void MakeTransient(T entity);
    }
}