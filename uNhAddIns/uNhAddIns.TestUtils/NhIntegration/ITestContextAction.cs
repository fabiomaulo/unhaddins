using System;

namespace uNhAddIns.TestUtils.NhIntegration
{
	public interface ITestContextAction
	{
		Action<ITestContext> Startup { get; }
		Action<ITestContext> Shutdown { get; }
	}
}