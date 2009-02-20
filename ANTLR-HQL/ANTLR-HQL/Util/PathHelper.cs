using Antlr.Runtime.Tree;
using NHibernate.Util;

namespace NHibernate.Hql.Ast.ANTLR.Util
{
	public static class PathHelper
	{
		private static readonly Logger log = new Logger();

		/// <summary>
		/// Turns a path into an AST.
		/// </summary>
		/// <param name="path">The path.</param>
		/// <param name="factory">The AST factory to use.</param>
		/// <returns>An HQL AST representing the path.</returns>
		public static ITree ParsePath(string path, ITreeAdaptor factory)
		{
			string[] identifiers = StringHelper.Split(".", path);
			ITree lhs = null;
			for (int i = 0; i < identifiers.Length; i++)
			{
				string identifier = identifiers[i];
				ITree child = ASTUtil.Create(factory, HqlSqlWalker.IDENT, identifier);
				if (i == 0)
				{
					lhs = child;
				}
				else
				{
					lhs = ASTUtil.CreateBinarySubtree(factory, HqlSqlWalker.DOT, ".", lhs, child);
				}
			}
			if (log.isDebugEnabled())
			{
				log.debug("parsePath() : " + path + " -> " + ASTUtil.GetDebugstring(lhs));
			}
			return lhs;
		}

		public static string GetAlias(string path)
		{
			return StringHelper.Root(path);
		}
	}
}
