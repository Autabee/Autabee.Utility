using Autabee.Utility.Messaging;
using Serilog;
using Serilog.Events;
using System;

namespace Autabee.Utility.Logger.Serilog
{
    public class AutabeeSerilogLogger : IAutabeeLogger
    {
        public readonly ILogger logger;

        public AutabeeSerilogLogger(ILogger logger)
        {
            this.logger = logger;
        }

        public void Error(string message, params object[] values)
            => logger.Error(message, values);

        public void Error(string message, Exception e, params object[] values)
            => logger.Error(e, message, values);

        public void Fatal(string message, params object[] values)
            => logger.Fatal(message, values);

        public void Fatal(string message, Exception e, params object[] values)
            => logger.Fatal(e, message, values);

        public void Information(string message, params object[] values)
            => logger.Information(message, values);

        public void Information(string message, Exception e, params object[] values)
            => logger.Information(e, message, values);


        LogEventLevel MessageLevelToLogEventLevel(MessageLevel level)
        {
            switch (level)
            {
                case MessageLevel.Debug:
                    return LogEventLevel.Debug;
                case MessageLevel.Error:
                    return LogEventLevel.Error;
                case MessageLevel.Fatal:
                    return LogEventLevel.Fatal;
                case MessageLevel.Info:
                    return LogEventLevel.Information;
                case MessageLevel.Warning:
                    return LogEventLevel.Warning;
                default:
                    return LogEventLevel.Verbose;
            }
        }
        public void Log(Message message)
        {
            logger.Write(MessageLevelToLogEventLevel(message.Level), message.ToString());
        }

        public void Log(Message message, Exception e)
        {
            throw new NotImplementedException();
        }

        public void Warning(string message, params object[] values)
            => logger.Warning(message, values);
        public void Warning(string message, Exception e, params object[] values)
            => logger.Warning(e, message, values);

    }
}