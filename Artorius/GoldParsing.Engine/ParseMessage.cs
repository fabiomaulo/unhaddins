namespace GoldParsing.Engine
{
	/// <summary>
	/// The result of the Parser.Parse method.
	/// </summary>
	public enum ParseMessage
	{
		/// <summary>
		/// This message is returned each time a token is read.
		/// </summary>
		TokenRead,

		/// <summary>
		/// When the engine is able to reduce a rule, this message is returned. 
		/// The rule that was reduced is set in the <c>Parser.Reduction</c> property. 
		/// The tokens that are reduced and correspond to the rule's definition 
		/// can be acquired using the <c>GetToken</c> or <c>GetTokens</c> methods.
		/// </summary>
		Reduction,

		/// <summary>
		/// The engine will returns this message when the source text has been 
		/// accepted as both complete and correct. In other words, the source 
		/// text was successfully analyzed.
		/// </summary>
		Accept,

		/// <summary>
		/// The tokenizer will generate this message when it is unable to 
		/// recognize a series of characters as a valid token. To recover, pop the 
		/// invalid token from the input queue using <c>Parser.PopInputToken</c>.
		/// </summary>
		LexicalError,

		/// <summary>
		/// Often the parser will read a token that is not expected in the 
		/// grammar. When this happens, you can acquire the expected tokens using
		/// the <c>GetToken</c> or <c>GetTokens</c> methods. To recover, push 
		/// one of the expected tokens onto the input queue.
		/// </summary>
		SyntaxError,

		/// <summary>
		/// The parser reached the end of the file while reading a comment. 
		/// This is caused when the source text contains a "run-away" comment, 
		/// or in other words, a block comment that lacks the end-delimiter.
		/// </summary>
		CommentError,

		/// <summary>
		/// Something is very wrong when this message is returned.
		/// </summary>
		InternalError
	};

}