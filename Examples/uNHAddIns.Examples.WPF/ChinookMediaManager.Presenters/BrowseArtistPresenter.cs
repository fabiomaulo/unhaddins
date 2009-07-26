using System;
using System.Collections.Generic;
using Caliburn.PresentationFramework.Actions;
using Caliburn.PresentationFramework.ApplicationModel;
using ChinookMediaManager.Domain;
using ChinookMediaManager.Domain.Model;
using ChinookMediaManager.Presenters.Interfaces;

namespace ChinookMediaManager.Presenters
{
   
    public class BrowseArtistPresenter : MultiPresenterManager, IBrowseArtistPresenter
    {
        private readonly IBrowseArtistModel _browseArtistModel;
        private readonly IAlbumManagementPresenter _albumManagementPresenter;

        //This service allow me to open a new window.
        private readonly IWindowManager _windowManager;

        public BrowseArtistPresenter(
            IBrowseArtistModel browseArtistModel, 
            IAlbumManagementPresenter browseArtistPresenter)
        {
            if (browseArtistModel == null) 
                throw new ArgumentNullException("browseArtistModel");
            if (browseArtistPresenter == null) 
                throw new ArgumentNullException("browseArtistPresenter");
            
            _browseArtistModel = browseArtistModel;
            _albumManagementPresenter = browseArtistPresenter;
        }

        public IList<Artist> Artists { get; private set; }

        [AsyncAction]
        public void LoadList()
        {
            Artists = _browseArtistModel.GetAllArtists();
            NotifyOfPropertyChange("Artists");
        }

        public void EditAlbums(Artist artist)
        {
            _albumManagementPresenter.OpenView(this, artist);
        }
    }


}