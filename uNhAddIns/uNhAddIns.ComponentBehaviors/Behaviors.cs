using System;

namespace uNhAddIns.ComponentBehaviors
{
    [Flags]
    public enum Behaviors
    {
        None                    = 0x000,
        DataErrorInfoBehavior   = 0x001,
        NotifiableBehavior      = 0x002,
        EditableBehavior        = 0x004
    }

    public static class BehaviorUtil
    {
        public static bool Include(this Behaviors behaviors, Behaviors behavior)
        {
            return (behaviors & behavior) == behavior;
        }
    }
}