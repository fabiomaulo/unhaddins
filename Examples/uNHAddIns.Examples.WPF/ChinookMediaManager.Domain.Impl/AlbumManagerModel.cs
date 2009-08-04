using System;
using System.Collections.Generic;
using System.Linq;
using ChinookMediaManager.Data.Repositories;
using ChinookMediaManager.Domain.Model;
using uNhAddIns.Adapters;

namespace ChinookMediaManager.Domain.Impl
{
    [PersistenceConversational(
        MethodsIncludeMode = MethodsIncludeMode.Implicit,
        DefaultEndMode = EndMode.Continue)]
    public class AlbumManagerModel : IAlbumManagerModel
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumManagerModel(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        #region IAlbumManagerModel Members

        public IEnumerable<IAlbum> GetAlbumsByArtist(Artist artist)
        {
            //The repository only can work with concrete types.
            return _albumRepository.GetByArtist(artist).OfType<IAlbum>();
        }

        public void Save(IAlbum album)
        {
            //The repository only can work with concrete types.
            _albumRepository.MakePersistent((Album)album);
        }

        [PersistenceConversation(ConversationEndMode = EndMode.End)]
        public void AceptAll()
        {}
        [PersistenceConversation(ConversationEndMode = EndMode.Abort)]
        public void CancelAll()
        {}

        #endregion
    }
}