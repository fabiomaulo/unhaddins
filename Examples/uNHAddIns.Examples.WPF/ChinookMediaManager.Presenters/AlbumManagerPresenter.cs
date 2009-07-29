using System;
using System.Collections.Generic;
using Caliburn.PresentationFramework.Actions;
using Caliburn.PresentationFramework.ApplicationModel;
using ChinookMediaManager.Domain;
using ChinookMediaManager.Domain.Model;
using ChinookMediaManager.Presenters.Interfaces;

namespace ChinookMediaManager.Presenters
{
    public class AlbumManagerPresenter : MultiPresenterManager, IAlbumManagerPresenter
    {
        private readonly IAlbumManagerModel _albumManagerModel;
        private readonly IWindowManager _windowManager;
        private IPresenter _owner;
        private Artist _artist;
        
        public AlbumManagerPresenter(IAlbumManagerModel albumManagerModel, IWindowManager windowManager)
        {
            _albumManagerModel = albumManagerModel;
            _windowManager = windowManager;
        }
  
        #region IAlbumManagerPresenter Members

        [AsyncAction]
        public void LoadData()
        {
            Albums = _albumManagerModel.GetAlbumsByArtist(_artist);
            NotifyOfPropertyChange("Albums");
        }

        public void OpenView(IPresenter owner, Artist artist)
        {
            if (owner == null) 
                throw new ArgumentNullException("owner");
            if (artist == null) 
                throw new ArgumentNullException("artist");

            SetUp(owner, artist);
            _windowManager.Show(this);
        }

        public IEnumerable<IAlbum> Albums { get; private set; }

        private void SetUp(IPresenter owner, Artist artist)
        {
            _owner = owner;
            _artist = artist;
            
        }

        #endregion
    }
}