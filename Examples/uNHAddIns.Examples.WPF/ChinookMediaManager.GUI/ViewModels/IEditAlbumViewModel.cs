using System;
using System.ComponentModel;
using System.Windows.Input;
using ChinookMediaManager.Domain;
using ChinookMediaManager.Domain.Model;

namespace ChinookMediaManager.GUI.ViewModels
{
    public interface IEditAlbumViewModel : INotifyPropertyChanged
    {
        void SetUp(Album album, IAlbumManagerModel albumManagerModel);

        /// <summary>
        /// The album being edited.
        /// </summary>
        Album Album { get; }
       
        /// <summary>
        /// The title of the tab.
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// The command to close the tab.
        /// </summary>
        ICommand CloseCommand { get; }

        /// <summary>
        /// The command to save the album.
        /// </summary>
        ICommand SaveCommand { get; }

        /// <summary>
        /// Add a new track to the album.
        /// </summary>
        ICommand AddNewTrackCommand { get; }

        /// <summary>
        /// Delete the selected track.
        /// </summary>
        ICommand DeleteSelectedTrackCommand { get; }

        Track SelectedTrack { get; set; }

        event EventHandler RequestClose;
    }
}