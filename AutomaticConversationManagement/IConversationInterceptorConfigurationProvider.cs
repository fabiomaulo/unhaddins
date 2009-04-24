using uNhAddIns.Adapters.Common;
using uNhAddIns.SessionEasier.Conversations;

namespace uNhAddIns.SpringAdapters.AutomaticConversationManagement
{
    public interface IConversationInterceptorConfigurationProvider
    {
        /// <summary>
        /// Gets the meta info store.
        /// </summary>
        /// <value>The meta info store.</value>
        IConversationalMetaInfoStore MetaStore { get; }
        /// <summary>
        /// Gets the container accessor.
        /// </summary>
        /// <value>The container accessor.</value>
        IConversationsContainerAccessor ContainerAccessor { get; }
        /// <summary>
        /// Gets the conversation factory.
        /// </summary>
        /// <value>The conversation factory.</value>
        IConversationFactory ConversationFactory { get; }
        /// <summary>
        /// Gets the creation interceptor.
        /// </summary>
        /// <value>The creation interceptor.</value>
        IConversationCreationInterceptor CreationInterceptor { get; }
    }
}