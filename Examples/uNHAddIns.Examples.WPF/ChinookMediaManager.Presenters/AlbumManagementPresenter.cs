using System;
using System.Collections.Generic;
using Caliburn.PresentationFramework.Actions;
using Caliburn.PresentationFramework.ApplicationModel;
using ChinookMediaManager.Domain;
using ChinookMediaManager.Domain.Model;
using ChinookMediaManager.Presenters.Interfaces;

namespace ChinookMediaManager.Presenters
{
    public class AlbumManagementPresenter : MultiPresenterManager, IAlbumManagementPresenter
    {
        private readonly IAlbumManagementModel _albumManagementModel;
        private readonly IWindowManager _windowManager;
        private IPresenter _owner;
        private Artist _artist;
        
        public AlbumManagementPresenter(IAlbumManagementModel albumManagementModel, IWindowManager windowManager)
        {
            _albumManagementModel = albumManagementModel;
            _windowManager = windowManager;
        }

        #region IAlbumManagementPresenter Members

        [AsyncAction]
        public void LoadData()
        {
            Albums = _albumManagementModel.GetAlbumsOfArtist(_artist);
            NotifyOfPropertyChange("Albums");
        }

        public void OpenView(IPresenter owner, Artist artist)
        {
            SetUp(owner, artist);
            _windowManager.Show(this);
        }

        public IEnumerable<Album> Albums { get; private set; }

        public void SetUp(IPresenter owner, Artist artist)
        {
            _owner = owner;
            _artist = artist;
            
        }

        #endregion
    }
}