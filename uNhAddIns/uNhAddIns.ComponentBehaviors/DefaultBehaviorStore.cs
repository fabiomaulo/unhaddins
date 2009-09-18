
using System;
using System.Collections.Generic;

namespace uNhAddIns.ComponentBehaviors
{
    public class DefaultBehaviorStore : IBehaviorStore
    {
        private readonly IDictionary<Type, Behaviors> _behaviors =
            new Dictionary<Type, Behaviors>();

        public Behaviors GetBehaviorsForType(Type type)
        {
            Behaviors result;
            _behaviors.TryGetValue(type, out result);
            return result;
        }

        public void SetBehaviors(Type type, Behaviors behaviors)
        {
            _behaviors[type] = behaviors;
        }
    }
}