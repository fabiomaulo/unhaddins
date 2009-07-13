using Castle.Windsor;
using CommonServiceLocator.WindsorAdapter;
using Microsoft.Practices.ServiceLocation;
using NHibernate.Cfg;
using NHibernate.Engine;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using uNhAddIns.CastleAdapters.EnhancedBytecodeProvider;

namespace uNhAddIns.WPF.Tests
{
    public class IntegrationBaseTest
    {
        protected static readonly WindsorContainer container;
        protected Configuration cfg;
        protected ISessionFactoryImplementor sessions;

        static IntegrationBaseTest()
        {
            container = new WindsorContainer();
        }


        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            ConfigureWindsorContainer();

            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));
            Environment.UseReflectionOptimizer = true;
            Environment.BytecodeProvider = new EnhancedBytecode(container);

            cfg = new Configuration();

            cfg.AddAssembly(typeof(IntegrationBaseTest).Assembly);
            cfg.Configure();
            //cfg.Interceptor = new NhEntityNameInterceptor();
            new SchemaExport(cfg).Create(false, true);
            sessions = (ISessionFactoryImplementor)cfg.BuildSessionFactory();
        }

        protected virtual void ConfigureWindsorContainer()
        {}

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            new SchemaExport(cfg).Drop(false, true);
            sessions.Close();
            sessions = null;
            cfg = null;
        }
    }
}