using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace GoldParsing.Engine
{
	/// <summary>
	/// This class contains the actions (reduce/shift) and goto information
	/// for a STATE in a LR parser. Essentially, this is just a row of actions in
	/// the LR state transition table. The only data structure is a list of
	/// LR Actions.
	/// </summary>
	public class LALRState
	{
		private readonly List<LALRAction> members= new List<LALRAction>();

		public IEnumerable<LALRAction> Members
		{
			get { return members; }
		}

		public LALRAction GetActionForSymbol(int symbolIndex)
		{
			return members.FirstOrDefault(lrAction => lrAction.Symbol.TableIndex == symbolIndex);
		}

		public LALRAction GetItem(int p_index)
		{
			if (p_index >= 0 && p_index < members.Count)
				return members[p_index];
			else
				return null;
		}

		/// <summary>Adds an new LRAction to this table.</summary>
		/// <param name="p_symbol">The Symbol.</param>
		/// <param name="p_action">The Action.</param>
		/// <param name="p_value">The value.</param>
		public void AddItem(Symbol p_symbol, Action p_action, int p_value)
		{
			members.Add(new LALRAction { Symbol = p_symbol, Action = p_action, Value = p_value });
		}

		public override String ToString()
		{
			var result = new StringBuilder(200);
			result.Append("LALR table:\n");
			foreach (LALRAction action in members)
			{
				result.Append("- ").Append(action).Append('\n');
			}
			return result.ToString();
		}

	}
}