using System.Collections;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Engine;
using NHibernate.Impl;
using NHibernate.Loader.Criteria;
using NHibernate.SqlCommand;
using NHibernate.Util;
using NUnit.Framework;
using uNhAddIns.Criterions;

namespace uNhAddIns.Test.CriterionTest
{
	[TestFixture]
	public class CriterionTest : TestCase
	{
		protected override IList Mappings
		{
			get { return new string[] { "CriterionTest.Simple.hbm.xml" }; }
		}

		[Test]
		public void EqOrNullTest()
		{
			using (ISession session = OpenSession())
			{
				CriteriaImpl criteria = (CriteriaImpl) session.CreateCriteria(typeof (Simple));
				CriteriaQueryTranslator criteriaQuery = new CriteriaQueryTranslator(sessions, criteria, criteria.EntityOrClassName, "sql_alias");

				ICriterion exp = Criterion.EqOrNull("Name", "foo");
				SqlString sqlString = exp.ToSqlString(criteria, criteriaQuery, new CollectionHelper.EmptyMapClass<string, IFilter>());

				string expectedSql = "sql_alias.Name = ?";

				Assert.AreEqual(expectedSql, sqlString.ToString());
				Assert.AreEqual(1, sqlString.GetParameterCount());

				exp = Criterion.EqOrNull("Name", null);
				sqlString = exp.ToSqlString(criteria, criteriaQuery, new CollectionHelper.EmptyMapClass<string, IFilter>());

				expectedSql = "sql_alias.Name is null";

				Assert.AreEqual(expectedSql, sqlString.ToString());
				Assert.AreEqual(0, sqlString.GetParameterCount());

				// Check that the result is the same than using official Expression
				ICriterion orExpExpected = Expression.Or(Expression.IsNull("Name"), Expression.Eq("Name", "foo"));
				ICriterion orExpActual = Expression.Or(Criterion.EqOrNull("Name", null), Criterion.EqOrNull("Name", "foo"));

				SqlString sqlStringExpected = orExpExpected.ToSqlString(criteria, criteriaQuery, new CollectionHelper.EmptyMapClass<string, IFilter>());
				SqlString sqlStringActual = orExpActual.ToSqlString(criteria, criteriaQuery, new CollectionHelper.EmptyMapClass<string, IFilter>());
				Assert.AreEqual(sqlStringExpected.ToString(), sqlStringActual.ToString());
			}
		}
	}
}