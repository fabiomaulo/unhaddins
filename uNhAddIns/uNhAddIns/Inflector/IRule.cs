using System.Collections.Generic;

namespace uNhAddIns.Inflector
{
	public interface IRule
	{
		string Replacement { get; }
		string Pattern { get; }
		string Apply(string word);
	}
}