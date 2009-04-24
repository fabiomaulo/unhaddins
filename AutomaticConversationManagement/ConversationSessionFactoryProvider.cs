using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using log4net;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Connection;
using NHibernate.Engine;
using NHibernate.Util;
using Spring.Data.Common;
using Spring.Data.NHibernate;
using uNhAddIns.SessionEasier;

namespace uNhAddIns.SpringAdapters.AutomaticConversationManagement
{
    public class ConversationSessionFactoryProvider : LocalSessionFactoryObject, ISessionFactoryProvider
    {
        private new static readonly ILog log = LogManager.GetLogger(typeof(ConversationSessionFactoryProvider));

        private IEnumerable<ISessionFactory> sessionFactories;
        private ISessionFactory sessionFactory;
        
        #region Implementation of IEnumerable
        public IEnumerator<ISessionFactory> GetEnumerator()
        {
            Initialize();
            return sessionFactories.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        #region Implementation of ISessionFactoryProvider
        public event EventHandler<EventArgs> BeforeCloseSessionFactory;
        public ISessionFactory GetFactory(string factoryId)
        {
            Initialize();
            return sessionFactory;
        }

        public void Initialize()
        {
            if (sessionFactory == null)
            {
                log.Debug("Initialize a new session factory reading the configuration.");
                sessionFactory = (ISessionFactory) GetObject();
                sessionFactories = new SingletonEnumerable<ISessionFactory>(sessionFactory);
                log.Debug("Initialized a new session factory reading the configuration.");
            }
        }

        private void DoBeforeCloseSessionFactory()
        {
            if (BeforeCloseSessionFactory != null)
            {
                BeforeCloseSessionFactory(this, new EventArgs());
            }
        }
        #endregion

        #region IDisposable
        private bool disposed;

        public new void Dispose()
        {
            Dispose(true);
            base.Dispose();
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (sessionFactory != null)
                    {
                        DoBeforeCloseSessionFactory();
                        sessionFactory.Close();
                        sessionFactory = null;
                    }
                }
                disposed = true;
            }
        }
        #endregion

        /// <summary>
        /// Subclasses can override this method to perform custom initialization
        /// of the SessionFactory instance, creating it via the given Configuration
        /// object that got prepared by this LocalSessionFactoryObject.
        /// </summary>
        /// <remarks>
        /// <p>The default implementation invokes Configuration's BuildSessionFactory.
        /// A custom implementation could prepare the instance in a specific way,
        /// or use a custom ISessionFactory subclass.
        /// </p>
        /// </remarks>
        /// <note>
        /// Nieve Goor 21/04/09: taken from the latest Nightly build.
        /// </note>
        /// <returns>The ISessionFactory instance.</returns>
        protected override ISessionFactory NewSessionFactory(Configuration config)
        {
            ISessionFactory sf = config.BuildSessionFactory();
            ISessionFactoryImplementor sfImplementor = sf as ISessionFactoryImplementor;
            if (sfImplementor != null)
            {
                DbProviderWrapper dbProviderWrapper = sfImplementor.ConnectionProvider as DbProviderWrapper;

                if (dbProviderWrapper != null)
                {
                    dbProviderWrapper.DbProvider = DbProvider;
                }
            }
            return sf;
        }

        #region DbProviderWrapper Helper class
        private class DbProviderWrapper : ConnectionProvider
        {
            private IDbProvider _dbProvider;

            public DbProviderWrapper()
            {
            }

            public IDbProvider DbProvider
            {
                get { return _dbProvider; }
                set { _dbProvider = value; }
            }

            public override void CloseConnection(IDbConnection conn)
            {
                base.CloseConnection(conn);
                conn.Dispose();
            }

            public override IDbConnection GetConnection()
            {
                IDbConnection dbCon = _dbProvider.CreateConnection();
                dbCon.Open();
                return dbCon;
            }
        }
        #endregion

    }
}
