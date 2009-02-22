using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using NUnit.Framework;
using uNhAddIns.GenericImpl;
using uNhAddIns.Pagination;

namespace uNhAddIns.Test.Pagination
{
	[TestFixture]
	public class PaginableCriteriaFixture : IntegrationTest
	{
		public const int totalFoo = 15;

		protected static void FillDb(ISession s)
		{
			for (int i = 0; i < totalFoo; i++)
			{
				var f = new Foo("N" + i, "D" + i);
				s.Save(f);
			}
		}

		protected static void DbCleanup(ISession s)
		{
			s.Delete("from Foo");
		}

		[Test]
		public void NullArgumentNotAllowed()
		{
			Assert.Throws<ArgumentNullException>(() => new PaginableCriteria<Foo>(null, DetachedCriteria.For<Foo>()));
			using (ISession s = SessionFactory.OpenSession())
			{
				Assert.Throws<ArgumentNullException>(() => new PaginableCriteria<Foo>(s, null));
			}
		}

		[Test]
		public void ListAllTest()
		{
			EnclosingInTransaction(FillDb);
			using (ISession session = SessionFactory.OpenSession())
			{
				DetachedCriteria dc = DetachedCriteria.For<Foo>();
				IPaginable<Foo> pg = new PaginableCriteria<Foo>(session, dc);
				IList<Foo> l = pg.ListAll();
				Assert.AreEqual(15, l.Count);
			}
			EnclosingInTransaction(DbCleanup);
		}

		[Test]
		public void GetPageTest()
		{
			EnclosingInTransaction(FillDb);
			// Page count start from 1
			using (ISession session = SessionFactory.OpenSession())
			{
				DetachedCriteria dc = DetachedCriteria.For<Foo>();
				IPaginable<Foo> pg = new PaginableCriteria<Foo>(session, dc);
				IList<Foo> l = pg.GetPage(3, 2);
				Assert.AreEqual(3, l.Count);
				Assert.AreEqual("N3", l[0].Name);
				Assert.AreEqual("N4", l[1].Name);
				Assert.AreEqual("N5", l[2].Name);

				l = pg.GetPage(2, 1);
				Assert.AreEqual(2, l.Count);
				Assert.AreEqual("N0", l[0].Name);
				Assert.AreEqual("N1", l[1].Name);

				// If pageSize=10 the page 2 have 5 elements
				l = pg.GetPage(10, 2);
				Assert.AreEqual(5, l.Count);
			}

			// Add an element from other session
			var fAdded = new Foo("NZ", "DZ");
			EnclosingInTransaction(s => s.Save(fAdded));

			// Reload the same page and have the new element
			using (ISession session = SessionFactory.OpenSession())
			{
				DetachedCriteria dc = DetachedCriteria.For<Foo>();
				IPaginable<Foo> pg = new PaginableCriteria<Foo>(session, dc);
				IList<Foo> l = pg.GetPage(10, 2);
				// If pageSize=10 the page 2 have 6 elements
				Assert.AreEqual(6, l.Count);
			}

			EnclosingInTransaction(DbCleanup);
		}

		[Test]
		public void PaginableRowsCount()
		{
			EnclosingInTransaction(FillDb);

			DetachedCriteria dc = DetachedCriteria.For<Foo>().Add(Restrictions.Like("Name", "N_"));

			using (ISession session = SessionFactory.OpenSession())
			{
				var fp = new PaginableCriteria<Foo>(session, dc);
				IList<Foo> l = fp.GetPage(5, 1);
				Assert.AreEqual(5, l.Count);
				Assert.AreEqual(10, fp.GetRowsCount(session));
			}

			EnclosingInTransaction(DbCleanup);
		}
	}
}