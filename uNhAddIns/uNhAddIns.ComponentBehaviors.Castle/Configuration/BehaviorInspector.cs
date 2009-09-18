using System;
using System.Linq;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.ModelBuilder.Inspectors;
using Castle.MicroKernel.Proxy;

namespace uNhAddIns.ComponentBehaviors.Castle.Configuration
{
    public class BehaviorInspector : MethodMetaInspector
    {
      
        public override void ProcessModel(IKernel kernel, ComponentModel model)
        {
            var behaviorToProxyResolver = (IBehaviorToProxyResolver)kernel[typeof(IBehaviorToProxyResolver)];
            if (behaviorToProxyResolver == null)
                throw new InvalidOperationException("Missing IBehaviorToProxyResolver service.");

            //Get the proxy info
            var proxyInfo = behaviorToProxyResolver.GetProxyInformation(model.Implementation);

            //No proxy info.
            if(proxyInfo.AdditionalInterfaces.Count == 0 &&
                proxyInfo.InterceptorTypes.Count == 0)
                return;
            

            //apply interceptor references to the model
            foreach (var interceptorType in proxyInfo.InterceptorTypes)
            {
                model.Dependencies.Add(new DependencyModel(DependencyType.Service, null, interceptorType, false));
                model.Interceptors.Add(new InterceptorReference(interceptorType));
            }
                
            //apply additional interfaces
            ProxyUtil.ObtainProxyOptions(model,true)
                    .AddAdditionalInterfaces(proxyInfo.AdditionalInterfaces.ToArray());
            
        }

        protected override string ObtainNodeName()
        {
            return "no op";
        }
    }
}