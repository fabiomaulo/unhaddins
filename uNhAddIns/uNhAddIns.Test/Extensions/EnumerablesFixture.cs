using NUnit.Framework;
using uNhAddIns.Extensions;

namespace uNhAddIns.Test.Extensions
{
	[TestFixture]
	public class EnumerablesFixture
	{
		[Test]
		public void ConcatWithSeparator()
		{
			(new[] {"1", "2"}).ConcatWithSeparator(';').Should().Be.EqualTo("1;2");
			(new[] {"1", "2", "3"}).ConcatWithSeparator(';').Should().Be.EqualTo("1;2;3");
			(new[] { "1" }).ConcatWithSeparator(';').Should().Be.EqualTo("1");
			(new[] { "" }).ConcatWithSeparator(';').Should().Be.EqualTo("");
		}
	}
}