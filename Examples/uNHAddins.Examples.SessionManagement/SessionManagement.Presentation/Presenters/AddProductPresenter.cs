using System;
using SessionManagement.Domain;
using SessionManagement.Presentation.ViewInterfaces;
using SessionManagement.Domain.Model;

namespace SessionManagement.Presentation.Presenters
{
	public class AddProductPresenter : Presenter<IAddProductView>
	{
		private readonly IProductModel productModel;

		public AddProductPresenter(IAddProductView view, IProductModel productModel)
			: base(view)
		{
			this.productModel = productModel;
		}

		public void CreateNewProduct()
		{
			try
			{
				var product = new Product
				{
					Code = View.Code,
					Description = View.Description,
					Price = View.Price
				};

				productModel.Save(product);
				productModel.EndConversation();
				View.ShowMessage("Product added");
				View.Clean();

			}
			catch (Exception)
			{
				View.ShowMessage("An error has occured while trying to save the product");
			}	
		}
	}
}
