using System;
using System.Linq;

namespace Autabee.Utility.Messaging
{
    /// <summary>
    /// Default message levels
    /// </summary>
    [Flags]
    public enum MessageLevels : ulong
    {
        None =    0,
        Trace =   0x4000_0000_0000_0000,
        Debug =   0x2000_0000_0000_0000,
        Info =    0x1000_0000_0000_0000,
        Warning = 0x0800_0000_0000_0000,
        Error =   0x0400_0000_0000_0000,
        Fatal =   0x0200_0000_0000_0000
    }
}