// $ANTLR 3.1.1 /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g 2009-02-20 14:14:53
// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162
namespace  NHibernate.Hql.Ast.ANTLR 
{

using System.Text;
using NHibernate.Hql.Ast.ANTLR.Tree;



using System;
using Antlr.Runtime;
using Antlr.Runtime.Tree;using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;



public partial class HqlSqlWalker : TreeParser
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
		"'descending'", 
		"FROM_FRAGMENT", 
		"IMPLIED_FROM", 
		"JOIN_FRAGMENT", 
		"SELECT_CLAUSE", 
		"LEFT_OUTER", 
		"RIGHT_OUTER", 
		"ALIAS_REF", 
		"PROPERTY_REF", 
		"SQL_TOKEN", 
		"SELECT_COLUMNS", 
		"SELECT_EXPR", 
		"THETA_JOINS", 
		"FILTERS", 
		"METHOD_NAME", 
		"NAMED_PARAM", 
		"BOGUS", 
		"QUOTED_STRING"
    };

    public const int EXPR_LIST = 73;
    public const int EXISTS = 19;
    public const int COMMA = 98;
    public const int FETCH = 21;
    public const int MINUS = 110;
    public const int AS = 7;
    public const int END = 56;
    public const int INTO = 30;
    public const int NAMED_PARAM = 142;
    public const int FROM_FRAGMENT = 128;
    public const int FALSE = 20;
    public const int ELEMENTS = 17;
    public const int THEN = 58;
    public const int FILTERS = 140;
    public const int ALIAS = 70;
    public const int ALIAS_REF = 134;
    public const int ON = 60;
    public const int DOT = 15;
    public const int ORDER = 41;
    public const int AND = 6;
    public const int CONSTANT = 92;
    public const int UNARY_MINUS = 88;
    public const int METHOD_CALL = 79;
    public const int RIGHT = 44;
    public const int CONCAT = 108;
    public const int PROPERTIES = 43;
    public const int SELECT = 45;
    public const int LE = 106;
    public const int RIGHT_OUTER = 133;
    public const int BETWEEN = 10;
    public const int SQL_TOKEN = 136;
    public const int NUM_INT = 93;
    public const int LEFT_OUTER = 132;
    public const int BOTH = 62;
    public const int METHOD_NAME = 141;
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
    public const int NEW = 37;
    public const int EQ = 99;
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
    public const int THETA_JOINS = 139;
    public const int IMPLIED_FROM = 129;
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
    public const int SELECT_EXPR = 138;
    public const int OR = 40;
    public const int JOIN_FRAGMENT = 130;
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
    public const int NOT_IN = 81;
    public const int FROM = 22;
    public const int DELETE = 13;
    public const int OBJECT = 66;
    public const int MAX = 35;
    public const int NOT_LIKE = 82;
    public const int EMPTY = 63;
    public const int QUOTED_String = 117;
    public const int ASCENDING = 8;
    public const int NUM_LONG = 96;
    public const int IS = 31;
    public const int SQL_NE = 103;
    public const int IN_LIST = 75;
    public const int WEIRD_IDENT = 91;
    public const int NE = 102;
    public const int GT = 105;
    public const int MIN = 36;
    public const int LIKE = 34;
    public const int WITH = 61;
    public const int IN = 26;
    public const int PROPERTY_REF = 135;
    public const int CONSTRUCTOR = 71;
    public const int SOME = 47;
    public const int CLASS = 11;
    public const int SELECT_COLUMNS = 137;
    public const int EXPONENT = 123;
    public const int BOGUS = 143;
    public const int ID_START_LETTER = 119;
    public const int QUOTED_STRING = 144;
    public const int EOF = -1;
    public const int CLOSE = 101;
    public const int AVG = 9;
    public const int SELECT_CLAUSE = 131;
    public const int STAR = 111;
    public const int NOT = 38;
    public const int JAVA_CONSTANT = 97;

    // delegates
    // delegators



        public HqlSqlWalker(ITreeNodeStream input)
    		: this(input, new RecognizerSharedState()) {
        }

        public HqlSqlWalker(ITreeNodeStream input, RecognizerSharedState state)
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
		get { return HqlSqlWalker.tokenNames; }
    }

    override public string GrammarFileName {
		get { return "/Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g"; }
    }


    public class statement_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "statement"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:41:1: statement : ( selectStatement | updateStatement | deleteStatement | insertStatement );
    public HqlSqlWalker.statement_return statement() // throws RecognitionException [1]
    {   
        HqlSqlWalker.statement_return retval = new HqlSqlWalker.statement_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        HqlSqlWalker.selectStatement_return selectStatement1 = default(HqlSqlWalker.selectStatement_return);

        HqlSqlWalker.updateStatement_return updateStatement2 = default(HqlSqlWalker.updateStatement_return);

        HqlSqlWalker.deleteStatement_return deleteStatement3 = default(HqlSqlWalker.deleteStatement_return);

        HqlSqlWalker.insertStatement_return insertStatement4 = default(HqlSqlWalker.insertStatement_return);



        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:42:2: ( selectStatement | updateStatement | deleteStatement | insertStatement )
            int alt1 = 4;
            switch ( input.LA(1) ) 
            {
            case QUERY:
            	{
                alt1 = 1;
                }
                break;
            case UPDATE:
            	{
                alt1 = 2;
                }
                break;
            case DELETE:
            	{
                alt1 = 3;
                }
                break;
            case INSERT:
            	{
                alt1 = 4;
                }
                break;
            	default:
            	    NoViableAltException nvae_d1s0 =
            	        new NoViableAltException("", 1, 0, input);

            	    throw nvae_d1s0;
            }

            switch (alt1) 
            {
                case 1 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:42:4: selectStatement
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_selectStatement_in_statement168);
                    	selectStatement1 = selectStatement();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, selectStatement1.Tree);

                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:42:22: updateStatement
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_updateStatement_in_statement172);
                    	updateStatement2 = updateStatement();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, updateStatement2.Tree);

                    }
                    break;
                case 3 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:42:40: deleteStatement
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_deleteStatement_in_statement176);
                    	deleteStatement3 = deleteStatement();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, deleteStatement3.Tree);

                    }
                    break;
                case 4 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:42:58: insertStatement
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_insertStatement_in_statement180);
                    	insertStatement4 = insertStatement();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, insertStatement4.Tree);

                    }
                    break;

            }
            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "statement"

    public class selectStatement_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "selectStatement"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:45:1: selectStatement : query ;
    public HqlSqlWalker.selectStatement_return selectStatement() // throws RecognitionException [1]
    {   
        HqlSqlWalker.selectStatement_return retval = new HqlSqlWalker.selectStatement_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        HqlSqlWalker.query_return query5 = default(HqlSqlWalker.query_return);



        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:46:2: ( query )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:46:4: query
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	_last = (CommonTree)input.LT(1);
            	PushFollow(FOLLOW_query_in_selectStatement191);
            	query5 = query();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, query5.Tree);

            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "selectStatement"

    public class updateStatement_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "updateStatement"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:65:1: updateStatement : ^(u= UPDATE (v= VERSIONED )? f= fromClause s= setClause (w= whereClause )? ) -> ^( $u $f $s ( $w)? ) ;
    public HqlSqlWalker.updateStatement_return updateStatement() // throws RecognitionException [1]
    {   
        HqlSqlWalker.updateStatement_return retval = new HqlSqlWalker.updateStatement_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree u = null;
        CommonTree v = null;
        HqlSqlWalker.fromClause_return f = default(HqlSqlWalker.fromClause_return);

        HqlSqlWalker.setClause_return s = default(HqlSqlWalker.setClause_return);

        HqlSqlWalker.whereClause_return w = default(HqlSqlWalker.whereClause_return);


        CommonTree u_tree=null;
        CommonTree v_tree=null;
        RewriteRuleNodeStream stream_UPDATE = new RewriteRuleNodeStream(adaptor,"token UPDATE");
        RewriteRuleNodeStream stream_VERSIONED = new RewriteRuleNodeStream(adaptor,"token VERSIONED");
        RewriteRuleSubtreeStream stream_fromClause = new RewriteRuleSubtreeStream(adaptor,"rule fromClause");
        RewriteRuleSubtreeStream stream_whereClause = new RewriteRuleSubtreeStream(adaptor,"rule whereClause");
        RewriteRuleSubtreeStream stream_setClause = new RewriteRuleSubtreeStream(adaptor,"rule setClause");
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:72:2: ( ^(u= UPDATE (v= VERSIONED )? f= fromClause s= setClause (w= whereClause )? ) -> ^( $u $f $s ( $w)? ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:72:4: ^(u= UPDATE (v= VERSIONED )? f= fromClause s= setClause (w= whereClause )? )
            {
            	_last = (CommonTree)input.LT(1);
            	{
            	CommonTree _save_last_1 = _last;
            	CommonTree _first_1 = null;
            	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	u=(CommonTree)Match(input,UPDATE,FOLLOW_UPDATE_in_updateStatement217);  
            	stream_UPDATE.Add(u);


            	 beforeStatement( "update", UPDATE ); 

            	Match(input, Token.DOWN, null); 
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:72:57: (v= VERSIONED )?
            	int alt2 = 2;
            	int LA2_0 = input.LA(1);

            	if ( (LA2_0 == VERSIONED) )
            	{
            	    alt2 = 1;
            	}
            	switch (alt2) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:72:58: v= VERSIONED
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	v=(CommonTree)Match(input,VERSIONED,FOLLOW_VERSIONED_in_updateStatement224);  
            	        	stream_VERSIONED.Add(v);


            	        }
            	        break;

            	}

            	_last = (CommonTree)input.LT(1);
            	PushFollow(FOLLOW_fromClause_in_updateStatement230);
            	f = fromClause();
            	state.followingStackPointer--;

            	stream_fromClause.Add(f.Tree);
            	_last = (CommonTree)input.LT(1);
            	PushFollow(FOLLOW_setClause_in_updateStatement234);
            	s = setClause();
            	state.followingStackPointer--;

            	stream_setClause.Add(s.Tree);
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:72:97: (w= whereClause )?
            	int alt3 = 2;
            	int LA3_0 = input.LA(1);

            	if ( (LA3_0 == WHERE) )
            	{
            	    alt3 = 1;
            	}
            	switch (alt3) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:72:98: w= whereClause
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_whereClause_in_updateStatement239);
            	        	w = whereClause();
            	        	state.followingStackPointer--;

            	        	stream_whereClause.Add(w.Tree);

            	        }
            	        break;

            	}


            	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	}



            	// AST REWRITE
            	// elements:          u, f, w, s
            	// token labels:      u
            	// rule labels:       w, f, retval, s
            	// token list labels: 
            	// rule list labels:  
            	retval.Tree = root_0;
            	RewriteRuleNodeStream stream_u = new RewriteRuleNodeStream(adaptor, "token u", u);
            	RewriteRuleSubtreeStream stream_w = new RewriteRuleSubtreeStream(adaptor, "token w", (w!=null ? w.Tree : null));
            	RewriteRuleSubtreeStream stream_f = new RewriteRuleSubtreeStream(adaptor, "token f", (f!=null ? f.Tree : null));
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));
            	RewriteRuleSubtreeStream stream_s = new RewriteRuleSubtreeStream(adaptor, "token s", (s!=null ? s.Tree : null));

            	root_0 = (CommonTree)adaptor.GetNilNode();
            	// 73:3: -> ^( $u $f $s ( $w)? )
            	{
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:73:6: ^( $u $f $s ( $w)? )
            	    {
            	    CommonTree root_1 = (CommonTree)adaptor.GetNilNode();
            	    root_1 = (CommonTree)adaptor.BecomeRoot(stream_u.NextNode(), root_1);

            	    adaptor.AddChild(root_1, stream_f.NextTree());
            	    adaptor.AddChild(root_1, stream_s.NextTree());
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:73:17: ( $w)?
            	    if ( stream_w.HasNext() )
            	    {
            	        adaptor.AddChild(root_1, stream_w.NextTree());

            	    }
            	    stream_w.Reset();

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;
            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);


            		beforeStatementCompletion( "update" );
            		prepareVersioned( ((CommonTree)retval.Tree), v_tree );
            		postProcessUpdate( ((CommonTree)retval.Tree) );
            		afterStatementCompletion( "update" );
            	
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "updateStatement"

    public class deleteStatement_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "deleteStatement"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:86:1: deleteStatement : ^( DELETE fromClause ( whereClause )? ) ;
    public HqlSqlWalker.deleteStatement_return deleteStatement() // throws RecognitionException [1]
    {   
        HqlSqlWalker.deleteStatement_return retval = new HqlSqlWalker.deleteStatement_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree DELETE6 = null;
        HqlSqlWalker.fromClause_return fromClause7 = default(HqlSqlWalker.fromClause_return);

        HqlSqlWalker.whereClause_return whereClause8 = default(HqlSqlWalker.whereClause_return);


        CommonTree DELETE6_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:92:2: ( ^( DELETE fromClause ( whereClause )? ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:92:4: ^( DELETE fromClause ( whereClause )? )
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	_last = (CommonTree)input.LT(1);
            	{
            	CommonTree _save_last_1 = _last;
            	CommonTree _first_1 = null;
            	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	DELETE6=(CommonTree)Match(input,DELETE,FOLLOW_DELETE_in_deleteStatement284); 
            		DELETE6_tree = (CommonTree)adaptor.DupNode(DELETE6);

            		root_1 = (CommonTree)adaptor.BecomeRoot(DELETE6_tree, root_1);


            	 beforeStatement( "delete", DELETE ); 

            	Match(input, Token.DOWN, null); 
            	_last = (CommonTree)input.LT(1);
            	PushFollow(FOLLOW_fromClause_in_deleteStatement288);
            	fromClause7 = fromClause();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_1, fromClause7.Tree);
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:92:66: ( whereClause )?
            	int alt4 = 2;
            	int LA4_0 = input.LA(1);

            	if ( (LA4_0 == WHERE) )
            	{
            	    alt4 = 1;
            	}
            	switch (alt4) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:92:67: whereClause
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_whereClause_in_deleteStatement291);
            	        	whereClause8 = whereClause();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, whereClause8.Tree);

            	        }
            	        break;

            	}


            	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	}


            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);


            		beforeStatementCompletion( "delete" );
            		postProcessDelete( ((CommonTree)retval.Tree) );
            		afterStatementCompletion( "delete" );
            	
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "deleteStatement"

    public class insertStatement_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "insertStatement"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:108:1: insertStatement : ^( INSERT intoClause query ) ;
    public HqlSqlWalker.insertStatement_return insertStatement() // throws RecognitionException [1]
    {   
        HqlSqlWalker.insertStatement_return retval = new HqlSqlWalker.insertStatement_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree INSERT9 = null;
        HqlSqlWalker.intoClause_return intoClause10 = default(HqlSqlWalker.intoClause_return);

        HqlSqlWalker.query_return query11 = default(HqlSqlWalker.query_return);


        CommonTree INSERT9_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:117:2: ( ^( INSERT intoClause query ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:117:4: ^( INSERT intoClause query )
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	_last = (CommonTree)input.LT(1);
            	{
            	CommonTree _save_last_1 = _last;
            	CommonTree _first_1 = null;
            	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	INSERT9=(CommonTree)Match(input,INSERT,FOLLOW_INSERT_in_insertStatement323); 
            		INSERT9_tree = (CommonTree)adaptor.DupNode(INSERT9);

            		root_1 = (CommonTree)adaptor.BecomeRoot(INSERT9_tree, root_1);


            	 beforeStatement( "insert", INSERT ); 

            	Match(input, Token.DOWN, null); 
            	_last = (CommonTree)input.LT(1);
            	PushFollow(FOLLOW_intoClause_in_insertStatement327);
            	intoClause10 = intoClause();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_1, intoClause10.Tree);
            	_last = (CommonTree)input.LT(1);
            	PushFollow(FOLLOW_query_in_insertStatement329);
            	query11 = query();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_1, query11.Tree);

            	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	}


            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);


            		beforeStatementCompletion( "insert" );
            		postProcessInsert( ((CommonTree)retval.Tree) );
            		afterStatementCompletion( "insert" );
            	
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "insertStatement"

    public class intoClause_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "intoClause"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:131:1: intoClause : ^( INTO (p= path ) ps= insertablePropertySpec ) ;
    public HqlSqlWalker.intoClause_return intoClause() // throws RecognitionException [1]
    {   
        HqlSqlWalker.intoClause_return retval = new HqlSqlWalker.intoClause_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree INTO12 = null;
        HqlSqlWalker.path_return p = default(HqlSqlWalker.path_return);

        HqlSqlWalker.insertablePropertySpec_return ps = default(HqlSqlWalker.insertablePropertySpec_return);


        CommonTree INTO12_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:132:2: ( ^( INTO (p= path ) ps= insertablePropertySpec ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:132:4: ^( INTO (p= path ) ps= insertablePropertySpec )
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	_last = (CommonTree)input.LT(1);
            	{
            	CommonTree _save_last_1 = _last;
            	CommonTree _first_1 = null;
            	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	INTO12=(CommonTree)Match(input,INTO,FOLLOW_INTO_in_intoClause349); 
            		INTO12_tree = (CommonTree)adaptor.DupNode(INTO12);

            		root_1 = (CommonTree)adaptor.BecomeRoot(INTO12_tree, root_1);


            	 handleClauseStart( INTO ); 

            	Match(input, Token.DOWN, null); 
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:132:43: (p= path )
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:132:44: p= path
            	{
            		_last = (CommonTree)input.LT(1);
            		PushFollow(FOLLOW_path_in_intoClause356);
            		p = path();
            		state.followingStackPointer--;

            		adaptor.AddChild(root_1, p.Tree);

            	}

            	_last = (CommonTree)input.LT(1);
            	PushFollow(FOLLOW_insertablePropertySpec_in_intoClause361);
            	ps = insertablePropertySpec();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_1, ps.Tree);

            	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	}


            			retval.Tree =  createIntoClause(((p != null) ? ((CommonTree)p.Tree) : null), ((ps != null) ? ((CommonTree)ps.Tree) : null));
            		

            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "intoClause"

    public class insertablePropertySpec_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "insertablePropertySpec"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:137:1: insertablePropertySpec : ^( RANGE ( IDENT )+ ) ;
    public HqlSqlWalker.insertablePropertySpec_return insertablePropertySpec() // throws RecognitionException [1]
    {   
        HqlSqlWalker.insertablePropertySpec_return retval = new HqlSqlWalker.insertablePropertySpec_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree RANGE13 = null;
        CommonTree IDENT14 = null;

        CommonTree RANGE13_tree=null;
        CommonTree IDENT14_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:138:2: ( ^( RANGE ( IDENT )+ ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:138:4: ^( RANGE ( IDENT )+ )
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	_last = (CommonTree)input.LT(1);
            	{
            	CommonTree _save_last_1 = _last;
            	CommonTree _first_1 = null;
            	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	RANGE13=(CommonTree)Match(input,RANGE,FOLLOW_RANGE_in_insertablePropertySpec378); 
            		RANGE13_tree = (CommonTree)adaptor.DupNode(RANGE13);

            		root_1 = (CommonTree)adaptor.BecomeRoot(RANGE13_tree, root_1);



            	Match(input, Token.DOWN, null); 
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:138:13: ( IDENT )+
            	int cnt5 = 0;
            	do 
            	{
            	    int alt5 = 2;
            	    int LA5_0 = input.LA(1);

            	    if ( (LA5_0 == IDENT) )
            	    {
            	        alt5 = 1;
            	    }


            	    switch (alt5) 
            		{
            			case 1 :
            			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:138:14: IDENT
            			    {
            			    	_last = (CommonTree)input.LT(1);
            			    	IDENT14=(CommonTree)Match(input,IDENT,FOLLOW_IDENT_in_insertablePropertySpec381); 
            			    		IDENT14_tree = (CommonTree)adaptor.DupNode(IDENT14);

            			    		adaptor.AddChild(root_1, IDENT14_tree);


            			    }
            			    break;

            			default:
            			    if ( cnt5 >= 1 ) goto loop5;
            		            EarlyExitException eee =
            		                new EarlyExitException(5, input);
            		            throw eee;
            	    }
            	    cnt5++;
            	} while (true);

            	loop5:
            		;	// Stops C# compiler whinging that label 'loop5' has no statements


            	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	}


            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "insertablePropertySpec"

    public class setClause_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "setClause"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:141:1: setClause : ^( SET ( assignment )* ) ;
    public HqlSqlWalker.setClause_return setClause() // throws RecognitionException [1]
    {   
        HqlSqlWalker.setClause_return retval = new HqlSqlWalker.setClause_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree SET15 = null;
        HqlSqlWalker.assignment_return assignment16 = default(HqlSqlWalker.assignment_return);


        CommonTree SET15_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:142:2: ( ^( SET ( assignment )* ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:142:4: ^( SET ( assignment )* )
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	_last = (CommonTree)input.LT(1);
            	{
            	CommonTree _save_last_1 = _last;
            	CommonTree _first_1 = null;
            	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	SET15=(CommonTree)Match(input,SET,FOLLOW_SET_in_setClause398); 
            		SET15_tree = (CommonTree)adaptor.DupNode(SET15);

            		root_1 = (CommonTree)adaptor.BecomeRoot(SET15_tree, root_1);


            	 handleClauseStart( SET ); 

            	if ( input.LA(1) == Token.DOWN )
            	{
            	    Match(input, Token.DOWN, null); 
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:142:41: ( assignment )*
            	    do 
            	    {
            	        int alt6 = 2;
            	        int LA6_0 = input.LA(1);

            	        if ( (LA6_0 == EQ) )
            	        {
            	            alt6 = 1;
            	        }


            	        switch (alt6) 
            	    	{
            	    		case 1 :
            	    		    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:142:42: assignment
            	    		    {
            	    		    	_last = (CommonTree)input.LT(1);
            	    		    	PushFollow(FOLLOW_assignment_in_setClause403);
            	    		    	assignment16 = assignment();
            	    		    	state.followingStackPointer--;

            	    		    	adaptor.AddChild(root_1, assignment16.Tree);

            	    		    }
            	    		    break;

            	    		default:
            	    		    goto loop6;
            	        }
            	    } while (true);

            	    loop6:
            	    	;	// Stops C# compiler whining that label 'loop6' has no statements


            	    Match(input, Token.UP, null); 
            	}adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	}


            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "setClause"

    public class assignment_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "assignment"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:155:1: assignment : ^( EQ (p= propertyRef ) ( newValue ) ) ;
    public HqlSqlWalker.assignment_return assignment() // throws RecognitionException [1]
    {   
        HqlSqlWalker.assignment_return retval = new HqlSqlWalker.assignment_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree EQ17 = null;
        HqlSqlWalker.propertyRef_return p = default(HqlSqlWalker.propertyRef_return);

        HqlSqlWalker.newValue_return newValue18 = default(HqlSqlWalker.newValue_return);


        CommonTree EQ17_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:161:2: ( ^( EQ (p= propertyRef ) ( newValue ) ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:161:4: ^( EQ (p= propertyRef ) ( newValue ) )
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	_last = (CommonTree)input.LT(1);
            	{
            	CommonTree _save_last_1 = _last;
            	CommonTree _first_1 = null;
            	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	EQ17=(CommonTree)Match(input,EQ,FOLLOW_EQ_in_assignment432); 
            		EQ17_tree = (CommonTree)adaptor.DupNode(EQ17);

            		root_1 = (CommonTree)adaptor.BecomeRoot(EQ17_tree, root_1);



            	Match(input, Token.DOWN, null); 
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:161:10: (p= propertyRef )
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:161:11: p= propertyRef
            	{
            		_last = (CommonTree)input.LT(1);
            		PushFollow(FOLLOW_propertyRef_in_assignment437);
            		p = propertyRef();
            		state.followingStackPointer--;

            		adaptor.AddChild(root_1, p.Tree);

            	}

            	 resolve(((p != null) ? ((CommonTree)p.Tree) : null)); 
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:161:48: ( newValue )
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:161:49: newValue
            	{
            		_last = (CommonTree)input.LT(1);
            		PushFollow(FOLLOW_newValue_in_assignment443);
            		newValue18 = newValue();
            		state.followingStackPointer--;

            		adaptor.AddChild(root_1, newValue18.Tree);

            	}


            	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	}


            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);


            		evaluateAssignment( ((CommonTree)retval.Tree) );
            	
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "assignment"

    public class newValue_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "newValue"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:165:1: newValue : ( expr | query );
    public HqlSqlWalker.newValue_return newValue() // throws RecognitionException [1]
    {   
        HqlSqlWalker.newValue_return retval = new HqlSqlWalker.newValue_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        HqlSqlWalker.expr_return expr19 = default(HqlSqlWalker.expr_return);

        HqlSqlWalker.query_return query20 = default(HqlSqlWalker.query_return);



        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:166:2: ( expr | query )
            int alt7 = 2;
            int LA7_0 = input.LA(1);

            if ( (LA7_0 == COUNT || LA7_0 == DOT || LA7_0 == FALSE || LA7_0 == NULL || LA7_0 == TRUE || LA7_0 == CASE || LA7_0 == AGGREGATE || LA7_0 == CASE2 || LA7_0 == INDEX_OP || LA7_0 == METHOD_CALL || LA7_0 == UNARY_MINUS || (LA7_0 >= VECTOR_EXPR && LA7_0 <= WEIRD_IDENT) || (LA7_0 >= NUM_INT && LA7_0 <= JAVA_CONSTANT) || (LA7_0 >= PLUS && LA7_0 <= DIV) || (LA7_0 >= COLON && LA7_0 <= PARAM) || LA7_0 == IDENT || LA7_0 == QUOTED_STRING) )
            {
                alt7 = 1;
            }
            else if ( (LA7_0 == QUERY) )
            {
                alt7 = 2;
            }
            else 
            {
                NoViableAltException nvae_d7s0 =
                    new NoViableAltException("", 7, 0, input);

                throw nvae_d7s0;
            }
            switch (alt7) 
            {
                case 1 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:166:4: expr
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_expr_in_newValue459);
                    	expr19 = expr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, expr19.Tree);

                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:166:11: query
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_query_in_newValue463);
                    	query20 = query();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, query20.Tree);

                    }
                    break;

            }
            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "newValue"

    public class query_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "query"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:192:1: query : ^( QUERY ^( SELECT_FROM f= fromClause (s= selectClause )? ) (w= whereClause )? (g= groupClause )? (o= orderClause )? ) -> ^( SELECT ( $s)? $f ( $w)? ( $g)? ( $o)? ) ;
    public HqlSqlWalker.query_return query() // throws RecognitionException [1]
    {   
        HqlSqlWalker.query_return retval = new HqlSqlWalker.query_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree QUERY21 = null;
        CommonTree SELECT_FROM22 = null;
        HqlSqlWalker.fromClause_return f = default(HqlSqlWalker.fromClause_return);

        HqlSqlWalker.selectClause_return s = default(HqlSqlWalker.selectClause_return);

        HqlSqlWalker.whereClause_return w = default(HqlSqlWalker.whereClause_return);

        HqlSqlWalker.groupClause_return g = default(HqlSqlWalker.groupClause_return);

        HqlSqlWalker.orderClause_return o = default(HqlSqlWalker.orderClause_return);


        CommonTree QUERY21_tree=null;
        CommonTree SELECT_FROM22_tree=null;
        RewriteRuleNodeStream stream_QUERY = new RewriteRuleNodeStream(adaptor,"token QUERY");
        RewriteRuleNodeStream stream_SELECT_FROM = new RewriteRuleNodeStream(adaptor,"token SELECT_FROM");
        RewriteRuleSubtreeStream stream_selectClause = new RewriteRuleSubtreeStream(adaptor,"rule selectClause");
        RewriteRuleSubtreeStream stream_fromClause = new RewriteRuleSubtreeStream(adaptor,"rule fromClause");
        RewriteRuleSubtreeStream stream_orderClause = new RewriteRuleSubtreeStream(adaptor,"rule orderClause");
        RewriteRuleSubtreeStream stream_whereClause = new RewriteRuleSubtreeStream(adaptor,"rule whereClause");
        RewriteRuleSubtreeStream stream_groupClause = new RewriteRuleSubtreeStream(adaptor,"rule groupClause");
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:199:2: ( ^( QUERY ^( SELECT_FROM f= fromClause (s= selectClause )? ) (w= whereClause )? (g= groupClause )? (o= orderClause )? ) -> ^( SELECT ( $s)? $f ( $w)? ( $g)? ( $o)? ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:199:4: ^( QUERY ^( SELECT_FROM f= fromClause (s= selectClause )? ) (w= whereClause )? (g= groupClause )? (o= orderClause )? )
            {
            	_last = (CommonTree)input.LT(1);
            	{
            	CommonTree _save_last_1 = _last;
            	CommonTree _first_1 = null;
            	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	QUERY21=(CommonTree)Match(input,QUERY,FOLLOW_QUERY_in_query487);  
            	stream_QUERY.Add(QUERY21);


            	 beforeStatement( "select", SELECT ); 

            	Match(input, Token.DOWN, null); 
            	_last = (CommonTree)input.LT(1);
            	{
            	CommonTree _save_last_2 = _last;
            	CommonTree _first_2 = null;
            	CommonTree root_2 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	SELECT_FROM22=(CommonTree)Match(input,SELECT_FROM,FOLLOW_SELECT_FROM_in_query499);  
            	stream_SELECT_FROM.Add(SELECT_FROM22);



            	Match(input, Token.DOWN, null); 
            	_last = (CommonTree)input.LT(1);
            	PushFollow(FOLLOW_fromClause_in_query507);
            	f = fromClause();
            	state.followingStackPointer--;

            	stream_fromClause.Add(f.Tree);
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:203:5: (s= selectClause )?
            	int alt8 = 2;
            	int LA8_0 = input.LA(1);

            	if ( (LA8_0 == SELECT) )
            	{
            	    alt8 = 1;
            	}
            	switch (alt8) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:203:6: s= selectClause
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_selectClause_in_query516);
            	        	s = selectClause();
            	        	state.followingStackPointer--;

            	        	stream_selectClause.Add(s.Tree);

            	        }
            	        break;

            	}


            	Match(input, Token.UP, null); adaptor.AddChild(root_1, root_2);_last = _save_last_2;
            	}

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:205:4: (w= whereClause )?
            	int alt9 = 2;
            	int LA9_0 = input.LA(1);

            	if ( (LA9_0 == WHERE) )
            	{
            	    alt9 = 1;
            	}
            	switch (alt9) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:205:5: w= whereClause
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_whereClause_in_query531);
            	        	w = whereClause();
            	        	state.followingStackPointer--;

            	        	stream_whereClause.Add(w.Tree);

            	        }
            	        break;

            	}

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:206:4: (g= groupClause )?
            	int alt10 = 2;
            	int LA10_0 = input.LA(1);

            	if ( (LA10_0 == GROUP) )
            	{
            	    alt10 = 1;
            	}
            	switch (alt10) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:206:5: g= groupClause
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_groupClause_in_query541);
            	        	g = groupClause();
            	        	state.followingStackPointer--;

            	        	stream_groupClause.Add(g.Tree);

            	        }
            	        break;

            	}

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:207:4: (o= orderClause )?
            	int alt11 = 2;
            	int LA11_0 = input.LA(1);

            	if ( (LA11_0 == ORDER) )
            	{
            	    alt11 = 1;
            	}
            	switch (alt11) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:207:5: o= orderClause
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_orderClause_in_query551);
            	        	o = orderClause();
            	        	state.followingStackPointer--;

            	        	stream_orderClause.Add(o.Tree);

            	        }
            	        break;

            	}


            	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	}



            	// AST REWRITE
            	// elements:          w, s, o, g, f
            	// token labels:      
            	// rule labels:       o, w, f, retval, g, s
            	// token list labels: 
            	// rule list labels:  
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_o = new RewriteRuleSubtreeStream(adaptor, "token o", (o!=null ? o.Tree : null));
            	RewriteRuleSubtreeStream stream_w = new RewriteRuleSubtreeStream(adaptor, "token w", (w!=null ? w.Tree : null));
            	RewriteRuleSubtreeStream stream_f = new RewriteRuleSubtreeStream(adaptor, "token f", (f!=null ? f.Tree : null));
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));
            	RewriteRuleSubtreeStream stream_g = new RewriteRuleSubtreeStream(adaptor, "token g", (g!=null ? g.Tree : null));
            	RewriteRuleSubtreeStream stream_s = new RewriteRuleSubtreeStream(adaptor, "token s", (s!=null ? s.Tree : null));

            	root_0 = (CommonTree)adaptor.GetNilNode();
            	// 209:2: -> ^( SELECT ( $s)? $f ( $w)? ( $g)? ( $o)? )
            	{
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:209:5: ^( SELECT ( $s)? $f ( $w)? ( $g)? ( $o)? )
            	    {
            	    CommonTree root_1 = (CommonTree)adaptor.GetNilNode();
            	    root_1 = (CommonTree)adaptor.BecomeRoot((CommonTree)adaptor.Create(SELECT, "SELECT"), root_1);

            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:209:14: ( $s)?
            	    if ( stream_s.HasNext() )
            	    {
            	        adaptor.AddChild(root_1, stream_s.NextTree());

            	    }
            	    stream_s.Reset();
            	    adaptor.AddChild(root_1, stream_f.NextTree());
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:209:21: ( $w)?
            	    if ( stream_w.HasNext() )
            	    {
            	        adaptor.AddChild(root_1, stream_w.NextTree());

            	    }
            	    stream_w.Reset();
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:209:25: ( $g)?
            	    if ( stream_g.HasNext() )
            	    {
            	        adaptor.AddChild(root_1, stream_g.NextTree());

            	    }
            	    stream_g.Reset();
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:209:29: ( $o)?
            	    if ( stream_o.HasNext() )
            	    {
            	        adaptor.AddChild(root_1, stream_o.NextTree());

            	    }
            	    stream_o.Reset();

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;
            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);


            		// Antlr note: #x_in refers to the input AST, #x refers to the output AST
            		beforeStatementCompletion( "select" );
            		processQuery( ((s != null) ? ((CommonTree)s.Tree) : null), ((CommonTree)retval.Tree) );
            		afterStatementCompletion( "select" );
            	
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "query"

    public class orderClause_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "orderClause"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:212:1: orderClause : ^( ORDER orderExprs ) ;
    public HqlSqlWalker.orderClause_return orderClause() // throws RecognitionException [1]
    {   
        HqlSqlWalker.orderClause_return retval = new HqlSqlWalker.orderClause_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree ORDER23 = null;
        HqlSqlWalker.orderExprs_return orderExprs24 = default(HqlSqlWalker.orderExprs_return);


        CommonTree ORDER23_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:213:2: ( ^( ORDER orderExprs ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:213:4: ^( ORDER orderExprs )
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	_last = (CommonTree)input.LT(1);
            	{
            	CommonTree _save_last_1 = _last;
            	CommonTree _first_1 = null;
            	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	ORDER23=(CommonTree)Match(input,ORDER,FOLLOW_ORDER_in_orderClause596); 
            		ORDER23_tree = (CommonTree)adaptor.DupNode(ORDER23);

            		root_1 = (CommonTree)adaptor.BecomeRoot(ORDER23_tree, root_1);


            	 handleClauseStart( ORDER ); 

            	Match(input, Token.DOWN, null); 
            	_last = (CommonTree)input.LT(1);
            	PushFollow(FOLLOW_orderExprs_in_orderClause600);
            	orderExprs24 = orderExprs();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_1, orderExprs24.Tree);

            	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	}


            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "orderClause"

    public class orderExprs_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "orderExprs"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:216:1: orderExprs : expr ( ASCENDING | DESCENDING )? ( orderExprs )? ;
    public HqlSqlWalker.orderExprs_return orderExprs() // throws RecognitionException [1]
    {   
        HqlSqlWalker.orderExprs_return retval = new HqlSqlWalker.orderExprs_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree set26 = null;
        HqlSqlWalker.expr_return expr25 = default(HqlSqlWalker.expr_return);

        HqlSqlWalker.orderExprs_return orderExprs27 = default(HqlSqlWalker.orderExprs_return);


        CommonTree set26_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:217:2: ( expr ( ASCENDING | DESCENDING )? ( orderExprs )? )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:217:4: expr ( ASCENDING | DESCENDING )? ( orderExprs )?
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	_last = (CommonTree)input.LT(1);
            	PushFollow(FOLLOW_expr_in_orderExprs612);
            	expr25 = expr();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, expr25.Tree);
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:217:9: ( ASCENDING | DESCENDING )?
            	int alt12 = 2;
            	int LA12_0 = input.LA(1);

            	if ( (LA12_0 == ASCENDING || LA12_0 == DESCENDING) )
            	{
            	    alt12 = 1;
            	}
            	switch (alt12) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	set26 = (CommonTree)input.LT(1);
            	        	if ( input.LA(1) == ASCENDING || input.LA(1) == DESCENDING ) 
            	        	{
            	        	    input.Consume();

            	        	    set26_tree = (CommonTree)adaptor.DupNode(set26);

            	        	    adaptor.AddChild(root_0, set26_tree);

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

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:217:37: ( orderExprs )?
            	int alt13 = 2;
            	int LA13_0 = input.LA(1);

            	if ( (LA13_0 == COUNT || LA13_0 == DOT || LA13_0 == FALSE || LA13_0 == NULL || LA13_0 == TRUE || LA13_0 == CASE || LA13_0 == AGGREGATE || LA13_0 == CASE2 || LA13_0 == INDEX_OP || LA13_0 == METHOD_CALL || LA13_0 == UNARY_MINUS || (LA13_0 >= VECTOR_EXPR && LA13_0 <= WEIRD_IDENT) || (LA13_0 >= NUM_INT && LA13_0 <= JAVA_CONSTANT) || (LA13_0 >= PLUS && LA13_0 <= DIV) || (LA13_0 >= COLON && LA13_0 <= PARAM) || LA13_0 == IDENT || LA13_0 == QUOTED_STRING) )
            	{
            	    alt13 = 1;
            	}
            	switch (alt13) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:217:38: orderExprs
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_orderExprs_in_orderExprs626);
            	        	orderExprs27 = orderExprs();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, orderExprs27.Tree);

            	        }
            	        break;

            	}


            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "orderExprs"

    public class groupClause_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "groupClause"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:220:1: groupClause : ^( GROUP ( expr )+ ( ^( HAVING logicalExpr ) )? ) ;
    public HqlSqlWalker.groupClause_return groupClause() // throws RecognitionException [1]
    {   
        HqlSqlWalker.groupClause_return retval = new HqlSqlWalker.groupClause_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree GROUP28 = null;
        CommonTree HAVING30 = null;
        HqlSqlWalker.expr_return expr29 = default(HqlSqlWalker.expr_return);

        HqlSqlWalker.logicalExpr_return logicalExpr31 = default(HqlSqlWalker.logicalExpr_return);


        CommonTree GROUP28_tree=null;
        CommonTree HAVING30_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:221:2: ( ^( GROUP ( expr )+ ( ^( HAVING logicalExpr ) )? ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:221:4: ^( GROUP ( expr )+ ( ^( HAVING logicalExpr ) )? )
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	_last = (CommonTree)input.LT(1);
            	{
            	CommonTree _save_last_1 = _last;
            	CommonTree _first_1 = null;
            	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	GROUP28=(CommonTree)Match(input,GROUP,FOLLOW_GROUP_in_groupClause640); 
            		GROUP28_tree = (CommonTree)adaptor.DupNode(GROUP28);

            		root_1 = (CommonTree)adaptor.BecomeRoot(GROUP28_tree, root_1);


            	 handleClauseStart( GROUP ); 

            	Match(input, Token.DOWN, null); 
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:221:44: ( expr )+
            	int cnt14 = 0;
            	do 
            	{
            	    int alt14 = 2;
            	    int LA14_0 = input.LA(1);

            	    if ( (LA14_0 == COUNT || LA14_0 == DOT || LA14_0 == FALSE || LA14_0 == NULL || LA14_0 == TRUE || LA14_0 == CASE || LA14_0 == AGGREGATE || LA14_0 == CASE2 || LA14_0 == INDEX_OP || LA14_0 == METHOD_CALL || LA14_0 == UNARY_MINUS || (LA14_0 >= VECTOR_EXPR && LA14_0 <= WEIRD_IDENT) || (LA14_0 >= NUM_INT && LA14_0 <= JAVA_CONSTANT) || (LA14_0 >= PLUS && LA14_0 <= DIV) || (LA14_0 >= COLON && LA14_0 <= PARAM) || LA14_0 == IDENT || LA14_0 == QUOTED_STRING) )
            	    {
            	        alt14 = 1;
            	    }


            	    switch (alt14) 
            		{
            			case 1 :
            			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:221:45: expr
            			    {
            			    	_last = (CommonTree)input.LT(1);
            			    	PushFollow(FOLLOW_expr_in_groupClause645);
            			    	expr29 = expr();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_1, expr29.Tree);

            			    }
            			    break;

            			default:
            			    if ( cnt14 >= 1 ) goto loop14;
            		            EarlyExitException eee =
            		                new EarlyExitException(14, input);
            		            throw eee;
            	    }
            	    cnt14++;
            	} while (true);

            	loop14:
            		;	// Stops C# compiler whinging that label 'loop14' has no statements

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:221:52: ( ^( HAVING logicalExpr ) )?
            	int alt15 = 2;
            	int LA15_0 = input.LA(1);

            	if ( (LA15_0 == HAVING) )
            	{
            	    alt15 = 1;
            	}
            	switch (alt15) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:221:54: ^( HAVING logicalExpr )
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	{
            	        	CommonTree _save_last_2 = _last;
            	        	CommonTree _first_2 = null;
            	        	CommonTree root_2 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	        	HAVING30=(CommonTree)Match(input,HAVING,FOLLOW_HAVING_in_groupClause652); 
            	        		HAVING30_tree = (CommonTree)adaptor.DupNode(HAVING30);

            	        		root_2 = (CommonTree)adaptor.BecomeRoot(HAVING30_tree, root_2);



            	        	Match(input, Token.DOWN, null); 
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_logicalExpr_in_groupClause654);
            	        	logicalExpr31 = logicalExpr();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_2, logicalExpr31.Tree);

            	        	Match(input, Token.UP, null); adaptor.AddChild(root_1, root_2);_last = _save_last_2;
            	        	}


            	        }
            	        break;

            	}


            	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	}


            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "groupClause"

    public class selectClause_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "selectClause"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:232:1: selectClause : ^( SELECT (d= DISTINCT )? x= selectExprList ) -> ^( SELECT_CLAUSE ( $d)? $x) ;
    public HqlSqlWalker.selectClause_return selectClause() // throws RecognitionException [1]
    {   
        HqlSqlWalker.selectClause_return retval = new HqlSqlWalker.selectClause_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree d = null;
        CommonTree SELECT32 = null;
        HqlSqlWalker.selectExprList_return x = default(HqlSqlWalker.selectExprList_return);


        CommonTree d_tree=null;
        CommonTree SELECT32_tree=null;
        RewriteRuleNodeStream stream_DISTINCT = new RewriteRuleNodeStream(adaptor,"token DISTINCT");
        RewriteRuleNodeStream stream_SELECT = new RewriteRuleNodeStream(adaptor,"token SELECT");
        RewriteRuleSubtreeStream stream_selectExprList = new RewriteRuleSubtreeStream(adaptor,"rule selectExprList");
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:233:2: ( ^( SELECT (d= DISTINCT )? x= selectExprList ) -> ^( SELECT_CLAUSE ( $d)? $x) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:233:4: ^( SELECT (d= DISTINCT )? x= selectExprList )
            {
            	_last = (CommonTree)input.LT(1);
            	{
            	CommonTree _save_last_1 = _last;
            	CommonTree _first_1 = null;
            	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	SELECT32=(CommonTree)Match(input,SELECT,FOLLOW_SELECT_in_selectClause675);  
            	stream_SELECT.Add(SELECT32);


            	 handleClauseStart( SELECT ); beforeSelectClause(); 

            	Match(input, Token.DOWN, null); 
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:233:68: (d= DISTINCT )?
            	int alt16 = 2;
            	int LA16_0 = input.LA(1);

            	if ( (LA16_0 == DISTINCT) )
            	{
            	    alt16 = 1;
            	}
            	switch (alt16) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:233:69: d= DISTINCT
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	d=(CommonTree)Match(input,DISTINCT,FOLLOW_DISTINCT_in_selectClause682);  
            	        	stream_DISTINCT.Add(d);


            	        }
            	        break;

            	}

            	_last = (CommonTree)input.LT(1);
            	PushFollow(FOLLOW_selectExprList_in_selectClause688);
            	x = selectExprList();
            	state.followingStackPointer--;

            	stream_selectExprList.Add(x.Tree);

            	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	}



            	// AST REWRITE
            	// elements:          d, x
            	// token labels:      d
            	// rule labels:       retval, x
            	// token list labels: 
            	// rule list labels:  
            	retval.Tree = root_0;
            	RewriteRuleNodeStream stream_d = new RewriteRuleNodeStream(adaptor, "token d", d);
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));
            	RewriteRuleSubtreeStream stream_x = new RewriteRuleSubtreeStream(adaptor, "token x", (x!=null ? x.Tree : null));

            	root_0 = (CommonTree)adaptor.GetNilNode();
            	// 234:2: -> ^( SELECT_CLAUSE ( $d)? $x)
            	{
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:234:5: ^( SELECT_CLAUSE ( $d)? $x)
            	    {
            	    CommonTree root_1 = (CommonTree)adaptor.GetNilNode();
            	    root_1 = (CommonTree)adaptor.BecomeRoot((CommonTree)adaptor.Create(SELECT_CLAUSE, "SELECT_CLAUSE"), root_1);

            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:234:21: ( $d)?
            	    if ( stream_d.HasNext() )
            	    {
            	        adaptor.AddChild(root_1, stream_d.NextNode());

            	    }
            	    stream_d.Reset();
            	    adaptor.AddChild(root_1, stream_x.NextTree());

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;
            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "selectClause"

    public class selectExprList_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "selectExprList"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:237:1: selectExprList : ( selectExpr | aliasedSelectExpr )+ ;
    public HqlSqlWalker.selectExprList_return selectExprList() // throws RecognitionException [1]
    {   
        HqlSqlWalker.selectExprList_return retval = new HqlSqlWalker.selectExprList_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        HqlSqlWalker.selectExpr_return selectExpr33 = default(HqlSqlWalker.selectExpr_return);

        HqlSqlWalker.aliasedSelectExpr_return aliasedSelectExpr34 = default(HqlSqlWalker.aliasedSelectExpr_return);




        		bool oldInSelect = _inSelect;
        		_inSelect = true;
        	
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:241:2: ( ( selectExpr | aliasedSelectExpr )+ )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:241:4: ( selectExpr | aliasedSelectExpr )+
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:241:4: ( selectExpr | aliasedSelectExpr )+
            	int cnt17 = 0;
            	do 
            	{
            	    int alt17 = 3;
            	    int LA17_0 = input.LA(1);

            	    if ( (LA17_0 == ALL || LA17_0 == COUNT || LA17_0 == DOT || LA17_0 == ELEMENTS || LA17_0 == INDICES || LA17_0 == CASE || LA17_0 == OBJECT || LA17_0 == AGGREGATE || (LA17_0 >= CONSTRUCTOR && LA17_0 <= CASE2) || LA17_0 == METHOD_CALL || LA17_0 == QUERY || LA17_0 == UNARY_MINUS || LA17_0 == WEIRD_IDENT || (LA17_0 >= NUM_INT && LA17_0 <= NUM_LONG) || (LA17_0 >= PLUS && LA17_0 <= DIV) || LA17_0 == IDENT || LA17_0 == QUOTED_STRING) )
            	    {
            	        alt17 = 1;
            	    }
            	    else if ( (LA17_0 == AS) )
            	    {
            	        alt17 = 2;
            	    }


            	    switch (alt17) 
            		{
            			case 1 :
            			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:241:6: selectExpr
            			    {
            			    	_last = (CommonTree)input.LT(1);
            			    	PushFollow(FOLLOW_selectExpr_in_selectExprList722);
            			    	selectExpr33 = selectExpr();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, selectExpr33.Tree);

            			    }
            			    break;
            			case 2 :
            			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:241:19: aliasedSelectExpr
            			    {
            			    	_last = (CommonTree)input.LT(1);
            			    	PushFollow(FOLLOW_aliasedSelectExpr_in_selectExprList726);
            			    	aliasedSelectExpr34 = aliasedSelectExpr();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, aliasedSelectExpr34.Tree);

            			    }
            			    break;

            			default:
            			    if ( cnt17 >= 1 ) goto loop17;
            		            EarlyExitException eee =
            		                new EarlyExitException(17, input);
            		            throw eee;
            	    }
            	    cnt17++;
            	} while (true);

            	loop17:
            		;	// Stops C# compiler whinging that label 'loop17' has no statements


            			_inSelect = oldInSelect;
            		

            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "selectExprList"

    public class aliasedSelectExpr_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "aliasedSelectExpr"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:255:1: aliasedSelectExpr : ^( AS se= selectExpr i= identifier ) ;
    public HqlSqlWalker.aliasedSelectExpr_return aliasedSelectExpr() // throws RecognitionException [1]
    {   
        HqlSqlWalker.aliasedSelectExpr_return retval = new HqlSqlWalker.aliasedSelectExpr_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree AS35 = null;
        HqlSqlWalker.selectExpr_return se = default(HqlSqlWalker.selectExpr_return);

        HqlSqlWalker.identifier_return i = default(HqlSqlWalker.identifier_return);


        CommonTree AS35_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:260:2: ( ^( AS se= selectExpr i= identifier ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:260:4: ^( AS se= selectExpr i= identifier )
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	_last = (CommonTree)input.LT(1);
            	{
            	CommonTree _save_last_1 = _last;
            	CommonTree _first_1 = null;
            	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	AS35=(CommonTree)Match(input,AS,FOLLOW_AS_in_aliasedSelectExpr752); 
            		AS35_tree = (CommonTree)adaptor.DupNode(AS35);

            		root_1 = (CommonTree)adaptor.BecomeRoot(AS35_tree, root_1);



            	Match(input, Token.DOWN, null); 
            	_last = (CommonTree)input.LT(1);
            	PushFollow(FOLLOW_selectExpr_in_aliasedSelectExpr756);
            	se = selectExpr();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_1, se.Tree);
            	_last = (CommonTree)input.LT(1);
            	PushFollow(FOLLOW_identifier_in_aliasedSelectExpr760);
            	i = identifier();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_1, i.Tree);

            	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	}


            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);


            	    setAlias(((se != null) ? ((CommonTree)se.Tree) : null),((i != null) ? ((CommonTree)i.Tree) : null));
            	    retval.Tree =  ((se != null) ? ((CommonTree)se.Tree) : null);
            	
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "aliasedSelectExpr"

    public class selectExpr_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "selectExpr"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:278:1: selectExpr : (p= propertyRef | ^( ALL ar2= aliasRef ) | ^( OBJECT ar3= aliasRef ) | con= constructor | functionCall | count | collectionFunction | literal | arithmeticExpr | query );
    public HqlSqlWalker.selectExpr_return selectExpr() // throws RecognitionException [1]
    {   
        HqlSqlWalker.selectExpr_return retval = new HqlSqlWalker.selectExpr_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree ALL36 = null;
        CommonTree OBJECT37 = null;
        HqlSqlWalker.propertyRef_return p = default(HqlSqlWalker.propertyRef_return);

        HqlSqlWalker.aliasRef_return ar2 = default(HqlSqlWalker.aliasRef_return);

        HqlSqlWalker.aliasRef_return ar3 = default(HqlSqlWalker.aliasRef_return);

        HqlSqlWalker.constructor_return con = default(HqlSqlWalker.constructor_return);

        HqlSqlWalker.functionCall_return functionCall38 = default(HqlSqlWalker.functionCall_return);

        HqlSqlWalker.count_return count39 = default(HqlSqlWalker.count_return);

        HqlSqlWalker.collectionFunction_return collectionFunction40 = default(HqlSqlWalker.collectionFunction_return);

        HqlSqlWalker.literal_return literal41 = default(HqlSqlWalker.literal_return);

        HqlSqlWalker.arithmeticExpr_return arithmeticExpr42 = default(HqlSqlWalker.arithmeticExpr_return);

        HqlSqlWalker.query_return query43 = default(HqlSqlWalker.query_return);


        CommonTree ALL36_tree=null;
        CommonTree OBJECT37_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:279:2: (p= propertyRef | ^( ALL ar2= aliasRef ) | ^( OBJECT ar3= aliasRef ) | con= constructor | functionCall | count | collectionFunction | literal | arithmeticExpr | query )
            int alt18 = 10;
            switch ( input.LA(1) ) 
            {
            case DOT:
            case WEIRD_IDENT:
            case IDENT:
            	{
                alt18 = 1;
                }
                break;
            case ALL:
            	{
                alt18 = 2;
                }
                break;
            case OBJECT:
            	{
                alt18 = 3;
                }
                break;
            case CONSTRUCTOR:
            	{
                alt18 = 4;
                }
                break;
            case AGGREGATE:
            case METHOD_CALL:
            	{
                alt18 = 5;
                }
                break;
            case COUNT:
            	{
                alt18 = 6;
                }
                break;
            case ELEMENTS:
            case INDICES:
            	{
                alt18 = 7;
                }
                break;
            case NUM_INT:
            case NUM_DOUBLE:
            case NUM_FLOAT:
            case NUM_LONG:
            case QUOTED_STRING:
            	{
                alt18 = 8;
                }
                break;
            case CASE:
            case CASE2:
            case UNARY_MINUS:
            case PLUS:
            case MINUS:
            case STAR:
            case DIV:
            	{
                alt18 = 9;
                }
                break;
            case QUERY:
            	{
                alt18 = 10;
                }
                break;
            	default:
            	    NoViableAltException nvae_d18s0 =
            	        new NoViableAltException("", 18, 0, input);

            	    throw nvae_d18s0;
            }

            switch (alt18) 
            {
                case 1 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:279:4: p= propertyRef
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_propertyRef_in_selectExpr777);
                    	p = propertyRef();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, p.Tree);
                    	 resolveSelectExpression(((p != null) ? ((CommonTree)p.Tree) : null)); 

                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:280:4: ^( ALL ar2= aliasRef )
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	ALL36=(CommonTree)Match(input,ALL,FOLLOW_ALL_in_selectExpr789); 
                    		ALL36_tree = (CommonTree)adaptor.DupNode(ALL36);

                    		root_1 = (CommonTree)adaptor.BecomeRoot(ALL36_tree, root_1);



                    	Match(input, Token.DOWN, null); 
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_aliasRef_in_selectExpr793);
                    	ar2 = aliasRef();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_1, ar2.Tree);

                    	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
                    	}

                    	 resolveSelectExpression(((ar2 != null) ? ((CommonTree)ar2.Tree) : null)); retval.Tree =  ((ar2 != null) ? ((CommonTree)ar2.Tree) : null); 

                    }
                    break;
                case 3 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:281:4: ^( OBJECT ar3= aliasRef )
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	OBJECT37=(CommonTree)Match(input,OBJECT,FOLLOW_OBJECT_in_selectExpr805); 
                    		OBJECT37_tree = (CommonTree)adaptor.DupNode(OBJECT37);

                    		root_1 = (CommonTree)adaptor.BecomeRoot(OBJECT37_tree, root_1);



                    	Match(input, Token.DOWN, null); 
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_aliasRef_in_selectExpr809);
                    	ar3 = aliasRef();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_1, ar3.Tree);

                    	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
                    	}

                    	 resolveSelectExpression(((ar3 != null) ? ((CommonTree)ar3.Tree) : null)); retval.Tree =  ((ar3 != null) ? ((CommonTree)ar3.Tree) : null); 

                    }
                    break;
                case 4 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:282:4: con= constructor
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_constructor_in_selectExpr820);
                    	con = constructor();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, con.Tree);
                    	 processConstructor(((con != null) ? ((CommonTree)con.Tree) : null)); 

                    }
                    break;
                case 5 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:283:4: functionCall
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_functionCall_in_selectExpr831);
                    	functionCall38 = functionCall();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, functionCall38.Tree);

                    }
                    break;
                case 6 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:284:4: count
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_count_in_selectExpr836);
                    	count39 = count();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, count39.Tree);

                    }
                    break;
                case 7 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:285:4: collectionFunction
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_collectionFunction_in_selectExpr841);
                    	collectionFunction40 = collectionFunction();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, collectionFunction40.Tree);

                    }
                    break;
                case 8 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:286:4: literal
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_literal_in_selectExpr849);
                    	literal41 = literal();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, literal41.Tree);

                    }
                    break;
                case 9 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:287:4: arithmeticExpr
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_arithmeticExpr_in_selectExpr854);
                    	arithmeticExpr42 = arithmeticExpr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, arithmeticExpr42.Tree);

                    }
                    break;
                case 10 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:288:4: query
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_query_in_selectExpr859);
                    	query43 = query();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, query43.Tree);

                    }
                    break;

            }
            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "selectExpr"

    public class count_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "count"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:291:1: count : ^( COUNT ( DISTINCT | ALL )? ( aggregateExpr | ROW_STAR ) ) ;
    public HqlSqlWalker.count_return count() // throws RecognitionException [1]
    {   
        HqlSqlWalker.count_return retval = new HqlSqlWalker.count_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree COUNT44 = null;
        CommonTree set45 = null;
        CommonTree ROW_STAR47 = null;
        HqlSqlWalker.aggregateExpr_return aggregateExpr46 = default(HqlSqlWalker.aggregateExpr_return);


        CommonTree COUNT44_tree=null;
        CommonTree set45_tree=null;
        CommonTree ROW_STAR47_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:292:2: ( ^( COUNT ( DISTINCT | ALL )? ( aggregateExpr | ROW_STAR ) ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:292:4: ^( COUNT ( DISTINCT | ALL )? ( aggregateExpr | ROW_STAR ) )
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	_last = (CommonTree)input.LT(1);
            	{
            	CommonTree _save_last_1 = _last;
            	CommonTree _first_1 = null;
            	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	COUNT44=(CommonTree)Match(input,COUNT,FOLLOW_COUNT_in_count871); 
            		COUNT44_tree = (CommonTree)adaptor.DupNode(COUNT44);

            		root_1 = (CommonTree)adaptor.BecomeRoot(COUNT44_tree, root_1);



            	Match(input, Token.DOWN, null); 
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:292:12: ( DISTINCT | ALL )?
            	int alt19 = 2;
            	int LA19_0 = input.LA(1);

            	if ( (LA19_0 == ALL || LA19_0 == DISTINCT) )
            	{
            	    alt19 = 1;
            	}
            	switch (alt19) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	set45 = (CommonTree)input.LT(1);
            	        	if ( input.LA(1) == ALL || input.LA(1) == DISTINCT ) 
            	        	{
            	        	    input.Consume();

            	        	    set45_tree = (CommonTree)adaptor.DupNode(set45);

            	        	    adaptor.AddChild(root_1, set45_tree);

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

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:292:32: ( aggregateExpr | ROW_STAR )
            	int alt20 = 2;
            	int LA20_0 = input.LA(1);

            	if ( (LA20_0 == COUNT || LA20_0 == DOT || LA20_0 == ELEMENTS || LA20_0 == FALSE || LA20_0 == INDICES || LA20_0 == NULL || LA20_0 == TRUE || LA20_0 == CASE || LA20_0 == AGGREGATE || LA20_0 == CASE2 || LA20_0 == INDEX_OP || LA20_0 == METHOD_CALL || LA20_0 == UNARY_MINUS || (LA20_0 >= VECTOR_EXPR && LA20_0 <= WEIRD_IDENT) || (LA20_0 >= NUM_INT && LA20_0 <= JAVA_CONSTANT) || (LA20_0 >= PLUS && LA20_0 <= DIV) || (LA20_0 >= COLON && LA20_0 <= PARAM) || LA20_0 == IDENT || LA20_0 == QUOTED_STRING) )
            	{
            	    alt20 = 1;
            	}
            	else if ( (LA20_0 == ROW_STAR) )
            	{
            	    alt20 = 2;
            	}
            	else 
            	{
            	    NoViableAltException nvae_d20s0 =
            	        new NoViableAltException("", 20, 0, input);

            	    throw nvae_d20s0;
            	}
            	switch (alt20) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:292:34: aggregateExpr
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_aggregateExpr_in_count886);
            	        	aggregateExpr46 = aggregateExpr();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, aggregateExpr46.Tree);

            	        }
            	        break;
            	    case 2 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:292:50: ROW_STAR
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	ROW_STAR47=(CommonTree)Match(input,ROW_STAR,FOLLOW_ROW_STAR_in_count890); 
            	        		ROW_STAR47_tree = (CommonTree)adaptor.DupNode(ROW_STAR47);

            	        		adaptor.AddChild(root_1, ROW_STAR47_tree);


            	        }
            	        break;

            	}


            	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	}


            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "count"

    public class constructor_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "constructor"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:302:1: constructor : ^( CONSTRUCTOR path ( selectExpr | aliasedSelectExpr )* ) ;
    public HqlSqlWalker.constructor_return constructor() // throws RecognitionException [1]
    {   
        HqlSqlWalker.constructor_return retval = new HqlSqlWalker.constructor_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree CONSTRUCTOR48 = null;
        HqlSqlWalker.path_return path49 = default(HqlSqlWalker.path_return);

        HqlSqlWalker.selectExpr_return selectExpr50 = default(HqlSqlWalker.selectExpr_return);

        HqlSqlWalker.aliasedSelectExpr_return aliasedSelectExpr51 = default(HqlSqlWalker.aliasedSelectExpr_return);


        CommonTree CONSTRUCTOR48_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:303:2: ( ^( CONSTRUCTOR path ( selectExpr | aliasedSelectExpr )* ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:303:4: ^( CONSTRUCTOR path ( selectExpr | aliasedSelectExpr )* )
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	_last = (CommonTree)input.LT(1);
            	{
            	CommonTree _save_last_1 = _last;
            	CommonTree _first_1 = null;
            	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	CONSTRUCTOR48=(CommonTree)Match(input,CONSTRUCTOR,FOLLOW_CONSTRUCTOR_in_constructor908); 
            		CONSTRUCTOR48_tree = (CommonTree)adaptor.DupNode(CONSTRUCTOR48);

            		root_1 = (CommonTree)adaptor.BecomeRoot(CONSTRUCTOR48_tree, root_1);



            	Match(input, Token.DOWN, null); 
            	_last = (CommonTree)input.LT(1);
            	PushFollow(FOLLOW_path_in_constructor910);
            	path49 = path();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_1, path49.Tree);
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:303:23: ( selectExpr | aliasedSelectExpr )*
            	do 
            	{
            	    int alt21 = 3;
            	    int LA21_0 = input.LA(1);

            	    if ( (LA21_0 == ALL || LA21_0 == COUNT || LA21_0 == DOT || LA21_0 == ELEMENTS || LA21_0 == INDICES || LA21_0 == CASE || LA21_0 == OBJECT || LA21_0 == AGGREGATE || (LA21_0 >= CONSTRUCTOR && LA21_0 <= CASE2) || LA21_0 == METHOD_CALL || LA21_0 == QUERY || LA21_0 == UNARY_MINUS || LA21_0 == WEIRD_IDENT || (LA21_0 >= NUM_INT && LA21_0 <= NUM_LONG) || (LA21_0 >= PLUS && LA21_0 <= DIV) || LA21_0 == IDENT || LA21_0 == QUOTED_STRING) )
            	    {
            	        alt21 = 1;
            	    }
            	    else if ( (LA21_0 == AS) )
            	    {
            	        alt21 = 2;
            	    }


            	    switch (alt21) 
            		{
            			case 1 :
            			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:303:25: selectExpr
            			    {
            			    	_last = (CommonTree)input.LT(1);
            			    	PushFollow(FOLLOW_selectExpr_in_constructor914);
            			    	selectExpr50 = selectExpr();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_1, selectExpr50.Tree);

            			    }
            			    break;
            			case 2 :
            			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:303:38: aliasedSelectExpr
            			    {
            			    	_last = (CommonTree)input.LT(1);
            			    	PushFollow(FOLLOW_aliasedSelectExpr_in_constructor918);
            			    	aliasedSelectExpr51 = aliasedSelectExpr();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_1, aliasedSelectExpr51.Tree);

            			    }
            			    break;

            			default:
            			    goto loop21;
            	    }
            	} while (true);

            	loop21:
            		;	// Stops C# compiler whining that label 'loop21' has no statements


            	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	}


            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "constructor"

    public class aggregateExpr_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "aggregateExpr"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:306:1: aggregateExpr : ( expr | collectionFunction );
    public HqlSqlWalker.aggregateExpr_return aggregateExpr() // throws RecognitionException [1]
    {   
        HqlSqlWalker.aggregateExpr_return retval = new HqlSqlWalker.aggregateExpr_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        HqlSqlWalker.expr_return expr52 = default(HqlSqlWalker.expr_return);

        HqlSqlWalker.collectionFunction_return collectionFunction53 = default(HqlSqlWalker.collectionFunction_return);



        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:307:2: ( expr | collectionFunction )
            int alt22 = 2;
            int LA22_0 = input.LA(1);

            if ( (LA22_0 == COUNT || LA22_0 == DOT || LA22_0 == FALSE || LA22_0 == NULL || LA22_0 == TRUE || LA22_0 == CASE || LA22_0 == AGGREGATE || LA22_0 == CASE2 || LA22_0 == INDEX_OP || LA22_0 == METHOD_CALL || LA22_0 == UNARY_MINUS || (LA22_0 >= VECTOR_EXPR && LA22_0 <= WEIRD_IDENT) || (LA22_0 >= NUM_INT && LA22_0 <= JAVA_CONSTANT) || (LA22_0 >= PLUS && LA22_0 <= DIV) || (LA22_0 >= COLON && LA22_0 <= PARAM) || LA22_0 == IDENT || LA22_0 == QUOTED_STRING) )
            {
                alt22 = 1;
            }
            else if ( (LA22_0 == ELEMENTS || LA22_0 == INDICES) )
            {
                alt22 = 2;
            }
            else 
            {
                NoViableAltException nvae_d22s0 =
                    new NoViableAltException("", 22, 0, input);

                throw nvae_d22s0;
            }
            switch (alt22) 
            {
                case 1 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:307:4: expr
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_expr_in_aggregateExpr934);
                    	expr52 = expr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, expr52.Tree);

                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:308:4: collectionFunction
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_collectionFunction_in_aggregateExpr940);
                    	collectionFunction53 = collectionFunction();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, collectionFunction53.Tree);

                    }
                    break;

            }
            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "aggregateExpr"

    public class fromClause_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "fromClause"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:324:1: fromClause : ^(f= FROM fromElementList ) ;
    public HqlSqlWalker.fromClause_return fromClause() // throws RecognitionException [1]
    {   
        HqlSqlWalker.fromClause_return retval = new HqlSqlWalker.fromClause_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree f = null;
        HqlSqlWalker.fromElementList_return fromElementList54 = default(HqlSqlWalker.fromElementList_return);


        CommonTree f_tree=null;


        		// NOTE: This references the INPUT AST! (see http://www.antlr.org/doc/trees.html#Action Translation)
        		// the ouput AST (#fromClause) has not been built yet.
        		PrepareFromClauseInputTree((ITree) input.LT(1));
        	
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:330:2: ( ^(f= FROM fromElementList ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:330:4: ^(f= FROM fromElementList )
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	_last = (CommonTree)input.LT(1);
            	{
            	CommonTree _save_last_1 = _last;
            	CommonTree _first_1 = null;
            	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	f=(CommonTree)Match(input,FROM,FOLLOW_FROM_in_fromClause962); 
            		f_tree = (CommonTree)adaptor.DupNode(f);

            		root_1 = (CommonTree)adaptor.BecomeRoot(f_tree, root_1);


            	 PushFromClause(f_tree, null); handleClauseStart( FROM ); 

            	Match(input, Token.DOWN, null); 
            	_last = (CommonTree)input.LT(1);
            	PushFollow(FOLLOW_fromElementList_in_fromClause966);
            	fromElementList54 = fromElementList();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_1, fromElementList54.Tree);

            	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	}


            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "fromClause"

    public class fromElementList_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "fromElementList"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:333:1: fromElementList : ( fromElement )+ ;
    public HqlSqlWalker.fromElementList_return fromElementList() // throws RecognitionException [1]
    {   
        HqlSqlWalker.fromElementList_return retval = new HqlSqlWalker.fromElementList_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        HqlSqlWalker.fromElement_return fromElement55 = default(HqlSqlWalker.fromElement_return);




        		bool oldInFrom = _inFrom;
        		_inFrom = true;
        		
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:337:2: ( ( fromElement )+ )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:337:4: ( fromElement )+
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:337:4: ( fromElement )+
            	int cnt23 = 0;
            	do 
            	{
            	    int alt23 = 2;
            	    int LA23_0 = input.LA(1);

            	    if ( (LA23_0 == JOIN || LA23_0 == FILTER_ENTITY || LA23_0 == RANGE) )
            	    {
            	        alt23 = 1;
            	    }


            	    switch (alt23) 
            		{
            			case 1 :
            			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:337:5: fromElement
            			    {
            			    	_last = (CommonTree)input.LT(1);
            			    	PushFollow(FOLLOW_fromElement_in_fromElementList984);
            			    	fromElement55 = fromElement();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, fromElement55.Tree);

            			    }
            			    break;

            			default:
            			    if ( cnt23 >= 1 ) goto loop23;
            		            EarlyExitException eee =
            		                new EarlyExitException(23, input);
            		            throw eee;
            	    }
            	    cnt23++;
            	} while (true);

            	loop23:
            		;	// Stops C# compiler whinging that label 'loop23' has no statements


            			_inFrom = oldInFrom;
            			

            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "fromElementList"

    public class fromElement_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "fromElement"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:361:1: fromElement : ( ^( RANGE p= path (a= ALIAS )? (pf= FETCH )? ) -> ^() | je= joinElement -> ^( $je) | fe= FILTER_ENTITY a3= ALIAS -> ^() );
    public HqlSqlWalker.fromElement_return fromElement() // throws RecognitionException [1]
    {   
        HqlSqlWalker.fromElement_return retval = new HqlSqlWalker.fromElement_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree a = null;
        CommonTree pf = null;
        CommonTree fe = null;
        CommonTree a3 = null;
        CommonTree RANGE56 = null;
        HqlSqlWalker.path_return p = default(HqlSqlWalker.path_return);

        HqlSqlWalker.joinElement_return je = default(HqlSqlWalker.joinElement_return);


        CommonTree a_tree=null;
        CommonTree pf_tree=null;
        CommonTree fe_tree=null;
        CommonTree a3_tree=null;
        CommonTree RANGE56_tree=null;
        RewriteRuleNodeStream stream_FETCH = new RewriteRuleNodeStream(adaptor,"token FETCH");
        RewriteRuleNodeStream stream_RANGE = new RewriteRuleNodeStream(adaptor,"token RANGE");
        RewriteRuleNodeStream stream_FILTER_ENTITY = new RewriteRuleNodeStream(adaptor,"token FILTER_ENTITY");
        RewriteRuleNodeStream stream_ALIAS = new RewriteRuleNodeStream(adaptor,"token ALIAS");
        RewriteRuleSubtreeStream stream_joinElement = new RewriteRuleSubtreeStream(adaptor,"rule joinElement");
        RewriteRuleSubtreeStream stream_path = new RewriteRuleSubtreeStream(adaptor,"rule path");
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:363:2: ( ^( RANGE p= path (a= ALIAS )? (pf= FETCH )? ) -> ^() | je= joinElement -> ^( $je) | fe= FILTER_ENTITY a3= ALIAS -> ^() )
            int alt26 = 3;
            switch ( input.LA(1) ) 
            {
            case RANGE:
            	{
                alt26 = 1;
                }
                break;
            case JOIN:
            	{
                alt26 = 2;
                }
                break;
            case FILTER_ENTITY:
            	{
                alt26 = 3;
                }
                break;
            	default:
            	    NoViableAltException nvae_d26s0 =
            	        new NoViableAltException("", 26, 0, input);

            	    throw nvae_d26s0;
            }

            switch (alt26) 
            {
                case 1 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:363:4: ^( RANGE p= path (a= ALIAS )? (pf= FETCH )? )
                    {
                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	RANGE56=(CommonTree)Match(input,RANGE,FOLLOW_RANGE_in_fromElement1006);  
                    	stream_RANGE.Add(RANGE56);



                    	Match(input, Token.DOWN, null); 
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_path_in_fromElement1010);
                    	p = path();
                    	state.followingStackPointer--;

                    	stream_path.Add(p.Tree);
                    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:363:19: (a= ALIAS )?
                    	int alt24 = 2;
                    	int LA24_0 = input.LA(1);

                    	if ( (LA24_0 == ALIAS) )
                    	{
                    	    alt24 = 1;
                    	}
                    	switch (alt24) 
                    	{
                    	    case 1 :
                    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:363:20: a= ALIAS
                    	        {
                    	        	_last = (CommonTree)input.LT(1);
                    	        	a=(CommonTree)Match(input,ALIAS,FOLLOW_ALIAS_in_fromElement1015);  
                    	        	stream_ALIAS.Add(a);


                    	        }
                    	        break;

                    	}

                    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:363:30: (pf= FETCH )?
                    	int alt25 = 2;
                    	int LA25_0 = input.LA(1);

                    	if ( (LA25_0 == FETCH) )
                    	{
                    	    alt25 = 1;
                    	}
                    	switch (alt25) 
                    	{
                    	    case 1 :
                    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:363:31: pf= FETCH
                    	        {
                    	        	_last = (CommonTree)input.LT(1);
                    	        	pf=(CommonTree)Match(input,FETCH,FOLLOW_FETCH_in_fromElement1022);  
                    	        	stream_FETCH.Add(pf);


                    	        }
                    	        break;

                    	}


                    	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
                    	}



                    	// AST REWRITE
                    	// elements:          
                    	// token labels:      
                    	// rule labels:       retval
                    	// token list labels: 
                    	// rule list labels:  
                    	retval.Tree = root_0;
                    	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));

                    	root_0 = (CommonTree)adaptor.GetNilNode();
                    	// 364:3: -> ^()
                    	{
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:364:6: ^()
                    	    {
                    	    CommonTree root_1 = (CommonTree)adaptor.GetNilNode();
                    	    root_1 = (CommonTree)adaptor.BecomeRoot(createFromElement(((p != null) ? p.p : default(String)),a, pf), root_1);

                    	    adaptor.AddChild(root_0, root_1);
                    	    }

                    	}

                    	retval.Tree = root_0;
                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:365:4: je= joinElement
                    {
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_joinElement_in_fromElement1042);
                    	je = joinElement();
                    	state.followingStackPointer--;

                    	stream_joinElement.Add(je.Tree);


                    	// AST REWRITE
                    	// elements:          je
                    	// token labels:      
                    	// rule labels:       retval, je
                    	// token list labels: 
                    	// rule list labels:  
                    	retval.Tree = root_0;
                    	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));
                    	RewriteRuleSubtreeStream stream_je = new RewriteRuleSubtreeStream(adaptor, "token je", (je!=null ? je.Tree : null));

                    	root_0 = (CommonTree)adaptor.GetNilNode();
                    	// 366:3: -> ^( $je)
                    	{
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:366:6: ^( $je)
                    	    {
                    	    CommonTree root_1 = (CommonTree)adaptor.GetNilNode();
                    	    root_1 = (CommonTree)adaptor.BecomeRoot(stream_je.NextNode(), root_1);

                    	    adaptor.AddChild(root_0, root_1);
                    	    }

                    	}

                    	retval.Tree = root_0;
                    }
                    break;
                case 3 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:368:4: fe= FILTER_ENTITY a3= ALIAS
                    {
                    	_last = (CommonTree)input.LT(1);
                    	fe=(CommonTree)Match(input,FILTER_ENTITY,FOLLOW_FILTER_ENTITY_in_fromElement1061);  
                    	stream_FILTER_ENTITY.Add(fe);

                    	_last = (CommonTree)input.LT(1);
                    	a3=(CommonTree)Match(input,ALIAS,FOLLOW_ALIAS_in_fromElement1065);  
                    	stream_ALIAS.Add(a3);



                    	// AST REWRITE
                    	// elements:          
                    	// token labels:      
                    	// rule labels:       retval
                    	// token list labels: 
                    	// rule list labels:  
                    	retval.Tree = root_0;
                    	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));

                    	root_0 = (CommonTree)adaptor.GetNilNode();
                    	// 369:3: -> ^()
                    	{
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:369:6: ^()
                    	    {
                    	    CommonTree root_1 = (CommonTree)adaptor.GetNilNode();
                    	    root_1 = (CommonTree)adaptor.BecomeRoot(createFromFilterElement(fe,a3), root_1);

                    	    adaptor.AddChild(root_0, root_1);
                    	    }

                    	}

                    	retval.Tree = root_0;
                    }
                    break;

            }
            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "fromElement"

    public class joinElement_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "joinElement"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:387:1: joinElement : ^( JOIN (j= joinType )? (f= FETCH )? pRef= propertyRef (a= ALIAS )? (pf= FETCH )? (with= WITH )? ) ;
    public HqlSqlWalker.joinElement_return joinElement() // throws RecognitionException [1]
    {   
        HqlSqlWalker.joinElement_return retval = new HqlSqlWalker.joinElement_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree f = null;
        CommonTree a = null;
        CommonTree pf = null;
        CommonTree with = null;
        CommonTree JOIN57 = null;
        HqlSqlWalker.joinType_return j = default(HqlSqlWalker.joinType_return);

        HqlSqlWalker.propertyRef_return pRef = default(HqlSqlWalker.propertyRef_return);


        CommonTree f_tree=null;
        CommonTree a_tree=null;
        CommonTree pf_tree=null;
        CommonTree with_tree=null;
        CommonTree JOIN57_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:391:2: ( ^( JOIN (j= joinType )? (f= FETCH )? pRef= propertyRef (a= ALIAS )? (pf= FETCH )? (with= WITH )? ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:391:4: ^( JOIN (j= joinType )? (f= FETCH )? pRef= propertyRef (a= ALIAS )? (pf= FETCH )? (with= WITH )? )
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	_last = (CommonTree)input.LT(1);
            	{
            	CommonTree _save_last_1 = _last;
            	CommonTree _first_1 = null;
            	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	JOIN57=(CommonTree)Match(input,JOIN,FOLLOW_JOIN_in_joinElement1096); 
            		JOIN57_tree = (CommonTree)adaptor.DupNode(JOIN57);

            		root_1 = (CommonTree)adaptor.BecomeRoot(JOIN57_tree, root_1);



            	Match(input, Token.DOWN, null); 
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:391:11: (j= joinType )?
            	int alt27 = 2;
            	int LA27_0 = input.LA(1);

            	if ( (LA27_0 == FULL || LA27_0 == INNER || LA27_0 == LEFT || LA27_0 == RIGHT) )
            	{
            	    alt27 = 1;
            	}
            	switch (alt27) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:391:12: j= joinType
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_joinType_in_joinElement1101);
            	        	j = joinType();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, j.Tree);
            	        	 setImpliedJoinType(((j != null) ? ((CommonTree)j.Tree) : null)); 

            	        }
            	        break;

            	}

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:391:59: (f= FETCH )?
            	int alt28 = 2;
            	int LA28_0 = input.LA(1);

            	if ( (LA28_0 == FETCH) )
            	{
            	    alt28 = 1;
            	}
            	switch (alt28) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:391:60: f= FETCH
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	f=(CommonTree)Match(input,FETCH,FOLLOW_FETCH_in_joinElement1111); 
            	        		f_tree = (CommonTree)adaptor.DupNode(f);

            	        		adaptor.AddChild(root_1, f_tree);


            	        }
            	        break;

            	}

            	_last = (CommonTree)input.LT(1);
            	PushFollow(FOLLOW_propertyRef_in_joinElement1117);
            	pRef = propertyRef();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_1, pRef.Tree);
            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:391:87: (a= ALIAS )?
            	int alt29 = 2;
            	int LA29_0 = input.LA(1);

            	if ( (LA29_0 == ALIAS) )
            	{
            	    alt29 = 1;
            	}
            	switch (alt29) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:391:88: a= ALIAS
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	a=(CommonTree)Match(input,ALIAS,FOLLOW_ALIAS_in_joinElement1122); 
            	        		a_tree = (CommonTree)adaptor.DupNode(a);

            	        		adaptor.AddChild(root_1, a_tree);


            	        }
            	        break;

            	}

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:391:98: (pf= FETCH )?
            	int alt30 = 2;
            	int LA30_0 = input.LA(1);

            	if ( (LA30_0 == FETCH) )
            	{
            	    alt30 = 1;
            	}
            	switch (alt30) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:391:99: pf= FETCH
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	pf=(CommonTree)Match(input,FETCH,FOLLOW_FETCH_in_joinElement1129); 
            	        		pf_tree = (CommonTree)adaptor.DupNode(pf);

            	        		adaptor.AddChild(root_1, pf_tree);


            	        }
            	        break;

            	}

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:391:110: (with= WITH )?
            	int alt31 = 2;
            	int LA31_0 = input.LA(1);

            	if ( (LA31_0 == WITH) )
            	{
            	    alt31 = 1;
            	}
            	switch (alt31) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:391:111: with= WITH
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	with=(CommonTree)Match(input,WITH,FOLLOW_WITH_in_joinElement1136); 
            	        		with_tree = (CommonTree)adaptor.DupNode(with);

            	        		adaptor.AddChild(root_1, with_tree);


            	        }
            	        break;

            	}


            	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	}


            			//createFromJoinElement(#ref,a,j,f, pf);
            			createFromJoinElement(((pRef != null) ? ((CommonTree)pRef.Tree) : null),a,((j != null) ? ((CommonTree)j.Tree) : null),f, pf, with);
            			setImpliedJoinType(INNER);	// Reset the implied join type.
            		

            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "joinElement"

    public class joinType_return : TreeRuleReturnScope
    {
        public int j;
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "joinType"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:400:1: joinType returns [int j] : ( ( (left= LEFT | right= RIGHT ) (outer= OUTER )? ) | FULL | INNER );
    public HqlSqlWalker.joinType_return joinType() // throws RecognitionException [1]
    {   
        HqlSqlWalker.joinType_return retval = new HqlSqlWalker.joinType_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree left = null;
        CommonTree right = null;
        CommonTree outer = null;
        CommonTree FULL58 = null;
        CommonTree INNER59 = null;

        CommonTree left_tree=null;
        CommonTree right_tree=null;
        CommonTree outer_tree=null;
        CommonTree FULL58_tree=null;
        CommonTree INNER59_tree=null;


        	int j = INNER;
        	
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:403:2: ( ( (left= LEFT | right= RIGHT ) (outer= OUTER )? ) | FULL | INNER )
            int alt34 = 3;
            switch ( input.LA(1) ) 
            {
            case LEFT:
            case RIGHT:
            	{
                alt34 = 1;
                }
                break;
            case FULL:
            	{
                alt34 = 2;
                }
                break;
            case INNER:
            	{
                alt34 = 3;
                }
                break;
            	default:
            	    NoViableAltException nvae_d34s0 =
            	        new NoViableAltException("", 34, 0, input);

            	    throw nvae_d34s0;
            }

            switch (alt34) 
            {
                case 1 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:403:4: ( (left= LEFT | right= RIGHT ) (outer= OUTER )? )
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:403:4: ( (left= LEFT | right= RIGHT ) (outer= OUTER )? )
                    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:403:6: (left= LEFT | right= RIGHT ) (outer= OUTER )?
                    	{
                    		// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:403:6: (left= LEFT | right= RIGHT )
                    		int alt32 = 2;
                    		int LA32_0 = input.LA(1);

                    		if ( (LA32_0 == LEFT) )
                    		{
                    		    alt32 = 1;
                    		}
                    		else if ( (LA32_0 == RIGHT) )
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
                    		        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:403:7: left= LEFT
                    		        {
                    		        	_last = (CommonTree)input.LT(1);
                    		        	left=(CommonTree)Match(input,LEFT,FOLLOW_LEFT_in_joinType1168); 
                    		        		left_tree = (CommonTree)adaptor.DupNode(left);

                    		        		adaptor.AddChild(root_0, left_tree);


                    		        }
                    		        break;
                    		    case 2 :
                    		        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:403:19: right= RIGHT
                    		        {
                    		        	_last = (CommonTree)input.LT(1);
                    		        	right=(CommonTree)Match(input,RIGHT,FOLLOW_RIGHT_in_joinType1174); 
                    		        		right_tree = (CommonTree)adaptor.DupNode(right);

                    		        		adaptor.AddChild(root_0, right_tree);


                    		        }
                    		        break;

                    		}

                    		// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:403:32: (outer= OUTER )?
                    		int alt33 = 2;
                    		int LA33_0 = input.LA(1);

                    		if ( (LA33_0 == OUTER) )
                    		{
                    		    alt33 = 1;
                    		}
                    		switch (alt33) 
                    		{
                    		    case 1 :
                    		        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:403:33: outer= OUTER
                    		        {
                    		        	_last = (CommonTree)input.LT(1);
                    		        	outer=(CommonTree)Match(input,OUTER,FOLLOW_OUTER_in_joinType1180); 
                    		        		outer_tree = (CommonTree)adaptor.DupNode(outer);

                    		        		adaptor.AddChild(root_0, outer_tree);


                    		        }
                    		        break;

                    		}


                    	}


                    			if (left != null)       j = LEFT_OUTER;
                    			else if (right != null) j = RIGHT_OUTER;
                    			else if (outer != null) j = RIGHT_OUTER;
                    		

                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:408:4: FULL
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	FULL58=(CommonTree)Match(input,FULL,FOLLOW_FULL_in_joinType1191); 
                    		FULL58_tree = (CommonTree)adaptor.DupNode(FULL58);

                    		adaptor.AddChild(root_0, FULL58_tree);


                    			j = FULL;
                    		

                    }
                    break;
                case 3 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:411:4: INNER
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	INNER59=(CommonTree)Match(input,INNER,FOLLOW_INNER_in_joinType1198); 
                    		INNER59_tree = (CommonTree)adaptor.DupNode(INNER59);

                    		adaptor.AddChild(root_0, INNER59_tree);


                    			j = INNER;
                    		

                    }
                    break;

            }
            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "joinType"

    public class path_return : TreeRuleReturnScope
    {
        public String p;
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "path"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:418:1: path returns [String p] : (a= identifier | ^( DOT x= path y= identifier ) );
    public HqlSqlWalker.path_return path() // throws RecognitionException [1]
    {   
        HqlSqlWalker.path_return retval = new HqlSqlWalker.path_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree DOT60 = null;
        HqlSqlWalker.identifier_return a = default(HqlSqlWalker.identifier_return);

        HqlSqlWalker.path_return x = default(HqlSqlWalker.path_return);

        HqlSqlWalker.identifier_return y = default(HqlSqlWalker.identifier_return);


        CommonTree DOT60_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:419:2: (a= identifier | ^( DOT x= path y= identifier ) )
            int alt35 = 2;
            int LA35_0 = input.LA(1);

            if ( (LA35_0 == WEIRD_IDENT || LA35_0 == IDENT) )
            {
                alt35 = 1;
            }
            else if ( (LA35_0 == DOT) )
            {
                alt35 = 2;
            }
            else 
            {
                NoViableAltException nvae_d35s0 =
                    new NoViableAltException("", 35, 0, input);

                throw nvae_d35s0;
            }
            switch (alt35) 
            {
                case 1 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:419:4: a= identifier
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_identifier_in_path1220);
                    	a = identifier();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, a.Tree);
                    	 retval.p =  ((a != null) ? input.TokenStream.ToString(
                    	  input.TreeAdaptor.GetTokenStartIndex(a.Start),
                    	  input.TreeAdaptor.GetTokenStopIndex(a.Start)) : null); 

                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:420:4: ^( DOT x= path y= identifier )
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	DOT60=(CommonTree)Match(input,DOT,FOLLOW_DOT_in_path1228); 
                    		DOT60_tree = (CommonTree)adaptor.DupNode(DOT60);

                    		root_1 = (CommonTree)adaptor.BecomeRoot(DOT60_tree, root_1);



                    	Match(input, Token.DOWN, null); 
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_path_in_path1232);
                    	x = path();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_1, x.Tree);
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_identifier_in_path1236);
                    	y = identifier();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_1, y.Tree);

                    	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
                    	}


                    				StringBuilder buf = new StringBuilder();
                    				buf.Append(((x != null) ? x.p : default(String))).Append('.').Append(((y != null) ? input.TokenStream.ToString(
                    	  input.TreeAdaptor.GetTokenStartIndex(y.Start),
                    	  input.TreeAdaptor.GetTokenStopIndex(y.Start)) : null));
                    				retval.p =  buf.ToString();
                    			

                    }
                    break;

            }
            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "path"

    public class pathAsIdent_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "pathAsIdent"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:438:1: pathAsIdent : path -> ^( IDENT path ) ;
    public HqlSqlWalker.pathAsIdent_return pathAsIdent() // throws RecognitionException [1]
    {   
        HqlSqlWalker.pathAsIdent_return retval = new HqlSqlWalker.pathAsIdent_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        HqlSqlWalker.path_return path61 = default(HqlSqlWalker.path_return);


        RewriteRuleSubtreeStream stream_path = new RewriteRuleSubtreeStream(adaptor,"rule path");
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:439:5: ( path -> ^( IDENT path ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:439:7: path
            {
            	_last = (CommonTree)input.LT(1);
            	PushFollow(FOLLOW_path_in_pathAsIdent1257);
            	path61 = path();
            	state.followingStackPointer--;

            	stream_path.Add(path61.Tree);


            	// AST REWRITE
            	// elements:          path
            	// token labels:      
            	// rule labels:       retval
            	// token list labels: 
            	// rule list labels:  
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));

            	root_0 = (CommonTree)adaptor.GetNilNode();
            	// 440:5: -> ^( IDENT path )
            	{
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:440:8: ^( IDENT path )
            	    {
            	    CommonTree root_1 = (CommonTree)adaptor.GetNilNode();
            	    root_1 = (CommonTree)adaptor.BecomeRoot((CommonTree)adaptor.Create(IDENT, "IDENT"), root_1);

            	    adaptor.AddChild(root_1, stream_path.NextTree());

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;
            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "pathAsIdent"

    public class withClause_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "withClause"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:457:1: withClause : ^(w= WITH b= logicalExpr ) -> ^( $w $b) ;
    public HqlSqlWalker.withClause_return withClause() // throws RecognitionException [1]
    {   
        HqlSqlWalker.withClause_return retval = new HqlSqlWalker.withClause_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree w = null;
        HqlSqlWalker.logicalExpr_return b = default(HqlSqlWalker.logicalExpr_return);


        CommonTree w_tree=null;
        RewriteRuleNodeStream stream_WITH = new RewriteRuleNodeStream(adaptor,"token WITH");
        RewriteRuleSubtreeStream stream_logicalExpr = new RewriteRuleSubtreeStream(adaptor,"rule logicalExpr");
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:464:2: ( ^(w= WITH b= logicalExpr ) -> ^( $w $b) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:464:4: ^(w= WITH b= logicalExpr )
            {
            	_last = (CommonTree)input.LT(1);
            	{
            	CommonTree _save_last_1 = _last;
            	CommonTree _first_1 = null;
            	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	w=(CommonTree)Match(input,WITH,FOLLOW_WITH_in_withClause1301);  
            	stream_WITH.Add(w);


            	 handleClauseStart( WITH ); 

            	Match(input, Token.DOWN, null); 
            	_last = (CommonTree)input.LT(1);
            	PushFollow(FOLLOW_logicalExpr_in_withClause1307);
            	b = logicalExpr();
            	state.followingStackPointer--;

            	stream_logicalExpr.Add(b.Tree);

            	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	}



            	// AST REWRITE
            	// elements:          b, w
            	// token labels:      w
            	// rule labels:       retval, b
            	// token list labels: 
            	// rule list labels:  
            	retval.Tree = root_0;
            	RewriteRuleNodeStream stream_w = new RewriteRuleNodeStream(adaptor, "token w", w);
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));
            	RewriteRuleSubtreeStream stream_b = new RewriteRuleSubtreeStream(adaptor, "token b", (b!=null ? b.Tree : null));

            	root_0 = (CommonTree)adaptor.GetNilNode();
            	// 465:2: -> ^( $w $b)
            	{
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:465:5: ^( $w $b)
            	    {
            	    CommonTree root_1 = (CommonTree)adaptor.GetNilNode();
            	    root_1 = (CommonTree)adaptor.BecomeRoot(stream_w.NextNode(), root_1);

            	    adaptor.AddChild(root_1, stream_b.NextTree());

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;
            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "withClause"

    public class whereClause_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "whereClause"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:477:1: whereClause : ^(w= WHERE b= logicalExpr ) -> ^( $w $b) ;
    public HqlSqlWalker.whereClause_return whereClause() // throws RecognitionException [1]
    {   
        HqlSqlWalker.whereClause_return retval = new HqlSqlWalker.whereClause_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree w = null;
        HqlSqlWalker.logicalExpr_return b = default(HqlSqlWalker.logicalExpr_return);


        CommonTree w_tree=null;
        RewriteRuleNodeStream stream_WHERE = new RewriteRuleNodeStream(adaptor,"token WHERE");
        RewriteRuleSubtreeStream stream_logicalExpr = new RewriteRuleSubtreeStream(adaptor,"rule logicalExpr");
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:478:2: ( ^(w= WHERE b= logicalExpr ) -> ^( $w $b) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:478:4: ^(w= WHERE b= logicalExpr )
            {
            	_last = (CommonTree)input.LT(1);
            	{
            	CommonTree _save_last_1 = _last;
            	CommonTree _first_1 = null;
            	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	w=(CommonTree)Match(input,WHERE,FOLLOW_WHERE_in_whereClause1337);  
            	stream_WHERE.Add(w);


            	 handleClauseStart( WHERE ); 

            	Match(input, Token.DOWN, null); 
            	_last = (CommonTree)input.LT(1);
            	PushFollow(FOLLOW_logicalExpr_in_whereClause1343);
            	b = logicalExpr();
            	state.followingStackPointer--;

            	stream_logicalExpr.Add(b.Tree);

            	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	}



            	// AST REWRITE
            	// elements:          b, w
            	// token labels:      w
            	// rule labels:       retval, b
            	// token list labels: 
            	// rule list labels:  
            	retval.Tree = root_0;
            	RewriteRuleNodeStream stream_w = new RewriteRuleNodeStream(adaptor, "token w", w);
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));
            	RewriteRuleSubtreeStream stream_b = new RewriteRuleSubtreeStream(adaptor, "token b", (b!=null ? b.Tree : null));

            	root_0 = (CommonTree)adaptor.GetNilNode();
            	// 479:2: -> ^( $w $b)
            	{
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:479:5: ^( $w $b)
            	    {
            	    CommonTree root_1 = (CommonTree)adaptor.GetNilNode();
            	    root_1 = (CommonTree)adaptor.BecomeRoot(stream_w.NextNode(), root_1);

            	    adaptor.AddChild(root_1, stream_b.NextTree());

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;
            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "whereClause"

    public class logicalExpr_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "logicalExpr"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:482:1: logicalExpr : ( ^( AND logicalExpr logicalExpr ) | ^( OR logicalExpr logicalExpr ) | ^( NOT logicalExpr ) | comparisonExpr );
    public HqlSqlWalker.logicalExpr_return logicalExpr() // throws RecognitionException [1]
    {   
        HqlSqlWalker.logicalExpr_return retval = new HqlSqlWalker.logicalExpr_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree AND62 = null;
        CommonTree OR65 = null;
        CommonTree NOT68 = null;
        HqlSqlWalker.logicalExpr_return logicalExpr63 = default(HqlSqlWalker.logicalExpr_return);

        HqlSqlWalker.logicalExpr_return logicalExpr64 = default(HqlSqlWalker.logicalExpr_return);

        HqlSqlWalker.logicalExpr_return logicalExpr66 = default(HqlSqlWalker.logicalExpr_return);

        HqlSqlWalker.logicalExpr_return logicalExpr67 = default(HqlSqlWalker.logicalExpr_return);

        HqlSqlWalker.logicalExpr_return logicalExpr69 = default(HqlSqlWalker.logicalExpr_return);

        HqlSqlWalker.comparisonExpr_return comparisonExpr70 = default(HqlSqlWalker.comparisonExpr_return);


        CommonTree AND62_tree=null;
        CommonTree OR65_tree=null;
        CommonTree NOT68_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:483:2: ( ^( AND logicalExpr logicalExpr ) | ^( OR logicalExpr logicalExpr ) | ^( NOT logicalExpr ) | comparisonExpr )
            int alt36 = 4;
            switch ( input.LA(1) ) 
            {
            case AND:
            	{
                alt36 = 1;
                }
                break;
            case OR:
            	{
                alt36 = 2;
                }
                break;
            case NOT:
            	{
                alt36 = 3;
                }
                break;
            case BETWEEN:
            case EXISTS:
            case IN:
            case LIKE:
            case IS_NOT_NULL:
            case IS_NULL:
            case NOT_BETWEEN:
            case NOT_IN:
            case NOT_LIKE:
            case EQ:
            case NE:
            case LT:
            case GT:
            case LE:
            case GE:
            	{
                alt36 = 4;
                }
                break;
            	default:
            	    NoViableAltException nvae_d36s0 =
            	        new NoViableAltException("", 36, 0, input);

            	    throw nvae_d36s0;
            }

            switch (alt36) 
            {
                case 1 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:483:4: ^( AND logicalExpr logicalExpr )
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	AND62=(CommonTree)Match(input,AND,FOLLOW_AND_in_logicalExpr1369); 
                    		AND62_tree = (CommonTree)adaptor.DupNode(AND62);

                    		root_1 = (CommonTree)adaptor.BecomeRoot(AND62_tree, root_1);



                    	Match(input, Token.DOWN, null); 
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_logicalExpr_in_logicalExpr1371);
                    	logicalExpr63 = logicalExpr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_1, logicalExpr63.Tree);
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_logicalExpr_in_logicalExpr1373);
                    	logicalExpr64 = logicalExpr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_1, logicalExpr64.Tree);

                    	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
                    	}


                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:484:4: ^( OR logicalExpr logicalExpr )
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	OR65=(CommonTree)Match(input,OR,FOLLOW_OR_in_logicalExpr1380); 
                    		OR65_tree = (CommonTree)adaptor.DupNode(OR65);

                    		root_1 = (CommonTree)adaptor.BecomeRoot(OR65_tree, root_1);



                    	Match(input, Token.DOWN, null); 
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_logicalExpr_in_logicalExpr1382);
                    	logicalExpr66 = logicalExpr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_1, logicalExpr66.Tree);
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_logicalExpr_in_logicalExpr1384);
                    	logicalExpr67 = logicalExpr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_1, logicalExpr67.Tree);

                    	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
                    	}


                    }
                    break;
                case 3 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:485:4: ^( NOT logicalExpr )
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	NOT68=(CommonTree)Match(input,NOT,FOLLOW_NOT_in_logicalExpr1391); 
                    		NOT68_tree = (CommonTree)adaptor.DupNode(NOT68);

                    		root_1 = (CommonTree)adaptor.BecomeRoot(NOT68_tree, root_1);



                    	Match(input, Token.DOWN, null); 
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_logicalExpr_in_logicalExpr1393);
                    	logicalExpr69 = logicalExpr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_1, logicalExpr69.Tree);

                    	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
                    	}


                    }
                    break;
                case 4 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:486:4: comparisonExpr
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_comparisonExpr_in_logicalExpr1399);
                    	comparisonExpr70 = comparisonExpr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, comparisonExpr70.Tree);

                    }
                    break;

            }
            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "logicalExpr"

    public class comparisonExpr_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "comparisonExpr"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:516:1: comparisonExpr : ( ^( EQ exprOrSubquery exprOrSubquery ) | ^( NE exprOrSubquery exprOrSubquery ) | ^( LT exprOrSubquery exprOrSubquery ) | ^( GT exprOrSubquery exprOrSubquery ) | ^( LE exprOrSubquery exprOrSubquery ) | ^( GE exprOrSubquery exprOrSubquery ) | ^( LIKE exprOrSubquery expr ( ^( ESCAPE expr ) )? ) | ^( NOT_LIKE exprOrSubquery expr ( ^( ESCAPE expr ) )? ) | ^( BETWEEN exprOrSubquery exprOrSubquery exprOrSubquery ) | ^( NOT_BETWEEN exprOrSubquery exprOrSubquery exprOrSubquery ) | ^( IN exprOrSubquery inRhs ) | ^( NOT_IN exprOrSubquery inRhs ) | ^( IS_NULL exprOrSubquery ) | ^( IS_NOT_NULL exprOrSubquery ) | ^( EXISTS ( expr | collectionFunctionOrSubselect ) ) ) ;
    public HqlSqlWalker.comparisonExpr_return comparisonExpr() // throws RecognitionException [1]
    {   
        HqlSqlWalker.comparisonExpr_return retval = new HqlSqlWalker.comparisonExpr_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree EQ71 = null;
        CommonTree NE74 = null;
        CommonTree LT77 = null;
        CommonTree GT80 = null;
        CommonTree LE83 = null;
        CommonTree GE86 = null;
        CommonTree LIKE89 = null;
        CommonTree ESCAPE92 = null;
        CommonTree NOT_LIKE94 = null;
        CommonTree ESCAPE97 = null;
        CommonTree BETWEEN99 = null;
        CommonTree NOT_BETWEEN103 = null;
        CommonTree IN107 = null;
        CommonTree NOT_IN110 = null;
        CommonTree IS_NULL113 = null;
        CommonTree IS_NOT_NULL115 = null;
        CommonTree EXISTS117 = null;
        HqlSqlWalker.exprOrSubquery_return exprOrSubquery72 = default(HqlSqlWalker.exprOrSubquery_return);

        HqlSqlWalker.exprOrSubquery_return exprOrSubquery73 = default(HqlSqlWalker.exprOrSubquery_return);

        HqlSqlWalker.exprOrSubquery_return exprOrSubquery75 = default(HqlSqlWalker.exprOrSubquery_return);

        HqlSqlWalker.exprOrSubquery_return exprOrSubquery76 = default(HqlSqlWalker.exprOrSubquery_return);

        HqlSqlWalker.exprOrSubquery_return exprOrSubquery78 = default(HqlSqlWalker.exprOrSubquery_return);

        HqlSqlWalker.exprOrSubquery_return exprOrSubquery79 = default(HqlSqlWalker.exprOrSubquery_return);

        HqlSqlWalker.exprOrSubquery_return exprOrSubquery81 = default(HqlSqlWalker.exprOrSubquery_return);

        HqlSqlWalker.exprOrSubquery_return exprOrSubquery82 = default(HqlSqlWalker.exprOrSubquery_return);

        HqlSqlWalker.exprOrSubquery_return exprOrSubquery84 = default(HqlSqlWalker.exprOrSubquery_return);

        HqlSqlWalker.exprOrSubquery_return exprOrSubquery85 = default(HqlSqlWalker.exprOrSubquery_return);

        HqlSqlWalker.exprOrSubquery_return exprOrSubquery87 = default(HqlSqlWalker.exprOrSubquery_return);

        HqlSqlWalker.exprOrSubquery_return exprOrSubquery88 = default(HqlSqlWalker.exprOrSubquery_return);

        HqlSqlWalker.exprOrSubquery_return exprOrSubquery90 = default(HqlSqlWalker.exprOrSubquery_return);

        HqlSqlWalker.expr_return expr91 = default(HqlSqlWalker.expr_return);

        HqlSqlWalker.expr_return expr93 = default(HqlSqlWalker.expr_return);

        HqlSqlWalker.exprOrSubquery_return exprOrSubquery95 = default(HqlSqlWalker.exprOrSubquery_return);

        HqlSqlWalker.expr_return expr96 = default(HqlSqlWalker.expr_return);

        HqlSqlWalker.expr_return expr98 = default(HqlSqlWalker.expr_return);

        HqlSqlWalker.exprOrSubquery_return exprOrSubquery100 = default(HqlSqlWalker.exprOrSubquery_return);

        HqlSqlWalker.exprOrSubquery_return exprOrSubquery101 = default(HqlSqlWalker.exprOrSubquery_return);

        HqlSqlWalker.exprOrSubquery_return exprOrSubquery102 = default(HqlSqlWalker.exprOrSubquery_return);

        HqlSqlWalker.exprOrSubquery_return exprOrSubquery104 = default(HqlSqlWalker.exprOrSubquery_return);

        HqlSqlWalker.exprOrSubquery_return exprOrSubquery105 = default(HqlSqlWalker.exprOrSubquery_return);

        HqlSqlWalker.exprOrSubquery_return exprOrSubquery106 = default(HqlSqlWalker.exprOrSubquery_return);

        HqlSqlWalker.exprOrSubquery_return exprOrSubquery108 = default(HqlSqlWalker.exprOrSubquery_return);

        HqlSqlWalker.inRhs_return inRhs109 = default(HqlSqlWalker.inRhs_return);

        HqlSqlWalker.exprOrSubquery_return exprOrSubquery111 = default(HqlSqlWalker.exprOrSubquery_return);

        HqlSqlWalker.inRhs_return inRhs112 = default(HqlSqlWalker.inRhs_return);

        HqlSqlWalker.exprOrSubquery_return exprOrSubquery114 = default(HqlSqlWalker.exprOrSubquery_return);

        HqlSqlWalker.exprOrSubquery_return exprOrSubquery116 = default(HqlSqlWalker.exprOrSubquery_return);

        HqlSqlWalker.expr_return expr118 = default(HqlSqlWalker.expr_return);

        HqlSqlWalker.collectionFunctionOrSubselect_return collectionFunctionOrSubselect119 = default(HqlSqlWalker.collectionFunctionOrSubselect_return);


        CommonTree EQ71_tree=null;
        CommonTree NE74_tree=null;
        CommonTree LT77_tree=null;
        CommonTree GT80_tree=null;
        CommonTree LE83_tree=null;
        CommonTree GE86_tree=null;
        CommonTree LIKE89_tree=null;
        CommonTree ESCAPE92_tree=null;
        CommonTree NOT_LIKE94_tree=null;
        CommonTree ESCAPE97_tree=null;
        CommonTree BETWEEN99_tree=null;
        CommonTree NOT_BETWEEN103_tree=null;
        CommonTree IN107_tree=null;
        CommonTree NOT_IN110_tree=null;
        CommonTree IS_NULL113_tree=null;
        CommonTree IS_NOT_NULL115_tree=null;
        CommonTree EXISTS117_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:520:2: ( ( ^( EQ exprOrSubquery exprOrSubquery ) | ^( NE exprOrSubquery exprOrSubquery ) | ^( LT exprOrSubquery exprOrSubquery ) | ^( GT exprOrSubquery exprOrSubquery ) | ^( LE exprOrSubquery exprOrSubquery ) | ^( GE exprOrSubquery exprOrSubquery ) | ^( LIKE exprOrSubquery expr ( ^( ESCAPE expr ) )? ) | ^( NOT_LIKE exprOrSubquery expr ( ^( ESCAPE expr ) )? ) | ^( BETWEEN exprOrSubquery exprOrSubquery exprOrSubquery ) | ^( NOT_BETWEEN exprOrSubquery exprOrSubquery exprOrSubquery ) | ^( IN exprOrSubquery inRhs ) | ^( NOT_IN exprOrSubquery inRhs ) | ^( IS_NULL exprOrSubquery ) | ^( IS_NOT_NULL exprOrSubquery ) | ^( EXISTS ( expr | collectionFunctionOrSubselect ) ) ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:521:2: ( ^( EQ exprOrSubquery exprOrSubquery ) | ^( NE exprOrSubquery exprOrSubquery ) | ^( LT exprOrSubquery exprOrSubquery ) | ^( GT exprOrSubquery exprOrSubquery ) | ^( LE exprOrSubquery exprOrSubquery ) | ^( GE exprOrSubquery exprOrSubquery ) | ^( LIKE exprOrSubquery expr ( ^( ESCAPE expr ) )? ) | ^( NOT_LIKE exprOrSubquery expr ( ^( ESCAPE expr ) )? ) | ^( BETWEEN exprOrSubquery exprOrSubquery exprOrSubquery ) | ^( NOT_BETWEEN exprOrSubquery exprOrSubquery exprOrSubquery ) | ^( IN exprOrSubquery inRhs ) | ^( NOT_IN exprOrSubquery inRhs ) | ^( IS_NULL exprOrSubquery ) | ^( IS_NOT_NULL exprOrSubquery ) | ^( EXISTS ( expr | collectionFunctionOrSubselect ) ) )
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:521:2: ( ^( EQ exprOrSubquery exprOrSubquery ) | ^( NE exprOrSubquery exprOrSubquery ) | ^( LT exprOrSubquery exprOrSubquery ) | ^( GT exprOrSubquery exprOrSubquery ) | ^( LE exprOrSubquery exprOrSubquery ) | ^( GE exprOrSubquery exprOrSubquery ) | ^( LIKE exprOrSubquery expr ( ^( ESCAPE expr ) )? ) | ^( NOT_LIKE exprOrSubquery expr ( ^( ESCAPE expr ) )? ) | ^( BETWEEN exprOrSubquery exprOrSubquery exprOrSubquery ) | ^( NOT_BETWEEN exprOrSubquery exprOrSubquery exprOrSubquery ) | ^( IN exprOrSubquery inRhs ) | ^( NOT_IN exprOrSubquery inRhs ) | ^( IS_NULL exprOrSubquery ) | ^( IS_NOT_NULL exprOrSubquery ) | ^( EXISTS ( expr | collectionFunctionOrSubselect ) ) )
            	int alt40 = 15;
            	switch ( input.LA(1) ) 
            	{
            	case EQ:
            		{
            	    alt40 = 1;
            	    }
            	    break;
            	case NE:
            		{
            	    alt40 = 2;
            	    }
            	    break;
            	case LT:
            		{
            	    alt40 = 3;
            	    }
            	    break;
            	case GT:
            		{
            	    alt40 = 4;
            	    }
            	    break;
            	case LE:
            		{
            	    alt40 = 5;
            	    }
            	    break;
            	case GE:
            		{
            	    alt40 = 6;
            	    }
            	    break;
            	case LIKE:
            		{
            	    alt40 = 7;
            	    }
            	    break;
            	case NOT_LIKE:
            		{
            	    alt40 = 8;
            	    }
            	    break;
            	case BETWEEN:
            		{
            	    alt40 = 9;
            	    }
            	    break;
            	case NOT_BETWEEN:
            		{
            	    alt40 = 10;
            	    }
            	    break;
            	case IN:
            		{
            	    alt40 = 11;
            	    }
            	    break;
            	case NOT_IN:
            		{
            	    alt40 = 12;
            	    }
            	    break;
            	case IS_NULL:
            		{
            	    alt40 = 13;
            	    }
            	    break;
            	case IS_NOT_NULL:
            		{
            	    alt40 = 14;
            	    }
            	    break;
            	case EXISTS:
            		{
            	    alt40 = 15;
            	    }
            	    break;
            		default:
            		    NoViableAltException nvae_d40s0 =
            		        new NoViableAltException("", 40, 0, input);

            		    throw nvae_d40s0;
            	}

            	switch (alt40) 
            	{
            	    case 1 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:521:4: ^( EQ exprOrSubquery exprOrSubquery )
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	{
            	        	CommonTree _save_last_1 = _last;
            	        	CommonTree _first_1 = null;
            	        	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	        	EQ71=(CommonTree)Match(input,EQ,FOLLOW_EQ_in_comparisonExpr1423); 
            	        		EQ71_tree = (CommonTree)adaptor.DupNode(EQ71);

            	        		root_1 = (CommonTree)adaptor.BecomeRoot(EQ71_tree, root_1);



            	        	Match(input, Token.DOWN, null); 
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_exprOrSubquery_in_comparisonExpr1425);
            	        	exprOrSubquery72 = exprOrSubquery();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, exprOrSubquery72.Tree);
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_exprOrSubquery_in_comparisonExpr1427);
            	        	exprOrSubquery73 = exprOrSubquery();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, exprOrSubquery73.Tree);

            	        	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	        	}


            	        }
            	        break;
            	    case 2 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:522:4: ^( NE exprOrSubquery exprOrSubquery )
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	{
            	        	CommonTree _save_last_1 = _last;
            	        	CommonTree _first_1 = null;
            	        	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	        	NE74=(CommonTree)Match(input,NE,FOLLOW_NE_in_comparisonExpr1434); 
            	        		NE74_tree = (CommonTree)adaptor.DupNode(NE74);

            	        		root_1 = (CommonTree)adaptor.BecomeRoot(NE74_tree, root_1);



            	        	Match(input, Token.DOWN, null); 
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_exprOrSubquery_in_comparisonExpr1436);
            	        	exprOrSubquery75 = exprOrSubquery();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, exprOrSubquery75.Tree);
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_exprOrSubquery_in_comparisonExpr1438);
            	        	exprOrSubquery76 = exprOrSubquery();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, exprOrSubquery76.Tree);

            	        	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	        	}


            	        }
            	        break;
            	    case 3 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:523:4: ^( LT exprOrSubquery exprOrSubquery )
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	{
            	        	CommonTree _save_last_1 = _last;
            	        	CommonTree _first_1 = null;
            	        	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	        	LT77=(CommonTree)Match(input,LT,FOLLOW_LT_in_comparisonExpr1445); 
            	        		LT77_tree = (CommonTree)adaptor.DupNode(LT77);

            	        		root_1 = (CommonTree)adaptor.BecomeRoot(LT77_tree, root_1);



            	        	Match(input, Token.DOWN, null); 
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_exprOrSubquery_in_comparisonExpr1447);
            	        	exprOrSubquery78 = exprOrSubquery();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, exprOrSubquery78.Tree);
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_exprOrSubquery_in_comparisonExpr1449);
            	        	exprOrSubquery79 = exprOrSubquery();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, exprOrSubquery79.Tree);

            	        	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	        	}


            	        }
            	        break;
            	    case 4 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:524:4: ^( GT exprOrSubquery exprOrSubquery )
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	{
            	        	CommonTree _save_last_1 = _last;
            	        	CommonTree _first_1 = null;
            	        	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	        	GT80=(CommonTree)Match(input,GT,FOLLOW_GT_in_comparisonExpr1456); 
            	        		GT80_tree = (CommonTree)adaptor.DupNode(GT80);

            	        		root_1 = (CommonTree)adaptor.BecomeRoot(GT80_tree, root_1);



            	        	Match(input, Token.DOWN, null); 
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_exprOrSubquery_in_comparisonExpr1458);
            	        	exprOrSubquery81 = exprOrSubquery();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, exprOrSubquery81.Tree);
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_exprOrSubquery_in_comparisonExpr1460);
            	        	exprOrSubquery82 = exprOrSubquery();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, exprOrSubquery82.Tree);

            	        	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	        	}


            	        }
            	        break;
            	    case 5 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:525:4: ^( LE exprOrSubquery exprOrSubquery )
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	{
            	        	CommonTree _save_last_1 = _last;
            	        	CommonTree _first_1 = null;
            	        	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	        	LE83=(CommonTree)Match(input,LE,FOLLOW_LE_in_comparisonExpr1467); 
            	        		LE83_tree = (CommonTree)adaptor.DupNode(LE83);

            	        		root_1 = (CommonTree)adaptor.BecomeRoot(LE83_tree, root_1);



            	        	Match(input, Token.DOWN, null); 
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_exprOrSubquery_in_comparisonExpr1469);
            	        	exprOrSubquery84 = exprOrSubquery();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, exprOrSubquery84.Tree);
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_exprOrSubquery_in_comparisonExpr1471);
            	        	exprOrSubquery85 = exprOrSubquery();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, exprOrSubquery85.Tree);

            	        	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	        	}


            	        }
            	        break;
            	    case 6 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:526:4: ^( GE exprOrSubquery exprOrSubquery )
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	{
            	        	CommonTree _save_last_1 = _last;
            	        	CommonTree _first_1 = null;
            	        	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	        	GE86=(CommonTree)Match(input,GE,FOLLOW_GE_in_comparisonExpr1478); 
            	        		GE86_tree = (CommonTree)adaptor.DupNode(GE86);

            	        		root_1 = (CommonTree)adaptor.BecomeRoot(GE86_tree, root_1);



            	        	Match(input, Token.DOWN, null); 
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_exprOrSubquery_in_comparisonExpr1480);
            	        	exprOrSubquery87 = exprOrSubquery();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, exprOrSubquery87.Tree);
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_exprOrSubquery_in_comparisonExpr1482);
            	        	exprOrSubquery88 = exprOrSubquery();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, exprOrSubquery88.Tree);

            	        	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	        	}


            	        }
            	        break;
            	    case 7 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:527:4: ^( LIKE exprOrSubquery expr ( ^( ESCAPE expr ) )? )
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	{
            	        	CommonTree _save_last_1 = _last;
            	        	CommonTree _first_1 = null;
            	        	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	        	LIKE89=(CommonTree)Match(input,LIKE,FOLLOW_LIKE_in_comparisonExpr1489); 
            	        		LIKE89_tree = (CommonTree)adaptor.DupNode(LIKE89);

            	        		root_1 = (CommonTree)adaptor.BecomeRoot(LIKE89_tree, root_1);



            	        	Match(input, Token.DOWN, null); 
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_exprOrSubquery_in_comparisonExpr1491);
            	        	exprOrSubquery90 = exprOrSubquery();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, exprOrSubquery90.Tree);
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_expr_in_comparisonExpr1493);
            	        	expr91 = expr();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, expr91.Tree);
            	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:527:31: ( ^( ESCAPE expr ) )?
            	        	int alt37 = 2;
            	        	int LA37_0 = input.LA(1);

            	        	if ( (LA37_0 == ESCAPE) )
            	        	{
            	        	    alt37 = 1;
            	        	}
            	        	switch (alt37) 
            	        	{
            	        	    case 1 :
            	        	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:527:33: ^( ESCAPE expr )
            	        	        {
            	        	        	_last = (CommonTree)input.LT(1);
            	        	        	{
            	        	        	CommonTree _save_last_2 = _last;
            	        	        	CommonTree _first_2 = null;
            	        	        	CommonTree root_2 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	        	        	ESCAPE92=(CommonTree)Match(input,ESCAPE,FOLLOW_ESCAPE_in_comparisonExpr1498); 
            	        	        		ESCAPE92_tree = (CommonTree)adaptor.DupNode(ESCAPE92);

            	        	        		root_2 = (CommonTree)adaptor.BecomeRoot(ESCAPE92_tree, root_2);



            	        	        	Match(input, Token.DOWN, null); 
            	        	        	_last = (CommonTree)input.LT(1);
            	        	        	PushFollow(FOLLOW_expr_in_comparisonExpr1500);
            	        	        	expr93 = expr();
            	        	        	state.followingStackPointer--;

            	        	        	adaptor.AddChild(root_2, expr93.Tree);

            	        	        	Match(input, Token.UP, null); adaptor.AddChild(root_1, root_2);_last = _save_last_2;
            	        	        	}


            	        	        }
            	        	        break;

            	        	}


            	        	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	        	}


            	        }
            	        break;
            	    case 8 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:528:4: ^( NOT_LIKE exprOrSubquery expr ( ^( ESCAPE expr ) )? )
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	{
            	        	CommonTree _save_last_1 = _last;
            	        	CommonTree _first_1 = null;
            	        	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	        	NOT_LIKE94=(CommonTree)Match(input,NOT_LIKE,FOLLOW_NOT_LIKE_in_comparisonExpr1512); 
            	        		NOT_LIKE94_tree = (CommonTree)adaptor.DupNode(NOT_LIKE94);

            	        		root_1 = (CommonTree)adaptor.BecomeRoot(NOT_LIKE94_tree, root_1);



            	        	Match(input, Token.DOWN, null); 
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_exprOrSubquery_in_comparisonExpr1514);
            	        	exprOrSubquery95 = exprOrSubquery();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, exprOrSubquery95.Tree);
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_expr_in_comparisonExpr1516);
            	        	expr96 = expr();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, expr96.Tree);
            	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:528:35: ( ^( ESCAPE expr ) )?
            	        	int alt38 = 2;
            	        	int LA38_0 = input.LA(1);

            	        	if ( (LA38_0 == ESCAPE) )
            	        	{
            	        	    alt38 = 1;
            	        	}
            	        	switch (alt38) 
            	        	{
            	        	    case 1 :
            	        	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:528:37: ^( ESCAPE expr )
            	        	        {
            	        	        	_last = (CommonTree)input.LT(1);
            	        	        	{
            	        	        	CommonTree _save_last_2 = _last;
            	        	        	CommonTree _first_2 = null;
            	        	        	CommonTree root_2 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	        	        	ESCAPE97=(CommonTree)Match(input,ESCAPE,FOLLOW_ESCAPE_in_comparisonExpr1521); 
            	        	        		ESCAPE97_tree = (CommonTree)adaptor.DupNode(ESCAPE97);

            	        	        		root_2 = (CommonTree)adaptor.BecomeRoot(ESCAPE97_tree, root_2);



            	        	        	Match(input, Token.DOWN, null); 
            	        	        	_last = (CommonTree)input.LT(1);
            	        	        	PushFollow(FOLLOW_expr_in_comparisonExpr1523);
            	        	        	expr98 = expr();
            	        	        	state.followingStackPointer--;

            	        	        	adaptor.AddChild(root_2, expr98.Tree);

            	        	        	Match(input, Token.UP, null); adaptor.AddChild(root_1, root_2);_last = _save_last_2;
            	        	        	}


            	        	        }
            	        	        break;

            	        	}


            	        	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	        	}


            	        }
            	        break;
            	    case 9 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:529:4: ^( BETWEEN exprOrSubquery exprOrSubquery exprOrSubquery )
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	{
            	        	CommonTree _save_last_1 = _last;
            	        	CommonTree _first_1 = null;
            	        	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	        	BETWEEN99=(CommonTree)Match(input,BETWEEN,FOLLOW_BETWEEN_in_comparisonExpr1535); 
            	        		BETWEEN99_tree = (CommonTree)adaptor.DupNode(BETWEEN99);

            	        		root_1 = (CommonTree)adaptor.BecomeRoot(BETWEEN99_tree, root_1);



            	        	Match(input, Token.DOWN, null); 
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_exprOrSubquery_in_comparisonExpr1537);
            	        	exprOrSubquery100 = exprOrSubquery();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, exprOrSubquery100.Tree);
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_exprOrSubquery_in_comparisonExpr1539);
            	        	exprOrSubquery101 = exprOrSubquery();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, exprOrSubquery101.Tree);
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_exprOrSubquery_in_comparisonExpr1541);
            	        	exprOrSubquery102 = exprOrSubquery();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, exprOrSubquery102.Tree);

            	        	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	        	}


            	        }
            	        break;
            	    case 10 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:530:4: ^( NOT_BETWEEN exprOrSubquery exprOrSubquery exprOrSubquery )
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	{
            	        	CommonTree _save_last_1 = _last;
            	        	CommonTree _first_1 = null;
            	        	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	        	NOT_BETWEEN103=(CommonTree)Match(input,NOT_BETWEEN,FOLLOW_NOT_BETWEEN_in_comparisonExpr1548); 
            	        		NOT_BETWEEN103_tree = (CommonTree)adaptor.DupNode(NOT_BETWEEN103);

            	        		root_1 = (CommonTree)adaptor.BecomeRoot(NOT_BETWEEN103_tree, root_1);



            	        	Match(input, Token.DOWN, null); 
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_exprOrSubquery_in_comparisonExpr1550);
            	        	exprOrSubquery104 = exprOrSubquery();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, exprOrSubquery104.Tree);
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_exprOrSubquery_in_comparisonExpr1552);
            	        	exprOrSubquery105 = exprOrSubquery();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, exprOrSubquery105.Tree);
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_exprOrSubquery_in_comparisonExpr1554);
            	        	exprOrSubquery106 = exprOrSubquery();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, exprOrSubquery106.Tree);

            	        	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	        	}


            	        }
            	        break;
            	    case 11 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:531:4: ^( IN exprOrSubquery inRhs )
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	{
            	        	CommonTree _save_last_1 = _last;
            	        	CommonTree _first_1 = null;
            	        	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	        	IN107=(CommonTree)Match(input,IN,FOLLOW_IN_in_comparisonExpr1561); 
            	        		IN107_tree = (CommonTree)adaptor.DupNode(IN107);

            	        		root_1 = (CommonTree)adaptor.BecomeRoot(IN107_tree, root_1);



            	        	Match(input, Token.DOWN, null); 
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_exprOrSubquery_in_comparisonExpr1563);
            	        	exprOrSubquery108 = exprOrSubquery();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, exprOrSubquery108.Tree);
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_inRhs_in_comparisonExpr1565);
            	        	inRhs109 = inRhs();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, inRhs109.Tree);

            	        	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	        	}


            	        }
            	        break;
            	    case 12 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:532:4: ^( NOT_IN exprOrSubquery inRhs )
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	{
            	        	CommonTree _save_last_1 = _last;
            	        	CommonTree _first_1 = null;
            	        	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	        	NOT_IN110=(CommonTree)Match(input,NOT_IN,FOLLOW_NOT_IN_in_comparisonExpr1573); 
            	        		NOT_IN110_tree = (CommonTree)adaptor.DupNode(NOT_IN110);

            	        		root_1 = (CommonTree)adaptor.BecomeRoot(NOT_IN110_tree, root_1);



            	        	Match(input, Token.DOWN, null); 
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_exprOrSubquery_in_comparisonExpr1575);
            	        	exprOrSubquery111 = exprOrSubquery();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, exprOrSubquery111.Tree);
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_inRhs_in_comparisonExpr1577);
            	        	inRhs112 = inRhs();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, inRhs112.Tree);

            	        	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	        	}


            	        }
            	        break;
            	    case 13 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:533:4: ^( IS_NULL exprOrSubquery )
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	{
            	        	CommonTree _save_last_1 = _last;
            	        	CommonTree _first_1 = null;
            	        	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	        	IS_NULL113=(CommonTree)Match(input,IS_NULL,FOLLOW_IS_NULL_in_comparisonExpr1585); 
            	        		IS_NULL113_tree = (CommonTree)adaptor.DupNode(IS_NULL113);

            	        		root_1 = (CommonTree)adaptor.BecomeRoot(IS_NULL113_tree, root_1);



            	        	Match(input, Token.DOWN, null); 
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_exprOrSubquery_in_comparisonExpr1587);
            	        	exprOrSubquery114 = exprOrSubquery();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, exprOrSubquery114.Tree);

            	        	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	        	}


            	        }
            	        break;
            	    case 14 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:534:4: ^( IS_NOT_NULL exprOrSubquery )
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	{
            	        	CommonTree _save_last_1 = _last;
            	        	CommonTree _first_1 = null;
            	        	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	        	IS_NOT_NULL115=(CommonTree)Match(input,IS_NOT_NULL,FOLLOW_IS_NOT_NULL_in_comparisonExpr1594); 
            	        		IS_NOT_NULL115_tree = (CommonTree)adaptor.DupNode(IS_NOT_NULL115);

            	        		root_1 = (CommonTree)adaptor.BecomeRoot(IS_NOT_NULL115_tree, root_1);



            	        	Match(input, Token.DOWN, null); 
            	        	_last = (CommonTree)input.LT(1);
            	        	PushFollow(FOLLOW_exprOrSubquery_in_comparisonExpr1596);
            	        	exprOrSubquery116 = exprOrSubquery();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_1, exprOrSubquery116.Tree);

            	        	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	        	}


            	        }
            	        break;
            	    case 15 :
            	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:537:4: ^( EXISTS ( expr | collectionFunctionOrSubselect ) )
            	        {
            	        	_last = (CommonTree)input.LT(1);
            	        	{
            	        	CommonTree _save_last_1 = _last;
            	        	CommonTree _first_1 = null;
            	        	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	        	EXISTS117=(CommonTree)Match(input,EXISTS,FOLLOW_EXISTS_in_comparisonExpr1605); 
            	        		EXISTS117_tree = (CommonTree)adaptor.DupNode(EXISTS117);

            	        		root_1 = (CommonTree)adaptor.BecomeRoot(EXISTS117_tree, root_1);



            	        	Match(input, Token.DOWN, null); 
            	        	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:537:13: ( expr | collectionFunctionOrSubselect )
            	        	int alt39 = 2;
            	        	int LA39_0 = input.LA(1);

            	        	if ( (LA39_0 == COUNT || LA39_0 == DOT || LA39_0 == FALSE || LA39_0 == NULL || LA39_0 == TRUE || LA39_0 == CASE || LA39_0 == AGGREGATE || LA39_0 == CASE2 || LA39_0 == INDEX_OP || LA39_0 == METHOD_CALL || LA39_0 == UNARY_MINUS || (LA39_0 >= VECTOR_EXPR && LA39_0 <= WEIRD_IDENT) || (LA39_0 >= NUM_INT && LA39_0 <= JAVA_CONSTANT) || (LA39_0 >= PLUS && LA39_0 <= DIV) || (LA39_0 >= COLON && LA39_0 <= PARAM) || LA39_0 == IDENT || LA39_0 == QUOTED_STRING) )
            	        	{
            	        	    alt39 = 1;
            	        	}
            	        	else if ( (LA39_0 == ELEMENTS || LA39_0 == INDICES || LA39_0 == QUERY) )
            	        	{
            	        	    alt39 = 2;
            	        	}
            	        	else 
            	        	{
            	        	    NoViableAltException nvae_d39s0 =
            	        	        new NoViableAltException("", 39, 0, input);

            	        	    throw nvae_d39s0;
            	        	}
            	        	switch (alt39) 
            	        	{
            	        	    case 1 :
            	        	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:537:15: expr
            	        	        {
            	        	        	_last = (CommonTree)input.LT(1);
            	        	        	PushFollow(FOLLOW_expr_in_comparisonExpr1609);
            	        	        	expr118 = expr();
            	        	        	state.followingStackPointer--;

            	        	        	adaptor.AddChild(root_1, expr118.Tree);

            	        	        }
            	        	        break;
            	        	    case 2 :
            	        	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:537:22: collectionFunctionOrSubselect
            	        	        {
            	        	        	_last = (CommonTree)input.LT(1);
            	        	        	PushFollow(FOLLOW_collectionFunctionOrSubselect_in_comparisonExpr1613);
            	        	        	collectionFunctionOrSubselect119 = collectionFunctionOrSubselect();
            	        	        	state.followingStackPointer--;

            	        	        	adaptor.AddChild(root_1, collectionFunctionOrSubselect119.Tree);

            	        	        }
            	        	        break;

            	        	}


            	        	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	        	}


            	        }
            	        break;

            	}


            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);


            	    prepareLogicOperator( ((CommonTree)retval.Tree) );
            	
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "comparisonExpr"

    public class inRhs_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "inRhs"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:541:1: inRhs : ^( IN_LIST ( collectionFunctionOrSubselect | ( expr )* ) ) ;
    public HqlSqlWalker.inRhs_return inRhs() // throws RecognitionException [1]
    {   
        HqlSqlWalker.inRhs_return retval = new HqlSqlWalker.inRhs_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree IN_LIST120 = null;
        HqlSqlWalker.collectionFunctionOrSubselect_return collectionFunctionOrSubselect121 = default(HqlSqlWalker.collectionFunctionOrSubselect_return);

        HqlSqlWalker.expr_return expr122 = default(HqlSqlWalker.expr_return);


        CommonTree IN_LIST120_tree=null;

        	int UP = 99999;		// TODO - added this to get compile working.  It's bogus & should be removed
        	
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:543:2: ( ^( IN_LIST ( collectionFunctionOrSubselect | ( expr )* ) ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:543:4: ^( IN_LIST ( collectionFunctionOrSubselect | ( expr )* ) )
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	_last = (CommonTree)input.LT(1);
            	{
            	CommonTree _save_last_1 = _last;
            	CommonTree _first_1 = null;
            	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	IN_LIST120=(CommonTree)Match(input,IN_LIST,FOLLOW_IN_LIST_in_inRhs1638); 
            		IN_LIST120_tree = (CommonTree)adaptor.DupNode(IN_LIST120);

            		root_1 = (CommonTree)adaptor.BecomeRoot(IN_LIST120_tree, root_1);



            	if ( input.LA(1) == Token.DOWN )
            	{
            	    Match(input, Token.DOWN, null); 
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:543:14: ( collectionFunctionOrSubselect | ( expr )* )
            	    int alt42 = 2;
            	    int LA42_0 = input.LA(1);

            	    if ( (LA42_0 == ELEMENTS || LA42_0 == INDICES || LA42_0 == QUERY) )
            	    {
            	        alt42 = 1;
            	    }
            	    else if ( (LA42_0 == UP || LA42_0 == COUNT || LA42_0 == DOT || LA42_0 == FALSE || LA42_0 == NULL || LA42_0 == TRUE || LA42_0 == CASE || LA42_0 == AGGREGATE || LA42_0 == CASE2 || LA42_0 == INDEX_OP || LA42_0 == METHOD_CALL || LA42_0 == UNARY_MINUS || (LA42_0 >= VECTOR_EXPR && LA42_0 <= WEIRD_IDENT) || (LA42_0 >= NUM_INT && LA42_0 <= JAVA_CONSTANT) || (LA42_0 >= PLUS && LA42_0 <= DIV) || (LA42_0 >= COLON && LA42_0 <= PARAM) || LA42_0 == IDENT || LA42_0 == QUOTED_STRING) )
            	    {
            	        alt42 = 2;
            	    }
            	    else 
            	    {
            	        NoViableAltException nvae_d42s0 =
            	            new NoViableAltException("", 42, 0, input);

            	        throw nvae_d42s0;
            	    }
            	    switch (alt42) 
            	    {
            	        case 1 :
            	            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:543:16: collectionFunctionOrSubselect
            	            {
            	            	_last = (CommonTree)input.LT(1);
            	            	PushFollow(FOLLOW_collectionFunctionOrSubselect_in_inRhs1642);
            	            	collectionFunctionOrSubselect121 = collectionFunctionOrSubselect();
            	            	state.followingStackPointer--;

            	            	adaptor.AddChild(root_1, collectionFunctionOrSubselect121.Tree);

            	            }
            	            break;
            	        case 2 :
            	            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:543:48: ( expr )*
            	            {
            	            	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:543:48: ( expr )*
            	            	do 
            	            	{
            	            	    int alt41 = 2;
            	            	    int LA41_0 = input.LA(1);

            	            	    if ( (LA41_0 == COUNT || LA41_0 == DOT || LA41_0 == FALSE || LA41_0 == NULL || LA41_0 == TRUE || LA41_0 == CASE || LA41_0 == AGGREGATE || LA41_0 == CASE2 || LA41_0 == INDEX_OP || LA41_0 == METHOD_CALL || LA41_0 == UNARY_MINUS || (LA41_0 >= VECTOR_EXPR && LA41_0 <= WEIRD_IDENT) || (LA41_0 >= NUM_INT && LA41_0 <= JAVA_CONSTANT) || (LA41_0 >= PLUS && LA41_0 <= DIV) || (LA41_0 >= COLON && LA41_0 <= PARAM) || LA41_0 == IDENT || LA41_0 == QUOTED_STRING) )
            	            	    {
            	            	        alt41 = 1;
            	            	    }


            	            	    switch (alt41) 
            	            		{
            	            			case 1 :
            	            			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:543:48: expr
            	            			    {
            	            			    	_last = (CommonTree)input.LT(1);
            	            			    	PushFollow(FOLLOW_expr_in_inRhs1646);
            	            			    	expr122 = expr();
            	            			    	state.followingStackPointer--;

            	            			    	adaptor.AddChild(root_1, expr122.Tree);

            	            			    }
            	            			    break;

            	            			default:
            	            			    goto loop41;
            	            	    }
            	            	} while (true);

            	            	loop41:
            	            		;	// Stops C# compiler whining that label 'loop41' has no statements


            	            }
            	            break;

            	    }


            	    Match(input, Token.UP, null); 
            	}adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	}


            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "inRhs"

    public class exprOrSubquery_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "exprOrSubquery"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:546:1: exprOrSubquery : ( expr | query | ^( ANY collectionFunctionOrSubselect ) | ^( ALL collectionFunctionOrSubselect ) | ^( SOME collectionFunctionOrSubselect ) );
    public HqlSqlWalker.exprOrSubquery_return exprOrSubquery() // throws RecognitionException [1]
    {   
        HqlSqlWalker.exprOrSubquery_return retval = new HqlSqlWalker.exprOrSubquery_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree ANY125 = null;
        CommonTree ALL127 = null;
        CommonTree SOME129 = null;
        HqlSqlWalker.expr_return expr123 = default(HqlSqlWalker.expr_return);

        HqlSqlWalker.query_return query124 = default(HqlSqlWalker.query_return);

        HqlSqlWalker.collectionFunctionOrSubselect_return collectionFunctionOrSubselect126 = default(HqlSqlWalker.collectionFunctionOrSubselect_return);

        HqlSqlWalker.collectionFunctionOrSubselect_return collectionFunctionOrSubselect128 = default(HqlSqlWalker.collectionFunctionOrSubselect_return);

        HqlSqlWalker.collectionFunctionOrSubselect_return collectionFunctionOrSubselect130 = default(HqlSqlWalker.collectionFunctionOrSubselect_return);


        CommonTree ANY125_tree=null;
        CommonTree ALL127_tree=null;
        CommonTree SOME129_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:547:2: ( expr | query | ^( ANY collectionFunctionOrSubselect ) | ^( ALL collectionFunctionOrSubselect ) | ^( SOME collectionFunctionOrSubselect ) )
            int alt43 = 5;
            switch ( input.LA(1) ) 
            {
            case COUNT:
            case DOT:
            case FALSE:
            case NULL:
            case TRUE:
            case CASE:
            case AGGREGATE:
            case CASE2:
            case INDEX_OP:
            case METHOD_CALL:
            case UNARY_MINUS:
            case VECTOR_EXPR:
            case WEIRD_IDENT:
            case NUM_INT:
            case NUM_DOUBLE:
            case NUM_FLOAT:
            case NUM_LONG:
            case JAVA_CONSTANT:
            case PLUS:
            case MINUS:
            case STAR:
            case DIV:
            case COLON:
            case PARAM:
            case IDENT:
            case QUOTED_STRING:
            	{
                alt43 = 1;
                }
                break;
            case QUERY:
            	{
                alt43 = 2;
                }
                break;
            case ANY:
            	{
                alt43 = 3;
                }
                break;
            case ALL:
            	{
                alt43 = 4;
                }
                break;
            case SOME:
            	{
                alt43 = 5;
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
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:547:4: expr
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_expr_in_exprOrSubquery1662);
                    	expr123 = expr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, expr123.Tree);

                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:548:4: query
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_query_in_exprOrSubquery1667);
                    	query124 = query();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, query124.Tree);

                    }
                    break;
                case 3 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:549:4: ^( ANY collectionFunctionOrSubselect )
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	ANY125=(CommonTree)Match(input,ANY,FOLLOW_ANY_in_exprOrSubquery1673); 
                    		ANY125_tree = (CommonTree)adaptor.DupNode(ANY125);

                    		root_1 = (CommonTree)adaptor.BecomeRoot(ANY125_tree, root_1);



                    	Match(input, Token.DOWN, null); 
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_collectionFunctionOrSubselect_in_exprOrSubquery1675);
                    	collectionFunctionOrSubselect126 = collectionFunctionOrSubselect();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_1, collectionFunctionOrSubselect126.Tree);

                    	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
                    	}


                    }
                    break;
                case 4 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:550:4: ^( ALL collectionFunctionOrSubselect )
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	ALL127=(CommonTree)Match(input,ALL,FOLLOW_ALL_in_exprOrSubquery1682); 
                    		ALL127_tree = (CommonTree)adaptor.DupNode(ALL127);

                    		root_1 = (CommonTree)adaptor.BecomeRoot(ALL127_tree, root_1);



                    	Match(input, Token.DOWN, null); 
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_collectionFunctionOrSubselect_in_exprOrSubquery1684);
                    	collectionFunctionOrSubselect128 = collectionFunctionOrSubselect();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_1, collectionFunctionOrSubselect128.Tree);

                    	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
                    	}


                    }
                    break;
                case 5 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:551:4: ^( SOME collectionFunctionOrSubselect )
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	SOME129=(CommonTree)Match(input,SOME,FOLLOW_SOME_in_exprOrSubquery1691); 
                    		SOME129_tree = (CommonTree)adaptor.DupNode(SOME129);

                    		root_1 = (CommonTree)adaptor.BecomeRoot(SOME129_tree, root_1);



                    	Match(input, Token.DOWN, null); 
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_collectionFunctionOrSubselect_in_exprOrSubquery1693);
                    	collectionFunctionOrSubselect130 = collectionFunctionOrSubselect();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_1, collectionFunctionOrSubselect130.Tree);

                    	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
                    	}


                    }
                    break;

            }
            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "exprOrSubquery"

    public class collectionFunctionOrSubselect_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "collectionFunctionOrSubselect"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:554:1: collectionFunctionOrSubselect : ( collectionFunction | query );
    public HqlSqlWalker.collectionFunctionOrSubselect_return collectionFunctionOrSubselect() // throws RecognitionException [1]
    {   
        HqlSqlWalker.collectionFunctionOrSubselect_return retval = new HqlSqlWalker.collectionFunctionOrSubselect_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        HqlSqlWalker.collectionFunction_return collectionFunction131 = default(HqlSqlWalker.collectionFunction_return);

        HqlSqlWalker.query_return query132 = default(HqlSqlWalker.query_return);



        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:555:2: ( collectionFunction | query )
            int alt44 = 2;
            int LA44_0 = input.LA(1);

            if ( (LA44_0 == ELEMENTS || LA44_0 == INDICES) )
            {
                alt44 = 1;
            }
            else if ( (LA44_0 == QUERY) )
            {
                alt44 = 2;
            }
            else 
            {
                NoViableAltException nvae_d44s0 =
                    new NoViableAltException("", 44, 0, input);

                throw nvae_d44s0;
            }
            switch (alt44) 
            {
                case 1 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:555:4: collectionFunction
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_collectionFunction_in_collectionFunctionOrSubselect1706);
                    	collectionFunction131 = collectionFunction();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, collectionFunction131.Tree);

                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:556:4: query
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_query_in_collectionFunctionOrSubselect1711);
                    	query132 = query();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, query132.Tree);

                    }
                    break;

            }
            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "collectionFunctionOrSubselect"

    public class expr_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "expr"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:571:1: expr : (ae= addrExpr[ true ] | ^( VECTOR_EXPR ( expr )* ) | constant | arithmeticExpr | functionCall | parameter | count );
    public HqlSqlWalker.expr_return expr() // throws RecognitionException [1]
    {   
        HqlSqlWalker.expr_return retval = new HqlSqlWalker.expr_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree VECTOR_EXPR133 = null;
        HqlSqlWalker.addrExpr_return ae = default(HqlSqlWalker.addrExpr_return);

        HqlSqlWalker.expr_return expr134 = default(HqlSqlWalker.expr_return);

        HqlSqlWalker.constant_return constant135 = default(HqlSqlWalker.constant_return);

        HqlSqlWalker.arithmeticExpr_return arithmeticExpr136 = default(HqlSqlWalker.arithmeticExpr_return);

        HqlSqlWalker.functionCall_return functionCall137 = default(HqlSqlWalker.functionCall_return);

        HqlSqlWalker.parameter_return parameter138 = default(HqlSqlWalker.parameter_return);

        HqlSqlWalker.count_return count139 = default(HqlSqlWalker.count_return);


        CommonTree VECTOR_EXPR133_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:572:2: (ae= addrExpr[ true ] | ^( VECTOR_EXPR ( expr )* ) | constant | arithmeticExpr | functionCall | parameter | count )
            int alt46 = 7;
            switch ( input.LA(1) ) 
            {
            case DOT:
            case INDEX_OP:
            case WEIRD_IDENT:
            case IDENT:
            	{
                alt46 = 1;
                }
                break;
            case VECTOR_EXPR:
            	{
                alt46 = 2;
                }
                break;
            case FALSE:
            case NULL:
            case TRUE:
            case NUM_INT:
            case NUM_DOUBLE:
            case NUM_FLOAT:
            case NUM_LONG:
            case JAVA_CONSTANT:
            case QUOTED_STRING:
            	{
                alt46 = 3;
                }
                break;
            case CASE:
            case CASE2:
            case UNARY_MINUS:
            case PLUS:
            case MINUS:
            case STAR:
            case DIV:
            	{
                alt46 = 4;
                }
                break;
            case AGGREGATE:
            case METHOD_CALL:
            	{
                alt46 = 5;
                }
                break;
            case COLON:
            case PARAM:
            	{
                alt46 = 6;
                }
                break;
            case COUNT:
            	{
                alt46 = 7;
                }
                break;
            	default:
            	    NoViableAltException nvae_d46s0 =
            	        new NoViableAltException("", 46, 0, input);

            	    throw nvae_d46s0;
            }

            switch (alt46) 
            {
                case 1 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:572:4: ae= addrExpr[ true ]
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_addrExpr_in_expr1727);
                    	ae = addrExpr(true);
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, ae.Tree);
                    	 resolve(((ae != null) ? ((CommonTree)ae.Tree) : null)); 

                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:573:4: ^( VECTOR_EXPR ( expr )* )
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	VECTOR_EXPR133=(CommonTree)Match(input,VECTOR_EXPR,FOLLOW_VECTOR_EXPR_in_expr1739); 
                    		VECTOR_EXPR133_tree = (CommonTree)adaptor.DupNode(VECTOR_EXPR133);

                    		root_1 = (CommonTree)adaptor.BecomeRoot(VECTOR_EXPR133_tree, root_1);



                    	if ( input.LA(1) == Token.DOWN )
                    	{
                    	    Match(input, Token.DOWN, null); 
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:573:19: ( expr )*
                    	    do 
                    	    {
                    	        int alt45 = 2;
                    	        int LA45_0 = input.LA(1);

                    	        if ( (LA45_0 == COUNT || LA45_0 == DOT || LA45_0 == FALSE || LA45_0 == NULL || LA45_0 == TRUE || LA45_0 == CASE || LA45_0 == AGGREGATE || LA45_0 == CASE2 || LA45_0 == INDEX_OP || LA45_0 == METHOD_CALL || LA45_0 == UNARY_MINUS || (LA45_0 >= VECTOR_EXPR && LA45_0 <= WEIRD_IDENT) || (LA45_0 >= NUM_INT && LA45_0 <= JAVA_CONSTANT) || (LA45_0 >= PLUS && LA45_0 <= DIV) || (LA45_0 >= COLON && LA45_0 <= PARAM) || LA45_0 == IDENT || LA45_0 == QUOTED_STRING) )
                    	        {
                    	            alt45 = 1;
                    	        }


                    	        switch (alt45) 
                    	    	{
                    	    		case 1 :
                    	    		    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:573:20: expr
                    	    		    {
                    	    		    	_last = (CommonTree)input.LT(1);
                    	    		    	PushFollow(FOLLOW_expr_in_expr1742);
                    	    		    	expr134 = expr();
                    	    		    	state.followingStackPointer--;

                    	    		    	adaptor.AddChild(root_1, expr134.Tree);

                    	    		    }
                    	    		    break;

                    	    		default:
                    	    		    goto loop45;
                    	        }
                    	    } while (true);

                    	    loop45:
                    	    	;	// Stops C# compiler whining that label 'loop45' has no statements


                    	    Match(input, Token.UP, null); 
                    	}adaptor.AddChild(root_0, root_1);_last = _save_last_1;
                    	}


                    }
                    break;
                case 3 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:574:4: constant
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_constant_in_expr1751);
                    	constant135 = constant();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, constant135.Tree);

                    }
                    break;
                case 4 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:575:4: arithmeticExpr
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_arithmeticExpr_in_expr1756);
                    	arithmeticExpr136 = arithmeticExpr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, arithmeticExpr136.Tree);

                    }
                    break;
                case 5 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:576:4: functionCall
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_functionCall_in_expr1761);
                    	functionCall137 = functionCall();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, functionCall137.Tree);

                    }
                    break;
                case 6 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:577:4: parameter
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_parameter_in_expr1773);
                    	parameter138 = parameter();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, parameter138.Tree);

                    }
                    break;
                case 7 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:578:4: count
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_count_in_expr1778);
                    	count139 = count();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, count139.Tree);

                    }
                    break;

            }
            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "expr"

    public class arithmeticExpr_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "arithmeticExpr"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:593:1: arithmeticExpr : ( ^( PLUS expr expr ) | ^( MINUS expr expr ) | ^( DIV expr expr ) | ^( STAR expr expr ) | ^( UNARY_MINUS expr ) | c= caseExpr );
    public HqlSqlWalker.arithmeticExpr_return arithmeticExpr() // throws RecognitionException [1]
    {   
        HqlSqlWalker.arithmeticExpr_return retval = new HqlSqlWalker.arithmeticExpr_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree PLUS140 = null;
        CommonTree MINUS143 = null;
        CommonTree DIV146 = null;
        CommonTree STAR149 = null;
        CommonTree UNARY_MINUS152 = null;
        HqlSqlWalker.caseExpr_return c = default(HqlSqlWalker.caseExpr_return);

        HqlSqlWalker.expr_return expr141 = default(HqlSqlWalker.expr_return);

        HqlSqlWalker.expr_return expr142 = default(HqlSqlWalker.expr_return);

        HqlSqlWalker.expr_return expr144 = default(HqlSqlWalker.expr_return);

        HqlSqlWalker.expr_return expr145 = default(HqlSqlWalker.expr_return);

        HqlSqlWalker.expr_return expr147 = default(HqlSqlWalker.expr_return);

        HqlSqlWalker.expr_return expr148 = default(HqlSqlWalker.expr_return);

        HqlSqlWalker.expr_return expr150 = default(HqlSqlWalker.expr_return);

        HqlSqlWalker.expr_return expr151 = default(HqlSqlWalker.expr_return);

        HqlSqlWalker.expr_return expr153 = default(HqlSqlWalker.expr_return);


        CommonTree PLUS140_tree=null;
        CommonTree MINUS143_tree=null;
        CommonTree DIV146_tree=null;
        CommonTree STAR149_tree=null;
        CommonTree UNARY_MINUS152_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:600:2: ( ^( PLUS expr expr ) | ^( MINUS expr expr ) | ^( DIV expr expr ) | ^( STAR expr expr ) | ^( UNARY_MINUS expr ) | c= caseExpr )
            int alt47 = 6;
            switch ( input.LA(1) ) 
            {
            case PLUS:
            	{
                alt47 = 1;
                }
                break;
            case MINUS:
            	{
                alt47 = 2;
                }
                break;
            case DIV:
            	{
                alt47 = 3;
                }
                break;
            case STAR:
            	{
                alt47 = 4;
                }
                break;
            case UNARY_MINUS:
            	{
                alt47 = 5;
                }
                break;
            case CASE:
            case CASE2:
            	{
                alt47 = 6;
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
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:600:4: ^( PLUS expr expr )
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	PLUS140=(CommonTree)Match(input,PLUS,FOLLOW_PLUS_in_arithmeticExpr1808); 
                    		PLUS140_tree = (CommonTree)adaptor.DupNode(PLUS140);

                    		root_1 = (CommonTree)adaptor.BecomeRoot(PLUS140_tree, root_1);



                    	Match(input, Token.DOWN, null); 
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_expr_in_arithmeticExpr1810);
                    	expr141 = expr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_1, expr141.Tree);
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_expr_in_arithmeticExpr1812);
                    	expr142 = expr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_1, expr142.Tree);

                    	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
                    	}


                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:601:4: ^( MINUS expr expr )
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	MINUS143=(CommonTree)Match(input,MINUS,FOLLOW_MINUS_in_arithmeticExpr1819); 
                    		MINUS143_tree = (CommonTree)adaptor.DupNode(MINUS143);

                    		root_1 = (CommonTree)adaptor.BecomeRoot(MINUS143_tree, root_1);



                    	Match(input, Token.DOWN, null); 
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_expr_in_arithmeticExpr1821);
                    	expr144 = expr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_1, expr144.Tree);
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_expr_in_arithmeticExpr1823);
                    	expr145 = expr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_1, expr145.Tree);

                    	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
                    	}


                    }
                    break;
                case 3 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:602:4: ^( DIV expr expr )
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	DIV146=(CommonTree)Match(input,DIV,FOLLOW_DIV_in_arithmeticExpr1830); 
                    		DIV146_tree = (CommonTree)adaptor.DupNode(DIV146);

                    		root_1 = (CommonTree)adaptor.BecomeRoot(DIV146_tree, root_1);



                    	Match(input, Token.DOWN, null); 
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_expr_in_arithmeticExpr1832);
                    	expr147 = expr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_1, expr147.Tree);
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_expr_in_arithmeticExpr1834);
                    	expr148 = expr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_1, expr148.Tree);

                    	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
                    	}


                    }
                    break;
                case 4 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:603:4: ^( STAR expr expr )
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	STAR149=(CommonTree)Match(input,STAR,FOLLOW_STAR_in_arithmeticExpr1841); 
                    		STAR149_tree = (CommonTree)adaptor.DupNode(STAR149);

                    		root_1 = (CommonTree)adaptor.BecomeRoot(STAR149_tree, root_1);



                    	Match(input, Token.DOWN, null); 
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_expr_in_arithmeticExpr1843);
                    	expr150 = expr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_1, expr150.Tree);
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_expr_in_arithmeticExpr1845);
                    	expr151 = expr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_1, expr151.Tree);

                    	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
                    	}


                    }
                    break;
                case 5 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:605:4: ^( UNARY_MINUS expr )
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	UNARY_MINUS152=(CommonTree)Match(input,UNARY_MINUS,FOLLOW_UNARY_MINUS_in_arithmeticExpr1853); 
                    		UNARY_MINUS152_tree = (CommonTree)adaptor.DupNode(UNARY_MINUS152);

                    		root_1 = (CommonTree)adaptor.BecomeRoot(UNARY_MINUS152_tree, root_1);



                    	Match(input, Token.DOWN, null); 
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_expr_in_arithmeticExpr1855);
                    	expr153 = expr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_1, expr153.Tree);

                    	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
                    	}


                    }
                    break;
                case 6 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:606:4: c= caseExpr
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_caseExpr_in_arithmeticExpr1863);
                    	c = caseExpr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, c.Tree);

                    }
                    break;

            }
            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);


            		if (((c != null) ? ((CommonTree)c.Tree) : null) == null)
            		{
            			prepareArithmeticOperator( ((CommonTree)retval.Tree) );
            		}
            	
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "arithmeticExpr"

    public class caseExpr_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "caseExpr"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:609:1: caseExpr : ( ^( CASE ( ^( WHEN logicalExpr expr ) )+ ( ^( ELSE expr ) )? ) | ^( CASE2 expr ( ^( WHEN expr expr ) )+ ( ^( ELSE expr ) )? ) );
    public HqlSqlWalker.caseExpr_return caseExpr() // throws RecognitionException [1]
    {   
        HqlSqlWalker.caseExpr_return retval = new HqlSqlWalker.caseExpr_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree CASE154 = null;
        CommonTree WHEN155 = null;
        CommonTree ELSE158 = null;
        CommonTree CASE2160 = null;
        CommonTree WHEN162 = null;
        CommonTree ELSE165 = null;
        HqlSqlWalker.logicalExpr_return logicalExpr156 = default(HqlSqlWalker.logicalExpr_return);

        HqlSqlWalker.expr_return expr157 = default(HqlSqlWalker.expr_return);

        HqlSqlWalker.expr_return expr159 = default(HqlSqlWalker.expr_return);

        HqlSqlWalker.expr_return expr161 = default(HqlSqlWalker.expr_return);

        HqlSqlWalker.expr_return expr163 = default(HqlSqlWalker.expr_return);

        HqlSqlWalker.expr_return expr164 = default(HqlSqlWalker.expr_return);

        HqlSqlWalker.expr_return expr166 = default(HqlSqlWalker.expr_return);


        CommonTree CASE154_tree=null;
        CommonTree WHEN155_tree=null;
        CommonTree ELSE158_tree=null;
        CommonTree CASE2160_tree=null;
        CommonTree WHEN162_tree=null;
        CommonTree ELSE165_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:610:2: ( ^( CASE ( ^( WHEN logicalExpr expr ) )+ ( ^( ELSE expr ) )? ) | ^( CASE2 expr ( ^( WHEN expr expr ) )+ ( ^( ELSE expr ) )? ) )
            int alt52 = 2;
            int LA52_0 = input.LA(1);

            if ( (LA52_0 == CASE) )
            {
                alt52 = 1;
            }
            else if ( (LA52_0 == CASE2) )
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
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:610:4: ^( CASE ( ^( WHEN logicalExpr expr ) )+ ( ^( ELSE expr ) )? )
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	CASE154=(CommonTree)Match(input,CASE,FOLLOW_CASE_in_caseExpr1875); 
                    		CASE154_tree = (CommonTree)adaptor.DupNode(CASE154);

                    		root_1 = (CommonTree)adaptor.BecomeRoot(CASE154_tree, root_1);


                    	 _inCase = true; 

                    	Match(input, Token.DOWN, null); 
                    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:610:31: ( ^( WHEN logicalExpr expr ) )+
                    	int cnt48 = 0;
                    	do 
                    	{
                    	    int alt48 = 2;
                    	    int LA48_0 = input.LA(1);

                    	    if ( (LA48_0 == WHEN) )
                    	    {
                    	        alt48 = 1;
                    	    }


                    	    switch (alt48) 
                    		{
                    			case 1 :
                    			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:610:32: ^( WHEN logicalExpr expr )
                    			    {
                    			    	_last = (CommonTree)input.LT(1);
                    			    	{
                    			    	CommonTree _save_last_2 = _last;
                    			    	CommonTree _first_2 = null;
                    			    	CommonTree root_2 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    			    	WHEN155=(CommonTree)Match(input,WHEN,FOLLOW_WHEN_in_caseExpr1881); 
                    			    		WHEN155_tree = (CommonTree)adaptor.DupNode(WHEN155);

                    			    		root_2 = (CommonTree)adaptor.BecomeRoot(WHEN155_tree, root_2);



                    			    	Match(input, Token.DOWN, null); 
                    			    	_last = (CommonTree)input.LT(1);
                    			    	PushFollow(FOLLOW_logicalExpr_in_caseExpr1883);
                    			    	logicalExpr156 = logicalExpr();
                    			    	state.followingStackPointer--;

                    			    	adaptor.AddChild(root_2, logicalExpr156.Tree);
                    			    	_last = (CommonTree)input.LT(1);
                    			    	PushFollow(FOLLOW_expr_in_caseExpr1885);
                    			    	expr157 = expr();
                    			    	state.followingStackPointer--;

                    			    	adaptor.AddChild(root_2, expr157.Tree);

                    			    	Match(input, Token.UP, null); adaptor.AddChild(root_1, root_2);_last = _save_last_2;
                    			    	}


                    			    }
                    			    break;

                    			default:
                    			    if ( cnt48 >= 1 ) goto loop48;
                    		            EarlyExitException eee =
                    		                new EarlyExitException(48, input);
                    		            throw eee;
                    	    }
                    	    cnt48++;
                    	} while (true);

                    	loop48:
                    		;	// Stops C# compiler whinging that label 'loop48' has no statements

                    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:610:59: ( ^( ELSE expr ) )?
                    	int alt49 = 2;
                    	int LA49_0 = input.LA(1);

                    	if ( (LA49_0 == ELSE) )
                    	{
                    	    alt49 = 1;
                    	}
                    	switch (alt49) 
                    	{
                    	    case 1 :
                    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:610:60: ^( ELSE expr )
                    	        {
                    	        	_last = (CommonTree)input.LT(1);
                    	        	{
                    	        	CommonTree _save_last_2 = _last;
                    	        	CommonTree _first_2 = null;
                    	        	CommonTree root_2 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	        	ELSE158=(CommonTree)Match(input,ELSE,FOLLOW_ELSE_in_caseExpr1892); 
                    	        		ELSE158_tree = (CommonTree)adaptor.DupNode(ELSE158);

                    	        		root_2 = (CommonTree)adaptor.BecomeRoot(ELSE158_tree, root_2);



                    	        	Match(input, Token.DOWN, null); 
                    	        	_last = (CommonTree)input.LT(1);
                    	        	PushFollow(FOLLOW_expr_in_caseExpr1894);
                    	        	expr159 = expr();
                    	        	state.followingStackPointer--;

                    	        	adaptor.AddChild(root_2, expr159.Tree);

                    	        	Match(input, Token.UP, null); adaptor.AddChild(root_1, root_2);_last = _save_last_2;
                    	        	}


                    	        }
                    	        break;

                    	}


                    	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
                    	}

                    	 _inCase = false; 

                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:611:4: ^( CASE2 expr ( ^( WHEN expr expr ) )+ ( ^( ELSE expr ) )? )
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	CASE2160=(CommonTree)Match(input,CASE2,FOLLOW_CASE2_in_caseExpr1906); 
                    		CASE2160_tree = (CommonTree)adaptor.DupNode(CASE2160);

                    		root_1 = (CommonTree)adaptor.BecomeRoot(CASE2160_tree, root_1);


                    	 _inCase = true; 

                    	Match(input, Token.DOWN, null); 
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_expr_in_caseExpr1910);
                    	expr161 = expr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_1, expr161.Tree);
                    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:611:37: ( ^( WHEN expr expr ) )+
                    	int cnt50 = 0;
                    	do 
                    	{
                    	    int alt50 = 2;
                    	    int LA50_0 = input.LA(1);

                    	    if ( (LA50_0 == WHEN) )
                    	    {
                    	        alt50 = 1;
                    	    }


                    	    switch (alt50) 
                    		{
                    			case 1 :
                    			    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:611:38: ^( WHEN expr expr )
                    			    {
                    			    	_last = (CommonTree)input.LT(1);
                    			    	{
                    			    	CommonTree _save_last_2 = _last;
                    			    	CommonTree _first_2 = null;
                    			    	CommonTree root_2 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    			    	WHEN162=(CommonTree)Match(input,WHEN,FOLLOW_WHEN_in_caseExpr1914); 
                    			    		WHEN162_tree = (CommonTree)adaptor.DupNode(WHEN162);

                    			    		root_2 = (CommonTree)adaptor.BecomeRoot(WHEN162_tree, root_2);



                    			    	Match(input, Token.DOWN, null); 
                    			    	_last = (CommonTree)input.LT(1);
                    			    	PushFollow(FOLLOW_expr_in_caseExpr1916);
                    			    	expr163 = expr();
                    			    	state.followingStackPointer--;

                    			    	adaptor.AddChild(root_2, expr163.Tree);
                    			    	_last = (CommonTree)input.LT(1);
                    			    	PushFollow(FOLLOW_expr_in_caseExpr1918);
                    			    	expr164 = expr();
                    			    	state.followingStackPointer--;

                    			    	adaptor.AddChild(root_2, expr164.Tree);

                    			    	Match(input, Token.UP, null); adaptor.AddChild(root_1, root_2);_last = _save_last_2;
                    			    	}


                    			    }
                    			    break;

                    			default:
                    			    if ( cnt50 >= 1 ) goto loop50;
                    		            EarlyExitException eee =
                    		                new EarlyExitException(50, input);
                    		            throw eee;
                    	    }
                    	    cnt50++;
                    	} while (true);

                    	loop50:
                    		;	// Stops C# compiler whinging that label 'loop50' has no statements

                    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:611:58: ( ^( ELSE expr ) )?
                    	int alt51 = 2;
                    	int LA51_0 = input.LA(1);

                    	if ( (LA51_0 == ELSE) )
                    	{
                    	    alt51 = 1;
                    	}
                    	switch (alt51) 
                    	{
                    	    case 1 :
                    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:611:59: ^( ELSE expr )
                    	        {
                    	        	_last = (CommonTree)input.LT(1);
                    	        	{
                    	        	CommonTree _save_last_2 = _last;
                    	        	CommonTree _first_2 = null;
                    	        	CommonTree root_2 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	        	ELSE165=(CommonTree)Match(input,ELSE,FOLLOW_ELSE_in_caseExpr1925); 
                    	        		ELSE165_tree = (CommonTree)adaptor.DupNode(ELSE165);

                    	        		root_2 = (CommonTree)adaptor.BecomeRoot(ELSE165_tree, root_2);



                    	        	Match(input, Token.DOWN, null); 
                    	        	_last = (CommonTree)input.LT(1);
                    	        	PushFollow(FOLLOW_expr_in_caseExpr1927);
                    	        	expr166 = expr();
                    	        	state.followingStackPointer--;

                    	        	adaptor.AddChild(root_2, expr166.Tree);

                    	        	Match(input, Token.UP, null); adaptor.AddChild(root_1, root_2);_last = _save_last_2;
                    	        	}


                    	        }
                    	        break;

                    	}


                    	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
                    	}

                    	 _inCase = false; 

                    }
                    break;

            }
            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "caseExpr"

    public class collectionFunction_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "collectionFunction"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:625:1: collectionFunction : ( ^(e= ELEMENTS p1= propertyRef ) | ^(i= INDICES p2= propertyRef ) );
    public HqlSqlWalker.collectionFunction_return collectionFunction() // throws RecognitionException [1]
    {   
        HqlSqlWalker.collectionFunction_return retval = new HqlSqlWalker.collectionFunction_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree e = null;
        CommonTree i = null;
        HqlSqlWalker.propertyRef_return p1 = default(HqlSqlWalker.propertyRef_return);

        HqlSqlWalker.propertyRef_return p2 = default(HqlSqlWalker.propertyRef_return);


        CommonTree e_tree=null;
        CommonTree i_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:626:2: ( ^(e= ELEMENTS p1= propertyRef ) | ^(i= INDICES p2= propertyRef ) )
            int alt53 = 2;
            int LA53_0 = input.LA(1);

            if ( (LA53_0 == ELEMENTS) )
            {
                alt53 = 1;
            }
            else if ( (LA53_0 == INDICES) )
            {
                alt53 = 2;
            }
            else 
            {
                NoViableAltException nvae_d53s0 =
                    new NoViableAltException("", 53, 0, input);

                throw nvae_d53s0;
            }
            switch (alt53) 
            {
                case 1 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:626:4: ^(e= ELEMENTS p1= propertyRef )
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	e=(CommonTree)Match(input,ELEMENTS,FOLLOW_ELEMENTS_in_collectionFunction1951); 
                    		e_tree = (CommonTree)adaptor.DupNode(e);

                    		root_1 = (CommonTree)adaptor.BecomeRoot(e_tree, root_1);


                    	_inFunctionCall=true;

                    	Match(input, Token.DOWN, null); 
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_propertyRef_in_collectionFunction1957);
                    	p1 = propertyRef();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_1, p1.Tree);
                    	 resolve(((p1 != null) ? ((CommonTree)p1.Tree) : null)); 

                    	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
                    	}

                    	 processFunction(e_tree,_inSelect); 
                    	_inFunctionCall=false;

                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:628:4: ^(i= INDICES p2= propertyRef )
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	i=(CommonTree)Match(input,INDICES,FOLLOW_INDICES_in_collectionFunction1976); 
                    		i_tree = (CommonTree)adaptor.DupNode(i);

                    		root_1 = (CommonTree)adaptor.BecomeRoot(i_tree, root_1);


                    	_inFunctionCall=true;

                    	Match(input, Token.DOWN, null); 
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_propertyRef_in_collectionFunction1982);
                    	p2 = propertyRef();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_1, p2.Tree);
                    	 resolve(((p2 != null) ? ((CommonTree)p2.Tree) : null)); 

                    	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
                    	}

                    	 processFunction(i_tree,_inSelect); 
                    	_inFunctionCall=false;

                    }
                    break;

            }
            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "collectionFunction"

    public class functionCall_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "functionCall"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:640:1: functionCall : ( ^( METHOD_CALL pathAsIdent ( ^( EXPR_LIST ( expr )* ) )? ) | ^( AGGREGATE aggregateExpr ) );
    public HqlSqlWalker.functionCall_return functionCall() // throws RecognitionException [1]
    {   
        HqlSqlWalker.functionCall_return retval = new HqlSqlWalker.functionCall_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree METHOD_CALL167 = null;
        CommonTree EXPR_LIST169 = null;
        CommonTree AGGREGATE171 = null;
        HqlSqlWalker.pathAsIdent_return pathAsIdent168 = default(HqlSqlWalker.pathAsIdent_return);

        HqlSqlWalker.expr_return expr170 = default(HqlSqlWalker.expr_return);

        HqlSqlWalker.aggregateExpr_return aggregateExpr172 = default(HqlSqlWalker.aggregateExpr_return);


        CommonTree METHOD_CALL167_tree=null;
        CommonTree EXPR_LIST169_tree=null;
        CommonTree AGGREGATE171_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:641:2: ( ^( METHOD_CALL pathAsIdent ( ^( EXPR_LIST ( expr )* ) )? ) | ^( AGGREGATE aggregateExpr ) )
            int alt56 = 2;
            int LA56_0 = input.LA(1);

            if ( (LA56_0 == METHOD_CALL) )
            {
                alt56 = 1;
            }
            else if ( (LA56_0 == AGGREGATE) )
            {
                alt56 = 2;
            }
            else 
            {
                NoViableAltException nvae_d56s0 =
                    new NoViableAltException("", 56, 0, input);

                throw nvae_d56s0;
            }
            switch (alt56) 
            {
                case 1 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:641:4: ^( METHOD_CALL pathAsIdent ( ^( EXPR_LIST ( expr )* ) )? )
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	METHOD_CALL167=(CommonTree)Match(input,METHOD_CALL,FOLLOW_METHOD_CALL_in_functionCall2007); 
                    		METHOD_CALL167_tree = (CommonTree)adaptor.DupNode(METHOD_CALL167);

                    		root_1 = (CommonTree)adaptor.BecomeRoot(METHOD_CALL167_tree, root_1);


                    	_inFunctionCall=true;

                    	Match(input, Token.DOWN, null); 
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_pathAsIdent_in_functionCall2012);
                    	pathAsIdent168 = pathAsIdent();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_1, pathAsIdent168.Tree);
                    	// /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:641:55: ( ^( EXPR_LIST ( expr )* ) )?
                    	int alt55 = 2;
                    	int LA55_0 = input.LA(1);

                    	if ( (LA55_0 == EXPR_LIST) )
                    	{
                    	    alt55 = 1;
                    	}
                    	switch (alt55) 
                    	{
                    	    case 1 :
                    	        // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:641:57: ^( EXPR_LIST ( expr )* )
                    	        {
                    	        	_last = (CommonTree)input.LT(1);
                    	        	{
                    	        	CommonTree _save_last_2 = _last;
                    	        	CommonTree _first_2 = null;
                    	        	CommonTree root_2 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	        	EXPR_LIST169=(CommonTree)Match(input,EXPR_LIST,FOLLOW_EXPR_LIST_in_functionCall2017); 
                    	        		EXPR_LIST169_tree = (CommonTree)adaptor.DupNode(EXPR_LIST169);

                    	        		root_2 = (CommonTree)adaptor.BecomeRoot(EXPR_LIST169_tree, root_2);



                    	        	if ( input.LA(1) == Token.DOWN )
                    	        	{
                    	        	    Match(input, Token.DOWN, null); 
                    	        	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:641:69: ( expr )*
                    	        	    do 
                    	        	    {
                    	        	        int alt54 = 2;
                    	        	        int LA54_0 = input.LA(1);

                    	        	        if ( (LA54_0 == COUNT || LA54_0 == DOT || LA54_0 == FALSE || LA54_0 == NULL || LA54_0 == TRUE || LA54_0 == CASE || LA54_0 == AGGREGATE || LA54_0 == CASE2 || LA54_0 == INDEX_OP || LA54_0 == METHOD_CALL || LA54_0 == UNARY_MINUS || (LA54_0 >= VECTOR_EXPR && LA54_0 <= WEIRD_IDENT) || (LA54_0 >= NUM_INT && LA54_0 <= JAVA_CONSTANT) || (LA54_0 >= PLUS && LA54_0 <= DIV) || (LA54_0 >= COLON && LA54_0 <= PARAM) || LA54_0 == IDENT || LA54_0 == QUOTED_STRING) )
                    	        	        {
                    	        	            alt54 = 1;
                    	        	        }


                    	        	        switch (alt54) 
                    	        	    	{
                    	        	    		case 1 :
                    	        	    		    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:641:70: expr
                    	        	    		    {
                    	        	    		    	_last = (CommonTree)input.LT(1);
                    	        	    		    	PushFollow(FOLLOW_expr_in_functionCall2020);
                    	        	    		    	expr170 = expr();
                    	        	    		    	state.followingStackPointer--;

                    	        	    		    	adaptor.AddChild(root_2, expr170.Tree);

                    	        	    		    }
                    	        	    		    break;

                    	        	    		default:
                    	        	    		    goto loop54;
                    	        	        }
                    	        	    } while (true);

                    	        	    loop54:
                    	        	    	;	// Stops C# compiler whining that label 'loop54' has no statements


                    	        	    Match(input, Token.UP, null); 
                    	        	}adaptor.AddChild(root_1, root_2);_last = _save_last_2;
                    	        	}


                    	        }
                    	        break;

                    	}


                    	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
                    	}

                    	 processFunction(((CommonTree)retval.Tree),_inSelect); 
                    	_inFunctionCall=false;

                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:643:4: ^( AGGREGATE aggregateExpr )
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	AGGREGATE171=(CommonTree)Match(input,AGGREGATE,FOLLOW_AGGREGATE_in_functionCall2041); 
                    		AGGREGATE171_tree = (CommonTree)adaptor.DupNode(AGGREGATE171);

                    		root_1 = (CommonTree)adaptor.BecomeRoot(AGGREGATE171_tree, root_1);



                    	Match(input, Token.DOWN, null); 
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_aggregateExpr_in_functionCall2043);
                    	aggregateExpr172 = aggregateExpr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_1, aggregateExpr172.Tree);

                    	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
                    	}


                    }
                    break;

            }
            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "functionCall"

    public class constant_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "constant"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:656:1: constant : ( literal | NULL | TRUE | FALSE | JAVA_CONSTANT );
    public HqlSqlWalker.constant_return constant() // throws RecognitionException [1]
    {   
        HqlSqlWalker.constant_return retval = new HqlSqlWalker.constant_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree NULL174 = null;
        CommonTree TRUE175 = null;
        CommonTree FALSE176 = null;
        CommonTree JAVA_CONSTANT177 = null;
        HqlSqlWalker.literal_return literal173 = default(HqlSqlWalker.literal_return);


        CommonTree NULL174_tree=null;
        CommonTree TRUE175_tree=null;
        CommonTree FALSE176_tree=null;
        CommonTree JAVA_CONSTANT177_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:657:2: ( literal | NULL | TRUE | FALSE | JAVA_CONSTANT )
            int alt57 = 5;
            switch ( input.LA(1) ) 
            {
            case NUM_INT:
            case NUM_DOUBLE:
            case NUM_FLOAT:
            case NUM_LONG:
            case QUOTED_STRING:
            	{
                alt57 = 1;
                }
                break;
            case NULL:
            	{
                alt57 = 2;
                }
                break;
            case TRUE:
            	{
                alt57 = 3;
                }
                break;
            case FALSE:
            	{
                alt57 = 4;
                }
                break;
            case JAVA_CONSTANT:
            	{
                alt57 = 5;
                }
                break;
            	default:
            	    NoViableAltException nvae_d57s0 =
            	        new NoViableAltException("", 57, 0, input);

            	    throw nvae_d57s0;
            }

            switch (alt57) 
            {
                case 1 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:657:4: literal
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_literal_in_constant2058);
                    	literal173 = literal();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, literal173.Tree);

                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:658:4: NULL
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	NULL174=(CommonTree)Match(input,NULL,FOLLOW_NULL_in_constant2063); 
                    		NULL174_tree = (CommonTree)adaptor.DupNode(NULL174);

                    		adaptor.AddChild(root_0, NULL174_tree);


                    }
                    break;
                case 3 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:659:4: TRUE
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	TRUE175=(CommonTree)Match(input,TRUE,FOLLOW_TRUE_in_constant2068); 
                    		TRUE175_tree = (CommonTree)adaptor.DupNode(TRUE175);

                    		adaptor.AddChild(root_0, TRUE175_tree);

                    	 processbool(((CommonTree)retval.Tree)); 

                    }
                    break;
                case 4 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:660:4: FALSE
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	FALSE176=(CommonTree)Match(input,FALSE,FOLLOW_FALSE_in_constant2076); 
                    		FALSE176_tree = (CommonTree)adaptor.DupNode(FALSE176);

                    		adaptor.AddChild(root_0, FALSE176_tree);

                    	 processbool(((CommonTree)retval.Tree)); 

                    }
                    break;
                case 5 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:661:4: JAVA_CONSTANT
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	JAVA_CONSTANT177=(CommonTree)Match(input,JAVA_CONSTANT,FOLLOW_JAVA_CONSTANT_in_constant2083); 
                    		JAVA_CONSTANT177_tree = (CommonTree)adaptor.DupNode(JAVA_CONSTANT177);

                    		adaptor.AddChild(root_0, JAVA_CONSTANT177_tree);


                    }
                    break;

            }
            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "constant"

    public class literal_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "literal"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:674:1: literal : ( numericLiteral | stringLiteral );
    public HqlSqlWalker.literal_return literal() // throws RecognitionException [1]
    {   
        HqlSqlWalker.literal_return retval = new HqlSqlWalker.literal_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        HqlSqlWalker.numericLiteral_return numericLiteral178 = default(HqlSqlWalker.numericLiteral_return);

        HqlSqlWalker.stringLiteral_return stringLiteral179 = default(HqlSqlWalker.stringLiteral_return);



        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:675:2: ( numericLiteral | stringLiteral )
            int alt58 = 2;
            int LA58_0 = input.LA(1);

            if ( ((LA58_0 >= NUM_INT && LA58_0 <= NUM_LONG)) )
            {
                alt58 = 1;
            }
            else if ( (LA58_0 == QUOTED_STRING) )
            {
                alt58 = 2;
            }
            else 
            {
                NoViableAltException nvae_d58s0 =
                    new NoViableAltException("", 58, 0, input);

                throw nvae_d58s0;
            }
            switch (alt58) 
            {
                case 1 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:675:4: numericLiteral
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_numericLiteral_in_literal2096);
                    	numericLiteral178 = numericLiteral();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, numericLiteral178.Tree);

                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:676:4: stringLiteral
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_stringLiteral_in_literal2101);
                    	stringLiteral179 = stringLiteral();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, stringLiteral179.Tree);

                    }
                    break;

            }
            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "literal"

    public class numericLiteral_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "numericLiteral"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:679:1: numericLiteral : ( NUM_INT | NUM_LONG | NUM_FLOAT | NUM_DOUBLE );
    public HqlSqlWalker.numericLiteral_return numericLiteral() // throws RecognitionException [1]
    {   
        HqlSqlWalker.numericLiteral_return retval = new HqlSqlWalker.numericLiteral_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree set180 = null;

        CommonTree set180_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:684:2: ( NUM_INT | NUM_LONG | NUM_FLOAT | NUM_DOUBLE )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	_last = (CommonTree)input.LT(1);
            	set180 = (CommonTree)input.LT(1);
            	if ( (input.LA(1) >= NUM_INT && input.LA(1) <= NUM_LONG) ) 
            	{
            	    input.Consume();

            	    set180_tree = (CommonTree)adaptor.DupNode(set180);

            	    adaptor.AddChild(root_0, set180_tree);

            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	 

            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);


            	processNumericLiteral( ((CommonTree)retval.Tree) );

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "numericLiteral"

    public class stringLiteral_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "stringLiteral"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:690:1: stringLiteral : QUOTED_STRING ;
    public HqlSqlWalker.stringLiteral_return stringLiteral() // throws RecognitionException [1]
    {   
        HqlSqlWalker.stringLiteral_return retval = new HqlSqlWalker.stringLiteral_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree QUOTED_STRING181 = null;

        CommonTree QUOTED_STRING181_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:691:2: ( QUOTED_STRING )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:691:4: QUOTED_STRING
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	_last = (CommonTree)input.LT(1);
            	QUOTED_STRING181=(CommonTree)Match(input,QUOTED_STRING,FOLLOW_QUOTED_STRING_in_stringLiteral2143); 
            		QUOTED_STRING181_tree = (CommonTree)adaptor.DupNode(QUOTED_STRING181);

            		adaptor.AddChild(root_0, QUOTED_STRING181_tree);


            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "stringLiteral"

    public class identifier_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "identifier"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:694:1: identifier : ( IDENT | WEIRD_IDENT ) ;
    public HqlSqlWalker.identifier_return identifier() // throws RecognitionException [1]
    {   
        HqlSqlWalker.identifier_return retval = new HqlSqlWalker.identifier_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree set182 = null;

        CommonTree set182_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:695:2: ( ( IDENT | WEIRD_IDENT ) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:695:4: ( IDENT | WEIRD_IDENT )
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	_last = (CommonTree)input.LT(1);
            	set182 = (CommonTree)input.LT(1);
            	if ( input.LA(1) == WEIRD_IDENT || input.LA(1) == IDENT ) 
            	{
            	    input.Consume();

            	    set182_tree = (CommonTree)adaptor.DupNode(set182);

            	    adaptor.AddChild(root_0, set182_tree);

            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}


            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "identifier"

    public class addrExpr_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "addrExpr"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:728:1: addrExpr[ bool root ] : ( addrExprDot[root] | addrExprIndex[root] | addrExprIdent[root] );
    public HqlSqlWalker.addrExpr_return addrExpr(bool root) // throws RecognitionException [1]
    {   
        HqlSqlWalker.addrExpr_return retval = new HqlSqlWalker.addrExpr_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        HqlSqlWalker.addrExprDot_return addrExprDot183 = default(HqlSqlWalker.addrExprDot_return);

        HqlSqlWalker.addrExprIndex_return addrExprIndex184 = default(HqlSqlWalker.addrExprIndex_return);

        HqlSqlWalker.addrExprIdent_return addrExprIdent185 = default(HqlSqlWalker.addrExprIdent_return);



        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:729:2: ( addrExprDot[root] | addrExprIndex[root] | addrExprIdent[root] )
            int alt59 = 3;
            switch ( input.LA(1) ) 
            {
            case DOT:
            	{
                alt59 = 1;
                }
                break;
            case INDEX_OP:
            	{
                alt59 = 2;
                }
                break;
            case WEIRD_IDENT:
            case IDENT:
            	{
                alt59 = 3;
                }
                break;
            	default:
            	    NoViableAltException nvae_d59s0 =
            	        new NoViableAltException("", 59, 0, input);

            	    throw nvae_d59s0;
            }

            switch (alt59) 
            {
                case 1 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:729:4: addrExprDot[root]
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_addrExprDot_in_addrExpr2175);
                    	addrExprDot183 = addrExprDot(root);
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, addrExprDot183.Tree);

                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:730:4: addrExprIndex[root]
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_addrExprIndex_in_addrExpr2182);
                    	addrExprIndex184 = addrExprIndex(root);
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, addrExprIndex184.Tree);

                    }
                    break;
                case 3 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:731:4: addrExprIdent[root]
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_addrExprIdent_in_addrExpr2189);
                    	addrExprIdent185 = addrExprIdent(root);
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, addrExprIdent185.Tree);

                    }
                    break;

            }
            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "addrExpr"

    public class addrExprDot_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "addrExprDot"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:734:1: addrExprDot[ bool root ] : ^(d= DOT lhs= addrExprLhs rhs= propertyName ) -> ^( $d $lhs $rhs) ;
    public HqlSqlWalker.addrExprDot_return addrExprDot(bool root) // throws RecognitionException [1]
    {   
        HqlSqlWalker.addrExprDot_return retval = new HqlSqlWalker.addrExprDot_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree d = null;
        HqlSqlWalker.addrExprLhs_return lhs = default(HqlSqlWalker.addrExprLhs_return);

        HqlSqlWalker.propertyName_return rhs = default(HqlSqlWalker.propertyName_return);


        CommonTree d_tree=null;
        RewriteRuleNodeStream stream_DOT = new RewriteRuleNodeStream(adaptor,"token DOT");
        RewriteRuleSubtreeStream stream_propertyName = new RewriteRuleSubtreeStream(adaptor,"rule propertyName");
        RewriteRuleSubtreeStream stream_addrExprLhs = new RewriteRuleSubtreeStream(adaptor,"rule addrExprLhs");
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:739:2: ( ^(d= DOT lhs= addrExprLhs rhs= propertyName ) -> ^( $d $lhs $rhs) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:739:4: ^(d= DOT lhs= addrExprLhs rhs= propertyName )
            {
            	_last = (CommonTree)input.LT(1);
            	{
            	CommonTree _save_last_1 = _last;
            	CommonTree _first_1 = null;
            	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	d=(CommonTree)Match(input,DOT,FOLLOW_DOT_in_addrExprDot2213);  
            	stream_DOT.Add(d);



            	Match(input, Token.DOWN, null); 
            	_last = (CommonTree)input.LT(1);
            	PushFollow(FOLLOW_addrExprLhs_in_addrExprDot2217);
            	lhs = addrExprLhs();
            	state.followingStackPointer--;

            	stream_addrExprLhs.Add(lhs.Tree);
            	_last = (CommonTree)input.LT(1);
            	PushFollow(FOLLOW_propertyName_in_addrExprDot2221);
            	rhs = propertyName();
            	state.followingStackPointer--;

            	stream_propertyName.Add(rhs.Tree);

            	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	}



            	// AST REWRITE
            	// elements:          rhs, lhs, d
            	// token labels:      d
            	// rule labels:       lhs, retval, rhs
            	// token list labels: 
            	// rule list labels:  
            	retval.Tree = root_0;
            	RewriteRuleNodeStream stream_d = new RewriteRuleNodeStream(adaptor, "token d", d);
            	RewriteRuleSubtreeStream stream_lhs = new RewriteRuleSubtreeStream(adaptor, "token lhs", (lhs!=null ? lhs.Tree : null));
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));
            	RewriteRuleSubtreeStream stream_rhs = new RewriteRuleSubtreeStream(adaptor, "token rhs", (rhs!=null ? rhs.Tree : null));

            	root_0 = (CommonTree)adaptor.GetNilNode();
            	// 740:3: -> ^( $d $lhs $rhs)
            	{
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:740:6: ^( $d $lhs $rhs)
            	    {
            	    CommonTree root_1 = (CommonTree)adaptor.GetNilNode();
            	    root_1 = (CommonTree)adaptor.BecomeRoot(stream_d.NextNode(), root_1);

            	    adaptor.AddChild(root_1, stream_lhs.NextTree());
            	    adaptor.AddChild(root_1, stream_rhs.NextTree());

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;
            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);


            	lookupProperty(((CommonTree)retval.Tree),root,false);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "addrExprDot"

    public class addrExprIndex_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "addrExprIndex"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:743:1: addrExprIndex[ bool root ] : ^(i= INDEX_OP lhs2= addrExprLhs rhs2= expr ) -> ^( $i $lhs2 $rhs2) ;
    public HqlSqlWalker.addrExprIndex_return addrExprIndex(bool root) // throws RecognitionException [1]
    {   
        HqlSqlWalker.addrExprIndex_return retval = new HqlSqlWalker.addrExprIndex_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree i = null;
        HqlSqlWalker.addrExprLhs_return lhs2 = default(HqlSqlWalker.addrExprLhs_return);

        HqlSqlWalker.expr_return rhs2 = default(HqlSqlWalker.expr_return);


        CommonTree i_tree=null;
        RewriteRuleNodeStream stream_INDEX_OP = new RewriteRuleNodeStream(adaptor,"token INDEX_OP");
        RewriteRuleSubtreeStream stream_expr = new RewriteRuleSubtreeStream(adaptor,"rule expr");
        RewriteRuleSubtreeStream stream_addrExprLhs = new RewriteRuleSubtreeStream(adaptor,"rule addrExprLhs");
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:749:2: ( ^(i= INDEX_OP lhs2= addrExprLhs rhs2= expr ) -> ^( $i $lhs2 $rhs2) )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:749:4: ^(i= INDEX_OP lhs2= addrExprLhs rhs2= expr )
            {
            	_last = (CommonTree)input.LT(1);
            	{
            	CommonTree _save_last_1 = _last;
            	CommonTree _first_1 = null;
            	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	i=(CommonTree)Match(input,INDEX_OP,FOLLOW_INDEX_OP_in_addrExprIndex2260);  
            	stream_INDEX_OP.Add(i);



            	Match(input, Token.DOWN, null); 
            	_last = (CommonTree)input.LT(1);
            	PushFollow(FOLLOW_addrExprLhs_in_addrExprIndex2264);
            	lhs2 = addrExprLhs();
            	state.followingStackPointer--;

            	stream_addrExprLhs.Add(lhs2.Tree);
            	_last = (CommonTree)input.LT(1);
            	PushFollow(FOLLOW_expr_in_addrExprIndex2268);
            	rhs2 = expr();
            	state.followingStackPointer--;

            	stream_expr.Add(rhs2.Tree);

            	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	}



            	// AST REWRITE
            	// elements:          rhs2, i, lhs2
            	// token labels:      i
            	// rule labels:       rhs2, retval, lhs2
            	// token list labels: 
            	// rule list labels:  
            	retval.Tree = root_0;
            	RewriteRuleNodeStream stream_i = new RewriteRuleNodeStream(adaptor, "token i", i);
            	RewriteRuleSubtreeStream stream_rhs2 = new RewriteRuleSubtreeStream(adaptor, "token rhs2", (rhs2!=null ? rhs2.Tree : null));
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));
            	RewriteRuleSubtreeStream stream_lhs2 = new RewriteRuleSubtreeStream(adaptor, "token lhs2", (lhs2!=null ? lhs2.Tree : null));

            	root_0 = (CommonTree)adaptor.GetNilNode();
            	// 750:3: -> ^( $i $lhs2 $rhs2)
            	{
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:750:6: ^( $i $lhs2 $rhs2)
            	    {
            	    CommonTree root_1 = (CommonTree)adaptor.GetNilNode();
            	    root_1 = (CommonTree)adaptor.BecomeRoot(stream_i.NextNode(), root_1);

            	    adaptor.AddChild(root_1, stream_lhs2.NextTree());
            	    adaptor.AddChild(root_1, stream_rhs2.NextTree());

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;
            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);


            	processIndex(((CommonTree)retval.Tree));

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "addrExprIndex"

    public class addrExprIdent_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "addrExprIdent"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:753:1: addrExprIdent[ bool root ] : p= identifier -> {isNonQualifiedPropertyRef($p.tree)}? ^() -> ^() ;
    public HqlSqlWalker.addrExprIdent_return addrExprIdent(bool root) // throws RecognitionException [1]
    {   
        HqlSqlWalker.addrExprIdent_return retval = new HqlSqlWalker.addrExprIdent_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        HqlSqlWalker.identifier_return p = default(HqlSqlWalker.identifier_return);


        RewriteRuleSubtreeStream stream_identifier = new RewriteRuleSubtreeStream(adaptor,"rule identifier");
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:754:2: (p= identifier -> {isNonQualifiedPropertyRef($p.tree)}? ^() -> ^() )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:754:4: p= identifier
            {
            	_last = (CommonTree)input.LT(1);
            	PushFollow(FOLLOW_identifier_in_addrExprIdent2300);
            	p = identifier();
            	state.followingStackPointer--;

            	stream_identifier.Add(p.Tree);


            	// AST REWRITE
            	// elements:          
            	// token labels:      
            	// rule labels:       retval
            	// token list labels: 
            	// rule list labels:  
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));

            	root_0 = (CommonTree)adaptor.GetNilNode();
            	// 755:2: -> {isNonQualifiedPropertyRef($p.tree)}? ^()
            	if (isNonQualifiedPropertyRef(((p != null) ? ((CommonTree)p.Tree) : null)))
            	{
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:755:43: ^()
            	    {
            	    CommonTree root_1 = (CommonTree)adaptor.GetNilNode();
            	    root_1 = (CommonTree)adaptor.BecomeRoot(lookupNonQualifiedProperty(((p != null) ? ((CommonTree)p.Tree) : null)), root_1);

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}
            	else // 756:2: -> ^()
            	{
            	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:756:5: ^()
            	    {
            	    CommonTree root_1 = (CommonTree)adaptor.GetNilNode();
            	    root_1 = (CommonTree)adaptor.BecomeRoot(resolve(((p != null) ? ((CommonTree)p.Tree) : null)), root_1);

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;
            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "addrExprIdent"

    public class addrExprLhs_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "addrExprLhs"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:759:1: addrExprLhs : addrExpr[ false ] ;
    public HqlSqlWalker.addrExprLhs_return addrExprLhs() // throws RecognitionException [1]
    {   
        HqlSqlWalker.addrExprLhs_return retval = new HqlSqlWalker.addrExprLhs_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        HqlSqlWalker.addrExpr_return addrExpr186 = default(HqlSqlWalker.addrExpr_return);



        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:760:2: ( addrExpr[ false ] )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:760:4: addrExpr[ false ]
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	_last = (CommonTree)input.LT(1);
            	PushFollow(FOLLOW_addrExpr_in_addrExprLhs2328);
            	addrExpr186 = addrExpr(false);
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, addrExpr186.Tree);

            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "addrExprLhs"

    public class propertyName_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "propertyName"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:763:1: propertyName : ( identifier | CLASS | ELEMENTS | INDICES );
    public HqlSqlWalker.propertyName_return propertyName() // throws RecognitionException [1]
    {   
        HqlSqlWalker.propertyName_return retval = new HqlSqlWalker.propertyName_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree CLASS188 = null;
        CommonTree ELEMENTS189 = null;
        CommonTree INDICES190 = null;
        HqlSqlWalker.identifier_return identifier187 = default(HqlSqlWalker.identifier_return);


        CommonTree CLASS188_tree=null;
        CommonTree ELEMENTS189_tree=null;
        CommonTree INDICES190_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:764:2: ( identifier | CLASS | ELEMENTS | INDICES )
            int alt60 = 4;
            switch ( input.LA(1) ) 
            {
            case WEIRD_IDENT:
            case IDENT:
            	{
                alt60 = 1;
                }
                break;
            case CLASS:
            	{
                alt60 = 2;
                }
                break;
            case ELEMENTS:
            	{
                alt60 = 3;
                }
                break;
            case INDICES:
            	{
                alt60 = 4;
                }
                break;
            	default:
            	    NoViableAltException nvae_d60s0 =
            	        new NoViableAltException("", 60, 0, input);

            	    throw nvae_d60s0;
            }

            switch (alt60) 
            {
                case 1 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:764:4: identifier
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_identifier_in_propertyName2341);
                    	identifier187 = identifier();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, identifier187.Tree);

                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:765:4: CLASS
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	CLASS188=(CommonTree)Match(input,CLASS,FOLLOW_CLASS_in_propertyName2346); 
                    		CLASS188_tree = (CommonTree)adaptor.DupNode(CLASS188);

                    		adaptor.AddChild(root_0, CLASS188_tree);


                    }
                    break;
                case 3 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:766:4: ELEMENTS
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	ELEMENTS189=(CommonTree)Match(input,ELEMENTS,FOLLOW_ELEMENTS_in_propertyName2351); 
                    		ELEMENTS189_tree = (CommonTree)adaptor.DupNode(ELEMENTS189);

                    		adaptor.AddChild(root_0, ELEMENTS189_tree);


                    }
                    break;
                case 4 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:767:4: INDICES
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	INDICES190=(CommonTree)Match(input,INDICES,FOLLOW_INDICES_in_propertyName2356); 
                    		INDICES190_tree = (CommonTree)adaptor.DupNode(INDICES190);

                    		adaptor.AddChild(root_0, INDICES190_tree);


                    }
                    break;

            }
            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "propertyName"

    public class propertyRef_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "propertyRef"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:794:1: propertyRef : ( ^(d= DOT lhs= propertyRefLhs rhs= propertyName ) -> ^( $d $lhs $rhs) | p= identifier );
    public HqlSqlWalker.propertyRef_return propertyRef() // throws RecognitionException [1]
    {   
        HqlSqlWalker.propertyRef_return retval = new HqlSqlWalker.propertyRef_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree d = null;
        HqlSqlWalker.propertyRefLhs_return lhs = default(HqlSqlWalker.propertyRefLhs_return);

        HqlSqlWalker.propertyName_return rhs = default(HqlSqlWalker.propertyName_return);

        HqlSqlWalker.identifier_return p = default(HqlSqlWalker.identifier_return);


        CommonTree d_tree=null;
        RewriteRuleNodeStream stream_DOT = new RewriteRuleNodeStream(adaptor,"token DOT");
        RewriteRuleSubtreeStream stream_propertyName = new RewriteRuleSubtreeStream(adaptor,"rule propertyName");
        RewriteRuleSubtreeStream stream_propertyRefLhs = new RewriteRuleSubtreeStream(adaptor,"rule propertyRefLhs");
        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:795:2: ( ^(d= DOT lhs= propertyRefLhs rhs= propertyName ) -> ^( $d $lhs $rhs) | p= identifier )
            int alt61 = 2;
            int LA61_0 = input.LA(1);

            if ( (LA61_0 == DOT) )
            {
                alt61 = 1;
            }
            else if ( (LA61_0 == WEIRD_IDENT || LA61_0 == IDENT) )
            {
                alt61 = 2;
            }
            else 
            {
                NoViableAltException nvae_d61s0 =
                    new NoViableAltException("", 61, 0, input);

                throw nvae_d61s0;
            }
            switch (alt61) 
            {
                case 1 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:795:4: ^(d= DOT lhs= propertyRefLhs rhs= propertyName )
                    {
                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	d=(CommonTree)Match(input,DOT,FOLLOW_DOT_in_propertyRef2373);  
                    	stream_DOT.Add(d);



                    	Match(input, Token.DOWN, null); 
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_propertyRefLhs_in_propertyRef2377);
                    	lhs = propertyRefLhs();
                    	state.followingStackPointer--;

                    	stream_propertyRefLhs.Add(lhs.Tree);
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_propertyName_in_propertyRef2381);
                    	rhs = propertyName();
                    	state.followingStackPointer--;

                    	stream_propertyName.Add(rhs.Tree);

                    	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
                    	}



                    	// AST REWRITE
                    	// elements:          rhs, lhs, d
                    	// token labels:      d
                    	// rule labels:       lhs, retval, rhs
                    	// token list labels: 
                    	// rule list labels:  
                    	retval.Tree = root_0;
                    	RewriteRuleNodeStream stream_d = new RewriteRuleNodeStream(adaptor, "token d", d);
                    	RewriteRuleSubtreeStream stream_lhs = new RewriteRuleSubtreeStream(adaptor, "token lhs", (lhs!=null ? lhs.Tree : null));
                    	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "token retval", (retval!=null ? retval.Tree : null));
                    	RewriteRuleSubtreeStream stream_rhs = new RewriteRuleSubtreeStream(adaptor, "token rhs", (rhs!=null ? rhs.Tree : null));

                    	root_0 = (CommonTree)adaptor.GetNilNode();
                    	// 796:3: -> ^( $d $lhs $rhs)
                    	{
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:796:6: ^( $d $lhs $rhs)
                    	    {
                    	    CommonTree root_1 = (CommonTree)adaptor.GetNilNode();
                    	    root_1 = (CommonTree)adaptor.BecomeRoot(stream_d.NextNode(), root_1);

                    	    adaptor.AddChild(root_1, stream_lhs.NextTree());
                    	    adaptor.AddChild(root_1, stream_rhs.NextTree());

                    	    adaptor.AddChild(root_0, root_1);
                    	    }
                    	    adaptor.AddChild(root_0, 
                    	    		// This gives lookupProperty() a chance to transform the tree to process collection properties (.elements, etc).
                    	    		lookupProperty(((CommonTree)retval.Tree),false,true)
                    	    	);

                    	}

                    	retval.Tree = root_0;
                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:802:2: p= identifier
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_identifier_in_propertyRef2410);
                    	p = identifier();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, p.Tree);

                    			// In many cases, things other than property-refs are recognized
                    			// by this propertyRef rule.  Some of those I have seen:
                    			//  1) select-clause from-aliases
                    			//  2) sql-functions
                    			if ( isNonQualifiedPropertyRef(((p != null) ? ((CommonTree)p.Tree) : null)) ) {
                    				retval.Tree =  lookupNonQualifiedProperty(((p != null) ? ((CommonTree)p.Tree) : null));
                    			}
                    			else {
                    				resolve(((p != null) ? ((CommonTree)p.Tree) : null));
                    				retval.Tree =  ((p != null) ? ((CommonTree)p.Tree) : null);
                    			}
                    		

                    }
                    break;

            }
            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "propertyRef"

    public class propertyRefLhs_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "propertyRefLhs"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:817:1: propertyRefLhs : propertyRef ;
    public HqlSqlWalker.propertyRefLhs_return propertyRefLhs() // throws RecognitionException [1]
    {   
        HqlSqlWalker.propertyRefLhs_return retval = new HqlSqlWalker.propertyRefLhs_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        HqlSqlWalker.propertyRef_return propertyRef191 = default(HqlSqlWalker.propertyRef_return);



        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:818:2: ( propertyRef )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:818:4: propertyRef
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	_last = (CommonTree)input.LT(1);
            	PushFollow(FOLLOW_propertyRef_in_propertyRefLhs2423);
            	propertyRef191 = propertyRef();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, propertyRef191.Tree);

            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "propertyRefLhs"

    public class aliasRef_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "aliasRef"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:830:1: aliasRef : i= identifier ;
    public HqlSqlWalker.aliasRef_return aliasRef() // throws RecognitionException [1]
    {   
        HqlSqlWalker.aliasRef_return retval = new HqlSqlWalker.aliasRef_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        HqlSqlWalker.identifier_return i = default(HqlSqlWalker.identifier_return);



        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:835:2: (i= identifier )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:835:4: i= identifier
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	_last = (CommonTree)input.LT(1);
            	PushFollow(FOLLOW_identifier_in_aliasRef2446);
            	i = identifier();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, i.Tree);

            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);


            		lookupAlias(((CommonTree)retval.Tree));
            	
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "aliasRef"

    public class parameter_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "parameter"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:864:1: parameter : ( ^(c= COLON a= identifier ) | ^(p= PARAM (n= NUM_INT )? ) );
    public HqlSqlWalker.parameter_return parameter() // throws RecognitionException [1]
    {   
        HqlSqlWalker.parameter_return retval = new HqlSqlWalker.parameter_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree c = null;
        CommonTree p = null;
        CommonTree n = null;
        HqlSqlWalker.identifier_return a = default(HqlSqlWalker.identifier_return);


        CommonTree c_tree=null;
        CommonTree p_tree=null;
        CommonTree n_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:865:2: ( ^(c= COLON a= identifier ) | ^(p= PARAM (n= NUM_INT )? ) )
            int alt63 = 2;
            int LA63_0 = input.LA(1);

            if ( (LA63_0 == COLON) )
            {
                alt63 = 1;
            }
            else if ( (LA63_0 == PARAM) )
            {
                alt63 = 2;
            }
            else 
            {
                NoViableAltException nvae_d63s0 =
                    new NoViableAltException("", 63, 0, input);

                throw nvae_d63s0;
            }
            switch (alt63) 
            {
                case 1 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:865:4: ^(c= COLON a= identifier )
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	c=(CommonTree)Match(input,COLON,FOLLOW_COLON_in_parameter2467); 
                    		c_tree = (CommonTree)adaptor.DupNode(c);

                    		root_1 = (CommonTree)adaptor.BecomeRoot(c_tree, root_1);



                    	Match(input, Token.DOWN, null); 
                    	_last = (CommonTree)input.LT(1);
                    	PushFollow(FOLLOW_identifier_in_parameter2471);
                    	a = identifier();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_1, a.Tree);

                    	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
                    	}


                    				// Create a NAMED_PARAM node instead of (COLON IDENT).
                    				retval.Tree =  generateNamedParameter( c, a );
                    	//			#parameter = #([NAMED_PARAM,a.getText()]);
                    	//			namedParameter(#parameter);
                    			

                    }
                    break;
                case 2 :
                    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:871:4: ^(p= PARAM (n= NUM_INT )? )
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	p=(CommonTree)Match(input,PARAM,FOLLOW_PARAM_in_parameter2482); 
                    		p_tree = (CommonTree)adaptor.DupNode(p);

                    		root_1 = (CommonTree)adaptor.BecomeRoot(p_tree, root_1);



                    	if ( input.LA(1) == Token.DOWN )
                    	{
                    	    Match(input, Token.DOWN, null); 
                    	    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:871:14: (n= NUM_INT )?
                    	    int alt62 = 2;
                    	    int LA62_0 = input.LA(1);

                    	    if ( (LA62_0 == NUM_INT) )
                    	    {
                    	        alt62 = 1;
                    	    }
                    	    switch (alt62) 
                    	    {
                    	        case 1 :
                    	            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:871:15: n= NUM_INT
                    	            {
                    	            	_last = (CommonTree)input.LT(1);
                    	            	n=(CommonTree)Match(input,NUM_INT,FOLLOW_NUM_INT_in_parameter2487); 
                    	            		n_tree = (CommonTree)adaptor.DupNode(n);

                    	            		adaptor.AddChild(root_1, n_tree);


                    	            }
                    	            break;

                    	    }


                    	    Match(input, Token.UP, null); 
                    	}adaptor.AddChild(root_0, root_1);_last = _save_last_1;
                    	}


                    				if ( n != null ) {
                    					// An ejb3-style "positional parameter", which we handle internally as a named-param
                    					retval.Tree =  generateNamedParameter( p, n );
                    	//				#parameter = #([NAMED_PARAM,n.getText()]);
                    	//				namedParameter(#parameter);
                    				}
                    				else {
                    					retval.Tree =  generatePositionalParameter( p );
                    	//				#parameter = #([PARAM,"?"]);
                    	//				positionalParameter(#parameter);
                    				}
                    			

                    }
                    break;

            }
            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "parameter"

    public class numericInteger_return : TreeRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "numericInteger"
    // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:886:1: numericInteger : NUM_INT ;
    public HqlSqlWalker.numericInteger_return numericInteger() // throws RecognitionException [1]
    {   
        HqlSqlWalker.numericInteger_return retval = new HqlSqlWalker.numericInteger_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree NUM_INT192 = null;

        CommonTree NUM_INT192_tree=null;

        try 
    	{
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:887:2: ( NUM_INT )
            // /Users/Steve/Projects/uNhAddins/Trunk/ANTLR-HQL/ANTLR-HQL/HqlSqlWalker.g:887:4: NUM_INT
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	_last = (CommonTree)input.LT(1);
            	NUM_INT192=(CommonTree)Match(input,NUM_INT,FOLLOW_NUM_INT_in_numericInteger2503); 
            		NUM_INT192_tree = (CommonTree)adaptor.DupNode(NUM_INT192);

            		adaptor.AddChild(root_0, NUM_INT192_tree);


            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "numericInteger"

    // Delegated rules


	private void InitializeCyclicDFAs()
	{
	}

 

    public static readonly BitSet FOLLOW_selectStatement_in_statement168 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_updateStatement_in_statement172 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_deleteStatement_in_statement176 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_insertStatement_in_statement180 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_query_in_selectStatement191 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_UPDATE_in_updateStatement217 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_VERSIONED_in_updateStatement224 = new BitSet(new ulong[]{0x0000000000400000UL});
    public static readonly BitSet FOLLOW_fromClause_in_updateStatement230 = new BitSet(new ulong[]{0x0000400000000000UL});
    public static readonly BitSet FOLLOW_setClause_in_updateStatement234 = new BitSet(new ulong[]{0x0020000000000008UL});
    public static readonly BitSet FOLLOW_whereClause_in_updateStatement239 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_DELETE_in_deleteStatement284 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_fromClause_in_deleteStatement288 = new BitSet(new ulong[]{0x0020000000000008UL});
    public static readonly BitSet FOLLOW_whereClause_in_deleteStatement291 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_INSERT_in_insertStatement323 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_intoClause_in_insertStatement327 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000100000UL});
    public static readonly BitSet FOLLOW_query_in_insertStatement329 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_INTO_in_intoClause349 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_path_in_intoClause356 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000200000UL});
    public static readonly BitSet FOLLOW_insertablePropertySpec_in_intoClause361 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_RANGE_in_insertablePropertySpec378 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_IDENT_in_insertablePropertySpec381 = new BitSet(new ulong[]{0x0000000000000008UL,0x0040000000000000UL});
    public static readonly BitSet FOLLOW_SET_in_setClause398 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_assignment_in_setClause403 = new BitSet(new ulong[]{0x0000000000000008UL,0x0000000800000000UL});
    public static readonly BitSet FOLLOW_EQ_in_assignment432 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_propertyRef_in_assignment437 = new BitSet(new ulong[]{0x0082008000109000UL,0x0059E003ED109120UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_newValue_in_assignment443 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_expr_in_newValue459 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_query_in_newValue463 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_QUERY_in_query487 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_SELECT_FROM_in_query499 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_fromClause_in_query507 = new BitSet(new ulong[]{0x0000200000000008UL});
    public static readonly BitSet FOLLOW_selectClause_in_query516 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_whereClause_in_query531 = new BitSet(new ulong[]{0x0000020001000008UL});
    public static readonly BitSet FOLLOW_groupClause_in_query541 = new BitSet(new ulong[]{0x0000020000000008UL});
    public static readonly BitSet FOLLOW_orderClause_in_query551 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_ORDER_in_orderClause596 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_orderExprs_in_orderClause600 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_expr_in_orderExprs612 = new BitSet(new ulong[]{0x008200800010D102UL,0x0059E003ED009120UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_set_in_orderExprs614 = new BitSet(new ulong[]{0x0082008000109002UL,0x0059E003ED009120UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_orderExprs_in_orderExprs626 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GROUP_in_groupClause640 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_expr_in_groupClause645 = new BitSet(new ulong[]{0x0082008002109008UL,0x0059E003ED009120UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_HAVING_in_groupClause652 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_logicalExpr_in_groupClause654 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_SELECT_in_selectClause675 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_DISTINCT_in_selectClause682 = new BitSet(new ulong[]{0x0082008008129090UL,0x0059E003ED1091A4UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_selectExprList_in_selectClause688 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_selectExpr_in_selectExprList722 = new BitSet(new ulong[]{0x0082008008129092UL,0x0059E003ED1091A4UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_aliasedSelectExpr_in_selectExprList726 = new BitSet(new ulong[]{0x0082008008129092UL,0x0059E003ED1091A4UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_AS_in_aliasedSelectExpr752 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_selectExpr_in_aliasedSelectExpr756 = new BitSet(new ulong[]{0x0000000000008000UL,0x0040000008001000UL});
    public static readonly BitSet FOLLOW_identifier_in_aliasedSelectExpr760 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_propertyRef_in_selectExpr777 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ALL_in_selectExpr789 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_aliasRef_in_selectExpr793 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_OBJECT_in_selectExpr805 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_aliasRef_in_selectExpr809 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_constructor_in_selectExpr820 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_functionCall_in_selectExpr831 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_count_in_selectExpr836 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_collectionFunction_in_selectExpr841 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_literal_in_selectExpr849 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_arithmeticExpr_in_selectExpr854 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_query_in_selectExpr859 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_COUNT_in_count871 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_set_in_count873 = new BitSet(new ulong[]{0x0082008008129000UL,0x0059E003ED409120UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_aggregateExpr_in_count886 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_ROW_STAR_in_count890 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_CONSTRUCTOR_in_constructor908 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_path_in_constructor910 = new BitSet(new ulong[]{0x0082008008129098UL,0x0059E003ED1091A4UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_selectExpr_in_constructor914 = new BitSet(new ulong[]{0x0082008008129098UL,0x0059E003ED1091A4UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_aliasedSelectExpr_in_constructor918 = new BitSet(new ulong[]{0x0082008008129098UL,0x0059E003ED1091A4UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_expr_in_aggregateExpr934 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_collectionFunction_in_aggregateExpr940 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FROM_in_fromClause962 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_fromElementList_in_fromClause966 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_fromElement_in_fromElementList984 = new BitSet(new ulong[]{0x0000000100000002UL,0x0000000000200400UL});
    public static readonly BitSet FOLLOW_RANGE_in_fromElement1006 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_path_in_fromElement1010 = new BitSet(new ulong[]{0x0000000000200008UL,0x0000000000000040UL});
    public static readonly BitSet FOLLOW_ALIAS_in_fromElement1015 = new BitSet(new ulong[]{0x0000000000200008UL});
    public static readonly BitSet FOLLOW_FETCH_in_fromElement1022 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_joinElement_in_fromElement1042 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FILTER_ENTITY_in_fromElement1061 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000040UL});
    public static readonly BitSet FOLLOW_ALIAS_in_fromElement1065 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_JOIN_in_joinElement1096 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_joinType_in_joinElement1101 = new BitSet(new ulong[]{0x0000000000208000UL,0x0040000008001000UL});
    public static readonly BitSet FOLLOW_FETCH_in_joinElement1111 = new BitSet(new ulong[]{0x0000000000008000UL,0x0040000008001000UL});
    public static readonly BitSet FOLLOW_propertyRef_in_joinElement1117 = new BitSet(new ulong[]{0x2000000000200008UL,0x0000000000000040UL});
    public static readonly BitSet FOLLOW_ALIAS_in_joinElement1122 = new BitSet(new ulong[]{0x2000000000200008UL});
    public static readonly BitSet FOLLOW_FETCH_in_joinElement1129 = new BitSet(new ulong[]{0x2000000000000008UL});
    public static readonly BitSet FOLLOW_WITH_in_joinElement1136 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_LEFT_in_joinType1168 = new BitSet(new ulong[]{0x0000040000000002UL});
    public static readonly BitSet FOLLOW_RIGHT_in_joinType1174 = new BitSet(new ulong[]{0x0000040000000002UL});
    public static readonly BitSet FOLLOW_OUTER_in_joinType1180 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FULL_in_joinType1191 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_INNER_in_joinType1198 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_identifier_in_path1220 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DOT_in_path1228 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_path_in_path1232 = new BitSet(new ulong[]{0x0000000000008000UL,0x0040000008001000UL});
    public static readonly BitSet FOLLOW_identifier_in_path1236 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_path_in_pathAsIdent1257 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_WITH_in_withClause1301 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_logicalExpr_in_withClause1307 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_WHERE_in_whereClause1337 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_logicalExpr_in_whereClause1343 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_AND_in_logicalExpr1369 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_logicalExpr_in_logicalExpr1371 = new BitSet(new ulong[]{0x0000014404080440UL,0x00000F4800076000UL});
    public static readonly BitSet FOLLOW_logicalExpr_in_logicalExpr1373 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_OR_in_logicalExpr1380 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_logicalExpr_in_logicalExpr1382 = new BitSet(new ulong[]{0x0000014404080440UL,0x00000F4800076000UL});
    public static readonly BitSet FOLLOW_logicalExpr_in_logicalExpr1384 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_NOT_in_logicalExpr1391 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_logicalExpr_in_logicalExpr1393 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_comparisonExpr_in_logicalExpr1399 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ_in_comparisonExpr1423 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_exprOrSubquery_in_comparisonExpr1425 = new BitSet(new ulong[]{0x0082808000109030UL,0x0059E003ED109120UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_exprOrSubquery_in_comparisonExpr1427 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_NE_in_comparisonExpr1434 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_exprOrSubquery_in_comparisonExpr1436 = new BitSet(new ulong[]{0x0082808000109030UL,0x0059E003ED109120UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_exprOrSubquery_in_comparisonExpr1438 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_LT_in_comparisonExpr1445 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_exprOrSubquery_in_comparisonExpr1447 = new BitSet(new ulong[]{0x0082808000109030UL,0x0059E003ED109120UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_exprOrSubquery_in_comparisonExpr1449 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_GT_in_comparisonExpr1456 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_exprOrSubquery_in_comparisonExpr1458 = new BitSet(new ulong[]{0x0082808000109030UL,0x0059E003ED109120UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_exprOrSubquery_in_comparisonExpr1460 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_LE_in_comparisonExpr1467 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_exprOrSubquery_in_comparisonExpr1469 = new BitSet(new ulong[]{0x0082808000109030UL,0x0059E003ED109120UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_exprOrSubquery_in_comparisonExpr1471 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_GE_in_comparisonExpr1478 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_exprOrSubquery_in_comparisonExpr1480 = new BitSet(new ulong[]{0x0082808000109030UL,0x0059E003ED109120UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_exprOrSubquery_in_comparisonExpr1482 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_LIKE_in_comparisonExpr1489 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_exprOrSubquery_in_comparisonExpr1491 = new BitSet(new ulong[]{0x0082008000109000UL,0x0059E003ED009120UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_expr_in_comparisonExpr1493 = new BitSet(new ulong[]{0x0000000000040008UL});
    public static readonly BitSet FOLLOW_ESCAPE_in_comparisonExpr1498 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_expr_in_comparisonExpr1500 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_NOT_LIKE_in_comparisonExpr1512 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_exprOrSubquery_in_comparisonExpr1514 = new BitSet(new ulong[]{0x0082008000109000UL,0x0059E003ED009120UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_expr_in_comparisonExpr1516 = new BitSet(new ulong[]{0x0000000000040008UL});
    public static readonly BitSet FOLLOW_ESCAPE_in_comparisonExpr1521 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_expr_in_comparisonExpr1523 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_BETWEEN_in_comparisonExpr1535 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_exprOrSubquery_in_comparisonExpr1537 = new BitSet(new ulong[]{0x0082808000109030UL,0x0059E003ED109120UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_exprOrSubquery_in_comparisonExpr1539 = new BitSet(new ulong[]{0x0082808000109030UL,0x0059E003ED109120UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_exprOrSubquery_in_comparisonExpr1541 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_NOT_BETWEEN_in_comparisonExpr1548 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_exprOrSubquery_in_comparisonExpr1550 = new BitSet(new ulong[]{0x0082808000109030UL,0x0059E003ED109120UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_exprOrSubquery_in_comparisonExpr1552 = new BitSet(new ulong[]{0x0082808000109030UL,0x0059E003ED109120UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_exprOrSubquery_in_comparisonExpr1554 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_IN_in_comparisonExpr1561 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_exprOrSubquery_in_comparisonExpr1563 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_inRhs_in_comparisonExpr1565 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_NOT_IN_in_comparisonExpr1573 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_exprOrSubquery_in_comparisonExpr1575 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_inRhs_in_comparisonExpr1577 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_IS_NULL_in_comparisonExpr1585 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_exprOrSubquery_in_comparisonExpr1587 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_IS_NOT_NULL_in_comparisonExpr1594 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_exprOrSubquery_in_comparisonExpr1596 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_EXISTS_in_comparisonExpr1605 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_expr_in_comparisonExpr1609 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_collectionFunctionOrSubselect_in_comparisonExpr1613 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_IN_LIST_in_inRhs1638 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_collectionFunctionOrSubselect_in_inRhs1642 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_expr_in_inRhs1646 = new BitSet(new ulong[]{0x0082008000109008UL,0x0059E003ED009120UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_expr_in_exprOrSubquery1662 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_query_in_exprOrSubquery1667 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ANY_in_exprOrSubquery1673 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_collectionFunctionOrSubselect_in_exprOrSubquery1675 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_ALL_in_exprOrSubquery1682 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_collectionFunctionOrSubselect_in_exprOrSubquery1684 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_SOME_in_exprOrSubquery1691 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_collectionFunctionOrSubselect_in_exprOrSubquery1693 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_collectionFunction_in_collectionFunctionOrSubselect1706 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_query_in_collectionFunctionOrSubselect1711 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_addrExpr_in_expr1727 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_VECTOR_EXPR_in_expr1739 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_expr_in_expr1742 = new BitSet(new ulong[]{0x0082008000109008UL,0x0059E003ED009120UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_constant_in_expr1751 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_arithmeticExpr_in_expr1756 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_functionCall_in_expr1761 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_parameter_in_expr1773 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_count_in_expr1778 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_PLUS_in_arithmeticExpr1808 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_expr_in_arithmeticExpr1810 = new BitSet(new ulong[]{0x0082008000109000UL,0x0059E003ED009120UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_expr_in_arithmeticExpr1812 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_MINUS_in_arithmeticExpr1819 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_expr_in_arithmeticExpr1821 = new BitSet(new ulong[]{0x0082008000109000UL,0x0059E003ED009120UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_expr_in_arithmeticExpr1823 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_DIV_in_arithmeticExpr1830 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_expr_in_arithmeticExpr1832 = new BitSet(new ulong[]{0x0082008000109000UL,0x0059E003ED009120UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_expr_in_arithmeticExpr1834 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_STAR_in_arithmeticExpr1841 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_expr_in_arithmeticExpr1843 = new BitSet(new ulong[]{0x0082008000109000UL,0x0059E003ED009120UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_expr_in_arithmeticExpr1845 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_UNARY_MINUS_in_arithmeticExpr1853 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_expr_in_arithmeticExpr1855 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_caseExpr_in_arithmeticExpr1863 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_CASE_in_caseExpr1875 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_WHEN_in_caseExpr1881 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_logicalExpr_in_caseExpr1883 = new BitSet(new ulong[]{0x0082008000109000UL,0x0059E003ED009120UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_expr_in_caseExpr1885 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_ELSE_in_caseExpr1892 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_expr_in_caseExpr1894 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_CASE2_in_caseExpr1906 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_expr_in_caseExpr1910 = new BitSet(new ulong[]{0x0800000000000000UL});
    public static readonly BitSet FOLLOW_WHEN_in_caseExpr1914 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_expr_in_caseExpr1916 = new BitSet(new ulong[]{0x0082008000109000UL,0x0059E003ED009120UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_expr_in_caseExpr1918 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_ELSE_in_caseExpr1925 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_expr_in_caseExpr1927 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_ELEMENTS_in_collectionFunction1951 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_propertyRef_in_collectionFunction1957 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_INDICES_in_collectionFunction1976 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_propertyRef_in_collectionFunction1982 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_METHOD_CALL_in_functionCall2007 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_pathAsIdent_in_functionCall2012 = new BitSet(new ulong[]{0x0000000000000008UL,0x0000000000000200UL});
    public static readonly BitSet FOLLOW_EXPR_LIST_in_functionCall2017 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_expr_in_functionCall2020 = new BitSet(new ulong[]{0x0082008000109008UL,0x0059E003ED009120UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_AGGREGATE_in_functionCall2041 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_aggregateExpr_in_functionCall2043 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_literal_in_constant2058 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NULL_in_constant2063 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_TRUE_in_constant2068 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FALSE_in_constant2076 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_JAVA_CONSTANT_in_constant2083 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_numericLiteral_in_literal2096 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_stringLiteral_in_literal2101 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_numericLiteral0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_QUOTED_STRING_in_stringLiteral2143 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_identifier2154 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_addrExprDot_in_addrExpr2175 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_addrExprIndex_in_addrExpr2182 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_addrExprIdent_in_addrExpr2189 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DOT_in_addrExprDot2213 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_addrExprLhs_in_addrExprDot2217 = new BitSet(new ulong[]{0x0000000008028800UL,0x0040000008001000UL});
    public static readonly BitSet FOLLOW_propertyName_in_addrExprDot2221 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_INDEX_OP_in_addrExprIndex2260 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_addrExprLhs_in_addrExprIndex2264 = new BitSet(new ulong[]{0x0082008000109000UL,0x0059E003ED009120UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_expr_in_addrExprIndex2268 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_identifier_in_addrExprIdent2300 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_addrExpr_in_addrExprLhs2328 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_identifier_in_propertyName2341 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_CLASS_in_propertyName2346 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ELEMENTS_in_propertyName2351 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_INDICES_in_propertyName2356 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DOT_in_propertyRef2373 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_propertyRefLhs_in_propertyRef2377 = new BitSet(new ulong[]{0x0000000008028800UL,0x0040000008001000UL});
    public static readonly BitSet FOLLOW_propertyName_in_propertyRef2381 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_identifier_in_propertyRef2410 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_propertyRef_in_propertyRefLhs2423 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_identifier_in_aliasRef2446 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_COLON_in_parameter2467 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_identifier_in_parameter2471 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_PARAM_in_parameter2482 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_NUM_INT_in_parameter2487 = new BitSet(new ulong[]{0x0000000000000008UL});
    public static readonly BitSet FOLLOW_NUM_INT_in_numericInteger2503 = new BitSet(new ulong[]{0x0000000000000002UL});

}
}