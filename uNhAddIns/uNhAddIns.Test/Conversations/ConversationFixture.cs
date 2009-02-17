using System;
using log4net.Config;
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
				t.Starting += ((x, y) => TestConversation.log.Debug("Starting called."));
				t.Started += ((x, y) => TestConversation.log.Debug("Started called."));
				using (var ls = new LogSpy(typeof (TestConversation)))
				{
					t.Start();
					var msgs = ls.Appender.GetEvents();
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
				t.Pausing += ((x, y) => TestConversation.log.Debug("Pausing called."));
				t.Paused += ((x, y) => TestConversation.log.Debug("Paused called."));
				using (var ls = new LogSpy(typeof (TestConversation)))
				{
					t.Pause();
					var msgs = ls.Appender.GetEvents();
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
				t.Pausing += ((x, y) => TestConversation.log.Debug("Pausing called."));
				t.Paused += ((x, y) => TestConversation.log.Debug("Paused called."));
				using (var ls = new LogSpy(typeof(TestConversation)))
				{
					t.PauseAndFlush();
					var msgs = ls.Appender.GetEvents();
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
				t.Resuming += ((x, y) => TestConversation.log.Debug("Resuming called."));
				t.Resumed += ((x, y) => TestConversation.log.Debug("Resumed called."));
				using (var ls = new LogSpy(typeof (TestConversation)))
				{
					t.Resume();
					var msgs = ls.Appender.GetEvents();
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
				t.Ending += ((x, y) => TestConversation.log.Debug("Ending called."));
				t.Ended += ((x, y) => TestConversation.log.Debug("Ended called."));
				t.Ended += EndedAssertionOutOfDisposing;
				using (var ls = new LogSpy(typeof(TestConversation)))
				{
					t.End();
					var msgs = ls.Appender.GetEvents();
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
				t.Ending += ((x, y) => TestConversation.log.Debug("Ending called."));
				t.Aborting += ((x, y) => TestConversation.log.Debug("Aborting called."));
				t.Ended += ((x, y) => TestConversation.log.Debug("Ended called."));
				t.Ended += EndedAssertionOutOfDisposing;
				using (var ls = new LogSpy(typeof(TestConversation)))
				{
					t.Abort();
					var msgs = ls.Appender.GetEvents();
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
			using (var ls = new LogSpy(typeof(TestConversation)))
			{
				using(var t = new TestConversation())
				{
					t.Ended += ((x, y) => TestConversation.log.Debug("End called."));
					t.Ended += ((x, y) => Assert.That(y.Disposing));
				}
				var msgs = ls.Appender.GetEvents();
				Assert.That(msgs.Length, Is.EqualTo(3));
				Assert.That(msgs[0].RenderedMessage, Text.Contains("DoAbort called."));
				Assert.That(msgs[1].RenderedMessage, Text.Contains("End called."));
				Assert.That(msgs[2].RenderedMessage, Text.Contains("Dispose called."));
			}
		}
	}
}