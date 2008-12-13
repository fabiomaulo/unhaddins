using System;

namespace SessionManagement.Infrastructure.InversionOfControl
{
	public interface IDependencyResolver : IDisposable
	{
		T Resolve<T>();
		void RegisterImplementationOf(string id, Type service, Type implementation, LifeStyle lifeStyle);

		void RegisterImplementationOf(string id, Type service, Type implementation);
	}
}
