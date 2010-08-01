using System;
using uNhAddIns.Entities;

namespace uNhAddIns.DataAccessObjects
{
	/// <summary>
	/// Generic Data Access Object contract for a read-only entity.
	/// </summary>
	/// <typeparam name="TIdentity">Entity's identity type.</typeparam>
	/// <typeparam name="TEntity">Entity's type.</typeparam>
	public interface IGenericDao<TIdentity, TEntity> where TEntity : IGenericEntity<TIdentity>
	{
		/// <summary>
		/// Get the persistent state, where available, for a given entity identity.
		/// </summary>
		/// <param name="id">The entity identity.</param>
		/// <returns>
		/// The persistent state of the entity or <see langword="null"/> where the state does not exists.
		/// </returns>
		TEntity Get(TIdentity id);

		/// <summary>
		/// Get the proxy persistent state, where available, for a given entity identity.
		/// </summary>
		/// <param name="id">The entity identity.</param>
		/// <returns>
		/// A proxy of the entity or the entity itself.
		/// </returns>
		/// <exception cref="DataAccessException">when the entity's persistent state is not available.</exception>
		/// <remarks>
		/// A proxy will be create without a DB hit.
		/// The exception will be thrown, at the first access to one of the entity methods, 
		/// when the persistent state does not exists.
		/// </remarks>
		TEntity GetProxy(TIdentity id);

		/// <summary>
		/// Get a fresh persistent state of the entity.
		/// </summary>
		/// <param name="entity">The entity needing to be refreshed.</param>
		/// <returns>
		/// The fresh persistent state.
		/// </returns>
		TEntity Refresh(TEntity entity);
	}

	
}