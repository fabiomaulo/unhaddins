using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;

namespace uNhAddIns.WPF.Castle
{
    public class WpfFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Register(Component.For<EditableBehaviorInterceptor>().LifeStyle.Transient);
            Kernel.Register(Component.For<GetEntityNameInterceptor>().LifeStyle.Transient);
            Kernel.Register(Component.For<PropertyChangeNotifier>().LifeStyle.Transient);
        }
    }
}