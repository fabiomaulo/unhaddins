using Antlr.Runtime;
using Antlr.Runtime.Tree;
using NHibernate.Hql.Ast.ANTLR.Util;

namespace NHibernate.Hql.Ast.ANTLR.Tree
{
	/// <summary>
	/// A semantic analysis node, that points back to the main analyzer.
	/// Authoer: josh
	/// Ported by: Steve Strong
	/// </summary>
	public class HqlSqlWalkerNode : SqlNode, IInitializableNode
	{
		/**
		 * A pointer back to the phase 2 processor.
		 */
		private HqlSqlWalker walker;

		public HqlSqlWalkerNode(IToken token) : base(token)
		{
		}

		public virtual void Initialize(object param)
		{
			walker = (HqlSqlWalker)param;
		}

		public HqlSqlWalker Walker
		{
			get { return walker; }
		}

		public SessionFactoryHelperExtensions SessionFactoryHelper
		{
			get { return walker.SessionFactoryHelper; }
		}

		
		public ITreeAdaptor ASTFactory
		{
			get { return walker.ASTFactory; }
		}
		
		public AliasGenerator AliasGenerator
		{
			get { return walker.AliasGenerator; }
		}
	}
}