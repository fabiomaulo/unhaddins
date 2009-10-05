using System;

namespace uNhAddIns.ComponentBehaviors.Castle.ComponentProxyFactory
{
	public interface IComponentProxyFactory
	{
		T GetEntity<T>();
		object GetEntity(Type type);
	}
}