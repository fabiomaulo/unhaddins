namespace NHibernate.Hql.Ast.Tree
{
	/// <summary>
	/// Only during Artorius development 
	/// </summary>
	public class NoConvertedExpression : AbstractClauseNode, IExpression
	{
		#region Implementation of IExpression

		public ExpType ExpressionType
		{
			get { throw new System.NotImplementedException(); }
		}

		#endregion
	}
}