using System;

namespace SessionManagement.Domain.Model
{
	public interface IModifyOrderModel
	{
		void AcceptConversation();
		void AbortConversation();
		PurchaseOrder FindOrderOrCreateNew(string number, DateTime dateTime);
		void Persist(PurchaseOrder order);
	}
}
