using NHibernate.Impl;
using NUnit.Framework;
using uNhAddIns.Pagination;

namespace uNhAddIns.Test.Pagination
{
	[TestFixture]
	public class NamedQueryRowsCounterFixture : PaginationTestBase
	{
		[Test]
		public void RowsCount()
		{
			IRowsCounter rc = new NamedQueryRowsCounter("Foo.Count.All");
			EnclosingInTransaction(s => Assert.That(rc.GetRowsCount(s), Is.EqualTo(TotalFoo)));
		}

		[Test]
		public void RowsCountUsingParameters()
		{
			var q = new DetachedNamedQuery("Foo.Count.Parameters");
			q.SetString("p1", "%1_");
			IRowsCounter rc = new NamedQueryRowsCounter(q);
			EnclosingInTransaction(s => Assert.That(rc.GetRowsCount(s), Is.EqualTo(5)));
		}
	}
}