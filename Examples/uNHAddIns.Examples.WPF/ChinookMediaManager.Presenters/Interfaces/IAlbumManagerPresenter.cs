using System.Collections.Generic;
using Caliburn.PresentationFramework.ApplicationModel;
using ChinookMediaManager.Domain;

namespace ChinookMediaManager.Presenters.Interfaces
{
    public interface IAlbumManagerPresenter : IPresenterManager
    {
        void LoadData();
        void OpenView(Artist artist);
        IEnumerable<Album> Albums { get; }
        void LaunchEdit(Album album);
        void SaveAll();
    }
}