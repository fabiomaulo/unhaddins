using System.Collections.Generic;
using Caliburn.PresentationFramework.ApplicationModel;
using ChinookMediaManager.Domain;

namespace ChinookMediaManager.Presenters.Interfaces
{
    public interface IAlbumManagerPresenter : IPresenterManager
    {
        void LoadData();
        void OpenView(IPresenter owner, Artist artist);
        //void SetUp(IPresenter owner, Artist artist);
        IEnumerable<IAlbum> Albums { get; }
    }
}