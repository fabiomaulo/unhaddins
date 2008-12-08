using System;

namespace NHibernate.Hql.Ast.Tree
{
	public class NamedParameter: AbstractTerminalNode
	{
		public NamedParameter(IClauseNode parentRule, string name) : base(parentRule)
		{
			var trimmed = name.Trim().TrimStart(':');
			Name = trimmed;
			if (string.IsNullOrEmpty(trimmed))
			{
				throw new ArgumentException("Invalid parameter name (null or empty)","name");
			}
		}

		public string Name { get; private set; }
	}
}