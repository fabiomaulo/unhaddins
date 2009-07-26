using System.Collections;
using System.Collections.Generic;
using ChinookMediaManager.Data.Repositories;
using NHibernate;
using NHibernate.Linq;

namespace ChinookMediaManager.Data.Impl.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        private readonly ISessionFactory _factory;

        public Repository(ISessionFactory factory)
        {
            _factory = factory;
        }


        protected ISession Session
        {
            get { return _factory.GetCurrentSession(); }
        }

        #region IRepository<T> Members

        public T Get(object id)
        {
            return Session.Get<T>(id);
        }

        public T Load(object id)
        {
            return Session.Load<T>(id);
        }

        public T MakePersistent(T entity)
        {
            Session.SaveOrUpdate(entity);
            return entity;
        }

        public void MakeTransient(T entity)
        {
            Session.Delete(entity);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Session.Linq<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Session.Linq<T>().GetEnumerator();
        }

        #endregion
    }
}