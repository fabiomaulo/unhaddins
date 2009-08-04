using System;
using System.Collections.Generic;
using Caliburn.PresentationFramework.Actions;
using Caliburn.PresentationFramework.ApplicationModel;
using ChinookMediaManager.Domain;
using ChinookMediaManager.Domain.Model;
using ChinookMediaManager.Presenters.Interfaces;
using ChinookMediaManager.Presenters.ModelInterfaces;

namespace ChinookMediaManager.Presenters
{
    public class AlbumManagerPresenter : MultiPresenterManager, IAlbumManagerPresenter
    {
        private readonly IAlbumManagerModel _albumManagerModel;
        private readonly IWindowManager _windowManager;
        private readonly IEditAlbumPresenter _editAlbumPresenter;
        private Artist _artist;
        
        public AlbumManagerPresenter(IAlbumManagerModel albumManagerModel, IWindowManager windowManager, IEditAlbumPresenter editAlbumPresenter)
        {
            _albumManagerModel = albumManagerModel;
            _windowManager = windowManager;
            _editAlbumPresenter = editAlbumPresenter;
        }
  
        #region IAlbumManagerPresenter Members

        [AsyncAction]
        public void LoadData()
        {
            Albums = _albumManagerModel.GetAlbumsByArtist(_artist);
            NotifyOfPropertyChange("Albums");
        }

        public void OpenView(Artist artist)
        {
            if (artist == null) 
                throw new ArgumentNullException("artist");

            _artist = artist;
            _windowManager.Show(this);
        }

        public IEnumerable<IAlbum> Albums { get; private set; }

        

        #endregion

        public void LaunchEdit(IEditableAlbum album)
        {
            album.BeginEdit();
            _editAlbumPresenter.Setup(this, album, _albumManagerModel);
            this.Open(_editAlbumPresenter);
        }

        [AsyncAction]
        public void SaveAll()
        {
            _albumManagerModel.AcceptAll();
        }
    }
}