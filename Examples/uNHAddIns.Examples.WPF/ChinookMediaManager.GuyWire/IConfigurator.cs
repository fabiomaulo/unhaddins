using Castle.Windsor;

namespace ChinookMediaManager.GuyWire
{
    public interface IConfigurator
    {
        void Configure(IWindsorContainer container);
    }
}