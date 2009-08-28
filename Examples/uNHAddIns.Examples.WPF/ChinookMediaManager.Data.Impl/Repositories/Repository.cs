using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ChinookMediaManager.Data.Repositories;
using NHibernate;
using NHibernate.Linq;
using uNhAddIns.Entities;

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
            Session.Persist(entity);
            return entity;
        }

        public void Refresh(T entity)
        {
            if ((entity is Entity) 
                && (entity as Entity).Id == 0)
                return;

            var id = Session.GetIdentifier(entity);
            Session.Evict(entity);
            Session.Load(entity, id);
        }

        public void MakeTransient(T entity)
        {
            Session.Delete(entity);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return GetLinq().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetLinq().GetEnumerator();
        }

        public Expression Expression
        {
            get { return GetLinq().Expression; }
        }

        public Type ElementType
        {
            get { return GetLinq().ElementType; }
        }

        public IQueryProvider Provider
        {
            get { return GetLinq().Provider; }
        }

        #endregion

        private INHibernateQueryable<T> GetLinq()
        {
            return Session.Linq<T>();
        }
    }
}