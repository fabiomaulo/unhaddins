using System;

// C# Translation of GoldParser, by Marcus Klimstra <klimstra@home.nl>.
// Based on GOLDParser by Devin Cook <http://www.devincook.com/goldparser>.
namespace GoldParser
{
	/// The result of the Parser.Parse method.
	public enum ParseMessage
	{
		/// This message is returned each time a token is read.
		TokenRead,
		
		/// When the engine is able to reduce a rule, this message is returned. 
		/// The rule that was reduced is set in the <c>Parser.Reduction</c> property. 
		/// The tokens that are reduced and correspond to the rule's definition 
		/// can be acquired using the <c>GetToken</c> or <c>GetTokens</c> methods.
		Reduction,
		
		/// The engine will returns this message when the source text has been 
		/// accepted as both complete and correct. In other words, the source 
		/// text was successfully analyzed.
		Accept,
		
		/// The tokenizer will generate this message when it is unable to 
		/// recognize a series of characters as a valid token. To recover, pop the 
		/// invalid token from the input queue using <c>Parser.PopInputToken</c>.
		LexicalError,
		
		/// Often the parser will read a token that is not expected in the 
		/// grammar. When this happens, you can acquire the expected tokens using
		/// the <c>GetToken</c> or <c>GetTokens</c> methods. To recover, push 
		/// one of the expected tokens onto the input queue.
		SyntaxError,
		
		/// The parser reached the end of the file while reading a comment. 
		/// This is caused when the source text contains a "run-away" comment, 
		/// or in other words, a block comment that lacks the end-delimiter.
		CommentError,
		
		/// Something is very wrong when this message is returned.
		InternalError
	};

	/// Respresents the type of a symbol.
	public enum SymbolType
	{		
		/// A normal non-terminal.
		NonTerminal			= 0,
		
		/// A normal terminal.
		Terminal			= 1,
		
		/// This Whitespace symbol is a special terminal that is automatically 
		/// ignored by the parsing engine. Any text accepted as whitespace is 
		/// considered to be inconsequential and "meaningless".
		Whitespace			= 2,
		
		/// The End symbol is generated when the tokenizer reaches the end of 
		/// the source text.
		End					= 3,
		
		/// This type of symbol designates the start of a block comment.
		CommentStart		= 4,
		
		/// This type of symbol designates the end of a block comment.
		CommentEnd			= 5,
		
		/// When the engine reads a token that is recognized as a line comment, 
		/// the remaining characters on the line are automatically ignored by 
		/// the parser.
		CommentLine			= 6,
		
		/// The Error symbol is a general-purpose means of representing characters 
		/// that were not recognized by the tokenizer. In other words, when the 
		/// tokenizer reads a series of characters that is not accepted by the DFA 
		/// engine, a token of this type is created.
		Error				= 7
	};
	
	/// constants associated with what action should be performed 
	internal enum Action
	{		
		///
		Shift				= 1,
		
		///
		Reduce				= 2,
		
		///
		Goto				= 3,
		
		///
		Accept				= 4,
		
		///
		Error				= 5
	};
	
	/// Represents the type of an entry in the CGT file.
	internal enum EntryContent
	{		
		///
		Empty				= 69,
		
		///
		Integer				= 73,
		
		///
		String				= 83,
		
		///
		Boolean				= 66,
		
		///
		Byte				= 98,
		
		///
		Multi				= 77
	};	

	/// Represents the type of a record in the CGT file.
	internal enum RecordId
	{		
		///
		Parameters			= 80,
		
		///
		TableCounts			= 84,
		
		///
		Initial				= 73,
		
		///
		Symbols				= 83,
		
		///
		CharSets			= 67,
		
		///
		Rules				= 82,
		
		///
		DFAStates			= 68,
		
		///
		LRTables			= 76,
		
		///
		Comment				= 33
	};

	/// Used internally to represent the result of the Parser.ParseToken method.
	internal enum ParseResult
	{		
		///
		Accept				= 301,
		
		///
		Shift				= 302,
		
		///
		ReduceNormal		= 303,
		
		///
		ReduceEliminated	= 304,
		
		///
		SyntaxError			= 305,
		
		///
		InternalError		= 406
	};	
}
