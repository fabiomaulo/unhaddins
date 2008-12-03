using System.Collections.Generic;

namespace GoldParsing.Engine
{
	/// <summary>
	/// 
	/// </summary>
	public interface IParserSettings
	{
		IDictionary<string, string> Parameters { get; }
		bool IsCaseSensitive { get; }
		int StartSymbolIndex { get; }
		Symbol[] SymbolTable { get; }
		Rule[] RuleTable { get; }
		string[] CharSetTable { get; }
		DFAState[] DFATable { get; }
		LALRState[] LALRTable { get; }
		int DFAInitialStateIndex { get; }
		int LALRInitialStateIndex { get; }
	}
}