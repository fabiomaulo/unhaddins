namespace GoldParsing.System
{
	/// <summary>
	/// While the Symbol represents a class of terminals and nonterminals,
	/// the Token represents an individual piece of information.
	/// </summary>
	public class Token : Symbol
	{
		public Token(Symbol parent)
		{
			CopyFrom(parent);
		}

		internal int State { get; set; }
		public object Data { get; set; }
	}
}