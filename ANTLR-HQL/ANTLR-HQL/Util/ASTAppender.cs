using System;
using Antlr.Runtime.Tree;

namespace NHibernate.Hql.Ast.ANTLR.Util
{
	/**
	 * Appends child nodes to a parent efficiently.
	 *
	 * @author Joshua Davis
	 */
	public class ASTAppender
	{
		private ITree parent;
		private ITreeAdaptor factory;

		public ASTAppender(ITreeAdaptor factory, ITree parent)
		{
			this.factory = factory;
			this.parent = parent;
		}

		public ITree Append(int type, String text, bool appendIfEmpty)
		{
			if (text != null && (appendIfEmpty || text.Length > 0))
			{
				ITree node = (ITree) factory.Create(type, text);
				parent.AddChild(node);
				return node;
			}
			else
			{
				return null;
			}
		}
	}
}
