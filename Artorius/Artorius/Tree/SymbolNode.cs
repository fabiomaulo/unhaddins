namespace NHibernate.Hql.Ast.Tree
{
	/// <summary>
	/// A SymbolNode is a node without a particular interpretation (a token as is)
	/// </summary>
	/// <remarks>
	/// Examples are: "+", "!=", "("...
	/// </remarks>
	public class SymbolNode : AbstractTerminalNode
	{
		public SymbolNode(IClauseNode parentRule, string symbol) : base(parentRule)
		{
			Symbol = symbol;
		}
		public string Symbol { get; internal set; }
		public override string ToString()
		{
			return Symbol;
		}
	}
}