using System.Linq;

namespace NHibernate.Hql.Ast.Tree
{
	public class AliasedElementsExpression : AbstractAliasedEntityExpression
	{
		public ElementsExpression ElementsOf
		{
			get { return children.OfType<ElementsExpression>().First(); }
		}

		public string AssotiationPath
		{
			get { return ElementsOf.Path; }
		}

		#region Overrides of AbstractAliasedEntityExpression

		public override ISyntaxNode Alieased
		{
			get { return children.First(x => x is ElementsExpression); }
		}

		#endregion

		public override string ToString()
		{
			string a = Alias;
			return a != null ? string.Concat(ElementsOf, " as ", a) : ElementsOf.ToString();
		}
	}
}