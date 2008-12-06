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
			ParserSettings shallowCopy = GetShallowCopy(parserSettings);
			Symbol whereStart = parserSettings.SymbolTable.FirstOrDefault(symbol => symbol.Name == SymbolNameFromWhereStart);
			if (whereStart != null)
			{
				shallowCopy.StartSymbolIndex = whereStart.TableIndex;
			}
			else
			{
				throw new ArgumentException("Symbol name, from where start, not found");
			}
			return new HqlParser(shallowCopy);
		}

		private static ParserSettings GetShallowCopy(IParserSettings settings)
		{
			var shallowCopy = new ParserSettings
			                  	{
			                  		CharSetTable = settings.CharSetTable,
			                  		DFATable = settings.DFATable,
			                  		DFAInitialStateIndex = settings.DFAInitialStateIndex,
			                  		IsCaseSensitive = settings.IsCaseSensitive,
			                  		LALRInitialStateIndex = settings.LALRInitialStateIndex,
			                  		LALRTable = settings.LALRTable,
			                  		RuleTable = settings.RuleTable,
			                  		SymbolTable = settings.SymbolTable,
			                  		StartSymbolIndex = settings.StartSymbolIndex
			                  	};
			foreach (var pair in settings.Parameters)
			{
				shallowCopy.Parameters.Add(pair);
			}
			return shallowCopy;
		}
	}
}