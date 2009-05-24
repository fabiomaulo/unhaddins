using System;
using Castle.Windsor;
using NHibernate.Bytecode;

namespace uNhAddIns.CastleAdapters.EnhancedBytecodeProvider
{
	public class ObjectsFactory : IObjectsFactory
	{
		private readonly IWindsorContainer container;

		public ObjectsFactory(IWindsorContainer container)
		{
			this.container = container;
		}

		public object CreateInstance(Type type)
		{
			if (container.Kernel.HasComponent(type))
			{
				return container.Resolve(type);
			}
			else
			{
				return Activator.CreateInstance(type);
			}
		}

		public object CreateInstance(Type type, bool nonPublic)
		{
			return container.Kernel.HasComponent(type) ? container.Resolve(type) : Activator.CreateInstance(type, nonPublic);
		}

		public object CreateInstance(Type type, params object[] ctorArgs)
		{
			return Activator.CreateInstance(type, ctorArgs);
		}
	}
}