namespace SessionManagement.Presentation.Presenters
{
	public abstract class Presenter<TView>
	{
		protected TView View { get; set; }

		protected Presenter(TView view)
		{
			View = view;
		}
	}
}