// $ANTLR 3.1.1 /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g 2009-02-23 10:44:54
// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162
namespace  NHibernate.Hql.Ast.ANTLR 
{

using NHibernate.Hql.Ast.ANTLR.Tree;


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;



using Antlr.Runtime.Tree;

public partial class HqlParser : Parser
{
    public static readonly string[] tokenNames = new string[] 
	{
        "<invalid>", 
		"<EOR>", 
		"<DOWN>", 
		"<UP>", 
		"ALL", 
		"ANY", 
		"AND", 
		"AS", 
		"ASCENDING", 
		"AVG", 
		"BETWEEN", 
		"CLASS", 
		"COUNT", 
		"DELETE", 
		"DESCENDING", 
		"DOT", 
		"DISTINCT", 
		"ELEMENTS", 
		"ESCAPE", 
		"EXISTS", 
		"FALSE", 
		"FETCH", 
		"FROM", 
		"FULL", 
		"GROUP", 
		"HAVING", 
		"IN", 
		"INDICES", 
		"INNER", 
		"INSERT", 
		"INTO", 
		"IS", 
		"JOIN", 
		"LEFT", 
		"LIKE", 
		"MAX", 
		"MIN", 
		"NEW", 
		"NOT", 
		"NULL", 
		"OR", 
		"ORDER", 
		"OUTER", 
		"PROPERTIES", 
		"RIGHT", 
		"SELECT", 
		"SET", 
		"SOME", 
		"SUM", 
		"TRUE", 
		"UNION", 
		"UPDATE", 
		"VERSIONED", 
		"WHERE", 
		"LITERAL_by", 
		"CASE", 
		"END", 
		"ELSE", 
		"THEN", 
		"WHEN", 
		"ON", 
		"WITH", 
		"BOTH", 
		"EMPTY", 
		"LEADING", 
		"MEMBER", 
		"OBJECT", 
		"OF", 
		"TRAILING", 
		"AGGREGATE", 
		"ALIAS", 
		"CONSTRUCTOR", 
		"CASE2", 
		"EXPR_LIST", 
		"FILTER_ENTITY", 
		"IN_LIST", 
		"INDEX_OP", 
		"IS_NOT_NULL", 
		"IS_NULL", 
		"METHOD_CALL", 
		"NOT_BETWEEN", 
		"NOT_IN", 
		"NOT_LIKE", 
		"ORDER_ELEMENT", 
		"QUERY", 
		"RANGE", 
		"ROW_STAR", 
		"SELECT_FROM", 
		"UNARY_MINUS", 
		"UNARY_PLUS", 
		"VECTOR_EXPR", 
		"WEIRD_IDENT", 
		"CONSTANT", 
		"NUM_INT", 
		"NUM_DOUBLE", 
		"NUM_FLOAT", 
		"NUM_LONG", 
		"JAVA_CONSTANT", 
		"COMMA", 
		"EQ", 
		"OPEN", 
		"CLOSE", 
		"NE", 
		"SQL_NE", 
		"LT", 
		"GT", 
		"LE", 
		"GE", 
		"CONCAT", 
		"PLUS", 
		"MINUS", 
		"STAR", 
		"DIV", 
		"OPEN_BRACKET", 
		"CLOSE_BRACKET", 
		"COLON", 
		"PARAM", 
		"QUOTED_String", 
		"IDENT", 
		"ID_START_LETTER", 
		"ID_LETTER", 
		"ESCqs", 
		"WS", 
		"EXPONENT", 
		"FLOAT_SUFFIX", 
		"HEX_DIGIT", 
		"'ascending'", 
		"'descending'"
    };

    public const int COMMA = 98;
    public const int EXISTS = 19;
    public const int EXPR_LIST = 73;
    public const int FETCH = 21;
    public const int MINUS = 110;
    public const int AS = 7;
    public const int END = 56;
    public const int INTO = 30;
    public const int FALSE = 20;
    public const int ELEMENTS = 17;
    public const int THEN = 58;
    public const int ALIAS = 70;
    public const int ON = 60;
    public const int DOT = 15;
    public const int ORDER = 41;
    public const int AND = 6;
    public const int CONSTANT = 92;
    public const int RIGHT = 44;
    public const int METHOD_CALL = 79;
    public const int UNARY_MINUS = 88;
    public const int CONCAT = 108;
    public const int PROPERTIES = 43;
    public const int SELECT = 45;
    public const int LE = 106;
    public const int BETWEEN = 10;
    public const int NUM_INT = 93;
    public const int BOTH = 62;
    public const int PLUS = 109;
    public const int VERSIONED = 52;
    public const int MEMBER = 65;
    public const int UNION = 50;
    public const int DISTINCT = 16;
    public const int RANGE = 85;
    public const int FILTER_ENTITY = 74;
    public const int IDENT = 118;
    public const int WHEN = 59;
    public const int DESCENDING = 14;
    public const int WS = 122;
    public const int EQ = 99;
    public const int NEW = 37;
    public const int LT = 104;
    public const int ESCqs = 121;
    public const int OF = 67;
    public const int UPDATE = 51;
    public const int SELECT_FROM = 87;
    public const int LITERAL_by = 54;
    public const int FLOAT_SUFFIX = 124;
    public const int ANY = 5;
    public const int UNARY_PLUS = 89;
    public const int NUM_FLOAT = 95;
    public const int GE = 107;
    public const int CASE = 55;
    public const int OPEN_BRACKET = 113;
    public const int ELSE = 57;
    public const int OPEN = 100;
    public const int COUNT = 12;
    public const int NULL = 39;
    public const int COLON = 115;
    public const int DIV = 112;
    public const int HAVING = 25;
    public const int ALL = 4;
    public const int SET = 46;
    public const int INSERT = 29;
    public const int TRUE = 49;
    public const int CASE2 = 72;
    public const int IS_NOT_NULL = 77;
    public const int WHERE = 53;
    public const int AGGREGATE = 69;
    public const int VECTOR_EXPR = 90;
    public const int LEADING = 64;
    public const int CLOSE_BRACKET = 114;
    public const int NUM_DOUBLE = 94;
    public const int T__126 = 126;
    public const int INNER = 28;
    public const int QUERY = 84;
    public const int ORDER_ELEMENT = 83;
    public const int OR = 40;
    public const int FULL = 23;
    public const int INDICES = 27;
    public const int IS_NULL = 78;
    public const int GROUP = 24;
    public const int ESCAPE = 18;
    public const int T__127 = 127;
    public const int PARAM = 116;
    public const int ID_LETTER = 120;
    public const int INDEX_OP = 76;
    public const int HEX_DIGIT = 125;
    public const int LEFT = 33;
    public const int TRAILING = 68;
    public const int JOIN = 32;
    public const int NOT_BETWEEN = 80;
    public const int SUM = 48;
    public const int ROW_STAR = 86;
    public const int OUTER = 42;
    public const int FROM = 22;
    public const int NOT_IN = 81;
    public const int DELETE = 13;
    public const int OBJECT = 66;
    public const int MAX = 35;
    public const int QUOTED_String = 117;
    public const int EMPTY = 63;
    public const int NOT_LIKE = 82;
    public const int ASCENDING = 8;
    public const int NUM_LONG = 96;
    public const int IS = 31;
    public const int SQL_NE = 103;
    public const int IN_LIST = 75;
    public const int WEIRD_IDENT = 91;
    public const int GT = 105;
    public const int NE = 102;
    public const int MIN = 36;
    public const int LIKE = 34;
    public const int WITH = 61;
    public const int IN = 26;
    public const int CONSTRUCTOR = 71;
    public const int CLASS = 11;
    public const int SOME = 47;
    public const int EXPONENT = 123;
    public const int ID_START_LETTER = 119;
    public const int EOF = -1;
    public const int CLOSE = 101;
    public const int AVG = 9;
    public const int STAR = 111;
    public const int NOT = 38;
    public const int JAVA_CONSTANT = 97;

    // delegates
    // delegators



        public HqlParser(ITokenStream input)
    		: this(input, new RecognizerSharedState()) {
        }

        public HqlParser(ITokenStream input, RecognizerSharedState state)
    		: base(input, state) {
            InitializeCyclicDFAs();

             
        }
        
    protected ITreeAdaptor adaptor = new CommonTreeAdaptor();

    public ITreeAdaptor TreeAdaptor
    {
        get { return this.adaptor; }
        set {
    	this.adaptor = value;
    	}
    }

    override public string[] TokenNames {
		get { return HqlParser.tokenNames; }
    }

    override public string GrammarFileName {
		get { return "/Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g"; }
    }


    public class statement_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "statement"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:142:1: statement : ( updateStatement | deleteStatement | selectStatement | insertStatement ) ;
    public HqlParser.statement_return statement() // throws RecognitionException [1]
    {   
        HqlParser.statement_return retval = new HqlParser.statement_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        HqlParser.updateStatement_return updateStatement1 = default(HqlParser.updateStatement_return);

        HqlParser.deleteStatement_return deleteStatement2 = default(HqlParser.deleteStatement_return);

        HqlParser.selectStatement_return selectStatement3 = default(HqlParser.selectStatement_return);

        HqlParser.insertStatement_return insertStatement4 = default(HqlParser.insertStatement_return);



        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:143:2: ( ( updateStatement | deleteStatement | selectStatement | insertStatement ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:143:4: ( updateStatement | deleteStatement | selectStatement | insertStatement )
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:143:4: ( updateStatement | deleteStatement | selectStatement | insertStatement )
            	int alt1 = 4;
            	alt1 = dfa1.Predict(input);
            	switch (alt1) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:143:6: updateStatement
            	        {
            	        	PushFollow(FOLLOW_updateStatement_in_statement603);
            	        	updateStatement1 = updateStatement();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, updateStatement1.Tree);

            	        }
            	        break;
            	    case 2 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:143:24: deleteStatement
            	        {
            	        	PushFollow(FOLLOW_deleteStatement_in_statement607);
            	        	deleteStatement2 = deleteStatement();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, deleteStatement2.Tree);

            	        }
            	        break;
            	    case 3 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:143:42: selectStatement
            	        {
            	        	PushFollow(FOLLOW_selectStatement_in_statement611);
            	        	selectStatement3 = selectStatement();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, selectStatement3.Tree);

            	        }
            	        break;
            	    case 4 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:143:60: insertStatement
            	        {
            	        	PushFollow(FOLLOW_insertStatement_in_statement615);
            	        	insertStatement4 = insertStatement();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, insertStatement4.Tree);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "statement"

    public class updateStatement_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "updateStatement"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:146:1: updateStatement : UPDATE ( VERSIONED )? optionalFromTokenFromClause setClause ( whereClause )? ;
    public HqlParser.updateStatement_return updateStatement() // throws RecognitionException [1]
    {   
        HqlParser.updateStatement_return retval = new HqlParser.updateStatement_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken UPDATE5 = null;
        IToken VERSIONED6 = null;
        HqlParser.optionalFromTokenFromClause_return optionalFromTokenFromClause7 = default(HqlParser.optionalFromTokenFromClause_return);

        HqlParser.setClause_return setClause8 = default(HqlParser.setClause_return);

        HqlParser.whereClause_return whereClause9 = default(HqlParser.whereClause_return);


        IASTNode UPDATE5_tree=null;
        IASTNode VERSIONED6_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:147:2: ( UPDATE ( VERSIONED )? optionalFromTokenFromClause setClause ( whereClause )? )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:147:4: UPDATE ( VERSIONED )? optionalFromTokenFromClause setClause ( whereClause )?
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	UPDATE5=(IToken)Match(input,UPDATE,FOLLOW_UPDATE_in_updateStatement628); 
            		UPDATE5_tree = (IASTNode)adaptor.Create(UPDATE5);
            		root_0 = (IASTNode)adaptor.BecomeRoot(UPDATE5_tree, root_0);

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:147:12: ( VERSIONED )?
            	int alt2 = 2;
            	int LA2_0 = input.LA(1);

            	if ( (LA2_0 == VERSIONED) )
            	{
            	    alt2 = 1;
            	}
            	switch (alt2) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:147:13: VERSIONED
            	        {
            	        	VERSIONED6=(IToken)Match(input,VERSIONED,FOLLOW_VERSIONED_in_updateStatement632); 
            	        		VERSIONED6_tree = (IASTNode)adaptor.Create(VERSIONED6);
            	        		adaptor.AddChild(root_0, VERSIONED6_tree);


            	        }
            	        break;

            	}

            	PushFollow(FOLLOW_optionalFromTokenFromClause_in_updateStatement638);
            	optionalFromTokenFromClause7 = optionalFromTokenFromClause();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, optionalFromTokenFromClause7.Tree);
            	PushFollow(FOLLOW_setClause_in_updateStatement642);
            	setClause8 = setClause();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, setClause8.Tree);
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:150:3: ( whereClause )?
            	int alt3 = 2;
            	int LA3_0 = input.LA(1);

            	if ( (LA3_0 == WHERE) )
            	{
            	    alt3 = 1;
            	}
            	switch (alt3) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:150:4: whereClause
            	        {
            	        	PushFollow(FOLLOW_whereClause_in_updateStatement647);
            	        	whereClause9 = whereClause();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, whereClause9.Tree);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "updateStatement"

    public class setClause_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "setClause"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:153:1: setClause : ( SET assignment ( COMMA assignment )* ) ;
    public HqlParser.setClause_return setClause() // throws RecognitionException [1]
    {   
        HqlParser.setClause_return retval = new HqlParser.setClause_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken SET10 = null;
        IToken COMMA12 = null;
        HqlParser.assignment_return assignment11 = default(HqlParser.assignment_return);

        HqlParser.assignment_return assignment13 = default(HqlParser.assignment_return);


        IASTNode SET10_tree=null;
        IASTNode COMMA12_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:154:2: ( ( SET assignment ( COMMA assignment )* ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:154:4: ( SET assignment ( COMMA assignment )* )
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:154:4: ( SET assignment ( COMMA assignment )* )
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:154:5: SET assignment ( COMMA assignment )*
            	{
            		SET10=(IToken)Match(input,SET,FOLLOW_SET_in_setClause661); 
            			SET10_tree = (IASTNode)adaptor.Create(SET10);
            			root_0 = (IASTNode)adaptor.BecomeRoot(SET10_tree, root_0);

            		PushFollow(FOLLOW_assignment_in_setClause664);
            		assignment11 = assignment();
            		state.followingStackPointer--;

            		adaptor.AddChild(root_0, assignment11.Tree);
            		// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:154:21: ( COMMA assignment )*
            		do 
            		{
            		    int alt4 = 2;
            		    int LA4_0 = input.LA(1);

            		    if ( (LA4_0 == COMMA) )
            		    {
            		        alt4 = 1;
            		    }


            		    switch (alt4) 
            			{
            				case 1 :
            				    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:154:22: COMMA assignment
            				    {
            				    	COMMA12=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_setClause667); 
            				    	PushFollow(FOLLOW_assignment_in_setClause670);
            				    	assignment13 = assignment();
            				    	state.followingStackPointer--;

            				    	adaptor.AddChild(root_0, assignment13.Tree);

            				    }
            				    break;

            				default:
            				    goto loop4;
            		    }
            		} while (true);

            		loop4:
            			;	// Stops C# compiler whining that label 'loop4' has no statements


            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "setClause"

    public class assignment_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "assignment"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:157:1: assignment : stateField EQ newValue ;
    public HqlParser.assignment_return assignment() // throws RecognitionException [1]
    {   
        HqlParser.assignment_return retval = new HqlParser.assignment_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken EQ15 = null;
        HqlParser.stateField_return stateField14 = default(HqlParser.stateField_return);

        HqlParser.newValue_return newValue16 = default(HqlParser.newValue_return);


        IASTNode EQ15_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:158:2: ( stateField EQ newValue )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:158:4: stateField EQ newValue
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	PushFollow(FOLLOW_stateField_in_assignment684);
            	stateField14 = stateField();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, stateField14.Tree);
            	EQ15=(IToken)Match(input,EQ,FOLLOW_EQ_in_assignment686); 
            		EQ15_tree = (IASTNode)adaptor.Create(EQ15);
            		root_0 = (IASTNode)adaptor.BecomeRoot(EQ15_tree, root_0);

            	PushFollow(FOLLOW_newValue_in_assignment689);
            	newValue16 = newValue();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, newValue16.Tree);

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "assignment"

    public class stateField_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "stateField"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:163:1: stateField : path ;
    public HqlParser.stateField_return stateField() // throws RecognitionException [1]
    {   
        HqlParser.stateField_return retval = new HqlParser.stateField_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        HqlParser.path_return path17 = default(HqlParser.path_return);



        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:164:2: ( path )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:164:4: path
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	PushFollow(FOLLOW_path_in_stateField702);
            	path17 = path();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, path17.Tree);

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "stateField"

    public class newValue_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "newValue"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:169:1: newValue : concatenation ;
    public HqlParser.newValue_return newValue() // throws RecognitionException [1]
    {   
        HqlParser.newValue_return retval = new HqlParser.newValue_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        HqlParser.concatenation_return concatenation18 = default(HqlParser.concatenation_return);



        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:170:2: ( concatenation )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:170:4: concatenation
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	PushFollow(FOLLOW_concatenation_in_newValue715);
            	concatenation18 = concatenation();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, concatenation18.Tree);

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "newValue"

    public class deleteStatement_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "deleteStatement"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:173:1: deleteStatement : DELETE ( optionalFromTokenFromClause ) ( whereClause )? ;
    public HqlParser.deleteStatement_return deleteStatement() // throws RecognitionException [1]
    {   
        HqlParser.deleteStatement_return retval = new HqlParser.deleteStatement_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken DELETE19 = null;
        HqlParser.optionalFromTokenFromClause_return optionalFromTokenFromClause20 = default(HqlParser.optionalFromTokenFromClause_return);

        HqlParser.whereClause_return whereClause21 = default(HqlParser.whereClause_return);


        IASTNode DELETE19_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:174:2: ( DELETE ( optionalFromTokenFromClause ) ( whereClause )? )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:174:4: DELETE ( optionalFromTokenFromClause ) ( whereClause )?
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	DELETE19=(IToken)Match(input,DELETE,FOLLOW_DELETE_in_deleteStatement726); 
            		DELETE19_tree = (IASTNode)adaptor.Create(DELETE19);
            		root_0 = (IASTNode)adaptor.BecomeRoot(DELETE19_tree, root_0);

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:175:3: ( optionalFromTokenFromClause )
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:175:4: optionalFromTokenFromClause
            	{
            		PushFollow(FOLLOW_optionalFromTokenFromClause_in_deleteStatement732);
            		optionalFromTokenFromClause20 = optionalFromTokenFromClause();
            		state.followingStackPointer--;

            		adaptor.AddChild(root_0, optionalFromTokenFromClause20.Tree);

            	}

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:176:3: ( whereClause )?
            	int alt5 = 2;
            	int LA5_0 = input.LA(1);

            	if ( (LA5_0 == WHERE) )
            	{
            	    alt5 = 1;
            	}
            	switch (alt5) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:176:4: whereClause
            	        {
            	        	PushFollow(FOLLOW_whereClause_in_deleteStatement738);
            	        	whereClause21 = whereClause();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, whereClause21.Tree);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "deleteStatement"

    public class optionalFromTokenFromClause_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "optionalFromTokenFromClause"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:188:1: optionalFromTokenFromClause : ( FROM )? path ( asAlias )? -> ^( FROM ^( RANGE path ( asAlias )? ) ) ;
    public HqlParser.optionalFromTokenFromClause_return optionalFromTokenFromClause() // throws RecognitionException [1]
    {   
        HqlParser.optionalFromTokenFromClause_return retval = new HqlParser.optionalFromTokenFromClause_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken FROM22 = null;
        HqlParser.path_return path23 = default(HqlParser.path_return);

        HqlParser.asAlias_return asAlias24 = default(HqlParser.asAlias_return);


        IASTNode FROM22_tree=null;
        RewriteRuleTokenStream stream_FROM = new RewriteRuleTokenStream(adaptor,"token FROM");
        RewriteRuleSubtreeStream stream_path = new RewriteRuleSubtreeStream(adaptor,"rule path");
        RewriteRuleSubtreeStream stream_asAlias = new RewriteRuleSubtreeStream(adaptor,"rule asAlias");
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:189:2: ( ( FROM )? path ( asAlias )? -> ^( FROM ^( RANGE path ( asAlias )? ) ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:189:4: ( FROM )? path ( asAlias )?
            {
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:189:4: ( FROM )?
            	int alt6 = 2;
            	int LA6_0 = input.LA(1);

            	if ( (LA6_0 == FROM) )
            	{
            	    alt6 = 1;
            	}
            	switch (alt6) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:189:5: FROM
            	        {
            	        	FROM22=(IToken)Match(input,FROM,FOLLOW_FROM_in_optionalFromTokenFromClause754);  
            	        	stream_FROM.Add(FROM22);


            	        }
            	        break;

            	}

            	PushFollow(FOLLOW_path_in_optionalFromTokenFromClause758);
            	path23 = path();
            	state.followingStackPointer--;

            	stream_path.Add(path23.Tree);
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:189:17: ( asAlias )?
            	int alt7 = 2;
            	int LA7_0 = input.LA(1);

            	if ( (LA7_0 == AS || LA7_0 == IDENT) )
            	{
            	    alt7 = 1;
            	}
            	switch (alt7) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:189:18: asAlias
            	        {
            	        	PushFollow(FOLLOW_asAlias_in_optionalFromTokenFromClause761);
            	        	asAlias24 = asAlias();
            	        	state.followingStackPointer--;

            	        	stream_asAlias.Add(asAlias24.Tree);

            	        }
            	        break;

            	}



            	// AST REWRITE
            	// elements:          path, asAlias, FROM
            	// token labels:      
            	// rule labels:       retval
            	// token list labels: 
            	// rule list labels:  
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));

            	root_0 = (IASTNode)adaptor.GetNilNode();
            	// 190:3: -> ^( FROM ^( RANGE path ( asAlias )? ) )
            	{
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:190:6: ^( FROM ^( RANGE path ( asAlias )? ) )
            	    {
            	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
            	    root_1 = (IASTNode)adaptor.BecomeRoot(stream_FROM.NextNode(), root_1);

            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:190:13: ^( RANGE path ( asAlias )? )
            	    {
            	    IASTNode root_2 = (IASTNode)adaptor.GetNilNode();
            	    root_2 = (IASTNode)adaptor.BecomeRoot((IASTNode)adaptor.Create(RANGE, "RANGE"), root_2);

            	    adaptor.AddChild(root_2, stream_path.NextTree());
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:190:26: ( asAlias )?
            	    if ( stream_asAlias.HasNext() )
            	    {
            	        adaptor.AddChild(root_2, stream_asAlias.NextTree());

            	    }
            	    stream_asAlias.Reset();

            	    adaptor.AddChild(root_1, root_2);
            	    }

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;retval.Tree = root_0;
            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "optionalFromTokenFromClause"

    public class selectStatement_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "selectStatement"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:201:1: selectStatement : q= queryRule -> ^( QUERY[\"query\"] $q) ;
    public HqlParser.selectStatement_return selectStatement() // throws RecognitionException [1]
    {   
        HqlParser.selectStatement_return retval = new HqlParser.selectStatement_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        HqlParser.queryRule_return q = default(HqlParser.queryRule_return);


        RewriteRuleSubtreeStream stream_queryRule = new RewriteRuleSubtreeStream(adaptor,"rule queryRule");
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:202:2: (q= queryRule -> ^( QUERY[\"query\"] $q) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:202:4: q= queryRule
            {
            	PushFollow(FOLLOW_queryRule_in_selectStatement796);
            	q = queryRule();
            	state.followingStackPointer--;

            	stream_queryRule.Add(q.Tree);


            	// AST REWRITE
            	// elements:          q
            	// token labels:      
            	// rule labels:       retval, q
            	// token list labels: 
            	// rule list labels:  
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));
            	RewriteRuleSubtreeStream stream_q = new RewriteRuleSubtreeStream(adaptor, "token q", (q!=null ? q.Tree : null));

            	root_0 = (IASTNode)adaptor.GetNilNode();
            	// 203:2: -> ^( QUERY[\"query\"] $q)
            	{
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:203:5: ^( QUERY[\"query\"] $q)
            	    {
            	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
            	    root_1 = (IASTNode)adaptor.BecomeRoot((IASTNode)adaptor.Create(QUERY, "query"), root_1);

            	    adaptor.AddChild(root_1, stream_q.NextTree());

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;retval.Tree = root_0;
            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "selectStatement"

    public class insertStatement_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "insertStatement"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:206:1: insertStatement : INSERT intoClause selectStatement ;
    public HqlParser.insertStatement_return insertStatement() // throws RecognitionException [1]
    {   
        HqlParser.insertStatement_return retval = new HqlParser.insertStatement_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken INSERT25 = null;
        HqlParser.intoClause_return intoClause26 = default(HqlParser.intoClause_return);

        HqlParser.selectStatement_return selectStatement27 = default(HqlParser.selectStatement_return);


        IASTNode INSERT25_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:210:2: ( INSERT intoClause selectStatement )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:210:4: INSERT intoClause selectStatement
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	INSERT25=(IToken)Match(input,INSERT,FOLLOW_INSERT_in_insertStatement825); 
            		INSERT25_tree = (IASTNode)adaptor.Create(INSERT25);
            		root_0 = (IASTNode)adaptor.BecomeRoot(INSERT25_tree, root_0);

            	PushFollow(FOLLOW_intoClause_in_insertStatement828);
            	intoClause26 = intoClause();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, intoClause26.Tree);
            	PushFollow(FOLLOW_selectStatement_in_insertStatement830);
            	selectStatement27 = selectStatement();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, selectStatement27.Tree);

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "insertStatement"

    public class intoClause_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "intoClause"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:213:1: intoClause : INTO path insertablePropertySpec ;
    public HqlParser.intoClause_return intoClause() // throws RecognitionException [1]
    {   
        HqlParser.intoClause_return retval = new HqlParser.intoClause_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken INTO28 = null;
        HqlParser.path_return path29 = default(HqlParser.path_return);

        HqlParser.insertablePropertySpec_return insertablePropertySpec30 = default(HqlParser.insertablePropertySpec_return);


        IASTNode INTO28_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:214:2: ( INTO path insertablePropertySpec )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:214:4: INTO path insertablePropertySpec
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	INTO28=(IToken)Match(input,INTO,FOLLOW_INTO_in_intoClause841); 
            		INTO28_tree = (IASTNode)adaptor.Create(INTO28);
            		root_0 = (IASTNode)adaptor.BecomeRoot(INTO28_tree, root_0);

            	PushFollow(FOLLOW_path_in_intoClause844);
            	path29 = path();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, path29.Tree);
            	 WeakKeywords(); 
            	PushFollow(FOLLOW_insertablePropertySpec_in_intoClause848);
            	insertablePropertySpec30 = insertablePropertySpec();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, insertablePropertySpec30.Tree);

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "intoClause"

    public class insertablePropertySpec_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "insertablePropertySpec"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:225:1: insertablePropertySpec : OPEN primaryExpression ( COMMA primaryExpression )* CLOSE -> ^( RANGE ^( OPEN ( primaryExpression )* ) ) ;
    public HqlParser.insertablePropertySpec_return insertablePropertySpec() // throws RecognitionException [1]
    {   
        HqlParser.insertablePropertySpec_return retval = new HqlParser.insertablePropertySpec_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken OPEN31 = null;
        IToken COMMA33 = null;
        IToken CLOSE35 = null;
        HqlParser.primaryExpression_return primaryExpression32 = default(HqlParser.primaryExpression_return);

        HqlParser.primaryExpression_return primaryExpression34 = default(HqlParser.primaryExpression_return);


        IASTNode OPEN31_tree=null;
        IASTNode COMMA33_tree=null;
        IASTNode CLOSE35_tree=null;
        RewriteRuleTokenStream stream_COMMA = new RewriteRuleTokenStream(adaptor,"token COMMA");
        RewriteRuleTokenStream stream_CLOSE = new RewriteRuleTokenStream(adaptor,"token CLOSE");
        RewriteRuleTokenStream stream_OPEN = new RewriteRuleTokenStream(adaptor,"token OPEN");
        RewriteRuleSubtreeStream stream_primaryExpression = new RewriteRuleSubtreeStream(adaptor,"rule primaryExpression");
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:226:2: ( OPEN primaryExpression ( COMMA primaryExpression )* CLOSE -> ^( RANGE ^( OPEN ( primaryExpression )* ) ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:226:4: OPEN primaryExpression ( COMMA primaryExpression )* CLOSE
            {
            	OPEN31=(IToken)Match(input,OPEN,FOLLOW_OPEN_in_insertablePropertySpec860);  
            	stream_OPEN.Add(OPEN31);

            	PushFollow(FOLLOW_primaryExpression_in_insertablePropertySpec862);
            	primaryExpression32 = primaryExpression();
            	state.followingStackPointer--;

            	stream_primaryExpression.Add(primaryExpression32.Tree);
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:226:27: ( COMMA primaryExpression )*
            	do 
            	{
            	    int alt8 = 2;
            	    int LA8_0 = input.LA(1);

            	    if ( (LA8_0 == COMMA) )
            	    {
            	        alt8 = 1;
            	    }


            	    switch (alt8) 
            		{
            			case 1 :
            			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:226:29: COMMA primaryExpression
            			    {
            			    	COMMA33=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_insertablePropertySpec866);  
            			    	stream_COMMA.Add(COMMA33);

            			    	PushFollow(FOLLOW_primaryExpression_in_insertablePropertySpec868);
            			    	primaryExpression34 = primaryExpression();
            			    	state.followingStackPointer--;

            			    	stream_primaryExpression.Add(primaryExpression34.Tree);

            			    }
            			    break;

            			default:
            			    goto loop8;
            	    }
            	} while (true);

            	loop8:
            		;	// Stops C# compiler whining that label 'loop8' has no statements

            	CLOSE35=(IToken)Match(input,CLOSE,FOLLOW_CLOSE_in_insertablePropertySpec873);  
            	stream_CLOSE.Add(CLOSE35);



            	// AST REWRITE
            	// elements:          primaryExpression, OPEN
            	// token labels:      
            	// rule labels:       retval
            	// token list labels: 
            	// rule list labels:  
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));

            	root_0 = (IASTNode)adaptor.GetNilNode();
            	// 227:3: -> ^( RANGE ^( OPEN ( primaryExpression )* ) )
            	{
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:227:6: ^( RANGE ^( OPEN ( primaryExpression )* ) )
            	    {
            	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
            	    root_1 = (IASTNode)adaptor.BecomeRoot((IASTNode)adaptor.Create(RANGE, "RANGE"), root_1);

            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:227:14: ^( OPEN ( primaryExpression )* )
            	    {
            	    IASTNode root_2 = (IASTNode)adaptor.GetNilNode();
            	    root_2 = (IASTNode)adaptor.BecomeRoot(stream_OPEN.NextNode(), root_2);

            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:227:20: ( primaryExpression )*
            	    while ( stream_primaryExpression.HasNext() )
            	    {
            	        adaptor.AddChild(root_2, stream_primaryExpression.NextTree());

            	    }
            	    stream_primaryExpression.Reset();

            	    adaptor.AddChild(root_1, root_2);
            	    }

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;retval.Tree = root_0;
            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "insertablePropertySpec"

    public class union_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "union"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:230:1: union : queryRule ( UNION queryRule )* ;
    public HqlParser.union_return union() // throws RecognitionException [1]
    {   
        HqlParser.union_return retval = new HqlParser.union_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken UNION37 = null;
        HqlParser.queryRule_return queryRule36 = default(HqlParser.queryRule_return);

        HqlParser.queryRule_return queryRule38 = default(HqlParser.queryRule_return);


        IASTNode UNION37_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:231:2: ( queryRule ( UNION queryRule )* )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:231:4: queryRule ( UNION queryRule )*
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	PushFollow(FOLLOW_queryRule_in_union900);
            	queryRule36 = queryRule();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, queryRule36.Tree);
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:231:14: ( UNION queryRule )*
            	do 
            	{
            	    int alt9 = 2;
            	    int LA9_0 = input.LA(1);

            	    if ( (LA9_0 == UNION) )
            	    {
            	        alt9 = 1;
            	    }


            	    switch (alt9) 
            		{
            			case 1 :
            			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:231:15: UNION queryRule
            			    {
            			    	UNION37=(IToken)Match(input,UNION,FOLLOW_UNION_in_union903); 
            			    		UNION37_tree = (IASTNode)adaptor.Create(UNION37);
            			    		adaptor.AddChild(root_0, UNION37_tree);

            			    	PushFollow(FOLLOW_queryRule_in_union905);
            			    	queryRule38 = queryRule();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, queryRule38.Tree);

            			    }
            			    break;

            			default:
            			    goto loop9;
            	    }
            	} while (true);

            	loop9:
            		;	// Stops C# compiler whining that label 'loop9' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "union"

    public class queryRule_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "queryRule"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:237:1: queryRule : selectFrom ( whereClause )? ( groupByClause )? ( orderByClause )? ;
    public HqlParser.queryRule_return queryRule() // throws RecognitionException [1]
    {   
        HqlParser.queryRule_return retval = new HqlParser.queryRule_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        HqlParser.selectFrom_return selectFrom39 = default(HqlParser.selectFrom_return);

        HqlParser.whereClause_return whereClause40 = default(HqlParser.whereClause_return);

        HqlParser.groupByClause_return groupByClause41 = default(HqlParser.groupByClause_return);

        HqlParser.orderByClause_return orderByClause42 = default(HqlParser.orderByClause_return);



        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:238:2: ( selectFrom ( whereClause )? ( groupByClause )? ( orderByClause )? )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:238:4: selectFrom ( whereClause )? ( groupByClause )? ( orderByClause )?
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	PushFollow(FOLLOW_selectFrom_in_queryRule921);
            	selectFrom39 = selectFrom();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, selectFrom39.Tree);
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:239:3: ( whereClause )?
            	int alt10 = 2;
            	int LA10_0 = input.LA(1);

            	if ( (LA10_0 == WHERE) )
            	{
            	    alt10 = 1;
            	}
            	switch (alt10) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:239:4: whereClause
            	        {
            	        	PushFollow(FOLLOW_whereClause_in_queryRule926);
            	        	whereClause40 = whereClause();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, whereClause40.Tree);

            	        }
            	        break;

            	}

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:240:3: ( groupByClause )?
            	int alt11 = 2;
            	int LA11_0 = input.LA(1);

            	if ( (LA11_0 == GROUP) )
            	{
            	    alt11 = 1;
            	}
            	switch (alt11) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:240:4: groupByClause
            	        {
            	        	PushFollow(FOLLOW_groupByClause_in_queryRule933);
            	        	groupByClause41 = groupByClause();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, groupByClause41.Tree);

            	        }
            	        break;

            	}

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:241:3: ( orderByClause )?
            	int alt12 = 2;
            	int LA12_0 = input.LA(1);

            	if ( (LA12_0 == ORDER) )
            	{
            	    alt12 = 1;
            	}
            	switch (alt12) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:241:4: orderByClause
            	        {
            	        	PushFollow(FOLLOW_orderByClause_in_queryRule940);
            	        	orderByClause42 = orderByClause();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, orderByClause42.Tree);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "queryRule"

    public class selectFrom_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "selectFrom"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:266:1: selectFrom : (s= selectClause )? (f= fromClause )? -> {$f.tree == null && filter}? ^( SELECT_FROM FROM[\"{filter-implied FROM}\"] ) -> ^( SELECT_FROM ( fromClause )? ( selectClause )? ) ;
    public HqlParser.selectFrom_return selectFrom() // throws RecognitionException [1]
    {   
        HqlParser.selectFrom_return retval = new HqlParser.selectFrom_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        HqlParser.selectClause_return s = default(HqlParser.selectClause_return);

        HqlParser.fromClause_return f = default(HqlParser.fromClause_return);


        RewriteRuleSubtreeStream stream_selectClause = new RewriteRuleSubtreeStream(adaptor,"rule selectClause");
        RewriteRuleSubtreeStream stream_fromClause = new RewriteRuleSubtreeStream(adaptor,"rule fromClause");
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:267:2: ( (s= selectClause )? (f= fromClause )? -> {$f.tree == null && filter}? ^( SELECT_FROM FROM[\"{filter-implied FROM}\"] ) -> ^( SELECT_FROM ( fromClause )? ( selectClause )? ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:267:5: (s= selectClause )? (f= fromClause )?
            {
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:267:5: (s= selectClause )?
            	int alt13 = 2;
            	int LA13_0 = input.LA(1);

            	if ( (LA13_0 == SELECT) )
            	{
            	    alt13 = 1;
            	}
            	switch (alt13) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:267:6: s= selectClause
            	        {
            	        	PushFollow(FOLLOW_selectClause_in_selectFrom961);
            	        	s = selectClause();
            	        	state.followingStackPointer--;

            	        	stream_selectClause.Add(s.Tree);

            	        }
            	        break;

            	}

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:267:23: (f= fromClause )?
            	int alt14 = 2;
            	int LA14_0 = input.LA(1);

            	if ( (LA14_0 == FROM) )
            	{
            	    alt14 = 1;
            	}
            	switch (alt14) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:267:24: f= fromClause
            	        {
            	        	PushFollow(FOLLOW_fromClause_in_selectFrom968);
            	        	f = fromClause();
            	        	state.followingStackPointer--;

            	        	stream_fromClause.Add(f.Tree);

            	        }
            	        break;

            	}


            				if (((f != null) ? ((IASTNode)f.Tree) : null) == null && !filter) 
            					throw new RecognitionException("FROM expected (non-filter queries must contain a FROM clause)");
            			


            	// AST REWRITE
            	// elements:          selectClause, fromClause
            	// token labels:      
            	// rule labels:       retval
            	// token list labels: 
            	// rule list labels:  
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));

            	root_0 = (IASTNode)adaptor.GetNilNode();
            	// 272:3: -> {$f.tree == null && filter}? ^( SELECT_FROM FROM[\"{filter-implied FROM}\"] )
            	if (((f != null) ? ((IASTNode)f.Tree) : null) == null && filter)
            	{
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:272:35: ^( SELECT_FROM FROM[\"{filter-implied FROM}\"] )
            	    {
            	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
            	    root_1 = (IASTNode)adaptor.BecomeRoot((IASTNode)adaptor.Create(SELECT_FROM, "SELECT_FROM"), root_1);

            	    adaptor.AddChild(root_1, (IASTNode)adaptor.Create(FROM, "{filter-implied FROM}"));

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}
            	else // 273:3: -> ^( SELECT_FROM ( fromClause )? ( selectClause )? )
            	{
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:273:6: ^( SELECT_FROM ( fromClause )? ( selectClause )? )
            	    {
            	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
            	    root_1 = (IASTNode)adaptor.BecomeRoot((IASTNode)adaptor.Create(SELECT_FROM, "SELECT_FROM"), root_1);

            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:273:20: ( fromClause )?
            	    if ( stream_fromClause.HasNext() )
            	    {
            	        adaptor.AddChild(root_1, stream_fromClause.NextTree());

            	    }
            	    stream_fromClause.Reset();
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:273:32: ( selectClause )?
            	    if ( stream_selectClause.HasNext() )
            	    {
            	        adaptor.AddChild(root_1, stream_selectClause.NextTree());

            	    }
            	    stream_selectClause.Reset();

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;retval.Tree = root_0;
            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "selectFrom"

    public class selectClause_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "selectClause"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:281:1: selectClause : SELECT ( DISTINCT )? ( selectedPropertiesList | newExpression | selectObject ) ;
    public HqlParser.selectClause_return selectClause() // throws RecognitionException [1]
    {   
        HqlParser.selectClause_return retval = new HqlParser.selectClause_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken SELECT43 = null;
        IToken DISTINCT44 = null;
        HqlParser.selectedPropertiesList_return selectedPropertiesList45 = default(HqlParser.selectedPropertiesList_return);

        HqlParser.newExpression_return newExpression46 = default(HqlParser.newExpression_return);

        HqlParser.selectObject_return selectObject47 = default(HqlParser.selectObject_return);


        IASTNode SELECT43_tree=null;
        IASTNode DISTINCT44_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:282:2: ( SELECT ( DISTINCT )? ( selectedPropertiesList | newExpression | selectObject ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:282:4: SELECT ( DISTINCT )? ( selectedPropertiesList | newExpression | selectObject )
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	SELECT43=(IToken)Match(input,SELECT,FOLLOW_SELECT_in_selectClause1018); 
            		SELECT43_tree = (IASTNode)adaptor.Create(SELECT43);
            		root_0 = (IASTNode)adaptor.BecomeRoot(SELECT43_tree, root_0);

            	 WeakKeywords(); 
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:284:3: ( DISTINCT )?
            	int alt15 = 2;
            	alt15 = dfa15.Predict(input);
            	switch (alt15) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:284:4: DISTINCT
            	        {
            	        	DISTINCT44=(IToken)Match(input,DISTINCT,FOLLOW_DISTINCT_in_selectClause1030); 
            	        		DISTINCT44_tree = (IASTNode)adaptor.Create(DISTINCT44);
            	        		adaptor.AddChild(root_0, DISTINCT44_tree);


            	        }
            	        break;

            	}

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:284:15: ( selectedPropertiesList | newExpression | selectObject )
            	int alt16 = 3;
            	alt16 = dfa16.Predict(input);
            	switch (alt16) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:284:17: selectedPropertiesList
            	        {
            	        	PushFollow(FOLLOW_selectedPropertiesList_in_selectClause1036);
            	        	selectedPropertiesList45 = selectedPropertiesList();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, selectedPropertiesList45.Tree);

            	        }
            	        break;
            	    case 2 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:284:42: newExpression
            	        {
            	        	PushFollow(FOLLOW_newExpression_in_selectClause1040);
            	        	newExpression46 = newExpression();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, newExpression46.Tree);

            	        }
            	        break;
            	    case 3 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:284:58: selectObject
            	        {
            	        	PushFollow(FOLLOW_selectObject_in_selectClause1044);
            	        	selectObject47 = selectObject();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, selectObject47.Tree);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "selectClause"

    public class newExpression_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "newExpression"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:293:1: newExpression : ( NEW path ) op= OPEN selectedPropertiesList CLOSE -> ^( CONSTRUCTOR[$op] path selectedPropertiesList ) ;
    public HqlParser.newExpression_return newExpression() // throws RecognitionException [1]
    {   
        HqlParser.newExpression_return retval = new HqlParser.newExpression_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken op = null;
        IToken NEW48 = null;
        IToken CLOSE51 = null;
        HqlParser.path_return path49 = default(HqlParser.path_return);

        HqlParser.selectedPropertiesList_return selectedPropertiesList50 = default(HqlParser.selectedPropertiesList_return);


        IASTNode op_tree=null;
        IASTNode NEW48_tree=null;
        IASTNode CLOSE51_tree=null;
        RewriteRuleTokenStream stream_CLOSE = new RewriteRuleTokenStream(adaptor,"token CLOSE");
        RewriteRuleTokenStream stream_OPEN = new RewriteRuleTokenStream(adaptor,"token OPEN");
        RewriteRuleTokenStream stream_NEW = new RewriteRuleTokenStream(adaptor,"token NEW");
        RewriteRuleSubtreeStream stream_selectedPropertiesList = new RewriteRuleSubtreeStream(adaptor,"rule selectedPropertiesList");
        RewriteRuleSubtreeStream stream_path = new RewriteRuleSubtreeStream(adaptor,"rule path");
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:294:2: ( ( NEW path ) op= OPEN selectedPropertiesList CLOSE -> ^( CONSTRUCTOR[$op] path selectedPropertiesList ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:294:4: ( NEW path ) op= OPEN selectedPropertiesList CLOSE
            {
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:294:4: ( NEW path )
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:294:5: NEW path
            	{
            		NEW48=(IToken)Match(input,NEW,FOLLOW_NEW_in_newExpression1060);  
            		stream_NEW.Add(NEW48);

            		PushFollow(FOLLOW_path_in_newExpression1062);
            		path49 = path();
            		state.followingStackPointer--;

            		stream_path.Add(path49.Tree);

            	}

            	op=(IToken)Match(input,OPEN,FOLLOW_OPEN_in_newExpression1067);  
            	stream_OPEN.Add(op);

            	PushFollow(FOLLOW_selectedPropertiesList_in_newExpression1069);
            	selectedPropertiesList50 = selectedPropertiesList();
            	state.followingStackPointer--;

            	stream_selectedPropertiesList.Add(selectedPropertiesList50.Tree);
            	CLOSE51=(IToken)Match(input,CLOSE,FOLLOW_CLOSE_in_newExpression1071);  
            	stream_CLOSE.Add(CLOSE51);



            	// AST REWRITE
            	// elements:          path, selectedPropertiesList
            	// token labels:      
            	// rule labels:       retval
            	// token list labels: 
            	// rule list labels:  
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));

            	root_0 = (IASTNode)adaptor.GetNilNode();
            	// 295:3: -> ^( CONSTRUCTOR[$op] path selectedPropertiesList )
            	{
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:295:6: ^( CONSTRUCTOR[$op] path selectedPropertiesList )
            	    {
            	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
            	    root_1 = (IASTNode)adaptor.BecomeRoot((IASTNode)adaptor.Create(CONSTRUCTOR, op), root_1);

            	    adaptor.AddChild(root_1, stream_path.NextTree());
            	    adaptor.AddChild(root_1, stream_selectedPropertiesList.NextTree());

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;retval.Tree = root_0;
            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "newExpression"

    public class selectObject_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "selectObject"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:298:1: selectObject : OBJECT OPEN identifier CLOSE ;
    public HqlParser.selectObject_return selectObject() // throws RecognitionException [1]
    {   
        HqlParser.selectObject_return retval = new HqlParser.selectObject_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken OBJECT52 = null;
        IToken OPEN53 = null;
        IToken CLOSE55 = null;
        HqlParser.identifier_return identifier54 = default(HqlParser.identifier_return);


        IASTNode OBJECT52_tree=null;
        IASTNode OPEN53_tree=null;
        IASTNode CLOSE55_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:299:4: ( OBJECT OPEN identifier CLOSE )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:299:6: OBJECT OPEN identifier CLOSE
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	OBJECT52=(IToken)Match(input,OBJECT,FOLLOW_OBJECT_in_selectObject1097); 
            		OBJECT52_tree = (IASTNode)adaptor.Create(OBJECT52);
            		root_0 = (IASTNode)adaptor.BecomeRoot(OBJECT52_tree, root_0);

            	OPEN53=(IToken)Match(input,OPEN,FOLLOW_OPEN_in_selectObject1100); 
            	PushFollow(FOLLOW_identifier_in_selectObject1103);
            	identifier54 = identifier();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, identifier54.Tree);
            	CLOSE55=(IToken)Match(input,CLOSE,FOLLOW_CLOSE_in_selectObject1105); 

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "selectObject"

    public class fromClause_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "fromClause"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:309:1: fromClause : FROM fromRange ( fromJoin | COMMA fromRange )* ;
    public HqlParser.fromClause_return fromClause() // throws RecognitionException [1]
    {   
        HqlParser.fromClause_return retval = new HqlParser.fromClause_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken FROM56 = null;
        IToken COMMA59 = null;
        HqlParser.fromRange_return fromRange57 = default(HqlParser.fromRange_return);

        HqlParser.fromJoin_return fromJoin58 = default(HqlParser.fromJoin_return);

        HqlParser.fromRange_return fromRange60 = default(HqlParser.fromRange_return);


        IASTNode FROM56_tree=null;
        IASTNode COMMA59_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:310:2: ( FROM fromRange ( fromJoin | COMMA fromRange )* )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:310:4: FROM fromRange ( fromJoin | COMMA fromRange )*
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	FROM56=(IToken)Match(input,FROM,FOLLOW_FROM_in_fromClause1126); 
            		FROM56_tree = (IASTNode)adaptor.Create(FROM56);
            		root_0 = (IASTNode)adaptor.BecomeRoot(FROM56_tree, root_0);

            	 WeakKeywords(); 
            	PushFollow(FOLLOW_fromRange_in_fromClause1131);
            	fromRange57 = fromRange();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, fromRange57.Tree);
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:310:40: ( fromJoin | COMMA fromRange )*
            	do 
            	{
            	    int alt17 = 3;
            	    alt17 = dfa17.Predict(input);
            	    switch (alt17) 
            		{
            			case 1 :
            			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:310:42: fromJoin
            			    {
            			    	PushFollow(FOLLOW_fromJoin_in_fromClause1135);
            			    	fromJoin58 = fromJoin();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, fromJoin58.Tree);

            			    }
            			    break;
            			case 2 :
            			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:310:53: COMMA fromRange
            			    {
            			    	COMMA59=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_fromClause1139); 
            			    	 WeakKeywords(); 
            			    	PushFollow(FOLLOW_fromRange_in_fromClause1144);
            			    	fromRange60 = fromRange();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, fromRange60.Tree);

            			    }
            			    break;

            			default:
            			    goto loop17;
            	    }
            	} while (true);

            	loop17:
            		;	// Stops C# compiler whining that label 'loop17' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "fromClause"

    public class fromJoin_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "fromJoin"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:316:1: fromJoin : ( ( ( LEFT | RIGHT ) ( OUTER )? ) | FULL | INNER )? JOIN ( FETCH )? path ( asAlias )? ( propertyFetch )? ( withClause )? ;
    public HqlParser.fromJoin_return fromJoin() // throws RecognitionException [1]
    {   
        HqlParser.fromJoin_return retval = new HqlParser.fromJoin_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken set61 = null;
        IToken OUTER62 = null;
        IToken FULL63 = null;
        IToken INNER64 = null;
        IToken JOIN65 = null;
        IToken FETCH66 = null;
        HqlParser.path_return path67 = default(HqlParser.path_return);

        HqlParser.asAlias_return asAlias68 = default(HqlParser.asAlias_return);

        HqlParser.propertyFetch_return propertyFetch69 = default(HqlParser.propertyFetch_return);

        HqlParser.withClause_return withClause70 = default(HqlParser.withClause_return);


        IASTNode set61_tree=null;
        IASTNode OUTER62_tree=null;
        IASTNode FULL63_tree=null;
        IASTNode INNER64_tree=null;
        IASTNode JOIN65_tree=null;
        IASTNode FETCH66_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:317:2: ( ( ( ( LEFT | RIGHT ) ( OUTER )? ) | FULL | INNER )? JOIN ( FETCH )? path ( asAlias )? ( propertyFetch )? ( withClause )? )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:317:4: ( ( ( LEFT | RIGHT ) ( OUTER )? ) | FULL | INNER )? JOIN ( FETCH )? path ( asAlias )? ( propertyFetch )? ( withClause )?
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:317:4: ( ( ( LEFT | RIGHT ) ( OUTER )? ) | FULL | INNER )?
            	int alt19 = 4;
            	switch ( input.LA(1) ) 
            	{
            	    case LEFT:
            	    case RIGHT:
            	    	{
            	        alt19 = 1;
            	        }
            	        break;
            	    case FULL:
            	    	{
            	        alt19 = 2;
            	        }
            	        break;
            	    case INNER:
            	    	{
            	        alt19 = 3;
            	        }
            	        break;
            	}

            	switch (alt19) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:317:6: ( ( LEFT | RIGHT ) ( OUTER )? )
            	        {
            	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:317:6: ( ( LEFT | RIGHT ) ( OUTER )? )
            	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:317:8: ( LEFT | RIGHT ) ( OUTER )?
            	        	{
            	        		set61 = (IToken)input.LT(1);
            	        		if ( input.LA(1) == LEFT || input.LA(1) == RIGHT ) 
            	        		{
            	        		    input.Consume();
            	        		    adaptor.AddChild(root_0, (IASTNode)adaptor.Create(set61));
            	        		    state.errorRecovery = false;
            	        		}
            	        		else 
            	        		{
            	        		    MismatchedSetException mse = new MismatchedSetException(null,input);
            	        		    throw mse;
            	        		}

            	        		// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:317:25: ( OUTER )?
            	        		int alt18 = 2;
            	        		int LA18_0 = input.LA(1);

            	        		if ( (LA18_0 == OUTER) )
            	        		{
            	        		    alt18 = 1;
            	        		}
            	        		switch (alt18) 
            	        		{
            	        		    case 1 :
            	        		        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:317:26: OUTER
            	        		        {
            	        		        	OUTER62=(IToken)Match(input,OUTER,FOLLOW_OUTER_in_fromJoin1176); 
            	        		        		OUTER62_tree = (IASTNode)adaptor.Create(OUTER62);
            	        		        		adaptor.AddChild(root_0, OUTER62_tree);


            	        		        }
            	        		        break;

            	        		}


            	        	}


            	        }
            	        break;
            	    case 2 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:317:38: FULL
            	        {
            	        	FULL63=(IToken)Match(input,FULL,FOLLOW_FULL_in_fromJoin1184); 
            	        		FULL63_tree = (IASTNode)adaptor.Create(FULL63);
            	        		adaptor.AddChild(root_0, FULL63_tree);


            	        }
            	        break;
            	    case 3 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:317:45: INNER
            	        {
            	        	INNER64=(IToken)Match(input,INNER,FOLLOW_INNER_in_fromJoin1188); 
            	        		INNER64_tree = (IASTNode)adaptor.Create(INNER64);
            	        		adaptor.AddChild(root_0, INNER64_tree);


            	        }
            	        break;

            	}

            	JOIN65=(IToken)Match(input,JOIN,FOLLOW_JOIN_in_fromJoin1193); 
            		JOIN65_tree = (IASTNode)adaptor.Create(JOIN65);
            		root_0 = (IASTNode)adaptor.BecomeRoot(JOIN65_tree, root_0);

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:317:60: ( FETCH )?
            	int alt20 = 2;
            	int LA20_0 = input.LA(1);

            	if ( (LA20_0 == FETCH) )
            	{
            	    alt20 = 1;
            	}
            	switch (alt20) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:317:61: FETCH
            	        {
            	        	FETCH66=(IToken)Match(input,FETCH,FOLLOW_FETCH_in_fromJoin1197); 
            	        		FETCH66_tree = (IASTNode)adaptor.Create(FETCH66);
            	        		adaptor.AddChild(root_0, FETCH66_tree);


            	        }
            	        break;

            	}

            	PushFollow(FOLLOW_path_in_fromJoin1205);
            	path67 = path();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, path67.Tree);
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:318:9: ( asAlias )?
            	int alt21 = 2;
            	alt21 = dfa21.Predict(input);
            	switch (alt21) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:318:10: asAlias
            	        {
            	        	PushFollow(FOLLOW_asAlias_in_fromJoin1208);
            	        	asAlias68 = asAlias();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, asAlias68.Tree);

            	        }
            	        break;

            	}

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:318:20: ( propertyFetch )?
            	int alt22 = 2;
            	alt22 = dfa22.Predict(input);
            	switch (alt22) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:318:21: propertyFetch
            	        {
            	        	PushFollow(FOLLOW_propertyFetch_in_fromJoin1213);
            	        	propertyFetch69 = propertyFetch();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, propertyFetch69.Tree);

            	        }
            	        break;

            	}

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:318:37: ( withClause )?
            	int alt23 = 2;
            	alt23 = dfa23.Predict(input);
            	switch (alt23) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:318:38: withClause
            	        {
            	        	PushFollow(FOLLOW_withClause_in_fromJoin1218);
            	        	withClause70 = withClause();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, withClause70.Tree);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "fromJoin"

    public class withClause_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "withClause"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:321:1: withClause : WITH logicalExpression ;
    public HqlParser.withClause_return withClause() // throws RecognitionException [1]
    {   
        HqlParser.withClause_return retval = new HqlParser.withClause_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken WITH71 = null;
        HqlParser.logicalExpression_return logicalExpression72 = default(HqlParser.logicalExpression_return);


        IASTNode WITH71_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:322:2: ( WITH logicalExpression )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:322:4: WITH logicalExpression
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	WITH71=(IToken)Match(input,WITH,FOLLOW_WITH_in_withClause1231); 
            		WITH71_tree = (IASTNode)adaptor.Create(WITH71);
            		root_0 = (IASTNode)adaptor.BecomeRoot(WITH71_tree, root_0);

            	PushFollow(FOLLOW_logicalExpression_in_withClause1234);
            	logicalExpression72 = logicalExpression();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, logicalExpression72.Tree);

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "withClause"

    public class fromRange_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "fromRange"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:325:1: fromRange : ( fromClassOrOuterQueryPath | inClassDeclaration | inCollectionDeclaration | inCollectionElementsDeclaration );
    public HqlParser.fromRange_return fromRange() // throws RecognitionException [1]
    {   
        HqlParser.fromRange_return retval = new HqlParser.fromRange_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        HqlParser.fromClassOrOuterQueryPath_return fromClassOrOuterQueryPath73 = default(HqlParser.fromClassOrOuterQueryPath_return);

        HqlParser.inClassDeclaration_return inClassDeclaration74 = default(HqlParser.inClassDeclaration_return);

        HqlParser.inCollectionDeclaration_return inCollectionDeclaration75 = default(HqlParser.inCollectionDeclaration_return);

        HqlParser.inCollectionElementsDeclaration_return inCollectionElementsDeclaration76 = default(HqlParser.inCollectionElementsDeclaration_return);



        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:326:2: ( fromClassOrOuterQueryPath | inClassDeclaration | inCollectionDeclaration | inCollectionElementsDeclaration )
            int alt24 = 4;
            alt24 = dfa24.Predict(input);
            switch (alt24) 
            {
                case 1 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:326:4: fromClassOrOuterQueryPath
                    {
                    	root_0 = (IASTNode)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_fromClassOrOuterQueryPath_in_fromRange1245);
                    	fromClassOrOuterQueryPath73 = fromClassOrOuterQueryPath();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, fromClassOrOuterQueryPath73.Tree);

                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:327:4: inClassDeclaration
                    {
                    	root_0 = (IASTNode)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_inClassDeclaration_in_fromRange1250);
                    	inClassDeclaration74 = inClassDeclaration();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, inClassDeclaration74.Tree);

                    }
                    break;
                case 3 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:328:4: inCollectionDeclaration
                    {
                    	root_0 = (IASTNode)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_inCollectionDeclaration_in_fromRange1255);
                    	inCollectionDeclaration75 = inCollectionDeclaration();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, inCollectionDeclaration75.Tree);

                    }
                    break;
                case 4 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:329:4: inCollectionElementsDeclaration
                    {
                    	root_0 = (IASTNode)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_inCollectionElementsDeclaration_in_fromRange1260);
                    	inCollectionElementsDeclaration76 = inCollectionElementsDeclaration();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, inCollectionElementsDeclaration76.Tree);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "fromRange"

    public class fromClassOrOuterQueryPath_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "fromClassOrOuterQueryPath"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:341:1: fromClassOrOuterQueryPath : path ( asAlias )? ( propertyFetch )? -> ^( RANGE path ( asAlias )? ( propertyFetch )? ) ;
    public HqlParser.fromClassOrOuterQueryPath_return fromClassOrOuterQueryPath() // throws RecognitionException [1]
    {   
        HqlParser.fromClassOrOuterQueryPath_return retval = new HqlParser.fromClassOrOuterQueryPath_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        HqlParser.path_return path77 = default(HqlParser.path_return);

        HqlParser.asAlias_return asAlias78 = default(HqlParser.asAlias_return);

        HqlParser.propertyFetch_return propertyFetch79 = default(HqlParser.propertyFetch_return);


        RewriteRuleSubtreeStream stream_path = new RewriteRuleSubtreeStream(adaptor,"rule path");
        RewriteRuleSubtreeStream stream_propertyFetch = new RewriteRuleSubtreeStream(adaptor,"rule propertyFetch");
        RewriteRuleSubtreeStream stream_asAlias = new RewriteRuleSubtreeStream(adaptor,"rule asAlias");
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:342:2: ( path ( asAlias )? ( propertyFetch )? -> ^( RANGE path ( asAlias )? ( propertyFetch )? ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:342:4: path ( asAlias )? ( propertyFetch )?
            {
            	PushFollow(FOLLOW_path_in_fromClassOrOuterQueryPath1275);
            	path77 = path();
            	state.followingStackPointer--;

            	stream_path.Add(path77.Tree);
            	 WeakKeywords(); 
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:342:29: ( asAlias )?
            	int alt25 = 2;
            	alt25 = dfa25.Predict(input);
            	switch (alt25) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:342:30: asAlias
            	        {
            	        	PushFollow(FOLLOW_asAlias_in_fromClassOrOuterQueryPath1280);
            	        	asAlias78 = asAlias();
            	        	state.followingStackPointer--;

            	        	stream_asAlias.Add(asAlias78.Tree);

            	        }
            	        break;

            	}

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:342:40: ( propertyFetch )?
            	int alt26 = 2;
            	alt26 = dfa26.Predict(input);
            	switch (alt26) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:342:41: propertyFetch
            	        {
            	        	PushFollow(FOLLOW_propertyFetch_in_fromClassOrOuterQueryPath1285);
            	        	propertyFetch79 = propertyFetch();
            	        	state.followingStackPointer--;

            	        	stream_propertyFetch.Add(propertyFetch79.Tree);

            	        }
            	        break;

            	}



            	// AST REWRITE
            	// elements:          propertyFetch, asAlias, path
            	// token labels:      
            	// rule labels:       retval
            	// token list labels: 
            	// rule list labels:  
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));

            	root_0 = (IASTNode)adaptor.GetNilNode();
            	// 343:3: -> ^( RANGE path ( asAlias )? ( propertyFetch )? )
            	{
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:343:6: ^( RANGE path ( asAlias )? ( propertyFetch )? )
            	    {
            	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
            	    root_1 = (IASTNode)adaptor.BecomeRoot((IASTNode)adaptor.Create(RANGE, "RANGE"), root_1);

            	    adaptor.AddChild(root_1, stream_path.NextTree());
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:343:19: ( asAlias )?
            	    if ( stream_asAlias.HasNext() )
            	    {
            	        adaptor.AddChild(root_1, stream_asAlias.NextTree());

            	    }
            	    stream_asAlias.Reset();
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:343:28: ( propertyFetch )?
            	    if ( stream_propertyFetch.HasNext() )
            	    {
            	        adaptor.AddChild(root_1, stream_propertyFetch.NextTree());

            	    }
            	    stream_propertyFetch.Reset();

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;retval.Tree = root_0;
            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "fromClassOrOuterQueryPath"

    public class inClassDeclaration_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "inClassDeclaration"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:355:1: inClassDeclaration : alias IN CLASS path -> ^( RANGE path alias ) ;
    public HqlParser.inClassDeclaration_return inClassDeclaration() // throws RecognitionException [1]
    {   
        HqlParser.inClassDeclaration_return retval = new HqlParser.inClassDeclaration_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken IN81 = null;
        IToken CLASS82 = null;
        HqlParser.alias_return alias80 = default(HqlParser.alias_return);

        HqlParser.path_return path83 = default(HqlParser.path_return);


        IASTNode IN81_tree=null;
        IASTNode CLASS82_tree=null;
        RewriteRuleTokenStream stream_CLASS = new RewriteRuleTokenStream(adaptor,"token CLASS");
        RewriteRuleTokenStream stream_IN = new RewriteRuleTokenStream(adaptor,"token IN");
        RewriteRuleSubtreeStream stream_path = new RewriteRuleSubtreeStream(adaptor,"rule path");
        RewriteRuleSubtreeStream stream_alias = new RewriteRuleSubtreeStream(adaptor,"rule alias");
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:356:2: ( alias IN CLASS path -> ^( RANGE path alias ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:356:4: alias IN CLASS path
            {
            	PushFollow(FOLLOW_alias_in_inClassDeclaration1318);
            	alias80 = alias();
            	state.followingStackPointer--;

            	stream_alias.Add(alias80.Tree);
            	IN81=(IToken)Match(input,IN,FOLLOW_IN_in_inClassDeclaration1320);  
            	stream_IN.Add(IN81);

            	CLASS82=(IToken)Match(input,CLASS,FOLLOW_CLASS_in_inClassDeclaration1322);  
            	stream_CLASS.Add(CLASS82);

            	PushFollow(FOLLOW_path_in_inClassDeclaration1324);
            	path83 = path();
            	state.followingStackPointer--;

            	stream_path.Add(path83.Tree);


            	// AST REWRITE
            	// elements:          path, alias
            	// token labels:      
            	// rule labels:       retval
            	// token list labels: 
            	// rule list labels:  
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));

            	root_0 = (IASTNode)adaptor.GetNilNode();
            	// 357:3: -> ^( RANGE path alias )
            	{
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:357:6: ^( RANGE path alias )
            	    {
            	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
            	    root_1 = (IASTNode)adaptor.BecomeRoot((IASTNode)adaptor.Create(RANGE, "RANGE"), root_1);

            	    adaptor.AddChild(root_1, stream_path.NextTree());
            	    adaptor.AddChild(root_1, stream_alias.NextTree());

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;retval.Tree = root_0;
            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "inClassDeclaration"

    public class inCollectionDeclaration_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "inCollectionDeclaration"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:369:1: inCollectionDeclaration : IN OPEN path CLOSE alias -> ^( JOIN INNER path alias ) ;
    public HqlParser.inCollectionDeclaration_return inCollectionDeclaration() // throws RecognitionException [1]
    {   
        HqlParser.inCollectionDeclaration_return retval = new HqlParser.inCollectionDeclaration_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken IN84 = null;
        IToken OPEN85 = null;
        IToken CLOSE87 = null;
        HqlParser.path_return path86 = default(HqlParser.path_return);

        HqlParser.alias_return alias88 = default(HqlParser.alias_return);


        IASTNode IN84_tree=null;
        IASTNode OPEN85_tree=null;
        IASTNode CLOSE87_tree=null;
        RewriteRuleTokenStream stream_CLOSE = new RewriteRuleTokenStream(adaptor,"token CLOSE");
        RewriteRuleTokenStream stream_OPEN = new RewriteRuleTokenStream(adaptor,"token OPEN");
        RewriteRuleTokenStream stream_IN = new RewriteRuleTokenStream(adaptor,"token IN");
        RewriteRuleSubtreeStream stream_path = new RewriteRuleSubtreeStream(adaptor,"rule path");
        RewriteRuleSubtreeStream stream_alias = new RewriteRuleSubtreeStream(adaptor,"rule alias");
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:370:5: ( IN OPEN path CLOSE alias -> ^( JOIN INNER path alias ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:370:7: IN OPEN path CLOSE alias
            {
            	IN84=(IToken)Match(input,IN,FOLLOW_IN_in_inCollectionDeclaration1355);  
            	stream_IN.Add(IN84);

            	OPEN85=(IToken)Match(input,OPEN,FOLLOW_OPEN_in_inCollectionDeclaration1357);  
            	stream_OPEN.Add(OPEN85);

            	PushFollow(FOLLOW_path_in_inCollectionDeclaration1359);
            	path86 = path();
            	state.followingStackPointer--;

            	stream_path.Add(path86.Tree);
            	CLOSE87=(IToken)Match(input,CLOSE,FOLLOW_CLOSE_in_inCollectionDeclaration1361);  
            	stream_CLOSE.Add(CLOSE87);

            	PushFollow(FOLLOW_alias_in_inCollectionDeclaration1363);
            	alias88 = alias();
            	state.followingStackPointer--;

            	stream_alias.Add(alias88.Tree);


            	// AST REWRITE
            	// elements:          path, alias
            	// token labels:      
            	// rule labels:       retval
            	// token list labels: 
            	// rule list labels:  
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));

            	root_0 = (IASTNode)adaptor.GetNilNode();
            	// 371:6: -> ^( JOIN INNER path alias )
            	{
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:371:9: ^( JOIN INNER path alias )
            	    {
            	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
            	    root_1 = (IASTNode)adaptor.BecomeRoot((IASTNode)adaptor.Create(JOIN, "JOIN"), root_1);

            	    adaptor.AddChild(root_1, (IASTNode)adaptor.Create(INNER, "INNER"));
            	    adaptor.AddChild(root_1, stream_path.NextTree());
            	    adaptor.AddChild(root_1, stream_alias.NextTree());

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;retval.Tree = root_0;
            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "inCollectionDeclaration"

    public class inCollectionElementsDeclaration_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "inCollectionElementsDeclaration"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:383:1: inCollectionElementsDeclaration : alias IN ELEMENTS OPEN path CLOSE -> ^( JOIN INNER path alias ) ;
    public HqlParser.inCollectionElementsDeclaration_return inCollectionElementsDeclaration() // throws RecognitionException [1]
    {   
        HqlParser.inCollectionElementsDeclaration_return retval = new HqlParser.inCollectionElementsDeclaration_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken IN90 = null;
        IToken ELEMENTS91 = null;
        IToken OPEN92 = null;
        IToken CLOSE94 = null;
        HqlParser.alias_return alias89 = default(HqlParser.alias_return);

        HqlParser.path_return path93 = default(HqlParser.path_return);


        IASTNode IN90_tree=null;
        IASTNode ELEMENTS91_tree=null;
        IASTNode OPEN92_tree=null;
        IASTNode CLOSE94_tree=null;
        RewriteRuleTokenStream stream_CLOSE = new RewriteRuleTokenStream(adaptor,"token CLOSE");
        RewriteRuleTokenStream stream_ELEMENTS = new RewriteRuleTokenStream(adaptor,"token ELEMENTS");
        RewriteRuleTokenStream stream_OPEN = new RewriteRuleTokenStream(adaptor,"token OPEN");
        RewriteRuleTokenStream stream_IN = new RewriteRuleTokenStream(adaptor,"token IN");
        RewriteRuleSubtreeStream stream_path = new RewriteRuleSubtreeStream(adaptor,"rule path");
        RewriteRuleSubtreeStream stream_alias = new RewriteRuleSubtreeStream(adaptor,"rule alias");
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:384:2: ( alias IN ELEMENTS OPEN path CLOSE -> ^( JOIN INNER path alias ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:384:4: alias IN ELEMENTS OPEN path CLOSE
            {
            	PushFollow(FOLLOW_alias_in_inCollectionElementsDeclaration1399);
            	alias89 = alias();
            	state.followingStackPointer--;

            	stream_alias.Add(alias89.Tree);
            	IN90=(IToken)Match(input,IN,FOLLOW_IN_in_inCollectionElementsDeclaration1401);  
            	stream_IN.Add(IN90);

            	ELEMENTS91=(IToken)Match(input,ELEMENTS,FOLLOW_ELEMENTS_in_inCollectionElementsDeclaration1403);  
            	stream_ELEMENTS.Add(ELEMENTS91);

            	OPEN92=(IToken)Match(input,OPEN,FOLLOW_OPEN_in_inCollectionElementsDeclaration1405);  
            	stream_OPEN.Add(OPEN92);

            	PushFollow(FOLLOW_path_in_inCollectionElementsDeclaration1407);
            	path93 = path();
            	state.followingStackPointer--;

            	stream_path.Add(path93.Tree);
            	CLOSE94=(IToken)Match(input,CLOSE,FOLLOW_CLOSE_in_inCollectionElementsDeclaration1409);  
            	stream_CLOSE.Add(CLOSE94);



            	// AST REWRITE
            	// elements:          alias, path
            	// token labels:      
            	// rule labels:       retval
            	// token list labels: 
            	// rule list labels:  
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));

            	root_0 = (IASTNode)adaptor.GetNilNode();
            	// 385:3: -> ^( JOIN INNER path alias )
            	{
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:385:6: ^( JOIN INNER path alias )
            	    {
            	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
            	    root_1 = (IASTNode)adaptor.BecomeRoot((IASTNode)adaptor.Create(JOIN, "JOIN"), root_1);

            	    adaptor.AddChild(root_1, (IASTNode)adaptor.Create(INNER, "INNER"));
            	    adaptor.AddChild(root_1, stream_path.NextTree());
            	    adaptor.AddChild(root_1, stream_alias.NextTree());

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;retval.Tree = root_0;
            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "inCollectionElementsDeclaration"

    public class asAlias_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "asAlias"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:389:1: asAlias : ( AS )? alias ;
    public HqlParser.asAlias_return asAlias() // throws RecognitionException [1]
    {   
        HqlParser.asAlias_return retval = new HqlParser.asAlias_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken AS95 = null;
        HqlParser.alias_return alias96 = default(HqlParser.alias_return);


        IASTNode AS95_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:390:2: ( ( AS )? alias )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:390:4: ( AS )? alias
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:390:4: ( AS )?
            	int alt27 = 2;
            	int LA27_0 = input.LA(1);

            	if ( (LA27_0 == AS) )
            	{
            	    alt27 = 1;
            	}
            	switch (alt27) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:390:5: AS
            	        {
            	        	AS95=(IToken)Match(input,AS,FOLLOW_AS_in_asAlias1440); 

            	        }
            	        break;

            	}

            	PushFollow(FOLLOW_alias_in_asAlias1445);
            	alias96 = alias();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, alias96.Tree);

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "asAlias"

    public class alias_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "alias"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:400:1: alias : i= identifier -> ^( ALIAS[$i.start] ) ;
    public HqlParser.alias_return alias() // throws RecognitionException [1]
    {   
        HqlParser.alias_return retval = new HqlParser.alias_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        HqlParser.identifier_return i = default(HqlParser.identifier_return);


        RewriteRuleSubtreeStream stream_identifier = new RewriteRuleSubtreeStream(adaptor,"rule identifier");
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:401:2: (i= identifier -> ^( ALIAS[$i.start] ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:401:4: i= identifier
            {
            	PushFollow(FOLLOW_identifier_in_alias1461);
            	i = identifier();
            	state.followingStackPointer--;

            	stream_identifier.Add(i.Tree);


            	// AST REWRITE
            	// elements:          
            	// token labels:      
            	// rule labels:       retval
            	// token list labels: 
            	// rule list labels:  
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));

            	root_0 = (IASTNode)adaptor.GetNilNode();
            	// 402:2: -> ^( ALIAS[$i.start] )
            	{
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:402:5: ^( ALIAS[$i.start] )
            	    {
            	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
            	    root_1 = (IASTNode)adaptor.BecomeRoot((IASTNode)adaptor.Create(ALIAS, ((i != null) ? ((IToken)i.Start) : null)), root_1);

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;retval.Tree = root_0;
            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "alias"

    public class propertyFetch_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "propertyFetch"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:405:1: propertyFetch : FETCH ALL PROPERTIES ;
    public HqlParser.propertyFetch_return propertyFetch() // throws RecognitionException [1]
    {   
        HqlParser.propertyFetch_return retval = new HqlParser.propertyFetch_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken FETCH97 = null;
        IToken ALL98 = null;
        IToken PROPERTIES99 = null;

        IASTNode FETCH97_tree=null;
        IASTNode ALL98_tree=null;
        IASTNode PROPERTIES99_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:406:2: ( FETCH ALL PROPERTIES )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:406:4: FETCH ALL PROPERTIES
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	FETCH97=(IToken)Match(input,FETCH,FOLLOW_FETCH_in_propertyFetch1480); 
            		FETCH97_tree = (IASTNode)adaptor.Create(FETCH97);
            		adaptor.AddChild(root_0, FETCH97_tree);

            	ALL98=(IToken)Match(input,ALL,FOLLOW_ALL_in_propertyFetch1482); 
            	PROPERTIES99=(IToken)Match(input,PROPERTIES,FOLLOW_PROPERTIES_in_propertyFetch1485); 

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "propertyFetch"

    public class groupByClause_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "groupByClause"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:412:1: groupByClause : GROUP 'by' expression ( COMMA expression )* ( havingClause )? ;
    public HqlParser.groupByClause_return groupByClause() // throws RecognitionException [1]
    {   
        HqlParser.groupByClause_return retval = new HqlParser.groupByClause_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken GROUP100 = null;
        IToken string_literal101 = null;
        IToken COMMA103 = null;
        HqlParser.expression_return expression102 = default(HqlParser.expression_return);

        HqlParser.expression_return expression104 = default(HqlParser.expression_return);

        HqlParser.havingClause_return havingClause105 = default(HqlParser.havingClause_return);


        IASTNode GROUP100_tree=null;
        IASTNode string_literal101_tree=null;
        IASTNode COMMA103_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:413:2: ( GROUP 'by' expression ( COMMA expression )* ( havingClause )? )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:413:4: GROUP 'by' expression ( COMMA expression )* ( havingClause )?
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	GROUP100=(IToken)Match(input,GROUP,FOLLOW_GROUP_in_groupByClause1500); 
            		GROUP100_tree = (IASTNode)adaptor.Create(GROUP100);
            		root_0 = (IASTNode)adaptor.BecomeRoot(GROUP100_tree, root_0);

            	string_literal101=(IToken)Match(input,LITERAL_by,FOLLOW_LITERAL_by_in_groupByClause1506); 
            	PushFollow(FOLLOW_expression_in_groupByClause1509);
            	expression102 = expression();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, expression102.Tree);
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:414:20: ( COMMA expression )*
            	do 
            	{
            	    int alt28 = 2;
            	    int LA28_0 = input.LA(1);

            	    if ( (LA28_0 == COMMA) )
            	    {
            	        alt28 = 1;
            	    }


            	    switch (alt28) 
            		{
            			case 1 :
            			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:414:22: COMMA expression
            			    {
            			    	COMMA103=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_groupByClause1513); 
            			    	PushFollow(FOLLOW_expression_in_groupByClause1516);
            			    	expression104 = expression();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, expression104.Tree);

            			    }
            			    break;

            			default:
            			    goto loop28;
            	    }
            	} while (true);

            	loop28:
            		;	// Stops C# compiler whining that label 'loop28' has no statements

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:415:3: ( havingClause )?
            	int alt29 = 2;
            	int LA29_0 = input.LA(1);

            	if ( (LA29_0 == HAVING) )
            	{
            	    alt29 = 1;
            	}
            	switch (alt29) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:415:4: havingClause
            	        {
            	        	PushFollow(FOLLOW_havingClause_in_groupByClause1524);
            	        	havingClause105 = havingClause();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, havingClause105.Tree);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "groupByClause"

    public class orderByClause_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "orderByClause"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:421:1: orderByClause : ORDER 'by' orderElement ( COMMA orderElement )* ;
    public HqlParser.orderByClause_return orderByClause() // throws RecognitionException [1]
    {   
        HqlParser.orderByClause_return retval = new HqlParser.orderByClause_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken ORDER106 = null;
        IToken string_literal107 = null;
        IToken COMMA109 = null;
        HqlParser.orderElement_return orderElement108 = default(HqlParser.orderElement_return);

        HqlParser.orderElement_return orderElement110 = default(HqlParser.orderElement_return);


        IASTNode ORDER106_tree=null;
        IASTNode string_literal107_tree=null;
        IASTNode COMMA109_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:422:2: ( ORDER 'by' orderElement ( COMMA orderElement )* )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:422:4: ORDER 'by' orderElement ( COMMA orderElement )*
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	ORDER106=(IToken)Match(input,ORDER,FOLLOW_ORDER_in_orderByClause1540); 
            		ORDER106_tree = (IASTNode)adaptor.Create(ORDER106);
            		root_0 = (IASTNode)adaptor.BecomeRoot(ORDER106_tree, root_0);

            	string_literal107=(IToken)Match(input,LITERAL_by,FOLLOW_LITERAL_by_in_orderByClause1543); 
            	PushFollow(FOLLOW_orderElement_in_orderByClause1546);
            	orderElement108 = orderElement();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, orderElement108.Tree);
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:422:30: ( COMMA orderElement )*
            	do 
            	{
            	    int alt30 = 2;
            	    int LA30_0 = input.LA(1);

            	    if ( (LA30_0 == COMMA) )
            	    {
            	        alt30 = 1;
            	    }


            	    switch (alt30) 
            		{
            			case 1 :
            			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:422:32: COMMA orderElement
            			    {
            			    	COMMA109=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_orderByClause1550); 
            			    	PushFollow(FOLLOW_orderElement_in_orderByClause1553);
            			    	orderElement110 = orderElement();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, orderElement110.Tree);

            			    }
            			    break;

            			default:
            			    goto loop30;
            	    }
            	} while (true);

            	loop30:
            		;	// Stops C# compiler whining that label 'loop30' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "orderByClause"

    public class orderElement_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "orderElement"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:425:1: orderElement : expression ( ascendingOrDescending )? ;
    public HqlParser.orderElement_return orderElement() // throws RecognitionException [1]
    {   
        HqlParser.orderElement_return retval = new HqlParser.orderElement_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        HqlParser.expression_return expression111 = default(HqlParser.expression_return);

        HqlParser.ascendingOrDescending_return ascendingOrDescending112 = default(HqlParser.ascendingOrDescending_return);



        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:426:2: ( expression ( ascendingOrDescending )? )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:426:4: expression ( ascendingOrDescending )?
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	PushFollow(FOLLOW_expression_in_orderElement1567);
            	expression111 = expression();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, expression111.Tree);
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:426:15: ( ascendingOrDescending )?
            	int alt31 = 2;
            	int LA31_0 = input.LA(1);

            	if ( (LA31_0 == ASCENDING || LA31_0 == DESCENDING || (LA31_0 >= 126 && LA31_0 <= 127)) )
            	{
            	    alt31 = 1;
            	}
            	switch (alt31) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:426:17: ascendingOrDescending
            	        {
            	        	PushFollow(FOLLOW_ascendingOrDescending_in_orderElement1571);
            	        	ascendingOrDescending112 = ascendingOrDescending();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, ascendingOrDescending112.Tree);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "orderElement"

    public class ascendingOrDescending_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "ascendingOrDescending"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:437:1: ascendingOrDescending : ( ( 'asc' | 'ascending' ) -> ^( ASCENDING ) | ( 'desc' | 'descending' ) -> ^( DESCENDING ) );
    public HqlParser.ascendingOrDescending_return ascendingOrDescending() // throws RecognitionException [1]
    {   
        HqlParser.ascendingOrDescending_return retval = new HqlParser.ascendingOrDescending_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken string_literal113 = null;
        IToken string_literal114 = null;
        IToken string_literal115 = null;
        IToken string_literal116 = null;

        IASTNode string_literal113_tree=null;
        IASTNode string_literal114_tree=null;
        IASTNode string_literal115_tree=null;
        IASTNode string_literal116_tree=null;
        RewriteRuleTokenStream stream_127 = new RewriteRuleTokenStream(adaptor,"token 127");
        RewriteRuleTokenStream stream_ASCENDING = new RewriteRuleTokenStream(adaptor,"token ASCENDING");
        RewriteRuleTokenStream stream_DESCENDING = new RewriteRuleTokenStream(adaptor,"token DESCENDING");
        RewriteRuleTokenStream stream_126 = new RewriteRuleTokenStream(adaptor,"token 126");

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:438:2: ( ( 'asc' | 'ascending' ) -> ^( ASCENDING ) | ( 'desc' | 'descending' ) -> ^( DESCENDING ) )
            int alt34 = 2;
            int LA34_0 = input.LA(1);

            if ( (LA34_0 == ASCENDING || LA34_0 == 126) )
            {
                alt34 = 1;
            }
            else if ( (LA34_0 == DESCENDING || LA34_0 == 127) )
            {
                alt34 = 2;
            }
            else 
            {
                NoViableAltException nvae_d34s0 =
                    new NoViableAltException("", 34, 0, input);

                throw nvae_d34s0;
            }
            switch (alt34) 
            {
                case 1 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:438:4: ( 'asc' | 'ascending' )
                    {
                    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:438:4: ( 'asc' | 'ascending' )
                    	int alt32 = 2;
                    	int LA32_0 = input.LA(1);

                    	if ( (LA32_0 == ASCENDING) )
                    	{
                    	    alt32 = 1;
                    	}
                    	else if ( (LA32_0 == 126) )
                    	{
                    	    alt32 = 2;
                    	}
                    	else 
                    	{
                    	    NoViableAltException nvae_d32s0 =
                    	        new NoViableAltException("", 32, 0, input);

                    	    throw nvae_d32s0;
                    	}
                    	switch (alt32) 
                    	{
                    	    case 1 :
                    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:438:6: 'asc'
                    	        {
                    	        	string_literal113=(IToken)Match(input,ASCENDING,FOLLOW_ASCENDING_in_ascendingOrDescending1590);  
                    	        	stream_ASCENDING.Add(string_literal113);


                    	        }
                    	        break;
                    	    case 2 :
                    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:438:14: 'ascending'
                    	        {
                    	        	string_literal114=(IToken)Match(input,126,FOLLOW_126_in_ascendingOrDescending1594);  
                    	        	stream_126.Add(string_literal114);


                    	        }
                    	        break;

                    	}



                    	// AST REWRITE
                    	// elements:          
                    	// token labels:      
                    	// rule labels:       retval
                    	// token list labels: 
                    	// rule list labels:  
                    	retval.Tree = root_0;
                    	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));

                    	root_0 = (IASTNode)adaptor.GetNilNode();
                    	// 439:3: -> ^( ASCENDING )
                    	{
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:439:6: ^( ASCENDING )
                    	    {
                    	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
                    	    root_1 = (IASTNode)adaptor.BecomeRoot((IASTNode)adaptor.Create(ASCENDING, "ASCENDING"), root_1);

                    	    adaptor.AddChild(root_0, root_1);
                    	    }

                    	}

                    	retval.Tree = root_0;retval.Tree = root_0;
                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:440:4: ( 'desc' | 'descending' )
                    {
                    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:440:4: ( 'desc' | 'descending' )
                    	int alt33 = 2;
                    	int LA33_0 = input.LA(1);

                    	if ( (LA33_0 == DESCENDING) )
                    	{
                    	    alt33 = 1;
                    	}
                    	else if ( (LA33_0 == 127) )
                    	{
                    	    alt33 = 2;
                    	}
                    	else 
                    	{
                    	    NoViableAltException nvae_d33s0 =
                    	        new NoViableAltException("", 33, 0, input);

                    	    throw nvae_d33s0;
                    	}
                    	switch (alt33) 
                    	{
                    	    case 1 :
                    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:440:6: 'desc'
                    	        {
                    	        	string_literal115=(IToken)Match(input,DESCENDING,FOLLOW_DESCENDING_in_ascendingOrDescending1611);  
                    	        	stream_DESCENDING.Add(string_literal115);


                    	        }
                    	        break;
                    	    case 2 :
                    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:440:15: 'descending'
                    	        {
                    	        	string_literal116=(IToken)Match(input,127,FOLLOW_127_in_ascendingOrDescending1615);  
                    	        	stream_127.Add(string_literal116);


                    	        }
                    	        break;

                    	}



                    	// AST REWRITE
                    	// elements:          
                    	// token labels:      
                    	// rule labels:       retval
                    	// token list labels: 
                    	// rule list labels:  
                    	retval.Tree = root_0;
                    	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));

                    	root_0 = (IASTNode)adaptor.GetNilNode();
                    	// 441:3: -> ^( DESCENDING )
                    	{
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:441:6: ^( DESCENDING )
                    	    {
                    	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
                    	    root_1 = (IASTNode)adaptor.BecomeRoot((IASTNode)adaptor.Create(DESCENDING, "DESCENDING"), root_1);

                    	    adaptor.AddChild(root_0, root_1);
                    	    }

                    	}

                    	retval.Tree = root_0;retval.Tree = root_0;
                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "ascendingOrDescending"

    public class havingClause_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "havingClause"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:447:1: havingClause : HAVING logicalExpression ;
    public HqlParser.havingClause_return havingClause() // throws RecognitionException [1]
    {   
        HqlParser.havingClause_return retval = new HqlParser.havingClause_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken HAVING117 = null;
        HqlParser.logicalExpression_return logicalExpression118 = default(HqlParser.logicalExpression_return);


        IASTNode HAVING117_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:448:2: ( HAVING logicalExpression )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:448:4: HAVING logicalExpression
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	HAVING117=(IToken)Match(input,HAVING,FOLLOW_HAVING_in_havingClause1638); 
            		HAVING117_tree = (IASTNode)adaptor.Create(HAVING117);
            		root_0 = (IASTNode)adaptor.BecomeRoot(HAVING117_tree, root_0);

            	PushFollow(FOLLOW_logicalExpression_in_havingClause1641);
            	logicalExpression118 = logicalExpression();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, logicalExpression118.Tree);

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "havingClause"

    public class whereClause_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "whereClause"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:454:1: whereClause : WHERE logicalExpression ;
    public HqlParser.whereClause_return whereClause() // throws RecognitionException [1]
    {   
        HqlParser.whereClause_return retval = new HqlParser.whereClause_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken WHERE119 = null;
        HqlParser.logicalExpression_return logicalExpression120 = default(HqlParser.logicalExpression_return);


        IASTNode WHERE119_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:455:2: ( WHERE logicalExpression )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:455:4: WHERE logicalExpression
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	WHERE119=(IToken)Match(input,WHERE,FOLLOW_WHERE_in_whereClause1655); 
            		WHERE119_tree = (IASTNode)adaptor.Create(WHERE119);
            		root_0 = (IASTNode)adaptor.BecomeRoot(WHERE119_tree, root_0);

            	PushFollow(FOLLOW_logicalExpression_in_whereClause1658);
            	logicalExpression120 = logicalExpression();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, logicalExpression120.Tree);

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "whereClause"

    public class selectedPropertiesList_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "selectedPropertiesList"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:461:1: selectedPropertiesList : aliasedExpression ( COMMA aliasedExpression )* ;
    public HqlParser.selectedPropertiesList_return selectedPropertiesList() // throws RecognitionException [1]
    {   
        HqlParser.selectedPropertiesList_return retval = new HqlParser.selectedPropertiesList_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken COMMA122 = null;
        HqlParser.aliasedExpression_return aliasedExpression121 = default(HqlParser.aliasedExpression_return);

        HqlParser.aliasedExpression_return aliasedExpression123 = default(HqlParser.aliasedExpression_return);


        IASTNode COMMA122_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:462:2: ( aliasedExpression ( COMMA aliasedExpression )* )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:462:4: aliasedExpression ( COMMA aliasedExpression )*
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	PushFollow(FOLLOW_aliasedExpression_in_selectedPropertiesList1672);
            	aliasedExpression121 = aliasedExpression();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, aliasedExpression121.Tree);
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:462:22: ( COMMA aliasedExpression )*
            	do 
            	{
            	    int alt35 = 2;
            	    int LA35_0 = input.LA(1);

            	    if ( (LA35_0 == COMMA) )
            	    {
            	        alt35 = 1;
            	    }


            	    switch (alt35) 
            		{
            			case 1 :
            			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:462:24: COMMA aliasedExpression
            			    {
            			    	COMMA122=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_selectedPropertiesList1676); 
            			    	PushFollow(FOLLOW_aliasedExpression_in_selectedPropertiesList1679);
            			    	aliasedExpression123 = aliasedExpression();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, aliasedExpression123.Tree);

            			    }
            			    break;

            			default:
            			    goto loop35;
            	    }
            	} while (true);

            	loop35:
            		;	// Stops C# compiler whining that label 'loop35' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "selectedPropertiesList"

    public class aliasedExpression_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "aliasedExpression"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:465:1: aliasedExpression : expression ( AS identifier )? ;
    public HqlParser.aliasedExpression_return aliasedExpression() // throws RecognitionException [1]
    {   
        HqlParser.aliasedExpression_return retval = new HqlParser.aliasedExpression_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken AS125 = null;
        HqlParser.expression_return expression124 = default(HqlParser.expression_return);

        HqlParser.identifier_return identifier126 = default(HqlParser.identifier_return);


        IASTNode AS125_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:466:2: ( expression ( AS identifier )? )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:466:4: expression ( AS identifier )?
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	PushFollow(FOLLOW_expression_in_aliasedExpression1694);
            	expression124 = expression();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, expression124.Tree);
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:466:15: ( AS identifier )?
            	int alt36 = 2;
            	alt36 = dfa36.Predict(input);
            	switch (alt36) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:466:17: AS identifier
            	        {
            	        	AS125=(IToken)Match(input,AS,FOLLOW_AS_in_aliasedExpression1698); 
            	        		AS125_tree = (IASTNode)adaptor.Create(AS125);
            	        		root_0 = (IASTNode)adaptor.BecomeRoot(AS125_tree, root_0);

            	        	PushFollow(FOLLOW_identifier_in_aliasedExpression1701);
            	        	identifier126 = identifier();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, identifier126.Tree);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "aliasedExpression"

    public class logicalExpression_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "logicalExpression"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:493:1: logicalExpression : expression ;
    public HqlParser.logicalExpression_return logicalExpression() // throws RecognitionException [1]
    {   
        HqlParser.logicalExpression_return retval = new HqlParser.logicalExpression_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        HqlParser.expression_return expression127 = default(HqlParser.expression_return);



        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:494:2: ( expression )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:494:4: expression
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	PushFollow(FOLLOW_expression_in_logicalExpression1739);
            	expression127 = expression();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, expression127.Tree);

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "logicalExpression"

    public class expression_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "expression"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:498:1: expression : logicalOrExpression ;
    public HqlParser.expression_return expression() // throws RecognitionException [1]
    {   
        HqlParser.expression_return retval = new HqlParser.expression_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        HqlParser.logicalOrExpression_return logicalOrExpression128 = default(HqlParser.logicalOrExpression_return);



        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:499:2: ( logicalOrExpression )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:499:4: logicalOrExpression
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	PushFollow(FOLLOW_logicalOrExpression_in_expression1751);
            	logicalOrExpression128 = logicalOrExpression();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, logicalOrExpression128.Tree);

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "expression"

    public class logicalOrExpression_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "logicalOrExpression"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:503:1: logicalOrExpression : logicalAndExpression ( OR logicalAndExpression )* ;
    public HqlParser.logicalOrExpression_return logicalOrExpression() // throws RecognitionException [1]
    {   
        HqlParser.logicalOrExpression_return retval = new HqlParser.logicalOrExpression_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken OR130 = null;
        HqlParser.logicalAndExpression_return logicalAndExpression129 = default(HqlParser.logicalAndExpression_return);

        HqlParser.logicalAndExpression_return logicalAndExpression131 = default(HqlParser.logicalAndExpression_return);


        IASTNode OR130_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:504:2: ( logicalAndExpression ( OR logicalAndExpression )* )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:504:4: logicalAndExpression ( OR logicalAndExpression )*
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	PushFollow(FOLLOW_logicalAndExpression_in_logicalOrExpression1763);
            	logicalAndExpression129 = logicalAndExpression();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, logicalAndExpression129.Tree);
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:504:25: ( OR logicalAndExpression )*
            	do 
            	{
            	    int alt37 = 2;
            	    alt37 = dfa37.Predict(input);
            	    switch (alt37) 
            		{
            			case 1 :
            			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:504:27: OR logicalAndExpression
            			    {
            			    	OR130=(IToken)Match(input,OR,FOLLOW_OR_in_logicalOrExpression1767); 
            			    		OR130_tree = (IASTNode)adaptor.Create(OR130);
            			    		root_0 = (IASTNode)adaptor.BecomeRoot(OR130_tree, root_0);

            			    	PushFollow(FOLLOW_logicalAndExpression_in_logicalOrExpression1770);
            			    	logicalAndExpression131 = logicalAndExpression();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, logicalAndExpression131.Tree);

            			    }
            			    break;

            			default:
            			    goto loop37;
            	    }
            	} while (true);

            	loop37:
            		;	// Stops C# compiler whining that label 'loop37' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "logicalOrExpression"

    public class logicalAndExpression_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "logicalAndExpression"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:508:1: logicalAndExpression : negatedExpression ( AND negatedExpression )* ;
    public HqlParser.logicalAndExpression_return logicalAndExpression() // throws RecognitionException [1]
    {   
        HqlParser.logicalAndExpression_return retval = new HqlParser.logicalAndExpression_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken AND133 = null;
        HqlParser.negatedExpression_return negatedExpression132 = default(HqlParser.negatedExpression_return);

        HqlParser.negatedExpression_return negatedExpression134 = default(HqlParser.negatedExpression_return);


        IASTNode AND133_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:509:2: ( negatedExpression ( AND negatedExpression )* )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:509:4: negatedExpression ( AND negatedExpression )*
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	PushFollow(FOLLOW_negatedExpression_in_logicalAndExpression1785);
            	negatedExpression132 = negatedExpression();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, negatedExpression132.Tree);
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:509:22: ( AND negatedExpression )*
            	do 
            	{
            	    int alt38 = 2;
            	    alt38 = dfa38.Predict(input);
            	    switch (alt38) 
            		{
            			case 1 :
            			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:509:24: AND negatedExpression
            			    {
            			    	AND133=(IToken)Match(input,AND,FOLLOW_AND_in_logicalAndExpression1789); 
            			    		AND133_tree = (IASTNode)adaptor.Create(AND133);
            			    		root_0 = (IASTNode)adaptor.BecomeRoot(AND133_tree, root_0);

            			    	PushFollow(FOLLOW_negatedExpression_in_logicalAndExpression1792);
            			    	negatedExpression134 = negatedExpression();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, negatedExpression134.Tree);

            			    }
            			    break;

            			default:
            			    goto loop38;
            	    }
            	} while (true);

            	loop38:
            		;	// Stops C# compiler whining that label 'loop38' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "logicalAndExpression"

    public class negatedExpression_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "negatedExpression"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:523:1: negatedExpression : ( NOT x= negatedExpression -> ^() | equalityExpression -> ^( equalityExpression ) );
    public HqlParser.negatedExpression_return negatedExpression() // throws RecognitionException [1]
    {   
        HqlParser.negatedExpression_return retval = new HqlParser.negatedExpression_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken NOT135 = null;
        HqlParser.negatedExpression_return x = default(HqlParser.negatedExpression_return);

        HqlParser.equalityExpression_return equalityExpression136 = default(HqlParser.equalityExpression_return);


        IASTNode NOT135_tree=null;
        RewriteRuleTokenStream stream_NOT = new RewriteRuleTokenStream(adaptor,"token NOT");
        RewriteRuleSubtreeStream stream_negatedExpression = new RewriteRuleSubtreeStream(adaptor,"rule negatedExpression");
        RewriteRuleSubtreeStream stream_equalityExpression = new RewriteRuleSubtreeStream(adaptor,"rule equalityExpression");
         WeakKeywords(); 
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:525:2: ( NOT x= negatedExpression -> ^() | equalityExpression -> ^( equalityExpression ) )
            int alt39 = 2;
            alt39 = dfa39.Predict(input);
            switch (alt39) 
            {
                case 1 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:525:4: NOT x= negatedExpression
                    {
                    	NOT135=(IToken)Match(input,NOT,FOLLOW_NOT_in_negatedExpression1816);  
                    	stream_NOT.Add(NOT135);

                    	PushFollow(FOLLOW_negatedExpression_in_negatedExpression1820);
                    	x = negatedExpression();
                    	state.followingStackPointer--;

                    	stream_negatedExpression.Add(x.Tree);


                    	// AST REWRITE
                    	// elements:          
                    	// token labels:      
                    	// rule labels:       retval
                    	// token list labels: 
                    	// rule list labels:  
                    	retval.Tree = root_0;
                    	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));

                    	root_0 = (IASTNode)adaptor.GetNilNode();
                    	// 526:3: -> ^()
                    	{
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:526:6: ^()
                    	    {
                    	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
                    	    root_1 = (IASTNode)adaptor.BecomeRoot(NegateNode(((x != null) ? ((IASTNode)x.Tree) : null)), root_1);

                    	    adaptor.AddChild(root_0, root_1);
                    	    }

                    	}

                    	retval.Tree = root_0;retval.Tree = root_0;
                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:527:4: equalityExpression
                    {
                    	PushFollow(FOLLOW_equalityExpression_in_negatedExpression1833);
                    	equalityExpression136 = equalityExpression();
                    	state.followingStackPointer--;

                    	stream_equalityExpression.Add(equalityExpression136.Tree);


                    	// AST REWRITE
                    	// elements:          equalityExpression
                    	// token labels:      
                    	// rule labels:       retval
                    	// token list labels: 
                    	// rule list labels:  
                    	retval.Tree = root_0;
                    	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));

                    	root_0 = (IASTNode)adaptor.GetNilNode();
                    	// 528:3: -> ^( equalityExpression )
                    	{
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:528:6: ^( equalityExpression )
                    	    {
                    	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
                    	    root_1 = (IASTNode)adaptor.BecomeRoot(stream_equalityExpression.NextNode(), root_1);

                    	    adaptor.AddChild(root_0, root_1);
                    	    }

                    	}

                    	retval.Tree = root_0;retval.Tree = root_0;
                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "negatedExpression"

    public class equalityExpression_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "equalityExpression"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:549:1: equalityExpression : x= relationalExpression ( ( EQ | isx= IS ( NOT )? | NE | ne= SQL_NE ) y= relationalExpression )* ;
    public HqlParser.equalityExpression_return equalityExpression() // throws RecognitionException [1]
    {   
        HqlParser.equalityExpression_return retval = new HqlParser.equalityExpression_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken isx = null;
        IToken ne = null;
        IToken EQ137 = null;
        IToken NOT138 = null;
        IToken NE139 = null;
        HqlParser.relationalExpression_return x = default(HqlParser.relationalExpression_return);

        HqlParser.relationalExpression_return y = default(HqlParser.relationalExpression_return);


        IASTNode isx_tree=null;
        IASTNode ne_tree=null;
        IASTNode EQ137_tree=null;
        IASTNode NOT138_tree=null;
        IASTNode NE139_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:554:2: (x= relationalExpression ( ( EQ | isx= IS ( NOT )? | NE | ne= SQL_NE ) y= relationalExpression )* )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:554:4: x= relationalExpression ( ( EQ | isx= IS ( NOT )? | NE | ne= SQL_NE ) y= relationalExpression )*
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	PushFollow(FOLLOW_relationalExpression_in_equalityExpression1865);
            	x = relationalExpression();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, x.Tree);
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:554:27: ( ( EQ | isx= IS ( NOT )? | NE | ne= SQL_NE ) y= relationalExpression )*
            	do 
            	{
            	    int alt42 = 2;
            	    alt42 = dfa42.Predict(input);
            	    switch (alt42) 
            		{
            			case 1 :
            			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:555:3: ( EQ | isx= IS ( NOT )? | NE | ne= SQL_NE ) y= relationalExpression
            			    {
            			    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:555:3: ( EQ | isx= IS ( NOT )? | NE | ne= SQL_NE )
            			    	int alt41 = 4;
            			    	switch ( input.LA(1) ) 
            			    	{
            			    	case EQ:
            			    		{
            			    	    alt41 = 1;
            			    	    }
            			    	    break;
            			    	case IS:
            			    		{
            			    	    alt41 = 2;
            			    	    }
            			    	    break;
            			    	case NE:
            			    		{
            			    	    alt41 = 3;
            			    	    }
            			    	    break;
            			    	case SQL_NE:
            			    		{
            			    	    alt41 = 4;
            			    	    }
            			    	    break;
            			    		default:
            			    		    NoViableAltException nvae_d41s0 =
            			    		        new NoViableAltException("", 41, 0, input);

            			    		    throw nvae_d41s0;
            			    	}

            			    	switch (alt41) 
            			    	{
            			    	    case 1 :
            			    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:555:5: EQ
            			    	        {
            			    	        	EQ137=(IToken)Match(input,EQ,FOLLOW_EQ_in_equalityExpression1873); 
            			    	        		EQ137_tree = (IASTNode)adaptor.Create(EQ137);
            			    	        		root_0 = (IASTNode)adaptor.BecomeRoot(EQ137_tree, root_0);


            			    	        }
            			    	        break;
            			    	    case 2 :
            			    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:556:5: isx= IS ( NOT )?
            			    	        {
            			    	        	isx=(IToken)Match(input,IS,FOLLOW_IS_in_equalityExpression1882); 
            			    	        		isx_tree = (IASTNode)adaptor.Create(isx);
            			    	        		root_0 = (IASTNode)adaptor.BecomeRoot(isx_tree, root_0);

            			    	        	 isx.Type = EQ; 
            			    	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:556:33: ( NOT )?
            			    	        	int alt40 = 2;
            			    	        	alt40 = dfa40.Predict(input);
            			    	        	switch (alt40) 
            			    	        	{
            			    	        	    case 1 :
            			    	        	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:556:34: NOT
            			    	        	        {
            			    	        	        	NOT138=(IToken)Match(input,NOT,FOLLOW_NOT_in_equalityExpression1888); 
            			    	        	        	 isx.Type =NE; 

            			    	        	        }
            			    	        	        break;

            			    	        	}


            			    	        }
            			    	        break;
            			    	    case 3 :
            			    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:557:5: NE
            			    	        {
            			    	        	NE139=(IToken)Match(input,NE,FOLLOW_NE_in_equalityExpression1900); 
            			    	        		NE139_tree = (IASTNode)adaptor.Create(NE139);
            			    	        		root_0 = (IASTNode)adaptor.BecomeRoot(NE139_tree, root_0);


            			    	        }
            			    	        break;
            			    	    case 4 :
            			    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:558:5: ne= SQL_NE
            			    	        {
            			    	        	ne=(IToken)Match(input,SQL_NE,FOLLOW_SQL_NE_in_equalityExpression1909); 
            			    	        		ne_tree = (IASTNode)adaptor.Create(ne);
            			    	        		root_0 = (IASTNode)adaptor.BecomeRoot(ne_tree, root_0);

            			    	        	 ne.Type = NE; 

            			    	        }
            			    	        break;

            			    	}

            			    	PushFollow(FOLLOW_relationalExpression_in_equalityExpression1920);
            			    	y = relationalExpression();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, y.Tree);

            			    }
            			    break;

            			default:
            			    goto loop42;
            	    }
            	} while (true);

            	loop42:
            		;	// Stops C# compiler whining that label 'loop42' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);

            			// Post process the equality expression to clean up 'is null', etc.
            			retval.Tree =  ProcessEqualityExpression(((IASTNode)retval.Tree));
            		
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "equalityExpression"

    public class relationalExpression_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "relationalExpression"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:596:1: relationalExpression : concatenation ( ( ( ( LT | GT | LE | GE ) additiveExpression )* ) | (n= NOT )? ( (i= IN inList ) | (b= BETWEEN betweenList ) | (l= LIKE concatenation likeEscape ) | ( MEMBER ( OF )? p= path ) ) ) ;
    public HqlParser.relationalExpression_return relationalExpression() // throws RecognitionException [1]
    {   
        HqlParser.relationalExpression_return retval = new HqlParser.relationalExpression_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken n = null;
        IToken i = null;
        IToken b = null;
        IToken l = null;
        IToken LT141 = null;
        IToken GT142 = null;
        IToken LE143 = null;
        IToken GE144 = null;
        IToken MEMBER150 = null;
        IToken OF151 = null;
        HqlParser.path_return p = default(HqlParser.path_return);

        HqlParser.concatenation_return concatenation140 = default(HqlParser.concatenation_return);

        HqlParser.additiveExpression_return additiveExpression145 = default(HqlParser.additiveExpression_return);

        HqlParser.inList_return inList146 = default(HqlParser.inList_return);

        HqlParser.betweenList_return betweenList147 = default(HqlParser.betweenList_return);

        HqlParser.concatenation_return concatenation148 = default(HqlParser.concatenation_return);

        HqlParser.likeEscape_return likeEscape149 = default(HqlParser.likeEscape_return);


        IASTNode n_tree=null;
        IASTNode i_tree=null;
        IASTNode b_tree=null;
        IASTNode l_tree=null;
        IASTNode LT141_tree=null;
        IASTNode GT142_tree=null;
        IASTNode LE143_tree=null;
        IASTNode GE144_tree=null;
        IASTNode MEMBER150_tree=null;
        IASTNode OF151_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:597:2: ( concatenation ( ( ( ( LT | GT | LE | GE ) additiveExpression )* ) | (n= NOT )? ( (i= IN inList ) | (b= BETWEEN betweenList ) | (l= LIKE concatenation likeEscape ) | ( MEMBER ( OF )? p= path ) ) ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:597:4: concatenation ( ( ( ( LT | GT | LE | GE ) additiveExpression )* ) | (n= NOT )? ( (i= IN inList ) | (b= BETWEEN betweenList ) | (l= LIKE concatenation likeEscape ) | ( MEMBER ( OF )? p= path ) ) )
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	PushFollow(FOLLOW_concatenation_in_relationalExpression1939);
            	concatenation140 = concatenation();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, concatenation140.Tree);
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:597:18: ( ( ( ( LT | GT | LE | GE ) additiveExpression )* ) | (n= NOT )? ( (i= IN inList ) | (b= BETWEEN betweenList ) | (l= LIKE concatenation likeEscape ) | ( MEMBER ( OF )? p= path ) ) )
            	int alt48 = 2;
            	alt48 = dfa48.Predict(input);
            	switch (alt48) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:598:3: ( ( ( LT | GT | LE | GE ) additiveExpression )* )
            	        {
            	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:598:3: ( ( ( LT | GT | LE | GE ) additiveExpression )* )
            	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:598:5: ( ( LT | GT | LE | GE ) additiveExpression )*
            	        	{
            	        		// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:598:5: ( ( LT | GT | LE | GE ) additiveExpression )*
            	        		do 
            	        		{
            	        		    int alt44 = 2;
            	        		    alt44 = dfa44.Predict(input);
            	        		    switch (alt44) 
            	        			{
            	        				case 1 :
            	        				    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:598:7: ( LT | GT | LE | GE ) additiveExpression
            	        				    {
            	        				    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:598:7: ( LT | GT | LE | GE )
            	        				    	int alt43 = 4;
            	        				    	switch ( input.LA(1) ) 
            	        				    	{
            	        				    	case LT:
            	        				    		{
            	        				    	    alt43 = 1;
            	        				    	    }
            	        				    	    break;
            	        				    	case GT:
            	        				    		{
            	        				    	    alt43 = 2;
            	        				    	    }
            	        				    	    break;
            	        				    	case LE:
            	        				    		{
            	        				    	    alt43 = 3;
            	        				    	    }
            	        				    	    break;
            	        				    	case GE:
            	        				    		{
            	        				    	    alt43 = 4;
            	        				    	    }
            	        				    	    break;
            	        				    		default:
            	        				    		    NoViableAltException nvae_d43s0 =
            	        				    		        new NoViableAltException("", 43, 0, input);

            	        				    		    throw nvae_d43s0;
            	        				    	}

            	        				    	switch (alt43) 
            	        				    	{
            	        				    	    case 1 :
            	        				    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:598:9: LT
            	        				    	        {
            	        				    	        	LT141=(IToken)Match(input,LT,FOLLOW_LT_in_relationalExpression1951); 
            	        				    	        		LT141_tree = (IASTNode)adaptor.Create(LT141);
            	        				    	        		root_0 = (IASTNode)adaptor.BecomeRoot(LT141_tree, root_0);


            	        				    	        }
            	        				    	        break;
            	        				    	    case 2 :
            	        				    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:598:15: GT
            	        				    	        {
            	        				    	        	GT142=(IToken)Match(input,GT,FOLLOW_GT_in_relationalExpression1956); 
            	        				    	        		GT142_tree = (IASTNode)adaptor.Create(GT142);
            	        				    	        		root_0 = (IASTNode)adaptor.BecomeRoot(GT142_tree, root_0);


            	        				    	        }
            	        				    	        break;
            	        				    	    case 3 :
            	        				    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:598:21: LE
            	        				    	        {
            	        				    	        	LE143=(IToken)Match(input,LE,FOLLOW_LE_in_relationalExpression1961); 
            	        				    	        		LE143_tree = (IASTNode)adaptor.Create(LE143);
            	        				    	        		root_0 = (IASTNode)adaptor.BecomeRoot(LE143_tree, root_0);


            	        				    	        }
            	        				    	        break;
            	        				    	    case 4 :
            	        				    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:598:27: GE
            	        				    	        {
            	        				    	        	GE144=(IToken)Match(input,GE,FOLLOW_GE_in_relationalExpression1966); 
            	        				    	        		GE144_tree = (IASTNode)adaptor.Create(GE144);
            	        				    	        		root_0 = (IASTNode)adaptor.BecomeRoot(GE144_tree, root_0);


            	        				    	        }
            	        				    	        break;

            	        				    	}

            	        				    	PushFollow(FOLLOW_additiveExpression_in_relationalExpression1971);
            	        				    	additiveExpression145 = additiveExpression();
            	        				    	state.followingStackPointer--;

            	        				    	adaptor.AddChild(root_0, additiveExpression145.Tree);

            	        				    }
            	        				    break;

            	        				default:
            	        				    goto loop44;
            	        		    }
            	        		} while (true);

            	        		loop44:
            	        			;	// Stops C# compiler whining that label 'loop44' has no statements


            	        	}


            	        }
            	        break;
            	    case 2 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:600:5: (n= NOT )? ( (i= IN inList ) | (b= BETWEEN betweenList ) | (l= LIKE concatenation likeEscape ) | ( MEMBER ( OF )? p= path ) )
            	        {
            	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:600:5: (n= NOT )?
            	        	int alt45 = 2;
            	        	int LA45_0 = input.LA(1);

            	        	if ( (LA45_0 == NOT) )
            	        	{
            	        	    alt45 = 1;
            	        	}
            	        	switch (alt45) 
            	        	{
            	        	    case 1 :
            	        	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:600:6: n= NOT
            	        	        {
            	        	        	n=(IToken)Match(input,NOT,FOLLOW_NOT_in_relationalExpression1988); 

            	        	        }
            	        	        break;

            	        	}

            	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:600:15: ( (i= IN inList ) | (b= BETWEEN betweenList ) | (l= LIKE concatenation likeEscape ) | ( MEMBER ( OF )? p= path ) )
            	        	int alt47 = 4;
            	        	switch ( input.LA(1) ) 
            	        	{
            	        	case IN:
            	        		{
            	        	    alt47 = 1;
            	        	    }
            	        	    break;
            	        	case BETWEEN:
            	        		{
            	        	    alt47 = 2;
            	        	    }
            	        	    break;
            	        	case LIKE:
            	        		{
            	        	    alt47 = 3;
            	        	    }
            	        	    break;
            	        	case MEMBER:
            	        		{
            	        	    alt47 = 4;
            	        	    }
            	        	    break;
            	        		default:
            	        		    NoViableAltException nvae_d47s0 =
            	        		        new NoViableAltException("", 47, 0, input);

            	        		    throw nvae_d47s0;
            	        	}

            	        	switch (alt47) 
            	        	{
            	        	    case 1 :
            	        	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:603:4: (i= IN inList )
            	        	        {
            	        	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:603:4: (i= IN inList )
            	        	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:603:5: i= IN inList
            	        	        	{
            	        	        		i=(IToken)Match(input,IN,FOLLOW_IN_in_relationalExpression2009); 
            	        	        			i_tree = (IASTNode)adaptor.Create(i);
            	        	        			root_0 = (IASTNode)adaptor.BecomeRoot(i_tree, root_0);


            	        	        							i.Type = (n == null) ? IN : NOT_IN;
            	        	        							i.Text = (n == null) ? "in" : "not in";
            	        	        						
            	        	        		PushFollow(FOLLOW_inList_in_relationalExpression2018);
            	        	        		inList146 = inList();
            	        	        		state.followingStackPointer--;

            	        	        		adaptor.AddChild(root_0, inList146.Tree);

            	        	        	}


            	        	        }
            	        	        break;
            	        	    case 2 :
            	        	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:608:6: (b= BETWEEN betweenList )
            	        	        {
            	        	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:608:6: (b= BETWEEN betweenList )
            	        	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:608:7: b= BETWEEN betweenList
            	        	        	{
            	        	        		b=(IToken)Match(input,BETWEEN,FOLLOW_BETWEEN_in_relationalExpression2029); 
            	        	        			b_tree = (IASTNode)adaptor.Create(b);
            	        	        			root_0 = (IASTNode)adaptor.BecomeRoot(b_tree, root_0);


            	        	        							b.Type = (n == null) ? BETWEEN : NOT_BETWEEN;
            	        	        							b.Text = (n == null) ? "between" : "not between";
            	        	        						
            	        	        		PushFollow(FOLLOW_betweenList_in_relationalExpression2038);
            	        	        		betweenList147 = betweenList();
            	        	        		state.followingStackPointer--;

            	        	        		adaptor.AddChild(root_0, betweenList147.Tree);

            	        	        	}


            	        	        }
            	        	        break;
            	        	    case 3 :
            	        	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:613:6: (l= LIKE concatenation likeEscape )
            	        	        {
            	        	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:613:6: (l= LIKE concatenation likeEscape )
            	        	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:613:7: l= LIKE concatenation likeEscape
            	        	        	{
            	        	        		l=(IToken)Match(input,LIKE,FOLLOW_LIKE_in_relationalExpression2050); 
            	        	        			l_tree = (IASTNode)adaptor.Create(l);
            	        	        			root_0 = (IASTNode)adaptor.BecomeRoot(l_tree, root_0);


            	        	        							l.Type = (n == null) ? LIKE : NOT_LIKE;
            	        	        							l.Text = (n == null) ? "like" : "not like";
            	        	        						
            	        	        		PushFollow(FOLLOW_concatenation_in_relationalExpression2059);
            	        	        		concatenation148 = concatenation();
            	        	        		state.followingStackPointer--;

            	        	        		adaptor.AddChild(root_0, concatenation148.Tree);
            	        	        		PushFollow(FOLLOW_likeEscape_in_relationalExpression2061);
            	        	        		likeEscape149 = likeEscape();
            	        	        		state.followingStackPointer--;

            	        	        		adaptor.AddChild(root_0, likeEscape149.Tree);

            	        	        	}


            	        	        }
            	        	        break;
            	        	    case 4 :
            	        	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:618:6: ( MEMBER ( OF )? p= path )
            	        	        {
            	        	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:618:6: ( MEMBER ( OF )? p= path )
            	        	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:618:7: MEMBER ( OF )? p= path
            	        	        	{
            	        	        		MEMBER150=(IToken)Match(input,MEMBER,FOLLOW_MEMBER_in_relationalExpression2070); 
            	        	        		// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:618:15: ( OF )?
            	        	        		int alt46 = 2;
            	        	        		int LA46_0 = input.LA(1);

            	        	        		if ( (LA46_0 == OF) )
            	        	        		{
            	        	        		    alt46 = 1;
            	        	        		}
            	        	        		switch (alt46) 
            	        	        		{
            	        	        		    case 1 :
            	        	        		        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:618:16: OF
            	        	        		        {
            	        	        		        	OF151=(IToken)Match(input,OF,FOLLOW_OF_in_relationalExpression2074); 

            	        	        		        }
            	        	        		        break;

            	        	        		}

            	        	        		PushFollow(FOLLOW_path_in_relationalExpression2081);
            	        	        		p = path();
            	        	        		state.followingStackPointer--;


            	        	        						ProcessMemberOf(n,((p != null) ? ((IASTNode)p.Tree) : null));
            	        	        					  

            	        	        	}


            	        	        }
            	        	        break;

            	        	}


            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "relationalExpression"

    public class likeEscape_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "likeEscape"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:625:1: likeEscape : ( ESCAPE concatenation )? ;
    public HqlParser.likeEscape_return likeEscape() // throws RecognitionException [1]
    {   
        HqlParser.likeEscape_return retval = new HqlParser.likeEscape_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken ESCAPE152 = null;
        HqlParser.concatenation_return concatenation153 = default(HqlParser.concatenation_return);


        IASTNode ESCAPE152_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:626:2: ( ( ESCAPE concatenation )? )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:626:4: ( ESCAPE concatenation )?
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:626:4: ( ESCAPE concatenation )?
            	int alt49 = 2;
            	alt49 = dfa49.Predict(input);
            	switch (alt49) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:626:5: ESCAPE concatenation
            	        {
            	        	ESCAPE152=(IToken)Match(input,ESCAPE,FOLLOW_ESCAPE_in_likeEscape2108); 
            	        		ESCAPE152_tree = (IASTNode)adaptor.Create(ESCAPE152);
            	        		root_0 = (IASTNode)adaptor.BecomeRoot(ESCAPE152_tree, root_0);

            	        	PushFollow(FOLLOW_concatenation_in_likeEscape2111);
            	        	concatenation153 = concatenation();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, concatenation153.Tree);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "likeEscape"

    public class inList_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "inList"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:636:1: inList : compoundExpr -> ^( IN_LIST compoundExpr ) ;
    public HqlParser.inList_return inList() // throws RecognitionException [1]
    {   
        HqlParser.inList_return retval = new HqlParser.inList_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        HqlParser.compoundExpr_return compoundExpr154 = default(HqlParser.compoundExpr_return);


        RewriteRuleSubtreeStream stream_compoundExpr = new RewriteRuleSubtreeStream(adaptor,"rule compoundExpr");
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:637:2: ( compoundExpr -> ^( IN_LIST compoundExpr ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:637:4: compoundExpr
            {
            	PushFollow(FOLLOW_compoundExpr_in_inList2126);
            	compoundExpr154 = compoundExpr();
            	state.followingStackPointer--;

            	stream_compoundExpr.Add(compoundExpr154.Tree);


            	// AST REWRITE
            	// elements:          compoundExpr
            	// token labels:      
            	// rule labels:       retval
            	// token list labels: 
            	// rule list labels:  
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));

            	root_0 = (IASTNode)adaptor.GetNilNode();
            	// 638:2: -> ^( IN_LIST compoundExpr )
            	{
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:638:5: ^( IN_LIST compoundExpr )
            	    {
            	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
            	    root_1 = (IASTNode)adaptor.BecomeRoot((IASTNode)adaptor.Create(IN_LIST, "IN_LIST"), root_1);

            	    adaptor.AddChild(root_1, stream_compoundExpr.NextTree());

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;retval.Tree = root_0;
            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "inList"

    public class betweenList_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "betweenList"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:641:1: betweenList : concatenation AND concatenation ;
    public HqlParser.betweenList_return betweenList() // throws RecognitionException [1]
    {   
        HqlParser.betweenList_return retval = new HqlParser.betweenList_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken AND156 = null;
        HqlParser.concatenation_return concatenation155 = default(HqlParser.concatenation_return);

        HqlParser.concatenation_return concatenation157 = default(HqlParser.concatenation_return);


        IASTNode AND156_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:642:2: ( concatenation AND concatenation )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:642:4: concatenation AND concatenation
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	PushFollow(FOLLOW_concatenation_in_betweenList2146);
            	concatenation155 = concatenation();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, concatenation155.Tree);
            	AND156=(IToken)Match(input,AND,FOLLOW_AND_in_betweenList2148); 
            	PushFollow(FOLLOW_concatenation_in_betweenList2151);
            	concatenation157 = concatenation();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, concatenation157.Tree);

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "betweenList"

    public class concatenation_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "concatenation"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:658:1: concatenation : additiveExpression (c= CONCAT additiveExpression ( CONCAT additiveExpression )* )? ;
    public HqlParser.concatenation_return concatenation() // throws RecognitionException [1]
    {   
        HqlParser.concatenation_return retval = new HqlParser.concatenation_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken c = null;
        IToken CONCAT160 = null;
        HqlParser.additiveExpression_return additiveExpression158 = default(HqlParser.additiveExpression_return);

        HqlParser.additiveExpression_return additiveExpression159 = default(HqlParser.additiveExpression_return);

        HqlParser.additiveExpression_return additiveExpression161 = default(HqlParser.additiveExpression_return);


        IASTNode c_tree=null;
        IASTNode CONCAT160_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:659:2: ( additiveExpression (c= CONCAT additiveExpression ( CONCAT additiveExpression )* )? )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:659:4: additiveExpression (c= CONCAT additiveExpression ( CONCAT additiveExpression )* )?
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	PushFollow(FOLLOW_additiveExpression_in_concatenation2166);
            	additiveExpression158 = additiveExpression();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, additiveExpression158.Tree);
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:660:2: (c= CONCAT additiveExpression ( CONCAT additiveExpression )* )?
            	int alt51 = 2;
            	alt51 = dfa51.Predict(input);
            	switch (alt51) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:660:4: c= CONCAT additiveExpression ( CONCAT additiveExpression )*
            	        {
            	        	c=(IToken)Match(input,CONCAT,FOLLOW_CONCAT_in_concatenation2174); 
            	        		c_tree = (IASTNode)adaptor.Create(c);
            	        		root_0 = (IASTNode)adaptor.BecomeRoot(c_tree, root_0);

            	        	PushFollow(FOLLOW_additiveExpression_in_concatenation2181);
            	        	additiveExpression159 = additiveExpression();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, additiveExpression159.Tree);
            	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:662:4: ( CONCAT additiveExpression )*
            	        	do 
            	        	{
            	        	    int alt50 = 2;
            	        	    alt50 = dfa50.Predict(input);
            	        	    switch (alt50) 
            	        		{
            	        			case 1 :
            	        			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:662:6: CONCAT additiveExpression
            	        			    {
            	        			    	CONCAT160=(IToken)Match(input,CONCAT,FOLLOW_CONCAT_in_concatenation2188); 
            	        			    	PushFollow(FOLLOW_additiveExpression_in_concatenation2191);
            	        			    	additiveExpression161 = additiveExpression();
            	        			    	state.followingStackPointer--;

            	        			    	adaptor.AddChild(root_0, additiveExpression161.Tree);

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop50;
            	        	    }
            	        	} while (true);

            	        	loop50:
            	        		;	// Stops C# compiler whining that label 'loop50' has no statements


            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "concatenation"

    public class additiveExpression_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "additiveExpression"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:667:1: additiveExpression : multiplyExpression ( ( PLUS | MINUS ) multiplyExpression )* ;
    public HqlParser.additiveExpression_return additiveExpression() // throws RecognitionException [1]
    {   
        HqlParser.additiveExpression_return retval = new HqlParser.additiveExpression_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken PLUS163 = null;
        IToken MINUS164 = null;
        HqlParser.multiplyExpression_return multiplyExpression162 = default(HqlParser.multiplyExpression_return);

        HqlParser.multiplyExpression_return multiplyExpression165 = default(HqlParser.multiplyExpression_return);


        IASTNode PLUS163_tree=null;
        IASTNode MINUS164_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:668:2: ( multiplyExpression ( ( PLUS | MINUS ) multiplyExpression )* )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:668:4: multiplyExpression ( ( PLUS | MINUS ) multiplyExpression )*
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	PushFollow(FOLLOW_multiplyExpression_in_additiveExpression2213);
            	multiplyExpression162 = multiplyExpression();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, multiplyExpression162.Tree);
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:668:23: ( ( PLUS | MINUS ) multiplyExpression )*
            	do 
            	{
            	    int alt53 = 2;
            	    alt53 = dfa53.Predict(input);
            	    switch (alt53) 
            		{
            			case 1 :
            			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:668:25: ( PLUS | MINUS ) multiplyExpression
            			    {
            			    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:668:25: ( PLUS | MINUS )
            			    	int alt52 = 2;
            			    	int LA52_0 = input.LA(1);

            			    	if ( (LA52_0 == PLUS) )
            			    	{
            			    	    alt52 = 1;
            			    	}
            			    	else if ( (LA52_0 == MINUS) )
            			    	{
            			    	    alt52 = 2;
            			    	}
            			    	else 
            			    	{
            			    	    NoViableAltException nvae_d52s0 =
            			    	        new NoViableAltException("", 52, 0, input);

            			    	    throw nvae_d52s0;
            			    	}
            			    	switch (alt52) 
            			    	{
            			    	    case 1 :
            			    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:668:27: PLUS
            			    	        {
            			    	        	PLUS163=(IToken)Match(input,PLUS,FOLLOW_PLUS_in_additiveExpression2219); 
            			    	        		PLUS163_tree = (IASTNode)adaptor.Create(PLUS163);
            			    	        		root_0 = (IASTNode)adaptor.BecomeRoot(PLUS163_tree, root_0);


            			    	        }
            			    	        break;
            			    	    case 2 :
            			    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:668:35: MINUS
            			    	        {
            			    	        	MINUS164=(IToken)Match(input,MINUS,FOLLOW_MINUS_in_additiveExpression2224); 
            			    	        		MINUS164_tree = (IASTNode)adaptor.Create(MINUS164);
            			    	        		root_0 = (IASTNode)adaptor.BecomeRoot(MINUS164_tree, root_0);


            			    	        }
            			    	        break;

            			    	}

            			    	PushFollow(FOLLOW_multiplyExpression_in_additiveExpression2229);
            			    	multiplyExpression165 = multiplyExpression();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, multiplyExpression165.Tree);

            			    }
            			    break;

            			default:
            			    goto loop53;
            	    }
            	} while (true);

            	loop53:
            		;	// Stops C# compiler whining that label 'loop53' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "additiveExpression"

    public class multiplyExpression_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "multiplyExpression"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:672:1: multiplyExpression : unaryExpression ( ( STAR | DIV ) unaryExpression )* ;
    public HqlParser.multiplyExpression_return multiplyExpression() // throws RecognitionException [1]
    {   
        HqlParser.multiplyExpression_return retval = new HqlParser.multiplyExpression_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken STAR167 = null;
        IToken DIV168 = null;
        HqlParser.unaryExpression_return unaryExpression166 = default(HqlParser.unaryExpression_return);

        HqlParser.unaryExpression_return unaryExpression169 = default(HqlParser.unaryExpression_return);


        IASTNode STAR167_tree=null;
        IASTNode DIV168_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:673:2: ( unaryExpression ( ( STAR | DIV ) unaryExpression )* )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:673:4: unaryExpression ( ( STAR | DIV ) unaryExpression )*
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	PushFollow(FOLLOW_unaryExpression_in_multiplyExpression2244);
            	unaryExpression166 = unaryExpression();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, unaryExpression166.Tree);
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:673:20: ( ( STAR | DIV ) unaryExpression )*
            	do 
            	{
            	    int alt55 = 2;
            	    alt55 = dfa55.Predict(input);
            	    switch (alt55) 
            		{
            			case 1 :
            			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:673:22: ( STAR | DIV ) unaryExpression
            			    {
            			    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:673:22: ( STAR | DIV )
            			    	int alt54 = 2;
            			    	int LA54_0 = input.LA(1);

            			    	if ( (LA54_0 == STAR) )
            			    	{
            			    	    alt54 = 1;
            			    	}
            			    	else if ( (LA54_0 == DIV) )
            			    	{
            			    	    alt54 = 2;
            			    	}
            			    	else 
            			    	{
            			    	    NoViableAltException nvae_d54s0 =
            			    	        new NoViableAltException("", 54, 0, input);

            			    	    throw nvae_d54s0;
            			    	}
            			    	switch (alt54) 
            			    	{
            			    	    case 1 :
            			    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:673:24: STAR
            			    	        {
            			    	        	STAR167=(IToken)Match(input,STAR,FOLLOW_STAR_in_multiplyExpression2250); 
            			    	        		STAR167_tree = (IASTNode)adaptor.Create(STAR167);
            			    	        		root_0 = (IASTNode)adaptor.BecomeRoot(STAR167_tree, root_0);


            			    	        }
            			    	        break;
            			    	    case 2 :
            			    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:673:32: DIV
            			    	        {
            			    	        	DIV168=(IToken)Match(input,DIV,FOLLOW_DIV_in_multiplyExpression2255); 
            			    	        		DIV168_tree = (IASTNode)adaptor.Create(DIV168);
            			    	        		root_0 = (IASTNode)adaptor.BecomeRoot(DIV168_tree, root_0);


            			    	        }
            			    	        break;

            			    	}

            			    	PushFollow(FOLLOW_unaryExpression_in_multiplyExpression2260);
            			    	unaryExpression169 = unaryExpression();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, unaryExpression169.Tree);

            			    }
            			    break;

            			default:
            			    goto loop55;
            	    }
            	} while (true);

            	loop55:
            		;	// Stops C# compiler whining that label 'loop55' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "multiplyExpression"

    public class unaryExpression_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "unaryExpression"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:687:1: unaryExpression : (m= MINUS mu= unaryExpression | p= PLUS pu= unaryExpression | c= caseExpression | q= quantifiedExpression | a= atom -> {m != null}? ^( UNARY_MINUS[$m] $mu) -> {p != null}? ^( UNARY_PLUS[$p] $pu) -> {c != null}? ^( $c) -> {q != null}? ^( $q) -> ^( $a) );
    public HqlParser.unaryExpression_return unaryExpression() // throws RecognitionException [1]
    {   
        HqlParser.unaryExpression_return retval = new HqlParser.unaryExpression_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken m = null;
        IToken p = null;
        HqlParser.unaryExpression_return mu = default(HqlParser.unaryExpression_return);

        HqlParser.unaryExpression_return pu = default(HqlParser.unaryExpression_return);

        HqlParser.caseExpression_return c = default(HqlParser.caseExpression_return);

        HqlParser.quantifiedExpression_return q = default(HqlParser.quantifiedExpression_return);

        HqlParser.atom_return a = default(HqlParser.atom_return);


        IASTNode m_tree=null;
        IASTNode p_tree=null;
        RewriteRuleSubtreeStream stream_atom = new RewriteRuleSubtreeStream(adaptor,"rule atom");
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:688:2: (m= MINUS mu= unaryExpression | p= PLUS pu= unaryExpression | c= caseExpression | q= quantifiedExpression | a= atom -> {m != null}? ^( UNARY_MINUS[$m] $mu) -> {p != null}? ^( UNARY_PLUS[$p] $pu) -> {c != null}? ^( $c) -> {q != null}? ^( $q) -> ^( $a) )
            int alt56 = 5;
            alt56 = dfa56.Predict(input);
            switch (alt56) 
            {
                case 1 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:688:4: m= MINUS mu= unaryExpression
                    {
                    	root_0 = (IASTNode)adaptor.GetNilNode();

                    	m=(IToken)Match(input,MINUS,FOLLOW_MINUS_in_unaryExpression2280); 
                    		m_tree = (IASTNode)adaptor.Create(m);
                    		adaptor.AddChild(root_0, m_tree);

                    	PushFollow(FOLLOW_unaryExpression_in_unaryExpression2284);
                    	mu = unaryExpression();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, mu.Tree);

                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:689:4: p= PLUS pu= unaryExpression
                    {
                    	root_0 = (IASTNode)adaptor.GetNilNode();

                    	p=(IToken)Match(input,PLUS,FOLLOW_PLUS_in_unaryExpression2291); 
                    		p_tree = (IASTNode)adaptor.Create(p);
                    		adaptor.AddChild(root_0, p_tree);

                    	PushFollow(FOLLOW_unaryExpression_in_unaryExpression2295);
                    	pu = unaryExpression();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, pu.Tree);

                    }
                    break;
                case 3 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:690:4: c= caseExpression
                    {
                    	root_0 = (IASTNode)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_caseExpression_in_unaryExpression2302);
                    	c = caseExpression();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, c.Tree);

                    }
                    break;
                case 4 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:691:4: q= quantifiedExpression
                    {
                    	root_0 = (IASTNode)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_quantifiedExpression_in_unaryExpression2309);
                    	q = quantifiedExpression();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, q.Tree);

                    }
                    break;
                case 5 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:692:4: a= atom
                    {
                    	PushFollow(FOLLOW_atom_in_unaryExpression2316);
                    	a = atom();
                    	state.followingStackPointer--;

                    	stream_atom.Add(a.Tree);


                    	// AST REWRITE
                    	// elements:          mu, pu, c, q, a
                    	// token labels:      
                    	// rule labels:       mu, a, c, pu, retval, q
                    	// token list labels: 
                    	// rule list labels:  
                    	retval.Tree = root_0;
                    	RewriteRuleSubtreeStream stream_mu = new RewriteRuleSubtreeStream(adaptor, "token mu", (mu!=null ? mu.Tree : null));
                    	RewriteRuleSubtreeStream stream_a = new RewriteRuleSubtreeStream(adaptor, "token a", (a!=null ? a.Tree : null));
                    	RewriteRuleSubtreeStream stream_c = new RewriteRuleSubtreeStream(adaptor, "token c", (c!=null ? c.Tree : null));
                    	RewriteRuleSubtreeStream stream_pu = new RewriteRuleSubtreeStream(adaptor, "token pu", (pu!=null ? pu.Tree : null));
                    	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));
                    	RewriteRuleSubtreeStream stream_q = new RewriteRuleSubtreeStream(adaptor, "token q", (q!=null ? q.Tree : null));

                    	root_0 = (IASTNode)adaptor.GetNilNode();
                    	// 693:2: -> {m != null}? ^( UNARY_MINUS[$m] $mu)
                    	if (m != null)
                    	{
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:693:18: ^( UNARY_MINUS[$m] $mu)
                    	    {
                    	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
                    	    root_1 = (IASTNode)adaptor.BecomeRoot((IASTNode)adaptor.Create(UNARY_MINUS, m), root_1);

                    	    adaptor.AddChild(root_1, stream_mu.NextTree());

                    	    adaptor.AddChild(root_0, root_1);
                    	    }

                    	}
                    	else // 694:2: -> {p != null}? ^( UNARY_PLUS[$p] $pu)
                    	if (p != null)
                    	{
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:694:18: ^( UNARY_PLUS[$p] $pu)
                    	    {
                    	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
                    	    root_1 = (IASTNode)adaptor.BecomeRoot((IASTNode)adaptor.Create(UNARY_PLUS, p), root_1);

                    	    adaptor.AddChild(root_1, stream_pu.NextTree());

                    	    adaptor.AddChild(root_0, root_1);
                    	    }

                    	}
                    	else // 695:2: -> {c != null}? ^( $c)
                    	if (c != null)
                    	{
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:695:18: ^( $c)
                    	    {
                    	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
                    	    root_1 = (IASTNode)adaptor.BecomeRoot(stream_c.NextNode(), root_1);

                    	    adaptor.AddChild(root_0, root_1);
                    	    }

                    	}
                    	else // 696:2: -> {q != null}? ^( $q)
                    	if (q != null)
                    	{
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:696:18: ^( $q)
                    	    {
                    	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
                    	    root_1 = (IASTNode)adaptor.BecomeRoot(stream_q.NextNode(), root_1);

                    	    adaptor.AddChild(root_0, root_1);
                    	    }

                    	}
                    	else // 697:2: -> ^( $a)
                    	{
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:697:5: ^( $a)
                    	    {
                    	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
                    	    root_1 = (IASTNode)adaptor.BecomeRoot(stream_a.NextNode(), root_1);

                    	    adaptor.AddChild(root_0, root_1);
                    	    }

                    	}

                    	retval.Tree = root_0;retval.Tree = root_0;
                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "unaryExpression"

    public class caseExpression_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "caseExpression"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:708:1: caseExpression : ( CASE ( whenClause )+ ( elseClause )? END -> ^( CASE whenClause ( elseClause )? ) | CASE unaryExpression ( altWhenClause )+ ( elseClause )? END -> ^( CASE2 unaryExpression ( altWhenClause )+ ( elseClause )? ) );
    public HqlParser.caseExpression_return caseExpression() // throws RecognitionException [1]
    {   
        HqlParser.caseExpression_return retval = new HqlParser.caseExpression_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken CASE170 = null;
        IToken END173 = null;
        IToken CASE174 = null;
        IToken END178 = null;
        HqlParser.whenClause_return whenClause171 = default(HqlParser.whenClause_return);

        HqlParser.elseClause_return elseClause172 = default(HqlParser.elseClause_return);

        HqlParser.unaryExpression_return unaryExpression175 = default(HqlParser.unaryExpression_return);

        HqlParser.altWhenClause_return altWhenClause176 = default(HqlParser.altWhenClause_return);

        HqlParser.elseClause_return elseClause177 = default(HqlParser.elseClause_return);


        IASTNode CASE170_tree=null;
        IASTNode END173_tree=null;
        IASTNode CASE174_tree=null;
        IASTNode END178_tree=null;
        RewriteRuleTokenStream stream_CASE = new RewriteRuleTokenStream(adaptor,"token CASE");
        RewriteRuleTokenStream stream_END = new RewriteRuleTokenStream(adaptor,"token END");
        RewriteRuleSubtreeStream stream_unaryExpression = new RewriteRuleSubtreeStream(adaptor,"rule unaryExpression");
        RewriteRuleSubtreeStream stream_whenClause = new RewriteRuleSubtreeStream(adaptor,"rule whenClause");
        RewriteRuleSubtreeStream stream_elseClause = new RewriteRuleSubtreeStream(adaptor,"rule elseClause");
        RewriteRuleSubtreeStream stream_altWhenClause = new RewriteRuleSubtreeStream(adaptor,"rule altWhenClause");
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:709:2: ( CASE ( whenClause )+ ( elseClause )? END -> ^( CASE whenClause ( elseClause )? ) | CASE unaryExpression ( altWhenClause )+ ( elseClause )? END -> ^( CASE2 unaryExpression ( altWhenClause )+ ( elseClause )? ) )
            int alt61 = 2;
            alt61 = dfa61.Predict(input);
            switch (alt61) 
            {
                case 1 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:709:4: CASE ( whenClause )+ ( elseClause )? END
                    {
                    	CASE170=(IToken)Match(input,CASE,FOLLOW_CASE_in_caseExpression2385);  
                    	stream_CASE.Add(CASE170);

                    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:709:9: ( whenClause )+
                    	int cnt57 = 0;
                    	do 
                    	{
                    	    int alt57 = 2;
                    	    int LA57_0 = input.LA(1);

                    	    if ( (LA57_0 == WHEN) )
                    	    {
                    	        alt57 = 1;
                    	    }


                    	    switch (alt57) 
                    		{
                    			case 1 :
                    			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:709:10: whenClause
                    			    {
                    			    	PushFollow(FOLLOW_whenClause_in_caseExpression2388);
                    			    	whenClause171 = whenClause();
                    			    	state.followingStackPointer--;

                    			    	stream_whenClause.Add(whenClause171.Tree);

                    			    }
                    			    break;

                    			default:
                    			    if ( cnt57 >= 1 ) goto loop57;
                    		            EarlyExitException eee =
                    		                new EarlyExitException(57, input);
                    		            throw eee;
                    	    }
                    	    cnt57++;
                    	} while (true);

                    	loop57:
                    		;	// Stops C# compiler whinging that label 'loop57' has no statements

                    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:709:23: ( elseClause )?
                    	int alt58 = 2;
                    	int LA58_0 = input.LA(1);

                    	if ( (LA58_0 == ELSE) )
                    	{
                    	    alt58 = 1;
                    	}
                    	switch (alt58) 
                    	{
                    	    case 1 :
                    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:709:24: elseClause
                    	        {
                    	        	PushFollow(FOLLOW_elseClause_in_caseExpression2393);
                    	        	elseClause172 = elseClause();
                    	        	state.followingStackPointer--;

                    	        	stream_elseClause.Add(elseClause172.Tree);

                    	        }
                    	        break;

                    	}

                    	END173=(IToken)Match(input,END,FOLLOW_END_in_caseExpression2397);  
                    	stream_END.Add(END173);



                    	// AST REWRITE
                    	// elements:          whenClause, CASE, elseClause
                    	// token labels:      
                    	// rule labels:       retval
                    	// token list labels: 
                    	// rule list labels:  
                    	retval.Tree = root_0;
                    	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));

                    	root_0 = (IASTNode)adaptor.GetNilNode();
                    	// 710:3: -> ^( CASE whenClause ( elseClause )? )
                    	{
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:710:6: ^( CASE whenClause ( elseClause )? )
                    	    {
                    	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
                    	    root_1 = (IASTNode)adaptor.BecomeRoot(stream_CASE.NextNode(), root_1);

                    	    adaptor.AddChild(root_1, stream_whenClause.NextTree());
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:710:24: ( elseClause )?
                    	    if ( stream_elseClause.HasNext() )
                    	    {
                    	        adaptor.AddChild(root_1, stream_elseClause.NextTree());

                    	    }
                    	    stream_elseClause.Reset();

                    	    adaptor.AddChild(root_0, root_1);
                    	    }

                    	}

                    	retval.Tree = root_0;retval.Tree = root_0;
                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:711:4: CASE unaryExpression ( altWhenClause )+ ( elseClause )? END
                    {
                    	CASE174=(IToken)Match(input,CASE,FOLLOW_CASE_in_caseExpression2416);  
                    	stream_CASE.Add(CASE174);

                    	PushFollow(FOLLOW_unaryExpression_in_caseExpression2418);
                    	unaryExpression175 = unaryExpression();
                    	state.followingStackPointer--;

                    	stream_unaryExpression.Add(unaryExpression175.Tree);
                    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:711:25: ( altWhenClause )+
                    	int cnt59 = 0;
                    	do 
                    	{
                    	    int alt59 = 2;
                    	    int LA59_0 = input.LA(1);

                    	    if ( (LA59_0 == WHEN) )
                    	    {
                    	        alt59 = 1;
                    	    }


                    	    switch (alt59) 
                    		{
                    			case 1 :
                    			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:711:26: altWhenClause
                    			    {
                    			    	PushFollow(FOLLOW_altWhenClause_in_caseExpression2421);
                    			    	altWhenClause176 = altWhenClause();
                    			    	state.followingStackPointer--;

                    			    	stream_altWhenClause.Add(altWhenClause176.Tree);

                    			    }
                    			    break;

                    			default:
                    			    if ( cnt59 >= 1 ) goto loop59;
                    		            EarlyExitException eee =
                    		                new EarlyExitException(59, input);
                    		            throw eee;
                    	    }
                    	    cnt59++;
                    	} while (true);

                    	loop59:
                    		;	// Stops C# compiler whinging that label 'loop59' has no statements

                    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:711:42: ( elseClause )?
                    	int alt60 = 2;
                    	int LA60_0 = input.LA(1);

                    	if ( (LA60_0 == ELSE) )
                    	{
                    	    alt60 = 1;
                    	}
                    	switch (alt60) 
                    	{
                    	    case 1 :
                    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:711:43: elseClause
                    	        {
                    	        	PushFollow(FOLLOW_elseClause_in_caseExpression2426);
                    	        	elseClause177 = elseClause();
                    	        	state.followingStackPointer--;

                    	        	stream_elseClause.Add(elseClause177.Tree);

                    	        }
                    	        break;

                    	}

                    	END178=(IToken)Match(input,END,FOLLOW_END_in_caseExpression2430);  
                    	stream_END.Add(END178);



                    	// AST REWRITE
                    	// elements:          unaryExpression, altWhenClause, elseClause
                    	// token labels:      
                    	// rule labels:       retval
                    	// token list labels: 
                    	// rule list labels:  
                    	retval.Tree = root_0;
                    	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));

                    	root_0 = (IASTNode)adaptor.GetNilNode();
                    	// 712:3: -> ^( CASE2 unaryExpression ( altWhenClause )+ ( elseClause )? )
                    	{
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:712:6: ^( CASE2 unaryExpression ( altWhenClause )+ ( elseClause )? )
                    	    {
                    	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
                    	    root_1 = (IASTNode)adaptor.BecomeRoot((IASTNode)adaptor.Create(CASE2, "CASE2"), root_1);

                    	    adaptor.AddChild(root_1, stream_unaryExpression.NextTree());
                    	    if ( !(stream_altWhenClause.HasNext()) ) {
                    	        throw new RewriteEarlyExitException();
                    	    }
                    	    while ( stream_altWhenClause.HasNext() )
                    	    {
                    	        adaptor.AddChild(root_1, stream_altWhenClause.NextTree());

                    	    }
                    	    stream_altWhenClause.Reset();
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:712:45: ( elseClause )?
                    	    if ( stream_elseClause.HasNext() )
                    	    {
                    	        adaptor.AddChild(root_1, stream_elseClause.NextTree());

                    	    }
                    	    stream_elseClause.Reset();

                    	    adaptor.AddChild(root_0, root_1);
                    	    }

                    	}

                    	retval.Tree = root_0;retval.Tree = root_0;
                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "caseExpression"

    public class whenClause_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "whenClause"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:715:1: whenClause : ( WHEN logicalExpression THEN unaryExpression ) ;
    public HqlParser.whenClause_return whenClause() // throws RecognitionException [1]
    {   
        HqlParser.whenClause_return retval = new HqlParser.whenClause_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken WHEN179 = null;
        IToken THEN181 = null;
        HqlParser.logicalExpression_return logicalExpression180 = default(HqlParser.logicalExpression_return);

        HqlParser.unaryExpression_return unaryExpression182 = default(HqlParser.unaryExpression_return);


        IASTNode WHEN179_tree=null;
        IASTNode THEN181_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:716:2: ( ( WHEN logicalExpression THEN unaryExpression ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:716:4: ( WHEN logicalExpression THEN unaryExpression )
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:716:4: ( WHEN logicalExpression THEN unaryExpression )
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:716:5: WHEN logicalExpression THEN unaryExpression
            	{
            		WHEN179=(IToken)Match(input,WHEN,FOLLOW_WHEN_in_whenClause2459); 
            			WHEN179_tree = (IASTNode)adaptor.Create(WHEN179);
            			root_0 = (IASTNode)adaptor.BecomeRoot(WHEN179_tree, root_0);

            		PushFollow(FOLLOW_logicalExpression_in_whenClause2462);
            		logicalExpression180 = logicalExpression();
            		state.followingStackPointer--;

            		adaptor.AddChild(root_0, logicalExpression180.Tree);
            		THEN181=(IToken)Match(input,THEN,FOLLOW_THEN_in_whenClause2464); 
            		PushFollow(FOLLOW_unaryExpression_in_whenClause2467);
            		unaryExpression182 = unaryExpression();
            		state.followingStackPointer--;

            		adaptor.AddChild(root_0, unaryExpression182.Tree);

            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "whenClause"

    public class altWhenClause_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "altWhenClause"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:719:1: altWhenClause : ( WHEN unaryExpression THEN unaryExpression ) ;
    public HqlParser.altWhenClause_return altWhenClause() // throws RecognitionException [1]
    {   
        HqlParser.altWhenClause_return retval = new HqlParser.altWhenClause_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken WHEN183 = null;
        IToken THEN185 = null;
        HqlParser.unaryExpression_return unaryExpression184 = default(HqlParser.unaryExpression_return);

        HqlParser.unaryExpression_return unaryExpression186 = default(HqlParser.unaryExpression_return);


        IASTNode WHEN183_tree=null;
        IASTNode THEN185_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:720:2: ( ( WHEN unaryExpression THEN unaryExpression ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:720:4: ( WHEN unaryExpression THEN unaryExpression )
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:720:4: ( WHEN unaryExpression THEN unaryExpression )
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:720:5: WHEN unaryExpression THEN unaryExpression
            	{
            		WHEN183=(IToken)Match(input,WHEN,FOLLOW_WHEN_in_altWhenClause2481); 
            			WHEN183_tree = (IASTNode)adaptor.Create(WHEN183);
            			root_0 = (IASTNode)adaptor.BecomeRoot(WHEN183_tree, root_0);

            		PushFollow(FOLLOW_unaryExpression_in_altWhenClause2484);
            		unaryExpression184 = unaryExpression();
            		state.followingStackPointer--;

            		adaptor.AddChild(root_0, unaryExpression184.Tree);
            		THEN185=(IToken)Match(input,THEN,FOLLOW_THEN_in_altWhenClause2486); 
            		PushFollow(FOLLOW_unaryExpression_in_altWhenClause2489);
            		unaryExpression186 = unaryExpression();
            		state.followingStackPointer--;

            		adaptor.AddChild(root_0, unaryExpression186.Tree);

            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "altWhenClause"

    public class elseClause_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "elseClause"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:723:1: elseClause : ( ELSE unaryExpression ) ;
    public HqlParser.elseClause_return elseClause() // throws RecognitionException [1]
    {   
        HqlParser.elseClause_return retval = new HqlParser.elseClause_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken ELSE187 = null;
        HqlParser.unaryExpression_return unaryExpression188 = default(HqlParser.unaryExpression_return);


        IASTNode ELSE187_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:724:2: ( ( ELSE unaryExpression ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:724:4: ( ELSE unaryExpression )
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:724:4: ( ELSE unaryExpression )
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:724:5: ELSE unaryExpression
            	{
            		ELSE187=(IToken)Match(input,ELSE,FOLLOW_ELSE_in_elseClause2503); 
            			ELSE187_tree = (IASTNode)adaptor.Create(ELSE187);
            			root_0 = (IASTNode)adaptor.BecomeRoot(ELSE187_tree, root_0);

            		PushFollow(FOLLOW_unaryExpression_in_elseClause2506);
            		unaryExpression188 = unaryExpression();
            		state.followingStackPointer--;

            		adaptor.AddChild(root_0, unaryExpression188.Tree);

            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "elseClause"

    public class quantifiedExpression_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "quantifiedExpression"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:727:1: quantifiedExpression : ( SOME | EXISTS | ALL | ANY ) ( identifier | collectionExpr | ( OPEN ( subQuery ) CLOSE ) ) ;
    public HqlParser.quantifiedExpression_return quantifiedExpression() // throws RecognitionException [1]
    {   
        HqlParser.quantifiedExpression_return retval = new HqlParser.quantifiedExpression_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken SOME189 = null;
        IToken EXISTS190 = null;
        IToken ALL191 = null;
        IToken ANY192 = null;
        IToken OPEN195 = null;
        IToken CLOSE197 = null;
        HqlParser.identifier_return identifier193 = default(HqlParser.identifier_return);

        HqlParser.collectionExpr_return collectionExpr194 = default(HqlParser.collectionExpr_return);

        HqlParser.subQuery_return subQuery196 = default(HqlParser.subQuery_return);


        IASTNode SOME189_tree=null;
        IASTNode EXISTS190_tree=null;
        IASTNode ALL191_tree=null;
        IASTNode ANY192_tree=null;
        IASTNode OPEN195_tree=null;
        IASTNode CLOSE197_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:728:2: ( ( SOME | EXISTS | ALL | ANY ) ( identifier | collectionExpr | ( OPEN ( subQuery ) CLOSE ) ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:728:4: ( SOME | EXISTS | ALL | ANY ) ( identifier | collectionExpr | ( OPEN ( subQuery ) CLOSE ) )
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:728:4: ( SOME | EXISTS | ALL | ANY )
            	int alt62 = 4;
            	switch ( input.LA(1) ) 
            	{
            	case SOME:
            		{
            	    alt62 = 1;
            	    }
            	    break;
            	case EXISTS:
            		{
            	    alt62 = 2;
            	    }
            	    break;
            	case ALL:
            		{
            	    alt62 = 3;
            	    }
            	    break;
            	case ANY:
            		{
            	    alt62 = 4;
            	    }
            	    break;
            		default:
            		    NoViableAltException nvae_d62s0 =
            		        new NoViableAltException("", 62, 0, input);

            		    throw nvae_d62s0;
            	}

            	switch (alt62) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:728:6: SOME
            	        {
            	        	SOME189=(IToken)Match(input,SOME,FOLLOW_SOME_in_quantifiedExpression2521); 
            	        		SOME189_tree = (IASTNode)adaptor.Create(SOME189);
            	        		root_0 = (IASTNode)adaptor.BecomeRoot(SOME189_tree, root_0);


            	        }
            	        break;
            	    case 2 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:728:14: EXISTS
            	        {
            	        	EXISTS190=(IToken)Match(input,EXISTS,FOLLOW_EXISTS_in_quantifiedExpression2526); 
            	        		EXISTS190_tree = (IASTNode)adaptor.Create(EXISTS190);
            	        		root_0 = (IASTNode)adaptor.BecomeRoot(EXISTS190_tree, root_0);


            	        }
            	        break;
            	    case 3 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:728:24: ALL
            	        {
            	        	ALL191=(IToken)Match(input,ALL,FOLLOW_ALL_in_quantifiedExpression2531); 
            	        		ALL191_tree = (IASTNode)adaptor.Create(ALL191);
            	        		root_0 = (IASTNode)adaptor.BecomeRoot(ALL191_tree, root_0);


            	        }
            	        break;
            	    case 4 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:728:31: ANY
            	        {
            	        	ANY192=(IToken)Match(input,ANY,FOLLOW_ANY_in_quantifiedExpression2536); 
            	        		ANY192_tree = (IASTNode)adaptor.Create(ANY192);
            	        		root_0 = (IASTNode)adaptor.BecomeRoot(ANY192_tree, root_0);


            	        }
            	        break;

            	}

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:729:2: ( identifier | collectionExpr | ( OPEN ( subQuery ) CLOSE ) )
            	int alt63 = 3;
            	switch ( input.LA(1) ) 
            	{
            	case IDENT:
            		{
            	    alt63 = 1;
            	    }
            	    break;
            	case ELEMENTS:
            	case INDICES:
            		{
            	    alt63 = 2;
            	    }
            	    break;
            	case OPEN:
            		{
            	    alt63 = 3;
            	    }
            	    break;
            		default:
            		    NoViableAltException nvae_d63s0 =
            		        new NoViableAltException("", 63, 0, input);

            		    throw nvae_d63s0;
            	}

            	switch (alt63) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:729:4: identifier
            	        {
            	        	PushFollow(FOLLOW_identifier_in_quantifiedExpression2545);
            	        	identifier193 = identifier();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, identifier193.Tree);

            	        }
            	        break;
            	    case 2 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:729:17: collectionExpr
            	        {
            	        	PushFollow(FOLLOW_collectionExpr_in_quantifiedExpression2549);
            	        	collectionExpr194 = collectionExpr();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, collectionExpr194.Tree);

            	        }
            	        break;
            	    case 3 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:729:34: ( OPEN ( subQuery ) CLOSE )
            	        {
            	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:729:34: ( OPEN ( subQuery ) CLOSE )
            	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:729:35: OPEN ( subQuery ) CLOSE
            	        	{
            	        		OPEN195=(IToken)Match(input,OPEN,FOLLOW_OPEN_in_quantifiedExpression2554); 
            	        		// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:729:41: ( subQuery )
            	        		// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:729:43: subQuery
            	        		{
            	        			PushFollow(FOLLOW_subQuery_in_quantifiedExpression2559);
            	        			subQuery196 = subQuery();
            	        			state.followingStackPointer--;

            	        			adaptor.AddChild(root_0, subQuery196.Tree);

            	        		}

            	        		CLOSE197=(IToken)Match(input,CLOSE,FOLLOW_CLOSE_in_quantifiedExpression2563); 

            	        	}


            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "quantifiedExpression"

    public class atom_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "atom"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:747:1: atom : primaryExpression ( DOT identifier ( options {greedy=true; } : (op= OPEN exprList CLOSE ) )? | lb= OPEN_BRACKET expression CLOSE_BRACKET )* ;
    public HqlParser.atom_return atom() // throws RecognitionException [1]
    {   
        HqlParser.atom_return retval = new HqlParser.atom_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken op = null;
        IToken lb = null;
        IToken DOT199 = null;
        IToken CLOSE202 = null;
        IToken CLOSE_BRACKET204 = null;
        HqlParser.primaryExpression_return primaryExpression198 = default(HqlParser.primaryExpression_return);

        HqlParser.identifier_return identifier200 = default(HqlParser.identifier_return);

        HqlParser.exprList_return exprList201 = default(HqlParser.exprList_return);

        HqlParser.expression_return expression203 = default(HqlParser.expression_return);


        IASTNode op_tree=null;
        IASTNode lb_tree=null;
        IASTNode DOT199_tree=null;
        IASTNode CLOSE202_tree=null;
        IASTNode CLOSE_BRACKET204_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:748:3: ( primaryExpression ( DOT identifier ( options {greedy=true; } : (op= OPEN exprList CLOSE ) )? | lb= OPEN_BRACKET expression CLOSE_BRACKET )* )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:748:5: primaryExpression ( DOT identifier ( options {greedy=true; } : (op= OPEN exprList CLOSE ) )? | lb= OPEN_BRACKET expression CLOSE_BRACKET )*
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	PushFollow(FOLLOW_primaryExpression_in_atom2584);
            	primaryExpression198 = primaryExpression();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, primaryExpression198.Tree);
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:749:3: ( DOT identifier ( options {greedy=true; } : (op= OPEN exprList CLOSE ) )? | lb= OPEN_BRACKET expression CLOSE_BRACKET )*
            	do 
            	{
            	    int alt65 = 3;
            	    alt65 = dfa65.Predict(input);
            	    switch (alt65) 
            		{
            			case 1 :
            			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:750:4: DOT identifier ( options {greedy=true; } : (op= OPEN exprList CLOSE ) )?
            			    {
            			    	DOT199=(IToken)Match(input,DOT,FOLLOW_DOT_in_atom2593); 
            			    		DOT199_tree = (IASTNode)adaptor.Create(DOT199);
            			    		root_0 = (IASTNode)adaptor.BecomeRoot(DOT199_tree, root_0);

            			    	PushFollow(FOLLOW_identifier_in_atom2596);
            			    	identifier200 = identifier();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, identifier200.Tree);
            			    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:751:5: ( options {greedy=true; } : (op= OPEN exprList CLOSE ) )?
            			    	int alt64 = 2;
            			    	alt64 = dfa64.Predict(input);
            			    	switch (alt64) 
            			    	{
            			    	    case 1 :
            			    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:752:6: (op= OPEN exprList CLOSE )
            			    	        {
            			    	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:752:6: (op= OPEN exprList CLOSE )
            			    	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:752:8: op= OPEN exprList CLOSE
            			    	        	{
            			    	        		op=(IToken)Match(input,OPEN,FOLLOW_OPEN_in_atom2624); 
            			    	        			op_tree = (IASTNode)adaptor.Create(op);
            			    	        			root_0 = (IASTNode)adaptor.BecomeRoot(op_tree, root_0);

            			    	        		op.Type = METHOD_CALL; 
            			    	        		PushFollow(FOLLOW_exprList_in_atom2629);
            			    	        		exprList201 = exprList();
            			    	        		state.followingStackPointer--;

            			    	        		adaptor.AddChild(root_0, exprList201.Tree);
            			    	        		CLOSE202=(IToken)Match(input,CLOSE,FOLLOW_CLOSE_in_atom2631); 

            			    	        	}


            			    	        }
            			    	        break;

            			    	}


            			    }
            			    break;
            			case 2 :
            			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:753:5: lb= OPEN_BRACKET expression CLOSE_BRACKET
            			    {
            			    	lb=(IToken)Match(input,OPEN_BRACKET,FOLLOW_OPEN_BRACKET_in_atom2645); 
            			    		lb_tree = (IASTNode)adaptor.Create(lb);
            			    		root_0 = (IASTNode)adaptor.BecomeRoot(lb_tree, root_0);

            			    	lb.Type = INDEX_OP; 
            			    	PushFollow(FOLLOW_expression_in_atom2650);
            			    	expression203 = expression();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, expression203.Tree);
            			    	CLOSE_BRACKET204=(IToken)Match(input,CLOSE_BRACKET,FOLLOW_CLOSE_BRACKET_in_atom2652); 

            			    }
            			    break;

            			default:
            			    goto loop65;
            	    }
            	} while (true);

            	loop65:
            		;	// Stops C# compiler whining that label 'loop65' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "atom"

    public class primaryExpression_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "primaryExpression"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:758:1: primaryExpression : ( identPrimary ( options {greedy=true; } : DOT 'class' )? | constant | COLON identifier | OPEN ( expressionOrVector | subQuery ) CLOSE | PARAM ( NUM_INT )? );
    public HqlParser.primaryExpression_return primaryExpression() // throws RecognitionException [1]
    {   
        HqlParser.primaryExpression_return retval = new HqlParser.primaryExpression_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken DOT206 = null;
        IToken string_literal207 = null;
        IToken COLON209 = null;
        IToken OPEN211 = null;
        IToken CLOSE214 = null;
        IToken PARAM215 = null;
        IToken NUM_INT216 = null;
        HqlParser.identPrimary_return identPrimary205 = default(HqlParser.identPrimary_return);

        HqlParser.constant_return constant208 = default(HqlParser.constant_return);

        HqlParser.identifier_return identifier210 = default(HqlParser.identifier_return);

        HqlParser.expressionOrVector_return expressionOrVector212 = default(HqlParser.expressionOrVector_return);

        HqlParser.subQuery_return subQuery213 = default(HqlParser.subQuery_return);


        IASTNode DOT206_tree=null;
        IASTNode string_literal207_tree=null;
        IASTNode COLON209_tree=null;
        IASTNode OPEN211_tree=null;
        IASTNode CLOSE214_tree=null;
        IASTNode PARAM215_tree=null;
        IASTNode NUM_INT216_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:759:2: ( identPrimary ( options {greedy=true; } : DOT 'class' )? | constant | COLON identifier | OPEN ( expressionOrVector | subQuery ) CLOSE | PARAM ( NUM_INT )? )
            int alt69 = 5;
            alt69 = dfa69.Predict(input);
            switch (alt69) 
            {
                case 1 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:759:6: identPrimary ( options {greedy=true; } : DOT 'class' )?
                    {
                    	root_0 = (IASTNode)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_identPrimary_in_primaryExpression2672);
                    	identPrimary205 = identPrimary();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, identPrimary205.Tree);
                    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:759:19: ( options {greedy=true; } : DOT 'class' )?
                    	int alt66 = 2;
                    	alt66 = dfa66.Predict(input);
                    	switch (alt66) 
                    	{
                    	    case 1 :
                    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:759:46: DOT 'class'
                    	        {
                    	        	DOT206=(IToken)Match(input,DOT,FOLLOW_DOT_in_primaryExpression2685); 
                    	        		DOT206_tree = (IASTNode)adaptor.Create(DOT206);
                    	        		root_0 = (IASTNode)adaptor.BecomeRoot(DOT206_tree, root_0);

                    	        	string_literal207=(IToken)Match(input,CLASS,FOLLOW_CLASS_in_primaryExpression2688); 
                    	        		string_literal207_tree = (IASTNode)adaptor.Create(string_literal207);
                    	        		adaptor.AddChild(root_0, string_literal207_tree);


                    	        }
                    	        break;

                    	}


                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:760:6: constant
                    {
                    	root_0 = (IASTNode)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_constant_in_primaryExpression2698);
                    	constant208 = constant();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, constant208.Tree);

                    }
                    break;
                case 3 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:761:6: COLON identifier
                    {
                    	root_0 = (IASTNode)adaptor.GetNilNode();

                    	COLON209=(IToken)Match(input,COLON,FOLLOW_COLON_in_primaryExpression2705); 
                    		COLON209_tree = (IASTNode)adaptor.Create(COLON209);
                    		root_0 = (IASTNode)adaptor.BecomeRoot(COLON209_tree, root_0);

                    	PushFollow(FOLLOW_identifier_in_primaryExpression2708);
                    	identifier210 = identifier();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, identifier210.Tree);

                    }
                    break;
                case 4 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:763:6: OPEN ( expressionOrVector | subQuery ) CLOSE
                    {
                    	root_0 = (IASTNode)adaptor.GetNilNode();

                    	OPEN211=(IToken)Match(input,OPEN,FOLLOW_OPEN_in_primaryExpression2717); 
                    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:763:12: ( expressionOrVector | subQuery )
                    	int alt67 = 2;
                    	alt67 = dfa67.Predict(input);
                    	switch (alt67) 
                    	{
                    	    case 1 :
                    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:763:13: expressionOrVector
                    	        {
                    	        	PushFollow(FOLLOW_expressionOrVector_in_primaryExpression2721);
                    	        	expressionOrVector212 = expressionOrVector();
                    	        	state.followingStackPointer--;

                    	        	adaptor.AddChild(root_0, expressionOrVector212.Tree);

                    	        }
                    	        break;
                    	    case 2 :
                    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:763:34: subQuery
                    	        {
                    	        	PushFollow(FOLLOW_subQuery_in_primaryExpression2725);
                    	        	subQuery213 = subQuery();
                    	        	state.followingStackPointer--;

                    	        	adaptor.AddChild(root_0, subQuery213.Tree);

                    	        }
                    	        break;

                    	}

                    	CLOSE214=(IToken)Match(input,CLOSE,FOLLOW_CLOSE_in_primaryExpression2728); 

                    }
                    break;
                case 5 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:764:6: PARAM ( NUM_INT )?
                    {
                    	root_0 = (IASTNode)adaptor.GetNilNode();

                    	PARAM215=(IToken)Match(input,PARAM,FOLLOW_PARAM_in_primaryExpression2736); 
                    		PARAM215_tree = (IASTNode)adaptor.Create(PARAM215);
                    		root_0 = (IASTNode)adaptor.BecomeRoot(PARAM215_tree, root_0);

                    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:764:13: ( NUM_INT )?
                    	int alt68 = 2;
                    	alt68 = dfa68.Predict(input);
                    	switch (alt68) 
                    	{
                    	    case 1 :
                    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:764:14: NUM_INT
                    	        {
                    	        	NUM_INT216=(IToken)Match(input,NUM_INT,FOLLOW_NUM_INT_in_primaryExpression2740); 
                    	        		NUM_INT216_tree = (IASTNode)adaptor.Create(NUM_INT216);
                    	        		adaptor.AddChild(root_0, NUM_INT216_tree);


                    	        }
                    	        break;

                    	}


                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "primaryExpression"

    public class expressionOrVector_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "expressionOrVector"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:781:1: expressionOrVector : e= expression (v= vectorExpr )? -> {v != null}? ^( VECTOR_EXPR[\"vector\"] $e $v) -> ^( $e) ;
    public HqlParser.expressionOrVector_return expressionOrVector() // throws RecognitionException [1]
    {   
        HqlParser.expressionOrVector_return retval = new HqlParser.expressionOrVector_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        HqlParser.expression_return e = default(HqlParser.expression_return);

        HqlParser.vectorExpr_return v = default(HqlParser.vectorExpr_return);


        RewriteRuleSubtreeStream stream_vectorExpr = new RewriteRuleSubtreeStream(adaptor,"rule vectorExpr");
        RewriteRuleSubtreeStream stream_expression = new RewriteRuleSubtreeStream(adaptor,"rule expression");
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:782:2: (e= expression (v= vectorExpr )? -> {v != null}? ^( VECTOR_EXPR[\"vector\"] $e $v) -> ^( $e) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:782:4: e= expression (v= vectorExpr )?
            {
            	PushFollow(FOLLOW_expression_in_expressionOrVector2760);
            	e = expression();
            	state.followingStackPointer--;

            	stream_expression.Add(e.Tree);
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:782:17: (v= vectorExpr )?
            	int alt70 = 2;
            	int LA70_0 = input.LA(1);

            	if ( (LA70_0 == COMMA) )
            	{
            	    alt70 = 1;
            	}
            	switch (alt70) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:782:19: v= vectorExpr
            	        {
            	        	PushFollow(FOLLOW_vectorExpr_in_expressionOrVector2766);
            	        	v = vectorExpr();
            	        	state.followingStackPointer--;

            	        	stream_vectorExpr.Add(v.Tree);

            	        }
            	        break;

            	}



            	// AST REWRITE
            	// elements:          e, v, e
            	// token labels:      
            	// rule labels:       retval, v, e
            	// token list labels: 
            	// rule list labels:  
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));
            	RewriteRuleSubtreeStream stream_v = new RewriteRuleSubtreeStream(adaptor, "token v", (v!=null ? v.Tree : null));
            	RewriteRuleSubtreeStream stream_e = new RewriteRuleSubtreeStream(adaptor, "token e", (e!=null ? e.Tree : null));

            	root_0 = (IASTNode)adaptor.GetNilNode();
            	// 783:2: -> {v != null}? ^( VECTOR_EXPR[\"vector\"] $e $v)
            	if (v != null)
            	{
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:783:18: ^( VECTOR_EXPR[\"vector\"] $e $v)
            	    {
            	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
            	    root_1 = (IASTNode)adaptor.BecomeRoot((IASTNode)adaptor.Create(VECTOR_EXPR, "vector"), root_1);

            	    adaptor.AddChild(root_1, stream_e.NextTree());
            	    adaptor.AddChild(root_1, stream_v.NextTree());

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}
            	else // 784:2: -> ^( $e)
            	{
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:784:5: ^( $e)
            	    {
            	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
            	    root_1 = (IASTNode)adaptor.BecomeRoot(stream_e.NextNode(), root_1);

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;retval.Tree = root_0;
            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "expressionOrVector"

    public class vectorExpr_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "vectorExpr"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:787:1: vectorExpr : COMMA expression ( COMMA expression )* ;
    public HqlParser.vectorExpr_return vectorExpr() // throws RecognitionException [1]
    {   
        HqlParser.vectorExpr_return retval = new HqlParser.vectorExpr_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken COMMA217 = null;
        IToken COMMA219 = null;
        HqlParser.expression_return expression218 = default(HqlParser.expression_return);

        HqlParser.expression_return expression220 = default(HqlParser.expression_return);


        IASTNode COMMA217_tree=null;
        IASTNode COMMA219_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:788:2: ( COMMA expression ( COMMA expression )* )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:788:4: COMMA expression ( COMMA expression )*
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	COMMA217=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_vectorExpr2805); 
            	PushFollow(FOLLOW_expression_in_vectorExpr2808);
            	expression218 = expression();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, expression218.Tree);
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:788:22: ( COMMA expression )*
            	do 
            	{
            	    int alt71 = 2;
            	    int LA71_0 = input.LA(1);

            	    if ( (LA71_0 == COMMA) )
            	    {
            	        alt71 = 1;
            	    }


            	    switch (alt71) 
            		{
            			case 1 :
            			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:788:23: COMMA expression
            			    {
            			    	COMMA219=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_vectorExpr2811); 
            			    	PushFollow(FOLLOW_expression_in_vectorExpr2814);
            			    	expression220 = expression();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, expression220.Tree);

            			    }
            			    break;

            			default:
            			    goto loop71;
            	    }
            	} while (true);

            	loop71:
            		;	// Stops C# compiler whining that label 'loop71' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "vectorExpr"

    public class identPrimary_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "identPrimary"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:806:1: identPrimary : (id1= identifier ( options {greedy=true; } : d= DOT (id2= identifier | e= ELEMENTS | o= OBJECT ) )* ( options {greedy=true; } : opx= (op= OPEN exprList CLOSE ) )? -> {$opx != null && $id2.tree != null}? ^( METHOD_CALL[$op] ^( $d $id1 $id2) exprList ) -> {$opx != null && $e.tree != null}? ^( METHOD_CALL[$op] ^( $d $id1 $e) exprList ) -> {$opx != null}? ^( METHOD_CALL[$op] ^( $d $id1 ^( IDENT[$o] ) ) exprList ) -> {$id2.tree != null}? ^( $d $id1 $id2) -> {$e != null}? ^( $d $id1 $e) -> ^( $d $id1 ^( IDENT[$o] ) ) | aggregate );
    public HqlParser.identPrimary_return identPrimary() // throws RecognitionException [1]
    {   
        HqlParser.identPrimary_return retval = new HqlParser.identPrimary_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken d = null;
        IToken e = null;
        IToken o = null;
        IToken op = null;
        IToken opx = null;
        IToken CLOSE222 = null;
        HqlParser.identifier_return id1 = default(HqlParser.identifier_return);

        HqlParser.identifier_return id2 = default(HqlParser.identifier_return);

        HqlParser.exprList_return exprList221 = default(HqlParser.exprList_return);

        HqlParser.aggregate_return aggregate223 = default(HqlParser.aggregate_return);


        IASTNode d_tree=null;
        IASTNode e_tree=null;
        IASTNode o_tree=null;
        IASTNode op_tree=null;
        IASTNode opx_tree=null;
        IASTNode CLOSE222_tree=null;
        RewriteRuleTokenStream stream_CLOSE = new RewriteRuleTokenStream(adaptor,"token CLOSE");
        RewriteRuleTokenStream stream_ELEMENTS = new RewriteRuleTokenStream(adaptor,"token ELEMENTS");
        RewriteRuleTokenStream stream_OBJECT = new RewriteRuleTokenStream(adaptor,"token OBJECT");
        RewriteRuleTokenStream stream_OPEN = new RewriteRuleTokenStream(adaptor,"token OPEN");
        RewriteRuleTokenStream stream_DOT = new RewriteRuleTokenStream(adaptor,"token DOT");
        RewriteRuleSubtreeStream stream_identifier = new RewriteRuleSubtreeStream(adaptor,"rule identifier");
        RewriteRuleSubtreeStream stream_exprList = new RewriteRuleSubtreeStream(adaptor,"rule exprList");
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:807:2: (id1= identifier ( options {greedy=true; } : d= DOT (id2= identifier | e= ELEMENTS | o= OBJECT ) )* ( options {greedy=true; } : opx= (op= OPEN exprList CLOSE ) )? -> {$opx != null && $id2.tree != null}? ^( METHOD_CALL[$op] ^( $d $id1 $id2) exprList ) -> {$opx != null && $e.tree != null}? ^( METHOD_CALL[$op] ^( $d $id1 $e) exprList ) -> {$opx != null}? ^( METHOD_CALL[$op] ^( $d $id1 ^( IDENT[$o] ) ) exprList ) -> {$id2.tree != null}? ^( $d $id1 $id2) -> {$e != null}? ^( $d $id1 $e) -> ^( $d $id1 ^( IDENT[$o] ) ) | aggregate )
            int alt75 = 2;
            int LA75_0 = input.LA(1);

            if ( (LA75_0 == IDENT) )
            {
                alt75 = 1;
            }
            else if ( (LA75_0 == AVG || LA75_0 == COUNT || LA75_0 == ELEMENTS || LA75_0 == INDICES || (LA75_0 >= MAX && LA75_0 <= MIN) || LA75_0 == SUM) )
            {
                alt75 = 2;
            }
            else 
            {
                NoViableAltException nvae_d75s0 =
                    new NoViableAltException("", 75, 0, input);

                throw nvae_d75s0;
            }
            switch (alt75) 
            {
                case 1 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:807:4: id1= identifier ( options {greedy=true; } : d= DOT (id2= identifier | e= ELEMENTS | o= OBJECT ) )* ( options {greedy=true; } : opx= (op= OPEN exprList CLOSE ) )?
                    {
                    	PushFollow(FOLLOW_identifier_in_identPrimary2834);
                    	id1 = identifier();
                    	state.followingStackPointer--;

                    	stream_identifier.Add(id1.Tree);
                    	 HandleDotIdent(); 
                    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:808:4: ( options {greedy=true; } : d= DOT (id2= identifier | e= ELEMENTS | o= OBJECT ) )*
                    	do 
                    	{
                    	    int alt73 = 2;
                    	    alt73 = dfa73.Predict(input);
                    	    switch (alt73) 
                    		{
                    			case 1 :
                    			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:808:33: d= DOT (id2= identifier | e= ELEMENTS | o= OBJECT )
                    			    {
                    			    	d=(IToken)Match(input,DOT,FOLLOW_DOT_in_identPrimary2856);  
                    			    	stream_DOT.Add(d);

                    			    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:808:39: (id2= identifier | e= ELEMENTS | o= OBJECT )
                    			    	int alt72 = 3;
                    			    	switch ( input.LA(1) ) 
                    			    	{
                    			    	case IDENT:
                    			    		{
                    			    	    alt72 = 1;
                    			    	    }
                    			    	    break;
                    			    	case ELEMENTS:
                    			    		{
                    			    	    alt72 = 2;
                    			    	    }
                    			    	    break;
                    			    	case OBJECT:
                    			    		{
                    			    	    alt72 = 3;
                    			    	    }
                    			    	    break;
                    			    		default:
                    			    		    NoViableAltException nvae_d72s0 =
                    			    		        new NoViableAltException("", 72, 0, input);

                    			    		    throw nvae_d72s0;
                    			    	}

                    			    	switch (alt72) 
                    			    	{
                    			    	    case 1 :
                    			    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:809:7: id2= identifier
                    			    	        {
                    			    	        	PushFollow(FOLLOW_identifier_in_identPrimary2869);
                    			    	        	id2 = identifier();
                    			    	        	state.followingStackPointer--;

                    			    	        	stream_identifier.Add(id2.Tree);

                    			    	        }
                    			    	        break;
                    			    	    case 2 :
                    			    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:810:7: e= ELEMENTS
                    			    	        {
                    			    	        	e=(IToken)Match(input,ELEMENTS,FOLLOW_ELEMENTS_in_identPrimary2880);  
                    			    	        	stream_ELEMENTS.Add(e);


                    			    	        }
                    			    	        break;
                    			    	    case 3 :
                    			    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:811:7: o= OBJECT
                    			    	        {
                    			    	        	o=(IToken)Match(input,OBJECT,FOLLOW_OBJECT_in_identPrimary2891);  
                    			    	        	stream_OBJECT.Add(o);


                    			    	        }
                    			    	        break;

                    			    	}


                    			    }
                    			    break;

                    			default:
                    			    goto loop73;
                    	    }
                    	} while (true);

                    	loop73:
                    		;	// Stops C# compiler whining that label 'loop73' has no statements

                    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:813:4: ( options {greedy=true; } : opx= (op= OPEN exprList CLOSE ) )?
                    	int alt74 = 2;
                    	alt74 = dfa74.Predict(input);
                    	switch (alt74) 
                    	{
                    	    case 1 :
                    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:813:33: opx= (op= OPEN exprList CLOSE )
                    	        {
                    	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:813:39: (op= OPEN exprList CLOSE )
                    	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:813:41: op= OPEN exprList CLOSE
                    	        	{
                    	        		op=(IToken)Match(input,OPEN,FOLLOW_OPEN_in_identPrimary2927);  
                    	        		stream_OPEN.Add(op);

                    	        		PushFollow(FOLLOW_exprList_in_identPrimary2929);
                    	        		exprList221 = exprList();
                    	        		state.followingStackPointer--;

                    	        		stream_exprList.Add(exprList221.Tree);
                    	        		CLOSE222=(IToken)Match(input,CLOSE,FOLLOW_CLOSE_in_identPrimary2931);  
                    	        		stream_CLOSE.Add(CLOSE222);


                    	        	}


                    	        }
                    	        break;

                    	}



                    	// AST REWRITE
                    	// elements:          exprList, d, e, id1, d, d, id1, id1, e, id1, id2, id1, exprList, d, d, d, id1, exprList, id2
                    	// token labels:      d, e
                    	// rule labels:       id1, id2, retval
                    	// token list labels: 
                    	// rule list labels:  
                    	retval.Tree = root_0;
                    	RewriteRuleTokenStream stream_d = new RewriteRuleTokenStream(adaptor, "token d", d);
                    	RewriteRuleTokenStream stream_e = new RewriteRuleTokenStream(adaptor, "token e", e);
                    	RewriteRuleSubtreeStream stream_id1 = new RewriteRuleSubtreeStream(adaptor, "token id1", (id1!=null ? id1.Tree : null));
                    	RewriteRuleSubtreeStream stream_id2 = new RewriteRuleSubtreeStream(adaptor, "token id2", (id2!=null ? id2.Tree : null));
                    	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));

                    	root_0 = (IASTNode)adaptor.GetNilNode();
                    	// 814:3: -> {$opx != null && $id2.tree != null}? ^( METHOD_CALL[$op] ^( $d $id1 $id2) exprList )
                    	if (opx != null && ((id2 != null) ? ((IASTNode)id2.Tree) : null) != null)
                    	{
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:814:43: ^( METHOD_CALL[$op] ^( $d $id1 $id2) exprList )
                    	    {
                    	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
                    	    root_1 = (IASTNode)adaptor.BecomeRoot((IASTNode)adaptor.Create(METHOD_CALL, op), root_1);

                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:814:62: ^( $d $id1 $id2)
                    	    {
                    	    IASTNode root_2 = (IASTNode)adaptor.GetNilNode();
                    	    root_2 = (IASTNode)adaptor.BecomeRoot(stream_d.NextNode(), root_2);

                    	    adaptor.AddChild(root_2, stream_id1.NextTree());
                    	    adaptor.AddChild(root_2, stream_id2.NextTree());

                    	    adaptor.AddChild(root_1, root_2);
                    	    }
                    	    adaptor.AddChild(root_1, stream_exprList.NextTree());

                    	    adaptor.AddChild(root_0, root_1);
                    	    }

                    	}
                    	else // 815:3: -> {$opx != null && $e.tree != null}? ^( METHOD_CALL[$op] ^( $d $id1 $e) exprList )
                    	if (opx != null && e_tree != null)
                    	{
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:815:41: ^( METHOD_CALL[$op] ^( $d $id1 $e) exprList )
                    	    {
                    	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
                    	    root_1 = (IASTNode)adaptor.BecomeRoot((IASTNode)adaptor.Create(METHOD_CALL, op), root_1);

                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:815:60: ^( $d $id1 $e)
                    	    {
                    	    IASTNode root_2 = (IASTNode)adaptor.GetNilNode();
                    	    root_2 = (IASTNode)adaptor.BecomeRoot(stream_d.NextNode(), root_2);

                    	    adaptor.AddChild(root_2, stream_id1.NextTree());
                    	    adaptor.AddChild(root_2, stream_e.NextNode());

                    	    adaptor.AddChild(root_1, root_2);
                    	    }
                    	    adaptor.AddChild(root_1, stream_exprList.NextTree());

                    	    adaptor.AddChild(root_0, root_1);
                    	    }

                    	}
                    	else // 816:3: -> {$opx != null}? ^( METHOD_CALL[$op] ^( $d $id1 ^( IDENT[$o] ) ) exprList )
                    	if (opx != null)
                    	{
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:816:22: ^( METHOD_CALL[$op] ^( $d $id1 ^( IDENT[$o] ) ) exprList )
                    	    {
                    	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
                    	    root_1 = (IASTNode)adaptor.BecomeRoot((IASTNode)adaptor.Create(METHOD_CALL, op), root_1);

                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:816:41: ^( $d $id1 ^( IDENT[$o] ) )
                    	    {
                    	    IASTNode root_2 = (IASTNode)adaptor.GetNilNode();
                    	    root_2 = (IASTNode)adaptor.BecomeRoot(stream_d.NextNode(), root_2);

                    	    adaptor.AddChild(root_2, stream_id1.NextTree());
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:816:51: ^( IDENT[$o] )
                    	    {
                    	    IASTNode root_3 = (IASTNode)adaptor.GetNilNode();
                    	    root_3 = (IASTNode)adaptor.BecomeRoot((IASTNode)adaptor.Create(IDENT, o), root_3);

                    	    adaptor.AddChild(root_2, root_3);
                    	    }

                    	    adaptor.AddChild(root_1, root_2);
                    	    }
                    	    adaptor.AddChild(root_1, stream_exprList.NextTree());

                    	    adaptor.AddChild(root_0, root_1);
                    	    }

                    	}
                    	else // 817:3: -> {$id2.tree != null}? ^( $d $id1 $id2)
                    	if (((id2 != null) ? ((IASTNode)id2.Tree) : null) != null)
                    	{
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:817:27: ^( $d $id1 $id2)
                    	    {
                    	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
                    	    root_1 = (IASTNode)adaptor.BecomeRoot(stream_d.NextNode(), root_1);

                    	    adaptor.AddChild(root_1, stream_id1.NextTree());
                    	    adaptor.AddChild(root_1, stream_id2.NextTree());

                    	    adaptor.AddChild(root_0, root_1);
                    	    }

                    	}
                    	else // 818:3: -> {$e != null}? ^( $d $id1 $e)
                    	if (e != null)
                    	{
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:818:20: ^( $d $id1 $e)
                    	    {
                    	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
                    	    root_1 = (IASTNode)adaptor.BecomeRoot(stream_d.NextNode(), root_1);

                    	    adaptor.AddChild(root_1, stream_id1.NextTree());
                    	    adaptor.AddChild(root_1, stream_e.NextNode());

                    	    adaptor.AddChild(root_0, root_1);
                    	    }

                    	}
                    	else // 819:3: -> ^( $d $id1 ^( IDENT[$o] ) )
                    	{
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:819:6: ^( $d $id1 ^( IDENT[$o] ) )
                    	    {
                    	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
                    	    root_1 = (IASTNode)adaptor.BecomeRoot(stream_d.NextNode(), root_1);

                    	    adaptor.AddChild(root_1, stream_id1.NextTree());
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:819:16: ^( IDENT[$o] )
                    	    {
                    	    IASTNode root_2 = (IASTNode)adaptor.GetNilNode();
                    	    root_2 = (IASTNode)adaptor.BecomeRoot((IASTNode)adaptor.Create(IDENT, o), root_2);

                    	    adaptor.AddChild(root_1, root_2);
                    	    }

                    	    adaptor.AddChild(root_0, root_1);
                    	    }

                    	}

                    	retval.Tree = root_0;retval.Tree = root_0;
                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:821:4: aggregate
                    {
                    	root_0 = (IASTNode)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_aggregate_in_identPrimary3068);
                    	aggregate223 = aggregate();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, aggregate223.Tree);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "identPrimary"

    public class aggregate_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "aggregate"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:838:1: aggregate : (op= ( SUM | AVG | MAX | MIN ) OPEN additiveExpression CLOSE -> ^( AGGREGATE[$op] additiveExpression ) | COUNT OPEN (s= STAR | p= ( ( DISTINCT | ALL )? ( path | collectionExpr ) ) ) CLOSE -> {s == null}? ^( COUNT $p) -> ^( COUNT ^( ROW_STAR ) ) | collectionExpr );
    public HqlParser.aggregate_return aggregate() // throws RecognitionException [1]
    {   
        HqlParser.aggregate_return retval = new HqlParser.aggregate_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken op = null;
        IToken s = null;
        IToken p = null;
        IToken SUM224 = null;
        IToken AVG225 = null;
        IToken MAX226 = null;
        IToken MIN227 = null;
        IToken OPEN228 = null;
        IToken CLOSE230 = null;
        IToken COUNT231 = null;
        IToken OPEN232 = null;
        IToken DISTINCT233 = null;
        IToken ALL234 = null;
        IToken CLOSE237 = null;
        HqlParser.additiveExpression_return additiveExpression229 = default(HqlParser.additiveExpression_return);

        HqlParser.path_return path235 = default(HqlParser.path_return);

        HqlParser.collectionExpr_return collectionExpr236 = default(HqlParser.collectionExpr_return);

        HqlParser.collectionExpr_return collectionExpr238 = default(HqlParser.collectionExpr_return);


        IASTNode op_tree=null;
        IASTNode s_tree=null;
        IASTNode p_tree=null;
        IASTNode SUM224_tree=null;
        IASTNode AVG225_tree=null;
        IASTNode MAX226_tree=null;
        IASTNode MIN227_tree=null;
        IASTNode OPEN228_tree=null;
        IASTNode CLOSE230_tree=null;
        IASTNode COUNT231_tree=null;
        IASTNode OPEN232_tree=null;
        IASTNode DISTINCT233_tree=null;
        IASTNode ALL234_tree=null;
        IASTNode CLOSE237_tree=null;
        RewriteRuleTokenStream stream_CLOSE = new RewriteRuleTokenStream(adaptor,"token CLOSE");
        RewriteRuleTokenStream stream_DISTINCT = new RewriteRuleTokenStream(adaptor,"token DISTINCT");
        RewriteRuleTokenStream stream_AVG = new RewriteRuleTokenStream(adaptor,"token AVG");
        RewriteRuleTokenStream stream_MAX = new RewriteRuleTokenStream(adaptor,"token MAX");
        RewriteRuleTokenStream stream_MIN = new RewriteRuleTokenStream(adaptor,"token MIN");
        RewriteRuleTokenStream stream_STAR = new RewriteRuleTokenStream(adaptor,"token STAR");
        RewriteRuleTokenStream stream_ALL = new RewriteRuleTokenStream(adaptor,"token ALL");
        RewriteRuleTokenStream stream_SUM = new RewriteRuleTokenStream(adaptor,"token SUM");
        RewriteRuleTokenStream stream_OPEN = new RewriteRuleTokenStream(adaptor,"token OPEN");
        RewriteRuleTokenStream stream_COUNT = new RewriteRuleTokenStream(adaptor,"token COUNT");
        RewriteRuleSubtreeStream stream_collectionExpr = new RewriteRuleSubtreeStream(adaptor,"rule collectionExpr");
        RewriteRuleSubtreeStream stream_additiveExpression = new RewriteRuleSubtreeStream(adaptor,"rule additiveExpression");
        RewriteRuleSubtreeStream stream_path = new RewriteRuleSubtreeStream(adaptor,"rule path");
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:839:2: (op= ( SUM | AVG | MAX | MIN ) OPEN additiveExpression CLOSE -> ^( AGGREGATE[$op] additiveExpression ) | COUNT OPEN (s= STAR | p= ( ( DISTINCT | ALL )? ( path | collectionExpr ) ) ) CLOSE -> {s == null}? ^( COUNT $p) -> ^( COUNT ^( ROW_STAR ) ) | collectionExpr )
            int alt80 = 3;
            switch ( input.LA(1) ) 
            {
            case AVG:
            case MAX:
            case MIN:
            case SUM:
            	{
                alt80 = 1;
                }
                break;
            case COUNT:
            	{
                alt80 = 2;
                }
                break;
            case ELEMENTS:
            case INDICES:
            	{
                alt80 = 3;
                }
                break;
            	default:
            	    NoViableAltException nvae_d80s0 =
            	        new NoViableAltException("", 80, 0, input);

            	    throw nvae_d80s0;
            }

            switch (alt80) 
            {
                case 1 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:839:4: op= ( SUM | AVG | MAX | MIN ) OPEN additiveExpression CLOSE
                    {
                    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:839:7: ( SUM | AVG | MAX | MIN )
                    	int alt76 = 4;
                    	switch ( input.LA(1) ) 
                    	{
                    	case SUM:
                    		{
                    	    alt76 = 1;
                    	    }
                    	    break;
                    	case AVG:
                    		{
                    	    alt76 = 2;
                    	    }
                    	    break;
                    	case MAX:
                    		{
                    	    alt76 = 3;
                    	    }
                    	    break;
                    	case MIN:
                    		{
                    	    alt76 = 4;
                    	    }
                    	    break;
                    		default:
                    		    NoViableAltException nvae_d76s0 =
                    		        new NoViableAltException("", 76, 0, input);

                    		    throw nvae_d76s0;
                    	}

                    	switch (alt76) 
                    	{
                    	    case 1 :
                    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:839:9: SUM
                    	        {
                    	        	SUM224=(IToken)Match(input,SUM,FOLLOW_SUM_in_aggregate3090);  
                    	        	stream_SUM.Add(SUM224);


                    	        }
                    	        break;
                    	    case 2 :
                    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:839:15: AVG
                    	        {
                    	        	AVG225=(IToken)Match(input,AVG,FOLLOW_AVG_in_aggregate3094);  
                    	        	stream_AVG.Add(AVG225);


                    	        }
                    	        break;
                    	    case 3 :
                    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:839:21: MAX
                    	        {
                    	        	MAX226=(IToken)Match(input,MAX,FOLLOW_MAX_in_aggregate3098);  
                    	        	stream_MAX.Add(MAX226);


                    	        }
                    	        break;
                    	    case 4 :
                    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:839:27: MIN
                    	        {
                    	        	MIN227=(IToken)Match(input,MIN,FOLLOW_MIN_in_aggregate3102);  
                    	        	stream_MIN.Add(MIN227);


                    	        }
                    	        break;

                    	}

                    	OPEN228=(IToken)Match(input,OPEN,FOLLOW_OPEN_in_aggregate3106);  
                    	stream_OPEN.Add(OPEN228);

                    	PushFollow(FOLLOW_additiveExpression_in_aggregate3108);
                    	additiveExpression229 = additiveExpression();
                    	state.followingStackPointer--;

                    	stream_additiveExpression.Add(additiveExpression229.Tree);
                    	CLOSE230=(IToken)Match(input,CLOSE,FOLLOW_CLOSE_in_aggregate3110);  
                    	stream_CLOSE.Add(CLOSE230);



                    	// AST REWRITE
                    	// elements:          additiveExpression
                    	// token labels:      
                    	// rule labels:       retval
                    	// token list labels: 
                    	// rule list labels:  
                    	retval.Tree = root_0;
                    	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));

                    	root_0 = (IASTNode)adaptor.GetNilNode();
                    	// 840:3: -> ^( AGGREGATE[$op] additiveExpression )
                    	{
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:840:6: ^( AGGREGATE[$op] additiveExpression )
                    	    {
                    	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
                    	    root_1 = (IASTNode)adaptor.BecomeRoot((IASTNode)adaptor.Create(AGGREGATE, op), root_1);

                    	    adaptor.AddChild(root_1, stream_additiveExpression.NextTree());

                    	    adaptor.AddChild(root_0, root_1);
                    	    }

                    	}

                    	retval.Tree = root_0;retval.Tree = root_0;
                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:842:5: COUNT OPEN (s= STAR | p= ( ( DISTINCT | ALL )? ( path | collectionExpr ) ) ) CLOSE
                    {
                    	COUNT231=(IToken)Match(input,COUNT,FOLLOW_COUNT_in_aggregate3129);  
                    	stream_COUNT.Add(COUNT231);

                    	OPEN232=(IToken)Match(input,OPEN,FOLLOW_OPEN_in_aggregate3131);  
                    	stream_OPEN.Add(OPEN232);

                    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:842:16: (s= STAR | p= ( ( DISTINCT | ALL )? ( path | collectionExpr ) ) )
                    	int alt79 = 2;
                    	int LA79_0 = input.LA(1);

                    	if ( (LA79_0 == STAR) )
                    	{
                    	    alt79 = 1;
                    	}
                    	else if ( (LA79_0 == ALL || (LA79_0 >= DISTINCT && LA79_0 <= ELEMENTS) || LA79_0 == INDICES || LA79_0 == IDENT) )
                    	{
                    	    alt79 = 2;
                    	}
                    	else 
                    	{
                    	    NoViableAltException nvae_d79s0 =
                    	        new NoViableAltException("", 79, 0, input);

                    	    throw nvae_d79s0;
                    	}
                    	switch (alt79) 
                    	{
                    	    case 1 :
                    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:842:18: s= STAR
                    	        {
                    	        	s=(IToken)Match(input,STAR,FOLLOW_STAR_in_aggregate3137);  
                    	        	stream_STAR.Add(s);


                    	        }
                    	        break;
                    	    case 2 :
                    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:842:27: p= ( ( DISTINCT | ALL )? ( path | collectionExpr ) )
                    	        {
                    	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:842:29: ( ( DISTINCT | ALL )? ( path | collectionExpr ) )
                    	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:842:31: ( DISTINCT | ALL )? ( path | collectionExpr )
                    	        	{
                    	        		// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:842:31: ( DISTINCT | ALL )?
                    	        		int alt77 = 3;
                    	        		int LA77_0 = input.LA(1);

                    	        		if ( (LA77_0 == DISTINCT) )
                    	        		{
                    	        		    alt77 = 1;
                    	        		}
                    	        		else if ( (LA77_0 == ALL) )
                    	        		{
                    	        		    alt77 = 2;
                    	        		}
                    	        		switch (alt77) 
                    	        		{
                    	        		    case 1 :
                    	        		        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:842:33: DISTINCT
                    	        		        {
                    	        		        	DISTINCT233=(IToken)Match(input,DISTINCT,FOLLOW_DISTINCT_in_aggregate3147);  
                    	        		        	stream_DISTINCT.Add(DISTINCT233);


                    	        		        }
                    	        		        break;
                    	        		    case 2 :
                    	        		        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:842:44: ALL
                    	        		        {
                    	        		        	ALL234=(IToken)Match(input,ALL,FOLLOW_ALL_in_aggregate3151);  
                    	        		        	stream_ALL.Add(ALL234);


                    	        		        }
                    	        		        break;

                    	        		}

                    	        		// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:842:51: ( path | collectionExpr )
                    	        		int alt78 = 2;
                    	        		int LA78_0 = input.LA(1);

                    	        		if ( (LA78_0 == IDENT) )
                    	        		{
                    	        		    alt78 = 1;
                    	        		}
                    	        		else if ( (LA78_0 == ELEMENTS || LA78_0 == INDICES) )
                    	        		{
                    	        		    alt78 = 2;
                    	        		}
                    	        		else 
                    	        		{
                    	        		    NoViableAltException nvae_d78s0 =
                    	        		        new NoViableAltException("", 78, 0, input);

                    	        		    throw nvae_d78s0;
                    	        		}
                    	        		switch (alt78) 
                    	        		{
                    	        		    case 1 :
                    	        		        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:842:53: path
                    	        		        {
                    	        		        	PushFollow(FOLLOW_path_in_aggregate3158);
                    	        		        	path235 = path();
                    	        		        	state.followingStackPointer--;

                    	        		        	stream_path.Add(path235.Tree);

                    	        		        }
                    	        		        break;
                    	        		    case 2 :
                    	        		        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:842:60: collectionExpr
                    	        		        {
                    	        		        	PushFollow(FOLLOW_collectionExpr_in_aggregate3162);
                    	        		        	collectionExpr236 = collectionExpr();
                    	        		        	state.followingStackPointer--;

                    	        		        	stream_collectionExpr.Add(collectionExpr236.Tree);

                    	        		        }
                    	        		        break;

                    	        		}


                    	        	}


                    	        }
                    	        break;

                    	}

                    	CLOSE237=(IToken)Match(input,CLOSE,FOLLOW_CLOSE_in_aggregate3170);  
                    	stream_CLOSE.Add(CLOSE237);



                    	// AST REWRITE
                    	// elements:          p, COUNT, COUNT
                    	// token labels:      p
                    	// rule labels:       retval
                    	// token list labels: 
                    	// rule list labels:  
                    	retval.Tree = root_0;
                    	RewriteRuleTokenStream stream_p = new RewriteRuleTokenStream(adaptor, "token p", p);
                    	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));

                    	root_0 = (IASTNode)adaptor.GetNilNode();
                    	// 843:3: -> {s == null}? ^( COUNT $p)
                    	if (s == null)
                    	{
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:843:19: ^( COUNT $p)
                    	    {
                    	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
                    	    root_1 = (IASTNode)adaptor.BecomeRoot(stream_COUNT.NextNode(), root_1);

                    	    adaptor.AddChild(root_1, stream_p.NextNode());

                    	    adaptor.AddChild(root_0, root_1);
                    	    }

                    	}
                    	else // 844:3: -> ^( COUNT ^( ROW_STAR ) )
                    	{
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:844:6: ^( COUNT ^( ROW_STAR ) )
                    	    {
                    	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
                    	    root_1 = (IASTNode)adaptor.BecomeRoot(stream_COUNT.NextNode(), root_1);

                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:844:14: ^( ROW_STAR )
                    	    {
                    	    IASTNode root_2 = (IASTNode)adaptor.GetNilNode();
                    	    root_2 = (IASTNode)adaptor.BecomeRoot((IASTNode)adaptor.Create(ROW_STAR, "ROW_STAR"), root_2);

                    	    adaptor.AddChild(root_1, root_2);
                    	    }

                    	    adaptor.AddChild(root_0, root_1);
                    	    }

                    	}

                    	retval.Tree = root_0;retval.Tree = root_0;
                    }
                    break;
                case 3 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:845:5: collectionExpr
                    {
                    	root_0 = (IASTNode)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_collectionExpr_in_aggregate3201);
                    	collectionExpr238 = collectionExpr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, collectionExpr238.Tree);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "aggregate"

    public class collectionExpr_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "collectionExpr"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:850:1: collectionExpr : ( ELEMENTS | INDICES ) OPEN path CLOSE ;
    public HqlParser.collectionExpr_return collectionExpr() // throws RecognitionException [1]
    {   
        HqlParser.collectionExpr_return retval = new HqlParser.collectionExpr_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken ELEMENTS239 = null;
        IToken INDICES240 = null;
        IToken OPEN241 = null;
        IToken CLOSE243 = null;
        HqlParser.path_return path242 = default(HqlParser.path_return);


        IASTNode ELEMENTS239_tree=null;
        IASTNode INDICES240_tree=null;
        IASTNode OPEN241_tree=null;
        IASTNode CLOSE243_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:851:2: ( ( ELEMENTS | INDICES ) OPEN path CLOSE )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:851:4: ( ELEMENTS | INDICES ) OPEN path CLOSE
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:851:4: ( ELEMENTS | INDICES )
            	int alt81 = 2;
            	int LA81_0 = input.LA(1);

            	if ( (LA81_0 == ELEMENTS) )
            	{
            	    alt81 = 1;
            	}
            	else if ( (LA81_0 == INDICES) )
            	{
            	    alt81 = 2;
            	}
            	else 
            	{
            	    NoViableAltException nvae_d81s0 =
            	        new NoViableAltException("", 81, 0, input);

            	    throw nvae_d81s0;
            	}
            	switch (alt81) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:851:5: ELEMENTS
            	        {
            	        	ELEMENTS239=(IToken)Match(input,ELEMENTS,FOLLOW_ELEMENTS_in_collectionExpr3215); 
            	        		ELEMENTS239_tree = (IASTNode)adaptor.Create(ELEMENTS239);
            	        		root_0 = (IASTNode)adaptor.BecomeRoot(ELEMENTS239_tree, root_0);


            	        }
            	        break;
            	    case 2 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:851:17: INDICES
            	        {
            	        	INDICES240=(IToken)Match(input,INDICES,FOLLOW_INDICES_in_collectionExpr3220); 
            	        		INDICES240_tree = (IASTNode)adaptor.Create(INDICES240);
            	        		root_0 = (IASTNode)adaptor.BecomeRoot(INDICES240_tree, root_0);


            	        }
            	        break;

            	}

            	OPEN241=(IToken)Match(input,OPEN,FOLLOW_OPEN_in_collectionExpr3224); 
            	PushFollow(FOLLOW_path_in_collectionExpr3227);
            	path242 = path();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, path242.Tree);
            	CLOSE243=(IToken)Match(input,CLOSE,FOLLOW_CLOSE_in_collectionExpr3229); 

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "collectionExpr"

    public class compoundExpr_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "compoundExpr"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:855:1: compoundExpr : ( collectionExpr | path | ( OPEN ( ( expression ( COMMA expression )* ) | subQuery ) CLOSE ) );
    public HqlParser.compoundExpr_return compoundExpr() // throws RecognitionException [1]
    {   
        HqlParser.compoundExpr_return retval = new HqlParser.compoundExpr_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken OPEN246 = null;
        IToken COMMA248 = null;
        IToken CLOSE251 = null;
        HqlParser.collectionExpr_return collectionExpr244 = default(HqlParser.collectionExpr_return);

        HqlParser.path_return path245 = default(HqlParser.path_return);

        HqlParser.expression_return expression247 = default(HqlParser.expression_return);

        HqlParser.expression_return expression249 = default(HqlParser.expression_return);

        HqlParser.subQuery_return subQuery250 = default(HqlParser.subQuery_return);


        IASTNode OPEN246_tree=null;
        IASTNode COMMA248_tree=null;
        IASTNode CLOSE251_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:856:2: ( collectionExpr | path | ( OPEN ( ( expression ( COMMA expression )* ) | subQuery ) CLOSE ) )
            int alt84 = 3;
            switch ( input.LA(1) ) 
            {
            case ELEMENTS:
            case INDICES:
            	{
                alt84 = 1;
                }
                break;
            case IDENT:
            	{
                alt84 = 2;
                }
                break;
            case OPEN:
            	{
                alt84 = 3;
                }
                break;
            	default:
            	    NoViableAltException nvae_d84s0 =
            	        new NoViableAltException("", 84, 0, input);

            	    throw nvae_d84s0;
            }

            switch (alt84) 
            {
                case 1 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:856:4: collectionExpr
                    {
                    	root_0 = (IASTNode)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_collectionExpr_in_compoundExpr3285);
                    	collectionExpr244 = collectionExpr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, collectionExpr244.Tree);

                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:857:4: path
                    {
                    	root_0 = (IASTNode)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_path_in_compoundExpr3290);
                    	path245 = path();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, path245.Tree);

                    }
                    break;
                case 3 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:858:4: ( OPEN ( ( expression ( COMMA expression )* ) | subQuery ) CLOSE )
                    {
                    	root_0 = (IASTNode)adaptor.GetNilNode();

                    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:858:4: ( OPEN ( ( expression ( COMMA expression )* ) | subQuery ) CLOSE )
                    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:858:5: OPEN ( ( expression ( COMMA expression )* ) | subQuery ) CLOSE
                    	{
                    		OPEN246=(IToken)Match(input,OPEN,FOLLOW_OPEN_in_compoundExpr3296); 
                    		// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:858:11: ( ( expression ( COMMA expression )* ) | subQuery )
                    		int alt83 = 2;
                    		alt83 = dfa83.Predict(input);
                    		switch (alt83) 
                    		{
                    		    case 1 :
                    		        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:858:13: ( expression ( COMMA expression )* )
                    		        {
                    		        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:858:13: ( expression ( COMMA expression )* )
                    		        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:858:14: expression ( COMMA expression )*
                    		        	{
                    		        		PushFollow(FOLLOW_expression_in_compoundExpr3302);
                    		        		expression247 = expression();
                    		        		state.followingStackPointer--;

                    		        		adaptor.AddChild(root_0, expression247.Tree);
                    		        		// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:858:25: ( COMMA expression )*
                    		        		do 
                    		        		{
                    		        		    int alt82 = 2;
                    		        		    int LA82_0 = input.LA(1);

                    		        		    if ( (LA82_0 == COMMA) )
                    		        		    {
                    		        		        alt82 = 1;
                    		        		    }


                    		        		    switch (alt82) 
                    		        			{
                    		        				case 1 :
                    		        				    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:858:26: COMMA expression
                    		        				    {
                    		        				    	COMMA248=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_compoundExpr3305); 
                    		        				    	PushFollow(FOLLOW_expression_in_compoundExpr3308);
                    		        				    	expression249 = expression();
                    		        				    	state.followingStackPointer--;

                    		        				    	adaptor.AddChild(root_0, expression249.Tree);

                    		        				    }
                    		        				    break;

                    		        				default:
                    		        				    goto loop82;
                    		        		    }
                    		        		} while (true);

                    		        		loop82:
                    		        			;	// Stops C# compiler whining that label 'loop82' has no statements


                    		        	}


                    		        }
                    		        break;
                    		    case 2 :
                    		        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:858:49: subQuery
                    		        {
                    		        	PushFollow(FOLLOW_subQuery_in_compoundExpr3315);
                    		        	subQuery250 = subQuery();
                    		        	state.followingStackPointer--;

                    		        	adaptor.AddChild(root_0, subQuery250.Tree);

                    		        }
                    		        break;

                    		}

                    		CLOSE251=(IToken)Match(input,CLOSE,FOLLOW_CLOSE_in_compoundExpr3319); 

                    	}


                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "compoundExpr"

    public class subQuery_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "subQuery"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:868:1: subQuery : union -> ^( QUERY $subQuery) ;
    public HqlParser.subQuery_return subQuery() // throws RecognitionException [1]
    {   
        HqlParser.subQuery_return retval = new HqlParser.subQuery_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        HqlParser.union_return union252 = default(HqlParser.union_return);


        RewriteRuleSubtreeStream stream_union = new RewriteRuleSubtreeStream(adaptor,"rule union");
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:869:2: ( union -> ^( QUERY $subQuery) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:869:4: union
            {
            	PushFollow(FOLLOW_union_in_subQuery3334);
            	union252 = union();
            	state.followingStackPointer--;

            	stream_union.Add(union252.Tree);


            	// AST REWRITE
            	// elements:          subQuery
            	// token labels:      
            	// rule labels:       retval
            	// token list labels: 
            	// rule list labels:  
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));

            	root_0 = (IASTNode)adaptor.GetNilNode();
            	// 870:2: -> ^( QUERY $subQuery)
            	{
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:870:5: ^( QUERY $subQuery)
            	    {
            	    IASTNode root_1 = (IASTNode)adaptor.GetNilNode();
            	    root_1 = (IASTNode)adaptor.BecomeRoot((IASTNode)adaptor.Create(QUERY, "QUERY"), root_1);

            	    adaptor.AddChild(root_1, stream_retval.NextTree());

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;retval.Tree = root_0;
            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "subQuery"

    public class exprList_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "exprList"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:888:1: exprList : (ts= ( TRAILING | LEADING | BOTH ) )? (r= ( expression ( ( COMMA expression )+ | FROM expression | AS identifier )? | FROM expression ) )? ;
    public HqlParser.exprList_return exprList() // throws RecognitionException [1]
    {   
        HqlParser.exprList_return retval = new HqlParser.exprList_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken ts = null;
        IToken r = null;
        IToken COMMA254 = null;
        IToken FROM256 = null;
        IToken AS258 = null;
        IToken FROM260 = null;
        HqlParser.expression_return expression253 = default(HqlParser.expression_return);

        HqlParser.expression_return expression255 = default(HqlParser.expression_return);

        HqlParser.expression_return expression257 = default(HqlParser.expression_return);

        HqlParser.identifier_return identifier259 = default(HqlParser.identifier_return);

        HqlParser.expression_return expression261 = default(HqlParser.expression_return);


        IASTNode ts_tree=null;
        IASTNode r_tree=null;
        IASTNode COMMA254_tree=null;
        IASTNode FROM256_tree=null;
        IASTNode AS258_tree=null;
        IASTNode FROM260_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:889:2: ( (ts= ( TRAILING | LEADING | BOTH ) )? (r= ( expression ( ( COMMA expression )+ | FROM expression | AS identifier )? | FROM expression ) )? )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:889:4: (ts= ( TRAILING | LEADING | BOTH ) )? (r= ( expression ( ( COMMA expression )+ | FROM expression | AS identifier )? | FROM expression ) )?
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:889:6: (ts= ( TRAILING | LEADING | BOTH ) )?
            	int alt85 = 2;
            	alt85 = dfa85.Predict(input);
            	switch (alt85) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:889:6: ts= ( TRAILING | LEADING | BOTH )
            	        {
            	        	ts = (IToken)input.LT(1);
            	        	if ( input.LA(1) == BOTH || input.LA(1) == LEADING || input.LA(1) == TRAILING ) 
            	        	{
            	        	    input.Consume();
            	        	    adaptor.AddChild(root_0, (IASTNode)adaptor.Create(ts));
            	        	    state.errorRecovery = false;
            	        	}
            	        	else 
            	        	{
            	        	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	        	    throw mse;
            	        	}


            	        }
            	        break;

            	}

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:893:5: (r= ( expression ( ( COMMA expression )+ | FROM expression | AS identifier )? | FROM expression ) )?
            	int alt89 = 2;
            	alt89 = dfa89.Predict(input);
            	switch (alt89) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:893:5: r= ( expression ( ( COMMA expression )+ | FROM expression | AS identifier )? | FROM expression )
            	        {
            	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:893:6: ( expression ( ( COMMA expression )+ | FROM expression | AS identifier )? | FROM expression )
            	        	int alt88 = 2;
            	        	alt88 = dfa88.Predict(input);
            	        	switch (alt88) 
            	        	{
            	        	    case 1 :
            	        	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:894:5: expression ( ( COMMA expression )+ | FROM expression | AS identifier )?
            	        	        {
            	        	        	PushFollow(FOLLOW_expression_in_exprList3406);
            	        	        	expression253 = expression();
            	        	        	state.followingStackPointer--;

            	        	        	adaptor.AddChild(root_0, expression253.Tree);
            	        	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:894:16: ( ( COMMA expression )+ | FROM expression | AS identifier )?
            	        	        	int alt87 = 4;
            	        	        	switch ( input.LA(1) ) 
            	        	        	{
            	        	        	    case COMMA:
            	        	        	    	{
            	        	        	        alt87 = 1;
            	        	        	        }
            	        	        	        break;
            	        	        	    case FROM:
            	        	        	    	{
            	        	        	        alt87 = 2;
            	        	        	        }
            	        	        	        break;
            	        	        	    case AS:
            	        	        	    	{
            	        	        	        alt87 = 3;
            	        	        	        }
            	        	        	        break;
            	        	        	}

            	        	        	switch (alt87) 
            	        	        	{
            	        	        	    case 1 :
            	        	        	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:894:18: ( COMMA expression )+
            	        	        	        {
            	        	        	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:894:18: ( COMMA expression )+
            	        	        	        	int cnt86 = 0;
            	        	        	        	do 
            	        	        	        	{
            	        	        	        	    int alt86 = 2;
            	        	        	        	    int LA86_0 = input.LA(1);

            	        	        	        	    if ( (LA86_0 == COMMA) )
            	        	        	        	    {
            	        	        	        	        alt86 = 1;
            	        	        	        	    }


            	        	        	        	    switch (alt86) 
            	        	        	        		{
            	        	        	        			case 1 :
            	        	        	        			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:894:19: COMMA expression
            	        	        	        			    {
            	        	        	        			    	COMMA254=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_exprList3411); 
            	        	        	        			    		COMMA254_tree = (IASTNode)adaptor.Create(COMMA254);
            	        	        	        			    		adaptor.AddChild(root_0, COMMA254_tree);

            	        	        	        			    	PushFollow(FOLLOW_expression_in_exprList3413);
            	        	        	        			    	expression255 = expression();
            	        	        	        			    	state.followingStackPointer--;

            	        	        	        			    	adaptor.AddChild(root_0, expression255.Tree);

            	        	        	        			    }
            	        	        	        			    break;

            	        	        	        			default:
            	        	        	        			    if ( cnt86 >= 1 ) goto loop86;
            	        	        	        		            EarlyExitException eee =
            	        	        	        		                new EarlyExitException(86, input);
            	        	        	        		            throw eee;
            	        	        	        	    }
            	        	        	        	    cnt86++;
            	        	        	        	} while (true);

            	        	        	        	loop86:
            	        	        	        		;	// Stops C# compiler whinging that label 'loop86' has no statements


            	        	        	        }
            	        	        	        break;
            	        	        	    case 2 :
            	        	        	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:895:9: FROM expression
            	        	        	        {
            	        	        	        	FROM256=(IToken)Match(input,FROM,FOLLOW_FROM_in_exprList3426); 
            	        	        	        		FROM256_tree = (IASTNode)adaptor.Create(FROM256);
            	        	        	        		adaptor.AddChild(root_0, FROM256_tree);

            	        	        	        	PushFollow(FOLLOW_expression_in_exprList3428);
            	        	        	        	expression257 = expression();
            	        	        	        	state.followingStackPointer--;

            	        	        	        	adaptor.AddChild(root_0, expression257.Tree);

            	        	        	        }
            	        	        	        break;
            	        	        	    case 3 :
            	        	        	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:896:9: AS identifier
            	        	        	        {
            	        	        	        	AS258=(IToken)Match(input,AS,FOLLOW_AS_in_exprList3439); 
            	        	        	        		AS258_tree = (IASTNode)adaptor.Create(AS258);
            	        	        	        		adaptor.AddChild(root_0, AS258_tree);

            	        	        	        	PushFollow(FOLLOW_identifier_in_exprList3441);
            	        	        	        	identifier259 = identifier();
            	        	        	        	state.followingStackPointer--;

            	        	        	        	adaptor.AddChild(root_0, identifier259.Tree);

            	        	        	        }
            	        	        	        break;

            	        	        	}


            	        	        }
            	        	        break;
            	        	    case 2 :
            	        	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:897:7: FROM expression
            	        	        {
            	        	        	FROM260=(IToken)Match(input,FROM,FOLLOW_FROM_in_exprList3453); 
            	        	        		FROM260_tree = (IASTNode)adaptor.Create(FROM260);
            	        	        		adaptor.AddChild(root_0, FROM260_tree);

            	        	        	PushFollow(FOLLOW_expression_in_exprList3455);
            	        	        	expression261 = expression();
            	        	        	state.followingStackPointer--;

            	        	        	adaptor.AddChild(root_0, expression261.Tree);

            	        	        }
            	        	        break;

            	        	}


            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "exprList"

    public class constant_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "constant"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:901:1: constant : ( NUM_INT | NUM_FLOAT | NUM_LONG | NUM_DOUBLE | QUOTED_String | NULL | TRUE | FALSE | EMPTY );
    public HqlParser.constant_return constant() // throws RecognitionException [1]
    {   
        HqlParser.constant_return retval = new HqlParser.constant_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken set262 = null;

        IASTNode set262_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:902:2: ( NUM_INT | NUM_FLOAT | NUM_LONG | NUM_DOUBLE | QUOTED_String | NULL | TRUE | FALSE | EMPTY )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	set262 = (IToken)input.LT(1);
            	if ( input.LA(1) == FALSE || input.LA(1) == NULL || input.LA(1) == TRUE || input.LA(1) == EMPTY || (input.LA(1) >= NUM_INT && input.LA(1) <= NUM_LONG) || input.LA(1) == QUOTED_String ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (IASTNode)adaptor.Create(set262));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "constant"

    public class path_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "path"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:919:1: path : identifier ( DOT identifier )* ;
    public HqlParser.path_return path() // throws RecognitionException [1]
    {   
        HqlParser.path_return retval = new HqlParser.path_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken DOT264 = null;
        HqlParser.identifier_return identifier263 = default(HqlParser.identifier_return);

        HqlParser.identifier_return identifier265 = default(HqlParser.identifier_return);


        IASTNode DOT264_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:920:2: ( identifier ( DOT identifier )* )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:920:4: identifier ( DOT identifier )*
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	PushFollow(FOLLOW_identifier_in_path3529);
            	identifier263 = identifier();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, identifier263.Tree);
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:920:15: ( DOT identifier )*
            	do 
            	{
            	    int alt90 = 2;
            	    alt90 = dfa90.Predict(input);
            	    switch (alt90) 
            		{
            			case 1 :
            			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:920:17: DOT identifier
            			    {
            			    	DOT264=(IToken)Match(input,DOT,FOLLOW_DOT_in_path3533); 
            			    		DOT264_tree = (IASTNode)adaptor.Create(DOT264);
            			    		root_0 = (IASTNode)adaptor.BecomeRoot(DOT264_tree, root_0);

            			    	 WeakKeywords(); 
            			    	PushFollow(FOLLOW_identifier_in_path3538);
            			    	identifier265 = identifier();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, identifier265.Tree);

            			    }
            			    break;

            			default:
            			    goto loop90;
            	    }
            	} while (true);

            	loop90:
            		;	// Stops C# compiler whining that label 'loop90' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (IASTNode)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "path"

    public class identifier_return : ParserRuleReturnScope
    {
        private IASTNode tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (IASTNode) value; }
        }
    };

    // $ANTLR start "identifier"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:925:1: identifier : IDENT ;
    public HqlParser.identifier_return identifier() // throws RecognitionException [1]
    {   
        HqlParser.identifier_return retval = new HqlParser.identifier_return();
        retval.Start = input.LT(1);

        IASTNode root_0 = null;

        IToken IDENT266 = null;

        IASTNode IDENT266_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:926:2: ( IDENT )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/Hql.g:926:4: IDENT
            {
            	root_0 = (IASTNode)adaptor.GetNilNode();

            	IDENT266=(IToken)Match(input,IDENT,FOLLOW_IDENT_in_identifier3554); 
            		IDENT266_tree = (IASTNode)adaptor.Create(IDENT266);
            		adaptor.AddChild(root_0, IDENT266_tree);


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (IASTNode)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException ex) 
        {

            		retval = HandleIdentifierError(input.LT(1),ex);
            	
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "identifier"

    // Delegated rules


   	protected DFA1 dfa1;
   	protected DFA15 dfa15;
   	protected DFA16 dfa16;
   	protected DFA17 dfa17;
   	protected DFA21 dfa21;
   	protected DFA22 dfa22;
   	protected DFA23 dfa23;
   	protected DFA24 dfa24;
   	protected DFA25 dfa25;
   	protected DFA26 dfa26;
   	protected DFA36 dfa36;
   	protected DFA37 dfa37;
   	protected DFA38 dfa38;
   	protected DFA39 dfa39;
   	protected DFA42 dfa42;
   	protected DFA40 dfa40;
   	protected DFA48 dfa48;
   	protected DFA44 dfa44;
   	protected DFA49 dfa49;
   	protected DFA51 dfa51;
   	protected DFA50 dfa50;
   	protected DFA53 dfa53;
   	protected DFA55 dfa55;
   	protected DFA56 dfa56;
   	protected DFA61 dfa61;
   	protected DFA65 dfa65;
   	protected DFA64 dfa64;
   	protected DFA69 dfa69;
   	protected DFA66 dfa66;
   	protected DFA67 dfa67;
   	protected DFA68 dfa68;
   	protected DFA73 dfa73;
   	protected DFA74 dfa74;
   	protected DFA83 dfa83;
   	protected DFA85 dfa85;
   	protected DFA89 dfa89;
   	protected DFA88 dfa88;
   	protected DFA90 dfa90;
	private void InitializeCyclicDFAs()
	{
    	this.dfa1 = new DFA1(this);
    	this.dfa15 = new DFA15(this);
    	this.dfa16 = new DFA16(this);
    	this.dfa17 = new DFA17(this);
    	this.dfa21 = new DFA21(this);
    	this.dfa22 = new DFA22(this);
    	this.dfa23 = new DFA23(this);
    	this.dfa24 = new DFA24(this);
    	this.dfa25 = new DFA25(this);
    	this.dfa26 = new DFA26(this);
    	this.dfa36 = new DFA36(this);
    	this.dfa37 = new DFA37(this);
    	this.dfa38 = new DFA38(this);
    	this.dfa39 = new DFA39(this);
    	this.dfa42 = new DFA42(this);
    	this.dfa40 = new DFA40(this);
    	this.dfa48 = new DFA48(this);
    	this.dfa44 = new DFA44(this);
    	this.dfa49 = new DFA49(this);
    	this.dfa51 = new DFA51(this);
    	this.dfa50 = new DFA50(this);
    	this.dfa53 = new DFA53(this);
    	this.dfa55 = new DFA55(this);
    	this.dfa56 = new DFA56(this);
    	this.dfa61 = new DFA61(this);
    	this.dfa65 = new DFA65(this);
    	this.dfa64 = new DFA64(this);
    	this.dfa69 = new DFA69(this);
    	this.dfa66 = new DFA66(this);
    	this.dfa67 = new DFA67(this);
    	this.dfa68 = new DFA68(this);
    	this.dfa73 = new DFA73(this);
    	this.dfa74 = new DFA74(this);
    	this.dfa83 = new DFA83(this);
    	this.dfa85 = new DFA85(this);
    	this.dfa89 = new DFA89(this);
    	this.dfa88 = new DFA88(this);
    	this.dfa90 = new DFA90(this);






































	}

    const string DFA1_eotS =
        "\x0a\uffff";
    const string DFA1_eofS =
        "\x01\x03\x09\uffff";
    const string DFA1_minS =
        "\x01\x0d\x09\uffff";
    const string DFA1_maxS =
        "\x01\x35\x09\uffff";
    const string DFA1_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x01\x03\x05\uffff\x01\x04";
    const string DFA1_specialS =
        "\x0a\uffff}>";
    static readonly string[] DFA1_transitionS = {
            "\x01\x02\x08\uffff\x01\x03\x01\uffff\x01\x03\x04\uffff\x01\x09"+
            "\x0b\uffff\x01\x03\x03\uffff\x01\x03\x05\uffff\x01\x01\x01\uffff"+
            "\x01\x03",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA1_eot = DFA.UnpackEncodedString(DFA1_eotS);
    static readonly short[] DFA1_eof = DFA.UnpackEncodedString(DFA1_eofS);
    static readonly char[] DFA1_min = DFA.UnpackEncodedStringToUnsignedChars(DFA1_minS);
    static readonly char[] DFA1_max = DFA.UnpackEncodedStringToUnsignedChars(DFA1_maxS);
    static readonly short[] DFA1_accept = DFA.UnpackEncodedString(DFA1_acceptS);
    static readonly short[] DFA1_special = DFA.UnpackEncodedString(DFA1_specialS);
    static readonly short[][] DFA1_transition = DFA.UnpackEncodedStringArray(DFA1_transitionS);

    protected class DFA1 : DFA
    {
        public DFA1(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 1;
            this.eot = DFA1_eot;
            this.eof = DFA1_eof;
            this.min = DFA1_min;
            this.max = DFA1_max;
            this.accept = DFA1_accept;
            this.special = DFA1_special;
            this.transition = DFA1_transition;

        }

        override public string Description
        {
            get { return "143:4: ( updateStatement | deleteStatement | selectStatement | insertStatement )"; }
        }

    }

    const string DFA15_eotS =
        "\x18\uffff";
    const string DFA15_eofS =
        "\x18\uffff";
    const string DFA15_minS =
        "\x01\x04\x17\uffff";
    const string DFA15_maxS =
        "\x01\x76\x17\uffff";
    const string DFA15_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x15\uffff";
    const string DFA15_specialS =
        "\x18\uffff}>";
    static readonly string[] DFA15_transitionS = {
            "\x02\x02\x03\uffff\x01\x02\x02\uffff\x01\x02\x03\uffff\x01\x01"+
            "\x01\x02\x01\uffff\x02\x02\x06\uffff\x01\x02\x07\uffff\x05\x02"+
            "\x07\uffff\x03\x02\x05\uffff\x01\x02\x07\uffff\x01\x02\x02\uffff"+
            "\x01\x02\x1a\uffff\x04\x02\x03\uffff\x01\x02\x08\uffff\x02\x02"+
            "\x04\uffff\x04\x02",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA15_eot = DFA.UnpackEncodedString(DFA15_eotS);
    static readonly short[] DFA15_eof = DFA.UnpackEncodedString(DFA15_eofS);
    static readonly char[] DFA15_min = DFA.UnpackEncodedStringToUnsignedChars(DFA15_minS);
    static readonly char[] DFA15_max = DFA.UnpackEncodedStringToUnsignedChars(DFA15_maxS);
    static readonly short[] DFA15_accept = DFA.UnpackEncodedString(DFA15_acceptS);
    static readonly short[] DFA15_special = DFA.UnpackEncodedString(DFA15_specialS);
    static readonly short[][] DFA15_transition = DFA.UnpackEncodedStringArray(DFA15_transitionS);

    protected class DFA15 : DFA
    {
        public DFA15(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 15;
            this.eot = DFA15_eot;
            this.eof = DFA15_eof;
            this.min = DFA15_min;
            this.max = DFA15_max;
            this.accept = DFA15_accept;
            this.special = DFA15_special;
            this.transition = DFA15_transition;

        }

        override public string Description
        {
            get { return "284:3: ( DISTINCT )?"; }
        }

    }

    const string DFA16_eotS =
        "\x17\uffff";
    const string DFA16_eofS =
        "\x17\uffff";
    const string DFA16_minS =
        "\x01\x04\x16\uffff";
    const string DFA16_maxS =
        "\x01\x76\x16\uffff";
    const string DFA16_acceptS =
        "\x01\uffff\x01\x01\x13\uffff\x01\x02\x01\x03";
    const string DFA16_specialS =
        "\x17\uffff}>";
    static readonly string[] DFA16_transitionS = {
            "\x02\x01\x03\uffff\x01\x01\x02\uffff\x01\x01\x04\uffff\x01\x01"+
            "\x01\uffff\x02\x01\x06\uffff\x01\x01\x07\uffff\x02\x01\x01\x15"+
            "\x02\x01\x07\uffff\x03\x01\x05\uffff\x01\x01\x07\uffff\x01\x01"+
            "\x02\uffff\x01\x16\x1a\uffff\x04\x01\x03\uffff\x01\x01\x08\uffff"+
            "\x02\x01\x04\uffff\x04\x01",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA16_eot = DFA.UnpackEncodedString(DFA16_eotS);
    static readonly short[] DFA16_eof = DFA.UnpackEncodedString(DFA16_eofS);
    static readonly char[] DFA16_min = DFA.UnpackEncodedStringToUnsignedChars(DFA16_minS);
    static readonly char[] DFA16_max = DFA.UnpackEncodedStringToUnsignedChars(DFA16_maxS);
    static readonly short[] DFA16_accept = DFA.UnpackEncodedString(DFA16_acceptS);
    static readonly short[] DFA16_special = DFA.UnpackEncodedString(DFA16_specialS);
    static readonly short[][] DFA16_transition = DFA.UnpackEncodedStringArray(DFA16_transitionS);

    protected class DFA16 : DFA
    {
        public DFA16(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 16;
            this.eot = DFA16_eot;
            this.eof = DFA16_eof;
            this.min = DFA16_min;
            this.max = DFA16_max;
            this.accept = DFA16_accept;
            this.special = DFA16_special;
            this.transition = DFA16_transition;

        }

        override public string Description
        {
            get { return "284:15: ( selectedPropertiesList | newExpression | selectObject )"; }
        }

    }

    const string DFA17_eotS =
        "\x0c\uffff";
    const string DFA17_eofS =
        "\x01\x01\x0b\uffff";
    const string DFA17_minS =
        "\x01\x17\x0b\uffff";
    const string DFA17_maxS =
        "\x01\x65\x0b\uffff";
    const string DFA17_acceptS =
        "\x01\uffff\x01\x03\x05\uffff\x01\x01\x03\uffff\x01\x02";
    const string DFA17_specialS =
        "\x0c\uffff}>";
    static readonly string[] DFA17_transitionS = {
            "\x01\x07\x01\x01\x03\uffff\x01\x07\x03\uffff\x02\x07\x07\uffff"+
            "\x01\x01\x02\uffff\x01\x07\x05\uffff\x01\x01\x02\uffff\x01\x01"+
            "\x2c\uffff\x01\x0b\x02\uffff\x01\x01",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA17_eot = DFA.UnpackEncodedString(DFA17_eotS);
    static readonly short[] DFA17_eof = DFA.UnpackEncodedString(DFA17_eofS);
    static readonly char[] DFA17_min = DFA.UnpackEncodedStringToUnsignedChars(DFA17_minS);
    static readonly char[] DFA17_max = DFA.UnpackEncodedStringToUnsignedChars(DFA17_maxS);
    static readonly short[] DFA17_accept = DFA.UnpackEncodedString(DFA17_acceptS);
    static readonly short[] DFA17_special = DFA.UnpackEncodedString(DFA17_specialS);
    static readonly short[][] DFA17_transition = DFA.UnpackEncodedStringArray(DFA17_transitionS);

    protected class DFA17 : DFA
    {
        public DFA17(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 17;
            this.eot = DFA17_eot;
            this.eof = DFA17_eof;
            this.min = DFA17_min;
            this.max = DFA17_max;
            this.accept = DFA17_accept;
            this.special = DFA17_special;
            this.transition = DFA17_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 310:40: ( fromJoin | COMMA fromRange )*"; }
        }

    }

    const string DFA21_eotS =
        "\x10\uffff";
    const string DFA21_eofS =
        "\x01\x03\x0f\uffff";
    const string DFA21_minS =
        "\x01\x07\x0f\uffff";
    const string DFA21_maxS =
        "\x01\x76\x0f\uffff";
    const string DFA21_acceptS =
        "\x01\uffff\x01\x01\x01\uffff\x01\x02\x0c\uffff";
    const string DFA21_specialS =
        "\x10\uffff}>";
    static readonly string[] DFA21_transitionS = {
            "\x01\x01\x0d\uffff\x01\x03\x01\uffff\x02\x03\x03\uffff\x01\x03"+
            "\x03\uffff\x02\x03\x07\uffff\x01\x03\x02\uffff\x01\x03\x05\uffff"+
            "\x01\x03\x02\uffff\x01\x03\x07\uffff\x01\x03\x24\uffff\x01\x03"+
            "\x02\uffff\x01\x03\x10\uffff\x01\x01",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA21_eot = DFA.UnpackEncodedString(DFA21_eotS);
    static readonly short[] DFA21_eof = DFA.UnpackEncodedString(DFA21_eofS);
    static readonly char[] DFA21_min = DFA.UnpackEncodedStringToUnsignedChars(DFA21_minS);
    static readonly char[] DFA21_max = DFA.UnpackEncodedStringToUnsignedChars(DFA21_maxS);
    static readonly short[] DFA21_accept = DFA.UnpackEncodedString(DFA21_acceptS);
    static readonly short[] DFA21_special = DFA.UnpackEncodedString(DFA21_specialS);
    static readonly short[][] DFA21_transition = DFA.UnpackEncodedStringArray(DFA21_transitionS);

    protected class DFA21 : DFA
    {
        public DFA21(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 21;
            this.eot = DFA21_eot;
            this.eof = DFA21_eof;
            this.min = DFA21_min;
            this.max = DFA21_max;
            this.accept = DFA21_accept;
            this.special = DFA21_special;
            this.transition = DFA21_transition;

        }

        override public string Description
        {
            get { return "318:9: ( asAlias )?"; }
        }

    }

    const string DFA22_eotS =
        "\x0e\uffff";
    const string DFA22_eofS =
        "\x01\x02\x0d\uffff";
    const string DFA22_minS =
        "\x01\x15\x0d\uffff";
    const string DFA22_maxS =
        "\x01\x65\x0d\uffff";
    const string DFA22_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x0b\uffff";
    const string DFA22_specialS =
        "\x0e\uffff}>";
    static readonly string[] DFA22_transitionS = {
            "\x01\x01\x01\uffff\x02\x02\x03\uffff\x01\x02\x03\uffff\x02\x02"+
            "\x07\uffff\x01\x02\x02\uffff\x01\x02\x05\uffff\x01\x02\x02\uffff"+
            "\x01\x02\x07\uffff\x01\x02\x24\uffff\x01\x02\x02\uffff\x01\x02",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA22_eot = DFA.UnpackEncodedString(DFA22_eotS);
    static readonly short[] DFA22_eof = DFA.UnpackEncodedString(DFA22_eofS);
    static readonly char[] DFA22_min = DFA.UnpackEncodedStringToUnsignedChars(DFA22_minS);
    static readonly char[] DFA22_max = DFA.UnpackEncodedStringToUnsignedChars(DFA22_maxS);
    static readonly short[] DFA22_accept = DFA.UnpackEncodedString(DFA22_acceptS);
    static readonly short[] DFA22_special = DFA.UnpackEncodedString(DFA22_specialS);
    static readonly short[][] DFA22_transition = DFA.UnpackEncodedStringArray(DFA22_transitionS);

    protected class DFA22 : DFA
    {
        public DFA22(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 22;
            this.eot = DFA22_eot;
            this.eof = DFA22_eof;
            this.min = DFA22_min;
            this.max = DFA22_max;
            this.accept = DFA22_accept;
            this.special = DFA22_special;
            this.transition = DFA22_transition;

        }

        override public string Description
        {
            get { return "318:20: ( propertyFetch )?"; }
        }

    }

    const string DFA23_eotS =
        "\x0d\uffff";
    const string DFA23_eofS =
        "\x01\x02\x0c\uffff";
    const string DFA23_minS =
        "\x01\x17\x0c\uffff";
    const string DFA23_maxS =
        "\x01\x65\x0c\uffff";
    const string DFA23_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x0a\uffff";
    const string DFA23_specialS =
        "\x0d\uffff}>";
    static readonly string[] DFA23_transitionS = {
            "\x02\x02\x03\uffff\x01\x02\x03\uffff\x02\x02\x07\uffff\x01\x02"+
            "\x02\uffff\x01\x02\x05\uffff\x01\x02\x02\uffff\x01\x02\x07\uffff"+
            "\x01\x01\x24\uffff\x01\x02\x02\uffff\x01\x02",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA23_eot = DFA.UnpackEncodedString(DFA23_eotS);
    static readonly short[] DFA23_eof = DFA.UnpackEncodedString(DFA23_eofS);
    static readonly char[] DFA23_min = DFA.UnpackEncodedStringToUnsignedChars(DFA23_minS);
    static readonly char[] DFA23_max = DFA.UnpackEncodedStringToUnsignedChars(DFA23_maxS);
    static readonly short[] DFA23_accept = DFA.UnpackEncodedString(DFA23_acceptS);
    static readonly short[] DFA23_special = DFA.UnpackEncodedString(DFA23_specialS);
    static readonly short[][] DFA23_transition = DFA.UnpackEncodedStringArray(DFA23_transitionS);

    protected class DFA23 : DFA
    {
        public DFA23(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 23;
            this.eot = DFA23_eot;
            this.eof = DFA23_eof;
            this.min = DFA23_min;
            this.max = DFA23_max;
            this.accept = DFA23_accept;
            this.special = DFA23_special;
            this.transition = DFA23_transition;

        }

        override public string Description
        {
            get { return "318:37: ( withClause )?"; }
        }

    }

    const string DFA24_eotS =
        "\x15\uffff";
    const string DFA24_eofS =
        "\x01\uffff\x01\x04\x13\uffff";
    const string DFA24_minS =
        "\x01\x1a\x01\x07\x01\uffff\x01\x0b\x11\uffff";
    const string DFA24_maxS =
        "\x02\x76\x01\uffff\x01\x11\x11\uffff";
    const string DFA24_acceptS =
        "\x02\uffff\x01\x03\x01\uffff\x01\x01\x0e\uffff\x01\x02\x01\x04";
    const string DFA24_specialS =
        "\x15\uffff}>";
    static readonly string[] DFA24_transitionS = {
            "\x01\x02\x5b\uffff\x01\x01",
            "\x01\x04\x07\uffff\x01\x04\x05\uffff\x01\x04\x01\uffff\x02"+
            "\x04\x01\uffff\x01\x03\x01\uffff\x01\x04\x03\uffff\x02\x04\x07"+
            "\uffff\x01\x04\x02\uffff\x01\x04\x05\uffff\x01\x04\x02\uffff"+
            "\x01\x04\x2c\uffff\x01\x04\x02\uffff\x01\x04\x10\uffff\x01\x04",
            "",
            "\x01\x13\x05\uffff\x01\x14",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA24_eot = DFA.UnpackEncodedString(DFA24_eotS);
    static readonly short[] DFA24_eof = DFA.UnpackEncodedString(DFA24_eofS);
    static readonly char[] DFA24_min = DFA.UnpackEncodedStringToUnsignedChars(DFA24_minS);
    static readonly char[] DFA24_max = DFA.UnpackEncodedStringToUnsignedChars(DFA24_maxS);
    static readonly short[] DFA24_accept = DFA.UnpackEncodedString(DFA24_acceptS);
    static readonly short[] DFA24_special = DFA.UnpackEncodedString(DFA24_specialS);
    static readonly short[][] DFA24_transition = DFA.UnpackEncodedStringArray(DFA24_transitionS);

    protected class DFA24 : DFA
    {
        public DFA24(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 24;
            this.eot = DFA24_eot;
            this.eof = DFA24_eof;
            this.min = DFA24_min;
            this.max = DFA24_max;
            this.accept = DFA24_accept;
            this.special = DFA24_special;
            this.transition = DFA24_transition;

        }

        override public string Description
        {
            get { return "325:1: fromRange : ( fromClassOrOuterQueryPath | inClassDeclaration | inCollectionDeclaration | inCollectionElementsDeclaration );"; }
        }

    }

    const string DFA25_eotS =
        "\x0f\uffff";
    const string DFA25_eofS =
        "\x01\x03\x0e\uffff";
    const string DFA25_minS =
        "\x01\x07\x0e\uffff";
    const string DFA25_maxS =
        "\x01\x76\x0e\uffff";
    const string DFA25_acceptS =
        "\x01\uffff\x01\x01\x01\uffff\x01\x02\x0b\uffff";
    const string DFA25_specialS =
        "\x0f\uffff}>";
    static readonly string[] DFA25_transitionS = {
            "\x01\x01\x0d\uffff\x01\x03\x01\uffff\x02\x03\x03\uffff\x01\x03"+
            "\x03\uffff\x02\x03\x07\uffff\x01\x03\x02\uffff\x01\x03\x05\uffff"+
            "\x01\x03\x02\uffff\x01\x03\x2c\uffff\x01\x03\x02\uffff\x01\x03"+
            "\x10\uffff\x01\x01",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA25_eot = DFA.UnpackEncodedString(DFA25_eotS);
    static readonly short[] DFA25_eof = DFA.UnpackEncodedString(DFA25_eofS);
    static readonly char[] DFA25_min = DFA.UnpackEncodedStringToUnsignedChars(DFA25_minS);
    static readonly char[] DFA25_max = DFA.UnpackEncodedStringToUnsignedChars(DFA25_maxS);
    static readonly short[] DFA25_accept = DFA.UnpackEncodedString(DFA25_acceptS);
    static readonly short[] DFA25_special = DFA.UnpackEncodedString(DFA25_specialS);
    static readonly short[][] DFA25_transition = DFA.UnpackEncodedStringArray(DFA25_transitionS);

    protected class DFA25 : DFA
    {
        public DFA25(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 25;
            this.eot = DFA25_eot;
            this.eof = DFA25_eof;
            this.min = DFA25_min;
            this.max = DFA25_max;
            this.accept = DFA25_accept;
            this.special = DFA25_special;
            this.transition = DFA25_transition;

        }

        override public string Description
        {
            get { return "342:29: ( asAlias )?"; }
        }

    }

    const string DFA26_eotS =
        "\x0d\uffff";
    const string DFA26_eofS =
        "\x01\x02\x0c\uffff";
    const string DFA26_minS =
        "\x01\x15\x0c\uffff";
    const string DFA26_maxS =
        "\x01\x65\x0c\uffff";
    const string DFA26_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x0a\uffff";
    const string DFA26_specialS =
        "\x0d\uffff}>";
    static readonly string[] DFA26_transitionS = {
            "\x01\x01\x01\uffff\x02\x02\x03\uffff\x01\x02\x03\uffff\x02\x02"+
            "\x07\uffff\x01\x02\x02\uffff\x01\x02\x05\uffff\x01\x02\x02\uffff"+
            "\x01\x02\x2c\uffff\x01\x02\x02\uffff\x01\x02",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA26_eot = DFA.UnpackEncodedString(DFA26_eotS);
    static readonly short[] DFA26_eof = DFA.UnpackEncodedString(DFA26_eofS);
    static readonly char[] DFA26_min = DFA.UnpackEncodedStringToUnsignedChars(DFA26_minS);
    static readonly char[] DFA26_max = DFA.UnpackEncodedStringToUnsignedChars(DFA26_maxS);
    static readonly short[] DFA26_accept = DFA.UnpackEncodedString(DFA26_acceptS);
    static readonly short[] DFA26_special = DFA.UnpackEncodedString(DFA26_specialS);
    static readonly short[][] DFA26_transition = DFA.UnpackEncodedStringArray(DFA26_transitionS);

    protected class DFA26 : DFA
    {
        public DFA26(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 26;
            this.eot = DFA26_eot;
            this.eof = DFA26_eof;
            this.min = DFA26_min;
            this.max = DFA26_max;
            this.accept = DFA26_accept;
            this.special = DFA26_special;
            this.transition = DFA26_transition;

        }

        override public string Description
        {
            get { return "342:40: ( propertyFetch )?"; }
        }

    }

    const string DFA36_eotS =
        "\x0a\uffff";
    const string DFA36_eofS =
        "\x01\x02\x09\uffff";
    const string DFA36_minS =
        "\x01\x07\x09\uffff";
    const string DFA36_maxS =
        "\x01\x65\x09\uffff";
    const string DFA36_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x07\uffff";
    const string DFA36_specialS =
        "\x0a\uffff}>";
    static readonly string[] DFA36_transitionS = {
            "\x01\x01\x0e\uffff\x01\x02\x01\uffff\x01\x02\x10\uffff\x01\x02"+
            "\x08\uffff\x01\x02\x02\uffff\x01\x02\x2c\uffff\x01\x02\x02\uffff"+
            "\x01\x02",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA36_eot = DFA.UnpackEncodedString(DFA36_eotS);
    static readonly short[] DFA36_eof = DFA.UnpackEncodedString(DFA36_eofS);
    static readonly char[] DFA36_min = DFA.UnpackEncodedStringToUnsignedChars(DFA36_minS);
    static readonly char[] DFA36_max = DFA.UnpackEncodedStringToUnsignedChars(DFA36_maxS);
    static readonly short[] DFA36_accept = DFA.UnpackEncodedString(DFA36_acceptS);
    static readonly short[] DFA36_special = DFA.UnpackEncodedString(DFA36_specialS);
    static readonly short[][] DFA36_transition = DFA.UnpackEncodedStringArray(DFA36_transitionS);

    protected class DFA36 : DFA
    {
        public DFA36(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 36;
            this.eot = DFA36_eot;
            this.eof = DFA36_eof;
            this.min = DFA36_min;
            this.max = DFA36_max;
            this.accept = DFA36_accept;
            this.special = DFA36_special;
            this.transition = DFA36_transition;

        }

        override public string Description
        {
            get { return "466:15: ( AS identifier )?"; }
        }

    }

    const string DFA37_eotS =
        "\x16\uffff";
    const string DFA37_eofS =
        "\x01\x01\x15\uffff";
    const string DFA37_minS =
        "\x01\x07\x15\uffff";
    const string DFA37_maxS =
        "\x01\x7f\x15\uffff";
    const string DFA37_acceptS =
        "\x01\uffff\x01\x02\x13\uffff\x01\x01";
    const string DFA37_specialS =
        "\x16\uffff}>";
    static readonly string[] DFA37_transitionS = {
            "\x02\x01\x05\uffff\x01\x01\x07\uffff\x04\x01\x02\uffff\x01\x01"+
            "\x03\uffff\x02\x01\x06\uffff\x01\x15\x01\x01\x02\uffff\x01\x01"+
            "\x05\uffff\x01\x01\x02\uffff\x01\x01\x04\uffff\x01\x01\x27\uffff"+
            "\x01\x01\x02\uffff\x01\x01\x0c\uffff\x01\x01\x0b\uffff\x02\x01",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA37_eot = DFA.UnpackEncodedString(DFA37_eotS);
    static readonly short[] DFA37_eof = DFA.UnpackEncodedString(DFA37_eofS);
    static readonly char[] DFA37_min = DFA.UnpackEncodedStringToUnsignedChars(DFA37_minS);
    static readonly char[] DFA37_max = DFA.UnpackEncodedStringToUnsignedChars(DFA37_maxS);
    static readonly short[] DFA37_accept = DFA.UnpackEncodedString(DFA37_acceptS);
    static readonly short[] DFA37_special = DFA.UnpackEncodedString(DFA37_specialS);
    static readonly short[][] DFA37_transition = DFA.UnpackEncodedStringArray(DFA37_transitionS);

    protected class DFA37 : DFA
    {
        public DFA37(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 37;
            this.eot = DFA37_eot;
            this.eof = DFA37_eof;
            this.min = DFA37_min;
            this.max = DFA37_max;
            this.accept = DFA37_accept;
            this.special = DFA37_special;
            this.transition = DFA37_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 504:25: ( OR logicalAndExpression )*"; }
        }

    }

    const string DFA38_eotS =
        "\x17\uffff";
    const string DFA38_eofS =
        "\x01\x01\x16\uffff";
    const string DFA38_minS =
        "\x01\x06\x16\uffff";
    const string DFA38_maxS =
        "\x01\x7f\x16\uffff";
    const string DFA38_acceptS =
        "\x01\uffff\x01\x02\x14\uffff\x01\x01";
    const string DFA38_specialS =
        "\x17\uffff}>";
    static readonly string[] DFA38_transitionS = {
            "\x01\x16\x02\x01\x05\uffff\x01\x01\x07\uffff\x04\x01\x02\uffff"+
            "\x01\x01\x03\uffff\x02\x01\x06\uffff\x02\x01\x02\uffff\x01\x01"+
            "\x05\uffff\x01\x01\x02\uffff\x01\x01\x04\uffff\x01\x01\x27\uffff"+
            "\x01\x01\x02\uffff\x01\x01\x0c\uffff\x01\x01\x0b\uffff\x02\x01",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA38_eot = DFA.UnpackEncodedString(DFA38_eotS);
    static readonly short[] DFA38_eof = DFA.UnpackEncodedString(DFA38_eofS);
    static readonly char[] DFA38_min = DFA.UnpackEncodedStringToUnsignedChars(DFA38_minS);
    static readonly char[] DFA38_max = DFA.UnpackEncodedStringToUnsignedChars(DFA38_maxS);
    static readonly short[] DFA38_accept = DFA.UnpackEncodedString(DFA38_acceptS);
    static readonly short[] DFA38_special = DFA.UnpackEncodedString(DFA38_specialS);
    static readonly short[][] DFA38_transition = DFA.UnpackEncodedStringArray(DFA38_transitionS);

    protected class DFA38 : DFA
    {
        public DFA38(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 38;
            this.eot = DFA38_eot;
            this.eof = DFA38_eof;
            this.min = DFA38_min;
            this.max = DFA38_max;
            this.accept = DFA38_accept;
            this.special = DFA38_special;
            this.transition = DFA38_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 509:22: ( AND negatedExpression )*"; }
        }

    }

    const string DFA39_eotS =
        "\x15\uffff";
    const string DFA39_eofS =
        "\x15\uffff";
    const string DFA39_minS =
        "\x01\x04\x14\uffff";
    const string DFA39_maxS =
        "\x01\x76\x14\uffff";
    const string DFA39_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x12\uffff";
    const string DFA39_specialS =
        "\x15\uffff}>";
    static readonly string[] DFA39_transitionS = {
            "\x02\x02\x03\uffff\x01\x02\x02\uffff\x01\x02\x04\uffff\x01\x02"+
            "\x01\uffff\x02\x02\x06\uffff\x01\x02\x07\uffff\x02\x02\x01\uffff"+
            "\x01\x01\x01\x02\x07\uffff\x03\x02\x05\uffff\x01\x02\x07\uffff"+
            "\x01\x02\x1d\uffff\x04\x02\x03\uffff\x01\x02\x08\uffff\x02\x02"+
            "\x04\uffff\x04\x02",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA39_eot = DFA.UnpackEncodedString(DFA39_eotS);
    static readonly short[] DFA39_eof = DFA.UnpackEncodedString(DFA39_eofS);
    static readonly char[] DFA39_min = DFA.UnpackEncodedStringToUnsignedChars(DFA39_minS);
    static readonly char[] DFA39_max = DFA.UnpackEncodedStringToUnsignedChars(DFA39_maxS);
    static readonly short[] DFA39_accept = DFA.UnpackEncodedString(DFA39_acceptS);
    static readonly short[] DFA39_special = DFA.UnpackEncodedString(DFA39_specialS);
    static readonly short[][] DFA39_transition = DFA.UnpackEncodedStringArray(DFA39_transitionS);

    protected class DFA39 : DFA
    {
        public DFA39(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 39;
            this.eot = DFA39_eot;
            this.eof = DFA39_eof;
            this.min = DFA39_min;
            this.max = DFA39_max;
            this.accept = DFA39_accept;
            this.special = DFA39_special;
            this.transition = DFA39_transition;

        }

        override public string Description
        {
            get { return "523:1: negatedExpression : ( NOT x= negatedExpression -> ^() | equalityExpression -> ^( equalityExpression ) );"; }
        }

    }

    const string DFA42_eotS =
        "\x1b\uffff";
    const string DFA42_eofS =
        "\x01\x01\x1a\uffff";
    const string DFA42_minS =
        "\x01\x06\x1a\uffff";
    const string DFA42_maxS =
        "\x01\x7f\x1a\uffff";
    const string DFA42_acceptS =
        "\x01\uffff\x01\x02\x15\uffff\x01\x01\x03\uffff";
    const string DFA42_specialS =
        "\x1b\uffff}>";
    static readonly string[] DFA42_transitionS = {
            "\x03\x01\x05\uffff\x01\x01\x07\uffff\x04\x01\x02\uffff\x01\x01"+
            "\x02\uffff\x01\x17\x02\x01\x06\uffff\x02\x01\x02\uffff\x01\x01"+
            "\x05\uffff\x01\x01\x02\uffff\x01\x01\x04\uffff\x01\x01\x27\uffff"+
            "\x01\x01\x01\x17\x01\uffff\x01\x01\x02\x17\x0a\uffff\x01\x01"+
            "\x0b\uffff\x02\x01",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA42_eot = DFA.UnpackEncodedString(DFA42_eotS);
    static readonly short[] DFA42_eof = DFA.UnpackEncodedString(DFA42_eofS);
    static readonly char[] DFA42_min = DFA.UnpackEncodedStringToUnsignedChars(DFA42_minS);
    static readonly char[] DFA42_max = DFA.UnpackEncodedStringToUnsignedChars(DFA42_maxS);
    static readonly short[] DFA42_accept = DFA.UnpackEncodedString(DFA42_acceptS);
    static readonly short[] DFA42_special = DFA.UnpackEncodedString(DFA42_specialS);
    static readonly short[][] DFA42_transition = DFA.UnpackEncodedStringArray(DFA42_transitionS);

    protected class DFA42 : DFA
    {
        public DFA42(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 42;
            this.eot = DFA42_eot;
            this.eof = DFA42_eof;
            this.min = DFA42_min;
            this.max = DFA42_max;
            this.accept = DFA42_accept;
            this.special = DFA42_special;
            this.transition = DFA42_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 554:27: ( ( EQ | isx= IS ( NOT )? | NE | ne= SQL_NE ) y= relationalExpression )*"; }
        }

    }

    const string DFA40_eotS =
        "\x15\uffff";
    const string DFA40_eofS =
        "\x15\uffff";
    const string DFA40_minS =
        "\x01\x04\x14\uffff";
    const string DFA40_maxS =
        "\x01\x76\x14\uffff";
    const string DFA40_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x12\uffff";
    const string DFA40_specialS =
        "\x15\uffff}>";
    static readonly string[] DFA40_transitionS = {
            "\x02\x02\x03\uffff\x01\x02\x02\uffff\x01\x02\x04\uffff\x01\x02"+
            "\x01\uffff\x02\x02\x06\uffff\x01\x02\x07\uffff\x02\x02\x01\uffff"+
            "\x01\x01\x01\x02\x07\uffff\x03\x02\x05\uffff\x01\x02\x07\uffff"+
            "\x01\x02\x1d\uffff\x04\x02\x03\uffff\x01\x02\x08\uffff\x02\x02"+
            "\x04\uffff\x04\x02",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA40_eot = DFA.UnpackEncodedString(DFA40_eotS);
    static readonly short[] DFA40_eof = DFA.UnpackEncodedString(DFA40_eofS);
    static readonly char[] DFA40_min = DFA.UnpackEncodedStringToUnsignedChars(DFA40_minS);
    static readonly char[] DFA40_max = DFA.UnpackEncodedStringToUnsignedChars(DFA40_maxS);
    static readonly short[] DFA40_accept = DFA.UnpackEncodedString(DFA40_acceptS);
    static readonly short[] DFA40_special = DFA.UnpackEncodedString(DFA40_specialS);
    static readonly short[][] DFA40_transition = DFA.UnpackEncodedStringArray(DFA40_transitionS);

    protected class DFA40 : DFA
    {
        public DFA40(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 40;
            this.eot = DFA40_eot;
            this.eof = DFA40_eof;
            this.min = DFA40_min;
            this.max = DFA40_max;
            this.accept = DFA40_accept;
            this.special = DFA40_special;
            this.transition = DFA40_transition;

        }

        override public string Description
        {
            get { return "556:33: ( NOT )?"; }
        }

    }

    const string DFA48_eotS =
        "\x24\uffff";
    const string DFA48_eofS =
        "\x01\x01\x23\uffff";
    const string DFA48_minS =
        "\x01\x06\x23\uffff";
    const string DFA48_maxS =
        "\x01\x7f\x23\uffff";
    const string DFA48_acceptS =
        "\x01\uffff\x01\x01\x1d\uffff\x01\x02\x04\uffff";
    const string DFA48_specialS =
        "\x24\uffff}>";
    static readonly string[] DFA48_transitionS = {
            "\x03\x01\x01\uffff\x01\x1f\x03\uffff\x01\x01\x07\uffff\x04\x01"+
            "\x01\x1f\x01\uffff\x01\x01\x02\uffff\x03\x01\x01\x1f\x03\uffff"+
            "\x01\x1f\x01\uffff\x02\x01\x02\uffff\x01\x01\x05\uffff\x01\x01"+
            "\x02\uffff\x01\x01\x04\uffff\x01\x01\x06\uffff\x01\x1f\x20\uffff"+
            "\x02\x01\x01\uffff\x07\x01\x06\uffff\x01\x01\x0b\uffff\x02\x01",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA48_eot = DFA.UnpackEncodedString(DFA48_eotS);
    static readonly short[] DFA48_eof = DFA.UnpackEncodedString(DFA48_eofS);
    static readonly char[] DFA48_min = DFA.UnpackEncodedStringToUnsignedChars(DFA48_minS);
    static readonly char[] DFA48_max = DFA.UnpackEncodedStringToUnsignedChars(DFA48_maxS);
    static readonly short[] DFA48_accept = DFA.UnpackEncodedString(DFA48_acceptS);
    static readonly short[] DFA48_special = DFA.UnpackEncodedString(DFA48_specialS);
    static readonly short[][] DFA48_transition = DFA.UnpackEncodedStringArray(DFA48_transitionS);

    protected class DFA48 : DFA
    {
        public DFA48(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 48;
            this.eot = DFA48_eot;
            this.eof = DFA48_eof;
            this.min = DFA48_min;
            this.max = DFA48_max;
            this.accept = DFA48_accept;
            this.special = DFA48_special;
            this.transition = DFA48_transition;

        }

        override public string Description
        {
            get { return "597:18: ( ( ( ( LT | GT | LE | GE ) additiveExpression )* ) | (n= NOT )? ( (i= IN inList ) | (b= BETWEEN betweenList ) | (l= LIKE concatenation likeEscape ) | ( MEMBER ( OF )? p= path ) ) )"; }
        }

    }

    const string DFA44_eotS =
        "\x1f\uffff";
    const string DFA44_eofS =
        "\x01\x01\x1e\uffff";
    const string DFA44_minS =
        "\x01\x06\x1e\uffff";
    const string DFA44_maxS =
        "\x01\x7f\x1e\uffff";
    const string DFA44_acceptS =
        "\x01\uffff\x01\x02\x19\uffff\x01\x01\x03\uffff";
    const string DFA44_specialS =
        "\x1f\uffff}>";
    static readonly string[] DFA44_transitionS = {
            "\x03\x01\x05\uffff\x01\x01\x07\uffff\x04\x01\x02\uffff\x01\x01"+
            "\x02\uffff\x03\x01\x06\uffff\x02\x01\x02\uffff\x01\x01\x05\uffff"+
            "\x01\x01\x02\uffff\x01\x01\x04\uffff\x01\x01\x27\uffff\x02\x01"+
            "\x01\uffff\x03\x01\x04\x1b\x06\uffff\x01\x01\x0b\uffff\x02\x01",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA44_eot = DFA.UnpackEncodedString(DFA44_eotS);
    static readonly short[] DFA44_eof = DFA.UnpackEncodedString(DFA44_eofS);
    static readonly char[] DFA44_min = DFA.UnpackEncodedStringToUnsignedChars(DFA44_minS);
    static readonly char[] DFA44_max = DFA.UnpackEncodedStringToUnsignedChars(DFA44_maxS);
    static readonly short[] DFA44_accept = DFA.UnpackEncodedString(DFA44_acceptS);
    static readonly short[] DFA44_special = DFA.UnpackEncodedString(DFA44_specialS);
    static readonly short[][] DFA44_transition = DFA.UnpackEncodedStringArray(DFA44_transitionS);

    protected class DFA44 : DFA
    {
        public DFA44(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 44;
            this.eot = DFA44_eot;
            this.eof = DFA44_eof;
            this.min = DFA44_min;
            this.max = DFA44_max;
            this.accept = DFA44_accept;
            this.special = DFA44_special;
            this.transition = DFA44_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 598:5: ( ( LT | GT | LE | GE ) additiveExpression )*"; }
        }

    }

    const string DFA49_eotS =
        "\x1c\uffff";
    const string DFA49_eofS =
        "\x01\x02\x1b\uffff";
    const string DFA49_minS =
        "\x01\x06\x1b\uffff";
    const string DFA49_maxS =
        "\x01\x7f\x1b\uffff";
    const string DFA49_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x19\uffff";
    const string DFA49_specialS =
        "\x1c\uffff}>";
    static readonly string[] DFA49_transitionS = {
            "\x03\x02\x05\uffff\x01\x02\x03\uffff\x01\x01\x03\uffff\x04\x02"+
            "\x02\uffff\x01\x02\x02\uffff\x03\x02\x06\uffff\x02\x02\x02\uffff"+
            "\x01\x02\x05\uffff\x01\x02\x02\uffff\x01\x02\x04\uffff\x01\x02"+
            "\x27\uffff\x02\x02\x01\uffff\x03\x02\x0a\uffff\x01\x02\x0b\uffff"+
            "\x02\x02",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA49_eot = DFA.UnpackEncodedString(DFA49_eotS);
    static readonly short[] DFA49_eof = DFA.UnpackEncodedString(DFA49_eofS);
    static readonly char[] DFA49_min = DFA.UnpackEncodedStringToUnsignedChars(DFA49_minS);
    static readonly char[] DFA49_max = DFA.UnpackEncodedStringToUnsignedChars(DFA49_maxS);
    static readonly short[] DFA49_accept = DFA.UnpackEncodedString(DFA49_acceptS);
    static readonly short[] DFA49_special = DFA.UnpackEncodedString(DFA49_specialS);
    static readonly short[][] DFA49_transition = DFA.UnpackEncodedStringArray(DFA49_transitionS);

    protected class DFA49 : DFA
    {
        public DFA49(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 49;
            this.eot = DFA49_eot;
            this.eof = DFA49_eof;
            this.min = DFA49_min;
            this.max = DFA49_max;
            this.accept = DFA49_accept;
            this.special = DFA49_special;
            this.transition = DFA49_transition;

        }

        override public string Description
        {
            get { return "626:4: ( ESCAPE concatenation )?"; }
        }

    }

    const string DFA51_eotS =
        "\x26\uffff";
    const string DFA51_eofS =
        "\x01\x02\x25\uffff";
    const string DFA51_minS =
        "\x01\x06\x25\uffff";
    const string DFA51_maxS =
        "\x01\x7f\x25\uffff";
    const string DFA51_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x23\uffff";
    const string DFA51_specialS =
        "\x26\uffff}>";
    static readonly string[] DFA51_transitionS = {
            "\x03\x02\x01\uffff\x01\x02\x03\uffff\x01\x02\x03\uffff\x01\x02"+
            "\x03\uffff\x05\x02\x01\uffff\x01\x02\x02\uffff\x04\x02\x03\uffff"+
            "\x01\x02\x01\uffff\x02\x02\x02\uffff\x01\x02\x05\uffff\x01\x02"+
            "\x02\uffff\x01\x02\x04\uffff\x01\x02\x06\uffff\x01\x02\x20\uffff"+
            "\x02\x02\x01\uffff\x07\x02\x01\x01\x05\uffff\x01\x02\x0b\uffff"+
            "\x02\x02",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA51_eot = DFA.UnpackEncodedString(DFA51_eotS);
    static readonly short[] DFA51_eof = DFA.UnpackEncodedString(DFA51_eofS);
    static readonly char[] DFA51_min = DFA.UnpackEncodedStringToUnsignedChars(DFA51_minS);
    static readonly char[] DFA51_max = DFA.UnpackEncodedStringToUnsignedChars(DFA51_maxS);
    static readonly short[] DFA51_accept = DFA.UnpackEncodedString(DFA51_acceptS);
    static readonly short[] DFA51_special = DFA.UnpackEncodedString(DFA51_specialS);
    static readonly short[][] DFA51_transition = DFA.UnpackEncodedStringArray(DFA51_transitionS);

    protected class DFA51 : DFA
    {
        public DFA51(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 51;
            this.eot = DFA51_eot;
            this.eof = DFA51_eof;
            this.min = DFA51_min;
            this.max = DFA51_max;
            this.accept = DFA51_accept;
            this.special = DFA51_special;
            this.transition = DFA51_transition;

        }

        override public string Description
        {
            get { return "660:2: (c= CONCAT additiveExpression ( CONCAT additiveExpression )* )?"; }
        }

    }

    const string DFA50_eotS =
        "\x26\uffff";
    const string DFA50_eofS =
        "\x01\x01\x25\uffff";
    const string DFA50_minS =
        "\x01\x06\x25\uffff";
    const string DFA50_maxS =
        "\x01\x7f\x25\uffff";
    const string DFA50_acceptS =
        "\x01\uffff\x01\x02\x23\uffff\x01\x01";
    const string DFA50_specialS =
        "\x26\uffff}>";
    static readonly string[] DFA50_transitionS = {
            "\x03\x01\x01\uffff\x01\x01\x03\uffff\x01\x01\x03\uffff\x01\x01"+
            "\x03\uffff\x05\x01\x01\uffff\x01\x01\x02\uffff\x04\x01\x03\uffff"+
            "\x01\x01\x01\uffff\x02\x01\x02\uffff\x01\x01\x05\uffff\x01\x01"+
            "\x02\uffff\x01\x01\x04\uffff\x01\x01\x06\uffff\x01\x01\x20\uffff"+
            "\x02\x01\x01\uffff\x07\x01\x01\x25\x05\uffff\x01\x01\x0b\uffff"+
            "\x02\x01",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA50_eot = DFA.UnpackEncodedString(DFA50_eotS);
    static readonly short[] DFA50_eof = DFA.UnpackEncodedString(DFA50_eofS);
    static readonly char[] DFA50_min = DFA.UnpackEncodedStringToUnsignedChars(DFA50_minS);
    static readonly char[] DFA50_max = DFA.UnpackEncodedStringToUnsignedChars(DFA50_maxS);
    static readonly short[] DFA50_accept = DFA.UnpackEncodedString(DFA50_acceptS);
    static readonly short[] DFA50_special = DFA.UnpackEncodedString(DFA50_specialS);
    static readonly short[][] DFA50_transition = DFA.UnpackEncodedStringArray(DFA50_transitionS);

    protected class DFA50 : DFA
    {
        public DFA50(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 50;
            this.eot = DFA50_eot;
            this.eof = DFA50_eof;
            this.min = DFA50_min;
            this.max = DFA50_max;
            this.accept = DFA50_accept;
            this.special = DFA50_special;
            this.transition = DFA50_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 662:4: ( CONCAT additiveExpression )*"; }
        }

    }

    const string DFA53_eotS =
        "\x28\uffff";
    const string DFA53_eofS =
        "\x01\x01\x27\uffff";
    const string DFA53_minS =
        "\x01\x06\x27\uffff";
    const string DFA53_maxS =
        "\x01\x7f\x27\uffff";
    const string DFA53_acceptS =
        "\x01\uffff\x01\x02\x24\uffff\x01\x01\x01\uffff";
    const string DFA53_specialS =
        "\x28\uffff}>";
    static readonly string[] DFA53_transitionS = {
            "\x03\x01\x01\uffff\x01\x01\x03\uffff\x01\x01\x03\uffff\x01\x01"+
            "\x03\uffff\x05\x01\x01\uffff\x01\x01\x02\uffff\x04\x01\x03\uffff"+
            "\x01\x01\x01\uffff\x02\x01\x02\uffff\x01\x01\x05\uffff\x01\x01"+
            "\x02\uffff\x01\x01\x04\uffff\x01\x01\x06\uffff\x01\x01\x20\uffff"+
            "\x02\x01\x01\uffff\x08\x01\x02\x26\x03\uffff\x01\x01\x0b\uffff"+
            "\x02\x01",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA53_eot = DFA.UnpackEncodedString(DFA53_eotS);
    static readonly short[] DFA53_eof = DFA.UnpackEncodedString(DFA53_eofS);
    static readonly char[] DFA53_min = DFA.UnpackEncodedStringToUnsignedChars(DFA53_minS);
    static readonly char[] DFA53_max = DFA.UnpackEncodedStringToUnsignedChars(DFA53_maxS);
    static readonly short[] DFA53_accept = DFA.UnpackEncodedString(DFA53_acceptS);
    static readonly short[] DFA53_special = DFA.UnpackEncodedString(DFA53_specialS);
    static readonly short[][] DFA53_transition = DFA.UnpackEncodedStringArray(DFA53_transitionS);

    protected class DFA53 : DFA
    {
        public DFA53(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 53;
            this.eot = DFA53_eot;
            this.eof = DFA53_eof;
            this.min = DFA53_min;
            this.max = DFA53_max;
            this.accept = DFA53_accept;
            this.special = DFA53_special;
            this.transition = DFA53_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 668:23: ( ( PLUS | MINUS ) multiplyExpression )*"; }
        }

    }

    const string DFA55_eotS =
        "\x2a\uffff";
    const string DFA55_eofS =
        "\x01\x01\x29\uffff";
    const string DFA55_minS =
        "\x01\x06\x29\uffff";
    const string DFA55_maxS =
        "\x01\x7f\x29\uffff";
    const string DFA55_acceptS =
        "\x01\uffff\x01\x02\x26\uffff\x01\x01\x01\uffff";
    const string DFA55_specialS =
        "\x2a\uffff}>";
    static readonly string[] DFA55_transitionS = {
            "\x03\x01\x01\uffff\x01\x01\x03\uffff\x01\x01\x03\uffff\x01\x01"+
            "\x03\uffff\x05\x01\x01\uffff\x01\x01\x02\uffff\x04\x01\x03\uffff"+
            "\x01\x01\x01\uffff\x02\x01\x02\uffff\x01\x01\x05\uffff\x01\x01"+
            "\x02\uffff\x01\x01\x04\uffff\x01\x01\x06\uffff\x01\x01\x20\uffff"+
            "\x02\x01\x01\uffff\x0a\x01\x02\x28\x01\uffff\x01\x01\x0b\uffff"+
            "\x02\x01",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA55_eot = DFA.UnpackEncodedString(DFA55_eotS);
    static readonly short[] DFA55_eof = DFA.UnpackEncodedString(DFA55_eofS);
    static readonly char[] DFA55_min = DFA.UnpackEncodedStringToUnsignedChars(DFA55_minS);
    static readonly char[] DFA55_max = DFA.UnpackEncodedStringToUnsignedChars(DFA55_maxS);
    static readonly short[] DFA55_accept = DFA.UnpackEncodedString(DFA55_acceptS);
    static readonly short[] DFA55_special = DFA.UnpackEncodedString(DFA55_specialS);
    static readonly short[][] DFA55_transition = DFA.UnpackEncodedStringArray(DFA55_transitionS);

    protected class DFA55 : DFA
    {
        public DFA55(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 55;
            this.eot = DFA55_eot;
            this.eof = DFA55_eof;
            this.min = DFA55_min;
            this.max = DFA55_max;
            this.accept = DFA55_accept;
            this.special = DFA55_special;
            this.transition = DFA55_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 673:20: ( ( STAR | DIV ) unaryExpression )*"; }
        }

    }

    const string DFA56_eotS =
        "\x14\uffff";
    const string DFA56_eofS =
        "\x14\uffff";
    const string DFA56_minS =
        "\x01\x04\x13\uffff";
    const string DFA56_maxS =
        "\x01\x76\x13\uffff";
    const string DFA56_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x01\x03\x01\x04\x03\uffff\x01\x05\x0b"+
        "\uffff";
    const string DFA56_specialS =
        "\x14\uffff}>";
    static readonly string[] DFA56_transitionS = {
            "\x02\x04\x03\uffff\x01\x08\x02\uffff\x01\x08\x04\uffff\x01\x08"+
            "\x01\uffff\x01\x04\x01\x08\x06\uffff\x01\x08\x07\uffff\x02\x08"+
            "\x02\uffff\x01\x08\x07\uffff\x01\x04\x02\x08\x05\uffff\x01\x03"+
            "\x07\uffff\x01\x08\x1d\uffff\x04\x08\x03\uffff\x01\x08\x08\uffff"+
            "\x01\x02\x01\x01\x04\uffff\x04\x08",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA56_eot = DFA.UnpackEncodedString(DFA56_eotS);
    static readonly short[] DFA56_eof = DFA.UnpackEncodedString(DFA56_eofS);
    static readonly char[] DFA56_min = DFA.UnpackEncodedStringToUnsignedChars(DFA56_minS);
    static readonly char[] DFA56_max = DFA.UnpackEncodedStringToUnsignedChars(DFA56_maxS);
    static readonly short[] DFA56_accept = DFA.UnpackEncodedString(DFA56_acceptS);
    static readonly short[] DFA56_special = DFA.UnpackEncodedString(DFA56_specialS);
    static readonly short[][] DFA56_transition = DFA.UnpackEncodedStringArray(DFA56_transitionS);

    protected class DFA56 : DFA
    {
        public DFA56(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 56;
            this.eot = DFA56_eot;
            this.eof = DFA56_eof;
            this.min = DFA56_min;
            this.max = DFA56_max;
            this.accept = DFA56_accept;
            this.special = DFA56_special;
            this.transition = DFA56_transition;

        }

        override public string Description
        {
            get { return "687:1: unaryExpression : (m= MINUS mu= unaryExpression | p= PLUS pu= unaryExpression | c= caseExpression | q= quantifiedExpression | a= atom -> {m != null}? ^( UNARY_MINUS[$m] $mu) -> {p != null}? ^( UNARY_PLUS[$p] $pu) -> {c != null}? ^( $c) -> {q != null}? ^( $q) -> ^( $a) );"; }
        }

    }

    const string DFA61_eotS =
        "\x16\uffff";
    const string DFA61_eofS =
        "\x16\uffff";
    const string DFA61_minS =
        "\x01\x37\x01\x04\x14\uffff";
    const string DFA61_maxS =
        "\x01\x37\x01\x76\x14\uffff";
    const string DFA61_acceptS =
        "\x02\uffff\x01\x01\x01\x02\x12\uffff";
    const string DFA61_specialS =
        "\x16\uffff}>";
    static readonly string[] DFA61_transitionS = {
            "\x01\x01",
            "\x02\x03\x03\uffff\x01\x03\x02\uffff\x01\x03\x04\uffff\x01"+
            "\x03\x01\uffff\x02\x03\x06\uffff\x01\x03\x07\uffff\x02\x03\x02"+
            "\uffff\x01\x03\x07\uffff\x03\x03\x05\uffff\x01\x03\x03\uffff"+
            "\x01\x02\x03\uffff\x01\x03\x1d\uffff\x04\x03\x03\uffff\x01\x03"+
            "\x08\uffff\x02\x03\x04\uffff\x04\x03",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA61_eot = DFA.UnpackEncodedString(DFA61_eotS);
    static readonly short[] DFA61_eof = DFA.UnpackEncodedString(DFA61_eofS);
    static readonly char[] DFA61_min = DFA.UnpackEncodedStringToUnsignedChars(DFA61_minS);
    static readonly char[] DFA61_max = DFA.UnpackEncodedStringToUnsignedChars(DFA61_maxS);
    static readonly short[] DFA61_accept = DFA.UnpackEncodedString(DFA61_acceptS);
    static readonly short[] DFA61_special = DFA.UnpackEncodedString(DFA61_specialS);
    static readonly short[][] DFA61_transition = DFA.UnpackEncodedStringArray(DFA61_transitionS);

    protected class DFA61 : DFA
    {
        public DFA61(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 61;
            this.eot = DFA61_eot;
            this.eof = DFA61_eof;
            this.min = DFA61_min;
            this.max = DFA61_max;
            this.accept = DFA61_accept;
            this.special = DFA61_special;
            this.transition = DFA61_transition;

        }

        override public string Description
        {
            get { return "708:1: caseExpression : ( CASE ( whenClause )+ ( elseClause )? END -> ^( CASE whenClause ( elseClause )? ) | CASE unaryExpression ( altWhenClause )+ ( elseClause )? END -> ^( CASE2 unaryExpression ( altWhenClause )+ ( elseClause )? ) );"; }
        }

    }

    const string DFA65_eotS =
        "\x2f\uffff";
    const string DFA65_eofS =
        "\x01\x01\x2e\uffff";
    const string DFA65_minS =
        "\x01\x06\x2e\uffff";
    const string DFA65_maxS =
        "\x01\x7f\x2e\uffff";
    const string DFA65_acceptS =
        "\x01\uffff\x01\x03\x2b\uffff\x01\x01\x01\x02";
    const string DFA65_specialS =
        "\x2f\uffff}>";
    static readonly string[] DFA65_transitionS = {
            "\x03\x01\x01\uffff\x01\x01\x03\uffff\x01\x01\x01\x2d\x02\uffff"+
            "\x01\x01\x03\uffff\x05\x01\x01\uffff\x01\x01\x02\uffff\x04\x01"+
            "\x03\uffff\x01\x01\x01\uffff\x02\x01\x02\uffff\x01\x01\x05\uffff"+
            "\x01\x01\x02\uffff\x01\x01\x02\uffff\x04\x01\x05\uffff\x01\x01"+
            "\x20\uffff\x02\x01\x01\uffff\x0c\x01\x01\x2e\x01\x01\x0b\uffff"+
            "\x02\x01",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA65_eot = DFA.UnpackEncodedString(DFA65_eotS);
    static readonly short[] DFA65_eof = DFA.UnpackEncodedString(DFA65_eofS);
    static readonly char[] DFA65_min = DFA.UnpackEncodedStringToUnsignedChars(DFA65_minS);
    static readonly char[] DFA65_max = DFA.UnpackEncodedStringToUnsignedChars(DFA65_maxS);
    static readonly short[] DFA65_accept = DFA.UnpackEncodedString(DFA65_acceptS);
    static readonly short[] DFA65_special = DFA.UnpackEncodedString(DFA65_specialS);
    static readonly short[][] DFA65_transition = DFA.UnpackEncodedStringArray(DFA65_transitionS);

    protected class DFA65 : DFA
    {
        public DFA65(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 65;
            this.eot = DFA65_eot;
            this.eof = DFA65_eof;
            this.min = DFA65_min;
            this.max = DFA65_max;
            this.accept = DFA65_accept;
            this.special = DFA65_special;
            this.transition = DFA65_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 749:3: ( DOT identifier ( options {greedy=true; } : (op= OPEN exprList CLOSE ) )? | lb= OPEN_BRACKET expression CLOSE_BRACKET )*"; }
        }

    }

    const string DFA64_eotS =
        "\x30\uffff";
    const string DFA64_eofS =
        "\x01\x02\x2f\uffff";
    const string DFA64_minS =
        "\x01\x06\x2f\uffff";
    const string DFA64_maxS =
        "\x01\x7f\x2f\uffff";
    const string DFA64_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x2d\uffff";
    const string DFA64_specialS =
        "\x30\uffff}>";
    static readonly string[] DFA64_transitionS = {
            "\x03\x02\x01\uffff\x01\x02\x03\uffff\x02\x02\x02\uffff\x01\x02"+
            "\x03\uffff\x05\x02\x01\uffff\x01\x02\x02\uffff\x04\x02\x03\uffff"+
            "\x01\x02\x01\uffff\x02\x02\x02\uffff\x01\x02\x05\uffff\x01\x02"+
            "\x02\uffff\x01\x02\x02\uffff\x04\x02\x05\uffff\x01\x02\x20\uffff"+
            "\x02\x02\x01\x01\x0e\x02\x0b\uffff\x02\x02",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA64_eot = DFA.UnpackEncodedString(DFA64_eotS);
    static readonly short[] DFA64_eof = DFA.UnpackEncodedString(DFA64_eofS);
    static readonly char[] DFA64_min = DFA.UnpackEncodedStringToUnsignedChars(DFA64_minS);
    static readonly char[] DFA64_max = DFA.UnpackEncodedStringToUnsignedChars(DFA64_maxS);
    static readonly short[] DFA64_accept = DFA.UnpackEncodedString(DFA64_acceptS);
    static readonly short[] DFA64_special = DFA.UnpackEncodedString(DFA64_specialS);
    static readonly short[][] DFA64_transition = DFA.UnpackEncodedStringArray(DFA64_transitionS);

    protected class DFA64 : DFA
    {
        public DFA64(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 64;
            this.eot = DFA64_eot;
            this.eof = DFA64_eof;
            this.min = DFA64_min;
            this.max = DFA64_max;
            this.accept = DFA64_accept;
            this.special = DFA64_special;
            this.transition = DFA64_transition;

        }

        override public string Description
        {
            get { return "751:5: ( options {greedy=true; } : (op= OPEN exprList CLOSE ) )?"; }
        }

    }

    const string DFA69_eotS =
        "\x0d\uffff";
    const string DFA69_eofS =
        "\x0d\uffff";
    const string DFA69_minS =
        "\x01\x09\x0c\uffff";
    const string DFA69_maxS =
        "\x01\x76\x0c\uffff";
    const string DFA69_acceptS =
        "\x01\uffff\x01\x01\x07\uffff\x01\x02\x01\x03\x01\x04\x01\x05";
    const string DFA69_specialS =
        "\x0d\uffff}>";
    static readonly string[] DFA69_transitionS = {
            "\x01\x01\x02\uffff\x01\x01\x04\uffff\x01\x01\x02\uffff\x01\x09"+
            "\x06\uffff\x01\x01\x07\uffff\x02\x01\x02\uffff\x01\x09\x08\uffff"+
            "\x01\x01\x01\x09\x0d\uffff\x01\x09\x1d\uffff\x04\x09\x03\uffff"+
            "\x01\x0b\x0e\uffff\x01\x0a\x01\x0c\x01\x09\x01\x01",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA69_eot = DFA.UnpackEncodedString(DFA69_eotS);
    static readonly short[] DFA69_eof = DFA.UnpackEncodedString(DFA69_eofS);
    static readonly char[] DFA69_min = DFA.UnpackEncodedStringToUnsignedChars(DFA69_minS);
    static readonly char[] DFA69_max = DFA.UnpackEncodedStringToUnsignedChars(DFA69_maxS);
    static readonly short[] DFA69_accept = DFA.UnpackEncodedString(DFA69_acceptS);
    static readonly short[] DFA69_special = DFA.UnpackEncodedString(DFA69_specialS);
    static readonly short[][] DFA69_transition = DFA.UnpackEncodedStringArray(DFA69_transitionS);

    protected class DFA69 : DFA
    {
        public DFA69(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 69;
            this.eot = DFA69_eot;
            this.eof = DFA69_eof;
            this.min = DFA69_min;
            this.max = DFA69_max;
            this.accept = DFA69_accept;
            this.special = DFA69_special;
            this.transition = DFA69_transition;

        }

        override public string Description
        {
            get { return "758:1: primaryExpression : ( identPrimary ( options {greedy=true; } : DOT 'class' )? | constant | COLON identifier | OPEN ( expressionOrVector | subQuery ) CLOSE | PARAM ( NUM_INT )? );"; }
        }

    }

    const string DFA66_eotS =
        "\x31\uffff";
    const string DFA66_eofS =
        "\x01\x02\x30\uffff";
    const string DFA66_minS =
        "\x01\x06\x01\x0b\x2f\uffff";
    const string DFA66_maxS =
        "\x01\x7f\x01\x76\x2f\uffff";
    const string DFA66_acceptS =
        "\x02\uffff\x01\x02\x2c\uffff\x01\x01\x01\uffff";
    const string DFA66_specialS =
        "\x31\uffff}>";
    static readonly string[] DFA66_transitionS = {
            "\x03\x02\x01\uffff\x01\x02\x03\uffff\x01\x02\x01\x01\x02\uffff"+
            "\x01\x02\x03\uffff\x05\x02\x01\uffff\x01\x02\x02\uffff\x04\x02"+
            "\x03\uffff\x01\x02\x01\uffff\x02\x02\x02\uffff\x01\x02\x05\uffff"+
            "\x01\x02\x02\uffff\x01\x02\x02\uffff\x04\x02\x05\uffff\x01\x02"+
            "\x20\uffff\x02\x02\x01\uffff\x0e\x02\x0b\uffff\x02\x02",
            "\x01\x2f\x6a\uffff\x01\x02",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA66_eot = DFA.UnpackEncodedString(DFA66_eotS);
    static readonly short[] DFA66_eof = DFA.UnpackEncodedString(DFA66_eofS);
    static readonly char[] DFA66_min = DFA.UnpackEncodedStringToUnsignedChars(DFA66_minS);
    static readonly char[] DFA66_max = DFA.UnpackEncodedStringToUnsignedChars(DFA66_maxS);
    static readonly short[] DFA66_accept = DFA.UnpackEncodedString(DFA66_acceptS);
    static readonly short[] DFA66_special = DFA.UnpackEncodedString(DFA66_specialS);
    static readonly short[][] DFA66_transition = DFA.UnpackEncodedStringArray(DFA66_transitionS);

    protected class DFA66 : DFA
    {
        public DFA66(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 66;
            this.eot = DFA66_eot;
            this.eof = DFA66_eof;
            this.min = DFA66_min;
            this.max = DFA66_max;
            this.accept = DFA66_accept;
            this.special = DFA66_special;
            this.transition = DFA66_transition;

        }

        override public string Description
        {
            get { return "759:19: ( options {greedy=true; } : DOT 'class' )?"; }
        }

    }

    const string DFA67_eotS =
        "\x1c\uffff";
    const string DFA67_eofS =
        "\x1c\uffff";
    const string DFA67_minS =
        "\x01\x04\x1b\uffff";
    const string DFA67_maxS =
        "\x01\x76\x1b\uffff";
    const string DFA67_acceptS =
        "\x01\uffff\x01\x01\x13\uffff\x01\x02\x06\uffff";
    const string DFA67_specialS =
        "\x1c\uffff}>";
    static readonly string[] DFA67_transitionS = {
            "\x02\x01\x03\uffff\x01\x01\x02\uffff\x01\x01\x04\uffff\x01\x01"+
            "\x01\uffff\x02\x01\x01\uffff\x01\x15\x01\uffff\x01\x15\x02\uffff"+
            "\x01\x01\x07\uffff\x02\x01\x01\uffff\x02\x01\x01\uffff\x01\x15"+
            "\x03\uffff\x01\x15\x01\uffff\x03\x01\x01\x15\x02\uffff\x01\x15"+
            "\x01\uffff\x01\x01\x07\uffff\x01\x01\x1d\uffff\x04\x01\x03\uffff"+
            "\x01\x01\x01\x15\x07\uffff\x02\x01\x04\uffff\x04\x01",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA67_eot = DFA.UnpackEncodedString(DFA67_eotS);
    static readonly short[] DFA67_eof = DFA.UnpackEncodedString(DFA67_eofS);
    static readonly char[] DFA67_min = DFA.UnpackEncodedStringToUnsignedChars(DFA67_minS);
    static readonly char[] DFA67_max = DFA.UnpackEncodedStringToUnsignedChars(DFA67_maxS);
    static readonly short[] DFA67_accept = DFA.UnpackEncodedString(DFA67_acceptS);
    static readonly short[] DFA67_special = DFA.UnpackEncodedString(DFA67_specialS);
    static readonly short[][] DFA67_transition = DFA.UnpackEncodedStringArray(DFA67_transitionS);

    protected class DFA67 : DFA
    {
        public DFA67(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 67;
            this.eot = DFA67_eot;
            this.eof = DFA67_eof;
            this.min = DFA67_min;
            this.max = DFA67_max;
            this.accept = DFA67_accept;
            this.special = DFA67_special;
            this.transition = DFA67_transition;

        }

        override public string Description
        {
            get { return "763:12: ( expressionOrVector | subQuery )"; }
        }

    }

    const string DFA68_eotS =
        "\x30\uffff";
    const string DFA68_eofS =
        "\x01\x02\x2f\uffff";
    const string DFA68_minS =
        "\x01\x06\x2f\uffff";
    const string DFA68_maxS =
        "\x01\x7f\x2f\uffff";
    const string DFA68_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x2d\uffff";
    const string DFA68_specialS =
        "\x30\uffff}>";
    static readonly string[] DFA68_transitionS = {
            "\x03\x02\x01\uffff\x01\x02\x03\uffff\x02\x02\x02\uffff\x01\x02"+
            "\x03\uffff\x05\x02\x01\uffff\x01\x02\x02\uffff\x04\x02\x03\uffff"+
            "\x01\x02\x01\uffff\x02\x02\x02\uffff\x01\x02\x05\uffff\x01\x02"+
            "\x02\uffff\x01\x02\x02\uffff\x04\x02\x05\uffff\x01\x02\x1b\uffff"+
            "\x01\x01\x04\uffff\x02\x02\x01\uffff\x0e\x02\x0b\uffff\x02\x02",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA68_eot = DFA.UnpackEncodedString(DFA68_eotS);
    static readonly short[] DFA68_eof = DFA.UnpackEncodedString(DFA68_eofS);
    static readonly char[] DFA68_min = DFA.UnpackEncodedStringToUnsignedChars(DFA68_minS);
    static readonly char[] DFA68_max = DFA.UnpackEncodedStringToUnsignedChars(DFA68_maxS);
    static readonly short[] DFA68_accept = DFA.UnpackEncodedString(DFA68_acceptS);
    static readonly short[] DFA68_special = DFA.UnpackEncodedString(DFA68_specialS);
    static readonly short[][] DFA68_transition = DFA.UnpackEncodedStringArray(DFA68_transitionS);

    protected class DFA68 : DFA
    {
        public DFA68(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 68;
            this.eot = DFA68_eot;
            this.eof = DFA68_eof;
            this.min = DFA68_min;
            this.max = DFA68_max;
            this.accept = DFA68_accept;
            this.special = DFA68_special;
            this.transition = DFA68_transition;

        }

        override public string Description
        {
            get { return "764:13: ( NUM_INT )?"; }
        }

    }

    const string DFA73_eotS =
        "\x34\uffff";
    const string DFA73_eofS =
        "\x01\x01\x33\uffff";
    const string DFA73_minS =
        "\x01\x06\x01\uffff\x01\x0b\x31\uffff";
    const string DFA73_maxS =
        "\x01\x7f\x01\uffff\x01\x76\x31\uffff";
    const string DFA73_acceptS =
        "\x01\uffff\x01\x02\x2f\uffff\x01\x01\x02\uffff";
    const string DFA73_specialS =
        "\x34\uffff}>";
    static readonly string[] DFA73_transitionS = {
            "\x03\x01\x01\uffff\x01\x01\x03\uffff\x01\x01\x01\x02\x02\uffff"+
            "\x01\x01\x03\uffff\x05\x01\x01\uffff\x01\x01\x02\uffff\x04\x01"+
            "\x03\uffff\x01\x01\x01\uffff\x02\x01\x02\uffff\x01\x01\x05\uffff"+
            "\x01\x01\x02\uffff\x01\x01\x02\uffff\x04\x01\x05\uffff\x01\x01"+
            "\x20\uffff\x11\x01\x0b\uffff\x02\x01",
            "",
            "\x01\x01\x05\uffff\x01\x31\x30\uffff\x01\x31\x33\uffff\x01"+
            "\x31",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA73_eot = DFA.UnpackEncodedString(DFA73_eotS);
    static readonly short[] DFA73_eof = DFA.UnpackEncodedString(DFA73_eofS);
    static readonly char[] DFA73_min = DFA.UnpackEncodedStringToUnsignedChars(DFA73_minS);
    static readonly char[] DFA73_max = DFA.UnpackEncodedStringToUnsignedChars(DFA73_maxS);
    static readonly short[] DFA73_accept = DFA.UnpackEncodedString(DFA73_acceptS);
    static readonly short[] DFA73_special = DFA.UnpackEncodedString(DFA73_specialS);
    static readonly short[][] DFA73_transition = DFA.UnpackEncodedStringArray(DFA73_transitionS);

    protected class DFA73 : DFA
    {
        public DFA73(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 73;
            this.eot = DFA73_eot;
            this.eof = DFA73_eof;
            this.min = DFA73_min;
            this.max = DFA73_max;
            this.accept = DFA73_accept;
            this.special = DFA73_special;
            this.transition = DFA73_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 808:4: ( options {greedy=true; } : d= DOT (id2= identifier | e= ELEMENTS | o= OBJECT ) )*"; }
        }

    }

    const string DFA74_eotS =
        "\x30\uffff";
    const string DFA74_eofS =
        "\x01\x02\x2f\uffff";
    const string DFA74_minS =
        "\x01\x06\x2f\uffff";
    const string DFA74_maxS =
        "\x01\x7f\x2f\uffff";
    const string DFA74_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x2d\uffff";
    const string DFA74_specialS =
        "\x30\uffff}>";
    static readonly string[] DFA74_transitionS = {
            "\x03\x02\x01\uffff\x01\x02\x03\uffff\x02\x02\x02\uffff\x01\x02"+
            "\x03\uffff\x05\x02\x01\uffff\x01\x02\x02\uffff\x04\x02\x03\uffff"+
            "\x01\x02\x01\uffff\x02\x02\x02\uffff\x01\x02\x05\uffff\x01\x02"+
            "\x02\uffff\x01\x02\x02\uffff\x04\x02\x05\uffff\x01\x02\x20\uffff"+
            "\x02\x02\x01\x01\x0e\x02\x0b\uffff\x02\x02",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA74_eot = DFA.UnpackEncodedString(DFA74_eotS);
    static readonly short[] DFA74_eof = DFA.UnpackEncodedString(DFA74_eofS);
    static readonly char[] DFA74_min = DFA.UnpackEncodedStringToUnsignedChars(DFA74_minS);
    static readonly char[] DFA74_max = DFA.UnpackEncodedStringToUnsignedChars(DFA74_maxS);
    static readonly short[] DFA74_accept = DFA.UnpackEncodedString(DFA74_acceptS);
    static readonly short[] DFA74_special = DFA.UnpackEncodedString(DFA74_specialS);
    static readonly short[][] DFA74_transition = DFA.UnpackEncodedStringArray(DFA74_transitionS);

    protected class DFA74 : DFA
    {
        public DFA74(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 74;
            this.eot = DFA74_eot;
            this.eof = DFA74_eof;
            this.min = DFA74_min;
            this.max = DFA74_max;
            this.accept = DFA74_accept;
            this.special = DFA74_special;
            this.transition = DFA74_transition;

        }

        override public string Description
        {
            get { return "813:4: ( options {greedy=true; } : opx= (op= OPEN exprList CLOSE ) )?"; }
        }

    }

    const string DFA83_eotS =
        "\x1c\uffff";
    const string DFA83_eofS =
        "\x1c\uffff";
    const string DFA83_minS =
        "\x01\x04\x1b\uffff";
    const string DFA83_maxS =
        "\x01\x76\x1b\uffff";
    const string DFA83_acceptS =
        "\x01\uffff\x01\x01\x13\uffff\x01\x02\x06\uffff";
    const string DFA83_specialS =
        "\x1c\uffff}>";
    static readonly string[] DFA83_transitionS = {
            "\x02\x01\x03\uffff\x01\x01\x02\uffff\x01\x01\x04\uffff\x01\x01"+
            "\x01\uffff\x02\x01\x01\uffff\x01\x15\x01\uffff\x01\x15\x02\uffff"+
            "\x01\x01\x07\uffff\x02\x01\x01\uffff\x02\x01\x01\uffff\x01\x15"+
            "\x03\uffff\x01\x15\x01\uffff\x03\x01\x01\x15\x02\uffff\x01\x15"+
            "\x01\uffff\x01\x01\x07\uffff\x01\x01\x1d\uffff\x04\x01\x03\uffff"+
            "\x01\x01\x01\x15\x07\uffff\x02\x01\x04\uffff\x04\x01",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA83_eot = DFA.UnpackEncodedString(DFA83_eotS);
    static readonly short[] DFA83_eof = DFA.UnpackEncodedString(DFA83_eofS);
    static readonly char[] DFA83_min = DFA.UnpackEncodedStringToUnsignedChars(DFA83_minS);
    static readonly char[] DFA83_max = DFA.UnpackEncodedStringToUnsignedChars(DFA83_maxS);
    static readonly short[] DFA83_accept = DFA.UnpackEncodedString(DFA83_acceptS);
    static readonly short[] DFA83_special = DFA.UnpackEncodedString(DFA83_specialS);
    static readonly short[][] DFA83_transition = DFA.UnpackEncodedStringArray(DFA83_transitionS);

    protected class DFA83 : DFA
    {
        public DFA83(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 83;
            this.eot = DFA83_eot;
            this.eof = DFA83_eof;
            this.min = DFA83_min;
            this.max = DFA83_max;
            this.accept = DFA83_accept;
            this.special = DFA83_special;
            this.transition = DFA83_transition;

        }

        override public string Description
        {
            get { return "858:11: ( ( expression ( COMMA expression )* ) | subQuery )"; }
        }

    }

    const string DFA85_eotS =
        "\x18\uffff";
    const string DFA85_eofS =
        "\x18\uffff";
    const string DFA85_minS =
        "\x01\x04\x17\uffff";
    const string DFA85_maxS =
        "\x01\x76\x17\uffff";
    const string DFA85_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x15\uffff";
    const string DFA85_specialS =
        "\x18\uffff}>";
    static readonly string[] DFA85_transitionS = {
            "\x02\x02\x03\uffff\x01\x02\x02\uffff\x01\x02\x04\uffff\x01\x02"+
            "\x01\uffff\x02\x02\x01\uffff\x01\x02\x04\uffff\x01\x02\x07\uffff"+
            "\x02\x02\x01\uffff\x02\x02\x07\uffff\x03\x02\x05\uffff\x01\x02"+
            "\x06\uffff\x01\x01\x01\x02\x01\x01\x03\uffff\x01\x01\x18\uffff"+
            "\x04\x02\x03\uffff\x02\x02\x07\uffff\x02\x02\x04\uffff\x04\x02",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA85_eot = DFA.UnpackEncodedString(DFA85_eotS);
    static readonly short[] DFA85_eof = DFA.UnpackEncodedString(DFA85_eofS);
    static readonly char[] DFA85_min = DFA.UnpackEncodedStringToUnsignedChars(DFA85_minS);
    static readonly char[] DFA85_max = DFA.UnpackEncodedStringToUnsignedChars(DFA85_maxS);
    static readonly short[] DFA85_accept = DFA.UnpackEncodedString(DFA85_acceptS);
    static readonly short[] DFA85_special = DFA.UnpackEncodedString(DFA85_specialS);
    static readonly short[][] DFA85_transition = DFA.UnpackEncodedStringArray(DFA85_transitionS);

    protected class DFA85 : DFA
    {
        public DFA85(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 85;
            this.eot = DFA85_eot;
            this.eof = DFA85_eof;
            this.min = DFA85_min;
            this.max = DFA85_max;
            this.accept = DFA85_accept;
            this.special = DFA85_special;
            this.transition = DFA85_transition;

        }

        override public string Description
        {
            get { return "889:6: (ts= ( TRAILING | LEADING | BOTH ) )?"; }
        }

    }

    const string DFA89_eotS =
        "\x17\uffff";
    const string DFA89_eofS =
        "\x17\uffff";
    const string DFA89_minS =
        "\x01\x04\x16\uffff";
    const string DFA89_maxS =
        "\x01\x76\x16\uffff";
    const string DFA89_acceptS =
        "\x01\uffff\x01\x01\x14\uffff\x01\x02";
    const string DFA89_specialS =
        "\x17\uffff}>";
    static readonly string[] DFA89_transitionS = {
            "\x02\x01\x03\uffff\x01\x01\x02\uffff\x01\x01\x04\uffff\x01\x01"+
            "\x01\uffff\x02\x01\x01\uffff\x01\x01\x04\uffff\x01\x01\x07\uffff"+
            "\x02\x01\x01\uffff\x02\x01\x07\uffff\x03\x01\x05\uffff\x01\x01"+
            "\x07\uffff\x01\x01\x1d\uffff\x04\x01\x03\uffff\x01\x01\x01\x16"+
            "\x07\uffff\x02\x01\x04\uffff\x04\x01",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA89_eot = DFA.UnpackEncodedString(DFA89_eotS);
    static readonly short[] DFA89_eof = DFA.UnpackEncodedString(DFA89_eofS);
    static readonly char[] DFA89_min = DFA.UnpackEncodedStringToUnsignedChars(DFA89_minS);
    static readonly char[] DFA89_max = DFA.UnpackEncodedStringToUnsignedChars(DFA89_maxS);
    static readonly short[] DFA89_accept = DFA.UnpackEncodedString(DFA89_acceptS);
    static readonly short[] DFA89_special = DFA.UnpackEncodedString(DFA89_specialS);
    static readonly short[][] DFA89_transition = DFA.UnpackEncodedStringArray(DFA89_transitionS);

    protected class DFA89 : DFA
    {
        public DFA89(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 89;
            this.eot = DFA89_eot;
            this.eof = DFA89_eof;
            this.min = DFA89_min;
            this.max = DFA89_max;
            this.accept = DFA89_accept;
            this.special = DFA89_special;
            this.transition = DFA89_transition;

        }

        override public string Description
        {
            get { return "893:5: (r= ( expression ( ( COMMA expression )+ | FROM expression | AS identifier )? | FROM expression ) )?"; }
        }

    }

    const string DFA88_eotS =
        "\x16\uffff";
    const string DFA88_eofS =
        "\x16\uffff";
    const string DFA88_minS =
        "\x01\x04\x15\uffff";
    const string DFA88_maxS =
        "\x01\x76\x15\uffff";
    const string DFA88_acceptS =
        "\x01\uffff\x01\x01\x13\uffff\x01\x02";
    const string DFA88_specialS =
        "\x16\uffff}>";
    static readonly string[] DFA88_transitionS = {
            "\x02\x01\x03\uffff\x01\x01\x02\uffff\x01\x01\x04\uffff\x01\x01"+
            "\x01\uffff\x02\x01\x01\uffff\x01\x15\x04\uffff\x01\x01\x07\uffff"+
            "\x02\x01\x01\uffff\x02\x01\x07\uffff\x03\x01\x05\uffff\x01\x01"+
            "\x07\uffff\x01\x01\x1d\uffff\x04\x01\x03\uffff\x01\x01\x08\uffff"+
            "\x02\x01\x04\uffff\x04\x01",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA88_eot = DFA.UnpackEncodedString(DFA88_eotS);
    static readonly short[] DFA88_eof = DFA.UnpackEncodedString(DFA88_eofS);
    static readonly char[] DFA88_min = DFA.UnpackEncodedStringToUnsignedChars(DFA88_minS);
    static readonly char[] DFA88_max = DFA.UnpackEncodedStringToUnsignedChars(DFA88_maxS);
    static readonly short[] DFA88_accept = DFA.UnpackEncodedString(DFA88_acceptS);
    static readonly short[] DFA88_special = DFA.UnpackEncodedString(DFA88_specialS);
    static readonly short[][] DFA88_transition = DFA.UnpackEncodedStringArray(DFA88_transitionS);

    protected class DFA88 : DFA
    {
        public DFA88(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 88;
            this.eot = DFA88_eot;
            this.eof = DFA88_eof;
            this.min = DFA88_min;
            this.max = DFA88_max;
            this.accept = DFA88_accept;
            this.special = DFA88_special;
            this.transition = DFA88_transition;

        }

        override public string Description
        {
            get { return "893:6: ( expression ( ( COMMA expression )+ | FROM expression | AS identifier )? | FROM expression )"; }
        }

    }

    const string DFA90_eotS =
        "\x21\uffff";
    const string DFA90_eofS =
        "\x01\x01\x20\uffff";
    const string DFA90_minS =
        "\x01\x06\x20\uffff";
    const string DFA90_maxS =
        "\x01\x7f\x20\uffff";
    const string DFA90_acceptS =
        "\x01\uffff\x01\x02\x1e\uffff\x01\x01";
    const string DFA90_specialS =
        "\x21\uffff}>";
    static readonly string[] DFA90_transitionS = {
            "\x03\x01\x05\uffff\x01\x01\x01\x20\x05\uffff\x05\x01\x02\uffff"+
            "\x01\x01\x02\uffff\x03\x01\x06\uffff\x02\x01\x02\uffff\x01\x01"+
            "\x01\uffff\x01\x01\x03\uffff\x01\x01\x02\uffff\x01\x01\x04\uffff"+
            "\x01\x01\x02\uffff\x01\x01\x24\uffff\x06\x01\x0a\uffff\x01\x01"+
            "\x03\uffff\x01\x01\x07\uffff\x02\x01",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA90_eot = DFA.UnpackEncodedString(DFA90_eotS);
    static readonly short[] DFA90_eof = DFA.UnpackEncodedString(DFA90_eofS);
    static readonly char[] DFA90_min = DFA.UnpackEncodedStringToUnsignedChars(DFA90_minS);
    static readonly char[] DFA90_max = DFA.UnpackEncodedStringToUnsignedChars(DFA90_maxS);
    static readonly short[] DFA90_accept = DFA.UnpackEncodedString(DFA90_acceptS);
    static readonly short[] DFA90_special = DFA.UnpackEncodedString(DFA90_specialS);
    static readonly short[][] DFA90_transition = DFA.UnpackEncodedStringArray(DFA90_transitionS);

    protected class DFA90 : DFA
    {
        public DFA90(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 90;
            this.eot = DFA90_eot;
            this.eof = DFA90_eof;
            this.min = DFA90_min;
            this.max = DFA90_max;
            this.accept = DFA90_accept;
            this.special = DFA90_special;
            this.transition = DFA90_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 920:15: ( DOT identifier )*"; }
        }

    }

 

    public static readonly BitSet FOLLOW_updateStatement_in_statement603 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_deleteStatement_in_statement607 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_selectStatement_in_statement611 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_insertStatement_in_statement615 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_UPDATE_in_updateStatement628 = new BitSet(new ulong[]{0x0010000000400000UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_VERSIONED_in_updateStatement632 = new BitSet(new ulong[]{0x0010000000400000UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_optionalFromTokenFromClause_in_updateStatement638 = new BitSet(new ulong[]{0x0000400000000000UL});
    public static readonly BitSet FOLLOW_setClause_in_updateStatement642 = new BitSet(new ulong[]{0x0020000000000002UL});
    public static readonly BitSet FOLLOW_whereClause_in_updateStatement647 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SET_in_setClause661 = new BitSet(new ulong[]{0x0010000000400000UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_assignment_in_setClause664 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000400000000UL});
    public static readonly BitSet FOLLOW_COMMA_in_setClause667 = new BitSet(new ulong[]{0x0010000000400000UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_assignment_in_setClause670 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000400000000UL});
    public static readonly BitSet FOLLOW_stateField_in_assignment684 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000800000000UL});
    public static readonly BitSet FOLLOW_EQ_in_assignment686 = new BitSet(new ulong[]{0x80938098085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_newValue_in_assignment689 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_path_in_stateField702 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_concatenation_in_newValue715 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DELETE_in_deleteStatement726 = new BitSet(new ulong[]{0x0010000000400000UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_optionalFromTokenFromClause_in_deleteStatement732 = new BitSet(new ulong[]{0x0020000000000002UL});
    public static readonly BitSet FOLLOW_whereClause_in_deleteStatement738 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FROM_in_optionalFromTokenFromClause754 = new BitSet(new ulong[]{0x0010000000400000UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_path_in_optionalFromTokenFromClause758 = new BitSet(new ulong[]{0x0010000000400082UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_asAlias_in_optionalFromTokenFromClause761 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_queryRule_in_selectStatement796 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_INSERT_in_insertStatement825 = new BitSet(new ulong[]{0x0000000040000000UL});
    public static readonly BitSet FOLLOW_intoClause_in_insertStatement828 = new BitSet(new ulong[]{0x0020220001400000UL});
    public static readonly BitSet FOLLOW_selectStatement_in_insertStatement830 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_INTO_in_intoClause841 = new BitSet(new ulong[]{0x0010000000400000UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_path_in_intoClause844 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000001000000000UL});
    public static readonly BitSet FOLLOW_insertablePropertySpec_in_intoClause848 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_OPEN_in_insertablePropertySpec860 = new BitSet(new ulong[]{0x80938098085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_primaryExpression_in_insertablePropertySpec862 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000002400000000UL});
    public static readonly BitSet FOLLOW_COMMA_in_insertablePropertySpec866 = new BitSet(new ulong[]{0x80938098085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_primaryExpression_in_insertablePropertySpec868 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000002400000000UL});
    public static readonly BitSet FOLLOW_CLOSE_in_insertablePropertySpec873 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_queryRule_in_union900 = new BitSet(new ulong[]{0x0004000000000002UL});
    public static readonly BitSet FOLLOW_UNION_in_union903 = new BitSet(new ulong[]{0x0020220001400000UL});
    public static readonly BitSet FOLLOW_queryRule_in_union905 = new BitSet(new ulong[]{0x0004000000000002UL});
    public static readonly BitSet FOLLOW_selectFrom_in_queryRule921 = new BitSet(new ulong[]{0x0020020001000002UL});
    public static readonly BitSet FOLLOW_whereClause_in_queryRule926 = new BitSet(new ulong[]{0x0000020001000002UL});
    public static readonly BitSet FOLLOW_groupByClause_in_queryRule933 = new BitSet(new ulong[]{0x0000020000000002UL});
    public static readonly BitSet FOLLOW_orderByClause_in_queryRule940 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_selectClause_in_selectFrom961 = new BitSet(new ulong[]{0x0000000000400002UL});
    public static readonly BitSet FOLLOW_fromClause_in_selectFrom968 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SELECT_in_selectClause1018 = new BitSet(new ulong[]{0x809380F8085B1230UL,0x00786011E0000004UL});
    public static readonly BitSet FOLLOW_DISTINCT_in_selectClause1030 = new BitSet(new ulong[]{0x809380F8085B1230UL,0x00786011E0000004UL});
    public static readonly BitSet FOLLOW_selectedPropertiesList_in_selectClause1036 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_newExpression_in_selectClause1040 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_selectObject_in_selectClause1044 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NEW_in_newExpression1060 = new BitSet(new ulong[]{0x0010000000400000UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_path_in_newExpression1062 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000001000000000UL});
    public static readonly BitSet FOLLOW_OPEN_in_newExpression1067 = new BitSet(new ulong[]{0x809380D8085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_selectedPropertiesList_in_newExpression1069 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000002000000000UL});
    public static readonly BitSet FOLLOW_CLOSE_in_newExpression1071 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_OBJECT_in_selectObject1097 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000001000000000UL});
    public static readonly BitSet FOLLOW_OPEN_in_selectObject1100 = new BitSet(new ulong[]{0x0010000000400000UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_selectObject1103 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000002000000000UL});
    public static readonly BitSet FOLLOW_CLOSE_in_selectObject1105 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FROM_in_fromClause1126 = new BitSet(new ulong[]{0x0010000004400080UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_fromRange_in_fromClause1131 = new BitSet(new ulong[]{0x0000100310800002UL,0x0000000400000000UL});
    public static readonly BitSet FOLLOW_fromJoin_in_fromClause1135 = new BitSet(new ulong[]{0x0000100310800002UL,0x0000000400000000UL});
    public static readonly BitSet FOLLOW_COMMA_in_fromClause1139 = new BitSet(new ulong[]{0x0010000004400080UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_fromRange_in_fromClause1144 = new BitSet(new ulong[]{0x0000100310800002UL,0x0000000400000000UL});
    public static readonly BitSet FOLLOW_set_in_fromJoin1165 = new BitSet(new ulong[]{0x0000040100000000UL});
    public static readonly BitSet FOLLOW_OUTER_in_fromJoin1176 = new BitSet(new ulong[]{0x0000000100000000UL});
    public static readonly BitSet FOLLOW_FULL_in_fromJoin1184 = new BitSet(new ulong[]{0x0000000100000000UL});
    public static readonly BitSet FOLLOW_INNER_in_fromJoin1188 = new BitSet(new ulong[]{0x0000000100000000UL});
    public static readonly BitSet FOLLOW_JOIN_in_fromJoin1193 = new BitSet(new ulong[]{0x0010000000600000UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_FETCH_in_fromJoin1197 = new BitSet(new ulong[]{0x0010000000400000UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_path_in_fromJoin1205 = new BitSet(new ulong[]{0x2010000000600082UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_asAlias_in_fromJoin1208 = new BitSet(new ulong[]{0x2000000000200002UL});
    public static readonly BitSet FOLLOW_propertyFetch_in_fromJoin1213 = new BitSet(new ulong[]{0x2000000000000002UL});
    public static readonly BitSet FOLLOW_withClause_in_fromJoin1218 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_WITH_in_withClause1231 = new BitSet(new ulong[]{0x809380D8085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_logicalExpression_in_withClause1234 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_fromClassOrOuterQueryPath_in_fromRange1245 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_inClassDeclaration_in_fromRange1250 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_inCollectionDeclaration_in_fromRange1255 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_inCollectionElementsDeclaration_in_fromRange1260 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_path_in_fromClassOrOuterQueryPath1275 = new BitSet(new ulong[]{0x0010000000600082UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_asAlias_in_fromClassOrOuterQueryPath1280 = new BitSet(new ulong[]{0x0000000000200002UL});
    public static readonly BitSet FOLLOW_propertyFetch_in_fromClassOrOuterQueryPath1285 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_alias_in_inClassDeclaration1318 = new BitSet(new ulong[]{0x0000000004000000UL});
    public static readonly BitSet FOLLOW_IN_in_inClassDeclaration1320 = new BitSet(new ulong[]{0x0000000000000800UL});
    public static readonly BitSet FOLLOW_CLASS_in_inClassDeclaration1322 = new BitSet(new ulong[]{0x0010000000400000UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_path_in_inClassDeclaration1324 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IN_in_inCollectionDeclaration1355 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000001000000000UL});
    public static readonly BitSet FOLLOW_OPEN_in_inCollectionDeclaration1357 = new BitSet(new ulong[]{0x0010000000400000UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_path_in_inCollectionDeclaration1359 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000002000000000UL});
    public static readonly BitSet FOLLOW_CLOSE_in_inCollectionDeclaration1361 = new BitSet(new ulong[]{0x0010000000400080UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_alias_in_inCollectionDeclaration1363 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_alias_in_inCollectionElementsDeclaration1399 = new BitSet(new ulong[]{0x0000000004000000UL});
    public static readonly BitSet FOLLOW_IN_in_inCollectionElementsDeclaration1401 = new BitSet(new ulong[]{0x0000000000020000UL});
    public static readonly BitSet FOLLOW_ELEMENTS_in_inCollectionElementsDeclaration1403 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000001000000000UL});
    public static readonly BitSet FOLLOW_OPEN_in_inCollectionElementsDeclaration1405 = new BitSet(new ulong[]{0x0010000000400000UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_path_in_inCollectionElementsDeclaration1407 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000002000000000UL});
    public static readonly BitSet FOLLOW_CLOSE_in_inCollectionElementsDeclaration1409 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_AS_in_asAlias1440 = new BitSet(new ulong[]{0x0010000000400080UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_alias_in_asAlias1445 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_identifier_in_alias1461 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FETCH_in_propertyFetch1480 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_ALL_in_propertyFetch1482 = new BitSet(new ulong[]{0x0000080000000000UL});
    public static readonly BitSet FOLLOW_PROPERTIES_in_propertyFetch1485 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GROUP_in_groupByClause1500 = new BitSet(new ulong[]{0x0040000000000000UL});
    public static readonly BitSet FOLLOW_LITERAL_by_in_groupByClause1506 = new BitSet(new ulong[]{0x809380D8085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_expression_in_groupByClause1509 = new BitSet(new ulong[]{0x0000000002000002UL,0x0000000400000000UL});
    public static readonly BitSet FOLLOW_COMMA_in_groupByClause1513 = new BitSet(new ulong[]{0x809380D8085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_expression_in_groupByClause1516 = new BitSet(new ulong[]{0x0000000002000002UL,0x0000000400000000UL});
    public static readonly BitSet FOLLOW_havingClause_in_groupByClause1524 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ORDER_in_orderByClause1540 = new BitSet(new ulong[]{0x0040000000000000UL});
    public static readonly BitSet FOLLOW_LITERAL_by_in_orderByClause1543 = new BitSet(new ulong[]{0x809380D8085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_orderElement_in_orderByClause1546 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000400000000UL});
    public static readonly BitSet FOLLOW_COMMA_in_orderByClause1550 = new BitSet(new ulong[]{0x809380D8085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_orderElement_in_orderByClause1553 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000400000000UL});
    public static readonly BitSet FOLLOW_expression_in_orderElement1567 = new BitSet(new ulong[]{0x0000000000004102UL,0xC000000000000000UL});
    public static readonly BitSet FOLLOW_ascendingOrDescending_in_orderElement1571 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ASCENDING_in_ascendingOrDescending1590 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_126_in_ascendingOrDescending1594 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DESCENDING_in_ascendingOrDescending1611 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_127_in_ascendingOrDescending1615 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_HAVING_in_havingClause1638 = new BitSet(new ulong[]{0x809380D8085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_logicalExpression_in_havingClause1641 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_WHERE_in_whereClause1655 = new BitSet(new ulong[]{0x809380D8085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_logicalExpression_in_whereClause1658 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_aliasedExpression_in_selectedPropertiesList1672 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000400000000UL});
    public static readonly BitSet FOLLOW_COMMA_in_selectedPropertiesList1676 = new BitSet(new ulong[]{0x809380D8085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_aliasedExpression_in_selectedPropertiesList1679 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000400000000UL});
    public static readonly BitSet FOLLOW_expression_in_aliasedExpression1694 = new BitSet(new ulong[]{0x0000000000000082UL});
    public static readonly BitSet FOLLOW_AS_in_aliasedExpression1698 = new BitSet(new ulong[]{0x0010000000400000UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_aliasedExpression1701 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_expression_in_logicalExpression1739 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_logicalOrExpression_in_expression1751 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_logicalAndExpression_in_logicalOrExpression1763 = new BitSet(new ulong[]{0x0000010000000002UL});
    public static readonly BitSet FOLLOW_OR_in_logicalOrExpression1767 = new BitSet(new ulong[]{0x809380D8085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_logicalAndExpression_in_logicalOrExpression1770 = new BitSet(new ulong[]{0x0000010000000002UL});
    public static readonly BitSet FOLLOW_negatedExpression_in_logicalAndExpression1785 = new BitSet(new ulong[]{0x0000000000000042UL});
    public static readonly BitSet FOLLOW_AND_in_logicalAndExpression1789 = new BitSet(new ulong[]{0x809380D8085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_negatedExpression_in_logicalAndExpression1792 = new BitSet(new ulong[]{0x0000000000000042UL});
    public static readonly BitSet FOLLOW_NOT_in_negatedExpression1816 = new BitSet(new ulong[]{0x809380D8085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_negatedExpression_in_negatedExpression1820 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_equalityExpression_in_negatedExpression1833 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_relationalExpression_in_equalityExpression1865 = new BitSet(new ulong[]{0x0000000080000002UL,0x000000C800000000UL});
    public static readonly BitSet FOLLOW_EQ_in_equalityExpression1873 = new BitSet(new ulong[]{0x809380D8085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_IS_in_equalityExpression1882 = new BitSet(new ulong[]{0x809380D8085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_NOT_in_equalityExpression1888 = new BitSet(new ulong[]{0x809380D8085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_NE_in_equalityExpression1900 = new BitSet(new ulong[]{0x809380D8085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_SQL_NE_in_equalityExpression1909 = new BitSet(new ulong[]{0x809380D8085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_relationalExpression_in_equalityExpression1920 = new BitSet(new ulong[]{0x0000000080000002UL,0x000000C800000000UL});
    public static readonly BitSet FOLLOW_concatenation_in_relationalExpression1939 = new BitSet(new ulong[]{0x0000004404000402UL,0x00000F0000000002UL});
    public static readonly BitSet FOLLOW_LT_in_relationalExpression1951 = new BitSet(new ulong[]{0x80938098085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_GT_in_relationalExpression1956 = new BitSet(new ulong[]{0x80938098085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_LE_in_relationalExpression1961 = new BitSet(new ulong[]{0x80938098085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_GE_in_relationalExpression1966 = new BitSet(new ulong[]{0x80938098085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_additiveExpression_in_relationalExpression1971 = new BitSet(new ulong[]{0x0000000000000002UL,0x00000F0000000000UL});
    public static readonly BitSet FOLLOW_NOT_in_relationalExpression1988 = new BitSet(new ulong[]{0x0000000404000400UL,0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IN_in_relationalExpression2009 = new BitSet(new ulong[]{0x0011001808421200UL,0x0040001000000000UL});
    public static readonly BitSet FOLLOW_inList_in_relationalExpression2018 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_BETWEEN_in_relationalExpression2029 = new BitSet(new ulong[]{0x80938098085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_betweenList_in_relationalExpression2038 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LIKE_in_relationalExpression2050 = new BitSet(new ulong[]{0x80938098085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_concatenation_in_relationalExpression2059 = new BitSet(new ulong[]{0x0000000000040000UL});
    public static readonly BitSet FOLLOW_likeEscape_in_relationalExpression2061 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_MEMBER_in_relationalExpression2070 = new BitSet(new ulong[]{0x0010000000400000UL,0x0040000000000008UL});
    public static readonly BitSet FOLLOW_OF_in_relationalExpression2074 = new BitSet(new ulong[]{0x0010000000400000UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_path_in_relationalExpression2081 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ESCAPE_in_likeEscape2108 = new BitSet(new ulong[]{0x80938098085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_concatenation_in_likeEscape2111 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_compoundExpr_in_inList2126 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_concatenation_in_betweenList2146 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_AND_in_betweenList2148 = new BitSet(new ulong[]{0x80938098085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_concatenation_in_betweenList2151 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_additiveExpression_in_concatenation2166 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000100000000000UL});
    public static readonly BitSet FOLLOW_CONCAT_in_concatenation2174 = new BitSet(new ulong[]{0x80938098085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_additiveExpression_in_concatenation2181 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000100000000000UL});
    public static readonly BitSet FOLLOW_CONCAT_in_concatenation2188 = new BitSet(new ulong[]{0x80938098085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_additiveExpression_in_concatenation2191 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000100000000000UL});
    public static readonly BitSet FOLLOW_multiplyExpression_in_additiveExpression2213 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000600000000000UL});
    public static readonly BitSet FOLLOW_PLUS_in_additiveExpression2219 = new BitSet(new ulong[]{0x80938098085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_MINUS_in_additiveExpression2224 = new BitSet(new ulong[]{0x80938098085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_multiplyExpression_in_additiveExpression2229 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000600000000000UL});
    public static readonly BitSet FOLLOW_unaryExpression_in_multiplyExpression2244 = new BitSet(new ulong[]{0x0000000000000002UL,0x0001800000000000UL});
    public static readonly BitSet FOLLOW_STAR_in_multiplyExpression2250 = new BitSet(new ulong[]{0x80938098085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_DIV_in_multiplyExpression2255 = new BitSet(new ulong[]{0x80938098085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_unaryExpression_in_multiplyExpression2260 = new BitSet(new ulong[]{0x0000000000000002UL,0x0001800000000000UL});
    public static readonly BitSet FOLLOW_MINUS_in_unaryExpression2280 = new BitSet(new ulong[]{0x80938098085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_unaryExpression_in_unaryExpression2284 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_PLUS_in_unaryExpression2291 = new BitSet(new ulong[]{0x80938098085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_unaryExpression_in_unaryExpression2295 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_caseExpression_in_unaryExpression2302 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_quantifiedExpression_in_unaryExpression2309 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_atom_in_unaryExpression2316 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_CASE_in_caseExpression2385 = new BitSet(new ulong[]{0x0800000000000000UL});
    public static readonly BitSet FOLLOW_whenClause_in_caseExpression2388 = new BitSet(new ulong[]{0x0B00000000000000UL});
    public static readonly BitSet FOLLOW_elseClause_in_caseExpression2393 = new BitSet(new ulong[]{0x0100000000000000UL});
    public static readonly BitSet FOLLOW_END_in_caseExpression2397 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_CASE_in_caseExpression2416 = new BitSet(new ulong[]{0x80938098085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_unaryExpression_in_caseExpression2418 = new BitSet(new ulong[]{0x0800000000000000UL});
    public static readonly BitSet FOLLOW_altWhenClause_in_caseExpression2421 = new BitSet(new ulong[]{0x0B00000000000000UL});
    public static readonly BitSet FOLLOW_elseClause_in_caseExpression2426 = new BitSet(new ulong[]{0x0100000000000000UL});
    public static readonly BitSet FOLLOW_END_in_caseExpression2430 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_WHEN_in_whenClause2459 = new BitSet(new ulong[]{0x809380D8085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_logicalExpression_in_whenClause2462 = new BitSet(new ulong[]{0x0400000000000000UL});
    public static readonly BitSet FOLLOW_THEN_in_whenClause2464 = new BitSet(new ulong[]{0x80938098085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_unaryExpression_in_whenClause2467 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_WHEN_in_altWhenClause2481 = new BitSet(new ulong[]{0x80938098085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_unaryExpression_in_altWhenClause2484 = new BitSet(new ulong[]{0x0400000000000000UL});
    public static readonly BitSet FOLLOW_THEN_in_altWhenClause2486 = new BitSet(new ulong[]{0x80938098085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_unaryExpression_in_altWhenClause2489 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ELSE_in_elseClause2503 = new BitSet(new ulong[]{0x80938098085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_unaryExpression_in_elseClause2506 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SOME_in_quantifiedExpression2521 = new BitSet(new ulong[]{0x0011001808421200UL,0x0040001000000000UL});
    public static readonly BitSet FOLLOW_EXISTS_in_quantifiedExpression2526 = new BitSet(new ulong[]{0x0011001808421200UL,0x0040001000000000UL});
    public static readonly BitSet FOLLOW_ALL_in_quantifiedExpression2531 = new BitSet(new ulong[]{0x0011001808421200UL,0x0040001000000000UL});
    public static readonly BitSet FOLLOW_ANY_in_quantifiedExpression2536 = new BitSet(new ulong[]{0x0011001808421200UL,0x0040001000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_quantifiedExpression2545 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_collectionExpr_in_quantifiedExpression2549 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_OPEN_in_quantifiedExpression2554 = new BitSet(new ulong[]{0x0020220001400000UL});
    public static readonly BitSet FOLLOW_subQuery_in_quantifiedExpression2559 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000002000000000UL});
    public static readonly BitSet FOLLOW_CLOSE_in_quantifiedExpression2563 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_primaryExpression_in_atom2584 = new BitSet(new ulong[]{0x0000000000008002UL,0x0002000000000000UL});
    public static readonly BitSet FOLLOW_DOT_in_atom2593 = new BitSet(new ulong[]{0x0010000000400000UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_atom2596 = new BitSet(new ulong[]{0x0000000000008002UL,0x0002001000000000UL});
    public static readonly BitSet FOLLOW_OPEN_in_atom2624 = new BitSet(new ulong[]{0xC09380D8085A1230UL,0x00786031E0000011UL});
    public static readonly BitSet FOLLOW_exprList_in_atom2629 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000002000000000UL});
    public static readonly BitSet FOLLOW_CLOSE_in_atom2631 = new BitSet(new ulong[]{0x0000000000008002UL,0x0002000000000000UL});
    public static readonly BitSet FOLLOW_OPEN_BRACKET_in_atom2645 = new BitSet(new ulong[]{0x809380D8085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_expression_in_atom2650 = new BitSet(new ulong[]{0x0000000000000000UL,0x0004000000000000UL});
    public static readonly BitSet FOLLOW_CLOSE_BRACKET_in_atom2652 = new BitSet(new ulong[]{0x0000000000008002UL,0x0002000000000000UL});
    public static readonly BitSet FOLLOW_identPrimary_in_primaryExpression2672 = new BitSet(new ulong[]{0x0000000000008002UL});
    public static readonly BitSet FOLLOW_DOT_in_primaryExpression2685 = new BitSet(new ulong[]{0x0000000000000800UL});
    public static readonly BitSet FOLLOW_CLASS_in_primaryExpression2688 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_constant_in_primaryExpression2698 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_COLON_in_primaryExpression2705 = new BitSet(new ulong[]{0x0010000000400000UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_primaryExpression2708 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_OPEN_in_primaryExpression2717 = new BitSet(new ulong[]{0x80B3A2D8095A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_expressionOrVector_in_primaryExpression2721 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000002000000000UL});
    public static readonly BitSet FOLLOW_subQuery_in_primaryExpression2725 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000002000000000UL});
    public static readonly BitSet FOLLOW_CLOSE_in_primaryExpression2728 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_PARAM_in_primaryExpression2736 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000020000000UL});
    public static readonly BitSet FOLLOW_NUM_INT_in_primaryExpression2740 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_expression_in_expressionOrVector2760 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000400000000UL});
    public static readonly BitSet FOLLOW_vectorExpr_in_expressionOrVector2766 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_COMMA_in_vectorExpr2805 = new BitSet(new ulong[]{0x809380D8085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_expression_in_vectorExpr2808 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000400000000UL});
    public static readonly BitSet FOLLOW_COMMA_in_vectorExpr2811 = new BitSet(new ulong[]{0x809380D8085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_expression_in_vectorExpr2814 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000400000000UL});
    public static readonly BitSet FOLLOW_identifier_in_identPrimary2834 = new BitSet(new ulong[]{0x0000000000008002UL,0x0000001000000000UL});
    public static readonly BitSet FOLLOW_DOT_in_identPrimary2856 = new BitSet(new ulong[]{0x0010000000420000UL,0x0040000000000004UL});
    public static readonly BitSet FOLLOW_identifier_in_identPrimary2869 = new BitSet(new ulong[]{0x0000000000008002UL,0x0000001000000000UL});
    public static readonly BitSet FOLLOW_ELEMENTS_in_identPrimary2880 = new BitSet(new ulong[]{0x0000000000008002UL,0x0000001000000000UL});
    public static readonly BitSet FOLLOW_OBJECT_in_identPrimary2891 = new BitSet(new ulong[]{0x0000000000008002UL,0x0000001000000000UL});
    public static readonly BitSet FOLLOW_OPEN_in_identPrimary2927 = new BitSet(new ulong[]{0xC09380D8085A1230UL,0x00786031E0000011UL});
    public static readonly BitSet FOLLOW_exprList_in_identPrimary2929 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000002000000000UL});
    public static readonly BitSet FOLLOW_CLOSE_in_identPrimary2931 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_aggregate_in_identPrimary3068 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SUM_in_aggregate3090 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000001000000000UL});
    public static readonly BitSet FOLLOW_AVG_in_aggregate3094 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000001000000000UL});
    public static readonly BitSet FOLLOW_MAX_in_aggregate3098 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000001000000000UL});
    public static readonly BitSet FOLLOW_MIN_in_aggregate3102 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000001000000000UL});
    public static readonly BitSet FOLLOW_OPEN_in_aggregate3106 = new BitSet(new ulong[]{0x80938098085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_additiveExpression_in_aggregate3108 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000002000000000UL});
    public static readonly BitSet FOLLOW_CLOSE_in_aggregate3110 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_COUNT_in_aggregate3129 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000001000000000UL});
    public static readonly BitSet FOLLOW_OPEN_in_aggregate3131 = new BitSet(new ulong[]{0x0011001808431210UL,0x0040800000000000UL});
    public static readonly BitSet FOLLOW_STAR_in_aggregate3137 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000002000000000UL});
    public static readonly BitSet FOLLOW_DISTINCT_in_aggregate3147 = new BitSet(new ulong[]{0x0011001808421200UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_ALL_in_aggregate3151 = new BitSet(new ulong[]{0x0011001808421200UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_path_in_aggregate3158 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000002000000000UL});
    public static readonly BitSet FOLLOW_collectionExpr_in_aggregate3162 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000002000000000UL});
    public static readonly BitSet FOLLOW_CLOSE_in_aggregate3170 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_collectionExpr_in_aggregate3201 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ELEMENTS_in_collectionExpr3215 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000001000000000UL});
    public static readonly BitSet FOLLOW_INDICES_in_collectionExpr3220 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000001000000000UL});
    public static readonly BitSet FOLLOW_OPEN_in_collectionExpr3224 = new BitSet(new ulong[]{0x0010000000400000UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_path_in_collectionExpr3227 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000002000000000UL});
    public static readonly BitSet FOLLOW_CLOSE_in_collectionExpr3229 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_collectionExpr_in_compoundExpr3285 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_path_in_compoundExpr3290 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_OPEN_in_compoundExpr3296 = new BitSet(new ulong[]{0x80B3A2D8095A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_expression_in_compoundExpr3302 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000002400000000UL});
    public static readonly BitSet FOLLOW_COMMA_in_compoundExpr3305 = new BitSet(new ulong[]{0x809380D8085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_expression_in_compoundExpr3308 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000002400000000UL});
    public static readonly BitSet FOLLOW_subQuery_in_compoundExpr3315 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000002000000000UL});
    public static readonly BitSet FOLLOW_CLOSE_in_compoundExpr3319 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_union_in_subQuery3334 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_exprList3359 = new BitSet(new ulong[]{0x809380D8085A1232UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_expression_in_exprList3406 = new BitSet(new ulong[]{0x0000000000400082UL,0x0000000400000000UL});
    public static readonly BitSet FOLLOW_COMMA_in_exprList3411 = new BitSet(new ulong[]{0x809380D8085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_expression_in_exprList3413 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000400000000UL});
    public static readonly BitSet FOLLOW_FROM_in_exprList3426 = new BitSet(new ulong[]{0x809380D8085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_expression_in_exprList3428 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_AS_in_exprList3439 = new BitSet(new ulong[]{0x0010000000400000UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_exprList3441 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FROM_in_exprList3453 = new BitSet(new ulong[]{0x809380D8085A1230UL,0x00786011E0000000UL});
    public static readonly BitSet FOLLOW_expression_in_exprList3455 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_constant0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_identifier_in_path3529 = new BitSet(new ulong[]{0x0000000000008002UL});
    public static readonly BitSet FOLLOW_DOT_in_path3533 = new BitSet(new ulong[]{0x0010000000400000UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_path3538 = new BitSet(new ulong[]{0x0000000000008002UL});
    public static readonly BitSet FOLLOW_IDENT_in_identifier3554 = new BitSet(new ulong[]{0x0000000000000002UL});

}
}