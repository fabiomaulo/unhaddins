using System;
using System.Collections.Generic;
using Castle.Core;

namespace uNhAddIns.ComponentBehaviors.Castle.Configuration
{
    public class ProxyInformation
    {
        public ProxyInformation(ICollection<Type> additionalInterfaces,
                                ICollection<Type> interceptorReferences)
        {
            AdditionalInterfaces = additionalInterfaces;
            InterceptorTypes = interceptorReferences;
        }

        public ICollection<Type> AdditionalInterfaces { get; private set; }
        public ICollection<Type> InterceptorTypes { get; private set; }
    }
}