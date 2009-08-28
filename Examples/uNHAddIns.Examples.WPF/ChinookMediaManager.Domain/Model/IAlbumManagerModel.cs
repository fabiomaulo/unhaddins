
using System.Collections.Generic;

namespace ChinookMediaManager.Domain.Model
{

    public interface IAlbumManagerModel
    {

        /// <summary>
        /// Search all the albums from a given artist.
        /// </summary>
        /// <param name="artist"></param>
        /// <returns></returns>
        IEnumerable<Album> GetAlbumsByArtist(Artist artist);

        /// <summary>
        /// Persist an album.
        /// </summary>
        /// <param name="album"></param>
        void SaveAlbum(Album album);

        /// <summary>
        /// Revert changes of a given album to his current persisted state.
        /// </summary>
        /// <param name="album"></param>
        void CancelAlbum(Album album);

        /// <summary>
        /// Flush all changes to the database.
        /// </summary>
        void SaveAll();

        /// <summary>
        /// Cancel all changes.
        /// </summary>
        void CancelAll();

        /// <summary>
        /// Return true if the album is valid.
        /// </summary>
        /// <param name="album"></param>
        /// <returns></returns>
        bool IsValid(Album album);

        /// <summary>
        /// Create a new instance of Album.
        /// </summary>
        /// <returns></returns>
        Album CreateNewAlbum(Artist artist);
    }
}