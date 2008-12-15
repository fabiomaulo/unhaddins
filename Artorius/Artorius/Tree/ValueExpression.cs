using System;

namespace NHibernate.Hql.Ast.Tree
{
	public class ValueExpression : AbstractClauseNode, IExpression
	{
		internal ValueExpression() {}

		public ValueExpression(AbstractLiteralNode literal)
		{
			if (literal == null)
			{
				throw new ArgumentNullException("literal");
			}
			children.Add(literal);
		}

		#region Implementation of IExpression

		public ExpType ExpressionType
		{
			get { throw new NotImplementedException(); }
		}

		#endregion
	}
}