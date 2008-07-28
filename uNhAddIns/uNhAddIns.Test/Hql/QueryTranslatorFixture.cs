namespace uNhAddIns.Test.Hql
{
	using System.Collections;
	using System.Collections.Generic;
	using NHibernate;
	using NHibernate.Cfg;
	using NUnit.Framework;
	using uNhAddIns.Hql.Gold;
	using TestCase=uNhAddIns.Test.TestCase;

	[TestFixture]
	public class QueryTranslatorFixture : TestCase
	{
		[SetUp]
		public void Init()
		{
			// Verify correct query translator is being used
			Assert.AreEqual(typeof (QueryTranslatorFactory), sessions.Settings.QueryTranslatorFactory.GetType());
		}

		/* Created the AstBuilderFixture, continued later
		[Test]
		public void BuildTree()
		{
			QueryTranslator translator = BuildTranslator("from Object");
		}
		*/

		#region Private Methods

		private QueryTranslator BuildTranslator(string query)
		{
			base.BuildSessionFactory();
			return new QueryTranslator("query", query, new Dictionary<string, IFilter>(), null);
		}

		#endregion

		#region TestCase

		protected override void Configure(Configuration configuration)
		{
			configuration.Properties.Add(Environment.QueryTranslator, typeof (QueryTranslatorFactory).AssemblyQualifiedName);
			base.Configure(configuration);
		}

		/// <summary>
		/// Mapping files used in the TestCase
		/// </summary>
		protected override IList Mappings
		{
			get { return new string[0]; }
		}

		#endregion
	}
}