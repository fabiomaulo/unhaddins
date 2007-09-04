using System;
using System.Collections;
using NHibernate;

namespace uNhAddIns.Test.DynamicQuery
{
	public class DetachedDynQuery:TestCase 
	{
		protected override IList Mappings
		{
			get { return new string[] { "DynamicQuery.Animal.hbm.xml" }; }
		}

		protected override void OnSetUp()
		{
			base.OnSetUp();
		}

		protected override void OnTearDown()
		{
			using(ISession s = OpenSession())
			{
				s.Delete("from Human");
				s.Delete("from Animal");
			}
		}
	}
}
