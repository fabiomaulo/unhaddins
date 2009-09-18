using System;
using Castle.Windsor;
using NHibernate.Bytecode;
using NHibernate.ByteCode.Castle;
using NHibernate.Properties;
using NHibernate.Type;

namespace uNhAddIns.CastleAdapters.EnhancedBytecodeProvider
{
	public class EnhancedBytecode : IBytecodeProvider, IInjectableCollectionTypeFactoryClass, IInjectableProxyFactoryFactory
	{
		private readonly IObjectsFactory objectsFactory;

		private readonly IWindsorContainer container;
		private ICollectionTypeFactory collectionTypefactory;
	    private IProxyFactoryFactory proxyFactoryFactory;

		public EnhancedBytecode(IWindsorContainer container)
		{
			this.container = container;
			objectsFactory = new ObjectsFactory(container);
			collectionTypefactory = new DefaultCollectionTypeFactory();
		    proxyFactoryFactory = new ProxyFactoryFactory();
		}

		#region IBytecodeProvider Members

		public IReflectionOptimizer GetReflectionOptimizer(Type clazz, IGetter[] getters, ISetter[] setters)
		{
			return new ReflectionOptimizer(container, clazz, getters, setters);
		}
        
		public IProxyFactoryFactory ProxyFactoryFactory
		{
			get
			{
			    return proxyFactoryFactory;
			}
		}

		public IObjectsFactory ObjectsFactory
		{
			get { return objectsFactory; }
		}

		public ICollectionTypeFactory CollectionTypeFactory
		{
			get { return collectionTypefactory; }
		}

		#endregion

	    public void SetCollectionTypeFactoryClass(string typeAssemblyQualifiedName)
	    {
	        SetCollectionTypeFactoryClass(Type.GetType(typeAssemblyQualifiedName, true));
	    }

	    public void SetCollectionTypeFactoryClass(Type type)
	    {
            if (container.Kernel.HasComponent(type))
                collectionTypefactory = (ICollectionTypeFactory)container.Resolve(type);
            else
	            collectionTypefactory = (ICollectionTypeFactory) Activator.CreateInstance(type);
	    }

	    public void SetProxyFactoryFactory(string typeName)
	    {
	        Type type = Type.GetType(typeName, true);
            if (container.Kernel.HasComponent(type))
                proxyFactoryFactory = (IProxyFactoryFactory)container.Resolve(type);
            else
                proxyFactoryFactory = (IProxyFactoryFactory)Activator.CreateInstance(type);
	    }
	}
}