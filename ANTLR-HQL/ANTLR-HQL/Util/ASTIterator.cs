using System.Collections;
using System.Collections.Generic;
using Antlr.Runtime.Tree;

namespace NHibernate.Hql.Ast.ANTLR.Util
{
	/// <summary>
	/// Depth first iteration of an ANTLR AST.
	/// Author: josh
	/// Ported by: Steve Strong
	/// </summary>
	public class ASTIterator : IEnumerable<ITree>
	{
		private ITree _current;
		private readonly Stack<ITree> _stack = new Stack<ITree>();

		public ASTIterator(ITree tree)
		{
			_current = tree;
		}

		public IEnumerator<ITree> GetEnumerator()
		{
			Down();

			while (_current != null)
			{
				yield return _current;

				_current = _current.GetNextSibling();

				if (_current == null)
				{
					if (_stack.Count > 0)
					{
						_current = _stack.Pop();
					}
				}
				else
				{
					Down();
				}
			}
		}

		private void Down() {
			while ( _current != null && _current.ChildCount > 0) 
			{
				_stack.Push(_current);
				_current = _current.GetChild(0);
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
