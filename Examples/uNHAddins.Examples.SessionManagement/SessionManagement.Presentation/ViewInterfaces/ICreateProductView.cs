using System;
using SessionManagement.Domain;

namespace SessionManagement.Presentation.ViewInterfaces
{
	public interface ICreateOrderView : IView
	{
		event EventHandler<TEventArgs<PurchaseOrder>> AddButtonPressed;
	}
}
