using System;

namespace NHibernate.Hql.Ast.Tree
{
	/// <summary>
	/// A generic Identifier may represent an EntityName or a Fuction without paren
	/// </summary>
	public class Identifier : AbstractTerminalNode
	{
		internal Identifier(IClauseNode parentRule, string name)
			: base(parentRule)
		{
			var trimmed = name.Trim();
			Name = trimmed;
			if (string.IsNullOrEmpty(trimmed))
			{
				throw new ArgumentException("Identifier name (null or empty)", "name");
			}
		}

		public string Name { get; private set; }
	}
}