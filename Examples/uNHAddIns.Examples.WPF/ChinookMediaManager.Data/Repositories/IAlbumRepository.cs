using System.Collections.Generic;
using ChinookMediaManager.Domain;

namespace ChinookMediaManager.Data.Repositories
{
    public interface IAlbumRepository : IRepository<IAlbum>
    {
        ICollection<IAlbum> GetByArtist(Artist artist);
    }
}