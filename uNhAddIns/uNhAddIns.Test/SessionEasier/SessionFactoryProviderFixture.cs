using log4net.Config;
using NHibernate;
using NUnit.Framework;
using uNhAddIns.SessionEasier;

namespace uNhAddIns.Test.SessionEasier
{
	[TestFixture]
	public class SessionFactoryProviderFixture
	{
		public SessionFactoryProviderFixture()
		{
			XmlConfigurator.Configure();
		}

		[Test]
		public void DisposeWithoutInitialize()
		{
			var sfp = new SessionFactoryProvider();
			using (var ls = new LogSpy(typeof (SessionFactoryProvider)))
			{
				sfp.Dispose();
				Assert.That(ls.GetWholeMessages(), Text.DoesNotContain("Initialize a new session factory"));
			}
		}

		[Test]
		public void Disposing()
		{
			SessionFactoryProvider sfp;
			ISessionFactory sf1;
			using (sfp = new SessionFactoryProvider())
			{
				sf1 = sfp.GetFactory(null);
			}
			Assert.That(sfp.GetFactory(null), Is.Not.EqualTo(sf1));
		}

		[Test]
		public void GetSessionFactory()
		{
			var sfp = new SessionFactoryProvider();
			Assert.That(sfp.GetFactory(null), Is.Not.Null);
			using (var ls = new LogSpy(typeof (SessionFactoryProvider)))
			{
				sfp.Initialize();
				Assert.That(ls.GetWholeMessages(), Text.DoesNotContain("Initialize a new session factory"));
			}
			ISessionFactory sf1 = sfp.GetFactory(null);
			ISessionFactory sf2 = sfp.GetFactory(null);
			Assert.That(ReferenceEquals(sf1, sf2));
		}

		[Test]
		public void Initialize()
		{
			var sfp = new SessionFactoryProvider();
			using (var ls = new LogSpy(typeof (SessionFactoryProvider)))
			{
				sfp.Initialize();
				Assert.That(ls.GetWholeMessages(), Text.Contains("Initialize a new session factory"));
			}
			Assert.That(sfp.GetFactory(null), Is.Not.Null);
		}
	}
}