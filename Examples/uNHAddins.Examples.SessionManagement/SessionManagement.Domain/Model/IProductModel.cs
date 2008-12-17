namespace SessionManagement.Domain.Model
{
	public interface IProductModel
	{
		Product Save(Product product);
		void EndConversation();
	}
}
