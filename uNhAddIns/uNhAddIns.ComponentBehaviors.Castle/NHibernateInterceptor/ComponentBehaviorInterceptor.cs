using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using uNhAddIns.NHibernateTypeResolver;

namespace uNhAddIns.ComponentBehaviors.Castle.NHibernateInterceptor
{
	public class ComponentBehaviorInterceptor : EntityNameInterceptor
	{
		//TODO: improve. This is done because I can't get a type with the not-qualified name.
		private readonly IDictionary<string, Type> _cachedTypes = new Dictionary<string, Type>();
		private readonly IComponentProxyFactory _componentProxyFactory;

		public ComponentBehaviorInterceptor(IComponentProxyFactory componentProxyFactory)
		{
			_componentProxyFactory = componentProxyFactory;
		}

		public ISessionFactory SessionFactory { get; set; }

		public override object Instantiate(string clazz, EntityMode entityMode, object id)
		{
			if (entityMode == EntityMode.Poco)
			{
				Type type;
				if (!_cachedTypes.TryGetValue(clazz, out type))
				{
					type = GetType(clazz);
					_cachedTypes[clazz] = type;
				}
				object entity = _componentProxyFactory.GetEntity(type);
				if(SessionFactory == null)
				{
					throw new InvalidOperationException("You should inject the ISessionFactory.");
				}
				SessionFactory.GetClassMetadata(clazz).SetIdentifier(entity, id, entityMode);
				return entity;
			}
			return base.Instantiate(clazz, entityMode, id);
		}

		private static Type GetType(string clazz)
		{
			//TODO: Find a better way to resolve a type with fullname (without the qualified name).
			IEnumerable<Type> query = from a in AppDomain.CurrentDomain.GetAssemblies()
			                          from t in a.GetTypes()
			                          where t.FullName.Equals(clazz)
			                          select t;

			Type type = query.FirstOrDefault();
			if (type == null)
			{
				throw new InvalidOperationException(string.Format("Cannot find the type {0}.", clazz));
			}
			return type;
		}
	}
}