using System;
using System.Collections.Generic;
using System.Linq;

namespace NHibernate.Hql.Ast.Tree
{
	public class AliasedExpression : AbstractClauseNode, IEqualityComparer<AliasedExpression>
	{
		internal AliasedExpression() {}

		public AliasedExpression(Expression expression, string alias)
		{
			if (expression == null)
			{
				throw new ArgumentNullException("expression");
			}
			if (expression.Parent != null)
			{
				throw new ArgumentException("Invalid node reparenting.", "expression");
			}
			expression.SetParent(this);
			children.Add(expression);
			children.Add(new Identifier(this, alias));
		}

		public Expression Expression
		{
			get { return (Expression) children.First(x => x is Expression); }
		}

		public string Alias
		{
			get { return children.First(x => x is Identifier).ToString(); }
		}

		public override string ToString()
		{
			return string.Concat(Expression, " as ", Alias);
		}

		#region Implementation of IEqualityComparer<AliasedEntityNameExpression>

		private int? requestedHash;

		public bool Equals(AliasedExpression x, AliasedExpression y)
		{
			return x.GetHashCode() == y.GetHashCode();
		}

		public int GetHashCode(AliasedExpression obj)
		{
			if (!requestedHash.HasValue)
			{
				// the Expression is the Hash code of object (exactly the same reference)
				requestedHash = 317 ^ Expression.GetHashCode() ^ Alias.GetHashCode();
			}
			return requestedHash.Value;
		}

		#endregion
	}
}