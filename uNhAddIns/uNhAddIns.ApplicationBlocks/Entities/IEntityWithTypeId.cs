using System;

namespace uNhAddIns.ApplicationBlocks.Entities {
    public interface IEntityWithTypeId<TId> : IEquatable<IEntity> {
        TId Id { get;}
    }
}