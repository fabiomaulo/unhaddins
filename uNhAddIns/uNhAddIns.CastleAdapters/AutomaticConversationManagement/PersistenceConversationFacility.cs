using Castle.MicroKernel.Facilities;

namespace uNhAddIns.CastleAdapters.AutomaticConversationManagement
{
	public class PersistenceConversationFacility : AbstractFacility
	{
		protected override void Init()
		{
			Kernel.AddComponent("uNhAddIns.conversation.interceptor", typeof(ConversationInterceptor));
			Kernel.AddComponent("uNhAddIns.conversation.MetaInfoStore", typeof(ConversationMetaInfoStore));
			Kernel.ComponentModelBuilder.AddContributor(new PersistenceConversationalComponentInspector());
		}
	}
}