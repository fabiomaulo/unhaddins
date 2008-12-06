using System.Collections.Generic;

namespace GoldParsing.Engine.Config
{
	public class Grammar : IGrammar
	{
		public Grammar()
		{
			Parameters = new Dictionary<string, string>(10);
		}
		public IDictionary<string, string> Parameters { get; private set; }
		public bool IsCaseSensitive { get; set; }
		public int StartSymbolIndex { get; set; }
		public Symbol[] SymbolTable { get; set; }
		public Rule[] RuleTable { get; set; }
		public string[] CharSetTable { get; set; }
		public DFAState[] DFATable { get; set; }
		public LALRState[] LALRTable { get; set; }
		public int DFAInitialStateIndex { get; set; }
		public int LALRInitialStateIndex { get; set; }
	}
}