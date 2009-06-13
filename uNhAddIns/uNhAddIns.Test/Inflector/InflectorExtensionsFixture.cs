using NUnit.Framework;
using uNhAddIns.Inflector;

namespace uNhAddIns.Test.Inflector
{
	[TestFixture]
	public class InflectorExtensionsFixture
	{
		[Test]
		public void SplitWords()
		{
			"OrdenCliente".SplitWords().Should().Have.SameSequenceAs(new[] { "Orden", "Cliente" });
			"Orden_Cliente".SplitWords().Should().Have.SameSequenceAs(new[] { "Orden", "_", "Cliente" });
			"Orden Cliente".SplitWords().Should().Have.SameSequenceAs(new[] { "Orden", " ", "Cliente" });
			"Orig�nOrd�n".SplitWords().Should().Have.SameSequenceAs(new[] { "Orig�n", "Ord�n" });
		}
	}
}