using System.Collections;
using NHibernate.Cfg;
using NUnit.Framework;
using SessionManagement.Data.NH.Tests;
using SessionManagement.Domain.Model;
using SessionManagement.Infrastructure.InversionOfControl;
using uNhAddIns.SessionEasier.Conversations;

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

		protected override void Configure(Configuration configuration)
		{
			configuration.Properties[Environment.CurrentSessionContextClass] =
				typeof(ThreadLocalConversationalSessionContext).AssemblyQualifiedName;
			base.Configure(configuration);
		}

		[Test]
		public void cannot_create_product_outside_a_conversation()
		{
			Product product = CreateProduct("A1", "A1 Product", 17.25);
			productManager.Save(product);
		}

		private Product CreateProduct(string code, string description, double price)
		{
			return new Product {Code = code, Description = description, Price = price};

		}

		#region Overrides of TestCase

		protected override IList Mappings
		{
			get { return new string[] { "Domain.Product.hbm.xml" }; }
		}

		#endregion
	}
}
