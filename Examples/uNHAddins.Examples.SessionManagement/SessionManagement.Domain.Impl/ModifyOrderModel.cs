using System;
using log4net;
using SessionManagement.Data.Repositories;
using SessionManagement.Domain.Events;
using SessionManagement.Domain.Model;
using uNhAddIns.Adapters;

namespace SessionManagement.Domain.Impl
{
	[PersistenceConversational(IdPrefix = "Notify")]
	public class ModifyOrderModel : IModifyOrderModel
	{
		private readonly IOrderRepository orderRepository;
		private static readonly ILog log = LogManager.GetLogger(typeof(ModifyOrderModel));

		public ModifyOrderModel(IOrderRepository orderRepository)
		{
			this.orderRepository = orderRepository;
			EventSource.ConversationEnded += EventSource_ConversationEnded;
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
			log.Info("Before persisting");
			orderRepository.MakePersistent(order);
			log.Info("Persisted");
		}

		void EventSource_ConversationEnded(object sender, EventArgs e)
		{
			log.Info("Conversation ended");
			EventSource.ConversationEnded += EventSource_ConversationEnded;
		}

		#endregion
	}
}
