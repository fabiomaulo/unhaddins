using System.Collections;
using NUnit.Framework;
using SessionManagement.Domain.Model;
using SessionManagement.Infrastructure.InversionOfControl;
using NUnit.Framework.Syntax.CSharp;
using System.Collections.Generic;

namespace SessionManagement.Domain.Tests.Model
{
	[TestFixture]
	public class IProductModelFixture : TestCase
	{
		private IProductModel productModel;

		protected override void OnSetUp()
		{
			productModel = IoC.Resolve<IProductModel>();
		}

		protected override void OnTearDown()
		{
			using (var session = sessions.OpenSession())
			{
				session.Delete("from Product");
				session.Flush();
			}
		}

		[Test]
		public void can_save_product()
		{
			Product product = CreateProduct("A1", "A1 Product", 17.25);
			Product savedProduct = productModel.Save(product);
			Assert.That(savedProduct, Is.Not.Null);
			Assert.That(savedProduct.Id > 0);
		}

		[Test]
		public void get_products_returns_emptylist_when_no_products()
		{
			IList<Product> products = productModel.GetProducts();
			Assert.That(products, Is.Not.Null, "Get products returned a null list");
			Assert.That(products.Count, Is.EqualTo(0));
		}

		[Test]
		public void get_products_returns_list_with_one_element_when_one_product_exists()
		{
			productModel.Save(CreateProduct("A1", "A1 Product", 17.25));
			productModel.EndConversation();
			Assert.That(productModel.GetProducts().Count, Is.EqualTo(1));
		}

		[Test]
		public void get_products_returns_list_with_four_element_when_four_products_exists()
		{
			productModel.Save(CreateProduct("A1", "A1 Product", 17.25));
			productModel.Save(CreateProduct("A2", "A2 Product", 17.25));
			productModel.Save(CreateProduct("A3", "A3 Product", 17.25));
			productModel.Save(CreateProduct("A4", "A4 Product", 17.25));
			productModel.EndConversation();
			Assert.That(productModel.GetProducts().Count, Is.EqualTo(4));
		}

		private Product CreateProduct(string code, string description, double price)
		{
			return new Product { Code = code, Description = description, Price = price };
		}

		#region Overrides of TestCase

		protected override IList Mappings
		{
			get { return new ArrayList(); }
		}

		#endregion
	}
}
