using System;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework.Config;
using NUnit.Framework;

namespace uNhAddIns.ActiveRecord.Test
{
    public abstract class TestCase
    {
        public abstract Type[] Entities { get; }

        [TestFixtureSetUp]
        public void TestFixtureSetUp() {
            XmlConfigurationSource config = new XmlConfigurationSource("ARConfig.xml");
            ActiveRecordStarter.Initialize(config, Entities);
            ActiveRecordStarter.CreateSchema();
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown() {
            ActiveRecordStarter.DropSchema();
        }

        public virtual void OnSetUp() {
        }

        [SetUp]
        public void SetUp() {
            OnSetUp();
        }

        public virtual void OnTearDown() {
        }

        [TearDown]
        public void TearDown() {
            OnTearDown();
        }
    }
}