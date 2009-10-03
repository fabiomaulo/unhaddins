using System;

namespace uNhAddIns.ComponentBehaviors
{
	/// <summary>
	/// Define a contract for behaviors
	/// </summary>
	public interface IBehavior
	{
		/// <summary>
		/// Additional interfaces for the proxy.
		/// </summary>
		/// <returns></returns>
		Type[] GetAdditionalInterfaces();

		/// <summary>
		/// Relative order as interceptor.
		/// </summary>
		/// <returns></returns>
		int GetRelativeOrder();
	}
}