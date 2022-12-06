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

        public void Error(string message, Exception e = null, params object[] values)
        {
            Log(LogLevel.Error, message, e, values);
        }

        public void Fatal(string message, Exception e = null, params object[] values)
        {
            Log(LogLevel.Critical, message, e, values);
        }

        public void Information(string message, Exception e = null, params object[] values)
        {
            Log(LogLevel.Information, message, e, values);
        }

        public void Warning(string message, Exception e = null, params object[] values)
        {
            Log(LogLevel.Warning, message, e, values);
        }

        private void Log(LogLevel level, string message, Exception e, object[] values)
        {
            if (e != null)
            {
                logger.Log(level, e, message, values);
            }
            else
            {
                logger.Log(level, message, values);
            }
        }
    }
}