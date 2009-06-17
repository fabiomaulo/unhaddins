namespace uNhAddIns.Inflector
{
	public interface IRule : IRuleApplier
	{
		string Replacement { get; }
		string Pattern { get; }
	}
}