using System;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;

namespace Autabee.Utility.Messaging
{

    public struct Message
    {
        public Message()
        {

        }
        
        public Message(MessageLevel level = MessageLevel.None, string text = "", params object[] parameters)
        {
            this.Exception = null;
            Text = text ?? string.Empty;
            Level = level;
            Time = DateTime.UtcNow;
            Parameters = parameters.Select(o => o.ToString()).ToArray();
        }

        public Message(MessageLevel level = MessageLevel.None, Exception exception = null, string text = "", params object[] parameters)
        {
            this.Exception = exception;
            Text = text ?? string.Empty;
            Level = level;
            Time = DateTime.UtcNow;
            Parameters = parameters.Select(o => o.ToString()).ToArray();
        }

        public override string ToString()
        {
            return string.Format(Text, Parameters);
        }

        public Exception Exception
        {
            get;
#if NET5_0_OR_GREATER
            init;
#else
            private set;
#endif
        }
        public MessageLevel Level
        {
            get;
#if NET5_0_OR_GREATER
            init; 
#else 
            private set;
#endif
        }
        public string[] Parameters
        {
            get;
#if NET5_0_OR_GREATER
            init; 
#else
            private set;
#endif
        }

        public string Text
        {
            get;
#if NET5_0_OR_GREATER
            init;
#else
            private set;
#endif
        }
        public DateTime Time
        {
            get;
#if NET5_0_OR_GREATER
            init; 
#else 
            private set;
#endif
        }
        //public string ToString(CultureInfo culture)
        //{
        //    if (string.IsNullOrWhiteSpace(Text))
        //    {
        //        //MessageText = MessageVault.GetMessage(MessageCode.MessageHash(),culture);
        //    }
        //    return string.Format(Text, Parameters);
        //}
    }
}