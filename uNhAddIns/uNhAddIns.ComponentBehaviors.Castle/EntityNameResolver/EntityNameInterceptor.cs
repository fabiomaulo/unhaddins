using NHibernate;

namespace uNhAddIns.ComponentBehaviors.Castle.EntityNameResolver
{
    public class EntityNameInterceptor : EmptyInterceptor
    {
        public override string GetEntityName(object entity)
        {
            if (entity is INamedEntity)
            {
                var namedEntity = (INamedEntity) entity;
                return namedEntity.EntityName;
            }

            return base.GetEntityName(entity);
        }
    }
}