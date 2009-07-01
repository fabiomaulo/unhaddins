using NHibernate.Mapping;
using NHibernate.Tuple;
using NHibernate.Tuple.Entity;

namespace uNHAddIns.Examples.CustomInterceptor.Infrastructure
{
    /// <summary>
    /// For use ProxiedEntityInstantiator.
    /// </summary>
    public class ProxiedTuplizer : PocoEntityTuplizer
    {
        public ProxiedTuplizer(EntityMetamodel entityMetamodel, PersistentClass mappedEntity)
            : base(entityMetamodel, mappedEntity)
        {
        }

        protected override IInstantiator BuildInstantiator(PersistentClass persistentClass)
        {
            return new ProxiedEntityInstantiator(persistentClass.MappedClass);
        }
    }
}