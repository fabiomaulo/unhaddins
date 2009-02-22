using System.Collections.Generic;
using NHibernate.Engine;
using Configuration=NHibernate.Cfg.Configuration;

namespace uNhAddIns.TestUtils.NhIntegration
{
	public interface IFunctionalTestSettings
	{
		bool AssertAllDataRemoved { get; }
		void Configure(Configuration configuration);
		void SchemaSetup(Configuration configuration);
		void SchemaShutdown(Configuration configuration);
		bool SchemaShutdownAfterFailure { get; }

		void LoadMappings(Configuration configuration);
		void BeforeSessionFactoryBuilt(Configuration configuration);
		void AfterSessionFactoryBuilt(ISessionFactoryImplementor sessionFactory);
	}
}