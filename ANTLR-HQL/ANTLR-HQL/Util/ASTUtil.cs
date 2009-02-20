using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;

namespace NHibernate.Hql.Ast.ANTLR.Util
{
	static public class ASTUtil
	{
		/// <summary>
		/// Creates a single node AST.
		/// </summary>
		/// <param name="astFactory">The factory.</param>
		/// <param name="type">The node type.</param>
		/// <param name="text">The node text.</param>
		/// <returns>A single node tree.</returns>
		public static CommonTree Create(ITreeAdaptor astFactory, int type, string text)
		{
			return (CommonTree)astFactory.Create(type, text);
		}

		/// <summary>
		/// Creates a single node AST as a sibling.
		/// </summary>
		/// <param name="astFactory">The factory.</param>
		/// <param name="type">The node type.</param>
		/// <param name="text">The node text.</param>
		/// <param name="prevSibling">The previous sibling.</param>
		/// <returns>A single node tree.</returns>
		public static CommonTree CreateSibling(ITreeAdaptor astFactory, int type, string text, ITree prevSibling)
		{
			CommonTree node = (CommonTree) astFactory.Create(type, text);

			return (CommonTree) AppendSibling(prevSibling, node);
		}

		/// <summary>
		/// Creates a 'binary operator' subtree, given the information about the
		/// parent and the two child nodes.
		/// </summary>
		/// <param name="factory">The AST factory.</param>
		/// <param name="parentType">The type of the parent node.</param>
		/// <param name="parentText">The text of the parent node.</param>
		/// <param name="child1">The first child.</param>
		/// <param name="child2">The second child.</param>
		/// <returns>A new sub-tree of the form "(parent child1 child2)"</returns>
		public static CommonTree CreateBinarySubtree(ITreeAdaptor factory, int parentType, string parentText, ITree child1, ITree child2)
		{
			CommonTree parent = (CommonTree)factory.Create(parentType, parentText);
			parent.AddChild(child1);
			parent.AddChild(child2);

			return parent;
		}

		public static void AddChildren(this CommonTree parent, params CommonTree[] children)
		{
			foreach (CommonTree child in children)
			{
				parent.AddChild(child);
			}
		}

		public static void InsertAsFirstChild(CommonTree parent, CommonTree child)
		{
			parent.Children.Insert(0, child);
		}

		public static ITree AppendSibling(ITree prevSibling, ITree newSibling)
		{
			ITree parent = prevSibling.Parent;
			int index = prevSibling.ChildIndex;
			List<ITree> siblings = new List<ITree>();

			for (int i = 0; i < parent.ChildCount; i++)
			{
				siblings.Add(parent.GetChild(i));
			}

			while (parent.ChildCount > 0)
			{
				parent.DeleteChild(0);
			}

			for (int i = 0; i <= index; i++)
			{
				parent.AddChild(siblings[i]);
			}

			parent.AddChild(newSibling);

			for (int i = index + 1; i < siblings.Count; i++)
			{
				parent.AddChild(siblings[i]);
			}

			return newSibling;
		}

		public static string GetPathText(ITree n)
		{
			StringBuilder buf = new StringBuilder();
			GetPathText(buf, n);
			return buf.ToString();
		}

		private static void GetPathText(StringBuilder buf, ITree n)
		{
			ITree firstChild = n.GetChild(0);

			// If the node has a first child, recurse into the first child.
			if (firstChild != null)
			{
				GetPathText(buf, firstChild);
			}

			// Append the text of the current node.
			buf.Append(n.Text);

			// If there is a second child (RHS), recurse into that child.
			if (firstChild != null && n.ChildCount > 1)
			{
				GetPathText(buf, n.GetChild(1));
			}
		}

		/// <summary>
		/// Returns the 'list' representation with some brackets around it for debugging.
		/// </summary>
		/// <param name="n">The tree.</param>
		/// <returns>The list representation of the tree.</returns>
		public static string GetDebugstring(ITree n)
		{
			StringBuilder buf = new StringBuilder();
			buf.Append("[ ");
			buf.Append((n == null) ? "{null}" : n.ToStringTree());
			buf.Append(" ]");
			return buf.ToString();
		}

		/// <summary>
		/// Determine if a given node (test) is contained anywhere in the subtree
		/// of another given node (fixture).
		/// </summary>
		/// <param name="fixture">The node against which to be checked for children.</param>
		/// <param name="test">The node to be tested as being a subtree child of the parent.</param>
		/// <returns>True if child is contained in the parent's collection of children.</returns>
		public static bool IsSubtreeChild(ITree fixture, ITree test)
		{
			for (int i = 0; i < fixture.ChildCount; i++)
			{
				ITree n = fixture.GetChild(i);

				if (n == test)
				{
					return true;
				}
				if (n.ChildCount > 0  && IsSubtreeChild(n, test))
				{
					return true;
				}
			}
			return false;
		}


		/// <summary>
		/// Finds the first node of the specified type in the chain of children.
		/// </summary>
		/// <param name="parent">The parent</param>
		/// <param name="type">The type to find.</param>
		/// <returns>The first node of the specified type, or null if not found.</returns>
		public static ITree FindTypeInChildren(ITree parent, int type)
		{
			for (int i = 0; i < parent.ChildCount; i++)
			{
				if (parent.GetChild(i).Type == type)
				{
					return parent.GetChild(i);
				}
			}
			return null;
		}

		public static IList<ITree> CollectChildren(ITree root, FilterPredicate predicate)
		{
			return new CollectingNodeVisitor(predicate).Collect(root);
		}
	}

	public class ASTTreeBuilder
	{
		private readonly ITreeAdaptor _factory;

		public ASTTreeBuilder(ITreeAdaptor factory)
		{
			_factory = factory;
		}

		public CommonTree CreateNode(int type, string text, params CommonTree[] children)
		{
			CommonTree parent = (CommonTree)_factory.Create(type, text);

			foreach (CommonTree child in children)
			{
				parent.AddChild(child);
			}

			return parent;
		}
	}

	static public class ASTUtilExtensions
	{
		public static ITree GetNextSibling(this ITree node)
		{
			if (node.Parent.ChildCount > (node.ChildIndex + 1))
			{
				return node.Parent.GetChild(node.ChildIndex + 1);
			}
			else
			{
				return null;
			}
		}

		// TODO - this would probably be ok on SqlNode...
		public static void SetType(this CommonTree node, int type)
		{
			node.Token.Type = type;
		}

		public static void DumpTree(this ITree node)
		{
			DumpTree(node, 0);
		}

		static void DumpTree(ITree node, int indent)
		{
			// TODO - replace Console.WriteLine with logging stuff
			Console.WriteLine("{2}({0}:{1})", node.Text, HqlParser.tokenNames[node.Type], new string(' ', indent));

			if (node.ChildCount > 0)
			{
				Console.WriteLine("{0}(", new string(' ', indent));
				for (int i = 0; i < node.ChildCount; i++)
				{
					DumpTree(node.GetChild(i), indent + 3);
				}
				Console.WriteLine("{0})", new string(' ', indent));
			}
		}
	}
}