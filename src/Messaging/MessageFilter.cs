using System;
using System.Linq;

namespace Autabee.Utility.Messaging
{
    /// <summary>
    /// Default message filters
    /// </summary>
    public enum MessageFilter : ushort
    {
        ALL = MessageLevel.Trace 
            | MessageLevel.Debug 
            | MessageLevel.Info 
            | MessageLevel.Warning 
            | MessageLevel.Error 
            | MessageLevel.Fatal,
        Debug =
            MessageLevel.Debug 
            | MessageLevel.Info 
            | MessageLevel.Warning 
            | MessageLevel.Error 
            | MessageLevel.Fatal,
        Info =
            MessageLevel.Info 
            | MessageLevel.Warning 
            | MessageLevel.Error 
            | MessageLevel.Fatal,
        Warning =
            MessageLevel.Warning 
            | MessageLevel.Error 
            | MessageLevel.Fatal,
        Error =
            MessageLevel.Error 
            | MessageLevel.Fatal,
        Fatal =
            MessageLevel.Fatal,
    }
}