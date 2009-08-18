using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using ChinookMediaManager.Domain;

namespace ChinookMediaManager.GUI.ViewModels
{
    public interface IBrowseArtistViewModel : INotifyPropertyChanged
    {
        void LoadList();
        ICommand LoadListCommand { get; }

        ICommand EditAlbumsCommand { get; }

        IList<Artist> Artists { get; }
        Artist SelectedArtist { get; set; }
    }
}