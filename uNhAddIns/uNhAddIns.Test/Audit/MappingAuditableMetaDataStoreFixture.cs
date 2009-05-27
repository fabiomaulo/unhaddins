using System;
using System.Linq;
using NHibernate.Cfg;
using NUnit.Framework;
using uNhAddIns.Audit;

namespace uNhAddIns.Test.Audit
{
	[TestFixture]
	public class MappingAuditableMetaDataStoreFixture
	{
		const string EntityName = "uNhAddIns.Test.Audit.Simple";

		[Test]
		public void CtorProtection()
		{
			Assert.Throws<ArgumentNullException>(() => new MappingAuditableMetaDataStore(null));
		}

	  [Test]
		public void CanRegister()
		{
			var conf = new Configuration().Configure();
			conf.AddResource("uNhAddIns.Test.Audit.Simple.hbm.xml", GetType().Assembly);
			IAuditableMetaDataStore store = new MappingAuditableMetaDataStore(conf);
			store.RegisterAuditableEntityIfNeeded(EntityName).Should().Be.True();
			store.GetAuditableMetaData(EntityName).Should().Not.Be.Null();
			store.Contains(EntityName).Should().Be.True();
		}

		[Test]
		[Description("Does not cause problem with not existent info.")]
		public void NotRegister()
		{
			var conf = new Configuration().Configure();
			IAuditableMetaDataStore store = new MappingAuditableMetaDataStore(conf);
			store.RegisterAuditableEntityIfNeeded("NotExists").Should().Be.False();
			store.GetAuditableMetaData("NotExists").Should().Be.Null();
			store.Contains("NotExists").Should().Be.False();

			store.RegisterAuditableEntityIfNeeded(string.Empty).Should().Be.False();
			store.GetAuditableMetaData(string.Empty).Should().Be.Null();
			store.Contains(string.Empty).Should().Be.False();
		}

		[Test]
		[Description("Should register all properties.")]
		public void RegisterProperties()
		{
			var conf = new Configuration().Configure();
			conf.AddResource("uNhAddIns.Test.Audit.Simple.hbm.xml", GetType().Assembly);
			IAuditableMetaDataStore store = new MappingAuditableMetaDataStore(conf);
			store.RegisterAuditableEntityIfNeeded(EntityName);
			var meta = store.GetAuditableMetaData(EntityName);
			meta.Propeties.Count().Should().Be.GreaterThan(0);
			meta.Propeties.First().Should().Be.EqualTo("Description");
		}
	}
}