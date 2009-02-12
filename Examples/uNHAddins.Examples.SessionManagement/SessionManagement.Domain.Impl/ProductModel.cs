using System;
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
			if (ProductExists(product))
				throw new Exception("Product exists");

			return productRepository.MakePersistent(product);
		}

		[PersistenceConversation(ConversationEndMode = EndMode.End)]
		public void AcceptConversation()
		{
		}

		[PersistenceConversation(ConversationEndMode = EndMode.End)]
		public IList<Product> GetProducts()
		{
			return productRepository.GetAllProducts();
		}
		
		[PersistenceConversation(ConversationEndMode = EndMode.End)]
		public bool ProductExists(Product product)
		{
			Product existingProduct = productRepository.GetProductByCode(product.Code);
			return existingProduct != null;
		}

		[PersistenceConversation(ConversationEndMode = EndMode.Abort)]
		public void AbortConversation()
		{
			// Rollback the use case
		}

		#endregion
	}
}
