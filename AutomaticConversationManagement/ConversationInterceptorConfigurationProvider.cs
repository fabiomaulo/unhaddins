using uNhAddIns.Adapters.Common;
using uNhAddIns.LinFuAdapters;
using uNhAddIns.SessionEasier;
using uNhAddIns.SessionEasier.Conversations;

namespace uNhAddIns.SpringAdapters.AutomaticConversationManagement
{
    public class ConversationInterceptorConfigurationProvider : IConversationInterceptorConfigurationProvider
    {
        #region Fields
        private IConversationalMetaInfoStore _metaStore;
        private IConversationsContainerAccessor _containerAccessor;
        private readonly ISessionFactoryProvider _sessionFactoryProvider = new ConversationSessionFactoryProvider();
        private IConversationFactory _conversationFactory;
        private readonly ISessionWrapper _sessionWrapper = new SessionWrapper();
        private readonly IConversationCreationInterceptor _creationInterceptor;
        #endregion
        
        public ConversationInterceptorConfigurationProvider(IConversationCreationInterceptor creationInterceptor)
        {
            _creationInterceptor = creationInterceptor;
        }

        #region Implementation of IConversationInterceptorConfigurationProvider
        /// <summary>
        /// Gets a meta info store.
        /// </summary>
        /// <value>The meta info store.</value>
        public IConversationalMetaInfoStore MetaStore
        {
            get
            {
                if (_metaStore == null)
                {
                    _metaStore = new ConversationalMetaInfoStore();
                }
                return _metaStore;
            }
        }

        /// <summary>
        /// Gets the container accessor.
        /// </summary>
        /// <value>The container accessor.</value>
        public IConversationsContainerAccessor ContainerAccessor
        {
            get
            {
                if (_containerAccessor == null)
                {
                    _containerAccessor = new NhConversationsContainerAccessor(_sessionFactoryProvider);
                }
                return _containerAccessor;
            }
        }

        /// <summary>
        /// Gets the conversation factory.
        /// </summary>
        /// <value>The conversation factory.</value>
        public IConversationFactory ConversationFactory
        {
            get
            {
                if (_conversationFactory == null)
                {
                    _conversationFactory = new DefaultConversationFactory(_sessionFactoryProvider, _sessionWrapper);
                }
                return _conversationFactory;
            }
        }

        /// <summary>
        /// Gets the creation interceptor.
        /// </summary>
        /// <value>The creation interceptor.</value>
        public IConversationCreationInterceptor CreationInterceptor
        {
            get { return _creationInterceptor; }
        }
        #endregion
    }
}