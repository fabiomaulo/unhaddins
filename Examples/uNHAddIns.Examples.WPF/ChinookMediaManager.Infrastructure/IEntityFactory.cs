using uNhAddIns.Entities;

namespace ChinookMediaManager.Infrastructure
{
    public interface IEntityFactory
    {
        T Instantiate<T>() where T : Entity;
    }
}