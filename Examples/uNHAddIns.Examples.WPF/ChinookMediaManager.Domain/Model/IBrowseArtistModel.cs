using System.Collections.Generic;

namespace ChinookMediaManager.Domain.Model
{
    public interface IBrowseArtistModel
    {
        IList<Artist> GetAllArtists();
    }
}