using System;
using NHibernate.Hql.Ast;
using NUnit.Framework;

namespace Artorius.Tests.Parsing
{
	[TestFixture]
	public class ParserErrorFixture: BaseParserTestCase
	{
		#region Overrides of BaseParserTestCase

		protected override string SymbolNameFromWhereStart
		{
			get { return "Expression"; }
		}

		#endregion

		[Test]
		public void BaseError()
		{
			var parser = NewParser();
			Assert.Throws<ArgumentException>(() => parser.Parse(""));
			Assert.Throws<ArgumentNullException>(() => parser.Parse(null));
		}

		[Test]
		public void Error()
		{
			var parser = NewParser();
			try
			{
				parser.Parse("123++");
				Assert.Fail();
			}
			catch (QuerySyntaxException e)
			{
				Assert.That(e.ParsingInfo.Query, Is.EqualTo("123++"));
				Assert.That(e.ParsingInfo.Line, Is.EqualTo(1));
				Assert.That(e.ParsingInfo.Column, Is.EqualTo(5));
			}
			try
			{
				parser.Parse("123\n+p.Age++5");
				Assert.Fail();
			}
			catch (QuerySyntaxException e)
			{
				Assert.That(e.ParsingInfo.Query, Is.EqualTo("123\n+p.Age++5"));
				Assert.That(e.ParsingInfo.Line, Is.EqualTo(2));
				Assert.That(e.ParsingInfo.Column, Is.EqualTo(8));
			}
		}

		[Test]
		public void ErrorEOF()
		{
			var parser = NewParser();
			try
			{
				parser.Parse("123(");
				Assert.Fail();
			}
			catch (QuerySyntaxException e)
			{
				Assert.That(e.ParsingInfo.Query, Is.EqualTo("123("));
				Assert.That(e.ParsingInfo.Line, Is.EqualTo(1));
				Assert.That(e.ParsingInfo.Column, Is.EqualTo(4));
			}
		}
	}
}