using System.Collections;
using NHibernate.Event;

namespace uNhAddIns.ComponentBehaviors.Castle.EntityNameResolver
{
    public class EntityNameResolver : ISaveOrUpdateEventListener, IMergeEventListener, IPersistEventListener
    {
        #region IMergeEventListener Members

        public void OnMerge(MergeEvent @event)
        {
            @event.EntityName = GetEntityName(@event.Original, @event.EntityName);
        }

        public void OnMerge(MergeEvent @event, IDictionary copiedAlready)
        {
            @event.EntityName = GetEntityName(@event.Original, @event.EntityName);
        }

        #endregion

        #region IPersistEventListener Members

        public void OnPersist(PersistEvent @event)
        {
            @event.EntityName = GetEntityName(@event.Entity, @event.EntityName);
        }

        public void OnPersist(PersistEvent @event, IDictionary createdAlready)
        {
            @event.EntityName = GetEntityName(@event.Entity, @event.EntityName);
        }

        #endregion

        #region ISaveOrUpdateEventListener Members

        public void OnSaveOrUpdate(SaveOrUpdateEvent @event)
        {
            @event.EntityName = GetEntityName(@event.Entity, @event.EntityName);
        }

        #endregion

        private static string GetEntityName(object entity, string actual)
        {
            if (actual != null && !string.IsNullOrEmpty(actual))
                return actual;

            var namedEntity = entity as INamedEntity;
            return namedEntity != null ? namedEntity.EntityName : null;
        }
    }
}