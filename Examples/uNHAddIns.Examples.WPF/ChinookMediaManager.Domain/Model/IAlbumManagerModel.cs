
using System.Collections.Generic;

namespace ChinookMediaManager.Domain.Model
{
    public interface IAlbumManagerModel
    {
        IEnumerable<IAlbum> GetAlbumsByArtist(Artist artist);
        void Save(IAlbum album);
        void AcceptAll();
        void CancelAll();
    }
}