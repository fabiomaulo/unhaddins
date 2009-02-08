using System;
using System.Collections.Generic;
using SessionManagement.Data.Repositories;
using SessionManagement.Domain.Model;
using uNhAddIns.Adapters;

namespace SessionManagement.Domain.Impl
{
	[PersistenceConversational]
	public class ModifyOrderModel : IModifyOrderModel
	{
		private readonly IOrderRepository orderRepository;
		private readonly IProductRepository productRepository;

		public ModifyOrderModel(IOrderRepository orderRepository, IProductRepository productRepository)
		{
			this.orderRepository = orderRepository;
			this.productRepository = productRepository;
		}

		#region Implementation of IProductManager

		[PersistenceConversation(ConversationEndMode = EndMode.Abort)]
		public void AbortConversation()
		{
			// Rollback the use case
		}

		[PersistenceConversation]
		public PurchaseOrder FindOrderOrCreateNew(string number, DateTime dateTime)
		{
			var order = orderRepository.GetOrderByNumberAndDate(number, dateTime.Date);

			if (order == null)
			{
				order = new PurchaseOrder { Date = dateTime, Number = number };
			}
			
			return order;
		}

		[PersistenceConversation(ConversationEndMode = EndMode.End)]
		public void Persist(PurchaseOrder order)
		{
			orderRepository.MakePersistent(order);
		}

		[PersistenceConversation]
		public IList<string> GetProductNumbers()
		{
			var products = new List<Product>(productRepository.GetAllProducts());
			return products.ConvertAll(p => p.Code);
		}

		#endregion
	}
}
