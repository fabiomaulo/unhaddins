namespace GoldParsing.Engine
{
	/// <summary>
	/// Each state in the Determinstic Finite Automata contains multiple edges which
	/// link to other states in the automata. This class is used to represent an edge.
	/// </summary>
	public class DFAEdge
	{
		public DFAEdge(string characters, int targetIndex)
		{
			Characters = characters;
			TargetIndex = targetIndex;
		}

		public int TargetIndex { get; private set; }
		public string Characters { get; private set; }

		public void AddCharacters(string characters)
		{
			Characters += characters;
		}

		public override string ToString()
		{
			return "DFA edge [chars=[" + Characters + "],action=" + TargetIndex + "]";
		}
	}
}