using uNhAddIns.Example.ConversationUsage.MultiTiers;

namespace uNhAddIns.Example.ConversationUsage
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			AppConfigure();
		}

		private static void AppConfigure()
		{
			var sl = new HomeMadeServiceLocator();
		}
	}
}