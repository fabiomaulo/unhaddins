
using System.Collections.Generic;

namespace ChinookMediaManager.Domain.Model
{
    public interface IAlbumManagerModel
    {
        IEnumerable<Album> GetAlbumsOfArtist(Artist artist);
    }
}