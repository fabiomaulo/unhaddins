using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using ChinookMediaManager.Domain;
using ChinookMediaManager.Domain.Model;
using ChinookMediaManager.Infrastructure;
using ChinookMediaManager.ViewModels.BaseClasses;

namespace ChinookMediaManager.ViewModels
{
	public class AlbumManagerViewModel : INotifyPropertyChanged
	{
		private readonly IAlbumManagerModel _albumManagerModel;
		private readonly IViewFactory _viewFactory;
		private IEnumerable<Album> _albums;
		private Artist _artist;
		private RelayCommand _cancelAllCommand;
		private ICommand _editNewAlbumCommand;


		private RelayCommand _editSelectedAlbumCommand;
		private RelayCommand _saveAllCommand;
		private ObservableCollection<EditAlbumViewModel> _workspaces;

		public AlbumManagerViewModel(
			IAlbumManagerModel albumManagerModel,
			IViewFactory viewFactory)
		{
			_albumManagerModel = albumManagerModel;
			_viewFactory = viewFactory;
		}

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
						o => SelectedAlbum != null && !AlbumEditWorkspaces.Any(ae => ae.Album == SelectedAlbum));
				return _editSelectedAlbumCommand;
			}
		}

		/// <summary>
		/// Open an edition workspace for editing the new album.
		/// </summary>
		public ICommand EditNewAlbumCommand
		{
			get
			{
				if (_editNewAlbumCommand == null)
					_editNewAlbumCommand = new RelayCommand(() =>
						{
							SelectedAlbum = _albumManagerModel.CreateNewAlbum(_artist);
							EditSelectedAlbum();
						}
						);

				return _editNewAlbumCommand;
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

		public ObservableCollection<EditAlbumViewModel> AlbumEditWorkspaces
		{
			get
			{
				if (_workspaces == null)
				{
					_workspaces = new ObservableCollection<EditAlbumViewModel>();
					_workspaces.CollectionChanged += (sender, args) =>
						{
							if (args.Action == NotifyCollectionChangedAction.Add)
								foreach (var wp in args.NewItems.OfType<EditAlbumViewModel>())
									wp.RequestClose += EditAlbumRequestClose;

							if (args.Action == NotifyCollectionChangedAction.Remove)
								foreach (var wp in args.OldItems.OfType<EditAlbumViewModel>())
									wp.RequestClose -= EditAlbumRequestClose;
						};
				}
				return _workspaces;
			}
		}

		private void SetActiveWorkspace(EditAlbumViewModel workspace)
		{
			ICollectionView collectionView = CollectionViewSource.GetDefaultView(AlbumEditWorkspaces);
			if (collectionView != null)
				collectionView.MoveCurrentTo(workspace);
		}


		public virtual void SetUp(Artist artist)
		{
			_artist = artist;
			Albums = _albumManagerModel.GetAlbumsByArtist(artist);
		}


		public event PropertyChangedEventHandler PropertyChanged;

		private void EditSelectedAlbum()
		{
			//Resolve a new instance of EditAlbumViewModel
			var newWp = _viewFactory.ResolveViewModel<EditAlbumViewModel>();

			//Setup the new viewmodel.
			newWp.SetUp(SelectedAlbum, _albumManagerModel);

			//add the new viewmodel to the workspace collection.
			AlbumEditWorkspaces.Add(newWp);

			//set the new viewmodel as the active wp.
			SetActiveWorkspace(newWp);
		}

		private void EditAlbumRequestClose(object sender, EventArgs e)
		{
			var editAlbumViewModel = (EditAlbumViewModel) sender;
			AlbumEditWorkspaces.Remove(editAlbumViewModel);

			if (!Albums.Contains(editAlbumViewModel.Album) &&
			    editAlbumViewModel.Album.Id != 0)
			{
				Albums = new List<Album>(Albums) {editAlbumViewModel.Album};
			}
		}

		private void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler changed = PropertyChanged;
			if (changed != null) changed(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}