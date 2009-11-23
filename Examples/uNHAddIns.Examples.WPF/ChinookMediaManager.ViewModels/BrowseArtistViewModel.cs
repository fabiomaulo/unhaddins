using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using ChinookMediaManager.Domain;
using ChinookMediaManager.Domain.Model;
using ChinookMediaManager.Infrastructure;
using ChinookMediaManager.ViewModels.BaseClasses;

namespace ChinookMediaManager.ViewModels
{
	public class BrowseArtistViewModel : INotifyPropertyChanged
	{
		private readonly IBrowseArtistModel _browseArtistModel;
		private readonly IViewFactory _viewFactory;
		private ICommand _editAlbumsCommand;
		private IAsyncCommandWithResult<object, IList<Artist>> _loadListCommand;


		public BrowseArtistViewModel(IBrowseArtistModel browseArtistModel, IViewFactory viewFactory)
		{
			if (browseArtistModel == null)
				throw new ArgumentNullException("browseArtistModel");
			_browseArtistModel = browseArtistModel;
			_viewFactory = viewFactory;
		}

		public virtual IAsyncCommandWithResult<object, IList<Artist>> LoadListCommand
		{
			get
			{
				if (_loadListCommand == null)
					_loadListCommand = new AsyncCommandWithResult<object, IList<Artist>>(o => _browseArtistModel.GetAllArtists())
					                   	{
					                   		BlockInteraction = true,
					                   		Preview = o => Status = "Loading artists...",
					                   		Completed = (o, artists) =>
					                   			{
					                   				Artists = artists;
					                   				Status = "Finished";
					                   			}
					                   	};
						
				return _loadListCommand;
			}
		}

		private string _status;
		public virtual string Status { 
			get
			{
				return _status;
			}	
			set
			{
				_status = value;
				OnPropertyChanged("Status");
			} 
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

		private IList<Artist> _artists;

		public virtual IList<Artist> Artists
		{
			get { return _artists; }
			private set
			{
				_artists = value;
				OnPropertyChanged("Artists");
			}
		}

		public Artist SelectedArtist { get; set; }

		private void EditAlbums()
		{
			var amViewModel = _viewFactory.ShowView<AlbumManagerViewModel>();
			amViewModel.SetUp(SelectedArtist);
		}



		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler changed = PropertyChanged;
			if (changed != null) changed(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}