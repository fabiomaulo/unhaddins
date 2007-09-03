using System;
using NHibernate;
using uNhAddIns.NH;
using uNhAddIns.Pagination;

namespace uNhAddIns.Test.aReposEmul
{
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