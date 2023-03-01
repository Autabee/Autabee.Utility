using Autabee.Utility.Messaging;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;

namespace Autabee.Utility.Logger
{
    public static class AutabeeSerilogLoggerExtension
    {
        static public LogEventLevel MessageEventLevel(Message msg)
        {
            return MessageLevelToLogEventLevel(msg.Level);
        }
        static public LogEventLevel MessageLevelToLogEventLevel(MessageLevel level)
        {
            switch (level)
            {
                case MessageLevel.Fatal:
                    return LogEventLevel.Fatal;
                case MessageLevel.Error:
                    return LogEventLevel.Error;
                case MessageLevel.Warning:
                    return LogEventLevel.Warning;
                case MessageLevel.Info:
                    return LogEventLevel.Information;
                case MessageLevel.Debug:
                    return LogEventLevel.Debug;
                default:
                    return LogEventLevel.Verbose;
            }
        }
        public static void Log(this Serilog.Core.Logger logger, Message message)
        {
            if (message.Exception == null)
            {
                logger.Write(MessageLevelToLogEventLevel(message.Level), message.ToString());
            }
            else
            {

                logger.Write(MessageLevelToLogEventLevel(message.Level), message.Exception, message.ToString());
            }
        }
        public static void Log(this ILogger logger, Message message)
        {
            if (message.Exception == null)
            {
                switch (MessageEventLevel(message))
                {
                    case LogEventLevel.Fatal:
                        logger.Fatal(message.ToString());
                        break;
                    case LogEventLevel.Verbose:
                        logger.Verbose(message.ToString());
                        break;
                    case LogEventLevel.Debug:
                        logger.Debug(message.ToString());
                        break;
                    case LogEventLevel.Information:
                        logger.Information(message.ToString());
                        break;
                    case LogEventLevel.Warning:
                        logger.Warning(message.ToString());
                        break;
                    case LogEventLevel.Error:
                        logger.Error(message.ToString());
                        break;
                }
            }
            else
            {
                switch (MessageEventLevel(message))
                {
                    case LogEventLevel.Fatal:
                        logger.Fatal(message.Exception, message.ToString());
                        break;
                    case LogEventLevel.Verbose:
                        logger.Verbose(message.Exception, message.ToString());
                        break;
                    case LogEventLevel.Debug:
                        logger.Debug(message.Exception, message.ToString());
                        break;
                    case LogEventLevel.Information:
                        logger.Information(message.Exception, message.ToString());
                        break;
                    case LogEventLevel.Warning:
                        logger.Warning(message.Exception, message.ToString());
                        break;
                    case LogEventLevel.Error:
                        logger.Error(message.Exception, message.ToString());
                        break;
                }
            }
        }
    }
}
