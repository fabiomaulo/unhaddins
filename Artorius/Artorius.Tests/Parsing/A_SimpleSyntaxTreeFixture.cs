using NHibernate.Hql.Ast.Tree;
using NUnit.Framework;

namespace Artorius.Tests.Parsing
{
	[TestFixture]
	public class A_SimpleSyntaxTreeFixture : BaseParserTestCase
	{
		#region Overrides of BaseParserTestCase

		protected override string SymbolNameFromWhereStart
		{
			get { return "Value"; }
		}

		#endregion

		[Test]
		public void SingleInteger()
		{
			var parser = NewParser();
			var node = parser.Parse("123");
			Assert.That(node, Is.Not.Null);
			Assert.That(node, Is.InstanceOf<ValueClause>());
			var clause = (ValueClause) node;
			Assert.That(clause.IsSingleValue);
			Assert.That(clause.GetValueAsString(), Is.EqualTo("123"));
		}
	}
}