using Spring.Objects.Factory.Config;
using Spring.Objects.Factory.Support;

namespace uNhAddIns.SpringAdapters
{
	public static class SpringRegistrationExtensions
	{
		public static void Register<TSerivice, TImplementation>(this IConfigurableListableObjectFactory confObjFactory)
		{
			IObjectDefinitionFactory odf = new DefaultObjectDefinitionFactory();
			var odb = ObjectDefinitionBuilder.RootObjectDefinition(odf, typeof(TImplementation));
			confObjFactory.RegisterObjectDefinition(typeof(TSerivice).FullName, odb.ObjectDefinition);
		}

		public static void RegisterPrototype<TSerivice, TImplementation>(this IConfigurableListableObjectFactory confObjFactory)
		{
			IObjectDefinitionFactory odf = new DefaultObjectDefinitionFactory();
			var odb = ObjectDefinitionBuilder.RootObjectDefinition(odf, typeof(TImplementation))
				.SetSingleton(false);
			confObjFactory.RegisterObjectDefinition(typeof(TSerivice).FullName, odb.ObjectDefinition);
		}

		public static void RegisterInstance<TSerivice>(this IConfigurableListableObjectFactory confObjFactory, TSerivice instance)
		{
			confObjFactory.RegisterSingleton(typeof(TSerivice).FullName, instance);
		}
	}
}