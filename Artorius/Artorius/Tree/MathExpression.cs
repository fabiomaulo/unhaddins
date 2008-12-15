using System;

namespace NHibernate.Hql.Ast.Tree
{
	public enum MathOp
	{
		Add,
		Subtract,
		Multiply,
		Divide
	}

	public class MathExpression : AbstractTwoOperandExpression
	{
		internal MathExpression() {}

		public MathExpression(IExpression leftOperand, MathOp op, IExpression rightOperand)
			:base(leftOperand, MathOpToString(op),rightOperand)
		{
		}

		public override ExpType ExpressionType
		{
			get { return ExpType.Math; }
		}

		public MathOp Operator
		{
			get { return ToMathOp(children[1].ToString()); }
		}

		private static MathOp ToMathOp(string op)
		{
			switch (op)
			{
				case "+":
					return MathOp.Add;
				case "-":
					return MathOp.Subtract;
				case "*":
					return MathOp.Multiply;
				case "/":
					return MathOp.Divide;
			}
			throw new QueryParserException("Unmanaged Math operator:" + op);
		}

		private static string MathOpToString(MathOp op)
		{
			switch (op)
			{
				case MathOp.Add:
					return "+";
				case MathOp.Subtract:
					return "-";
				case MathOp.Multiply:
					return "*";
				case MathOp.Divide:
					return "/";
				default:
					throw new ArgumentOutOfRangeException("op");
			}
		}
	}
}