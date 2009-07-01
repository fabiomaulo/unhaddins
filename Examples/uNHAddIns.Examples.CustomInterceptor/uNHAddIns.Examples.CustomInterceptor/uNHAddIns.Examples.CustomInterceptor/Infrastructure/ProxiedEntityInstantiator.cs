using System;
using Microsoft.Practices.ServiceLocation;
using NHibernate.Tuple;

namespace uNHAddIns.Examples.CustomInterceptor.Infrastructure
{

    /// <summary>
    /// Resolve an entity through ServiceLocator.
    /// This allow to inject a proxy and intercepted entity.
    ///     TODO: change the name.
    /// </summary>
    public class ProxiedEntityInstantiator : IInstantiator
    {
        #region IInstantiator Members

        private readonly Type _entityType;

        public ProxiedEntityInstantiator(Type entityType)
        {
            _entityType = entityType;
        }

        public object Instantiate(object id)
        {
            var obj = ServiceLocator.Current.GetInstance(_entityType);
            //TODO: Depends on the id strategy. This is horrible hack.
            //if(id != null)
            //    obj.GetType().GetProperty("Id").SetValue(obj, id, null);
            
            return obj;
        }

        public object Instantiate()
        {
            return Instantiate(null);
        }

        public bool IsInstance(object obj)
        {
            return _entityType.IsInstanceOfType(obj);
        }

        #endregion
    }
}