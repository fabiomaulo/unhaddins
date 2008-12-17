namespace SessionManagement.Presentation.ViewInterfaces
{
	public interface IAddProductView : IView
	{
		string Code { get; }
		string Description { get; }
		double Price { get; }
		
	}

	public interface IView
	{
		void Clean();
		void ShowMessage(string message);
	}
}
