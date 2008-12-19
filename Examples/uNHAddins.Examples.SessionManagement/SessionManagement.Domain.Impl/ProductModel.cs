using System.Collections.Generic;
using SessionManagement.Data.Repositories;
using SessionManagement.Domain.Model;
using uNhAddIns.Adapters;

namespace SessionManagement.Domain.Impl
{
	[PersistenceConversational]
	public class ProductModel : IProductModel
	{
		private readonly IProductRepository productRepository;

		public ProductModel(IProductRepository productRepository)
		{
			this.productRepository = productRepository;
		}

		#region Implementation of IProductManager

		[PersistenceConversation]
		public Product Save(Product product)
		{
			return productRepository.MakePersistent(product);
		}

		[PersistenceConversation(ConversationEndMode = EndMode.End)]
		public void EndConversation()
		{
			// Commits the use case
		}

		[PersistenceConversation(ConversationEndMode = EndMode.End)]
		public IList<Product> GetProducts()
		{
			return productRepository.GetAllProducts();
		}

		[PersistenceConversation(ConversationEndMode = EndMode.Abort)]
		public void AbortConversation()
		{
			// Commits the use case
		}

		#endregion
	}
}
