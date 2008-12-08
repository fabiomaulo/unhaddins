using GoldParsing.Engine;
using GoldParsing.Engine.Config;
using NHibernate.Hql.Ast.GoldImpls;

namespace Artorius.Tests
{
	public class BaseParserTestCase
	{
		public const string GrammarPath = @"..\..\..\Grammar\Hql.cgt";
		private static readonly IGrammar grammar;
		private static readonly SyntaxNodeFactory syntaxNodeFactory = new SyntaxNodeFactory();

		static BaseParserTestCase()
		{
			var cgl = new CompiledGrammarLoader(GrammarPath);
			grammar = cgl.Load();
		}

		public HqlParser NewParser()
		{
			return new HqlParser(grammar, syntaxNodeFactory);
		}
	}
}