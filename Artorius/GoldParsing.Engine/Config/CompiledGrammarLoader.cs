using System;

namespace GoldParsing.Engine.Config
{
	public class CompiledGrammarLoader : IGrammarLoader
	{
		private readonly string filePath;

		public CompiledGrammarLoader(string filePath)
		{
			if (filePath == null)
			{
				throw new ArgumentNullException("filePath");
			}
			this.filePath = filePath;
		}

		#region Implementation of IParserSettingsLoader

		public IGrammar Load()
		{
			var ps = new Grammar();
			using (var reader = new CompiledGrammarReader(filePath))
			{
				while (reader.MoveNext())
				{
					short index;
					var id = (RecordId) (byte) reader.RetrieveNext();

					switch (id)
					{
						case RecordId.Parameters:
							ps.Parameters["Name"] = reader.RetrieveNext() as string;
							ps.Parameters["Version"] = reader.RetrieveNext() as string;
							ps.Parameters["Author"] = reader.RetrieveNext() as string;
							ps.Parameters["About"] = reader.RetrieveNext() as string;
							ps.IsCaseSensitive = (Boolean) reader.RetrieveNext();
							ps.StartSymbolIndex = (short) reader.RetrieveNext();
							break;

						case RecordId.TableCounts:
							ps.SymbolTable = new Symbol[(short) reader.RetrieveNext()];
							ps.CharSetTable = new string[(short) reader.RetrieveNext()];
							ps.RuleTable = new Rule[(short) reader.RetrieveNext()];
							ps.DFATable = new DFAState[(short) reader.RetrieveNext()];
							ps.LALRTable = new LALRState[(short) reader.RetrieveNext()];
							break;

						case RecordId.Initial:
							ps.DFAInitialStateIndex = (short) reader.RetrieveNext();
							ps.LALRInitialStateIndex = (short) reader.RetrieveNext();
							break;

						case RecordId.Symbols:
							index = (short) reader.RetrieveNext();
							var name = (String) reader.RetrieveNext();
							var kind = (SymbolType) (short) reader.RetrieveNext();
							ps.SymbolTable[index] = new Symbol(index, name, kind);
							break;

						case RecordId.CharSets:
							index = (short) reader.RetrieveNext();
							var charset = (String) reader.RetrieveNext();
							ps.CharSetTable[index] = ps.IsCaseSensitive ? charset : charset.ToLowerInvariant();
							break;

						case RecordId.Rules:
							index = (short) reader.RetrieveNext();
							Symbol head = ps.SymbolTable[(short) reader.RetrieveNext()];
							var rule = new Rule(index, head);

							reader.RetrieveNext(); // reserved
							object obj;
							while ((obj = reader.RetrieveNext()) != null)
							{
								rule.Symbols.Add(ps.SymbolTable[(short) obj]);
							}
							ps.RuleTable[index] = rule;
							break;

						case RecordId.DFAStates:
							var dfaState = new DFAState();
							index = (short) reader.RetrieveNext();

							if ((bool) reader.RetrieveNext())
							{
								dfaState.AcceptSymbol = (short) reader.RetrieveNext();
							}
							else
							{
								reader.RetrieveNext();
							}

							reader.RetrieveNext(); // reserverd					

							while (!reader.RetrieveDone())
							{
								var ci = (short) reader.RetrieveNext();
								var ti = (short) reader.RetrieveNext();
								reader.RetrieveNext(); // reserved
								dfaState.AddEdge(ps.CharSetTable[ci], ti);
							}
							ps.DFATable[index] = dfaState;
							break;

						case RecordId.LRTables:
							var lalrState = new LALRState();
							index = (short) reader.RetrieveNext();
							reader.RetrieveNext(); // reserverd

							while (!reader.RetrieveDone())
							{
								var sid = (short) reader.RetrieveNext();
								var action = (short) reader.RetrieveNext();
								var tid = (short) reader.RetrieveNext();
								reader.RetrieveNext(); // reserved
								lalrState.AddItem(ps.SymbolTable[sid], (Action) action, tid);
							}
							ps.LALRTable[index] = lalrState;
							break;

						case RecordId.Comment:
							// ignore
							break;

						default:
							throw new ParserException("Wrong id for record");
					}
				}
				return ps;
			}
		}

		#endregion

		#region Nested type: RecordId

		private enum RecordId
		{
			Parameters = 80,
			TableCounts = 84,
			Initial = 73,
			Symbols = 83,
			CharSets = 67,
			Rules = 82,
			DFAStates = 68,
			LRTables = 76,
			Comment = 33
		} ;

		#endregion
	}
}