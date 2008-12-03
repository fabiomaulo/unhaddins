namespace GoldParsing.System
{
	/// <summary>
	/// This class represents an action in a LALR State. 
	/// There is one and only one action for any given symbol.
	/// </summary>
	internal class LRAction
	{
		public Symbol Symbol { get; set; }
		public Action Action { get; set; }
		public int Value { get; set; }

		public override string ToString()
		{
			return "LALR action [symbol=" + Symbol + ",action=" + Action + ",value=" + Value + "]";
		}		
	}
}