using log4net;
using uNhAddIns.SessionEasier.Conversations;

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
			if (log.IsDebugEnabled)
				log.Debug("Dispose called.");
		}

		protected override void DoStart()
		{
			if (log.IsDebugEnabled)
				log.Debug("DoStart called.");
		}

		protected override void DoPause()
		{
			if (log.IsDebugEnabled)
				log.Debug("DoPause called.");
		}

		protected override void DoResume()
		{
			if (log.IsDebugEnabled)
				log.Debug("DoResume called.");
		}

		protected override void DoEnd()
		{
			if (log.IsDebugEnabled)
				log.Debug("DoEnd called.");
		}

		protected override void DoAbort()
		{
			if (log.IsDebugEnabled)
				log.Debug("DoAbort called.");
		}

		#endregion
	}
}