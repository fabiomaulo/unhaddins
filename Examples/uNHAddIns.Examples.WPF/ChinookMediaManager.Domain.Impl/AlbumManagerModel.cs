using System;
using System.Collections.Generic;
using ChinookMediaManager.Data.Repositories;
using ChinookMediaManager.Domain.Model;
using uNhAddIns.Adapters;

namespace ChinookMediaManager.Domain.Impl
{
    [PersistenceConversational(MethodsIncludeMode = MethodsIncludeMode.Implicit)]
    public class AlbumManagerModel : IAlbumManagerModel
    {

        private readonly IAlbumRepository albumRepository;

        public AlbumManagerModel(IAlbumRepository albumRepository)
        {
            this.albumRepository = albumRepository;
        }

        /// <summary>
        /// Search all the albums from a given artist.
        /// </summary>
        /// <param name="artist"></param>
        /// <returns></returns>
        public IEnumerable<Album> GetAlbumsByArtist(Artist artist)
        {
            return albumRepository.GetByArtist(artist);
        }

        /// <summary>
        /// Persist an album.
        /// </summary>
        /// <param name="album"></param>
        public void SaveAlbum(Album album)
        {
            albumRepository.MakePersistent(album);
        }

        /// <summary>
        /// Revert changes from a given album to his original state.
        /// </summary>
        /// <param name="album"></param>
        public void CancelAlbum(Album album)
        {
            albumRepository.Refresh(album);
        }

        /// <summary>
        /// Flush all changes to the database.
        /// </summary>
        [PersistenceConversation(ConversationEndMode = EndMode.End)]
        public void SaveAll()
        {}

        /// <summary>
        /// Cancel all changes.
        /// </summary>
        [PersistenceConversation(ConversationEndMode = EndMode.Abort)]
        public void CancelAll()
        {
            throw new NotImplementedException();
        }
    }
}