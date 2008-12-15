namespace NHibernate.Hql.Ast.Tree
{
	public class ConstantExpression<T> : AbstractLiteralNode
	{
		public ConstantExpression(IClauseNode parentRule, T value, string originalText) : base(parentRule, originalText)
		{
			Value = value;
		}

		public ConstantExpression(IClauseNode parentRule, T value)
			: this(parentRule, value, value.ToString()) {}

		public T Value { get; private set; }

		#region Overrides of AbstractLiteralNode

		public override System.Type ReturnType
		{
			get { return typeof (T); }
		}

		#endregion
	}
}