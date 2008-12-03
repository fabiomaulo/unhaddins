using System;
using System.Collections;
using System.IO;
using System.Text;

namespace GoldParsing.Engine.Config
{
	/// <summary>
	/// This class is used to read information stored in the very simple file
	/// structure used by the Compiled Grammar Table file.
	/// </summary>
	public class CompiledGrammarReader : IDisposable
	{
		private const string fileHeader = "GOLD Parser Tables/v1.0";
		private readonly FileStream file;

		private readonly Encoding encoding = new UnicodeEncoding(false, true);
		private readonly Queue entryQueue = new Queue();
		private readonly BinaryReader reader;

		public CompiledGrammarReader(string filePath)
		{
			try
			{
				file = new FileStream(filePath, FileMode.Open);
				reader = new BinaryReader(file);
			}
			catch (Exception e)
			{
				throw new ParserException("Error constructing GrammarReader", e);
			}

			if (!HasValidHeader())
			{
				throw new ParserException("Incorrect file header");
			}
		}

		public bool MoveNext()
		{
			try
			{
				var content = (EntryContent) reader.ReadByte();
				if (content == EntryContent.Multi)
				{
					entryQueue.Clear();
					int count = reader.ReadInt16();

					for (int n = 0; n < count; n++)
					{
						ReadEntry();
					}

					return true;
				}
				else
				{
					return false;
				}
			}
			catch (IOException)
			{
				return false;
			}
		}

		public object RetrieveNext()
		{
			if (entryQueue.Count == 0)
			{
				return null;
			}
			else
			{
				return entryQueue.Dequeue();
			}
		}

		public bool RetrieveDone()
		{
			return (entryQueue.Count == 0);
		}

		private bool HasValidHeader()
		{
			string filetype = ReadString();
			return fileHeader.Equals(filetype);
		}

		private string ReadString()
		{
			int pos = 0;
			var buffer = new byte[1024];

			while (true)
			{
				reader.Read(buffer, pos, 2);
				if (buffer[pos] == 0)
				{
					break;
				}
				pos = pos + 2;
			}

			return encoding.GetString(buffer, 0, pos);
		}

		private void ReadEntry()
		{
			var content = (EntryContent) reader.ReadByte();
			switch (content)
			{
				case EntryContent.Empty:
					entryQueue.Enqueue(new Object());
					break;
				case EntryContent.Boolean:
					bool boolvalue = (reader.ReadByte() == 1);
					entryQueue.Enqueue(boolvalue);
					break;
				case EntryContent.Byte:
					byte bytevalue = reader.ReadByte();
					entryQueue.Enqueue(bytevalue);
					break;
				case EntryContent.Integer:
					Int16 intvalue = reader.ReadInt16();
					entryQueue.Enqueue(intvalue);
					break;
				case EntryContent.String:
					string strvalue = ReadString();
					entryQueue.Enqueue(strvalue);
					break;
				default:
					throw new ParserException("Error reading CGT: unknown entry-content type");
			}
		}

		#region Nested type: EntryContent

		private enum EntryContent
		{
			Empty = 69,
			Integer = 73,
			String = 83,
			Boolean = 66,
			Byte = 98,
			Multi = 77
		} ;

		#endregion

		#region Implementation of IDisposable

		private bool disposed;

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~CompiledGrammarReader()
		{
			Dispose(false);
		}

		private void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					reader.Close();
					file.Dispose();
				}

				disposed = true;
			}
		}

		#endregion
	}
}