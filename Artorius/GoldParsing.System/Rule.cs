using System.Collections.Generic;
using System.Text;

namespace GoldParsing.System
{
	/// <summary>
	/// The Rule class is used to represent the logical structures of the grammar.
	/// Rules consist of a head containing a nonterminal followed by a series of
	/// both nonterminals and terminals.
	/// </summary>
	public class Rule
	{
		private readonly List<Symbol> symbols = new List<Symbol>();

		public Rule(int tableIndex, Symbol head)
		{
			TableIndex = tableIndex;
			Head = head;
		}

		public ICollection<Symbol> Symbols
		{
			get { return symbols; }
		}

		public int TableIndex { get; private set; }

		/// <summary>
		/// The head symbol of this rule.
		/// </summary>
		/// <remarks>
		/// Not Terminal symbol
		/// </remarks>
		public Symbol Head { get; private set; }

		/// <summary>
		/// The name of this rule
		/// </summary>
		public string Name
		{
			get { return "<" + Head.Name + ">"; }
		}

		public string Definition
		{
			get
			{
				var result = new StringBuilder();
				foreach (Symbol symbol in Symbols)
				{
					result.Append(symbol).Append(' ');
				}
				return result.ToString();
			}
		}

		internal bool ContainsOneNonTerminal
		{
			get { return symbols.Count == 1 && symbols[0].Kind == SymbolType.NonTerminal; }
		}

		/// <summary>
		/// Returns the symbol in the body of the rule with the specified index. 
		/// </summary>
		/// <param name="index">The index</param>
		/// <returns>The symbol in the body or null where not available </returns>
		public Symbol GetSymbol(int index)
		{
			if (index >= 0 && index < symbols.Count)
			{
				return symbols[index];
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Returns the Backus-Noir representation.
		/// </summary>
		/// <returns>The Backus-Noir</returns>
		public override string ToString()
		{
			return Name + " ::= " + Definition;
		}
	}
}