using System;
using System.Reflection;
using AopAlliance.Intercept;
using uNhAddIns.Adapters.Common;
using uNhAddIns.SessionEasier.Conversations;

namespace uNhAddIns.SpringAdapters.AutomaticConversationManagement
{
    class ConversationInterceptor : AbstractConversationInterceptor, IMethodInterceptor
    {
        private Type targetImplementation;
        private IConversationCreationInterceptor _conversationCreationInterceptor;

        #region Implementation of IMethodInterceptor
        public ConversationInterceptor(IConversationInterceptorConfigurationProvider configurationProvider ) :
            this(configurationProvider.MetaStore, configurationProvider.ContainerAccessor,
            configurationProvider.ConversationFactory, configurationProvider.CreationInterceptor)
        {
            
        }

        public ConversationInterceptor(IConversationalMetaInfoStore metadataStore,
            IConversationsContainerAccessor conversationsContainerAccessor,
            IConversationFactory conversationFactory,
            IConversationCreationInterceptor conversationCreationInterceptor)
            : base(metadataStore, conversationsContainerAccessor, conversationFactory)
        {
            ConversationCreationInterceptor = conversationCreationInterceptor;
        }

        public IConversationCreationInterceptor ConversationCreationInterceptor
        {
            set { _conversationCreationInterceptor = value; }
        }

        public object Invoke(IMethodInvocation invocation)
        {
            MethodInfo methodInfo = invocation.Method;
            targetImplementation = invocation.TargetType;
            BeforeMethodExecution(methodInfo);
            try
            {
                object retValue = invocation.Proceed();
                AfterMethodExecution(methodInfo);
                return retValue;
            }
            catch (Exception)
            {
                DisposeConversationOnException();
                throw;
            }
        }

        protected override Type GetConversationalImplementor()
        {
            return targetImplementation;
        }

        protected override IConversationCreationInterceptor GetConversationCreationInterceptor(Type configuredConcreteType)
        {
            return _conversationCreationInterceptor;
        }
        #endregion
    }
}
