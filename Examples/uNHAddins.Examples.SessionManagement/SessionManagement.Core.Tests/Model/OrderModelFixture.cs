using System;
using System.Collections;
using NUnit.Framework;
using SessionManagement.Domain.Impl;
using SessionManagement.Domain.Model;
using SessionManagement.Infrastructure.InversionOfControl;
using NUnit.Framework.Syntax.CSharp;
using System.Collections.Generic;
using SessionManagement.TestUtils;

namespace SessionManagement.Domain.Tests.Model
{
	[TestFixture]
	public class OrderModelFixture : TestCase
	{
		private IModifyOrderModel modifyOrderModel;

		protected override void OnSetUp()
		{
			modifyOrderModel = IoC.Resolve<IModifyOrderModel>();
		}

		protected override void OnTearDown()
		{
			using (var session = sessions.OpenSession())
			{
				session.Delete("from PurchaseOrder");
				session.Flush();
			}
		}

		[Test]
		public void can_save_order()
		{
			var purchaseOrder = new PurchaseOrder
			                    	{
			                    		Date = DateTime.Now,
			                    		Number = "N1"
			                    	};
			modifyOrderModel.Persist(purchaseOrder);
			Assert.That(purchaseOrder, Is.Not.Null);
			Assert.That(purchaseOrder.Id > 0);
		}

		#region Overrides of TestCase

		protected override IList Mappings
		{
			get { return new ArrayList(); }
		}

		#endregion
	}
}
