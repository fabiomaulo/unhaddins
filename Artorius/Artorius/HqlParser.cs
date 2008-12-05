using GoldParsing.Engine;

namespace NHibernate.Hql.Ast
{
	public class HqlParser
	{
		private readonly IParserSettings settings;

		public HqlParser(IParserSettings settings)
		{
			this.settings = settings;
		}

		public INode Parse(string hql)
		{
			return null;
		}
	}
}