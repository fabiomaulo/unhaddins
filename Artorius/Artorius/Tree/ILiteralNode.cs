namespace NHibernate.Hql.Ast.Tree
{
	public interface ILiteralNode
	{
		string AsString { get; }
		System.Type ReturnType { get; }
	}
}