using Caliburn.PresentationFramework.ApplicationModel;
using ChinookMediaManager.Domain;
using ChinookMediaManager.Domain.Model;

namespace ChinookMediaManager.Presenters.Interfaces
{
    public interface IEditAlbumPresenter : IPresenter
    {
        Album Album { get; }
        void Setup(IPresenterManager owner, Album album, IAlbumManagerModel albumManagerModel);
        void Cancel();
        void Save();
        void AddNewEmptyTrack();
        void RemoveSelectedTrack(Track track);
    }
}