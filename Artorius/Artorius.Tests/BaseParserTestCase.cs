using System;
using System.Linq;
using GoldParsing.Engine;
using GoldParsing.Engine.Config;
using NHibernate.Hql.Ast;

namespace Artorius.Tests
{
	public abstract class BaseParserTestCase
	{
		private const string grammarPath = @"..\..\..\Grammar\Hql.cgt";
		private static readonly IParserSettings parserSettings;

		static BaseParserTestCase()
		{
			var cgl = new CompiledGrammarLoader(grammarPath);
			parserSettings = cgl.Load();
		}

		protected abstract string SymbolNameFromWhereStart { get; }

		public HqlParser NewParser()
		{
			Symbol whereStart = parserSettings.SymbolTable.FirstOrDefault(symbol => symbol.Name == SymbolNameFromWhereStart);
			if (whereStart != null)
			{
				((ParserSettings) parserSettings).StartSymbolIndex = whereStart.TableIndex;
			}
			else
			{
				throw new ArgumentException("Symbol name, from where start, not found");
			}
			return new HqlParser(parserSettings);
		}
	}
}