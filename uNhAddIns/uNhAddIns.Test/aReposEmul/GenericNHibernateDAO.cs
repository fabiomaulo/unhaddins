using System.Collections.Generic;
using NHibernate;
using uNhAddIns.GenericImpl;
using uNhAddIns.NH;
using uNhAddIns.NH.Expression;
using uNhAddIns.Pagination;

namespace uNhAddIns.Test.aReposEmul
{
	// This implementation is similar to the implementation of 
	// NHibernate in Action book.
	// In your own implementation, you don't need a constructor because you can use a
	// static class like "NHibernateHelper" that provide you the session.
	// Ours tests really don't need this class and it is present only to have a more closer example
	// to your reality.
	// Surfing on the NET you can find many others examples of GenericNHibernateDAO implementation;
	// Provide one is not the target of uNhAddIns. Make your choice like you want.
	public class GenericNHibernateDAO<T, TId>
	{
		private readonly TestCase workingTest;
		public GenericNHibernateDAO(TestCase workingTest)
		{
			this.workingTest = workingTest;
		}

		private ISession session;
		public ISession Session
		{
			get
			{
				if (session == null)
					session = workingTest.LastOpenedSession; // NHibernateHelper.GetCurrentSession();
				return session;
			}
			set
			{
				session = value;
			}
		}

		public T FindById(TId id)
		{
			return Session.Load<T>(id);
		}

		public T FindByIdAndLock(TId id)
		{
			return Session.Load<T>(id, LockMode.Upgrade);
		}

		public IList<T> FindAll()
		{
			return Session.CreateCriteria(typeof(T)).List<T>();
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

		public IList<T> Find(DetachedCriteria criteria)
		{
			return criteria.GetExecutableCriteria(Session).List<T>();
		}

		public IList<T> Find(IDetachedQuery query)
		{
			return query.GetExecutableQuery(Session).List<T>();
		}

		public T FindUnique(DetachedCriteria criteria)
		{
			return criteria.GetExecutableCriteria(Session).UniqueResult<T>();
		}

		public T FindUnique(IDetachedQuery query)
		{
			return query.GetExecutableQuery(Session).UniqueResult<T>();
		}

		public virtual IPaginable<T> GetPaginable(DetachedCriteria criteria)
		{
			return new PaginableCriteria<T>(Session, criteria);
		}

		public virtual IPaginable<T> GetPaginable(IDetachedQuery query)
		{
			return new PaginableQuery<T>(Session, query);
		}
	}
}
