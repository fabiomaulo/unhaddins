using System.Collections;
using NHibernate;
using NUnit.Framework;
using uNHAddins.Examples.Caches.Tests;
using TestCase=uNHAddins.Examples.Caches.Tests.TestCase;

namespace uNHAddIns.Examples.Caches.Tests
{
	[TestFixture]
	public class SecondLevelFixture : TestCase
	{
		protected override IList Mappings
		{
			get { return new string[] {"Country.hbm.xml"}; }
		}

		protected override void OnTearDown()
		{
			using (ISession s = base.OpenSession())
			using (ITransaction t = s.BeginTransaction())
			{
				s.Delete("from System.Object");
				t.Commit();
			}
		}

		[Test]
		public void GetFromMultipleSessions()
		{
			using (new SqlLogSpy())
			{
				Country country;

				using (ISession s = base.OpenSession())
				using (ITransaction t = s.BeginTransaction())
				{
					country = new Country("Italy");
					s.Save(country);
					t.Commit();
				}

				log.Debug("Reading 100 times:");

				for (int i = 0; i < 100; i++)
				{
					using (ISession s = base.OpenSession())
					{
						s.Get<Country>(country.Id);
					}
				}
			}
		}
	}
}