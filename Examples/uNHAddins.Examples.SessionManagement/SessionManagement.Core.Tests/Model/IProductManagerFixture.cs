using System.Collections;
using NUnit.Framework;
using SessionManagement.Data.NH.Tests;
using SessionManagement.Domain.Model;
using SessionManagement.Infrastructure.InversionOfControl;
using NUnit.Framework.Syntax.CSharp;

namespace SessionManagement.Domain.Tests.Model
{
	[TestFixture]
	public class IProductManagerFixture : TestCase
	{
		private IProductManager productManager;

		protected override void OnSetUp()
		{
			productManager = IoC.Resolve<IProductManager>();
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
			Product savedProduct = productManager.Save(product);
			Assert.That(savedProduct, Is.Not.Null);
			Assert.That(savedProduct.Id > 0);
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
