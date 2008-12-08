using System;

namespace NHibernate.Hql.Ast.Tree
{
	public class FloatConstant : AbstractLiteralNode
	{
		private readonly System.Type returnType;
		private readonly double value;

		internal FloatConstant(IClauseNode parentRule, string originalText) : base(parentRule, originalText)
		{
			returnType = typeof (int);
			value = long.Parse(originalText);
		}

		public FloatConstant(IClauseNode parentRule, float value) : base(parentRule, value.ToString())
		{
			this.value = value;
			returnType = typeof (float);
		}

		public FloatConstant(IClauseNode parentRule, double value) : base(parentRule, value.ToString())
		{
			this.value = value;
			returnType = typeof (double);
		}

		public double Value
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