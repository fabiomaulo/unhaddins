using System;
using System.Linq;

namespace NHibernate.Hql.Ast.Tree
{
	public class AliasedEntityNameExpression : AbstractAliasedEntityExpression
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
			get { return children.OfType<EntityNameExpression>().First().ToString(); }
		}

		public override string ToString()
		{
			string a = Alias;
			return a != null ? string.Concat(EntityName, " as ", a) : EntityName;
		}

		#region Overrides of AbstractAliasedEntityExpression

		public override ISyntaxNode Alieased
		{
			get { return children.First(x => x is EntityNameExpression); }
		}

		#endregion
	}
}