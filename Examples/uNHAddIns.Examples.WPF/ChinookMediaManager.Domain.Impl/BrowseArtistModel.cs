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
    public class BrowseArtistModel : IBrowseArtistModel
    {
        private readonly IArtistRepository _artistRepository;

        public BrowseArtistModel(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        #region IBrowseArtistModel Members

        [PersistenceConversation(ConversationEndMode = EndMode.End)]
        public IList<Artist> GetAllArtists()
        {
            return _artistRepository.OrderBy(a => a.Name).ToList();
        }

        #endregion
    }
}