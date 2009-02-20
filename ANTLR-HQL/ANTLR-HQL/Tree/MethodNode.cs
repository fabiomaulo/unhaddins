using System;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using NHibernate.Hql.Ast.ANTLR.Util;
using NHibernate.Persister.Collection;

namespace NHibernate.Hql.Ast.ANTLR.Tree
{
	/// <summary>
	/// Represents a method call
	/// Author: josh
	/// Ported by: Steve Strong
	/// </summary>
	public class MethodNode : AbstractSelectExpression, ISelectExpression 
	{
		Logger log = new Logger();

		private string[] _selectColumns;
		private string _methodName;
		private bool _inSelect;
		private FromElement _fromElement;

		public MethodNode(IToken token) : base(token)
		{
		}
		
		public override void SetScalarColumnText(int i)
		{
			if ( _selectColumns == null ) 
			{ 	// Dialect function
				ColumnHelper.GenerateSingleScalarColumn( this, i );
			}
			else 
			{	// Collection 'property function'
				ColumnHelper.GenerateScalarColumns( this, _selectColumns, i );
			}
		}

		public void InitializeMethodNode(CommonTree name, bool inSelect)
		{
			name.SetType(HqlSqlWalker.METHOD_NAME);
			_methodName = name.Text.ToLowerInvariant();	// Use the lower case function name.
			_inSelect = inSelect;			// Remember whether we're in a SELECT clause or not.
		}

		public bool IsCollectionPropertyMethod
		{
			get { return CollectionProperties.IsAnyCollectionProperty(_methodName); }
		}

		public void ResolveCollectionProperty(ITree expr)
		{
			String propertyName = CollectionProperties.GetNormalizedPropertyName( _methodName );

			if ( expr is FromReferenceNode ) 
			{
				FromReferenceNode collectionNode = ( FromReferenceNode ) expr;
				// If this is 'elements' then create a new FROM element.
				if ( CollectionPropertyNames.Elements == propertyName ) 
				{
					HandleElements( collectionNode, propertyName );
				}
				else {
					// Not elements(x)
					_fromElement = collectionNode.FromElement;
					DataType = _fromElement.GetPropertyType( propertyName, propertyName );
					_selectColumns = _fromElement.ToColumns( _fromElement.TableAlias, propertyName, _inSelect );
				}
				if ( collectionNode is DotNode ) 
				{
					PrepareAnyImplicitJoins( ( DotNode ) collectionNode );
				}
				if ( !_inSelect ) 
				{
					_fromElement.SetText( "" );
					_fromElement.UseWhereFragment = false;
				}

				PrepareSelectColumns( _selectColumns );
				SetText( _selectColumns[0] );
				this.SetType( HqlSqlWalker.SQL_TOKEN );
			}
			else 
			{
				throw new SemanticException( 
						"Unexpected expression " + expr + 
						" found for collection function " + propertyName 
					);
			}
		}

		public String GetDisplayText()
		{
			return "{" +
					"method=" + _methodName +
					",selectColumns=" + (_selectColumns == null ?
							null : _selectColumns) +
					",fromElement=" + _fromElement.TableAlias +
					"}";
		}

		protected virtual void PrepareSelectColumns(string[] columns)
		{
			return;
		}

		private void PrepareAnyImplicitJoins(DotNode dotNode) 
		{
			if ( dotNode.GetLhs() is DotNode )
			{
				DotNode lhs = ( DotNode ) dotNode.GetLhs();
				FromElement lhsOrigin = lhs.FromElement;
				if ( lhsOrigin != null && "" == lhsOrigin.Text )
				{
					String lhsOriginText = lhsOrigin.Queryable.TableName +
							" " + lhsOrigin.TableAlias;
					lhsOrigin.SetText( lhsOriginText );
				}
				PrepareAnyImplicitJoins( lhs );
			}
		}

		private void HandleElements(FromReferenceNode collectionNode, String propertyName)
		{
			FromElement collectionFromElement = collectionNode.FromElement;
			IQueryableCollection queryableCollection = collectionFromElement.QueryableCollection;

			String path = collectionNode.Path + "[]." + propertyName;
			log.debug("Creating elements for " + path);

			_fromElement = collectionFromElement;
			if (!collectionFromElement.IsCollectionOfValuesOrComponents)
			{
				Walker.AddQuerySpaces(queryableCollection.ElementPersister.QuerySpaces);
			}

			DataType = queryableCollection.ElementType;
			_selectColumns = collectionFromElement.ToColumns(_fromElement.TableAlias, propertyName, _inSelect);
		}


	}

}
