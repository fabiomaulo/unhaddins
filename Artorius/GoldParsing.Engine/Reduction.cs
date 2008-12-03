using System.Collections.Generic;
using System.Linq;

namespace GoldParsing.Engine
{
	/// <summary>
	/// This class is used by the engine to hold a reduced rule. 
	/// </summary>
	/// <remarks>
	/// Rather than contain a list of Symbols, a reduction contains a list of Tokens corresponding to the
	/// the rule it represents. 
	/// This class is important since it is used to store the actual source program parsed by the Engine.
	/// </remarks>
	public class Reduction
	{
		public Reduction(Rule parent)
		{
			Tokens = new List<Token>();
			Parent = parent;
		}

		public List<Token> Tokens { get; private set; }
		public Rule Parent { get; private set; }
		public object Tag { get; set; }

		public override string ToString()
		{
			return Parent.ToString();
		}

		public void Accept(IVisitor visitor)
		{
			visitor.Visit(this);
		}

		/// <summary>
		/// Makes the <c>IVisitor</c> visit the children of this <c>Reduction</c>.
		/// </summary>
		public void ChildrenAccept(IVisitor visitor)
		{
			foreach (Reduction reduction in Tokens.Where(x => x.Kind == SymbolType.NonTerminal).OfType<Reduction>())
			{
				reduction.Accept(visitor);
			}
		}
	}
}