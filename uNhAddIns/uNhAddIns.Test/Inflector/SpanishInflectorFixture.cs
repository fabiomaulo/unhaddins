using NUnit.Framework;
using uNhAddIns.Inflector;

namespace uNhAddIns.Test.Inflector
{
	[TestFixture]
	public class SpanishInflectorFixture : BaseInflectorFixture
	{
		public SpanishInflectorFixture()
		{
			SingularToPlural.Add("inglés", "ingleses");
			SingularToPlural.Add("hijo", "hijos");
			SingularToPlural.Add("paz", "paces");
			SingularToPlural.Add("crisis", "crisis");
			SingularToPlural.Add("praxis", "praxis");
			SingularToPlural.Add("apendicitis", "apendicitis");
			SingularToPlural.Add("llave", "llaves");
			SingularToPlural.Add("auto", "autos");
			SingularToPlural.Add("ordén", "ordenes");
			SingularToPlural.Add("item", "items");
			SingularToPlural.Add("linea", "lineas");
			SingularToPlural.Add("proveedor", "proveedores");

			TestInflector = new SpanishInflector();
		}
	}
}