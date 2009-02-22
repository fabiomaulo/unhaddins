using System;
using NHibernate;
using uNhAddIns.TestUtils.NhIntegration;

namespace uNhAddIns.Test
{
	public class IntegrationTest : FunctionalTestCase
	{
		public void EnclosingInTransaction(Action<ISession> work)
		{
			using (ISession s = SessionFactory.OpenSession())
			{
				using (ITransaction tx = s.BeginTransaction())
				{
					work(s);
					tx.Commit();
				}
			}
		}
	}
}