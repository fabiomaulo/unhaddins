using System.Collections.Generic;
using Caliburn.PresentationFramework.ApplicationModel;
using ChinookMediaManager.Domain;

namespace ChinookMediaManager.Presenters.Interfaces
{
    public interface IBrowseArtistPresenter : IPresenterManager
    {
        void LoadList();
        IList<Artist> Artists { get; }
        
    }
}