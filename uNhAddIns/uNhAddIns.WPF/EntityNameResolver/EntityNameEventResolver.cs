using NHibernate.Event;

namespace uNhAddIns.WPF.EntityNameResolver
{
    public class EntityNameEventResolver : NHibernate.Event.Default.DefaultSaveOrUpdateEventListener
    {
        public override void OnSaveOrUpdate(SaveOrUpdateEvent @event)
        {
            
            
            var namedEntity = @event.Entity as INamedEntity;
            if(namedEntity != null)
            {
                @event.EntityName = namedEntity.EntityName;    
            }else
            {
                base.OnSaveOrUpdate(@event);    
            }
            
        }
    }
}