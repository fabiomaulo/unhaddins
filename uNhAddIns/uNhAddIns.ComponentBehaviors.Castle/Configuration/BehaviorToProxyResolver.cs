using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Castle.Core;
using uNhAddIns.ComponentBehaviors.Castle.EntityNameResolver;

namespace uNhAddIns.ComponentBehaviors.Castle.Configuration
{
    public class BehaviorToProxyResolver : IBehaviorToProxyResolver
    {
        private readonly IBehaviorStore _behaviorStore;

        private class ProxyBehavior
        {
            public int Order { get; set; }
            public Behaviors Behavior { get; set; }
            public Type Interface { get; set; }
            public Type Interceptor { get; set; }
        }

        private static readonly IList<ProxyBehavior> behaviorsRepository
            = new List<ProxyBehavior>
                  {
                    new ProxyBehavior
                        {
                            Order = 0,
                            Behavior = Behaviors.DataErrorInfoBehavior,
                            Interface = typeof(IDataErrorInfo),
                            Interceptor = typeof(DataErrorInfoInterceptor)
                        },
                    new ProxyBehavior
                        {
                            Order = 1,
                            Behavior = Behaviors.NotifiableBehavior,
                            Interface = typeof(INotifyPropertyChanged),
                            Interceptor = typeof(PropertyChangedInterceptor)
                        },
                    new ProxyBehavior
                       {
                            Order = 0,
                            Behavior = Behaviors.EditableBehavior,
                            Interface = typeof(IEditableObject),
                            Interceptor = typeof(EditableBehaviorInterceptor)
                        }
               };
        public BehaviorToProxyResolver(IBehaviorStore behaviorStore)
        {
            _behaviorStore = behaviorStore;
        }

        public ProxyInformation GetProxyInformation(Type implementationType)
        {
            var selectedBehaviors = _behaviorStore.GetBehaviorsForType(implementationType);

            var involvedBehaviors = behaviorsRepository.Where(b => selectedBehaviors.Include(b.Behavior));

            //Interfaces that are not already implemented by the implementationType.
            var additionalInterfaces = involvedBehaviors.Where(b => !b.Interface.IsAssignableFrom(implementationType))
                                                        .Select(b => b.Interface).ToList();

            //select interceptors
            var interceptorReferences = involvedBehaviors
                                            .OrderBy(b => b.Order)
                                            .Select(b => b.Interceptor).ToList();

            
            if(interceptorReferences.Count > 0)
            {
                additionalInterfaces.Add(typeof(INamedEntity));
                interceptorReferences
                        .Insert(0, typeof(GetEntityNameInterceptor));
            }

            return new ProxyInformation(additionalInterfaces, interceptorReferences);
        }
    }


}