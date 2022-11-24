using System;

namespace Autabee.Utility
{
    public struct MessageCode
    {
        public MessageCode(ulong code)
        {
            Code = code;
        }

        public ulong Code { get; }

        public MessageLevels Level()
        {
            return (MessageLevels)(Code & 0x7F00_0000_0000_0000);
        }

        public int MessageHash()
        {
            return Convert.ToInt32(Code & 0xFFFF_FFFF);
        }
    }

}
