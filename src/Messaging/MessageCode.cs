using System;
using System.Runtime.CompilerServices;

namespace Autabee.Utility.Messaging
{
    public struct MessageCode
    {
        public MessageCode(ulong code)
        {
            Code = code;
        }

        public ulong Code { get; }
    }

    public static class MessageCodeExtension {
        public static  MessageLevels Level(this MessageCode code)
        {
            return (MessageLevels)(code.Code & 0x7F00_0000_0000_0000);
        }

        public static int MessageHash(this MessageCode code)
        {
            return Convert.ToInt32(code.Code & 0xFFFF_FFFF);
        }
    }
}
