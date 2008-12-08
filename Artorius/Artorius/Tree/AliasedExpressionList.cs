using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NHibernate.Hql.Ast.Tree
{
	public class AliasedExpressionList : AbstractClauseNode, ICollection<AliasedExpression>
	{
				internal AliasedExpressionList() {}
				public AliasedExpressionList(params AliasedExpression[] list)
		{
			children.AddRange(list);
		}

		#region Implementation of IEnumerable

		public IEnumerator<AliasedExpression> GetEnumerator()
		{
			return children.Cast<AliasedExpression>().GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#endregion

		#region Implementation of ICollection<AliasedExpression>

		public void Add(AliasedExpression item)
		{
			children.Add(item);
		}

		public void Clear()
		{
			throw new System.NotSupportedException();
		}

		public bool Contains(AliasedExpression item)
		{
			return children.Contains(item);
		}

		public void CopyTo(AliasedExpression[] array, int arrayIndex)
		{
			throw new System.NotSupportedException();
		}

		public bool Remove(AliasedExpression item)
		{
			throw new System.NotSupportedException();
		}

		public int Count
		{
			get { return children.Count; }
		}

		public bool IsReadOnly
		{
			get { return false; }
		}

		#endregion
	}
}