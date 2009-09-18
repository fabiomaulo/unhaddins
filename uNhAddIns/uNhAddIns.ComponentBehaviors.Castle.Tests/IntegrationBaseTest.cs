using System;
using Castle.Windsor;
//using NHibernate.ByteCode.Castle;
using NHibernate.ByteCode.Castle;
using NHibernate.Engine;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using uNhAddIns.CastleAdapters.EnhancedBytecodeProvider;
using uNhAddIns.ComponentBehaviors.Castle.EntityNameResolver;
using uNhAddIns.ComponentBehaviors.Castle.ProxyFactory;
using Environment=NHibernate.Cfg.Environment;

namespace uNhAddIns.ComponentBehaviors.Castle.Tests
{
    public class IntegrationBaseTest
    {
        protected WindsorContainer container;
        protected NHibernate.Cfg.Configuration cfg;
        protected ISessionFactoryImplementor sessions;

        //static IntegrationBaseTest()
        //{
           
        //}


        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            container = new WindsorContainer();
            log4net.Config.XmlConfigurator.Configure();

            ConfigureWindsorContainer();

            Environment.UseReflectionOptimizer = true;
            Environment.BytecodeProvider = new EnhancedBytecode(container);

            cfg = new NHibernate.Cfg.Configuration();
            //cfg.Properties[Environment.ProxyFactoryFactoryClass] = 

           

            cfg.Configure();
            
            cfg.Properties[Environment.ProxyFactoryFactoryClass] = GetProxyFactoryFactory();
 
            cfg.Properties[Environment.CurrentSessionContextClass] = "thread_static";
            cfg.RegisterEntityNameResolver();
            cfg.AddAssembly(typeof(IntegrationBaseTest).Assembly);
            //cfg.Configure();
            
            new SchemaExport(cfg).Create(false, true);
            sessions = (ISessionFactoryImplementor)cfg.BuildSessionFactory();
            

        }

        protected virtual string GetProxyFactoryFactory()
        {
            return typeof (ProxyFactoryFactory).AssemblyQualifiedName;
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