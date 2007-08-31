using System;
using NHibernate;
using uNhAddIns.NH;
using uNhAddIns.Pagination;

namespace uNhAddIns.Test.Pagination
{
	// You can take this class like an Example about how use PaginableRowsCounterQuery to create
	// your own GenericPaginableDAO (if you use a GenericNHDAO for example).
	// The DAO is the candidate place of because is where you have available the NH.Session 
	// (some times from the classic NHibernateHelpers)
	//
	// Only for test, we use the TestCase like a session provider, 
	// but you can take the session where you want.
	//
	public class GenericPaginableDAO<T>: AbstractPaginableQuery<T> 
	{
		private readonly TestCase workingTest;
		private readonly IDetachedQuery detachedQuery;
		public GenericPaginableDAO(TestCase workingTest, IDetachedQuery detachedQuery)
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
	}
}
