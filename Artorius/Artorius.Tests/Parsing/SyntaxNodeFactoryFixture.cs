using System.Linq;
using System.Text;
using GoldParsing.Engine;
using GoldParsing.Engine.Config;
using NHibernate.Hql.Ast.GoldImpls;
using NUnit.Framework;

namespace Artorius.Tests.Parsing
{
	[TestFixture]
	public class SyntaxNodeFactoryFixture
	{
		[Test]
		public void AllSymbolsAreRecognized()
		{
			var goldEmbeddedSymbols = new[] {"EOF", "Error", "Whitespace", "Comment End", "Comment Line", "Comment Start"};
			var cgl = new CompiledGrammarLoader(BaseParserTestCase.GrammarPath);
			IGrammar grammar = cgl.Load();
			var notRegister = new StringBuilder(100);
			var syntaxNodeFactory = new SyntaxNodeFactory();
			foreach (Symbol symbol in grammar.SymbolTable)
			{
				if (!syntaxNodeFactory.IsRegisterConverter(symbol.Name) && !goldEmbeddedSymbols.Contains(symbol.Name))
				{
					notRegister.AppendLine(symbol.Name);
				}
			}
			string message = notRegister.ToString();
			Assert.That(message.Length, Is.EqualTo(0), "Not register symbols.\n" + message);
		}
	}
}