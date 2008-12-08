using System;

namespace NHibernate.Hql.Ast.Tree
{
	public class IntegerConstant : AbstractLiteralNode
	{
		private readonly System.Type returnType;
		private readonly long value;

		internal IntegerConstant(IClauseNode parentRule, string originalText) : base(parentRule, originalText)
		{
			returnType = typeof (int);
			value = long.Parse(originalText);
		}

		public IntegerConstant(IClauseNode parentRule, int value) : base(parentRule, value.ToString())
		{
			this.value = value;
			returnType = typeof (int);
		}

		public IntegerConstant(IClauseNode parentRule, long value) : base(parentRule, value.ToString())
		{
			this.value = value;
			returnType = typeof (long);
		}

		public long Value
		{
			get { return value; }
		}

		#region Overrides of AbstractLiteralNode

		public override System.Type ReturnType
		{
			get { return returnType; }
		}

		#endregion
	}
}