using System;
using System.Collections.Generic;
using System.Linq;
using ChinookMediaManager.Data.Repositories;
using ChinookMediaManager.Domain;
using NHibernate;

namespace ChinookMediaManager.Data.Impl.Repositories
{
    public class AlbumRepository : Repository<IAlbum>, IAlbumRepository
    {
        public AlbumRepository(ISessionFactory factory) : base(factory)
        {}

        public ICollection<IAlbum> GetByArtist(Artist artist)
        {
            return this.Where(album => album.Artist != null && album.Artist.Id == artist.Id).ToList();
        }
    }
}