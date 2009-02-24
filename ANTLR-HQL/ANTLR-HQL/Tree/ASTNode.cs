using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime;
using Antlr.Runtime.Tree;

namespace NHibernate.Hql.Ast.ANTLR.Tree
{
	public class ASTNode : IASTNode, ITree
	{
		private int _startIndex;
		private int _stopIndex;
		private int _childIndex;
		private IASTNode _parent;
		private readonly IToken _token;
		private List<IASTNode> _children;

		public ASTNode(IToken token)
		{
			_startIndex = -1;
			_stopIndex = -1;
			_childIndex = -1;
			_token = token;
		}

		public ASTNode(ASTNode other)
		{
			_startIndex = -1;
			_stopIndex = -1;
			_childIndex = -1;
			_token = other._token;
			_startIndex = other._startIndex;
			_stopIndex = other._stopIndex;
			
		}

		public bool IsNil
		{
			get { return _token == null; }
		}

		public int Type
		{
			get
			{
				if (_token == null)
				{
					return 0;
				}

				return _token.Type;
			}
			set
			{
				if (_token != null)
				{
					_token.Type = value;
				}
			}
		}

		public virtual string Text
		{
			get
			{
				if (_token == null)
				{
					return null;
				}

				return _token.Text;
			}
			set
			{
				if (_token != null)
				{
					_token.Text = value;
				}
			}
		}

		public IASTNode Parent
		{
			get { return _parent; }
			set { _parent = value; }
		}

		public int ChildCount
		{
			get
			{
				if (_children == null)
				{
					return 0;
				}
				return _children.Count;
			}
		}

		public int ChildIndex
		{
			get { return _childIndex; }
		}

		public int Line
		{
			get
			{
				if ((_token != null) && (_token.Line != 0))
				{
					return _token.Line;
				}
				if (ChildCount > 0)
				{
					return GetChild(0).Line;
				}
				return 0;
			}
		}

		public int CharPositionInLine
		{
			get 
			{
				if ((_token != null) && (_token.CharPositionInLine != 0))
				{
					return _token.CharPositionInLine;
				}
				if (ChildCount > 0)
				{
					return GetChild(0).CharPositionInLine;
				}
				return 0;
			}
		}

		public IASTNode AddChild(IASTNode child)
		{
			if (child != null)
			{
				ASTNode childNode = (ASTNode) child;

				if (childNode.IsNil)
				{
					if ((_children != null) && (_children == childNode._children))
					{
						throw new InvalidOperationException("attempt to add child list to itself");
					}

					if (childNode._children != null)
					{
						if (_children != null)
						{
							int count = childNode._children.Count;
							for (int i = 0; i < count; i++)
							{
								ASTNode tree2 = (ASTNode) childNode._children[i];
								_children.Add(tree2);
								tree2._parent = this;
								tree2._childIndex = _children.Count - 1;
							}
						}
						else
						{
							_children = childNode._children;
							FreshenParentAndChildIndexes();
						}
					}
				}
				else
				{
					if (_children == null)
					{
						_children = new List<IASTNode>();
					}
					_children.Add(childNode);
					childNode._parent = this;
					childNode._childIndex = _children.Count - 1;
				}
			}

			return child;
		}

		public IASTNode InsertChild(int index, IASTNode child)
		{
			_children.Insert(index, child);

			return child;
		}

		public IASTNode AddSiblingToRight(IASTNode newSibling)
		{
			throw new System.NotImplementedException();
		}

		public void ClearChildren()
		{
			throw new System.NotImplementedException();
		}

		public void AddChildren(IEnumerable<IASTNode> children)
		{
			if (_children == null)
			{
				_children = new List<IASTNode>();
			}

			_children.AddRange(children);
		}

		public void AddChildren(params IASTNode[] children)
		{
			if (_children == null)
			{
				_children = new List<IASTNode>();
			}

			_children.AddRange(children);
		}

		public IASTNode DupNode()
		{
			return new ASTNode(this);
		}

		public IASTNode RightHandSibling
		{
			get
			{
				if (_parent.ChildCount > (_childIndex + 1))
				{
					return _parent.GetChild(_childIndex + 1);
				}

				return null;
			}
		}

		public IASTNode GetChild(int index)
		{
			return _children[index];
		}

		public IToken Token
		{
			get { return _token; }
		}

		public override string ToString()
		{
			if (IsNil)
			{
				return "nil";
			}
			if (Type == 0)
			{
				return "<errornode>";
			}
			if (_token == null)
			{
				return null;
			}
			return _token.Text;
		}

		public string ToStringTree()
		{
			if ((_children == null) || (_children.Count == 0))
			{
				return ToString();
			}

			StringBuilder builder = new StringBuilder();
			if (!IsNil)
			{
				builder.Append("(");
				builder.Append(ToString());
				builder.Append(' ');
			}

			bool first = true;
			foreach (ASTNode child in _children)
			{
				if (!first)
				{
					builder.Append(' ');
				}
				builder.Append(child.ToStringTree());
				first = false;
			}

			if (!IsNil)
			{
				builder.Append(")");
			}

			return builder.ToString();
		}

		public IEnumerator<IASTNode> GetEnumerator()
		{
			return _children.GetEnumerator();
		}

		#region ITree
		// //////////////////////////////////////////////////////////
		// ITree implementations
		// //////////////////////////////////////////////////////////

		void ITree.FreshenParentAndChildIndexes()
		{
			throw new System.NotImplementedException();
		}

		ITree ITree.GetChild(int i)
		{
			return (ITree) GetChild(i);
		}

		void ITree.AddChild(ITree t)
		{
			AddChild((IASTNode) t);
		}

		void ITree.SetChild(int i, ITree t)
		{
			throw new System.NotImplementedException();
		}

		object ITree.DeleteChild(int i)
		{
			throw new System.NotImplementedException();
		}

		void ITree.ReplaceChildren(int startChildIndex, int stopChildIndex, object t)
		{
			throw new System.NotImplementedException();
		}

		ITree ITree.DupNode()
		{
			return (ITree) DupNode();
		}

		int ITree.ChildIndex { get; set; }

		ITree ITree.Parent
		{
			get { return (ITree)Parent; }
			set { Parent = (IASTNode)value; }
		}

		int ITree.TokenStartIndex
		{
			get
			{
				if ((_startIndex == -1) && (_token != null))
				{
					return _token.TokenIndex;
				}
				return _startIndex;
			}
			set { _startIndex = value; }
		}

		int ITree.TokenStopIndex
		{
			get
			{
				if ((_stopIndex == -1) && (_token != null))
				{
					return _token.TokenIndex;
				}
				return _stopIndex;
			}
			set { _stopIndex = value; }
		}
		#endregion

		#region IEnumerable
		// //////////////////////////////////////////////////////////
		// IEnumerable implementations
		// //////////////////////////////////////////////////////////

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		#endregion

		// //////////////////////////////////////////////////////////
		// Private methods
		// //////////////////////////////////////////////////////////

		private void FreshenParentAndChildIndexes()
		{
			FreshenParentAndChildIndexes(0);
		}

		private void FreshenParentAndChildIndexes(int offset)
		{
			for (int i = offset; i < _children.Count; i++)
			{
				ASTNode child = (ASTNode) _children[i];
				child._childIndex = i;
				child._parent = this;
			}
		}
	}
}
