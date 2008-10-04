namespace uNhAddIns.SessionEasier.Conversations
{
	public class DefaultConversationFactory : IConversationFactory
	{
		private readonly ISessionFactoryProvider factoriesProvider;

		public DefaultConversationFactory(ISessionFactoryProvider factoriesProvider)
		{
			this.factoriesProvider = factoriesProvider;
		}

		#region Implementation of IConversationFactory

		public IConversation CreateConversation()
		{
			return new NhConversation(factoriesProvider);
		}

		public IConversation CreateConversation(string conversationId)
		{
			return new NhConversation(factoriesProvider, conversationId);
		}

		#endregion
	}
}