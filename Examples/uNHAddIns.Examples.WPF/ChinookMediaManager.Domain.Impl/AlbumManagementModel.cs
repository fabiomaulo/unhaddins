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
    public class AlbumManagementModel : IAlbumManagementModel
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumManagementModel(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        #region IAlbumManagementModel Members

        public IEnumerable<Album> GetAlbumsOfArtist(Artist artist)
        {
            //album.Artist.Equals(artist)
            return _albumRepository.Where(album => album.Artist != null && album.Artist.Id == artist.Id ).ToList();
            //.AsObservable();
        }

        #endregion
    }
}