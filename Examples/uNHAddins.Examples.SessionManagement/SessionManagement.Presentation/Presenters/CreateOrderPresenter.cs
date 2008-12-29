using System;
using SessionManagement.Domain;
using SessionManagement.Presentation.ViewInterfaces;
using SessionManagement.Domain.Model;

namespace SessionManagement.Presentation.Presenters
{
	public class CreateOrderPresenter : Presenter<ICreateOrderView>, IAddProductPresenter
	{
		private readonly IOrderModel orderModel;

		public CreateOrderPresenter(ICreateOrderView view, IOrderModel orderModel)
			: base(view)
		{
			this.orderModel = orderModel;
		}
	}
}
