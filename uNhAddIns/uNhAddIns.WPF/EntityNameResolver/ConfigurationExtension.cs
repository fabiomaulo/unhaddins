using System.Linq;
using NHibernate.Cfg;
using NHibernate.Event;

namespace uNhAddIns.WPF.EntityNameResolver
{
    public static class ConfigurationExtension
    {
        public static Configuration RegisterEntityNameResolver(this Configuration configuration)
        {
            EventListeners listeners = configuration.EventListeners;
            var entityNameResolver = new EntityNameResolver();
            listeners.MergeEventListeners =
                new[] { entityNameResolver }.Concat(listeners.MergeEventListeners).ToArray();
            listeners.UpdateEventListeners =
                new[] { entityNameResolver }.Concat(listeners.UpdateEventListeners).ToArray();
            listeners.SaveOrUpdateEventListeners =
                new[] { entityNameResolver }.Concat(listeners.SaveOrUpdateEventListeners).ToArray();
            listeners.SaveEventListeners =
                new[] { entityNameResolver }.Concat(listeners.SaveEventListeners).ToArray();
            listeners.PersistEventListeners =
                new[] {entityNameResolver}.Concat(listeners.PersistEventListeners).ToArray();

            return configuration;
        }
    }
}