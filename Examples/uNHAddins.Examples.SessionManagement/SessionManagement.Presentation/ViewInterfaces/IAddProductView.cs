namespace SessionManagement.Presentation.ViewInterfaces
{
	public interface IAddProductView : IView
	{
		string Code { get; }
		string Description { get; }
		double Price { get; }
		
	}
}
