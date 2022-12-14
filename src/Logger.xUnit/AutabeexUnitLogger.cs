using Autabee.Utility.Messaging;
using System;
using Xunit.Abstractions;

namespace Autabee.Utility.Logger.xUnit
{
    public class AutabeeXunitLogger : IAutabeeLogger
    {
        private ITestOutputHelper logger;

        public AutabeeXunitLogger(ITestOutputHelper logger)
        {
            this.logger = logger;
        }
        public void Error(string message, params object[] values)
        {
            Log("Error", message, values);
        }
        public void Error(string message, Exception e = null, params object[] values)
        {
            Log("Error", message, e, values);
        }
        public void Fatal(string message, params object[] values)
        {
            Log("Fatal", message, values);
        }

        public void Fatal(string message, Exception e = null, params object[] values)
        {
            Log("Fatal", message, e, values);
        }

        public void Information(string message, params object[] values)
        {
            Log("Information", message, values);
        }
        public void Information(string message, Exception e = null, params object[] values)
        {
            Log("Information", message, e, values);
        }
        public void Warning(string message, params object[] values)
        {
            Log("Warning", message, values);
        }

        public void Warning(string message, Exception e = null, params object[] values)
        {
            Log("Warning", message, e, values);
        }

        private void Log(string level, string message, Exception e, object[] values)
        {
            if (e != null)
            {
                logger.WriteLine($"[{level}] {string.Format(message, values)} \r\n{e.Message}\r\n{e.StackTrace}");
            }
            else
            {
                logger.WriteLine($"[{level}] {string.Format(message, values)}");
            }
        }
        private void Log(string level, string message, object[] values)
        {

            logger.WriteLine($"[{level}] {string.Format(message, values)}");

        }

        public void Log(Message message)
        {

            logger.WriteLine($"[{message.Level}] {message}");

        }

        public void Log(Message message, Exception e)
        {
            if (e != null)
            {
                logger.WriteLine($"[{message.Level}] {message} \r\n{e.Message}\r\n{e.StackTrace}");
            }
            else
            {
                logger.WriteLine($"[{message.Level}] {message}");
            }
        }
    }
}