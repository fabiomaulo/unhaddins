using System.Collections.Generic;
using ChinookMediaManager.Domain;

namespace ChinookMediaManager.Data.Repositories
{
    public interface IAlbumRepository : IRepository<Album>
    {
        ICollection<Album> GetByArtist(Artist artist);
    }
}