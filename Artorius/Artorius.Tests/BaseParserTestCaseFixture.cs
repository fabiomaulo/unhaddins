using System;
using NUnit.Framework;

namespace Artorius.Tests
{
	[TestFixture]
	public class BaseParserTestCaseFixture
	{
		public class MockTest: BaseParserTestCase
		{
			private readonly Func<string> action;

			public MockTest(Func<string> action)
			{
				this.action = action;
			}

			#region Overrides of BaseParserTestCase

			protected override string SymbolNameFromWhereStart
			{
				get { return action.Invoke(); }
			}

			#endregion
		}

		[Test]
		public void NewParser()
		{
			var nt = new MockTest(() => null);
			Assert.Throws<ArgumentException>(() => nt.NewParser());
			var it = new MockTest(() => "PIZZA");
			Assert.Throws<ArgumentException>(() => it.NewParser());
			var vt = new MockTest(() => "Expression");
			Assert.That(vt.NewParser(), Is.Not.Null);
		}
	}
}