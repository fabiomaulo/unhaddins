using System;
using NHibernate;
using NHibernate.Impl;
using NUnit.Framework;
using uNhAddIns.Pagination;

namespace uNhAddIns.Test.Pagination
{
	[TestFixture]
	public class QueryRowsCounterFixture : PaginationTestBase
	{
		[Test]
		public void CtorProtection()
		{
			string nothing=null;
			IDetachedQuery dq = null;
			Assert.Throws<ArgumentNullException>(() => new QueryRowsCounter(nothing));
			Assert.Throws<ArgumentNullException>(() => new QueryRowsCounter(dq));
		}

		[Test]
		public void RowsCount()
		{
			IRowsCounter rc = new QueryRowsCounter("select count(*) from Foo");
			
			EnclosingInTransaction(s => Assert.AreEqual(TotalFoo, rc.GetRowsCount(s)));
		}

		[Test]
		public void InvalidRowsCount()
		{
			IRowsCounter rc = new QueryRowsCounter("select f.Name from Foo f");
			EnclosingInTransaction(s => Assert.Throws<HibernateException>(()=> rc.GetRowsCount(s)));

			rc = new QueryRowsCounter("select f.Name from Foo f where f.Name='N1'");
			EnclosingInTransaction(s => Assert.Throws<HibernateException>(() => rc.GetRowsCount(s)));
		}

		[Test]
		public void RowsCountUsingParameters()
		{
			IDetachedQuery dq = 
				new DetachedQuery("select count(*) from Foo f where f.Name like :p1")
				.SetString("p1", "%1_");
			IRowsCounter rc = new QueryRowsCounter(dq);
			EnclosingInTransaction(s => Assert.AreEqual(5, rc.GetRowsCount(s)));
		}

		[Test]
		public void RowsCountTransforming()
		{
			Assert.Throws<ArgumentNullException>(() => QueryRowsCounter.Transforming(null));
		
			var originalQuery =new DetachedQuery("from Foo f where f.Name like :p1");
			originalQuery.SetString("p1", "%1_");
			
			IRowsCounter rc = QueryRowsCounter.Transforming(originalQuery);
			
			EnclosingInTransaction(s => Assert.AreEqual(5, rc.GetRowsCount(s)));
		}

		[Test]
		public void TransformingUnsafeQuery()
		{
			Assert.Throws<ArgumentNullException>(() => QueryRowsCounter.Transforming(new DetachedQuery("select f.Name from Foo f")));
		}

		[Test]
		public void TransformingShouldDelayingParameterCopy()
		{
			var originalQuery = new DetachedQuery("from Foo f where f.Name like :p1");
			IRowsCounter rc = QueryRowsCounter.Transforming(originalQuery);
			
			originalQuery.SetString("p1", "%1_");

			EnclosingInTransaction(s => Assert.AreEqual(5, rc.GetRowsCount(s)));
		}

	}
}
