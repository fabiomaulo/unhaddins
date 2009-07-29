using Caliburn.PresentationFramework.ApplicationModel;
using ChinookMediaManager.Domain.Model;
using ChinookMediaManager.Presenters.ModelInterfaces;

namespace ChinookMediaManager.Presenters.Interfaces
{
    public interface IEditAlbumPresenter : IPresenter
    {
        IEditableAlbum Album { get; }
        void Setup(IPresenterManager owner, IEditableAlbum album, IAlbumManagerModel albumManagerModel);
        void Cancel();
        void Acept();
    }
}