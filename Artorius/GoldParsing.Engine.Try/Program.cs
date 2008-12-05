using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using GoldParsing.Engine.Config;

namespace GoldParsing.Engine.Try
{
	internal class Program
	{
		private static Parser parser;

		private static void Main(string[] args)
		{
			const string symbolNameFromWhereStart = "Expression";
			const string grammarPath = @"..\..\..\Grammar\Hql.cgt";
			try
			{
				if (args == null || args.Length == 0)
				{
					throw new ArgumentException("you must specify an argument as, for example: \"p.Age + 5*3-(a.Parent.Age + :pO)\"");
				}
				var cgl = new CompiledGrammarLoader(grammarPath);
				var parserSettings = cgl.Load();
				Symbol whereStart = parserSettings.SymbolTable.FirstOrDefault(symbol => symbol.Name == symbolNameFromWhereStart);
				if (whereStart != null)
					((ParserSettings)parserSettings).StartSymbolIndex = whereStart.TableIndex;
				parser = new Parser(parserSettings) {TrimReductions = true};
				Console.WriteLine(args[0]);
				Console.WriteLine();
				Execute(args[0]);
				Console.ReadLine();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
				Console.ReadLine();
			}
		}

		public static void Execute(string inputText)
		{
			using (var sr = new StringReader(inputText))
			{
				bool done = false, fatal = false;
				int errors = 0, errorLine = -1;

				parser.OpenStream(sr);

				while (!done && !fatal)
				{
					ParseMessage result = parser.Parse();
					switch (result)
					{
						case ParseMessage.TokenRead:
							// do nothing
							break;
						case ParseMessage.Reduction:
							// do nothing
							break;
						case ParseMessage.Accept:
							// program accepted
							done = true;
							break;
						case ParseMessage.LexicalError:
							Console.WriteLine("LexicalError");
							fatal = true;
							break;
						case ParseMessage.SyntaxError:
							if (errorLine == (errorLine = parser.CurrentLineNumber))
							{
								fatal = true; // stop if there are multiple errors on one line
							}
							else
							{
								errors++;
								HandleSyntaxError();
							}
							break;
						case ParseMessage.CommentError:
							Console.WriteLine("CommentError");
							fatal = true;
							break;
						case ParseMessage.InternalError:
							Console.WriteLine("Internal error - this is really bad");
							fatal = true;
							break;
					}

					errors = (fatal ? errors + 1 : errors);
					fatal = fatal || (errors > 7);
				}

				if (fatal || errors > 0)
				{
					Console.WriteLine(errors + " error(s)");
				}
				else
				{
					var visitor = new DumpVisitor();
					parser.CurrentReduction.Accept(visitor);
					Console.WriteLine(visitor.GetResult());
				}
			}
		}

		private static void HandleSyntaxError()
		{
			int line = parser.CurrentLineNumber;
			IEnumerable<Token> expected = parser.ExpectedTokens;

			Console.WriteLine("Syntax error in line " + line + ".");
			Console.WriteLine("  after column: " + parser.LastValidPosition);
			Console.WriteLine("  found: " + parser.CurrentToken.Data);
			Console.Write("  expected: ");

			Token first = null;
			foreach (Token token in expected)
			{
				if (first == null)
				{
					first = token;
				}
				Console.Write(token + " ");
			}

			Console.Write("\n\n");
			parser.PushInputToken(first);
		}
	}

	public class DumpVisitor : IVisitor
	{
		private readonly StringBuilder displayTree = new StringBuilder();
		private int level;

		#region IVisitor Members

		public void Visit(Reduction reduction)
		{
			Print(reduction.ToString());
			level++;
			reduction.ChildrenAccept(this);
			level--;
		}

		#endregion

		public string GetResult()
		{
			return displayTree.ToString();
		}

		private void Print(string description)
		{
			displayTree.Append(new string(' ', level));
			displayTree.Append(description).Append("\n");
		}
	}
}