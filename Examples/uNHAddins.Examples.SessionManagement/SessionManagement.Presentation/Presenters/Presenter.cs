using SessionManagement.Domain;

namespace SessionManagement.Presentation.Presenters
{
	public class Presenter<TView>
	{
		private TView view;
		protected virtual TView View
		{
			get { return view; }
			set { view = value; }
		}

		public Presenter(TView view)
		{
			this.view = view;
		}
	}
}