using log4net;
using uNhAddIns.Conversations;

namespace uNhAddIns.Test.Conversations
{
	public class TestConversation : AbstractConversation
	{
		internal static readonly ILog log = LogManager.GetLogger(typeof (TestConversation));

		public TestConversation() {}
		public TestConversation(string id) : base(id) {}

		#region Overrides of AbstractConversation

		protected override void Dispose(bool disposing)
		{
			log.Debug("Dispose called.");
		}

		protected override void DoStart()
		{
			log.Debug("DoStart called.");
		}

		protected override void DoPause()
		{
			log.Debug("DoPause called.");
		}

		protected override void DoResume()
		{
			log.Debug("DoResume called.");
		}

		protected override void DoEnd()
		{
			log.Debug("DoEnd called.");
		}

		#endregion
	}
}