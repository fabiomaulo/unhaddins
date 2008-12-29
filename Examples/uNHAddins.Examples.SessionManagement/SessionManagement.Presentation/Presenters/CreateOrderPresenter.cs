using System;
using System.Collections.Generic;
using SessionManagement.Domain;
using SessionManagement.Presentation.ViewInterfaces;
using SessionManagement.Domain.Model;

namespace SessionManagement.Presentation.Presenters
{
	public class CreateOrderPresenter : Presenter<ICreateOrderView>, IAddProductPresenter
	{
		private readonly IModifyOrderModel modifyOrderModel;
		private PurchaseOrder currentOrder;

		public CreateOrderPresenter(ICreateOrderView view, IModifyOrderModel modifyOrderModel)
			: base(view)
		{
			this.modifyOrderModel = modifyOrderModel;
			view.AddButtonPressed += AddButtonPressed;
			view.SaveButtonPressed += view_SaveButtonPressed;
		}

		void view_SaveButtonPressed(object sender, EventArgs e)
		{
			modifyOrderModel.Persist(currentOrder);
		}

		void AddButtonPressed(object sender, EventArgs e)
		{
			currentOrder = modifyOrderModel.FindOrderOrCreateNew(View.OrderNumber, View.OrderDate);

			var orderLines = !currentOrder.IsNew ? currentOrder.OrderLines : new List<OrderLine>();

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
