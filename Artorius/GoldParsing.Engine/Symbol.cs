using System;
using System.Text;

namespace GoldParsing.Engine
{
	/// <summary>
	/// This class is used to store the nonterminals used by the DFA and LALR parser
	/// Symbols can be either terminals (which represent a class of tokens, such as
	/// identifiers) or non-terminals (which represent the rules and structures of
	/// the grammar). Symbols fall into several categories for use by the 
	/// GoldParser Engine which are enumerated in type <see cref="SymbolType"/> enum.
	/// </summary>
	public class Symbol : IEquatable<Symbol>
	{
		private readonly int hashCode;
		protected Symbol() : this(-1, string.Empty, SymbolType.Error) {}

		/// <summary>
		/// Creates a new Symbol object.
		/// </summary>
		public Symbol(int tableIndex, string name, SymbolType kind)
		{
			TableIndex = tableIndex;
			Name = name;
			Kind = kind;
			hashCode = 97 ^ Name.GetHashCode() ^ Kind.GetHashCode();
		}

		/// <summary>
		/// Gets the index of this symbol in the GoldParser's symbol table.
		/// </summary>
		public int TableIndex { get; private set; }

		/// <summary>
		/// Gets the name of the symbol.
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// Gets the type of the symbol.
		/// </summary>
		public SymbolType Kind { get; private set; }

		#region IEquatable<Symbol> Members

		public bool Equals(Symbol other)
		{
			if (other == null)
			{
				return false;
			}
			return hashCode == other.GetHashCode();
		}

		#endregion

		/// <summary>
		/// Returns true if the specified symbol is equal to this one.
		/// </summary>
		public override bool Equals(object obj)
		{
			var symbol = obj as Symbol;
			return Equals(symbol);
		}

		/// <summary>
		/// Returns the hashcode for the symbol.
		/// </summary>
		public override int GetHashCode()
		{
			return hashCode;
		}

		/// <summary>
		/// Returns the text representation of the symbol.
		/// </summary>
		/// <remarks>
		/// In the case of nonterminals, the name is delimited by angle brackets, 
		/// special terminals are delimited by parenthesis and terminals are delimited 
		/// by single quotes (if special characters are present).
		/// </remarks>
		public override string ToString()
		{
			var result = new StringBuilder(Name.Length + 2);

			if (Kind == SymbolType.NonTerminal)
			{
				result.Append("<").Append(Name).Append(">");
			}
			else if (Kind == SymbolType.Terminal)
			{
				result.Append(Name);
			}
			else
			{
				result.Append("(").Append(Name).Append(")");
			}

			return result.ToString();
		}

		protected void CopyFrom(Symbol origin)
		{
			Name = origin.Name;
			Kind = origin.Kind;
			TableIndex = origin.TableIndex;
		}
	}
}