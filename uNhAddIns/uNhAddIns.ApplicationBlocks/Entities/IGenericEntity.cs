using System;

namespace uNhAddIns.ApplicationBlocks.Entities
{
	public interface IGenericEntity<TIdentity> : IEquatable<IGenericEntity<TIdentity>>
	{
		TIdentity Id { get; }
	}
}