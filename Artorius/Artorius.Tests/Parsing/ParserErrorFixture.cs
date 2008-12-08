using System;
using GoldParsing.Engine;
using GoldParsing.Engine.Config;
using NHibernate.Hql.Ast;
using NHibernate.Hql.Ast.GoldImpls;
using NUnit.Framework;

namespace Artorius.Tests.Parsing
{
	[TestFixture]
	public class ParserErrorFixture
	{
		public const string GrammarPath = @"..\..\..\Grammar\TestExpression.cgt";
		private readonly IGrammar grammar;
		private readonly SyntaxNodeFactory syntaxNodeFactory = new SyntaxNodeFactory();

		public ParserErrorFixture()
		{
			var cgl = new CompiledGrammarLoader(GrammarPath);
			grammar = cgl.Load();
		}

		public HqlParser NewParser()
		{
			return new HqlParser(grammar, syntaxNodeFactory);
		}		[Test]
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