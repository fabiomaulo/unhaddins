using System;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using Castle.ActiveRecord.Framework.Config;
using NUnit.Framework;

namespace uNhAddIns.ActiveRecord.Test
{
    public abstract class AbstractActiveRecordTestCase
    {
        public abstract Type[] Entities { get; }

        /// <summary>
        /// If Entities == null, each Test method will Inicialize ActiveRecord.
        /// </summary>
        [TestFixtureSetUp]
        public void TestFixtureSetUp() {
            
            if (Entities != null)
            {
                ActiveRecordStarter.Initialize(GetConfigSource(), Entities);
                ActiveRecordStarter.CreateSchema();
            }
        }

        public IConfigurationSource GetConfigSource() {
            return new XmlConfigurationSource("ARConfig.xml");
        }

        protected void Recreate(){
            ActiveRecordStarter.CreateSchema();
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown() {
            ActiveRecordStarter.DropSchema();
        }

        public virtual void OnSetUp() {
        }

        [SetUp]
        public void Init() {
            ActiveRecordStarter.ResetInitializationFlag();
            OnSetUp();
        }

        public virtual void OnTearDown() {
        }

        [TearDown]
        public void Drop() {
            OnTearDown();
            ActiveRecordStarter.DropSchema();
        }
    }
}