using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }
    }
}