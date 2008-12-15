using System;

namespace NHibernate.Hql.Ast.Tree
{
	public enum BinaryOp
	{
		And,
		Or
	}

	public class LogicalExpression : AbstractTwoOperandExpression
	{
		public LogicalExpression() {}
		public LogicalExpression(IExpression leftOperand, BinaryOp op, IExpression rightOperand)
			: base(leftOperand, BinaryOpToString(op), rightOperand) { }

		#region Implementation of IExpression

		public override ExpType ExpressionType
		{
			get { return ExpType.Logical; }
		}

		public BinaryOp Operator
		{
			get { return ToBinaryOp(children[1].ToString()); }
		}

		#endregion

		private static BinaryOp ToBinaryOp(string op)
		{
			switch (op.ToLowerInvariant())
			{
				case "and":
					return BinaryOp.And;
				case "or":
					return BinaryOp.Or;
			}
			throw new QueryParserException("Unmanaged Binary operator:" + op);
		}

		private static string BinaryOpToString(BinaryOp op)
		{
			switch (op)
			{
				case BinaryOp.And:
					return "and";
				case BinaryOp.Or:
					return "or";
				default:
					throw new ArgumentOutOfRangeException("op");
			}
		}
	}
}