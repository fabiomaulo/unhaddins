using System;
using log4net.Config;
using NHibernate;
using NUnit.Framework;
using uNhAddIns.SessionEasier;

namespace uNhAddIns.Test.SessionEasier
{
	[TestFixture]
	public class MultiSessionFactoryProviderFixture
	{
		public MultiSessionFactoryProviderFixture()
		{
			XmlConfigurator.Configure();
		}

		[Test, ExpectedException(typeof (ArgumentNullException))]
		public void CtorParameter()
		{
			new MultiSessionFactoryProvider(null);
		}

		[Test]
		public void DisposeWithoutInitialize()
		{
			var sfp = new MultiSessionFactoryProvider();
			using (var ls = new LogSpy(typeof (MultiSessionFactoryProvider)))
			{
				sfp.Dispose();
				Assert.That(ls.GetWholeMessages(), Text.DoesNotContain("Initialize a new session factory"));
			}
		}

		[Test]
		public void Disposing()
		{
			MultiSessionFactoryProvider sfp;
			ISessionFactory sf1;
			int disposed = 0;
			using (sfp = new MultiSessionFactoryProvider())
			{
				sfp.BeforeCloseSessionFactory += ((sender, e) => disposed++);
				sf1 = sfp.GetFactory(null);
			}
			Assert.That(disposed, Is.EqualTo(2));
			Assert.That(sf1.IsClosed);
			disposed = 0;
			sfp.Dispose();
			Assert.That(disposed, Is.EqualTo(0));
		}

		[Test]
		public void GetSessionFactory()
		{
			var sfp = new MultiSessionFactoryProvider();
			Assert.That(sfp.GetFactory(null), Is.Not.Null);
			using (var ls = new LogSpy(typeof (SessionFactoryProvider)))
			{
				sfp.Initialize();
				Assert.That(ls.GetWholeMessages(), Text.DoesNotContain("Initialize new session factories"));
			}
			ISessionFactory sf1 = sfp.GetFactory(null);
			ISessionFactory sf2 = sfp.GetFactory(null);
			Assert.That(ReferenceEquals(sf1, sf2));

			ISessionFactory sfp1 = sfp.GetFactory("FACTORY1");
			Assert.That(ReferenceEquals(sf1, sfp1));
			ISessionFactory sfp2 = sfp.GetFactory("FACTORY2");
			Assert.That(!ReferenceEquals(sfp1, sfp2));
		}

		[Test]
		public void Initialize()
		{
			var sfp = new MultiSessionFactoryProvider();
			using (var ls = new LogSpy(typeof (MultiSessionFactoryProvider)))
			{
				sfp.Initialize();
				Assert.That(ls.GetWholeMessages(), Text.Contains("Initialize new session factories"));
			}
			Assert.That(sfp.GetFactory(null), Is.Not.Null);
		}
	}
}