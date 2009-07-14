using System;
using System.Collections;
using NHibernate.Event;

namespace uNhAddIns.WPF.EntityNameResolver
{
    public class EntityNameResolver : ISaveOrUpdateEventListener, IPersistEventListener, IMergeEventListener
    {
        public void OnSaveOrUpdate(SaveOrUpdateEvent @event)
        {
            @event.EntityName = GetEntityName(@event.Entity);
        }

        public void OnPersist(PersistEvent @event)
        {
            @event.EntityName = GetEntityName(@event.Entity);
        }

        public void OnPersist(PersistEvent @event, IDictionary createdAlready)
        {
            @event.EntityName = GetEntityName(@event.Entity);
        }

        public void OnMerge(MergeEvent @event)
        {
            @event.EntityName = GetEntityName(@event.Entity);
        }

        public void OnMerge(MergeEvent @event, IDictionary copiedAlready)
        {
            @event.EntityName = GetEntityName(@event.Entity);
        }

        private static string GetEntityName(object entity)
        {
            var namedEntity = entity as INamedEntity;
            return namedEntity != null ? namedEntity.EntityName : string.Empty;
        }
    }
}