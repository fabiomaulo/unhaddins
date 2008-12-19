using System.Collections.Generic;

namespace SessionManagement.Domain.Model
{
	public interface IProductModel
	{
		Product Save(Product product);
		void EndConversation();
		IList<Product> GetProducts();
	}
}
