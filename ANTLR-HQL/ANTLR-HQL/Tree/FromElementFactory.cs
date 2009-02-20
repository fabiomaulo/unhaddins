using System;
using Antlr.Runtime.Tree;
using NHibernate.Engine;
using NHibernate.Hql.Ast.ANTLR.Util;
using NHibernate.Persister.Collection;
using NHibernate.Persister.Entity;
using NHibernate.SqlCommand;
using NHibernate.Type;
using NHibernate.Util;

namespace NHibernate.Hql.Ast.ANTLR.Tree
{
	public class FromElementFactory
	{
		private readonly Logger log = new Logger();

		private readonly FromClause _fromClause;
		private readonly FromElement _origin;
		private readonly string _path;
		private readonly bool _collection;
		private readonly string _classAlias;
		private readonly string[] _columns;
		private bool _implied;
		private bool _inElementsFunction;
		private IQueryableCollection _queryableCollection;
		private CollectionType _collectionType;


		/// <summary>
		/// Creates entity from elements.
		/// </summary>
		/// <param name="fromClause"></param>
		/// <param name="origin"></param>
		/// <param name="path"></param>
		public FromElementFactory(FromClause fromClause, FromElement origin, string path)
		{
			_fromClause = fromClause;
			_origin = origin;
			_path = path;
			_collection = false;
		}

		/// <summary>
		/// Creates collection from elements.
		/// </summary>
		/// <param name="fromClause"></param>
		/// <param name="origin"></param>
		/// <param name="path"></param>
		/// <param name="classAlias"></param>
		/// <param name="columns"></param>
		/// <param name="implied"></param>
		public FromElementFactory(
			FromClause fromClause,
			FromElement origin,
			string path,
			string classAlias,
			string[] columns,
			bool implied)
			: this(fromClause, origin, path)
		{
			_classAlias = classAlias;
			_columns = columns;
			_implied = implied;
			_collection = true;
		}

		public FromElement AddFromElement()
		{
			FromClause parentFromClause = _fromClause.ParentFromClause;
			if (parentFromClause != null)
			{
				// Look up class name using the first identifier in the path.
				string pathAlias = PathHelper.GetAlias(_path);
				FromElement parentFromElement = parentFromClause.GetFromElement(pathAlias);
				if (parentFromElement != null)
				{
					return CreateFromElementInSubselect(_path, pathAlias, parentFromElement, _classAlias);
				}
			}

			IEntityPersister entityPersister = _fromClause.SessionFactoryHelper.RequireClassPersister(_path);

			FromElement elem = CreateAndAddFromElement(_path,
					_classAlias,
					entityPersister,
					(EntityType)((IQueryable)entityPersister).Type,
					null);

			// Add to the query spaces.
			_fromClause.Walker.AddQuerySpaces(entityPersister.QuerySpaces);

			return elem;
		}

		public FromElement CreateCollectionElementsJoin(IQueryableCollection queryableCollection,
												 String collectionName) 
		{
			JoinSequence collectionJoinSequence = _fromClause.SessionFactoryHelper.CreateCollectionJoinSequence( queryableCollection, collectionName );
			_queryableCollection = queryableCollection;
			return CreateCollectionJoin( collectionJoinSequence, null );
		}

		private FromElement CreateFromElementInSubselect(
			string path,
			string pathAlias,
			FromElement parentFromElement,
			string classAlias)
		{
			if (log.isDebugEnabled())
			{
				log.debug("createFromElementInSubselect() : path = " + path);
			}

			// Create an DotNode AST for the path and resolve it.
			FromElement fromElement = EvaluateFromElementPath(path, classAlias);
			IEntityPersister entityPersister = fromElement.EntityPersister;

			// If the first identifier in the path referrs to the class alias (not the class name), then this
			// is a correlated subselect.  If it's a correlated sub-select, use the existing table alias.  Otherwise
			// generate a new one.
			string tableAlias;
			bool correlatedSubselect = pathAlias == parentFromElement.ClassAlias;
			if (correlatedSubselect)
			{
				tableAlias = fromElement.TableAlias;
			}
			else
			{
				tableAlias = null;
			}

			// If the from element isn't in the same clause, create a new from element.
			if (fromElement.FromClause != _fromClause)
			{
				if (log.isDebugEnabled())
				{
					log.debug("createFromElementInSubselect() : creating a new FROM element...");
				}

				fromElement = CreateFromElement(entityPersister);

				InitializeAndAddFromElement(fromElement,
						path,
						classAlias,
						entityPersister,
						(EntityType)((IQueryable)entityPersister).Type,
						tableAlias
				);
			}
			if (log.isDebugEnabled())
			{
				log.debug("createFromElementInSubselect() : " + path + " -> " + fromElement);
			}

			return fromElement;
		}

		public FromElement CreateCollection(IQueryableCollection queryableCollection,
									string role,
									JoinType joinType,
									bool fetchFlag,
									bool indexed)
		{
			if ( !_collection ) 
			{
				throw new InvalidOperationException( "FromElementFactory not initialized for collections!" );
			}

			_inElementsFunction = indexed;
			FromElement elem;
			_queryableCollection = queryableCollection;
			_collectionType = queryableCollection.CollectionType;
			string roleAlias = _fromClause.AliasGenerator.CreateName(role);

			// Correlated subqueries create 'special' implied from nodes
			// because correlated subselects can't use an ANSI-style join
			bool explicitSubqueryFromElement = _fromClause.IsSubQuery && !_implied;
			if ( explicitSubqueryFromElement ) 
			{
				string pathRoot = StringHelper.Root( _path );
				FromElement origin = _fromClause.GetFromElement( pathRoot );
				if ( origin == null || origin.FromClause != _fromClause ) 
				{
					_implied = true;
				}
			}

			// super-duper-classic-parser-regression-testing-mojo-magic...
			if ( explicitSubqueryFromElement && DotNode.UseThetaStyleImplicitJoins ) 
			{
				_implied = true;
			}

			IType elementType = queryableCollection.ElementType;

			if ( elementType.IsEntityType ) 
			{ 	
				// A collection of entities...
				elem = CreateEntityAssociation( role, roleAlias, joinType );
			}
			else if ( elementType.IsComponentType ) 
			{	
				// A collection of components...
				JoinSequence joinSequence = CreateJoinSequence( roleAlias, joinType );
				elem = CreateCollectionJoin( joinSequence, roleAlias );
			}
			else 
			{
				// A collection of scalar elements...
				JoinSequence joinSequence = CreateJoinSequence( roleAlias, joinType );
				elem = CreateCollectionJoin( joinSequence, roleAlias );
			}

			elem.SetRole(role);
			elem.QueryableCollection = queryableCollection;
			// Don't include sub-classes for implied collection joins or subquery joins.
			if ( _implied )
			{
				elem.IncludeSubclasses = false;
			}

			if ( explicitSubqueryFromElement )
			{
				elem.InProjectionList = true;	// Treat explict from elements in sub-queries properly.
			}

			if ( fetchFlag ) 
			{
				elem.Fetch = true;
			}
			return elem;
		}

		public FromElement CreateEntityJoin(
	        string entityClass,
	        string tableAlias,
	        JoinSequence joinSequence,
	        bool fetchFlag,
	        bool inFrom,
	        EntityType type)
		{
			FromElement elem = CreateJoin( entityClass, tableAlias, joinSequence, type, false );
			elem.Fetch = fetchFlag;
			IEntityPersister entityPersister = elem.EntityPersister;
			int numberOfTables = entityPersister.QuerySpaces.Length;

			if ( numberOfTables > 1 && _implied && !elem.UseFromFragment ) 
			{
				if ( log.isDebugEnabled() ) 
				{
					log.debug( "createEntityJoin() : Implied multi-table entity join" );
				}
				elem.UseFromFragment = true;
			}

			// If this is an implied join in a FROM clause, then use ANSI-style joining, and set the
			// flag on the FromElement that indicates that it was implied in the FROM clause itself.
			if ( _implied && inFrom ) 
			{
				joinSequence.SetUseThetaStyle(false);
				elem.UseFromFragment = true;
				elem.SetImpliedInFromClause( true );
			}
			if ( elem.Walker.IsSubQuery ) 
			{
				// two conditions where we need to transform this to a theta-join syntax:
				//      1) 'elem' is the "root from-element" in correlated subqueries
				//      2) The DotNode.useThetaStyleImplicitJoins has been set to true
				//          and 'elem' represents an implicit join
				if ( elem.FromClause != elem.Origin.FromClause ||
	//			        ( implied && DotNode.useThetaStyleImplicitJoins ) ) {
						DotNode.UseThetaStyleImplicitJoins) {
					// the "root from-element" in correlated subqueries do need this piece
					elem.SetType( HqlSqlWalker.FROM_FRAGMENT );
					joinSequence.SetUseThetaStyle( true );
					elem.UseFromFragment = false;
				}
			}

			return elem;
		}

		private FromElement CreateEntityAssociation(
				string role,
				string roleAlias,
				JoinType joinType) 
		{
			FromElement elem;
			IQueryable entityPersister = ( IQueryable ) _queryableCollection.ElementPersister;
			string associatedEntityName = entityPersister.EntityName;

			// Get the class name of the associated entity.
			if ( _queryableCollection.IsOneToMany ) 
			{
				if ( log.isDebugEnabled() ) 
				{
					log.debug( "createEntityAssociation() : One to many - path = " + _path + " role = " + role + " associatedEntityName = " + associatedEntityName );
				}

				JoinSequence joinSequence = CreateJoinSequence( roleAlias, joinType );

				elem = CreateJoin( associatedEntityName, roleAlias, joinSequence, ( EntityType ) _queryableCollection.ElementType, false );
			}
			else
			{
				if ( log.isDebugEnabled() ) {
					log.debug( "createManyToMany() : path = " + _path + " role = " + role + " associatedEntityName = " + associatedEntityName );
				}

				elem = CreateManyToMany( role, associatedEntityName,
						roleAlias, entityPersister, ( EntityType ) _queryableCollection.ElementType, joinType );
				_fromClause.Walker.AddQuerySpaces( _queryableCollection.CollectionSpaces);
			}
			elem.CollectionTableAlias = roleAlias;
			return elem;
		}

		private FromElement CreateCollectionJoin(JoinSequence collectionJoinSequence, string tableAlias) 
		{
			string text = _queryableCollection.TableName;
			ITree ast = CreateFromElement( text );
			FromElement destination = ( FromElement ) ast;
			IType elementType = _queryableCollection.ElementType;

			if (elementType.IsCollectionType) 
			{
				throw new SemanticException( "Collections of collections are not supported!" );
			}

			destination.InitializeCollection( _fromClause, _classAlias, tableAlias );
			destination.SetType( HqlSqlWalker.JOIN_FRAGMENT );		// Tag this node as a JOIN.
			destination.SetIncludeSubclasses( false );	// Don't include subclasses in the join.
			destination.CollectionJoin = true;		// This is a clollection join.
			destination.JoinSequence = collectionJoinSequence;
			destination.SetOrigin( _origin, false );
			destination.CollectionTableAlias = tableAlias;
	//		origin.addDestination( destination );
	// This was the cause of HHH-242
	//		origin.setType( FROM_FRAGMENT );			// Set the parent node type so that the AST is properly formed.
			_origin.SetText( "" );						// The destination node will have all the FROM text.
			_origin.CollectionJoin = true;			// The parent node is a collection join too (voodoo - see JoinProcessor)
			_fromClause.AddCollectionJoinFromElementByPath( _path, destination );
			_fromClause.Walker.AddQuerySpaces( _queryableCollection.CollectionSpaces );
			return destination;
		}

		private FromElement CreateManyToMany(
				string role,
				string associatedEntityName,
				string roleAlias,
				IEntityPersister entityPersister,
				EntityType type,
				JoinType joinType)
		{
			FromElement elem;
			SessionFactoryHelperExtensions sfh = _fromClause.SessionFactoryHelper;

			if ( _inElementsFunction /*implied*/ ) 
			{
				// For implied many-to-many, just add the end join.
				JoinSequence joinSequence = CreateJoinSequence( roleAlias, joinType );
				elem = CreateJoin( associatedEntityName, roleAlias, joinSequence, type, true );
			}
			else 
			{
				// For an explicit many-to-many relationship, add a second join from the intermediate 
				// (many-to-many) table to the destination table.  Also, make sure that the from element's 
				// idea of the destination is the destination table.
				string tableAlias = _fromClause.AliasGenerator.CreateName( entityPersister.EntityName );
				string[] secondJoinColumns = sfh.GetCollectionElementColumns( role, roleAlias );

				// Add the second join, the one that ends in the destination table.
				JoinSequence joinSequence = CreateJoinSequence( roleAlias, joinType );
				joinSequence.AddJoin( sfh.GetElementAssociationType( _collectionType ), tableAlias, joinType, secondJoinColumns );
				elem = CreateJoin( associatedEntityName, tableAlias, joinSequence, type, false );
				elem.UseFromFragment = true;
			}
			return elem;
		}


		private JoinSequence CreateJoinSequence(string roleAlias, JoinType joinType)
		{
			SessionFactoryHelperExtensions sessionFactoryHelper = _fromClause.SessionFactoryHelper;
			string[] joinColumns = Columns;
			if (_collectionType == null)
			{
				throw new InvalidOperationException("collectionType is null!");
			}
			return sessionFactoryHelper.CreateJoinSequence(_implied, _collectionType, roleAlias, joinType, joinColumns);
		}

		private FromElement CreateJoin(
				string entityClass,
				string tableAlias,
				JoinSequence joinSequence,
				EntityType type,
				bool manyToMany)
		{
			//  origin, path, implied, columns, classAlias,
			IEntityPersister entityPersister = _fromClause.SessionFactoryHelper.RequireClassPersister( entityClass );
			FromElement destination = CreateAndAddFromElement( entityClass,
					_classAlias,
					entityPersister,
					type,
					tableAlias );
			return InitializeJoin( _path, destination, joinSequence, Columns, _origin, manyToMany );
		}

		private FromElement InitializeJoin(
				string path,
				FromElement destination,
				JoinSequence joinSequence,
				string[] columns,
				FromElement origin,
				bool manyToMany)
		{
			destination.SetType(HqlSqlWalker.JOIN_FRAGMENT);
			destination.JoinSequence = joinSequence;
			destination.Columns = columns;
			destination.SetOrigin(origin, manyToMany);
			_fromClause.AddJoinByPathMap(path, destination);
			return destination;
		}

		private FromElement EvaluateFromElementPath(string path, string classAlias)
		{
			ITreeAdaptor factory = _fromClause.ASTFactory;
			FromReferenceNode pathNode = (FromReferenceNode)PathHelper.ParsePath(path, factory);

			pathNode.RecursiveResolve(FromReferenceNode.ROOT_LEVEL, // This is the root level node.
					false, // Generate an explicit from clause at the root.
					classAlias,
					null
			);

			if (pathNode.GetImpliedJoin() != null)
			{
				return pathNode.GetImpliedJoin();
			}
			else
			{
				return pathNode.FromElement;
			}
		}

		private FromElement CreateFromElement(IEntityPersister entityPersister)
		{
			IJoinable joinable = (IJoinable)entityPersister;
			string text = joinable.TableName;
			ITree ast = CreateFromElement(text);
			FromElement element = (FromElement)ast;
			return element;
		}

		private ITree CreateFromElement(string text)
		{
			CommonTree ast = ASTUtil.Create(_fromClause.ASTFactory,
					_implied ? HqlSqlWalker.IMPLIED_FROM : HqlSqlWalker.FROM_FRAGMENT, // This causes the factory to instantiate the desired class.
					text);

			// Reset the node type, because the rest of the system is expecting FROM_FRAGMENT, all we wanted was
			// for the factory to create the right sub-class.  This might get reset again later on anyway to make the
			// SQL generation simpler.
			ast.SetType(HqlSqlWalker.FROM_FRAGMENT);

			return ast;
		}

		private void InitializeAndAddFromElement(FromElement element,
												string className,
												string classAlias,
												IEntityPersister entityPersister,
												EntityType type,
												string tableAlias)
		{
			if (tableAlias == null)
			{
				AliasGenerator aliasGenerator = _fromClause.AliasGenerator;
				tableAlias = aliasGenerator.CreateName(entityPersister.EntityName);
			}
			element.InitializeEntity(_fromClause, className, entityPersister, type, classAlias, tableAlias);
		}

		private FromElement CreateAndAddFromElement(
	        string className,
	        string classAlias,
	        IEntityPersister entityPersister,
	        EntityType type,
	        string tableAlias) 
		{
			if (!(entityPersister is IJoinable)) 
			{
				throw new ArgumentException("EntityPersister " + entityPersister + " does not implement Joinable!");
			}

			FromElement element = CreateFromElement( entityPersister );
			InitializeAndAddFromElement( element, className, classAlias, entityPersister, type, tableAlias );
			return element;
		}

		private string[] Columns
		{
			get
			{
				if (_columns == null)
				{
					throw new InvalidOperationException("No foriegn key columns were supplied!");
				}
				return _columns;
			}
		}

	}
}
