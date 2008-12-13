using System;
using System.Collections.Generic;
using System.Text;
using SessionManagement.Presentation.ViewInterfaces;

namespace SessionManagement.Presentation.Presenters
{
	public class AddProductPresenter : Presenter<IAddProductView>
	{
		public AddProductPresenter(IAddProductView view) : base(view) { }


	}
}
