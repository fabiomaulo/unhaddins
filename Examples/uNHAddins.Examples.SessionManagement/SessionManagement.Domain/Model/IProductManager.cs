namespace SessionManagement.Domain.Model
{
	public interface IProductManager
	{
		Product Save(Product product);
		void EndConversation();
	}
}
