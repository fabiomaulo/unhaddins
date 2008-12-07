using System;

namespace NHibernate.Hql.Ast.Tree
{
	public class IntegerLiteral : AbstractLiteralNode
	{
		public IntegerLiteral(IClauseNode parentRule) : base(parentRule) {}

		#region Overrides of AbstractLiteralNode

		public override Type ReturnType
		{
			get { return typeof (int); }
		}

		#endregion
	}
}