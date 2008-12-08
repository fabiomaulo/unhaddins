using System;
namespace NHibernate.Hql.Ast.Tree
{
	public class MathNegateExpression : AbstractClauseNode
	{
		internal MathNegateExpression() { }

		public MathNegateExpression(IClauseNode rightOperand)
		{
			if (rightOperand == null)
			{
				throw new ArgumentNullException("rightOperand");
			}
			children.Add(new SymbolNode(this, "-"));
			children.Add(rightOperand);
			rightOperand.SetParent(this);
		}

		public IClauseNode RightOperand
		{
			get { return (IClauseNode)children[1]; }
		}
	}
}