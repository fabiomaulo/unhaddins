using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using ChinookMediaManager.Domain;
using ChinookMediaManager.Domain.Model;
using ChinookMediaManager.GUI.ViewModels;
using ChinookMediaManager.Infrastructure;
using ChinookMediaManager.ViewModels.BaseClasses;

namespace ChinookMediaManager.ViewModels
{
    public class AlbumManagerViewModel : IAlbumManagerViewModel
    {
        private readonly IAlbumManagerModel _albumManagerModel;
        private readonly IViewFactory _viewFactory;
        private ObservableCollection<IEditAlbumViewModel> _workspaces;


        private RelayCommand _editSelectedAlbumCommand;
        private RelayCommand _saveAllCommand;
        private RelayCommand _cancelAllCommand;

        public AlbumManagerViewModel(
            IAlbumManagerModel albumManagerModel, 
            IViewFactory viewFactory)
        {
            _albumManagerModel = albumManagerModel;
            _viewFactory = viewFactory;
        }

        #region IAlbumManagerViewModel Members

        private IEnumerable<Album> _albums;
        public IEnumerable<Album> Albums
        {
            get { return _albums; }
            private set
            {
                _albums = value;
                OnPropertyChanged("Albums");
            }
        }

        public Album SelectedAlbum { get; set; }

        public ICommand EditSelectedAlbumCommand
        {
            get
            {
                if (_editSelectedAlbumCommand == null)
                    _editSelectedAlbumCommand = new RelayCommand(
                        o => EditSelectedAlbum(),
                        o => SelectedAlbum != null &&!AlbumEditWorkspaces.Any(ae => ae.Album == SelectedAlbum));
                return _editSelectedAlbumCommand;
            }
        }

        public ICommand SaveAllCommand
        {
            get
            {
                if (_saveAllCommand == null)
                    _saveAllCommand = new RelayCommand(o => _albumManagerModel.SaveAll());
                return _saveAllCommand;
            }
        }

        public ICommand CancelAllCommand
        {
            get
            {
                if (_cancelAllCommand == null)
                    _cancelAllCommand = new RelayCommand(o => _albumManagerModel.CancelAll());
                return _cancelAllCommand;
            }
        }

        void SetActiveWorkspace(IEditAlbumViewModel workspace)
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(AlbumEditWorkspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }

        public ObservableCollection<IEditAlbumViewModel> AlbumEditWorkspaces
        {
            get
            {
                if (_workspaces == null)
                {
                    _workspaces = new ObservableCollection<IEditAlbumViewModel>();
                    
                }
                return _workspaces;
            }
        }


        public void SetUp(Artist artist)
        {
            Albums = _albumManagerModel.GetAlbumsByArtist(artist);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        private void EditSelectedAlbum()
        {
            //Resolve a new instance of EditAlbumViewModel
            var newWp = _viewFactory.ResolveViewModel<IEditAlbumViewModel>();
            //Setup the new viewmodel.
            newWp.SetUp(SelectedAlbum, _albumManagerModel);
            //subscribe to close request.
            newWp.RequestClose += EditAlbumRequestClose;
            //add the new viewmodel to the workspace collection.
            AlbumEditWorkspaces.Add(newWp);
            //set the new viewmodel as the active wp.
            SetActiveWorkspace(newWp);
        }

        void EditAlbumRequestClose(object sender, EventArgs e)
        {
            var editAlbumViewModel = (IEditAlbumViewModel) sender;
            AlbumEditWorkspaces.Remove(editAlbumViewModel);
            editAlbumViewModel.RequestClose -= EditAlbumRequestClose;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler changed = PropertyChanged;
            if (changed != null) changed(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}