using System;
using GoldParser;
using NHibernate;
using NUnit.Framework;

namespace uNhAddIns.Hql.Tests
{
	[TestFixture]
	public class EngineFixture
	{
		private HqlParser parser;

		[SetUp]
		public void Init()
		{
			parser = new HqlParser();
		}

		/// <summary>
		/// Useful to validate errors while loading the grammar or executing the parser
		/// </summary>
		[Test]
		public void ParseEmptyQuery()
		{
			Reduction root = parser.Execute("");
			Assert.IsNull(root);
		}

		[Test]
		[ExpectedException(typeof(QueryException))]
		public void ThrowOnInvalidQuery()
		{
			try
			{
				parser.Execute("This is an invalid query");
			}
			catch (Exception ex)
			{
				Assert.IsTrue(ex.Message.StartsWith("Error in query: [This is an invalid query]"));
				Console.WriteLine(ex.Message);

				throw;
			}
		}
	}
}