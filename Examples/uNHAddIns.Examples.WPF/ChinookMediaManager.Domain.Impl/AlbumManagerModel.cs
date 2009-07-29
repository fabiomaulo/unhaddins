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
            return _albumRepository.GetByArtist(artist);
        }

        public void Save(IAlbum album)
        {
            _albumRepository.MakePersistent(album);
        }

        [PersistenceConversation(ConversationEndMode = EndMode.End)]
        public void AceptAll()
        {}

        #endregion
    }
}