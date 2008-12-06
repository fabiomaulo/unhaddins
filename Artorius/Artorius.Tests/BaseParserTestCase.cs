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
		private static readonly IGrammar grammar;

		static BaseParserTestCase()
		{
			var cgl = new CompiledGrammarLoader(grammarPath);
			grammar = cgl.Load();
		}

		protected abstract string SymbolNameFromWhereStart { get; }

		public HqlParser NewParser()
		{
			Grammar shallowCopy = GetShallowCopy(grammar);
			Symbol whereStart = grammar.SymbolTable.FirstOrDefault(symbol => symbol.Name == SymbolNameFromWhereStart);
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

		private static Grammar GetShallowCopy(IGrammar orgGrammar)
		{
			var shallowCopy = new Grammar
			                  	{
			                  		CharSetTable = orgGrammar.CharSetTable,
			                  		DFATable = orgGrammar.DFATable,
			                  		DFAInitialStateIndex = orgGrammar.DFAInitialStateIndex,
			                  		IsCaseSensitive = orgGrammar.IsCaseSensitive,
			                  		LALRInitialStateIndex = orgGrammar.LALRInitialStateIndex,
			                  		LALRTable = orgGrammar.LALRTable,
			                  		RuleTable = orgGrammar.RuleTable,
			                  		SymbolTable = orgGrammar.SymbolTable,
			                  		StartSymbolIndex = orgGrammar.StartSymbolIndex
			                  	};
			foreach (var pair in orgGrammar.Parameters)
			{
				shallowCopy.Parameters.Add(pair);
			}
			return shallowCopy;
		}
	}
}