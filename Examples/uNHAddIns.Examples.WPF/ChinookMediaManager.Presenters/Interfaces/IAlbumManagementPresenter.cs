using Caliburn.PresentationFramework.ApplicationModel;
using ChinookMediaManager.Domain;

namespace ChinookMediaManager.Presenters.Interfaces
{
    public interface IAlbumManagementPresenter : IPresenterManager
    {
        void LoadData();
        void OpenView(IPresenter owner, Artist artist);
        //void SetUp(IPresenter owner, Artist artist);
    }
}