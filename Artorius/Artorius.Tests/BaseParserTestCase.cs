using System;
using System.Linq;
using GoldParsing.Engine;
using GoldParsing.Engine.Config;
using NHibernate.Hql.Ast.GoldImpls;

namespace Artorius.Tests
{
	public abstract class BaseParserTestCase
	{
		public const string GrammarPath = @"..\..\..\Grammar\Hql.cgt";
		private static readonly IGrammar grammar;
		private static readonly SyntaxNodeFactory syntaxNodeFactory= new SyntaxNodeFactory();

		static BaseParserTestCase()
		{
			var cgl = new CompiledGrammarLoader(GrammarPath);
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
			return new HqlParser(shallowCopy, syntaxNodeFactory);
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