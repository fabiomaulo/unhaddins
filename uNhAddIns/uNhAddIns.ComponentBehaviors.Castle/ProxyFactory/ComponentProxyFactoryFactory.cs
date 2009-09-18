using Castle.Windsor;
using NHibernate.Bytecode;
using NHibernate.Proxy;
using uNhAddIns.ComponentBehaviors.Castle.Configuration;

namespace uNhAddIns.ComponentBehaviors.Castle.ProxyFactory
{
    public class ComponentProxyFactoryFactory : IProxyFactoryFactory
    {
        private readonly IBehaviorToProxyResolver _behaviorToProxyResolver;
        private readonly IWindsorContainer _container;

        //TODO: Find a better way. Avoid injecting the container itself.
        public ComponentProxyFactoryFactory(IBehaviorToProxyResolver behaviorToProxyResolver, IWindsorContainer container)
        {
            _behaviorToProxyResolver = behaviorToProxyResolver;
            _container = container;
        }

        /// <summary>
        /// Build a proxy factory specifically for handling runtime
        ///             lazy loading. 
        /// </summary>
        /// <returns>
        /// The lazy-load proxy factory. 
        /// </returns>
        public IProxyFactory BuildProxyFactory()
        {
            return new ComponentProxyFactory(_behaviorToProxyResolver, _container);
        }

        public IProxyValidator ProxyValidator
        {
            get { return new DynProxyTypeValidator(); }
        }
    }
}