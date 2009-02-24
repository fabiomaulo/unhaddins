using System;
using Antlr.Runtime;
using NHibernate.Type;

namespace NHibernate.Hql.Ast.ANTLR.Tree
{
	/// <summary>
	/// A base AST node for the intermediate tree.
	/// </summary>
	public class SqlNode : ASTNode
	{
		/**
		 * The original text for the node, mostly for debugging.
		 */
		private String _originalText;

		/**
		 * The data type of this node.  Null for 'no type'.
		 */
		private IType _dataType;

		public SqlNode(IToken token) : base(token)
		{
		}

		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;

				if (!string.IsNullOrEmpty(value) && _originalText == null)
				{
					_originalText = value;
				}
			}
		}

		public String getOriginalText()
		{
			return _originalText;
		}

		public virtual IType DataType
		{
			get { return _dataType; }
			set { _dataType = value; }
		}
	}
}
