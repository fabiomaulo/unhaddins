using System;
using System.ComponentModel;
using System.Windows.Input;
using ChinookMediaManager.Domain;
using ChinookMediaManager.Domain.Model;
using ChinookMediaManager.GUI.ViewModels;
using ChinookMediaManager.ViewModels.BaseClasses;

namespace ChinookMediaManager.ViewModels
{
    public class EditAlbumViewModel : IEditAlbumViewModel
    {
        private RelayCommand _addNewTrackCommand;
        private Album _album;
        private IAlbumManagerModel _albumManagerModel;
        private ICommand _closeCommand;
        private ICommand _deleteSelectedTrackCommand;
        private ICommand _saveCommand;

        #region IEditAlbumViewModel Members

        public void SetUp(Album album, IAlbumManagerModel albumManagerModel)
        {
            if (album == null) throw new ArgumentNullException("album");
            if (albumManagerModel == null) throw new ArgumentNullException("albumManagerModel");
            Album = album;
            _albumManagerModel = albumManagerModel;
        }

        public Album Album
        {
            get { return _album; }
            private set
            {
                _album = value;
                OnPropertyChanged("Album");
            }
        }

        public string DisplayName
        {
            get
            {
                if (_album.Title.Length > 15)
                    return Album.Title.Substring(0, 15);
                return Album.Title;
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                    _closeCommand = new RelayCommand(o =>
                                                         {
                                                             _albumManagerModel.CancelAlbum(Album);
                                                             OnRequestClose();
                                                         });
                return _closeCommand;
            }
        }


        /// <summary>
        /// The command to save the album.
        /// </summary>
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new RelayCommand(o =>
                                                        {
                                                            _albumManagerModel.SaveAlbum(Album);
                                                            OnRequestClose();
                                                        },
                                                      o=> _albumManagerModel.IsValid(Album));
                return _saveCommand;
            }
        }


        public ICommand AddNewTrackCommand
        {
            get
            {
                if (_addNewTrackCommand == null)
                    _addNewTrackCommand = new RelayCommand(o => AddNewTrack());
                return _addNewTrackCommand;
            }
        }

        public ICommand DeleteSelectedTrackCommand
        {
            get
            {
                if (_deleteSelectedTrackCommand == null)
                    _deleteSelectedTrackCommand = new RelayCommand(o => DeleteSelectedTrack(),
                                                                   o => SelectedTrack != null);
                return _deleteSelectedTrackCommand;
            }
        }

        public Track SelectedTrack { get; set; }

        public event EventHandler RequestClose;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        private void AddNewTrack()
        {
            var track = new Track {Name = "New Track"};
            Album.AddTrack(track);
            SelectedTrack = track;
        }

        public void DeleteSelectedTrack()
        {
            Album.RemoveTrack(SelectedTrack);
            SelectedTrack = null;
        }

        private void OnRequestClose()
        {
            EventHandler handler = RequestClose;
            if (handler != null) handler(this, new EventArgs());
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler changed = PropertyChanged;
            if (changed != null) changed(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}