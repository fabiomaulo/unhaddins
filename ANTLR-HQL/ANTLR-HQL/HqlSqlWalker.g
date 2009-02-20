tree grammar HqlSqlWalker;

options
{
	language=CSharp2;
	output=AST;
	tokenVocab=Hql;
	ASTLabelType=CommonTree;
}

tokens
{
	FROM_FRAGMENT;	// A fragment of SQL that represents a table reference in a FROM clause.
	IMPLIED_FROM;	// An implied FROM element.
	JOIN_FRAGMENT;	// A JOIN fragment.
	SELECT_CLAUSE;
	LEFT_OUTER;
	RIGHT_OUTER;
	ALIAS_REF;      // An IDENT that is a reference to an entity via it's alias.
	PROPERTY_REF;   // A DOT that is a reference to a property in an entity.
	SQL_TOKEN;      // A chunk of SQL that is 'rendered' already.
	SELECT_COLUMNS; // A chunk of SQL representing a bunch of select columns.
	SELECT_EXPR;    // A select expression, generated from a FROM element.
	THETA_JOINS;	// Root of theta join condition subtree.
	FILTERS;		// Root of the filters condition subtree.
	METHOD_NAME;    // An IDENT that is a method name.
	NAMED_PARAM;    // A named parameter (:foo).
	BOGUS;          // Used for error state detection, etc.
}

@namespace { NHibernate.Hql.Ast.ANTLR }

@header
{
using System.Text;
using NHibernate.Hql.Ast.ANTLR.Tree;

}

// The main statement rule.
statement
	: selectStatement | updateStatement | deleteStatement | insertStatement
	;

selectStatement
	: query
	;

// Cannot use just the fromElement rule here in the update and delete queries
// because fromElement essentially relies on a FromClause already having been
// built :(
/*
TODO - check
updateStatement!
	: ^( u=UPDATE { beforeStatement( "update", UPDATE ); } (v=VERSIONED)? f=fromClause s=setClause (w=whereClause)? ) 
	{
		#updateStatement = #(#u, #f, #s, #w);
		beforeStatementCompletion( "update" );
		prepareVersioned( #updateStatement, #v );
		postProcessUpdate( #updateStatement );
		afterStatementCompletion( "update" );
	}
	;
*/
updateStatement!
	@after{
		beforeStatementCompletion( "update" );
		prepareVersioned( $updateStatement.tree, $v.tree );
		postProcessUpdate( $updateStatement.tree );
		afterStatementCompletion( "update" );
	}
	: ^( u=UPDATE { beforeStatement( "update", UPDATE ); } (v=VERSIONED)? f=fromClause s=setClause (w=whereClause)? ) 
		-> ^($u $f $s $w?)
	;

/*
TODO - check
deleteStatement
	: ^( DELETE { beforeStatement( "delete", DELETE ); } fromClause (whereClause)? ) {
		beforeStatementCompletion( "delete" );
		postProcessDelete( #deleteStatement );
		afterStatementCompletion( "delete" );
	}
	;
*/
deleteStatement
	@after {
		beforeStatementCompletion( "delete" );
		postProcessDelete( $deleteStatement.tree );
		afterStatementCompletion( "delete" );
	}
	: ^( DELETE { beforeStatement( "delete", DELETE ); } fromClause (whereClause)? ) 
	;

/*
TODO - check
insertStatement
	// currently only "INSERT ... SELECT ..." statements supported;
	// do we also need support for "INSERT ... VALUES ..."?
	//
	: ^( INSERT { beforeStatement( "insert", INSERT ); } intoClause query ) {
		beforeStatementCompletion( "insert" );
		postProcessInsert( #insertStatement );
		afterStatementCompletion( "insert" );
	}
	;
*/
insertStatement
	// currently only "INSERT ... SELECT ..." statements supported;
	// do we also need support for "INSERT ... VALUES ..."?
	//
	@after {
		beforeStatementCompletion( "insert" );
		postProcessInsert( $insertStatement.tree );
		afterStatementCompletion( "insert" );
	}
	: ^( INSERT { beforeStatement( "insert", INSERT ); } intoClause query ) 
	;

/*
TODO - check
intoClause! @init{
		String p = null;
	}
	: ^( INTO { handleClauseStart( INTO ); } (p=path) ps=insertablePropertySpec ) {
		#intoClause = createIntoClause(p, ps);
	}
	;

*/
intoClause! 
	: ^( INTO { handleClauseStart( INTO ); } (p=path) ps=insertablePropertySpec ) {
		$intoClause.tree = createIntoClause($p.tree, $ps.tree);
	}
	;

insertablePropertySpec
	: ^( RANGE (IDENT)+ )
	;

setClause
	: ^( SET { handleClauseStart( SET ); } (assignment)* )
	;

/*
TODO - check
assignment
	// Note: the propertyRef here needs to be resolved
	// *before* we evaluate the newValue rule...
	: ^( EQ (p=propertyRef) { resolve(#p); } (newValue) ) {
		evaluateAssignment( #assignment );
	}
	;
*/
assignment
	@after {
		evaluateAssignment( $assignment.tree );
	}
	// Note: the propertyRef here needs to be resolved
	// *before* we evaluate the newValue rule...
	: ^( EQ (p=propertyRef) { resolve($p.tree); } (newValue) ) 
	;

// For now, just use expr.  Revisit after ejb3 solidifies this.
newValue
	: expr | query
	;

// The query / subquery rule. Pops the current 'from node' context 
// (list of aliases).
/*
TODO - check
query!
	: ^( QUERY { beforeStatement( "select", SELECT ); }
			// The first phase places the FROM first to make processing the SELECT simpler.
			^(SELECT_FROM
				f=fromClause
				(s=selectClause)?
			)
			(w=whereClause)?
			(g=groupClause)?
			(o=orderClause)?
		) {
		// Antlr note: #x_in refers to the input AST, #x refers to the output AST
		#query = #([SELECT,"SELECT"], #s, #f, #w, #g, #o);
		beforeStatementCompletion( "select" );
		processQuery( #s, #query );
		afterStatementCompletion( "select" );
	}
	;
*/
query!
	@after {
		// Antlr note: #x_in refers to the input AST, #x refers to the output AST
		beforeStatementCompletion( "select" );
		processQuery( $s.tree, $query.tree );
		afterStatementCompletion( "select" );
	}
	: ^( QUERY { beforeStatement( "select", SELECT ); }
			// The first phase places the FROM first to make processing the SELECT simpler.
			^(SELECT_FROM
				f=fromClause
				(s=selectClause)?
			)
			(w=whereClause)?
			(g=groupClause)?
			(o=orderClause)?
		) 
	-> ^(SELECT $s? $f $w? $g? $o?)
	;

orderClause
	: ^(ORDER { handleClauseStart( ORDER ); } orderExprs)
	;

orderExprs
	: expr ( ASCENDING | DESCENDING )? (orderExprs)?
	;

groupClause
	: ^(GROUP { handleClauseStart( GROUP ); } (expr)+ ( ^(HAVING logicalExpr) )? )
	;

/*
TODO - check
selectClause!
	: ^(SELECT { handleClauseStart( SELECT ); beforeSelectClause(); } (d=DISTINCT)? x=selectExprList ) {
		#selectClause = #([SELECT_CLAUSE,"{select clause}"], #d, #x);
	}
	;
*/
selectClause!
	: ^(SELECT { handleClauseStart( SELECT ); beforeSelectClause(); } (d=DISTINCT)? x=selectExprList ) 
	-> ^(SELECT_CLAUSE $d? $x)
	;

selectExprList @init{
		bool oldInSelect = _inSelect;
		_inSelect = true;
	}
	: ( selectExpr | aliasedSelectExpr )+ {
		_inSelect = oldInSelect;
	}
	;

/*
TODO - check
aliasedSelectExpr!
	: ^(AS se=selectExpr i=identifier) {
	    setAlias(#se,#i);
		#aliasedSelectExpr = #se;
	}
	;
*/
aliasedSelectExpr!
	@after {
	    setAlias($se.tree,$i.tree);
	    $aliasedSelectExpr.tree = $se.tree;
	}
	: ^(AS se=selectExpr i=identifier) 
	;

/*
TODO - check
selectExpr
	: p=propertyRef					{ resolveSelectExpression(#p); }
	| ^(ALL ar2=aliasRef) 			{ resolveSelectExpression(#ar2); #selectExpr = #ar2; }
	| ^(OBJECT ar3=aliasRef)		{ resolveSelectExpression(#ar3); #selectExpr = #ar3; }
	| con=constructor 				{ processConstructor(#con); }
	| functionCall
	| count
	| collectionFunction			// elements() or indices()
	| literal
	| arithmeticExpr
	| query
	;
*/
selectExpr
	: p=propertyRef					{ resolveSelectExpression($p.tree); }
	| ^(ALL ar2=aliasRef) 			{ resolveSelectExpression($ar2.tree); $selectExpr.tree = $ar2.tree; }
	| ^(OBJECT ar3=aliasRef)		{ resolveSelectExpression($ar3.tree); $selectExpr.tree = $ar3.tree; }
	| con=constructor 				{ processConstructor($con.tree); }
	| functionCall
	| count
	| collectionFunction			// elements() or indices()
	| literal
	| arithmeticExpr
	| query
	;

count
	: ^(COUNT ( DISTINCT | ALL )? ( aggregateExpr | ROW_STAR ) )
	;

/*
TODO - check
constructor
	{ String className = null; }
	: #(CONSTRUCTOR className=path ( selectExpr | aliasedSelectExpr )* )
	;
*/
constructor
	: ^(CONSTRUCTOR path ( selectExpr | aliasedSelectExpr )* )
	;

aggregateExpr
	: expr //p:propertyRef { resolve(#p); }
	| collectionFunction
	;

// Establishes the list of aliases being used by this query.
/*
TODO - check. In particular, I've swapped "#fromClause_in" to "(ITree) input.LT(1)", which seems a little ugly.
		In addition, the PushFromClause now takes $f.tree as it's first argument;  the way that ANYTLR3 handles
		trees is looking quite different to v2
fromClause @init{
		// NOTE: This references the INPUT AST! (see http://www.antlr.org/doc/trees.html#Action Translation)
		// the ouput AST (#fromClause) has not been built yet.
		prepareFromClauseInputTree(#fromClause_in);
	}
	: ^(f=FROM { pushFromClause(#fromClause,f); handleClauseStart( FROM ); } fromElementList )
	;
*/
fromClause 
@init{
		// NOTE: This references the INPUT AST! (see http://www.antlr.org/doc/trees.html#Action Translation)
		// the ouput AST (#fromClause) has not been built yet.
		PrepareFromClauseInputTree((ITree) input.LT(1));
	}
	: ^(f=FROM { PushFromClause($f.tree, null); handleClauseStart( FROM ); } fromElementList )
	;

fromElementList @init{
		bool oldInFrom = _inFrom;
		_inFrom = true;
		}
	: (fromElement)+ {
		_inFrom = oldInFrom;
		}
	;

/*
TODO - check.  (Depending on the java methods being called, this can possibly
		by done in-line with the tree-rewrite stuff)
fromElement! @init{
	String p = null;
	}
	// A simple class name, alias element.
	: ^(RANGE p=path (a=ALIAS)? (pf=FETCH)? ) {
		#fromElement = createFromElement(p,a, pf);
	}
	| je=joinElement {
		#fromElement = #je;
	}
	// A from element created due to filter compilation
	| fe=FILTER_ENTITY a3=ALIAS {
		#fromElement = createFromFilterElement(fe,a3);
	}
	;
*/
fromElement! 
	// A simple class name, alias element.
	: ^(RANGE p=path (a=ALIAS)? (pf=FETCH)? ) 
		-> ^({createFromElement($p.p,$a, $pf)})
	| je=joinElement 
		-> ^($je)
	// A from element created due to filter compilation
	| fe=FILTER_ENTITY a3=ALIAS 
		-> ^({createFromFilterElement($fe,$a3)})
	;

/*
TODO - check
joinElement! @init{
		int j = INNER;
	}
	// A from element with a join.  This time, the 'path' should be treated as an AST
	// and resolved (like any path in a WHERE clause).   Make sure all implied joins
	// generated by the property ref use the join type, if it was specified.
	: ^(JOIN (j=joinType { setImpliedJoinType(j); } )? (f=FETCH)? ref=propertyRef (a=ALIAS)? (pf=FETCH)? (with=WITH)? ) {
		//createFromJoinElement(#ref,a,j,f, pf);
		createFromJoinElement(#ref,a,j,f, pf, with);
		setImpliedJoinType(INNER);	// Reset the implied join type.
	}
	;
*/
joinElement! 
	// A from element with a join.  This time, the 'path' should be treated as an AST
	// and resolved (like any path in a WHERE clause).   Make sure all implied joins
	// generated by the property ref use the join type, if it was specified.
	: ^(JOIN (j=joinType { setImpliedJoinType($j.tree); } )? (f=FETCH)? pRef=propertyRef (a=ALIAS)? (pf=FETCH)? (with=WITH)? ) {
		//createFromJoinElement(#ref,a,j,f, pf);
		createFromJoinElement($pRef.tree,$a,$j.tree,$f, $pf, $with);
		setImpliedJoinType(INNER);	// Reset the implied join type.
	}
	;

// Returns an node type integer that represents the join type
// tokens.
joinType returns [int j] @init{
	int j = INNER;
	}
	: ( (left=LEFT | right=RIGHT) (outer=OUTER)? ) {
		if (left != null)       j = LEFT_OUTER;
		else if (right != null) j = RIGHT_OUTER;
		else if (outer != null) j = RIGHT_OUTER;
	}
	| FULL {
		j = FULL;
	}
	| INNER {
		j = INNER;
	}
	;

// Matches a path and returns the normalized string for the path (usually
// fully qualified a class name).
path returns [String p] 
	: a=identifier { $p = $a.text; }
	| ^(DOT x=path y=identifier) {
			StringBuilder buf = new StringBuilder();
			buf.Append($x.p).Append('.').Append($y.text);
			$p = buf.ToString();
		}
	;

// Returns a path as a single identifier node.
/* 
TODO - check
pathAsIdent @init{
    String text = "?text?";
    }
    : text=path {
        #pathAsIdent = #([IDENT,text]);
    }
    ;
*/
pathAsIdent 
    : path 
    -> ^(IDENT path)
    ;

/*
TODO - check
withClause
	// Note : this is used internally from the HqlSqlWalker to
	// parse the node recognized with the with keyword earlier.
	// Done this way because it relies on the join it "qualifies"
	// already having been processed, which would not be the case
	// if withClause was simply referenced from the joinElement
	// rule during recognition...
	: ^(w=WITH { handleClauseStart( WITH ); } b=logicalExpr ) {
		#withClause = #(w , #b);
	}
	;
*/
withClause
	// Note : this is used internally from the HqlSqlWalker to
	// parse the node recognized with the with keyword earlier.
	// Done this way because it relies on the join it "qualifies"
	// already having been processed, which would not be the case
	// if withClause was simply referenced from the joinElement
	// rule during recognition...
	: ^(w=WITH { handleClauseStart( WITH ); } b=logicalExpr ) 
	-> ^($w $b)
	;

/*
TODO - check
whereClause
	: ^(w=WHERE { handleClauseStart( WHERE ); } b=logicalExpr ) {
		// Use the *output* AST for the bool expression!
		#whereClause = #(w , #b);
	}
	;
*/
whereClause
	: ^(w=WHERE { handleClauseStart( WHERE ); } b=logicalExpr ) 
	-> ^($w $b)
	;

logicalExpr
	: ^(AND logicalExpr logicalExpr)
	| ^(OR logicalExpr logicalExpr)
	| ^(NOT logicalExpr)
	| comparisonExpr
	;

// TODO: Add any other comparison operators here.
/*
TODO - check
comparisonExpr
	:
	( ^(EQ exprOrSubquery exprOrSubquery)
	| ^(NE exprOrSubquery exprOrSubquery)
	| ^(LT exprOrSubquery exprOrSubquery)
	| ^(GT exprOrSubquery exprOrSubquery)
	| ^(LE exprOrSubquery exprOrSubquery)
	| ^(GE exprOrSubquery exprOrSubquery)
	| ^(LIKE exprOrSubquery expr ( ^(ESCAPE expr) )? )
	| ^(NOT_LIKE exprOrSubquery expr ( ^(ESCAPE expr) )? )
	| ^(BETWEEN exprOrSubquery exprOrSubquery exprOrSubquery)
	| ^(NOT_BETWEEN exprOrSubquery exprOrSubquery exprOrSubquery)
	| ^(IN exprOrSubquery inRhs )
	| ^(NOT_IN exprOrSubquery inRhs )
	| ^(IS_NULL exprOrSubquery)
	| ^(IS_NOT_NULL exprOrSubquery)
//	| ^(IS_TRUE expr)
//	| ^(IS_FALSE expr)
	| ^(EXISTS ( expr | collectionFunctionOrSubselect ) )
	) {
	    prepareLogicOperator( #comparisonExpr );
	}
	;
*/
comparisonExpr
	@after {
	    prepareLogicOperator( $comparisonExpr.tree );
	}
	:
	( ^(EQ exprOrSubquery exprOrSubquery)
	| ^(NE exprOrSubquery exprOrSubquery)
	| ^(LT exprOrSubquery exprOrSubquery)
	| ^(GT exprOrSubquery exprOrSubquery)
	| ^(LE exprOrSubquery exprOrSubquery)
	| ^(GE exprOrSubquery exprOrSubquery)
	| ^(LIKE exprOrSubquery expr ( ^(ESCAPE expr) )? )
	| ^(NOT_LIKE exprOrSubquery expr ( ^(ESCAPE expr) )? )
	| ^(BETWEEN exprOrSubquery exprOrSubquery exprOrSubquery)
	| ^(NOT_BETWEEN exprOrSubquery exprOrSubquery exprOrSubquery)
	| ^(IN exprOrSubquery inRhs )
	| ^(NOT_IN exprOrSubquery inRhs )
	| ^(IS_NULL exprOrSubquery)
	| ^(IS_NOT_NULL exprOrSubquery)
//	| ^(IS_TRUE expr)
//	| ^(IS_FALSE expr)
	| ^(EXISTS ( expr | collectionFunctionOrSubselect ) )
	) 
	;

inRhs @init {	int UP = 99999;		// TODO - added this to get compile working.  It's bogus & should be removed
	}
	: ^(IN_LIST ( collectionFunctionOrSubselect | expr* ) )
	;

exprOrSubquery
	: expr
	| query
	| ^(ANY collectionFunctionOrSubselect)
	| ^(ALL collectionFunctionOrSubselect)
	| ^(SOME collectionFunctionOrSubselect)
	;
	
collectionFunctionOrSubselect
	: collectionFunction
	| query
	;
	
/*
TODO - check
expr
	: ae=addrExpr [ true ] { resolve(#ae); }	// Resolve the top level 'address expression'
	| ^( VECTOR_EXPR (expr)* )
	| constant
	| arithmeticExpr
	| functionCall							// Function call, not in the SELECT clause.
	| parameter
	| count										// Count, not in the SELECT clause.
	;
*/
expr
	: ae=addrExpr [ true ] { resolve($ae.tree); }	// Resolve the top level 'address expression'
	| ^( VECTOR_EXPR (expr)* )
	| constant
	| arithmeticExpr
	| functionCall							// Function call, not in the SELECT clause.
	| parameter
	| count										// Count, not in the SELECT clause.
	;

/*
TODO - check
arithmeticExpr
	: ^(PLUS expr expr)         { prepareArithmeticOperator( #arithmeticExpr ); }
	| ^(MINUS expr expr)        { prepareArithmeticOperator( #arithmeticExpr ); }
	| ^(DIV expr expr)          { prepareArithmeticOperator( #arithmeticExpr ); }
	| ^(STAR expr expr)         { prepareArithmeticOperator( #arithmeticExpr ); }
//	| ^(CONCAT expr (expr)+ )   { prepareArithmeticOperator( #arithmeticExpr ); }
	| ^(UNARY_MINUS expr)       { prepareArithmeticOperator( #arithmeticExpr ); }
	| caseExpr
	;
*/
arithmeticExpr
	@after {
		if ($c.tree == null)
		{
			prepareArithmeticOperator( $arithmeticExpr.tree );
		}
	}
	: ^(PLUS expr expr)
	| ^(MINUS expr expr)
	| ^(DIV expr expr)
	| ^(STAR expr expr)
//	| ^(CONCAT expr (expr)+ )
	| ^(UNARY_MINUS expr)
	| c=caseExpr
	;

caseExpr
	: ^(CASE { _inCase = true; } (^(WHEN logicalExpr expr))+ (^(ELSE expr))?) { _inCase = false; }
	| ^(CASE2 { _inCase = true; } expr (^(WHEN expr expr))+ (^(ELSE expr))?) { _inCase = false; }
	;

//TODO: I don't think we need this anymore .. how is it different to 
//      maxelements, etc, which are handled by functionCall
/* 
TODO - check
collectionFunction
	: ^(e=ELEMENTS {inFunctionCall=true;} p1=propertyRef { resolve(#p1); } ) 
		{ processFunction(#e,inSelect); } {inFunctionCall=false;}
	| ^(i=INDICES {inFunctionCall=true;} p2=propertyRef { resolve(#p2); } ) 
		{ processFunction(#i,inSelect); } {inFunctionCall=false;}
	;
*/
collectionFunction
	: ^(e=ELEMENTS {_inFunctionCall=true;} p1=propertyRef { resolve($p1.tree); } ) 
		{ processFunction($e.tree,_inSelect); } {_inFunctionCall=false;}
	| ^(i=INDICES {_inFunctionCall=true;} p2=propertyRef { resolve($p2.tree); } ) 
		{ processFunction($i.tree,_inSelect); } {_inFunctionCall=false;}
	;

/*
TODO - check
functionCall
	: ^(METHOD_CALL  {inFunctionCall=true;} pathAsIdent ( ^(EXPR_LIST (expr)* ) )? )
		{ processFunction(#functionCall,inSelect); } {inFunctionCall=false;}
	| ^(AGGREGATE aggregateExpr )
	;
*/
functionCall
	: ^(METHOD_CALL  {_inFunctionCall=true;} pathAsIdent ( ^(EXPR_LIST (expr)* ) )? )
		{ processFunction($functionCall.tree,_inSelect); } {_inFunctionCall=false;}
	| ^(AGGREGATE aggregateExpr )
	;

/*
TODO - check
constant
	: literal
	| NULL
	| TRUE { processbool(#constant); } 
	| FALSE { processbool(#constant); }
	| JAVA_CONSTANT
	;
*/
constant
	: literal
	| NULL
	| TRUE { processbool($constant.tree); } 
	| FALSE { processbool($constant.tree); }
	| JAVA_CONSTANT
	;

/*
TODO - check
literal
	: NUM_INT { processNumericLiteral( #literal ); }
	| NUM_LONG { processNumericLiteral( #literal ); }
	| NUM_FLOAT { processNumericLiteral( #literal ); }
	| NUM_DOUBLE { processNumericLiteral( #literal ); }
	| QUOTED_STRING
	;
*/
literal
	: numericLiteral
	| stringLiteral
	;

numericLiteral
@after
{
	processNumericLiteral( $numericLiteral.tree );
}
	: NUM_INT
	| NUM_LONG
	| NUM_FLOAT
	| NUM_DOUBLE
	;

stringLiteral
	: QUOTED_STRING
	;

identifier
	: (IDENT | WEIRD_IDENT)
	;

/*
TODO - check.  Think the "port" here is completely bogus.  Right now, just want it to compile...
addrExpr [ bool root ]
	: ^(d=DOT lhs=addrExprLhs rhs=propertyName )	{
		// This gives lookupProperty() a chance to transform the tree 
		// to process collection properties (.elements, etc).
		#addrExpr = #(#d, #lhs, #rhs);
		#addrExpr = lookupProperty(#addrExpr,root,false);
	}
	| ^(i=INDEX_OP lhs2=addrExprLhs rhs2=expr)	{
		#addrExpr = #(#i, #lhs2, #rhs2);
		processIndex(#addrExpr);
	}
	| p=identifier {
//		#addrExpr = #p;
//		resolve(#addrExpr);
		// In many cases, things other than property-refs are recognized
		// by this addrExpr rule.  Some of those I have seen:
		//  1) select-clause from-aliases
		//  2) sql-functions
		if ( isNonQualifiedPropertyRef(#p) ) {
			#addrExpr = lookupNonQualifiedProperty(#p);
		}
		else {
			resolve(#p);
			#addrExpr = #p;
		}
	}
	;
*/
addrExpr [ bool root ]
	: addrExprDot [root]
	| addrExprIndex [root]
	| addrExprIdent [root]
 	;

addrExprDot [ bool root ]
@after
{
	lookupProperty($addrExprDot.tree,root,false);
}
	:	^(d=DOT lhs=addrExprLhs rhs=propertyName )
		-> ^($d $lhs $rhs)
	;

addrExprIndex [ bool root ]
@after
{
	processIndex($addrExprIndex.tree);
}

	:	^(i=INDEX_OP lhs2=addrExprLhs rhs2=expr)	
		-> ^($i $lhs2 $rhs2)
	;

addrExprIdent [ bool root ]
	:	p=identifier 
	-> {isNonQualifiedPropertyRef($p.tree)}? ^({lookupNonQualifiedProperty($p.tree)})
	-> ^({resolve($p.tree)})
	;

addrExprLhs
	: addrExpr [ false ]
	;

propertyName
	: identifier
	| CLASS
	| ELEMENTS
	| INDICES
	;

/*
TODO - check
propertyRef!
	: ^(d=DOT lhs=propertyRefLhs rhs=propertyName )	{
		// This gives lookupProperty() a chance to transform the tree to process collection properties (.elements, etc).
		#propertyRef = #(#d, #lhs, #rhs);
		#propertyRef = lookupProperty(#propertyRef,false,true);
	}
	|
	p=identifier {
		// In many cases, things other than property-refs are recognized
		// by this propertyRef rule.  Some of those I have seen:
		//  1) select-clause from-aliases
		//  2) sql-functions
		if ( isNonQualifiedPropertyRef(#p) ) {
			#propertyRef = lookupNonQualifiedProperty(#p);
		}
		else {
			resolve(#p);
			#propertyRef = #p;
		}
	}
	;
*/
propertyRef!
	: ^(d=DOT lhs=propertyRefLhs rhs=propertyName )	
		-> ^($d $lhs $rhs)
	{
		// This gives lookupProperty() a chance to transform the tree to process collection properties (.elements, etc).
		lookupProperty($propertyRef.tree,false,true)
	}
	|
	p=identifier {
		// In many cases, things other than property-refs are recognized
		// by this propertyRef rule.  Some of those I have seen:
		//  1) select-clause from-aliases
		//  2) sql-functions
		if ( isNonQualifiedPropertyRef($p.tree) ) {
			$propertyRef.tree = lookupNonQualifiedProperty($p.tree);
		}
		else {
			resolve($p.tree);
			$propertyRef.tree = $p.tree;
		}
	}
	;

propertyRefLhs
	: propertyRef
	;

/*
TODO - check
aliasRef!
	: i=identifier {
		#aliasRef = #([ALIAS_REF,i.getText()]);	// Create an ALIAS_REF node instead of an IDENT node.
		lookupAlias(#aliasRef);
		}
	;
*/
aliasRef!
	@after
	{
		lookupAlias($aliasRef.tree);
	}
	: i=identifier 
	// TODO -> ^(ALIAS_REF[$i.start, $i.text])
	;

/*
TODO - check
parameter!
	: ^(c=COLON a=identifier) {
			// Create a NAMED_PARAM node instead of (COLON IDENT).
			#parameter = generateNamedParameter( c, a );
//			#parameter = #([NAMED_PARAM,a.getText()]);
//			namedParameter(#parameter);
		}
	| ^(p=PARAM (n=NUM_INT)?) {
			if ( n != null ) {
				// An ejb3-style "positional parameter", which we handle internally as a named-param
				#parameter = generateNamedParameter( p, n );
//				#parameter = #([NAMED_PARAM,n.getText()]);
//				namedParameter(#parameter);
			}
			else {
				#parameter = generatePositionalParameter( p );
//				#parameter = #([PARAM,"?"]);
//				positionalParameter(#parameter);
			}
		}
	;
*/

parameter!
	: ^(c=COLON a=identifier) {
			// Create a NAMED_PARAM node instead of (COLON IDENT).
			$parameter.tree = generateNamedParameter( c, a );
//			#parameter = #([NAMED_PARAM,a.getText()]);
//			namedParameter(#parameter);
		}
	| ^(p=PARAM (n=NUM_INT)?) {
			if ( n != null ) {
				// An ejb3-style "positional parameter", which we handle internally as a named-param
				$parameter.tree = generateNamedParameter( p, n );
//				#parameter = #([NAMED_PARAM,n.getText()]);
//				namedParameter(#parameter);
			}
			else {
				$parameter.tree = generatePositionalParameter( p );
//				#parameter = #([PARAM,"?"]);
//				positionalParameter(#parameter);
			}
		}
	;

numericInteger
	: NUM_INT
	;
