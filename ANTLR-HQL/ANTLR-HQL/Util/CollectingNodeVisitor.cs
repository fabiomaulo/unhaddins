using System.Collections.Generic;
using Antlr.Runtime.Tree;

namespace NHibernate.Hql.Ast.ANTLR.Util
{
	public delegate bool FilterPredicate(ITree node);

	public class CollectingNodeVisitor : IVisitationStrategy
	{
		private readonly FilterPredicate predicate;
		private readonly List<ITree> collectedNodes = new List<ITree>();

		public CollectingNodeVisitor(FilterPredicate predicate)
		{
			this.predicate = predicate;
		}

		public void Visit(ITree node)
		{
			if ( predicate == null || predicate( node ) ) 
			{
				collectedNodes.Add( node );
			}
		}

		public IList<ITree> GetCollectedNodes() {
			return collectedNodes;
		}

		public IList<ITree> Collect(ITree root)
		{
			NodeTraverser traverser = new NodeTraverser( this );
			traverser.TraverseDepthFirst( root );
			return collectedNodes;
		}
	}
}
