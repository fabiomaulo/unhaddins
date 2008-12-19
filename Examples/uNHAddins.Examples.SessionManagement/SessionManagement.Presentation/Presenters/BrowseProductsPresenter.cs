using System;
using System.Collections.Generic;
using SessionManagement.Domain;
using SessionManagement.Presentation.ViewInterfaces;
using SessionManagement.Domain.Model;

namespace SessionManagement.Presentation.Presenters
{
	public class BrowseProductsPresenter : Presenter<IBrowseProductsView>
	{
		private readonly IProductModel productModel;

		public BrowseProductsPresenter(IBrowseProductsView view, IProductModel productModel)
			: base(view)
		{
			this.productModel = productModel;
			view.ViewInitialized += view_ViewInitialized;
		}

		void view_ViewInitialized(object sender, EventArgs e)
		{
			IList<Product> products = productModel.GetProducts();
			View.SetProducts(products);
		}

		public void CreateNewProduct()
		{
			throw new NotImplementedException();
		}
	}
}
