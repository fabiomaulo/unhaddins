using Caliburn.PresentationFramework.Screens;
using Caliburn.PresentationFramework.ViewModels;

namespace ChinookMediaManager.GUI.Shell
{

	public interface IShellViewModel
	{
	}

	public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, IShellViewModel
	{
		private readonly IViewModelFactory viewModelFactory;

		public ShellViewModel(IViewModelFactory viewModelFactory)
		{
			this.viewModelFactory = viewModelFactory;
		}

		
		public void ShutdownPresenter(IScreen presenter)
		{
			CloseItem(presenter);
		}
	}
}