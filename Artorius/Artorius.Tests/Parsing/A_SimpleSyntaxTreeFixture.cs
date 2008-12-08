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
			get { return "Expression"; }
		}

		#endregion

		[Test]
		public void SingleInteger()
		{
			var parser = NewParser();
			var node = parser.Parse("123");
			Assert.That(node, Is.Not.Null);
			Assert.That(node, Is.InstanceOf<ValueExpression>());
			var clause = (ValueExpression) node;
			Assert.That(clause.IsSingleValue);
			Assert.That(clause.ToString(), Is.EqualTo("123"));
		}

		[Test]
		public void MathExpression()
		{
			var parser = NewParser();
			var node = parser.Parse("123 + 10");
			Assert.That(node, Is.Not.Null);
			Assert.That(node, Is.InstanceOf<MathExpression>());
			Assert.That(node.ToString(), Is.EqualTo("123+10"));
		}
	}
}