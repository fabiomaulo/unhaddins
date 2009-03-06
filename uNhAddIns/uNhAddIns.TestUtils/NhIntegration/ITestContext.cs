using uNhAddIns.SessionEasier;

namespace uNhAddIns.TestUtils.NhIntegration
{
	public interface ITestContext
	{
		IConfigurationProvider ConfigurationProvider { get; }
		ISessionFactoryProvider SessionFactoryProvider { get; }
		IMappingsLoader MappingsLoader { get; }
		ITestContextAction[] Actions { get; }
	}
}