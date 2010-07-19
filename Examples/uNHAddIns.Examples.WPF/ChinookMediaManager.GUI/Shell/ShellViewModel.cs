using System.Collections.ObjectModel;
using System.Windows.Input;
using ChinookMediaManager.GUI.Artifacts;

namespace ChinookMediaManager.GUI.Shell
{
	public class ShellViewModel : ViewModelBase
	{
		private readonly IViewModelFactory viewModelFactory;

		public ShellViewModel(IViewModelFactory viewModelFactory)
		{
			this.viewModelFactory = viewModelFactory;

			Presenters = new ObservableCollection<ViewModelBase>();

			CloseView = new RelayCommand(
				() =>
					{
						Presenters.Remove(CurrentPresenter);
						viewModelFactory.DestroyViewModel(CurrentPresenter);
						CurrentPresenter = null;
					},
				() => CurrentPresenter != null);

			//ShowAlbums = new RelayCommand(
			//    () => Presenters.Add(viewModelFactory.CreateViewModel<>()));
		}

		public ICommand CloseView { get; private set; }
		public ICommand ShowAlbums { get; private set; }

		public ObservableCollection<ViewModelBase> Presenters { get; private set; }

		private ViewModelBase currentPresenter;
		public ViewModelBase CurrentPresenter
		{
			get { return currentPresenter; }
			set
			{
				currentPresenter = value;
				OnPropertyChanged("CurrentPresenter");
			}
		}
	}
}