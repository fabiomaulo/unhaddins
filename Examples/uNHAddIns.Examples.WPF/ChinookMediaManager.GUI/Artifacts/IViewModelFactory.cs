namespace ChinookMediaManager.GUI.Artifacts
{
	public interface IViewModelFactory
	{
		TViewModel CreateViewModel<TViewModel>() 
			where TViewModel : ViewModelBase;

		void DestroyViewModel<TViewModel>(TViewModel viewModel) 
			where TViewModel : ViewModelBase;
	}
}