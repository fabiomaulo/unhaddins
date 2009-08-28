using System.Collections.Generic;
using ChinookMediaManager.Data.Repositories;
using ChinookMediaManager.Domain.Model;
using ChinookMediaManager.Infrastructure;
using uNhAddIns.Adapters;

namespace ChinookMediaManager.Domain.Impl
{
    [PersistenceConversational(MethodsIncludeMode = MethodsIncludeMode.Implicit)]
    public class AlbumManagerModel : IAlbumManagerModel
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IEntityFactory _entityFactory;
        private readonly IEntityValidator _entityValidator;

        public AlbumManagerModel(IAlbumRepository albumRepository, IEntityValidator entityValidator,
                                 IEntityFactory entityFactory)
        {
            _albumRepository = albumRepository;
            _entityValidator = entityValidator;
            _entityFactory = entityFactory;
        }

        #region IAlbumManagerModel Members

        /// <summary>
        /// Search all the albums from a given artist.
        /// </summary>
        /// <param name="artist"></param>
        /// <returns></returns>
        public IEnumerable<Album> GetAlbumsByArtist(Artist artist)
        {
            return _albumRepository.GetByArtist(artist);
        }

        /// <summary>
        /// Persist an album.
        /// </summary>
        /// <param name="album"></param>
        public void SaveAlbum(Album album)
        {
            if (IsValid(album))
                _albumRepository.MakePersistent(album);
        }

        /// <summary>
        /// Revert changes from a given album to his original state.
        /// </summary>
        /// <param name="album"></param>
        public void CancelAlbum(Album album)
        {
            _albumRepository.Refresh(album);
        }

        /// <summary>
        /// Return true if the album is valid.
        /// </summary>
        /// <param name="album"></param>
        /// <returns></returns>
        public bool IsValid(Album album)
        {
            return _entityValidator.IsValid(album);
        }

        /// <summary>
        /// Flush all changes to the database.
        /// </summary>
        [PersistenceConversation(ConversationEndMode = EndMode.End)]
        public void SaveAll()
        {
        }

        /// <summary>
        /// Cancel all changes.
        /// </summary>
        [PersistenceConversation(ConversationEndMode = EndMode.Abort)]
        public void CancelAll()
        {
        }

        /// <summary>
        /// Create a new instance of Album.
        /// </summary>
        /// <returns></returns>
        public Album CreateNewAlbum(Artist artist)
        {
            var album = _entityFactory.Create<Album>();
            album.Artist = artist;
            return album;
        }

        #endregion
    }
}