using System.Collections.Generic;
using System.Linq;

namespace NHibernate.Hql.Ast.Tree
{
	public abstract class AbstractAliasedEntityExpression : AbstractClauseNode,
	                                                        IEqualityComparer<AliasedEntityNameExpression>
	{
		private int? requestedHash;

		public abstract ISyntaxNode Alieased { get; }

		public string Alias
		{
			get
			{
				ISyntaxNode result = children.FirstOrDefault(x => x is Identifier);
				return result != null ? result.ToString() : null;
			}
		}

		#region IEqualityComparer<AliasedEntityNameExpression> Members

		public bool Equals(AliasedEntityNameExpression x, AliasedEntityNameExpression y)
		{
			return x.GetHashCode() == y.GetHashCode();
		}

		public int GetHashCode(AliasedEntityNameExpression obj)
		{
			if (!requestedHash.HasValue)
			{
				requestedHash = 317 ^ Alieased.GetHashCode();
				string a = Alias;
				if (a != null)
				{
					requestedHash ^= a.GetHashCode();
				}
			}
			return requestedHash.Value;
		}

		#endregion
	}
}