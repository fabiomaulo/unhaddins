﻿using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Expression;
using uNhAddIns.GenericImpl;
using uNhAddIns.NH;
using uNhAddIns.NH.Impl;
using uNhAddIns.Pagination;

namespace Data
{
    public abstract class AbstractNHibernateDao<T, IdT>
    {
        /// <summary>
        /// Loads an instance of type TypeOfListItem from the DB based on its ID.
        /// </summary>
        public T GetById(IdT id, bool shouldLock)
        {
            T entity;

            if (shouldLock)
            {
                entity = (T)NHibernateSession.Load(persitentType, id, LockMode.Upgrade);
            }
            else
            {
                entity = (T)NHibernateSession.Load(persitentType, id);
            }

            return entity;
        }

        /// <summary>
        /// Loads every instance of the requested type with no filtering.
        /// </summary>
        public List<T> GetAll()
        {
            return GetByCriteria();
        }

        /// <summary>
        /// Loads every instance of the requested type using the supplied <see cref="ICriterion" />.
        /// If no <see cref="ICriterion" /> is supplied, this behaves like <see cref="GetAll" />.
        /// </summary>
        public List<T> GetByCriteria(params ICriterion[] criterion)
        {
            ICriteria criteria = NHibernateSession.CreateCriteria(persitentType);

            foreach (ICriterion criterium in criterion)
            {
                criteria.Add(criterium);
            }

            return criteria.List<T>() as List<T>;
        }

        public List<T> GetByExample(T exampleInstance, params string[] propertiesToExclude)
        {
            ICriteria criteria = NHibernateSession.CreateCriteria(persitentType);
            Example example = Example.Create(exampleInstance);

            foreach (string propertyToExclude in propertiesToExclude)
            {
                example.ExcludeProperty(propertyToExclude);
            }

            criteria.Add(example);

            return criteria.List<T>() as List<T>;
        }

        /// <summary>
        /// Looks for a single instance using the example provided.
        /// </summary>
        /// <exception cref="NonUniqueResultException" />
        public T GetUniqueByExample(T exampleInstance, params string[] propertiesToExclude)
        {
            List<T> foundList = GetByExample(exampleInstance, propertiesToExclude);

            if (foundList.Count > 1)
            {
                throw new NonUniqueResultException(foundList.Count);
            }

            if (foundList.Count > 0)
            {
                return foundList[0];
            }
            else
            {
                return default(T);
            }
        }

        public IList<T> GetBy(DetachedQuery detachedQuery)
        {
            return detachedQuery.GetExecutableQuery(NHibernateSession).List<T>();

        }

        public T GetUniqueBy(DetachedQuery detachedQuery)
        {
            return (T)detachedQuery.GetExecutableQuery(NHibernateSession).UniqueResult();
        }

        public Paginator<T> GetPaginator(IDetachedQuery detachedQuery)
        {
            IPaginable<T> paginable = GetPaginable<T>(detachedQuery);

            Paginator<T> ptor = new Paginator<T>(
                10,
                paginable,
                GetRowCounter(detachedQuery));

            return ptor;
        }

        public IRowsCounter GetRowCounter(IDetachedQuery dq)
        {
            IRowsCounter counter = QueryRowsCounter.Transforming((DetachedQuery)dq);

            return counter;
        }

        public IPaginable<T> GetPaginable<T>(IDetachedQuery query)
        {
            return new PaginableQuery<T>(NHibernateSession, query);
        }

        /// <summary>
        /// For entities that have assigned ID's, you must explicitly call Save to add a new one.
        /// See http://www.hibernate.org/hib_docs/reference/en/html/mapping.html#mapping-declaration-id-assigned.
        /// </summary>
        public T Save(T entity)
        {
            NHibernateSession.Save(entity);
            return entity;
        }

        /// <summary>
        /// For entities with automatatically generated IDs, such as identity, SaveOrUpdate may 
        /// be called when saving a new entity.  SaveOrUpdate can also be called to update any 
        /// entity, even if its ID is assigned.
        /// </summary>
        public T SaveOrUpdate(T entity)
        {
            NHibernateSession.SaveOrUpdate(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            NHibernateSession.Delete(entity);
        }

        /// <summary>
        /// Commits changes regardless of whether there's an open transaction or not
        /// </summary>
        public void CommitChanges()
        {
            if (NHibernateSessionManager.Instance.HasOpenTransaction())
            {
                NHibernateSessionManager.Instance.CommitTransaction();
            }
            else
            {
                // If there's no transaction, just flush the changes
                NHibernateSessionManager.Instance.GetSession().Flush();
            }
        }

        /// <summary>
        /// Exposes the ISession used within the DAO.
        /// </summary>
        private ISession NHibernateSession
        {
            get
            {
                return NHibernateSessionManager.Instance.GetSession();
            }
        }

        private Type persitentType = typeof(T);
    }
}

