using Spring.Objects.Factory.Config;
using Spring.Objects.Factory.Support;

namespace uNhAddIns.SpringAdapters
{
	public static class SpringRegistrationExtensions
	{
		private static readonly IObjectDefinitionFactory ObjectDefinitionFactory = new DefaultObjectDefinitionFactory();

		public static void Register<TSerivice, TImplementation>(this IConfigurableListableObjectFactory confObjFactory)
		{
			var odb = ObjectDefinitionBuilder.RootObjectDefinition(ObjectDefinitionFactory, typeof(TImplementation))
				.SetAutowireMode(AutoWiringMode.ByType);
			confObjFactory.RegisterObjectDefinition(typeof(TSerivice).FullName, odb.ObjectDefinition);
		}

		public static void RegisterPrototype<TSerivice, TImplementation>(this IConfigurableListableObjectFactory confObjFactory)
		{
			var odb = ObjectDefinitionBuilder.RootObjectDefinition(ObjectDefinitionFactory, typeof(TImplementation))
				.SetSingleton(false).SetAutowireMode(AutoWiringMode.ByType);
			confObjFactory.RegisterObjectDefinition(typeof(TSerivice).FullName, odb.ObjectDefinition);
		}

		public static void RegisterInstance<TSerivice>(this IConfigurableListableObjectFactory confObjFactory, TSerivice instance)
		{
			confObjFactory.RegisterSingleton(typeof(TSerivice).FullName, instance);
		}
	}
}