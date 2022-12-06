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

        public Message(ulong messageCode = 0, string messageText="",  params object[] parameters)
        {
            MessageText = messageText ?? string.Empty;
            MessageCode = messageCode == 0
                ? new MessageCode(Convert.ToUInt64(messageText.GetHashCode())) 
                : new MessageCode(messageCode);
            MessageTime = DateTime.UtcNow;
            Parameters = parameters.Select(o => o.ToString()).ToArray();
        }

        public Message(MessageCode messageCode, string messageText, params object[] parameters)
        {
            MessageText = messageText ?? string.Empty;
            MessageCode = messageCode;
            MessageTime = DateTime.UtcNow;
            Parameters = parameters.Select(o => o.ToString()).ToArray();
        }

        public string MessageText { 
            get; 
            private set; 
        }
        public MessageCode MessageCode { get;
#if NET5_0_OR_GREATER
            init; 
#else 
            private set;
#endif
        }
        public string[] Parameters { get;
#if NET5_0_OR_GREATER
            init; 
#else
            private set;
#endif
        }
        public DateTime MessageTime { get;
#if NET5_0_OR_GREATER
            init; 
#else 
            private set;
#endif
        }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(MessageText)) {
                 MessageText = MessageVault.GetMessage(MessageCode.MessageHash()); }
            return string.Format(MessageText, Parameters);
        }
        public string ToString(CultureInfo culture)
        {
            if (string.IsNullOrWhiteSpace(MessageText))
            {
                MessageText = MessageVault.GetMessage(MessageCode.MessageHash(),culture);
            }
            return string.Format(MessageText, Parameters);
        }
    }
}