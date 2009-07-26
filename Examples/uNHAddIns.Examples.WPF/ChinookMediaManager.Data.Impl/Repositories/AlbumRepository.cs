using ChinookMediaManager.Data.Repositories;
using ChinookMediaManager.Domain;
using NHibernate;

namespace ChinookMediaManager.Data.Impl.Repositories
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(ISessionFactory factory) : base(factory)
        {}
    }
}