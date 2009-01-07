namespace uNhAddIns.Example.AopConversationUsage.MultiTiers
{
	public interface IServiceLocator
	{
		T Resolve<T>(string key);
		T Resolve<T>();
	}
}