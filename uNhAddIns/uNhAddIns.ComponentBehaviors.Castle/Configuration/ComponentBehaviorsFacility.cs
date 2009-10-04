using Castle.Facilities.FactorySupport;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using uNhAddIns.ComponentBehaviors.Castle.NHibernateInterceptor;
using uNhAddIns.ComponentBehaviors.Castle.ProxyFactory;

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
									.ImplementedBy<BehaviorConfigurator>().LifeStyle.Singleton);
			Kernel.Register(Component.For<ComponentBehaviorInterceptor>()
									.UsingFactoryMethod(k => new ComponentBehaviorInterceptor(k.Resolve<IBehaviorConfigurator>(), k)));
            Kernel.Register(Component.For<ComponentProxyFactoryFactory>()
        	                		.UsingFactoryMethod(k => new ComponentProxyFactoryFactory(k.Resolve<IBehaviorConfigurator>(), k)));
			Kernel.ComponentModelBuilder.AddContributor(new BehaviorInspector());
        }
    }
}