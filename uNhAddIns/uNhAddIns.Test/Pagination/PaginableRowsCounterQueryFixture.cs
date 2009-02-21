using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Impl;
using NUnit.Framework;
using uNhAddIns.GenericImpl;
using uNhAddIns.Pagination;

namespace uNhAddIns.Test.Pagination
{
	[TestFixture]
	public class PaginableRowsCounterQueryFixture : TestCase
	{
		protected override IList Mappings
		{
			get { return new[] {"Pagination.PagTest.hbm.xml"}; }
		}

		public const int totalFoo = 15;

		private void CreateDomain()
		{
			using (ISession s = OpenSession())
			{
				using (ITransaction tx = s.BeginTransaction())
				{
					for (int i = 0; i < totalFoo; i++)
					{
						s.Save(new Foo("N" + i, "D" + i));
					}
					tx.Commit();
				}
			}
		}

		private void CleanupDomain()
		{
			using (ISession s = OpenSession())
			{
				using (ITransaction tx = s.BeginTransaction())
				{
					s.Delete("from Foo");
					tx.Commit();
				}
			}
		}

		[Test]
		public void Ctor()
		{
			using (ISession s = OpenSession())
			{
				Assert.Throws<ArgumentNullException>(() => new PaginableRowsCounterQuery<Foo>(s, null),
				                                     "Should not accept null query");
			}
			var dq = new DetachedQuery("from Foo f where f.Name like :p1");
			Assert.Throws<ArgumentNullException>(() => new PaginableRowsCounterQuery<Foo>(null, dq),
			                                     "Should not accept null session");
		}

		[Test]
		public void ShouldWorkAsPaginatorAndAsRowCounter()
		{
			CreateDomain();
			var dq = new DetachedQuery("from Foo f where f.Name like :p1");
			dq.SetString("p1", "N_");
			using (ISession s = OpenSession())
			{
				IPaginable<Foo> fp = new PaginableRowsCounterQuery<Foo>(s, dq);
				IList<Foo> l = fp.GetPage(5, 1);
				Assert.That(l.Count, Is.EqualTo(5));
				Assert.That(((IRowsCounter) fp).GetRowsCount(s), Is.EqualTo(10));
			}
			CleanupDomain();
		}

		[Test]
		public void ShouldNotTransformAUnsafeHQL()
		{
			var dq = new DetachedQuery("select f.Name from Foo f where f.Name like :p1");
			dq.SetString("p1", "N_");
			using (ISession s = OpenSession())
			{
				IPaginable<Foo> fp = new PaginableRowsCounterQuery<Foo>(s, dq);
				Assert.Throws<HibernateException>(() => ((IRowsCounter) fp).GetRowsCount(s),
				                                  "Should not transform a query with a select clause.");
			}
		}
	}
}