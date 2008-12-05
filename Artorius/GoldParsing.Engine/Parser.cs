using System;
using System.Collections.Generic;
using System.IO;

namespace GoldParsing.Engine
{
	/// <summary>
	/// This is the main class in the GoldParser Engine and is used to perform
	/// all duties required to the parsing of a source text string. This class
	/// contains the LALR(1) State Machine code, the DFA State Machine code,
	/// character table (used by the DFA algorithm).
	/// </summary>
	public class Parser
	{
		private readonly Symbol endSymbol;
		private readonly Symbol errorSymbol;
		private readonly FixCaseDelegate fixCase;
		// Stack of tokens to be analyzed
		private readonly TokenStack inputTokens = new TokenStack();
		// The set of tokens for 1. Expecting during error, 2. Reduction
		private readonly TokenStack outputTokens = new TokenStack();
		private readonly IParserSettings settings;
		// I often dont know what to call variables.
		private readonly TokenStack tempStack = new TokenStack();
		private int commentLevel;
		private bool haveReduction;
		private int lalrStateIndex;
		private int lineNumber;
		private LookAheadReader source;

		public Parser(IParserSettings settings)
		{
			if (settings == null)
			{
				throw new ArgumentNullException("settings");
			}
			this.settings = settings;

			if (settings.IsCaseSensitive)
			{
				fixCase = x => x;
			}
			else
			{
				fixCase = x => char.ToLowerInvariant(x);
			}
			foreach (Symbol symbol in settings.SymbolTable)
			{
				if (symbol.Kind == SymbolType.Error)
				{
					errorSymbol = symbol;
				}
				else if (symbol.Kind == SymbolType.End)
				{
					endSymbol = symbol;
				}
			}
			TrimReductions = false;
		}

		/// <summary>
		/// Gets or sets whether or not to trim reductions which contain 
		/// only one non-terminal.
		/// </summary>
		public bool TrimReductions { get; set; }

		/// <summary>
		/// Gets the current token.
		/// </summary>
		public Token CurrentToken
		{
			get { return inputTokens.PeekToken(); }
		}

		/// <summary>Gets the <c>Reduction</c> made by the parsing engine.</summary>
		/// <remarks>The value of this property is only valid when the Parse-method
		///          returns <c>ParseMessage.Reduction</c>.</remarks>
		public Reduction CurrentReduction
		{
			get
			{
				if (haveReduction)
				{
					Token token = tempStack.PeekToken();
					return (token.Data as Reduction);
				}
				else
				{
					return null;
				}
			}
			set
			{
				if (haveReduction)
				{
					tempStack.PeekToken().Data = value;
				}
			}
		}

		/// <summary>
		/// Gets the line number that is currently being processed.
		/// </summary>
		public int CurrentLineNumber
		{
			get { return lineNumber; }
		}

		/// <summary>
		/// Tokens for the reduced rule or
		/// the tokens that where expected when a syntax error occures.
		/// </summary>		
		public IEnumerable<Token> ExpectedTokens
		{
			get { return outputTokens; }
		}

		/// <summary>
		/// Pushes the specified token onto the internal input queue. 
		/// It will be the next token analyzed by the parsing engine.
		/// </summary>
		public void PushInputToken(Token token)
		{
			inputTokens.PushToken(token);
		}

		/// <summary>
		/// Opens the file with the specified name for parsing.
		/// </summary>
		public void OpenStream(TextReader stream)
		{
			Reset();
			source = new LookAheadReader(stream);
			PrepareToParse();
		}

		private void PrepareToParse()
		{
			var token = new Token(settings.SymbolTable[settings.StartSymbolIndex]) {State = settings.LALRInitialStateIndex};
			tempStack.PushToken(token);
		}

		private void Reset()
		{
			inputTokens.Clear();
			outputTokens.Clear();
			tempStack.Clear();
			lineNumber = 1;
			commentLevel = 0;
			lalrStateIndex = settings.LALRInitialStateIndex;
			haveReduction = false;
		}

		/// <summary>Executes a parse-action.</summary>
		/// <remarks>
		/// When this method is called, the parsing engine 
		/// reads information from the source text and then reports what action was taken. 
		/// This ranges from a token being read and recognized from the source, a parse 
		/// reduction, or some type of error.
		/// </remarks>
		public ParseMessage Parse()
		{
			while (true)
			{
				if (inputTokens.Count == 0)
				{
					// we must read a token.				

					Token token = RetrieveToken();

					if (token == null)
					{
						throw new ParserException("RetrieveToken returned null");
					}

					if (token.Kind != SymbolType.Whitespace)
					{
						inputTokens.PushToken(token);

						if (commentLevel == 0 && !IsCommentToken(token))
						{
							return ParseMessage.TokenRead;
						}
					}
				}
				else if (commentLevel > 0)
				{
					// we are in a block comment.
					Token token = inputTokens.PopToken();

					switch (token.Kind)
					{
						case SymbolType.CommentStart:
							commentLevel++;
							break;
						case SymbolType.CommentEnd:
							commentLevel--;
							break;
						case SymbolType.End:
							return ParseMessage.CommentError;
					}
				}
				else
				{
					// we are ready to parse.
					Token token = inputTokens.PeekToken();
					switch (token.Kind)
					{
						case SymbolType.CommentStart:
							inputTokens.PopToken();
							commentLevel++;
							break;
						case SymbolType.CommentLine:
							inputTokens.PopToken();
							DiscardLine();
							break;
						default:
							ParseResult result = ParseToken(token);
							switch (result)
							{
								case ParseResult.Accept:
									return ParseMessage.Accept;
								case ParseResult.InternalError:
									return ParseMessage.InternalError;
								case ParseResult.ReduceNormal:
									return ParseMessage.Reduction;
								case ParseResult.Shift:
									inputTokens.PopToken();
									break;
								case ParseResult.SyntaxError:
									return ParseMessage.SyntaxError;
							}
							break;
					}
				}
			}
		}

		public int LastValidPosition
		{
			get { return source.CurrentPosition; }
		}

		/// <summary>
		/// Returns true if the specified token is a CommentLine or CommentStart-symbol.
		/// </summary>
		private static bool IsCommentToken(Symbol token)
		{
			return (token.Kind == SymbolType.CommentLine) || (token.Kind == SymbolType.CommentStart);
		}

		/// <summary>
		/// This method implements the DFA algorithm and returns a token
		/// to the LALR state machine.
		/// </summary>
		private Token RetrieveToken()
		{
			Token result;
			int currentPos = 0;
			int lastAcceptState = -1;
			int lastAcceptPos = -1;
			DFAState currentState = settings.DFATable[settings.DFAInitialStateIndex];

			try
			{
				while (true)
				{
					// This code searches all the branches of the current DFA state for the next
					// character in the input LookaheadStream. If found the target state is returned.
					// The InStr() function searches the string pCharacterSetTable.Member(CharSetIndex)
					// starting at position 1 for ch.  The pCompareMode variable determines whether
					// the search is case sensitive.
					char ch = fixCase(source.LookAhead(currentPos));

					int target = FindEdge(currentState, ch);

					// This block-if statement checks whether an edge was found from the current state.
					// If so, the state and current position advance. Otherwise it is time to exit the main loop
					// and report the token found (if there was it fact one). If the LastAcceptState is -1,
					// then we never found a match and the Error Token is created. Otherwise, a new token
					// is created using the Symbol in the Accept State and all the characters that
					// comprise it.
					if (target != -1)
					{
						// This code checks whether the target state accepts a token. If so, it sets the
						// appropiate variables so when the algorithm is done, it can return the proper
						// token and number of characters.
						if (settings.DFATable[target].AcceptSymbol.HasValue)
						{
							lastAcceptState = target;
							lastAcceptPos = currentPos;
						}

						currentState = settings.DFATable[target];
						currentPos++;
					}
					else
					{
						if (lastAcceptState == -1)
						{
							result = new Token(errorSymbol) {Data = source.Read(1)};
						}
						else
						{
							Symbol symbol = settings.SymbolTable[settings.DFATable[lastAcceptState].AcceptSymbol.Value];
							result = new Token(symbol) {Data = source.Read(lastAcceptPos + 1)};
						}
						break;
					}
				}
			}
			catch (EndOfStreamException)
			{
				result = new Token(endSymbol) {Data = ""};
			}

			UpdateLineNumber((string) result.Data);

			return result;
		}

		private static int FindEdge(DFAState currentState, char ch)
		{
			foreach (DFAEdge edge in currentState.Edges)
			{
				if (edge.Characters.IndexOf(ch) != -1)
				{
					return edge.TargetIndex;
				}
			}
			return -1;
		}

		/// <summary>
		/// This function analyzes a token and either:
		///   1. Makes a SINGLE reduction and pushes a complete Reduction object on the stack
		///   2. Accepts the token and shifts
		///   3. Errors and places the expected symbol indexes in the Tokens list
		/// The Token is assumed to be valid and WILL be checked
		/// </summary>
		private ParseResult ParseToken(Token token)
		{
			ParseResult result = ParseResult.InternalError;
			LALRState table = settings.LALRTable[lalrStateIndex];
			LALRAction action = table.GetActionForSymbol(token.TableIndex);

			if (action != null)
			{
				haveReduction = false;
				outputTokens.Clear();

				switch (action.Action)
				{
					case Action.Accept:
						haveReduction = true;
						result = ParseResult.Accept;
						break;
					case Action.Shift:
						token.State = lalrStateIndex = action.Value;
						tempStack.PushToken(token);
						result = ParseResult.Shift;
						break;
					case Action.Reduce:
						result = Reduce(settings.RuleTable[action.Value]);
						break;
				}
			}
			else
			{
				// syntax error - fill expected tokens.				
				outputTokens.Clear();
				foreach (LALRAction a in table.Members)
				{
					SymbolType kind = a.Symbol.Kind;

					if (kind == SymbolType.Terminal || kind == SymbolType.End)
					{
						outputTokens.PushToken(new Token(a.Symbol));
					}
				}
				result = ParseResult.SyntaxError;
			}

			return result;
		}

		/// <summary>Produces a reduction.</summary>
		/// <remarks>Removes as many tokens as members in the rule and pushes a 
		///          non-terminal token.</remarks>
		private ParseResult Reduce(Rule rule)
		{
			ParseResult result;
			Token head;

			if (TrimReductions && rule.ContainsOneNonTerminal)
			{
				// The current rule only consists of a single nonterminal and can be trimmed from the
				// parse tree. Usually we create a new Reduction, assign it to the Data property
				// of Head and push it on the stack. However, in this case, the Data property of the
				// Head will be assigned the Data property of the reduced token (i.e. the only one
				// on the stack). In this case, to save code, the value popped of the stack is changed 
				// into the head.
				head = tempStack.PopToken();
				head.SetParent(rule.Head);

				result = ParseResult.ReduceEliminated;
			}
			else
			{
				var reduction = new Reduction(rule);

				tempStack.PopTokensInto(reduction, rule.Symbols.Count);

				head = new Token(rule.Head) {Data = reduction};

				haveReduction = true;
				result = ParseResult.ReduceNormal;
			}

			int index = tempStack.PeekToken().State;
			LALRAction action = settings.LALRTable[index].GetActionForSymbol(rule.Head.TableIndex);

			if (action != null)
			{
				head.State = lalrStateIndex = action.Value;
				tempStack.PushToken(head);
			}
			else
			{
				throw new ParserException("Action for LALR state is null");
			}

			return result;
		}

		private void UpdateLineNumber(string line)
		{
			int index, pos = 0;
			while ((index = line.IndexOf('\n', pos)) != -1)
			{
				pos = index + 1;
				lineNumber++;
			}
		}

		private void DiscardLine()
		{
			source.DiscardLine();
			lineNumber++;
		}

		#region Nested type: FixCaseDelegate

		private delegate char FixCaseDelegate(char c);

		#endregion

		#region Nested type: ParseResult

		internal enum ParseResult
		{
			Accept = 301,
			Shift = 302,
			ReduceNormal = 303,
			ReduceEliminated = 304,
			SyntaxError = 305,
			InternalError = 406
		} ;

		#endregion
	}
}