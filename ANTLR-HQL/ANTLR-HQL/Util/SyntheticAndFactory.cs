using Antlr.Runtime.Tree;
using NHibernate.Hql.Ast.ANTLR.Parameters;
using NHibernate.Hql.Ast.ANTLR.Tree;
using NHibernate.SqlCommand;
using NHibernate.Type;
using NHibernate.Util;

namespace NHibernate.Hql.Ast.ANTLR.Util
{
	/// <summary>
	/// Creates synthetic and nodes based on the where fragment part of a JoinSequence.
	/// Author: josh
	/// Ported by: Steve Strong
	/// </summary>
	public class SyntheticAndFactory
	{
		Logger log = new Logger();
		private readonly HqlSqlWalker _hqlSqlWalker;
		private CommonTree _filters;
		private CommonTree _thetaJoins;

		public SyntheticAndFactory(HqlSqlWalker hqlSqlWalker)
		{
			_hqlSqlWalker = hqlSqlWalker;
		}

		public void AddWhereFragment(
				JoinFragment joinFragment,
				SqlString whereFragment,
				QueryNode query,
				FromElement fromElement,
				HqlSqlWalker hqlSqlWalker)
		{
			if (whereFragment == null)
			{
				return;
			}

			if (!fromElement.UseWhereFragment && !joinFragment.HasThetaJoins())
			{
				return;
			}

			whereFragment = whereFragment.Trim();
			if (StringHelper.IsEmpty(whereFragment.ToString()))
			{
				return;
			}

			// Forcefully remove leading ands from where fragments; the grammar will
			// handle adding them
			if (whereFragment.StartsWithCaseInsensitive("and"))
			{
				whereFragment = whereFragment.Substring(4);
			}

			log.debug("Using unprocessed WHERE-fragment [" + whereFragment +"]");

			SqlFragment fragment = (SqlFragment) Create(HqlSqlWalker.SQL_TOKEN, whereFragment.ToString());

			fragment.SetJoinFragment(joinFragment);
			fragment.FromElement = fromElement;

			if (fromElement.IndexCollectionSelectorParamSpec != null)
			{
				fragment.AddEmbeddedParameter(fromElement.IndexCollectionSelectorParamSpec);
				fromElement.IndexCollectionSelectorParamSpec = null;
			}

			if (hqlSqlWalker.isFilter())
			{
				if (whereFragment.IndexOfCaseInsensitive("?") >= 0)
				{
					IType collectionFilterKeyType = hqlSqlWalker.SessionFactoryHelper
							.RequireQueryableCollection(hqlSqlWalker.CollectionFilterRole)
							.KeyType;
					CollectionFilterKeyParameterSpecification paramSpec = new CollectionFilterKeyParameterSpecification(
							hqlSqlWalker.CollectionFilterRole,
							collectionFilterKeyType,
							0
					);
					fragment.AddEmbeddedParameter(paramSpec);
				}
			}

			JoinProcessor.ProcessDynamicFilterParameters(
					whereFragment,
					fragment,
					hqlSqlWalker
			);

			log.debug("Using processed WHERE-fragment [" + fragment.Text + "]");

			// Filter conditions need to be inserted before the HQL where condition and the
			// theta join node.  This is because org.hibernate.loader.Loader binds the filter parameters first,
			// then it binds all the HQL query parameters, see org.hibernate.loader.Loader.processFilterParameters().
			if (fragment.FromElement.IsFilter || fragment.HasFilterCondition)
			{
				if (_filters == null)
				{
					// Find or create the WHERE clause
					CommonTree where = (CommonTree) query.WhereClause;
					// Create a new FILTERS node as a parent of all filters
					_filters = Create(HqlSqlWalker.FILTERS, "{filter conditions}");
					// Put the FILTERS node before the HQL condition and theta joins
					ASTUtil.InsertAsFirstChild(where, _filters);
				}

				// add the current fragment to the FILTERS node
				_filters.AddChild(fragment);
			}
			else
			{
				if (_thetaJoins == null)
				{
					// Find or create the WHERE clause
					CommonTree where = (CommonTree) query.WhereClause;

					// Create a new THETA_JOINS node as a parent of all filters
					_thetaJoins = Create(HqlSqlWalker.THETA_JOINS, "{theta joins}");

					// Put the THETA_JOINS node before the HQL condition, after the filters.
					if (_filters == null)
					{
						ASTUtil.InsertAsFirstChild(where, _thetaJoins);
					}
					else
					{
						ASTUtil.AppendSibling(_thetaJoins, _filters);
					}
				}

				// add the current fragment to the THETA_JOINS node
				_thetaJoins.AddChild(fragment);
			}
		}

		private CommonTree Create(int tokenType, string text)
		{
			return ASTUtil.Create(_hqlSqlWalker.ASTFactory, tokenType, text);
		}
	}
}
