using GoldParsing.Engine;
using GoldParsing.Engine.Config;
using NHibernate.Hql.Ast;
using NHibernate.Hql.Ast.GoldImpls;
using NHibernate.Hql.Ast.Tree;
using NUnit.Framework;
using System.Linq;

namespace Artorius.Tests.Parsing
{
	[TestFixture]
	public class HqlAstReductions
	{
		public const string GrammarPath = @"..\..\..\Grammar\Hql.cgt";
		private readonly IGrammar grammar;
		private readonly ISyntaxNodeFactory<Reduction, Token> nodeFactory;

		public HqlAstReductions()
		{
			var cgl = new CompiledGrammarLoader(GrammarPath);
			grammar = cgl.Load();
			nodeFactory = new SyntaxNodeFactory();
		}

		public ISyntaxNode Parse(string hql)
		{
			var p = new HqlParser(grammar, nodeFactory);
			return p.Parse(hql);
		}

		[Test]
		public void OrderByReduction()
		{
			string hql = "from Animal a order by a.Father.Name, a.Name, a.Weight";
			OrderByClause orderByClause = ((FromClause) Parse(hql)).OrderBy;
			Assert.That(orderByClause, Is.Not.Null);
			Assert.That(orderByClause.OrderList, Is.Not.Null);
			Assert.That(orderByClause.OrderList.Count, Is.EqualTo(3));
			Assert.That(orderByClause.OrderList.ElementAt(0).ToString(), Is.EqualTo("a.Father.Name"));
			Assert.That(orderByClause.OrderList.ElementAt(1).ToString(), Is.EqualTo("a.Name"));
			Assert.That(orderByClause.OrderList.ElementAt(2).ToString(), Is.EqualTo("a.Weight"));
		}

	}
}