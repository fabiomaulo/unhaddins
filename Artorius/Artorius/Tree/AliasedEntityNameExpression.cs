using System.Collections.Generic;
using System.Linq;
namespace NHibernate.Hql.Ast.Tree
{
	public class AliasedEntityNameExpression : AbstractClauseNode, IEqualityComparer<AliasedEntityNameExpression>
	{
		internal AliasedEntityNameExpression() {}

		public AliasedEntityNameExpression(string entityName, string alias)
		{
			var item = new EntityNameExpression(entityName);
			item.SetParent(this);
			children.Add(item);
			children.Add(new Identifier(this, alias));
		}

		public string EntityName
		{
			get
			{
				return children.First(x => x is EntityNameExpression).ToString();
			}
		}

		public string Alias
		{
			get
			{
				return children.First(x => x is Identifier).ToString();
			}
		}

		public override string ToString()
		{
			return string.Concat(EntityName, " as ", Alias);
		}

		#region Implementation of IEqualityComparer<AliasedEntityNameExpression>

		public bool Equals(AliasedEntityNameExpression x, AliasedEntityNameExpression y)
		{
			return x.GetHashCode() == y.GetHashCode();
		}

		private int? requestedHash;
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