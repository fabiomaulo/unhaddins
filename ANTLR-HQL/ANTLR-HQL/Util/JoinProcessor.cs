﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime.Tree;
using NHibernate.Engine;
using NHibernate.Hql.Ast.ANTLR.Parameters;
using NHibernate.Hql.Ast.ANTLR.Tree;
using NHibernate.Hql.Classic;
using NHibernate.Impl;
using NHibernate.SqlCommand;
using NHibernate.Type;
using NHibernate.Util;

namespace NHibernate.Hql.Ast.ANTLR.Util
{
	/// <summary>
	/// Performs the post-processing of the join information gathered during semantic analysis.
	/// The join generating classes are complex, this encapsulates some of the JoinSequence-related
	/// code.
	/// Author: Joshua Davis
	/// Ported by: Steve Strong
 	/// </summary>
	public class JoinProcessor
	{
		private static readonly Logger log = new Logger();

		private readonly HqlSqlWalker _walker;
		private readonly SyntheticAndFactory _syntheticAndFactory;

		/// <summary>
		/// Constructs a new JoinProcessor.
		/// </summary>
		/// <param name="walker">The walker to which we are bound, giving us access to needed resources.</param>
		public JoinProcessor(HqlSqlWalker walker) 
		{
			_walker = walker;
			_syntheticAndFactory = new SyntheticAndFactory( walker );
		}

		public void ProcessJoins(QueryNode query) 
		{
			FromClause fromClause = query.FromClause;

			IList<ITree> fromElements;
			if ( DotNode.UseThetaStyleImplicitJoins ) 
			{
				// for regression testing against output from the old parser...
				// found it easiest to simply reorder the FromElements here into ascending order
				// in terms of injecting them into the resulting sql ast in orders relative to those
				// expected by the old parser; this is definitely another of those "only needed
				// for regression purposes".  The SyntheticAndFactory, then, simply injects them as it
				// encounters them.
				fromElements = new List<ITree>();
				IList<ITree> t = fromClause.GetFromElements();

				for (int i = t.Count - 1; i >= 0; i--)
				{
					fromElements.Add(t[i]);
				}
			}
			else 
			{
				fromElements = fromClause.GetFromElements();
			}

			// Iterate through the alias,JoinSequence pairs and generate SQL token nodes.
			foreach (FromElement fromElement in fromElements)
			{
				JoinSequence join = fromElement.JoinSequence;/*
				join.setSelector(
						new JoinSequence.Selector() {
							public boolean includeSubclasses(String alias) {
								// The uber-rule here is that we need to include  subclass joins if
								// the FromElement is in any way dereferenced by a property from
								// the subclass table; otherwise we end up with column references
								// qualified by a non-existent table reference in the resulting SQL...
								boolean containsTableAlias = fromClause.containsTableAlias( alias );
								if ( fromElement.isDereferencedBySubclassProperty() ) {
									// TODO : or should we return 'containsTableAlias'??
									log.trace( "forcing inclusion of extra joins [alias=" + alias + ", containsTableAlias=" + containsTableAlias + "]" );
									return true;
								}
								boolean shallowQuery = walker.isShallowQuery();
								boolean includeSubclasses = fromElement.isIncludeSubclasses();
								boolean subQuery = fromClause.isSubQuery();
								return includeSubclasses && containsTableAlias && !subQuery && !shallowQuery;
							}
						}
				);*/

				AddJoinNodes( query, join, fromElement );
			}
		}

		private void AddJoinNodes(QueryNode query, JoinSequence join, FromElement fromElement) 
		{
			JoinFragment joinFragment = join.ToJoinFragment(
					_walker.EnabledFilters,
					fromElement.UseFromFragment || fromElement.IsDereferencedBySuperclassOrSubclassProperty,
					fromElement.WithClauseFragment,
					fromElement.WithClauseJoinAlias
			);

			SqlString frag = joinFragment.ToFromFragmentString;
			SqlString whereFrag = joinFragment.ToWhereFragmentString;

			// If the from element represents a JOIN_FRAGMENT and it is
			// a theta-style join, convert its type from JOIN_FRAGMENT
			// to FROM_FRAGMENT
			if ( fromElement.Type == HqlSqlWalker.JOIN_FRAGMENT &&
					( join.IsThetaStyle || StringHelper.IsNotEmpty( whereFrag ) ) ) 
			{
				fromElement.SetType( HqlSqlWalker.FROM_FRAGMENT );
				fromElement.JoinSequence.SetUseThetaStyle( true ); // this is used during SqlGenerator processing
			}

			// If there is a FROM fragment and the FROM element is an explicit, then add the from part.
			if ( fromElement.UseFromFragment /*&& StringHelper.isNotEmpty( frag )*/ ) 
			{
				SqlString fromFragment = ProcessFromFragment( frag, join ).Trim();
				if ( log.isDebugEnabled() ) 
				{
					log.debug( "Using FROM fragment [" + fromFragment + "]" );
				}

				ProcessDynamicFilterParameters(
						fromFragment,
						fromElement,
						_walker
				);
			}

			_syntheticAndFactory.AddWhereFragment( 
					joinFragment,
					whereFrag,
					query,
					fromElement,
					_walker
			);
		}

		private static SqlString ProcessFromFragment(SqlString frag, JoinSequence join) 
		{
			SqlString fromFragment = frag.Trim();
			// The FROM fragment will probably begin with ', '.  Remove this if it is present.
			if ( fromFragment.StartsWithCaseInsensitive( ", " ) ) {
				fromFragment = fromFragment.Substring( 2 );
			}
			return fromFragment;
		}

		public static void ProcessDynamicFilterParameters(
				SqlString sqlFragment,
				IParameterContainer container,
				HqlSqlWalker walker) 
		{
			if ( walker.EnabledFilters.Count == 0
					&& ( ! HasDynamicFilterParam( sqlFragment ) )
					&& ( ! ( HasCollectionFilterParam( sqlFragment ) ) ) ) 
			{
				return;
			}

			NHibernate.Dialect.Dialect dialect = walker.SessionFactoryHelper.Factory.Dialect;

			string symbols = new StringBuilder().Append( ParserHelper.HqlSeparators )
					.Append( dialect.OpenQuote)
					.Append( dialect.CloseQuote)
					.ToString();

			StringTokenizer tokens = new StringTokenizer( sqlFragment.ToString(), symbols, true );
			StringBuilder result = new StringBuilder();

			foreach (string token in tokens)
			{
				if ( token.StartsWith( ParserHelper.HqlVariablePrefix ) ) 
				{
					string filterParameterName = token.Substring( 1 );
					string[] parts = LoadQueryInfluencers.ParseFilterParameterName( filterParameterName );
					FilterImpl filter = ( FilterImpl ) walker.EnabledFilters[parts[0]];
					Object value = filter.GetParameter( parts[1] );
					IType type = filter.FilterDefinition.GetParameterType( parts[1] );
					String typeBindFragment = StringHelper.Join(
							",",
							ArrayHelper.FillArray( "?", type.GetColumnSpan( walker.SessionFactoryHelper.Factory ) )
					);
					string bindFragment = ( value != null && value is ICollection)
							? StringHelper.Join( ",", ArrayHelper.FillArray( typeBindFragment, ( ( ICollection ) value ).Count ) )
							: typeBindFragment;
					result.Append( bindFragment );
					container.AddEmbeddedParameter( new DynamicFilterParameterSpecification( parts[0], parts[1], type ) );
				}
				else 
				{
					result.Append( token );
				}
			}

			container.SetText( result.ToString() );
		}

		private static bool HasDynamicFilterParam(SqlString sqlFragment)
		{
			return sqlFragment.IndexOfCaseInsensitive(ParserHelper.HqlVariablePrefix) < 0;
		}

		private static bool HasCollectionFilterParam(SqlString sqlFragment)
		{
			return sqlFragment.IndexOfCaseInsensitive("?") < 0;
		}

	}
}
