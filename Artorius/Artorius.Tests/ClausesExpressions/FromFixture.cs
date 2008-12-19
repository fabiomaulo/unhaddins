using System.Linq;
using NHibernate.Hql.Ast.Tree;
using NUnit.Framework;

namespace Artorius.Tests.ClausesExpressions
{
	[TestFixture]
	public class FromFixture
	{
		[Test]
		public void CreateWithEntityName()
		{
			var fromClause = new FromClause("Animal");
			Assert.That(fromClause.EntityNames, Is.Not.Null);
			Assert.That(fromClause.EntityNames.Count, Is.EqualTo(1));
			Assert.That(fromClause.EntityNames.ElementAt(0).Alieased.ToString(), Is.EqualTo("Animal"));
			Assert.That(fromClause.EntityNames.ElementAt(0).Alias, Is.Null);
		}

		[Test]
		public void AddEntityName()
		{
			var fromClause = new FromClause();
			fromClause.AddChild(new EntityNameExpression("Animal"));
			Assert.That(fromClause.EntityNames, Is.Not.Null);
			Assert.That(fromClause.EntityNames.Count, Is.EqualTo(1));
			Assert.That(fromClause.EntityNames.ElementAt(0).Alieased.ToString(), Is.EqualTo("Animal"));
			Assert.That(fromClause.EntityNames.ElementAt(0).Alias, Is.Null);

			fromClause = new FromClause();
			fromClause.AddChild(new AliasedEntityNameExpression("Animal","a"));
			Assert.That(fromClause.EntityNames, Is.Not.Null);
			Assert.That(fromClause.EntityNames.Count, Is.EqualTo(1));
			Assert.That(fromClause.EntityNames.ElementAt(0).Alieased.ToString(), Is.EqualTo("Animal"));
			Assert.That(fromClause.EntityNames.ElementAt(0).Alias, Is.EqualTo("a"));
		}
	}
}