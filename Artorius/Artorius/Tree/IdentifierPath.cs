using System;

namespace NHibernate.Hql.Ast.Tree
{
	/// <summary>
	/// A Path may represent an EntityName, where the name is the FullName of a entity-class or
	/// a path of a property.
	/// </summary>
	public class IdentifierPath : AbstractTerminalNode
	{
		internal IdentifierPath(IClauseNode parentRule, string path) : base(parentRule)
		{
			// TODO: a public constructor need a formal validation of the path value
			string trimmed = path.Trim();
			Path = trimmed;
			if (string.IsNullOrEmpty(trimmed))
			{
				throw new ArgumentException("Identifier path (null or empty)", "path");
			}
		}

		public string Path { get; private set; }

		public string[] Elements
		{
			get { return Path.Split('.'); }
		}

		public override string ToString()
		{
			return Path;
		}
	}
}