namespace uNhAddIns.DataAccessObjects
{
	/// <summary>
	/// Factory od DAOs
	/// </summary>
	public interface IDaoFactory
	{
		/// <summary>
		/// Get a Data Access Object instance.
		/// </summary>
		/// <typeparam name="TDao">The type DAO's type.</typeparam>
		/// <returns>The DAO instance.</returns>
		TDao GetDao<TDao>() where TDao : class;
	}
}