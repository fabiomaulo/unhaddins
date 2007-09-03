using System;
using NHibernate;
using uNhAddIns.NH;
using uNhAddIns.NH.Impl;
using uNhAddIns.Pagination;

namespace uNhAddIns.Test.aReposEmul
{
	public class GenericPaginableRowsCounterQueryDAO<T> : PaginableRowsCounterQuery<T>
	{
		private readonly TestCase workingTest;
		private readonly DetachedQuery detachedQuery;
		public GenericPaginableRowsCounterQueryDAO(TestCase workingTest, DetachedQuery detachedQuery)
		{
			if (detachedQuery == null)
			{
				throw new ArgumentNullException("detachedQuery");
			}
			this.workingTest = workingTest;
			this.detachedQuery = detachedQuery;
		}

		protected override IDetachedQuery DetachedQuery
		{
			get { return detachedQuery; }
		}

		public override ISession GetSession()
		{
			return workingTest.LastOpenedSession;
		}

		protected override IDetachedQuery GetRowCountQuery()
		{
			if (!detachedQuery.Hql.StartsWith("from", StringComparison.InvariantCultureIgnoreCase))
				throw new HibernateException(string.Format("Can't trasform the HQL to it's counter, the query must start with 'from' clause:{0}", detachedQuery.Hql));
			DetachedQuery result = new DetachedQuery("select count(*) " + detachedQuery.Hql);
			result.CopyParametersFrom(detachedQuery);
			return result;
		}
	}
}