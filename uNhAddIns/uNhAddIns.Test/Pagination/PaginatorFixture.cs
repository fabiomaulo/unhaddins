using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Impl;
using NUnit.Framework;
using uNhAddIns.GenericImpl;
using uNhAddIns.Pagination;

namespace uNhAddIns.Test.Pagination
{
	[TestFixture]
	public class PaginatorFixture : PaginationTestBase
	{
		[Test]
		public void SimplePaginator()
		{
			using (ISession session = SessionFactory.OpenSession())
			{
				// with "AutoCalcPages mode" DISABLED
				var ptor = new Paginator<Foo>(3, new PaginableQuery<Foo>(session, new DetachedQuery("from Foo")));
				// check init state
				Assert.AreEqual(1, ptor.FirstPageNumber);
				Assert.IsFalse(ptor.LastPageNumber.HasValue);
				Assert.IsFalse(ptor.CurrentPageNumber.HasValue);
				Assert.IsTrue(ptor.HasNext);
				Assert.IsFalse(ptor.HasPrevious);
				IList<Foo> lpage = ptor.GetFirstPage();
				Assert.AreEqual(3, lpage.Count);
				Assert.AreEqual(1, ptor.CurrentPageNumber);
				// check lastPage sill unavailable
				Assert.IsFalse(ptor.LastPageNumber.HasValue);
			}
		}

		[Test]
		public void AutoCalcPages()
		{
			using (ISession session = SessionFactory.OpenSession())
			{
				var ptor = new Paginator<Foo>(3, new PaginableQuery<Foo>(session, new DetachedQuery("from Foo")), true);
				// check init state
				Assert.AreEqual(1, ptor.FirstPageNumber);
				Assert.AreEqual(5, ptor.LastPageNumber);
				Assert.AreEqual(1, ptor.CurrentPageNumber);
				Assert.IsTrue(ptor.HasNext);
				Assert.IsFalse(ptor.HasPrevious);
				IList<Foo> lpage = ptor.GetLastPage();
				Assert.AreEqual(3, lpage.Count);
				Assert.AreEqual(5, ptor.CurrentPageNumber);
				Assert.IsFalse(ptor.HasNext);
				Assert.IsTrue(ptor.HasPrevious);

				// Partial last page
				ptor = new Paginator<Foo>(10, new PaginableQuery<Foo>(session, new DetachedQuery("from Foo")), true);
				Assert.AreEqual(2, ptor.LastPageNumber);
			}
		}

		[Test]
		public void WithCounter()
		{
			using (ISession session = SessionFactory.OpenSession())
			{
				var ptor = new Paginator<Foo>(5, new PaginableQuery<Foo>(session, new DetachedQuery("from Foo")),
				                              new NamedQueryRowsCounter("Foo.Count.All"));
				Assert.AreEqual(3, ptor.LastPageNumber);
			}
		}

		[Test]
		public void WithSelfCounter()
		{
			var dq = new DetachedQuery("from Foo f where f.Name like :p1");
			dq.SetString("p1", "%1_");
			using (ISession session = SessionFactory.OpenSession())
			{
				IPaginable<Foo> fp = new PaginableRowsCounterQuery<Foo>(session, dq);

				var ptor = new Paginator<Foo>(2, fp);
				Assert.IsTrue(ptor.AutoCalcPages);
				Assert.AreEqual(3, ptor.LastPageNumber);
				// check page 2
				IList<Foo> lpage = ptor.GetPage(2);
				Assert.AreEqual(2, lpage.Count);
				Assert.AreEqual(2, ptor.CurrentPageNumber);
				Assert.AreEqual("N12", lpage[0].Name);
				Assert.AreEqual("N13", lpage[1].Name);
			}
		}

		[Test]
		public void HasNotPages()
		{
			const string hql = "from Foo where Name = '-N123'";
			using (ISession session = SessionFactory.OpenSession())
			{
				var pag = new PaginableRowsCounterQuery<Foo>(session, new DetachedQuery(hql));
				var ptor = new Paginator<Foo>(3, pag);

				Assert.AreEqual(false, ptor.HasPages);
				Assert.AreEqual(false, ptor.HasPrevious);
				Assert.AreEqual(false, ptor.HasNext);
				Assert.AreEqual(0, ptor.RowsCount.Value);

				//throw ArgumentOutOfRangeException
				Assert.Throws<ArgumentOutOfRangeException>(() => ptor.GetPage(1));
			}
		}

		[Test]
		public void HasPages()
		{
			const string hql = "from Foo where Name = 'N1'";
			using (ISession session = SessionFactory.OpenSession())
			{
				var pag = new PaginableRowsCounterQuery<Foo>(session, new DetachedQuery(hql));
				var ptor = new Paginator<Foo>(3, pag);

				Assert.AreEqual(true, ptor.HasPages);
				Assert.AreEqual(1, ptor.RowsCount);
				Assert.AreEqual(false, ptor.HasPrevious);
				Assert.AreEqual(false, ptor.HasNext);

				IList<Foo> lpage = ptor.GetPage(1);
				Assert.AreEqual(1, lpage.Count);
			}
		}
	}
}