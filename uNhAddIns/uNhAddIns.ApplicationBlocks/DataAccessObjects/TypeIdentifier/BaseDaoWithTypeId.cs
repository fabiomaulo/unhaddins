using NHibernate;
using uNhAddIns.SessionEasier;

namespace uNhAddIns.ApplicationBlocks.DataAccessObjects.TypeIdentifier {
    public class BaseDaoWithTypeId<TEntity, TId> : IDaoWithTypeId<TEntity, TId> {
        readonly ISessionFactoryProvider sfp;

        protected BaseDaoWithTypeId(ISessionFactoryProvider sessionFactoryProvider) {
            sfp = sessionFactoryProvider;
        }

        protected ISession GetSession() {
            return sfp.GetFactory(Alias).GetCurrentSession();
        }

        public TEntity Get(TId id) {
            return GetSession().Get<TEntity>(id);
        }

        /// <summary>
        /// support multi factory
        /// </summary>
        public string Alias { get; set; }
    }
}