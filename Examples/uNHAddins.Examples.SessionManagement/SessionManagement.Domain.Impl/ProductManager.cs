using SessionManagement.Data.Repositories;
using SessionManagement.Domain.Model;
using uNhAddIns.Adapters;

namespace SessionManagement.Domain.Impl
{
	[PersistenceConversational]
	public class ProductManager : IProductManager
	{
		private readonly IProductRepository productRepository;

		public ProductManager(IProductRepository productRepository)
		{
			this.productRepository = productRepository;
		}

		#region Implementation of IProductManager

		[PersistenceConversation]
		public Product Save(Product product)
		{
			return productRepository.MakePersistent(product);
		}

		[PersistenceConversation(EndConversation = true)]
		public void EndConversation()
		{
			// Commits the use case
		}

		#endregion
	}
}
