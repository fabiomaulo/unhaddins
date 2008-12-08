using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NHibernate.Hql.Ast.Tree
{
	public class AliasedEntityNameList :AbstractClauseNode, ICollection<AliasedEntityNameExpression>
	{
		internal AliasedEntityNameList() {}
		public AliasedEntityNameList(params AliasedEntityNameExpression[] list)
		{
			if(list == null || list.Length == 0)
			{
				throw new ArgumentNullException("list","The list must be not null and not empty.");
			}
			children.AddRange(list);
		}

		#region Implementation of IEnumerable

		public IEnumerator<AliasedEntityNameExpression> GetEnumerator()
		{
			return children.Cast<AliasedEntityNameExpression>().GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#endregion

		#region Implementation of ICollection<AliasedEntityNameExpression>

		public void Add(AliasedEntityNameExpression item)
		{
			children.Add(item);
		}

		public void Clear()
		{
			throw new System.NotSupportedException();
		}

		public bool Contains(AliasedEntityNameExpression item)
		{
			return children.Contains(item);
		}

		public void CopyTo(AliasedEntityNameExpression[] array, int arrayIndex)
		{
			throw new System.NotSupportedException();
		}

		public bool Remove(AliasedEntityNameExpression item)
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