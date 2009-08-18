using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using ChinookMediaManager.Domain;
using ChinookMediaManager.Domain.Model;
using ChinookMediaManager.GUI.ViewModels;
using ChinookMediaManager.Infrastructure;
using ChinookMediaManager.ViewModels.BaseClasses;

namespace ChinookMediaManager.ViewModels
{
    public class BrowseArtistViewModel : IBrowseArtistViewModel
    {
        private readonly IBrowseArtistModel _browseArtistModel;
        private readonly IViewFactory _viewFactory;
        private RelayCommand _loadListCommand;
        private RelayCommand _editAlbumsCommand;


        public BrowseArtistViewModel(IBrowseArtistModel browseArtistModel, IViewFactory viewFactory)
        {
            if (browseArtistModel == null)
                throw new ArgumentNullException("browseArtistModel");
            _browseArtistModel = browseArtistModel;
            _viewFactory = viewFactory;
        }

        #region IBrowseArtistViewModel Members

        public virtual ICommand LoadListCommand
        {
            get
            {
                if (_loadListCommand == null)
                    _loadListCommand = new RelayCommand(o => LoadList());

                return new RelayCommand(o => LoadList());    
            }
        }

        private void EditAlbums()
        {
            var amViewModel = _viewFactory.ShowView<IAlbumManagerViewModel>();
            amViewModel.SetUp(SelectedArtist);
        }

        public ICommand EditAlbumsCommand
        {
            get
            {
                if (_editAlbumsCommand == null)
                    _editAlbumsCommand = new RelayCommand(o => EditAlbums(),
                                                          o => SelectedArtist != null);
                return _editAlbumsCommand;
            }
        }

        public virtual IList<Artist> Artists { get; private set; }
        public Artist SelectedArtist{get; set;}

        public virtual void LoadList()
        {
            Artists = _browseArtistModel.GetAllArtists();
            OnPropertyChanged("Artists");
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler changed = PropertyChanged;
            if (changed != null) changed(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}