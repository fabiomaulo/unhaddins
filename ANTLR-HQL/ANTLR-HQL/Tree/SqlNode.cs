using System;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using NHibernate.Type;

namespace NHibernate.Hql.Ast.ANTLR.Tree
{
	/// <summary>
	/// A base AST node for the intermediate tree.
	/// </summary>
	public class SqlNode : CommonTree
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
	
		public void SetText(string s)
		{
			base.Token.Text = s;

			if (!string.IsNullOrEmpty(s) && _originalText == null)
			{
				_originalText = s;
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
