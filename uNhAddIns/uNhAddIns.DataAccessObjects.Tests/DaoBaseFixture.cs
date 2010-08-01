using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CommonServiceLocator.WindsorAdapter;
using log4net;
using log4net.Config;
using Microsoft.Practices.ServiceLocation;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using uNhAddIns.DataAccessObjects.Impl;
using uNhAddIns.SessionEasier;

namespace uNhAddIns.DataAccessObjects.Tests {
	[TestFixture]
	public abstract class DaoBaseFixture {
		static readonly ILog log = LogManager.GetLogger(typeof (DaoBaseFixture));

		static DaoBaseFixture() {
			XmlConfigurator.Configure();
		}

		protected Configuration cfg;

		[TestFixtureSetUp]
		public void FixtureSetUp() {
			try {
				var container = new WindsorContainer();
				InitializeServiceLocator(container);
				RegisterSessionFactory(container);
				RegisterDaoFactory(container);
				RegisterDao(container);
			}
			catch (Exception e) {
				log.Error("Error while setting up the test fixture", e);
				throw;
			}
		}

		static void RegisterDaoFactory(IWindsorContainer container) {
			container.Register(Component.For<IDaoFactory>().ImplementedBy<DaoFactory>());
		}

		[TestFixtureTearDown]
		public void TestFixtureTearDown() {
			DropSchema();
			Cleanup();
		}

		void DropSchema() {
			new SchemaExport(cfg).Drop(false, true);
		}

		void Cleanup() {
			GetCurrentSession().Close();
			cfg = null;
		}

		public void RegisterSessionFactory(IWindsorContainer container) {
			var nhConfigurator = new DefaultSessionFactoryConfigurationProvider();
			nhConfigurator.AfterConfigure += CreateDb;
			var sfp = new SessionFactoryProvider(nhConfigurator);
			container.Register(Component.For<ISessionFactory>().Instance(sfp.GetFactory(null)));
		}

		void CreateDb(object sender, ConfigurationEventArgs e) {
			cfg = e.Configuration;
			new SchemaExport(cfg).Create(false, true);
		}

		protected void InitializeServiceLocator(WindsorContainer container) {
			var sl = new WindsorServiceLocator(container);
			container.Register(Component.For<IServiceLocator>().Instance(sl));
			ServiceLocator.SetLocatorProvider(() => sl);
		}

		protected abstract void RegisterDao(IWindsorContainer container);

		protected ISession GetCurrentSession() {
			var sessionFactory = (ISessionFactory) ServiceLocator.Current.GetService(typeof (ISessionFactory));
			return sessionFactory.GetCurrentSession();
		}

		protected IDaoFactory GetDaoFactory() {
			var daoFactory = (IDaoFactory) ServiceLocator.Current.GetService(typeof(IDaoFactory));
			return daoFactory;
		}
	}
}