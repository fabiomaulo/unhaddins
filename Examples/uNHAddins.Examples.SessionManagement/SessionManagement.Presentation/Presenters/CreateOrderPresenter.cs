using System;
using System.Collections.Generic;
using SessionManagement.Domain;
using SessionManagement.Infrastructure.InversionOfControl;
using SessionManagement.Presentation.ViewInterfaces;
using SessionManagement.Domain.Model;

namespace SessionManagement.Presentation.Presenters
{
	public class CreateOrderPresenter : Presenter<ICreateOrderView>
	{
		private readonly IModifyOrderModel modifyOrderModel;
		private PurchaseOrder currentOrder;

		public CreateOrderPresenter(ICreateOrderView view) : this(view, IoC.Resolve<IModifyOrderModel>())
		{
			
		}

		public CreateOrderPresenter(ICreateOrderView view, IModifyOrderModel modifyOrderModel)
			: base(view)
		{
			this.modifyOrderModel = modifyOrderModel;
			view.AddButtonPressed += AddButtonPressed;
			view.SaveButtonPressed += view_SaveButtonPressed;
		}

		void view_SaveButtonPressed(object sender, EventArgs e)
		{
			currentOrder.ClearLines();
			foreach (var line in View.OrderLines)
			{
				currentOrder.AddOrderLine(line);
			}

			modifyOrderModel.Persist(currentOrder);
			modifyOrderModel.AcceptConversation();
		}

		void AddButtonPressed(object sender, EventArgs e)
		{
			// If a conversation was pending then abort it.
			modifyOrderModel.AbortConversation();

			currentOrder = modifyOrderModel.FindOrderOrCreateNew(View.OrderNumber, View.OrderDate);
			var orderLines = !currentOrder.IsNew ? new List<OrderLine>(currentOrder.OrderLines) : new List<OrderLine>();
			View.ShowLines(orderLines);
		}

		#region Overrides of Presenter<ICreateOrderView>

		protected override void ViewInitialized(object sender, EventArgs e)
		{
			// no-op
		}

		#endregion
	}
}
