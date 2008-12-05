using System;
using System.IO;

namespace GoldParsing.Engine
{
	/// <summary>
	/// This is a wrapper around StreamReader which supports lookahead.
	/// </summary>
	public class LookAheadReader : IDisposable
	{
		private const int BufferSize = 256;

		private readonly char[] buffer;
		private readonly TextReader reader;
		private int buflen;
		private int curpos;

		/// <summary>
		/// Creates a new LookAheadReader around the specified StreamReader.
		/// </summary>
		public LookAheadReader(TextReader textReader)
		{
			reader = textReader;
			curpos = -1;
			buffer = new char[BufferSize];
		}

		public int CurrentPosition
		{
			get { return curpos; }
		}

		/// <summary>
		/// Makes sure there are enough characters in the buffer.
		/// </summary>
		private void FillBuffer(int length)
		{
			int av = buflen - curpos; // het aantal chars na curpos

			if (curpos == -1)
			{
				// fill the buffer
				buflen = reader.Read(buffer, 0, BufferSize);
				curpos = 0;
			}
			else if (av < length)
			{
				if (buflen < BufferSize)
				{
					// not available
					throw new EndOfStreamException();
				}
				else
				{
					// re-fill the buffer								
					Array.Copy(buffer, curpos, buffer, 0, av);
					buflen = reader.Read(buffer, av, curpos) + av;
					curpos = 0;
				}
			}

			// append a newline on EOF
			if (buflen < BufferSize)
			{
				buffer[buflen++] = '\n';
			}
		}

		/// <summary>
		/// Returns the next char in the buffer but doesn't advance the current position.
		/// </summary>
		/// <returns>the next char</returns>
		public char LookAhead()
		{
			FillBuffer(1);
			return buffer[curpos];
		}

		/// <summary>
		/// Returns the char at current position + the specified number of characters.
		/// Does not change the current position.
		/// </summary>
		/// <param name="position">The position after the current one where the character to return is</param>
		public char LookAhead(int position)
		{
			FillBuffer(position + 1);
			return buffer[curpos + position];
		}

		/// <summary>
		/// Returns the next char in the buffer and advances the current position by one.
		/// </summary>
		public char Read()
		{
			FillBuffer(1);
			return buffer[curpos++];
		}

		/// <summary>
		/// Returns the next n characters in the buffer and advances the current position by n.
		/// </summary>
		public string Read(int length)
		{
			FillBuffer(length);
			var result = new string(buffer, curpos, length);
			curpos += length;
			return result;
		}

		/// <summary>
		/// Advances the current position in the buffer until a newline is encountered.
		/// </summary>
		public void DiscardLine()
		{
			while (LookAhead() != '\n')
			{
				curpos++;
			}
		}

		/// <summary>
		/// Closes the underlying StreamReader.
		/// </summary>
		public void Close()
		{
			reader.Close();
		}

		#region Implementation of IDisposable

		private bool disposed;

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~LookAheadReader()
		{
			Dispose(false);
		}

		private void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					reader.Dispose();
				}

				disposed = true;
			}
		}

		#endregion
	}
}