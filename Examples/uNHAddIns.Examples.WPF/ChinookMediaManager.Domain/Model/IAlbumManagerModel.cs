
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
        /// Revert changes from a given album to his original state.
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
    }
}