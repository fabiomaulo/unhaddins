using System;
using Caliburn.PresentationFramework.Actions;
using Caliburn.PresentationFramework.ApplicationModel;
using ChinookMediaManager.Domain.Model;
using ChinookMediaManager.Presenters.Interfaces;
using ChinookMediaManager.Presenters.ModelInterfaces;

namespace ChinookMediaManager.Presenters
{
    public class EditAlbumPresenter : Presenter, IEditAlbumPresenter
    {
        private IPresenterManager _owner;
        private IAlbumManagerModel _albumModel;

        #region IEditAlbumPresenter Members

        public IEditableAlbum Album { get; private set; }

        public void Setup(IPresenterManager owner, IEditableAlbum album, IAlbumManagerModel albumManagerModel)
        {
            Album = album;
            _owner = owner;
            _albumModel = albumManagerModel;
        }

        public void Cancel()
        {
            Album.CancelEdit();
            _owner.Shutdown(this);
        }

        [AsyncAction]
        public void Acept()
        {
            Album.EndEdit();
            _albumModel.Save(Album);
            _owner.Shutdown(this);
        }

        #endregion
    }
}