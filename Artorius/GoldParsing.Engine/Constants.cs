namespace GoldParsing.Engine
{
	/// <summary>
	/// Respresents the type of a symbol.
	/// </summary>
	public enum SymbolType
	{
		/// <summary>
		/// A normal non-terminal.
		/// </summary>
		NonTerminal = 0,

		/// <summary>
		/// A normal terminal.
		/// </summary>
		Terminal = 1,

		/// <summary>
		/// This Whitespace symbol is a special terminal that is automatically 
		/// ignored by the parsing engine. Any text accepted as whitespace is 
		/// considered to be inconsequential and "meaningless".
		/// </summary>
		Whitespace = 2,

		/// <summary>
		/// The End symbol is generated when the tokenizer reaches the end of 
		/// the source text.
		/// </summary>
		End = 3,

		/// <summary>
		/// This type of symbol designates the start of a block comment.
		/// </summary>
		CommentStart = 4,

		/// <summary>
		/// This type of symbol designates the end of a block comment.
		/// </summary>
		CommentEnd = 5,

		/// <summary>
		/// When the engine reads a token that is recognized as a line comment, 
		/// the remaining characters on the line are automatically ignored by 
		/// the parser.
		/// </summary>
		CommentLine = 6,

		/// <summary>
		/// The Error symbol is a general-purpose means of representing characters 
		/// that were not recognized by the tokenizer. In other words, when the 
		/// tokenizer reads a series of characters that is not accepted by the DFA 
		/// engine, a token of this type is created.
		/// </summary>
		Error = 7
	};

	public enum Action
	{
		Shift = 1,
		Reduce = 2,
		Goto = 3,
		Accept = 4,
		Error = 5
	};
}