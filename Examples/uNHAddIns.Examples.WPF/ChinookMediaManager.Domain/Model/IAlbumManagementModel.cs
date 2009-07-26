
using System.Collections.Generic;

namespace ChinookMediaManager.Domain.Model
{
    public interface IAlbumManagementModel
    {
        IEnumerable<Album> GetAlbumsOfArtist(Artist artist);
    }
}