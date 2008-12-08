using System;
using System.Collections.Generic;
using GoldParsing.Engine;
using GoldParsing.Engine.Config;
using NHibernate.Engine;

namespace NHibernate.Hql.Ast.GoldImpls
{
	public class QueryTranslatorFactory : IQueryTranslatorFactory
	{
		// TODO: move the compiled grammar or his equivalent as embedded resource (during development is better to have it as external file)
		public const string GrammarPath = "Hql.cgt";
		private readonly IGrammar grammar;
		private readonly SyntaxNodeFactory syntaxNodeFactory = new SyntaxNodeFactory();

		public QueryTranslatorFactory()
		{
			var cgl = new CompiledGrammarLoader(GrammarPath);
			grammar = cgl.Load();
		}

		#region Implementation of IQueryTranslatorFactory

		public IQueryTranslator CreateQueryTranslator(string queryIdentifier, string queryString,
		                                              IDictionary<string, IFilter> filters, ISessionFactoryImplementor factory)
		{
			return new QueryTranslator(queryIdentifier, queryString, filters, new HqlParser(grammar, syntaxNodeFactory), factory);
		}

		public IFilterTranslator CreateFilterTranslator(string queryIdentifier, string queryString,
		                                                IDictionary<string, IFilter> filters,
		                                                ISessionFactoryImplementor factory)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}