using NUnit.Framework;
using uNhAddIns.Inflector;

namespace uNhAddIns.Test.Inflector
{
	[TestFixture]
	public class SpanishInflectorFixture : BaseInflectorFixture
	{
		public SpanishInflectorFixture()
		{
			SingularToPlural.Add("ingl�s", "ingleses");
			SingularToPlural.Add("hijo", "hijos");
			SingularToPlural.Add("paz", "paces");
			SingularToPlural.Add("crisis", "crisis");
			SingularToPlural.Add("praxis", "praxis");
			SingularToPlural.Add("apendicitis", "apendicitis");
			SingularToPlural.Add("llave", "llaves");
			SingularToPlural.Add("auto", "autos");
			SingularToPlural.Add("ord�n", "ordenes");
			SingularToPlural.Add("item", "items");
			SingularToPlural.Add("linea", "lineas");
			SingularToPlural.Add("proveedor", "proveedores");
			SingularToPlural.Add("Terminal", "Terminales");
			SingularToPlural.Add("ParteFichaTecnica", "ParteFichaTecnicas");
			SingularToPlural.Add("pago", "pagos");
			SingularToPlural.Add("Ubicaci�n", "Ubicaciones");
			SingularToPlural.Add("Orig�n", "Origenes");
			SingularToPlural.Add("rol", "roles");
			SingularToPlural.Add("ciudad", "ciudades");
			SingularToPlural.Add("documento", "documentos");
			SingularToPlural.Add("Historial", "Historiales");
			SingularToPlural.Add("Promoci�n", "Promociones");

			ClassNameToTableName.Add("Orig�n", "Origenes");
			ClassNameToTableName.Add("Ord�n", "ordenes");

			TestInflector = new SpanishInflector();
		}
	}
}