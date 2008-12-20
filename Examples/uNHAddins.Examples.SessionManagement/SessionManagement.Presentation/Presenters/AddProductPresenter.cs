using System;
using SessionManagement.Domain;
using SessionManagement.Presentation.ViewInterfaces;
using SessionManagement.Domain.Model;

namespace SessionManagement.Presentation.Presenters
{
	public class AddProductPresenter : Presenter<IAddProductView>, IAddProductPresenter
	{
		private readonly IProductModel productModel;

		public AddProductPresenter(IAddProductView view, IProductModel productModel)
			: base(view)
		{
			this.productModel = productModel;
			view.AddButtonPressed += view_AddButtonPressed;
		}

		void view_AddButtonPressed(object sender, TEventArgs<Product> e)
		{
			CreateNewProduct(e.Data);
		}

		private void CreateNewProduct(Product product)
		{
			try
			{
				if (!productModel.ProductExists(product))
				{
					productModel.Save(product);
					View.ShowMessage("Product added");
					View.Clean();
				}
				else
				{
					View.ShowMessage("Product already exists");
				}

				productModel.AcceptConversation();
			}
			catch (Exception ex)
			{
				View.ShowMessage(ex.Message);
			}	
		}
	}
}
