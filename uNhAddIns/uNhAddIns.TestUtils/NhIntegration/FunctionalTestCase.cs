using NUnit.Framework;

namespace uNhAddIns.TestUtils.NhIntegration
{
	public class FunctionalTestCase : FunctionalTestCaseTemplate
	{
		protected IFunctionalTestSettings settings;

		public FunctionalTestCase()
		{
			// Convention: mappings are in the same namespace of the test
			var ml = new NamespaceMappingsLoader(GetType().Assembly, GetType().Namespace);
			var s = new DefaultFunctionalTestSettings(ml);
			settings = s;
		}

		public FunctionalTestCase(string baseName, string[] mappings)
		{
			var ml = new ResourceWithRelativeNameMappingsLoader(GetType().Assembly, baseName, mappings);
			var s = new DefaultFunctionalTestSettings(ml);
			settings = s;
		}

		#region Overrides of AbstractFunctionalTestCase

		protected override IFunctionalTestSettings Settings
		{
			get { return settings; }
		}

		#endregion

		[TestFixtureSetUp]
		public void FixtureSetUp()
		{
			SetUpNhibernate();
		}

		[TestFixtureTearDown]
		public void FixtureTearDown()
		{
			ShutdownNhibernate();
		}

		[TearDown]
		public void TearDown()
		{
			AssertAllDataRemovedIfNeeded();
		}

	}
}