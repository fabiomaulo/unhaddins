using System.Collections.Generic;
using System.Linq;
using ChinookMediaManager.Data.Repositories;
using ChinookMediaManager.Domain;
using NHibernate;

namespace ChinookMediaManager.Data.Impl.Repositories
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(ISessionFactory factory) : base(factory)
        {
        }

        #region IAlbumRepository Members

        public ICollection<Album> GetByArtist(Artist artist)
        {
            //Todo could be implemented as an extesion method
            return this.Where(album => album.Artist != null && album.Artist.Id == artist.Id)
                       .ToList();
        }

        #endregion
    }
}