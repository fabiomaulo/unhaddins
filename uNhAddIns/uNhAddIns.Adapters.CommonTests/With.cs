using System;
using System.Collections.Generic;

namespace uNhAddIns.Adapters.CommonTests
{
    public class With
    {
        public static ICollection<string> Logging(string loggerName, Action workToLog)
        {
            using (var spy = new LogSpy(loggerName))
            {
                workToLog();
                return spy.GetMessages();
            }
        }
    }
}