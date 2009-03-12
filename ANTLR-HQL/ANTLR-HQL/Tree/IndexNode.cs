using System;
using System.Collections.Generic;
using Antlr.Runtime;
using log4net;
using NHibernate.Engine;
using NHibernate.Hql.Ast.ANTLR.Parameters;
using NHibernate.Persister.Collection;
using NHibernate.Type;

namespace NHibernate.Hql.Ast.ANTLR.Tree
{
	/// <summary>
	/// Represents the [] operator and provides it's semantics.
	/// Author: josh
	/// Ported by: Steve Strong
	/// </summary>
	public class IndexNode : FromReferenceNode
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(IndexNode));
		private bool _isResolved;

		public IndexNode(IToken token) : base(token)
		{
		}

		public override void SetScalarColumnText(int i)
		{
			throw new InvalidOperationException("An IndexNode cannot generate column text!");
		}

		public override void ResolveIndex(IASTNode parent)
		{
			throw new InvalidOperationException();
		}

		public override void  Resolve(bool generateJoin, bool implicitJoin, string classAlias, IASTNode parent)
		{
			if ( _isResolved ) 
			{
				return;
			}

			FromReferenceNode collectionNode = ( FromReferenceNode ) GetChild(0);
			SessionFactoryHelperExtensions sessionFactoryHelper = SessionFactoryHelper;
			collectionNode.ResolveIndex( this );		// Fully resolve the map reference, create implicit joins.

			IType type = collectionNode.DataType;
			if ( !type.IsCollectionType ) 
			{
				throw new SemanticException( "The [] operator cannot be applied to type " + type.ToString() );
			}

			string collectionRole = ( ( CollectionType ) type ).Role;
			IQueryableCollection queryableCollection = sessionFactoryHelper.RequireQueryableCollection( collectionRole );
			if ( !queryableCollection.HasIndex ) 
			{
				throw new QueryException( "unindexed fromElement before []: " + collectionNode.Path );
			}

			// Generate the inner join -- The elements need to be joined to the collection they are in.
			FromElement fromElement = collectionNode.FromElement;
			String elementTable = fromElement.TableAlias;
			FromClause fromClause = fromElement.FromClause;
			String path = collectionNode.Path;

			FromElement elem = fromClause.FindCollectionJoin( path );
			if ( elem == null ) 
			{
				FromElementFactory factory = new FromElementFactory( fromClause, fromElement, path );
				elem = factory.CreateCollectionElementsJoin( queryableCollection, elementTable );
				if ( log.IsDebugEnabled )
				{
					log.Debug( "No FROM element found for the elements of collection join path " + path
							+ ", created " + elem );
				}
			}
			else 
			{
				if ( log.IsDebugEnabled ) 
				{
					log.Debug( "FROM element found for collection join path " + path );
				}
			}

			// The 'from element' that represents the elements of the collection.
			FromElement = fromElement;

			// Add the condition to the join sequence that qualifies the indexed element.
			IASTNode selector = GetChild(1);
			if ( selector == null ) 
			{
				throw new QueryException( "No index value!" );
			}

			// Sometimes use the element table alias, sometimes use the... umm... collection table alias (many to many)
			String collectionTableAlias = elementTable;
			if ( elem.CollectionTableAlias != null ) 
			{
				collectionTableAlias = elem.CollectionTableAlias;
			}

			// TODO: get SQL rendering out of here, create an AST for the join expressions.
			// Use the SQL generator grammar to generate the SQL text for the index expression.
			JoinSequence joinSequence = fromElement.JoinSequence;
			string[] indexCols = queryableCollection.IndexColumnNames;
			if ( indexCols.Length != 1 ) 
			{
				throw new QueryException( "composite-index appears in []: " + collectionNode.Path );
			}
			SqlGenerator gen = new SqlGenerator( SessionFactoryHelper.Factory );
			try 
			{
				gen.SimpleExpr( selector ); //TODO: used to be exprNoParens! was this needed?
			}
			catch ( RecognitionException e ) 
			{
				throw new QueryException( e.Message, e );
			}

			string selectorExpression = gen.GetSQL().ToString();
			//joinSequence.AddCondition( collectionTableAlias + '.' + indexCols[0] + " = " + selectorExpression );
			joinSequence.AddCondition(collectionTableAlias, new string[] { indexCols[0] }, selectorExpression, false);
			IList<IParameterSpecification> paramSpecs = gen.GetCollectedParameters();
			if ( paramSpecs != null ) 
			{
				switch ( paramSpecs.Count ) 
				{
					case 0 :
						// nothing to do
						break;
					case 1 :
						IParameterSpecification paramSpec = paramSpecs[0];
						paramSpec.ExpectedType = queryableCollection.IndexType;
						fromElement.SetIndexCollectionSelectorParamSpec( paramSpec );
						break;
					default:
						fromElement.SetIndexCollectionSelectorParamSpec(
								new AggregatedIndexCollectionSelectorParameterSpecifications( paramSpecs )
						);
						break;
				}
			}

			// Now, set the text for this node.  It should be the element columns.
			String[] elementColumns = queryableCollection.GetElementColumnNames( elementTable );
			Text = elementColumns[0];
			SetResolved();
		}

		public void SetResolved()
		{
			_isResolved = true;
			if (log.IsDebugEnabled)
			{
				log.Debug("Resolved :  " + Path + " -> " + Text);
			}
		}
	}
}
