using Autabee.Utility.Messaging;
using Microsoft.Extensions.Logging;
using System;

namespace Autabee.Utility.Logger.Microsoft
{
    public class AutabeeMicrosoftLogger : IAutabeeLogger
    {
        private ILogger logger;

        public AutabeeMicrosoftLogger(ILogger logger)
        {
            this.logger = logger;
        }
        public void Error(string message, params object[] values)
        {
            Log(LogLevel.Error, message, values);
        }

        public void Error(string message, Exception e = null, params object[] values)
        {
            Log(LogLevel.Error, message, e, values);
        }
        public void Fatal(string message, params object[] values)
        {
            Log(LogLevel.Critical, message, values);
        }
        public void Fatal(string message, Exception e = null, params object[] values)
        {
            Log(LogLevel.Critical, message, e, values);
        }

        public void Information(string message, params object[] values)
        {
            Log(LogLevel.Information, message, values);
        }
        public void Information(string message, Exception e, params object[] values)
        {
            Log(LogLevel.Information, message, e, values);
        }
        public void Warning(string message, params object[] values)
        {
            Log(LogLevel.Warning, message, values);
        }
        public void Warning(string message, Exception e, params object[] values)
        {
            Log(LogLevel.Warning, message, e, values);
        }

        private void Log(LogLevel level, string message, Exception e, object[] values)
        {

            logger.Log(level, e, message, values);
        }
        private void Log(LogLevel level, string message, object[] values)
        {
            logger.Log(level, message, values);
        }


        static LogLevel MessageLevelToLogLevel(MessageLevel level)
        {
            switch (level.GetLevel())
            {
                case MessageLevel.Debug:
                    return LogLevel.Debug;
                case MessageLevel.Error:
                    return LogLevel.Error;
                case MessageLevel.Fatal:
                    return LogLevel.Critical;
                case MessageLevel.Info:
                    return LogLevel.Information;
                case MessageLevel.Warning:
                    return LogLevel.Warning;
                case MessageLevel.Trace:
                    return LogLevel.Trace;
                default:
                    return LogLevel.None;
            }
        }
        public void Log(Message message)
        {
            logger.Log(MessageLevelToLogLevel(message.Level), message.Text, message.Parameters);
        }

        public void Log(Message message, Exception e)
        {
            logger.Log(MessageLevelToLogLevel(message.Level), e, message.Text, message.Parameters);
        }
    }
}