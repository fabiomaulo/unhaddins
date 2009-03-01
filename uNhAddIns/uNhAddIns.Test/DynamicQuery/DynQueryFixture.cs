using System;
using NHibernate;
using NUnit.Framework;
using uNhAddIns.DynQuery;

namespace uNhAddIns.Test.DynamicQuery
{
	[TestFixture]
	public class DynQueryFixture
	{
		[Test]
		public void FromWithEmptySelect()
		{
			Assert.AreEqual("from Foo", new From("Foo").Clause);
		}

		[Test]
		public void LogicalExpressionTest()
		{
			IQueryPart le = new LogicalExpression("   a = b  ");
			Assert.AreEqual("(a = b)", le.Expression);
			Assert.AreEqual(le.Expression, le.Clause);
		}

		[Test]
		public void SimpleQuery()
		{
			From frm = new From("Foo f");
			frm.Where("f.Name like :p1").And("length(f.Name)>2").Or("f.Name like 'N%'");
			Assert.AreEqual("from Foo f where ((f.Name like :p1) and (length(f.Name)>2) or (f.Name like 'N%'))", frm.Clause);
		}

		[Test]
		public void WhereInjection()
		{
			// Create a where clause away of the from clause
			Where w = (new Where("f.Name like :p1")).And("length(f.Name)>2").Or("f.Name like 'N%'");
			From frm = new From("Foo f");
			frm.SetWhere(w);
			Assert.AreEqual("from Foo f where ((f.Name like :p1) and (length(f.Name)>2) or (f.Name like 'N%'))", frm.Clause);
		}

		[Test]
		public void DirtyWhereCostruction()
		{
			// This way, to construct the where clause, can be useful if 
			// you don't know which will be the first expression
			Where w = new Where();
			w.And("f.Name like :p1").And("length(f.Name)>2").Or("f.Name like 'N%'");
			Assert.AreEqual("where ((f.Name like :p1) and (length(f.Name)>2) or (f.Name like 'N%'))", w.Clause);

			w = new Where();
			w.Or("f.Name like :p1").And("length(f.Name)>2").Or("f.Name like 'N%'");
			Assert.AreEqual("where ((f.Name like :p1) and (length(f.Name)>2) or (f.Name like 'N%'))", w.Clause);
		}

		[Test]
		public void OrderByTest()
		{
			// OrderBy can be created away
			OrderBy o = new OrderBy().Add("f.Name").Add("f.Id", true).Add("f.Surname");
			Assert.AreEqual("f.Name, f.Id desc, f.Surname", o.Expression);
			Assert.AreEqual("order by f.Name, f.Id desc, f.Surname", o.Clause);
		}

		[Test]
		public void OrderByInjection()
		{
			// Inject the OrderBy to an existing "from clause"
			OrderBy o = new OrderBy()
				.Add("f.Name")
				.Add("f.Id", true);
			From frm = new From("Foo");
			frm.SetOrderBy(o);
			Assert.AreEqual("from Foo order by f.Name, f.Id desc", frm.Clause);
		}

		[Test]
		public void SelectTest()
		{
			Select s = new Select("f.Name, f.Description, b.Descriptoin").From("Foo f join f.Bar b");
			Assert.IsTrue(s.HasMembers);
			Assert.AreEqual("f.Name, f.Description, b.Descriptoin", s.Expression);
			Assert.AreEqual("select f.Name, f.Description, b.Descriptoin from Foo f join f.Bar b", s.Clause);
		}

		[Test]
		public void SelectWhereTest()
		{
			Select s = new Select("f.Name, f.Description, b.Descriptoin").From("Foo f join f.Bar b").Where("f.Name like :pName");
			Assert.AreEqual("f.Name, f.Description, b.Descriptoin", s.Expression);
			Assert.AreEqual("select f.Name, f.Description, b.Descriptoin from Foo f join f.Bar b where ((f.Name like :pName))", s.Clause);
		}

		[Test]
		public void CommonUse()
		{
			// some times the select can be static in son place (the service of a DAO)
			Select s = new Select("f.Name, f.Description, b.Descriptoin").From("Foo f join f.Bar b");

			// Create a new where by checking some contition
			Where where = new Where();

			// check something and set a condition of where clause
			where.And("f.Name like :pName");

			// check something else and set another condition of where clause
			where.And("b.Asociated > :pAso");

			// Inject the where to the select
			s.From().SetWhere(where);

			// Create a basic order by
			OrderBy order = new OrderBy().Add("b.Asociated", true);

			// Check some condition and add an order
			order.Add("f.Name");

			// Inject the OrderBy to the select
			s.From().SetOrderBy(order);
			s.From().OrderBy("b.Other");

			// And: The winner is....
			string expected = "select f.Name, f.Description, b.Descriptoin from Foo f join f.Bar b where ((f.Name like :pName) and (b.Asociated > :pAso)) order by b.Asociated desc, f.Name, b.Other";
			Assert.AreEqual(expected, s.Clause);
		}

		public class BlogPostCriteria
		{
			public int? BlogId { get; set; }
			public int? UserId { get; set; }
			public int? CategoryId { get; set; }
		}

		public class BlogPostQueryCreator
		{
			private readonly BlogPostCriteria bpc;
			public BlogPostQueryCreator(BlogPostCriteria criteria)
			{
				bpc = criteria;
			}

			private const string defaultAlias = "bp";
			public IDetachedQuery GetSelection()
			{
				var selection = new From("BlogPost " + defaultAlias);
				selection.OrderBy("bp.ID", true);

				return GetQueryWithConstraints(selection);
			}

			private IDetachedQuery GetQueryWithConstraints(From selection)
			{
				var result = new DetachedDynQuery(selection);
				InjectConstraintsTo(result);

				return result;
			}

			private IDetachedQuery GetQueryWithConstraints(Select selection)
			{
				var result = new DetachedDynQuery(selection);
				InjectConstraintsTo(result);

				return result;
			}

			public IDetachedQuery GetStatistic(string propertyPath)
			{
				string qualifyProperty = QualifyProperty(propertyPath);
				var selection = new Select(qualifyProperty + ", count(*)").From("BlogPost " + defaultAlias);
				selection.From().GroupBy(qualifyProperty).OrderBy(qualifyProperty);
				return GetQueryWithConstraints(selection);
			}

			public void InjectConstraintsTo(DetachedDynQuery ddq)
			{
				var from = ddq.Query;

				from.Where("bp.State.ID = 1");

				if (bpc.BlogId.HasValue)
				{
					from.Where().And(QualifyProperty("Blog.ID") + " = :BlogID");
					ddq.SetInt32("BlogID", bpc.BlogId.Value);
				}

				if (bpc.CategoryId.HasValue)
				{
					from.Join(QualifyProperty("Category") + " c");
					from.Where().And("c.ID = :CategoryID");
					ddq.SetInt32("CategoryID", bpc.CategoryId.Value);
				}

				if (bpc.UserId.HasValue)
				{
					from.Where().And(QualifyProperty("BlogUsuser.ID") + " = :UserID");
					ddq.SetInt32("UserID", bpc.UserId.Value);
				}
			}

			private static string QualifyProperty(string propertyPath)
			{
				return string.Concat(defaultAlias, ".", propertyPath);
			}
		}

		[Test]
		public void ExampleWithDetachedQuery()
		{
			var bpc = new BlogPostCriteria { BlogId = 1, CategoryId = 2, UserId = 3 };
			var queryCreator = new BlogPostQueryCreator(bpc);

			var ddq = (DetachedDynQuery)queryCreator.GetSelection();

			const string expected = "from BlogPost bp join bp.Category c where ((bp.State.ID = 1) and (bp.Blog.ID = :BlogID) and (c.ID = :CategoryID) and (bp.BlogUsuser.ID = :UserID)) order by bp.ID desc";
			Assert.That(ddq.Hql, Is.EqualTo(expected));
		}

		[Test]
		public void ExampleForStatistics()
		{
			var bpc = new BlogPostCriteria { UserId = 3 };
			var queryCreator = new BlogPostQueryCreator(bpc);
			var ddq = (DetachedDynQuery)queryCreator.GetStatistic("Category.Name");

			string expected = "select bp.Category.Name, count(*) from BlogPost bp where ((bp.State.ID = 1) and (bp.BlogUsuser.ID = :UserID)) group by bp.Category.Name order by bp.Category.Name";
			Assert.That(ddq.Hql, Is.EqualTo(expected));

			bpc = new BlogPostCriteria();
			queryCreator = new BlogPostQueryCreator(bpc);
			ddq = (DetachedDynQuery)queryCreator.GetStatistic("BlogUsuser.Name");

			expected = "select bp.BlogUsuser.Name, count(*) from BlogPost bp where ((bp.State.ID = 1)) group by bp.BlogUsuser.Name order by bp.BlogUsuser.Name";
			Assert.That(ddq.Hql, Is.EqualTo(expected));

			bpc = new BlogPostCriteria { CategoryId = 11 };
			queryCreator = new BlogPostQueryCreator(bpc);
			ddq = (DetachedDynQuery)queryCreator.GetStatistic("BlogUsuser.Name");

			expected = "select bp.BlogUsuser.Name, count(*) from BlogPost bp join bp.Category c where ((bp.State.ID = 1) and (c.ID = :CategoryID)) group by bp.BlogUsuser.Name order by bp.BlogUsuser.Name";
			Assert.That(ddq.Hql, Is.EqualTo(expected));
		}

		[Test]
		public void DifferentLogicalExpressions()
		{
			Where simple = new Where().Not("a = 1");
			Assert.AreEqual("where (not (a = 1))", simple.Clause);

			Where full = new Where().And("a = 1").Or("b = 2").Not("c = 3");
			Assert.AreEqual("where ((a = 1) or (b = 2) and not (c = 3))", full.Clause);
		}

		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void GroupByFailsSettingOrderWithoutFrom()
		{
			new GroupBy().OrderBy("Name", true);
		}

		[Test]
		public void GroupByOrdersAfterHavingFrom()
		{
			GroupBy groupBy = new GroupBy();

			From from = new From("Foo");
			from.SetGroupBy(groupBy);

			groupBy.OrderBy("Name", true);

			Assert.AreEqual("from Foo order by Name desc", from.Clause);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void FailsIfGroupingByNothing()
		{
			new GroupBy().Add(" ");
		}

		[Test]
		[ExpectedException(typeof(NotSupportedException))]
		public void FailsIfSelectsHasNoFrom()
		{
			string clause = new Select("p").Clause;
		}

		[Test]
		public void UsesDistinct()
		{
			Assert.AreEqual("select distinct p from Foo p", Select.Distinct("p").From("Foo p").Clause);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void FailsIfSelectIsEmpty()
		{
			Select.Distinct("");
		}

		[Test]
		[ExpectedException(typeof(NotSupportedException))]
		public void FailsIfOverwritingFromClause()
		{
			Select.Distinct("p").From("Foo p").From("Bar p");
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void FailsIfSettingNullFrom()
		{
			Select select = Select.Distinct("p");
			select.SetFrom(null);
		}

		[Test]
		[ExpectedException(typeof(NotSupportedException))]
		public void FailsWhenGettingFromIfNotSet()
		{
			// no from is set yet!
			Select.Distinct("p").From();
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void FailsIfWhereIsNull()
		{
			new From("Foo").SetWhere(null);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void FailsIfOrderByIsNull()
		{
			new From("Foo").SetOrderBy(null);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void FailsIfGroupByIsNull()
		{
			new From("Foo").SetGroupBy(null);
		}

		[Test]
		[ExpectedException(typeof(NotSupportedException))]
		public void WhereNotFailsWhereIsAlreadySet()
		{
			From from = new From("Foo");
			from.Where().And("Name = 'Sean'");
			from.WhereNot().And("Name = 'Sean'");
		}

		[Test]
		public void UsingWhereNot()
		{
			From from = new From("Foo");
			from.WhereNot().And("Name = 'Sean'");
			Assert.AreEqual("from Foo where not ((Name = 'Sean'))", from.Clause);
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void GroupByFailsIfPropertyIsEmpty()
		{
			new GroupBy().Add("");
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void OrderByFailsIfPropertyIsEmpty()
		{
			new OrderBy().Add("");
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void OrderByFailsIfPropertyIsASpace()
		{
			new OrderBy().Add("  ");
		}

		[Test]
		public void OrderByExpressionDefaultsToEmpty()
		{
			Assert.IsEmpty(new OrderBy().Expression);
		}

		[Test]
		public void GroupByMultipleProperties()
		{
			GroupBy groupBy = new GroupBy();
			Assert.IsEmpty(groupBy.Expression);

			groupBy.Add("Activity");
			groupBy.Add("Country");

			Assert.AreEqual("Activity, Country", groupBy.Expression);
		}
	}
}
