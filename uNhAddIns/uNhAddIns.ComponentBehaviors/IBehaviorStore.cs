using System;

namespace uNhAddIns.ComponentBehaviors
{
    public interface IBehaviorStore
    {
        Behaviors GetBehaviorsForType(Type type);
        void SetBehaviors(Type type, Behaviors behaviors);
    }
}