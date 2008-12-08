using System;

namespace NHibernate.Hql.Ast.Tree
{
	public class StringConstant : AbstractLiteralNode
	{
		public StringConstant(IClauseNode parentRule, string value) : base(parentRule, value) {}

		#region Overrides of AbstractLiteralNode

		public override Type ReturnType
		{
			get { return typeof (string); }
		}

		#endregion
	}
}