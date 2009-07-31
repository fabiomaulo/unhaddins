using System.Collections.Generic;
using Caliburn.PresentationFramework.ApplicationModel;
using ChinookMediaManager.Domain;
using ChinookMediaManager.Presenters.ModelInterfaces;

namespace ChinookMediaManager.Presenters.Interfaces
{
    public interface IAlbumManagerPresenter : IPresenterManager
    {
        void LoadData();
        void OpenView(Artist artist);
        //void SetUp(IPresenter owner, Artist artist);
        IEnumerable<IAlbum> Albums { get; }
        void LaunchEdit(IEditableAlbum album);
        void SaveAll();
    }
}