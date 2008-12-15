using System;

namespace NHibernate.Hql.Ast.Tree
{
	public abstract class AbstractTwoOperandExpression : AbstractClauseNode, IExpression
	{
		internal AbstractTwoOperandExpression() {}

		protected AbstractTwoOperandExpression(IExpression leftOperand, string op, IExpression rightOperand)
		{
			if (leftOperand == null)
			{
				throw new ArgumentNullException("leftOperand");
			}
			if (rightOperand == null)
			{
				throw new ArgumentNullException("rightOperand");
			}
			children.Add(leftOperand);
			leftOperand.SetParent(this);
			children.Add(new SymbolNode(this, op));
			children.Add(rightOperand);
			rightOperand.SetParent(this);
		}

		public IExpression LeftOperand
		{
			get { return (IExpression)children[0]; }
		}

		public IExpression RightOperand
		{
			get { return (IExpression)children[2]; }
		}

		public string OperatorAsString
		{
			get { return children[1].ToString(); }
		}

		#region IExpression Members

		public abstract ExpType ExpressionType { get; }

		#endregion
	}
}