using log4net.Config;
using NHibernate.Cfg;
using NHibernate.Engine;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace ChinookMediaManager.Data.Test
{
    public class PersistenceFixtureBase
    {
        protected Configuration cfg;
        protected ISessionFactoryImplementor sessions;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            XmlConfigurator.Configure();
            cfg = new Configuration();
            cfg.Configure();
            //new SchemaExport(cfg).Create(false, true);
            sessions = (ISessionFactoryImplementor)cfg.BuildSessionFactory();
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            sessions.Close();
            sessions = null;
            cfg = null;
        }
    }
}