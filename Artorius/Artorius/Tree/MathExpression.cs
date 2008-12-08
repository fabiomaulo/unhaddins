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

	public class MathExpression : AbstractClauseNode
	{
		internal MathExpression() {}

		public MathExpression(IClauseNode leftOperand, MathOp op, IClauseNode rightOperand)
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
			children.Add(new SymbolNode(this, MathOpToString(op)));
			children.Add(rightOperand);
			rightOperand.SetParent(this);
		}

		public IClauseNode LeftOperand
		{
			get { return (IClauseNode) children[0]; }
		}

		public IClauseNode RightOperand
		{
			get { return (IClauseNode) children[2]; }
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