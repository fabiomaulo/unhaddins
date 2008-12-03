using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GoldParsing.Engine
{
	/// <summary>
	/// Represents a state in the Deterministic Finite Automata which is used by the tokenizer.
	/// </summary>
	public class DFAState
	{
		private readonly List<DFAEdge> edges= new List<DFAEdge>();

		public IEnumerable<DFAEdge> Edges
		{
			get { return edges; }
		}

		public int? AcceptSymbol { get; set; }

		public int EdgeCount
		{
			get { return edges.Count; }
		}

		public DFAEdge GetEdge(int p_index)
		{
			if (p_index >= 0 && p_index < edges.Count)
				return edges[p_index];
			else
				return null;
		}

		public void AddEdge(string characters, int targetIndex)
		{
			if (string.IsNullOrEmpty(characters))
			{
				edges.Add(new DFAEdge(characters, targetIndex));
			}
			else
			{
				var existent = edges.FirstOrDefault(edge => edge.TargetIndex == targetIndex);
				if (existent == null)
				{
					edges.Add(new DFAEdge(characters, targetIndex));
				}
				else
				{
					existent.AddCharacters(characters);
				}
			}
		}

		public override string ToString()
		{
			var result = new StringBuilder();
			result.Append("DFA state:\n");

			foreach (DFAEdge edge in edges)
			{
				result.Append("- ").Append(edge).Append("\n");
			}

			if (AcceptSymbol.HasValue)
				result.Append("- accept symbol: ").Append(AcceptSymbol).Append("\n");

			return result.ToString();
		}
	}
}