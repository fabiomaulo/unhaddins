using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using ChinookMediaManager.Domain;

namespace ChinookMediaManager.GUI.ViewModels
{
    public interface IAlbumManagerViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Setup the view, load the albums collection.
        /// </summary>
        /// <param name="artist"></param>
        void SetUp(Artist artist);

        /// <summary>
        /// Expose a bindable collection of albums.
        /// </summary>
        IEnumerable<Album> Albums { get; }

        /// <summary>
        /// Get or Set the selected album.
        /// </summary>
        Album SelectedAlbum { get; set; }

        /// <summary>
        /// Open an edition workspace for editing the selected album.
        /// </summary>
        ICommand EditSelectedAlbumCommand { get; }

        /// <summary>
        /// Open an edition workspace for editing the selected album.
        /// </summary>
        ICommand EditNewAlbumCommand { get; }

        /// <summary>
        /// Commit all the changes.
        /// </summary>
        ICommand SaveAllCommand { get; }

        /// <summary>
        /// Discard all the changes.
        /// </summary>
        ICommand CancelAllCommand { get; }

        /// <summary>
        /// WorkSpace open.
        /// </summary>
        ObservableCollection<IEditAlbumViewModel> AlbumEditWorkspaces { get; }
    }
}