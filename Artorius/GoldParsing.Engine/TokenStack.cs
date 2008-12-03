using System.Collections;
using System.Collections.Generic;

namespace GoldParsing.Engine
{
	public class TokenStack: IEnumerable<Token>
	{
		private readonly List<Token> items = new List<Token>();

		/// Returns the token at the specified position from the top.
		public Token this[int index]
		{
			get { return items[index]; }
		}

		/// Gets the number of items in the stack.
		public int Count
		{
			get { return items.Count; }
		}

		/// Removes all tokens from the stack.
		public void Clear()
		{
			items.Clear();
		}

		/// Pushes the specified token on the stack.
		public void PushToken(Token p_token)
		{
			items.Add(p_token);
		}

		/// Returns the token on top of the stack.
		public Token PeekToken()
		{
			int last = items.Count - 1;
			return (last < 0 ? null : items[last]);
		}

		/// <summary>Pops a token from the stack.</summary>
		/// <remarks>The token on top of the stack will be removed and returned 
		/// by the method.</remarks>
		public Token PopToken()
		{
			int last = items.Count - 1;
			if (last < 0) return null;
			Token result = items[last];
			items.RemoveAt(last);
			return result;
		}

		/// Pops the specified number of tokens from the stack and adds them
		/// to the specified <c>Reduction</c>.
		public void PopTokensInto(Reduction reduction, int itemsCount)
		{
			int start = items.Count - itemsCount;
			int end = items.Count;

			for (int i = start; i < end; i++)
				reduction.Tokens.Add(items[i]);

			items.RemoveRange(start, itemsCount);
		}

		#region Implementation of IEnumerable

		public IEnumerator<Token> GetEnumerator()
		{
			return items.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#endregion
	}
}