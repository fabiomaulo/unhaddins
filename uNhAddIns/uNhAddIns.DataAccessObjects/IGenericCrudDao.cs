using uNhAddIns.Entities;

namespace uNhAddIns.DataAccessObjects
{
	/// <summary>
	/// Generic Data Access Object contract for a read-write entity.
	/// </summary>
	/// <typeparam name="TIdentity">Entity's identity type.</typeparam>
	/// <typeparam name="TEntity">Entity's type.</typeparam>
	public interface IGenericCrudDao<TIdentity, TEntity> : IGenericDao<TIdentity, TEntity> where TEntity : IGenericEntity<TIdentity>
	{
		/// <summary>
		/// Persist the state of an entity.
		/// </summary>
		/// <param name="entity">A transient or persistent entity instance.</param>
		/// <returns>The persistent state.</returns>
		TEntity MakePersistent(TEntity entity);

		/// <summary>
		/// Make transient a persistent entity.
		/// </summary>
		/// <param name="entity">The entity to be delated.</param>
		/// <returns>The transient state.</returns>
		/// <remarks>
		/// The entity is marked to be delated when Unit-of-work will be commited.
		/// </remarks>
		TEntity MakeTransient(TEntity entity);

		/// <summary>
		/// Get a merged persistent state of a persistent entity.
		/// </summary>
		/// <param name="actualEntity">The actual persistent state.</param>
		/// <returns>The persistent state merged.</returns>
		TEntity GetMerged(TEntity actualEntity);
	}
}