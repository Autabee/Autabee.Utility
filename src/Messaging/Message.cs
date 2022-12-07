using System;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;

namespace Autabee.Utility.Messaging
{
#if NET5_0_OR_GREATER
    public record Message
#else
    public class Message
#endif
    {
        public Message()
        {

        }

        public Message(MessageLevel level = MessageLevel.None, string text = "", params object[] parameters)
        {
            Text = text ?? string.Empty;
            Level = level;
            Time = DateTime.UtcNow;
            Parameters = parameters.Select(o => o.ToString()).ToArray();
        }

        public string Text
        {
            get;
            private set;
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
        public DateTime Time
        {
            get;
#if NET5_0_OR_GREATER
            init; 
#else 
            private set;
#endif
        }

        public override string ToString()
        {
            return string.Format(Text, Parameters);
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