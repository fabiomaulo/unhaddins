using uNhAddIns.Entities;

namespace ChinookMediaManager.Infrastructure
{
    public interface IEntityFactory
    {
        T Create<T>() where T : Entity;
    }
}