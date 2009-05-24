using System;
using Castle.Windsor;
using NHibernate.Bytecode;
using NHibernate.ByteCode.Castle;
using NHibernate.Properties;

namespace uNhAddIns.CastleAdapters.EnhancedBytecodeProvider
{
	public class EnhancedBytecode : IBytecodeProvider
	{
		private readonly IObjectsFactory objectsFactory;

		private readonly IWindsorContainer container;

		public EnhancedBytecode(IWindsorContainer container)
		{
			this.container = container;
			objectsFactory = new ObjectsFactory(container);
		}

		#region IBytecodeProvider Members

		public IReflectionOptimizer GetReflectionOptimizer(Type clazz, IGetter[] getters, ISetter[] setters)
		{
			return new ReflectionOptimizer(container, clazz, getters, setters);
		}

		public IProxyFactoryFactory ProxyFactoryFactory
		{
			get { return new ProxyFactoryFactory(); }
		}

		public IObjectsFactory ObjectsFactory
		{
			get { return objectsFactory; }
		}

		#endregion
	}
}