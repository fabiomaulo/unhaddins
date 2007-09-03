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

		protected override DetachedQuery GetQuery()
		{
			return detachedQuery;
		}

		protected override IDetachedQuery DetachedQuery
		{
			get { return GetQuery(); }
		}

		public override ISession GetSession()
		{
			return workingTest.LastOpenedSession;
		}
	}
}