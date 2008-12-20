using System.Collections.Generic;

namespace SessionManagement.Domain.Model
{
	public interface IProductModel
	{
		Product Save(Product product);
		void AcceptConversation();
		void AbortConversation();
		IList<Product> GetProducts();
		bool ProductExists(Product product);
	}
}
