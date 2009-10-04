using System;
using System.Collections.Generic;
using System.Linq;
using Castle.DynamicProxy;
using Castle.MicroKernel;
using NHibernate;
using uNhAddIns.ComponentBehaviors.Castle.Configuration;
using uNhAddIns.NHibernateTypeResolver;
using IInterceptor=Castle.Core.Interceptor.IInterceptor;

namespace uNhAddIns.ComponentBehaviors.Castle.NHibernateInterceptor
{
	public class ComponentBehaviorInterceptor : EntityNameInterceptor
	{
		private static readonly ProxyGenerator proxyGenerator =
			new ProxyGenerator();
        private readonly IBehaviorConfigurator _behaviorConfigurator;
		private readonly IKernel _kernel;
        private readonly IDictionary<string, ProxyInformation> _cachedProxyInformation =
						new Dictionary<string, ProxyInformation>();

		public ComponentBehaviorInterceptor(IBehaviorConfigurator behaviorConfigurator, IKernel kernel)
		{
			_behaviorConfigurator = behaviorConfigurator;
			_kernel = kernel;
		}

		private ProxyInformation GetProxyInformation(string clazz)
		{
			ProxyInformation result;
			if(_cachedProxyInformation.TryGetValue(clazz, out result))
			{
				return result;
			}

			//TODO: Find a better way to resolve a type with fullname (without the qualified name).
			var query = from a in AppDomain.CurrentDomain.GetAssemblies()
						from t in a.GetTypes()
						where t.FullName.Equals(clazz)
						select t;

			Type type = query.FirstOrDefault();
			if(type == null) return null;

			ProxyInformation proxyInfo = _behaviorConfigurator.GetProxyInformation(type);
			_cachedProxyInformation[clazz] = proxyInfo;
			return proxyInfo;
		}

		public override object Instantiate(string clazz, EntityMode entityMode, object id)
		{
			if (entityMode == EntityMode.Poco)
			{
				var proxyInfo = GetProxyInformation(clazz);
				if(proxyInfo != null && proxyInfo.Interceptors.Count > 0)
				{
					Type[] additionalInterfacesToProxy = proxyInfo.AdditionalInterfaces.ToArray();
					IInterceptor[] interceptors = proxyInfo.Interceptors.Select(i => _kernel[i]).OfType<IInterceptor>().ToArray();

					object instance = proxyGenerator.CreateClassProxy(proxyInfo.EntityType,
																	  additionalInterfacesToProxy,
																	  interceptors);
					return instance;
				}
			}
			return base.Instantiate(clazz, entityMode, id);
		}
	}
}