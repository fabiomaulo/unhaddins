using System;
using NHibernate.Bytecode;
using NHibernate.ByteCode.Spring;
using NHibernate.Properties;
using Spring.Objects.Factory;

namespace uNhAddIns.SpringAdapters.EnhancedBytecodeProvider
{
	public class EnhancedBytecode : IBytecodeProvider
	{
		private readonly IListableObjectFactory listableObjectFactory;
		private readonly IObjectsFactory objectsFactory;

		public EnhancedBytecode(IListableObjectFactory listableObjectFactory)
		{
			this.listableObjectFactory = listableObjectFactory;
			objectsFactory = new ObjectsFactory(listableObjectFactory);
		}

		public IReflectionOptimizer GetReflectionOptimizer(Type clazz, IGetter[] getters, ISetter[] setters)
		{
			return new ReflectionOptimizer(listableObjectFactory, clazz, getters, setters);
		}

		public IProxyFactoryFactory ProxyFactoryFactory
		{
			get { return new ProxyFactoryFactory(); }
		}

		public IObjectsFactory ObjectsFactory
		{
			get { return objectsFactory; }
		}
	}
}