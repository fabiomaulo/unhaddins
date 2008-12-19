using System.Linq;

namespace NHibernate.Hql.Ast.Tree
{
	public class ElementsExpression : AbstractClauseNode
	{
		internal ElementsExpression() { }
		public ElementsExpression(string assotiationPath)
		{
			children.Add(new IdentifierPath(this, assotiationPath));
		}

		public string Path
		{
			get { return children.OfType<IdentifierPath>().First().ToString(); }
		}

		public override string ToString()
		{
			return string.Format("elements_of({0})", Path);
		}
	}
}