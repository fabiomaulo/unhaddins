using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;

namespace uNhAddIns.ComponentBehaviors.Castle
{
    public class ComponentBehaviorsFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Register(Component.For<EditableBehaviorInterceptor>().LifeStyle.Transient);
            Kernel.Register(Component.For<NhEditableBehaviorInterceptor>().LifeStyle.Transient);
            Kernel.Register(Component.For<PropertyChangedInterceptor>().LifeStyle.Transient);
            Kernel.Register(Component.For<GetEntityNameInterceptor>().LifeStyle.Transient);
            Kernel.Register(Component.For<DataErrorInfoInterceptor>().LifeStyle.Transient);
        }
    }
}