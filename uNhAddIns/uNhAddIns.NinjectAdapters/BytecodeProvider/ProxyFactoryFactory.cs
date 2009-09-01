using Ninject;
using NHibernate.Bytecode;

namespace uNhAddIns.NinjectAdapters.BytecodeProvider
{
    public class ProxyFactoryFactory : IProxyFactoryFactory 
    {

        public ProxyFactoryFactory(IKernel Kernel)
        {
            kernel = Kernel;
        }

        private readonly IKernel kernel;


        #region IProxyFactoryFactory Members

        NHibernate.Proxy.IProxyFactory IProxyFactoryFactory.BuildProxyFactory()
        {
            return kernel.Get<NHibernate.Proxy.IProxyFactory>();
        }

        NHibernate.Proxy.IProxyValidator IProxyFactoryFactory.ProxyValidator
        {
            get {return new uNhAddIns.NinjectAdapters.Proxy.ProxyTypeValidator();}
        }

        #endregion
    }
}
