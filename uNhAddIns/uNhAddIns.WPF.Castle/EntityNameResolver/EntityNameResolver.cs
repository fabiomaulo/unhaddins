using System.Collections;
using NHibernate.Event;

namespace uNhAddIns.WPF.Castle.EntityNameResolver
{
    public class EntityNameResolver : ISaveOrUpdateEventListener, IMergeEventListener, IPersistEventListener
    {
        #region IMergeEventListener Members

        public void OnMerge(MergeEvent @event)
        {
            @event.EntityName = GetEntityName(@event.Original);
        }

        public void OnMerge(MergeEvent @event, IDictionary copiedAlready)
        {
            @event.EntityName = GetEntityName(@event.Original);
        }

        #endregion

        #region IPersistEventListener Members

        public void OnPersist(PersistEvent @event)
        {
            @event.EntityName = GetEntityName(@event.Entity);
        }

        public void OnPersist(PersistEvent @event, IDictionary createdAlready)
        {
            @event.EntityName = GetEntityName(@event.Entity);
        }

        #endregion

        #region ISaveOrUpdateEventListener Members

        public void OnSaveOrUpdate(SaveOrUpdateEvent @event)
        {
            @event.EntityName = GetEntityName(@event.Entity);
        }

        #endregion

        private static string GetEntityName(object entity)
        {
            var namedEntity = entity as INamedEntity;
            return namedEntity != null ? namedEntity.EntityName : null;
        }
    }
}