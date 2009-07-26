using System.Collections.Generic;

namespace ChinookMediaManager.Data.Repositories
{
    public interface IRepository<T> : IEnumerable<T>
    {
        T Get(object id);
        T Load(object id);
        T MakePersistent(T entity);
        void MakeTransient(T entity);
    }
}