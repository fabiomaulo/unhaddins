using System;
using NUnit.Framework;

namespace uNhAddIns.ComponentBehaviors.Tests
{
    [TestFixture]
    public class DefaultBehaviorStoreFixture
    {
        [Test]
        public void can_put_and_get_multiples_behaviors()
        {
            var defaultBehaviorStore = new DefaultBehaviorStore();

            defaultBehaviorStore.SetBehaviors(typeof (Decimal),
                                              Behaviors.EditableBehavior
                                              | Behaviors.NotifiableBehavior);

            Behaviors behaviors = defaultBehaviorStore.GetBehaviorsForType(typeof (Decimal));

            ((behaviors & Behaviors.NotifiableBehavior) == Behaviors.NotifiableBehavior)
                .Should().Be.True();

            ((behaviors & Behaviors.EditableBehavior) == Behaviors.EditableBehavior)
                .Should().Be.True();
        }
    }
}