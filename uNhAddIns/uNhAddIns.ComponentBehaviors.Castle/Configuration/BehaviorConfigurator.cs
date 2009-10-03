using System;
using System.Linq;
using uNhAddIns.NHibernateTypeResolver;

namespace uNhAddIns.ComponentBehaviors.Castle.Configuration
{
	public class BehaviorConfigurator : IBehaviorConfigurator
	{
		readonly IBehavior[] _behaviors;
		readonly IBehaviorStore _behaviorStore;


		public BehaviorConfigurator(IBehaviorStore behaviorStore, IBehavior[] behaviors)
		{
			_behaviorStore = behaviorStore;
			_behaviors = behaviors;
		}

		#region IBehaviorConfigurator Members

		public ProxyInformation GetProxyInformation(Type implementationType)
		{
			var selectedBehaviors = _behaviorStore.GetBehaviorsForType(implementationType);

			var involvedBehaviors = _behaviors.Where(b => selectedBehaviors.Contains(b.GetType()));

			//Interfaces that are not already implemented by the implementationType.
			var additionalInterfaces = (from b in involvedBehaviors
			                            from i in b.GetAdditionalInterfaces()
			                            where !i.IsAssignableFrom(implementationType)
			                            select i).ToList();


			//select interceptors
			var interceptorReferences = involvedBehaviors
				.OrderBy(b => b.GetRelativeOrder())
				.Select(b => b)
				.ToList();


			if (interceptorReferences.Count > 0)
			{
				additionalInterfaces.Add(typeof (IWellKnownProxy));
				interceptorReferences.Insert(0, _behaviors.First(b => typeof (GetEntityNameBehavior).IsInstanceOfType(b)));
			}

			return new ProxyInformation(additionalInterfaces, interceptorReferences);
		}

		#endregion
	}
}