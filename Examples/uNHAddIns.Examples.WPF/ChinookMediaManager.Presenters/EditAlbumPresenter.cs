using System;
using Caliburn.PresentationFramework.Actions;
using Caliburn.PresentationFramework.ApplicationModel;
using ChinookMediaManager.Domain;
using ChinookMediaManager.Domain.Model;
using ChinookMediaManager.Presenters.Interfaces;

namespace ChinookMediaManager.Presenters
{
    public class EditAlbumPresenter : Presenter, IEditAlbumPresenter
    {
        private IPresenterManager _owner;
        private IAlbumManagerModel _albumModel;

        #region IEditAlbumPresenter Members

        private Album _album;
        public Album Album
        {
            get { return _album; }
            private set
            {
                _album = value;
                NotifyOfPropertyChange("Album");
            }
        }

        public void Setup(IPresenterManager owner, Album album, IAlbumManagerModel albumManagerModel)
        {
            Album = album;
            _owner = owner;
            _albumModel = albumManagerModel;
        }

        [AsyncAction]
        public void Cancel()
        {
            _albumModel.CancelAlbum(Album);
            _owner.Shutdown(this);
        }
        
        [AsyncAction]
        public void Save()
        {
            _albumModel.SaveAlbum(Album);
            _owner.Shutdown(this);
        }

        public void AddNewEmptyTrack()
        {
            Album.AddTrack(new Track
                               {
                                   Name = "New track"
                               });
        }

        public void RemoveSelectedTrack(Track track)
        {
            Album.RemoveTrack(track);
        }

        #endregion
    }
}