using Antlr.Runtime;

namespace NHibernate.Hql.Ast.ANTLR.Tree
{
	public class ImpliedFromElement : FromElement
	{
		public ImpliedFromElement(IToken token) : base(token)
		{
		}

		public override bool IsImplied
		{
			get { return true; }
		}
	}
}
