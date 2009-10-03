using Castle.Facilities.FactorySupport;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;

namespace uNhAddIns.ComponentBehaviors.Castle.Configuration
{
    public class ComponentBehaviorsFacility : AbstractFacility
    {
        protected override void Init()
        {
        	Kernel.Register(Component.For<EditableBehavior>().LifeStyle.Transient);
            Kernel.Register(Component.For<NotifyPropertyChangedBehavior>().LifeStyle.Transient);
            Kernel.Register(Component.For<GetEntityNameBehavior>().LifeStyle.Transient);
            Kernel.Register(Component.For<DataErrorInfoBehavior>().LifeStyle.Transient);
            Kernel.Register(Component.For<IBehaviorConfigurator>()
                                     .UsingFactoryMethod(k => new BehaviorConfigurator(k.Resolve<IBehaviorStore>(), k.ResolveAll<IBehavior>()))
                                     .LifeStyle.Singleton);
            Kernel.ComponentModelBuilder.AddContributor(new BehaviorInspector());
        }
    }
}