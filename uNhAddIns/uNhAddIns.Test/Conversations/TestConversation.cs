using log4net;
using uNhAddIns.SessionEasier.Conversations;

namespace uNhAddIns.Test.Conversations
{
	public class TestConversation : AbstractConversation
	{
		public TestConversation() {}

		public TestConversation(string id) : base(id) {}

		public ILog Log
		{
			get { return LogManager.GetLogger(typeof (TestConversation)); }
		}

		#region Overrides of AbstractConversation

		protected override void Dispose(bool disposing)
		{
			if (disposing && Log.IsDebugEnabled)
			{
				Log.Debug("Dispose called.");
			}
		}

		protected override void DoStart()
		{
			if (Log.IsDebugEnabled)
			{
				Log.Debug("DoStart called.");
			}
		}

		protected override void DoPause()
		{
			if (Log.IsDebugEnabled)
			{
				Log.Debug("DoPause called.");
			}
		}

		protected override void DoFlushAndPause()
		{
			if (Log.IsDebugEnabled)
			{
				Log.Debug("DoPauseAndFlush called.");
			}
		}

		protected override void DoResume()
		{
			if (Log.IsDebugEnabled)
			{
				Log.Debug("DoResume called.");
			}
		}

		protected override void DoEnd()
		{
			if (Log.IsDebugEnabled)
			{
				Log.Debug("DoEnd called.");
			}
		}

		protected override void DoAbort()
		{
			if (Log.IsDebugEnabled)
			{
				Log.Debug("DoAbort called.");
			}
		}

		#endregion
	}
}