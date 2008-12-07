namespace NHibernate.Hql.Ast
{
	/// <summary>
	/// The generic HQL parser interface.
	/// </summary>
	/// <typeparam name="TSource">The type of the HQL representation.</typeparam>
	public interface IHqlParser<TSource>
	{
		ISyntaxNode Parse(TSource hql);
	}
}