using Autabee.Utility.Messaging;
using System;

namespace Autabee.Utility.Logger
{
    public interface IAutabeeLogger
    {
        void Error(string message, params object[] values);
        void Error(string message, Exception e, params object[] values);

        void Warning(string message, params object[] values);
        void Warning(string message, Exception e, params object[] values);

        void Fatal(string message, params object[] values);
        void Fatal(string message, Exception e, params object[] values);
        
        void Information(string message, params object[] values);
        void Information(string message, Exception e, params object[] values);
        
        void Log(Message message);
        void Log(Message message, Exception e);
    }
}