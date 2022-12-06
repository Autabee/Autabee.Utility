using System;
using System.Linq;

namespace Autabee.Utility.Messaging
{
    /// <summary>
    /// Default message filters
    /// </summary>
    public enum MessageFilter : ulong
    {
        ALL = MessageLevels.Trace 
            | MessageLevels.Debug 
            | MessageLevels.Info 
            | MessageLevels.Warning 
            | MessageLevels.Error 
            | MessageLevels.Fatal,
        DebugAndLower =
            MessageLevels.Debug 
            | MessageLevels.Info 
            | MessageLevels.Warning 
            | MessageLevels.Error 
            | MessageLevels.Fatal,
        InfoAndLower =
            MessageLevels.Info 
            | MessageLevels.Warning 
            | MessageLevels.Error 
            | MessageLevels.Fatal,
        WarningAndLower =
            MessageLevels.Warning 
            | MessageLevels.Error 
            | MessageLevels.Fatal,
        ErrorAndLower =
            MessageLevels.Error 
            | MessageLevels.Fatal,
    }
}