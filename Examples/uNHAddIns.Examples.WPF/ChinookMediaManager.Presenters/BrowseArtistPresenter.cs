using System;
using System.Collections.Generic;
using Caliburn.PresentationFramework.Actions;
using Caliburn.PresentationFramework.ApplicationModel;
using ChinookMediaManager.Domain;
using ChinookMediaManager.Domain.Model;
using ChinookMediaManager.Infrastructure;
using ChinookMediaManager.Presenters.Interfaces;

namespace ChinookMediaManager.Presenters
{
   
    public class BrowseArtistPresenter : MultiPresenterManager, IBrowseArtistPresenter
    {
        private readonly IBrowseArtistModel _browseArtistModel;
        private readonly IPresenterFactory _presenterFactory;
        //private readonly IAlbumManagerPresenter _albumManagerPresenter;

        //This service allow me to open a new window.
        private readonly IWindowManager _windowManager;

        public BrowseArtistPresenter(
            IBrowseArtistModel browseArtistModel, 
            IPresenterFactory presenterFactory)
        {
            if (browseArtistModel == null) 
                throw new ArgumentNullException("browseArtistModel");

            if (presenterFactory == null) 
                throw new ArgumentNullException("presenterFactory");


            _browseArtistModel = browseArtistModel;
            _presenterFactory = presenterFactory;
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
            var albumManagerPresenter = _presenterFactory.GetPresenter<IAlbumManagerPresenter>();
            albumManagerPresenter.OpenView(this, artist);
        }
    }


}