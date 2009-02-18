using System;
using System.Text;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Repository.Hierarchy;

namespace uNhAddIns.CastleAdapters.Tests
{
	public class LogSpy : IDisposable
	{
		private readonly MemoryAppender appender;
		private readonly Logger logger;
		private readonly Level prevLogLevel;

		public LogSpy(ILog log)
		{
			logger = log.Logger as Logger;
			if (logger == null)
			{
				throw new Exception("Unable to get the SQL logger");
			}

			// Change the log level to DEBUG and temporarily save the previous log level
			prevLogLevel = logger.Level;
			logger.Level = Level.Debug;

			// Add a new MemoryAppender to the logger.
			appender = new MemoryAppender();
			logger.AddAppender(appender);
		}

		public LogSpy(Type loggerType) : this(LogManager.GetLogger(loggerType)) {}

		public LogSpy(string loggerName) : this(LogManager.GetLogger(loggerName)) {}

		public MemoryAppender Appender
		{
			get { return appender; }
		}

		public string GetWholeMessages()
		{
			StringBuilder wholeMessage = new StringBuilder();
			foreach (LoggingEvent loggingEvent in Appender.GetEvents())
			{
				string singleMessage = loggingEvent.RenderedMessage;
				wholeMessage.Append(singleMessage);
			}
			return wholeMessage.ToString();
		}

		#region IDisposable Members

		public void Dispose()
		{
			// Restore the previous log level of the SQL logger and remove the MemoryAppender
			logger.RemoveAppender(appender);
			logger.Level = prevLogLevel;
		}

		#endregion
	}
}