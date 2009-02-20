using System.Collections.Generic;

namespace SessionManagement.Domain.Model
{
	public interface IProductModel
	{
		Product Save(Product product);
		IList<Product> GetProducts();
		bool ProductExists(Product product);

		void EndConversation();
	}
}
