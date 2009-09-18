using System;

namespace uNhAddIns.ComponentBehaviors.Castle.Configuration
{
    public interface IBehaviorToProxyResolver
    {
        ProxyInformation GetProxyInformation(Type implementationType);
    }
}