using System;
using System.Collections.Generic;
using System.Linq;

namespace NHibernate.Hql.Ast.Tree
{
	public class AliasedEntityNameExpression : AbstractClauseNode, IEqualityComparer<AliasedEntityNameExpression>
	{
		internal AliasedEntityNameExpression() {}

		public AliasedEntityNameExpression(EntityNameExpression entityName, string alias)
		{
			if (entityName == null)
			{
				throw new ArgumentNullException("entityName");
			}

			EntityNameExpression item = entityName;
			item.SetParent(this);
			children.Add(item);
			string a = string.IsNullOrEmpty(alias) ? alias : alias.Trim();
			if (!string.IsNullOrEmpty(a))
			{
				children.Add(new Identifier(this, a));
			}
		}

		public AliasedEntityNameExpression(string entityName, string alias)
			: this(new EntityNameExpression(entityName), alias) {}

		public string EntityName
		{
			get { return children.First(x => x is EntityNameExpression).ToString(); }
		}

		public string Alias
		{
			get
			{
				ISyntaxNode result = children.FirstOrDefault(x => x is Identifier);
				return result != null ? result.ToString() : null;
			}
		}

		public override string ToString()
		{
			string a = Alias;
			return a != null ? string.Concat(EntityName, " as ", Alias) : EntityName;
		}

		#region Implementation of IEqualityComparer<AliasedEntityNameExpression>

		private int? requestedHash;

		public bool Equals(AliasedEntityNameExpression x, AliasedEntityNameExpression y)
		{
			return x.GetHashCode() == y.GetHashCode();
		}

		public int GetHashCode(AliasedEntityNameExpression obj)
		{
			if (!requestedHash.HasValue)
			{
				requestedHash = 317 ^ EntityName.GetHashCode() ^ Alias.GetHashCode();
			}
			return requestedHash.Value;
		}

		#endregion
	}
}