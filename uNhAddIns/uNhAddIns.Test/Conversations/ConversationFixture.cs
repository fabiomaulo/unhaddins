using System;
using log4net.Config;
using log4net.Core;
using NUnit.Framework;
using NUnit.Framework.Syntax.CSharp;
using uNhAddIns.SessionEasier.Conversations;

namespace uNhAddIns.Test.Conversations
{
	[TestFixture]
	public class ConversationFixture
	{
		public ConversationFixture()
		{
			XmlConfigurator.Configure();
		}

		[Test]
		public void Ctors()
		{
			Assert.That((new TestConversation()).Id, Is.Not.Null);
			Assert.Throws<ArgumentNullException>(() => new TestConversation(null));
			Assert.Throws<ArgumentNullException>(() => new TestConversation(""));
		}

		[Test]
		public void Equality()
		{
			var t = new TestConversation();
			Assert.That(t.Equals(t));
			Assert.That(!t.Equals(new TestConversation()));
			Assert.That(!t.Equals(null));
			Assert.That(!t.Equals(new object()));

			string key1 = "ModelName" + Guid.NewGuid();
			string key2 = "ModelName" + Guid.NewGuid();
			t = new TestConversation(key1);
			Assert.That(t.Equals(new TestConversation(key1)));
			Assert.That(!t.Equals(new TestConversation(key2)));
		}

		[Test]
		public void HashCode()
		{
			string key1 = "ModelName" + Guid.NewGuid();
			var t = new TestConversation(key1);
			Assert.That(t.GetHashCode(), Is.EqualTo(key1.GetHashCode()));
		}

		[Test]
		public void StartCallSequence()
		{
			// I'm using log instad a mock, I know
			using (var t = new TestConversation())
			{
				t.Starting += ((x, y) => t.Log.Debug("Starting called."));
				t.Started += ((x, y) => t.Log.Debug("Started called."));
				using (var ls = new LogSpy(typeof (TestConversation)))
				{
					t.Start();
					LoggingEvent[] msgs = ls.Appender.GetEvents();
					Assert.That(msgs.Length, Is.EqualTo(3));
					Assert.That(msgs[0].RenderedMessage, Text.Contains("Starting called."));
					Assert.That(msgs[1].RenderedMessage, Text.Contains("DoStart called."));
					Assert.That(msgs[2].RenderedMessage, Text.Contains("Started called."));
				}
			}
		}

		[Test]
		public void PauseCallSequence()
		{
			using (var t = new TestConversation())
			{
				t.Pausing += ((x, y) => t.Log.Debug("Pausing called."));
				t.Paused += ((x, y) => t.Log.Debug("Paused called."));
				using (var ls = new LogSpy(typeof (TestConversation)))
				{
					t.Pause();
					LoggingEvent[] msgs = ls.Appender.GetEvents();
					Assert.That(msgs.Length, Is.EqualTo(3));
					Assert.That(msgs[0].RenderedMessage, Text.Contains("Pausing called."));
					Assert.That(msgs[1].RenderedMessage, Text.Contains("DoPause called."));
					Assert.That(msgs[2].RenderedMessage, Text.Contains("Paused called."));
				}
			}
		}

		[Test]
		public void PauseAndFlushCallSequence()
		{
			using (var t = new TestConversation())
			{
				t.Pausing += ((x, y) => t.Log.Debug("Pausing called."));
				t.Paused += ((x, y) => t.Log.Debug("Paused called."));
				using (var ls = new LogSpy(typeof (TestConversation)))
				{
					t.FlushAndPause();
					LoggingEvent[] msgs = ls.Appender.GetEvents();
					Assert.That(msgs.Length, Is.EqualTo(3));
					Assert.That(msgs[0].RenderedMessage, Text.Contains("Pausing called."));
					Assert.That(msgs[1].RenderedMessage, Text.Contains("DoPauseAndFlush called."));
					Assert.That(msgs[2].RenderedMessage, Text.Contains("Paused called."));
				}
			}
		}

		[Test]
		public void ResumeCallSequence()
		{
			using (var t = new TestConversation())
			{
				t.Resuming += ((x, y) => t.Log.Debug("Resuming called."));
				t.Resumed += ((x, y) => t.Log.Debug("Resumed called."));
				using (var ls = new LogSpy(typeof (TestConversation)))
				{
					t.Resume();
					LoggingEvent[] msgs = ls.Appender.GetEvents();
					Assert.That(msgs.Length, Is.EqualTo(3));
					Assert.That(msgs[0].RenderedMessage, Text.Contains("Resuming called."));
					Assert.That(msgs[1].RenderedMessage, Text.Contains("DoResume called."));
					Assert.That(msgs[2].RenderedMessage, Text.Contains("Resumed called."));
				}
			}
		}

		[Test]
		public void EndCallSequence()
		{
			using (var t = new TestConversation())
			{
				t.Ending += ((x, y) => t.Log.Debug("Ending called."));
				t.Ended += ((x, y) => t.Log.Debug("Ended called."));
				t.Ended += EndedAssertionOutOfDisposing;
				using (var ls = new LogSpy(typeof (TestConversation)))
				{
					t.End();
					LoggingEvent[] msgs = ls.Appender.GetEvents();
					Assert.That(msgs.Length, Is.EqualTo(3));
					Assert.That(msgs[0].RenderedMessage, Text.Contains("Ending called."));
					Assert.That(msgs[1].RenderedMessage, Text.Contains("DoEnd called."));
					Assert.That(msgs[2].RenderedMessage, Text.Contains("Ended called."));
				}
				t.Ended -= EndedAssertionOutOfDisposing;
			}
		}

		public void EndedAssertionOutOfDisposing(object x, EndedEventArgs y)
		{
			Assert.That(!y.Disposing);
		}

		[Test]
		public void AbortCallSequence()
		{
			using (var t = new TestConversation())
			{
				t.Ending += ((x, y) => t.Log.Debug("Ending called."));
				t.Aborting += ((x, y) => t.Log.Debug("Aborting called."));
				t.Ended += ((x, y) => t.Log.Debug("Ended called."));
				t.Ended += EndedAssertionOutOfDisposing;
				using (var ls = new LogSpy(typeof (TestConversation)))
				{
					t.Abort();
					LoggingEvent[] msgs = ls.Appender.GetEvents();
					Assert.That(msgs.Length, Is.EqualTo(3));
					Assert.That(msgs[0].RenderedMessage, Text.Contains("Aborting called."));
					Assert.That(msgs[1].RenderedMessage, Text.Contains("DoAbort called."));
					Assert.That(msgs[2].RenderedMessage, Text.Contains("Ended called."));
				}
				t.Ended -= EndedAssertionOutOfDisposing;
			}
		}

		[Test]
		public void DisposeCallSequence()
		{
			using (var ls = new LogSpy(typeof (TestConversation)))
			{
				using (var t = new TestConversation())
				{
					t.Ended += ((x, y) => t.Log.Debug("End called."));
					t.Ended += ((x, y) => Assert.That(y.Disposing));
				}
				LoggingEvent[] msgs = ls.Appender.GetEvents();
				Assert.That(msgs.Length, Is.EqualTo(3));
				Assert.That(msgs[0].RenderedMessage, Text.Contains("DoAbort called."));
				Assert.That(msgs[1].RenderedMessage, Text.Contains("End called."));
				Assert.That(msgs[2].RenderedMessage, Text.Contains("Dispose called."));
			}
		}

		public class ConversationError : AbstractConversation
		{
			#region Overrides of AbstractConversation

			protected override void Dispose(bool disposing) {}

			protected override void DoStart()
			{
				throw new NotImplementedException(ConversationAction.Start.ToString());
			}

			protected override void DoFlushAndPause()
			{
				throw new NotImplementedException(ConversationAction.FlushAndPause.ToString());
			}

			protected override void DoPause()
			{
				throw new NotImplementedException(ConversationAction.Pause.ToString());
			}

			protected override void DoResume()
			{
				throw new NotImplementedException(ConversationAction.Resume.ToString());
			}

			protected override void DoEnd()
			{
				throw new NotImplementedException(ConversationAction.End.ToString());
			}

			protected override void DoAbort()
			{
				throw new NotImplementedException(ConversationAction.Abort.ToString());
			}

			#endregion
		}

		[Test]
		public void OnExceptionWithoutReThrow()
		{
			try
			{
				using (var t = new ConversationError())
				{
					t.OnException += AssertException;
					t.Start();
					t.Pause();
					t.FlushAndPause();
					t.Resume();
					t.End();
					t.Abort();
				}
			}
			catch (NotImplementedException)
			{
				// The Abort during Dispose is not managed by the OnException events
			}
		}

		[Test]
		public void OnExceptionReThrow()
		{
			try
			{
				using (var t = new ConversationError())
				{
					Assert.Throws<ConversationException>(t.Start);
					Assert.Throws<ConversationException>(t.Resume);
					Assert.Throws<ConversationException>(t.Pause);
					Assert.Throws<ConversationException>(t.FlushAndPause);
					Assert.Throws<ConversationException>(t.End);
					Assert.Throws<ConversationException>(t.Abort);
				}
			}
			catch (NotImplementedException)
			{
				// The Abort during Dispose
			}
		}

		private static void AssertException(object conversation, OnExceptionEventArgs args)
		{
			Assert.That(args.Exception, Is.InstanceOfType(typeof (NotImplementedException)));
			Assert.That(args.Exception.Message, Is.EqualTo(args.Action.ToString()));
			args.ReThrow = false;
		}
	}
}