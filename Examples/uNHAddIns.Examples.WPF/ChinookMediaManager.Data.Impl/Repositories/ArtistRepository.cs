using ChinookMediaManager.Data.Repositories;
using ChinookMediaManager.Domain;
using NHibernate;

namespace ChinookMediaManager.Data.Impl.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(ISessionFactory factory) : base(factory)
        {}
    }
}