using System;

namespace Autabee.Utility.Logger
{
    public interface IAutabeeLogger
    {
        void Error(string message, Exception e = null, params object[] values);

        void Warning(string message, Exception e = null, params object[] values);

        void Fatal(string message, Exception e = null, params object[] values);

        void Information(string message, Exception e = null, params object[] values);
    }
}