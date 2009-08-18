using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using ChinookMediaManager.Domain;

namespace ChinookMediaManager.GUI.ViewModels
{
    public interface IAlbumManagerViewModel : INotifyPropertyChanged
    {
        void SetUp(Artist artist);
        IEnumerable<Album> Albums { get; }
        Album SelectedAlbum { get; set; }
        ICommand EditSelectedAlbumCommand { get; }

        ICommand SaveAllCommand { get; }
        ICommand CancelAllCommand { get; }

        ObservableCollection<IEditAlbumViewModel> AlbumEditWorkspaces { get; }
    }
}