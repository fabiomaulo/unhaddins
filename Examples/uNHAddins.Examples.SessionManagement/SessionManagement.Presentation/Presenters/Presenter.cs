namespace SessionManagement.Presentation.Presenters
{
	public class Presenter<TView>
	{
		protected TView View { get; set; }

		public Presenter(TView view)
		{
			View = view;
		}
	}
}