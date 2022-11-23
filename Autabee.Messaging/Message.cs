using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Autabee.Utility
{
    public class Message 
    {
        public Message()
        {
            
        }
        public Message(ulong messageCode = 0, string messageText="",  params string[] parameters)
        {
            MessageText = messageText ?? string.Empty;
            MessageCode = messageCode == 0
                ? new MessageCode(Convert.ToUInt64(messageText.GetHashCode())) 
                : new MessageCode(messageCode);
            MessageTime = DateTime.UtcNow;
            Parameters = parameters;
            messageText.GetHashCode();
        }

        public Message(MessageCode messageCode, string messageText, params string[] parameters)
        {
            MessageText = messageText ?? string.Empty;
            MessageCode = messageCode;
            MessageTime = DateTime.UtcNow;
            Parameters = parameters;
            messageText.GetHashCode();
        }

        public string MessageText { get; private set; }
        public MessageCode MessageCode { get; init; }
        public string[] Parameters { get; init; }
        public DateTime MessageTime { get; init; }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(MessageText)) {
                 MessageText =MessageVault.GetMessage(MessageCode.MessageHash()); }
            return string.Format(MessageText, Parameters);
        }
    }
}