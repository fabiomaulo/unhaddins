using Castle.Windsor;
using System;
namespace uNhAddIns.Example.AopConversationUsage.MultiTiers
{
	public class WindsorServiceLocator: IServiceLocator, IContainerAccessor, IDisposable
	{
		private readonly IWindsorContainer container;

		public WindsorServiceLocator(IWindsorContainer container)
		{
			this.container = container;
			this.container.Kernel.AddComponentInstance<IContainerAccessor>(this);
			this.container.Kernel.AddComponentInstance<IServiceLocator>(this);
		}

		#region Implementation of IServiceLocator

		public T Resolve<T>(string key)
		{
			return container.Resolve<T>(key);
		}

		public T Resolve<T>()
		{
			return container.Resolve<T>();
		}

		#endregion

		#region Implementation of IDisposable

		public void Dispose()
		{
			container.Dispose();
		}

		#endregion

		#region IContainerAccessor Members

		IWindsorContainer IContainerAccessor.Container
		{
			get { return container; }
		}

		#endregion
	}
}