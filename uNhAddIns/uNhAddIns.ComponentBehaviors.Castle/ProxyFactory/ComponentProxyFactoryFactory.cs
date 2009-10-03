using Castle.Windsor;
using NHibernate.Bytecode;
using NHibernate.Proxy;
using uNhAddIns.ComponentBehaviors.Castle.Configuration;

namespace uNhAddIns.ComponentBehaviors.Castle.ProxyFactory
{
    public class ComponentProxyFactoryFactory : IProxyFactoryFactory
    {
        private readonly IBehaviorConfigurator _behaviorConfigurator;

    	public ComponentProxyFactoryFactory(IBehaviorConfigurator behaviorConfigurator)
        {
            _behaviorConfigurator = behaviorConfigurator;
        }

        #region IProxyFactoryFactory Members

        /// <summary>
        /// Build a proxy factory specifically for handling runtime
        ///             lazy loading. 
        /// </summary>
        /// <returns>
        /// The lazy-load proxy factory. 
        /// </returns>
        public IProxyFactory BuildProxyFactory()
        {
        	return new ComponentProxyFactory(_behaviorConfigurator);
        }

        public IProxyValidator ProxyValidator
        {
            get { return new DynProxyTypeValidator(); }
        }

        #endregion
    }
}