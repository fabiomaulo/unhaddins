using System;
using NUnit.Framework;
using uNhAddIns.Inflector;

namespace uNhAddIns.Test.Inflector
{
	[TestFixture]
	public class RuleFixture
	{
		[Test]
		public void Ctor()
		{
			Assert.Throws<ArgumentNullException>(() => new InflectorRule(null, null));
			Assert.Throws<ArgumentNullException>(() => new InflectorRule("$s", null));
			Assert.Throws<ArgumentNullException>(() => new InflectorRule(null, "s"));
			Assert.Throws<ArgumentNullException>(() => new InflectorRule("", "s"));
			Assert.DoesNotThrow(() => new InflectorRule("$s", ""));
		}

		[Test]
		public void Equality()
		{
			var r = new InflectorRule("$s", "s");
			r.Should().Be.EqualTo(new InflectorRule("$s", "s"));
			r.Should().Not.Be.EqualTo(new InflectorRule("$s", "ss"));
		}

		[Test]
		public void HashCode()
		{
			var r = new InflectorRule("$s", "s");
			r.GetHashCode().Should().Be.EqualTo((new InflectorRule("$s", "s")).GetHashCode());
			r.GetHashCode().Should().Not.Be.EqualTo((new InflectorRule("$s", "ss")).GetHashCode());
		}

		[Test]
		public void Apply()
		{
			var r = new InflectorRule("(pizz)a$", "$1e");
			r.Apply("pizza").Should().Be.EqualTo("pizze");
		}
	}
}