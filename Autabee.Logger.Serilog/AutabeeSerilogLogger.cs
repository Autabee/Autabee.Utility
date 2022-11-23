using Autabee.Utility.Logger;
using Serilog;
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

        public void Error(string message, Exception e = null, params object[] values)
        {
            if (e == null)
            {
                logger.Error(message, values);
            }
            else
            {
                logger.Error(e, message, values);
            }
        }

        public void Fatal(string message, Exception e = null, params object[] values)
        {
            if (e == null)
            {
                logger.Fatal(message, values);
            }
            else
            {
                logger.Fatal(e, message, values);
            }
        }

        public void Information(string message, Exception e = null, params object[] values)
        {
            if (e == null)
            {
                logger.Information(message, values);
            }
            else
            {
                logger.Information(e, message, values);
            }
        }

        public void Warning(string message, Exception e = null, params object[] values)
        {
            if (e == null)
            {
                logger.Warning(message, values);
            }
            else
            {
                logger.Warning(e, message, values);
            }
        }
    }
}