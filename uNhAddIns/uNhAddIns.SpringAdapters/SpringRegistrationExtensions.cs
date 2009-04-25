using Spring.Objects.Factory.Config;
using Spring.Objects.Factory.Support;
using uNhAddIns.SessionEasier;
using uNhAddIns.SessionEasier.Conversations;

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

		public static void RegisterDefaultPersistentConversationServices(this IConfigurableListableObjectFactory confObjFactory)
		{
			confObjFactory.Register<ISessionFactoryProvider, SessionFactoryProvider>();
			confObjFactory.Register<ISessionWrapper, SessionWrapper>();
			confObjFactory.Register<IConversationFactory, DefaultConversationFactory>();
			confObjFactory.Register<IConversationsContainerAccessor, NhConversationsContainerAccessor>();
		}
	}
}