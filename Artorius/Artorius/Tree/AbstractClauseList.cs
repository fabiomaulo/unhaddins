using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NHibernate.Hql.Ast.Tree
{
	public abstract class AbstractClauseList<T> : AbstractClauseNode, ICollection<T> where T : ISyntaxNode
	{
		internal protected AbstractClauseList() { }
		protected AbstractClauseList(params T[] list)
		{
			foreach (var clause in list)
			{
				children.Add(clause);
			}
		}

		#region Implementation of IEnumerable

		public IEnumerator<T> GetEnumerator()
		{
			return children.Cast<T>().GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#endregion

		#region Implementation of ICollection<T>

		public void Add(T item)
		{
			children.Add(item);
		}

		public void Clear()
		{
			throw new System.NotSupportedException();
		}

		public bool Contains(T item)
		{
			return children.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			throw new System.NotSupportedException();
		}

		public bool Remove(T item)
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