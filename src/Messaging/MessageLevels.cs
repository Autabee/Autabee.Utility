using System;
using System.Linq;

namespace Autabee.Utility.Messaging
{
    /// <summary>
    /// Default message levels
    /// </summary>
    [Flags]
    public enum MessageLevel : ushort
    {
        None = 2,
        Trace = 4,
        Debug = 8,
        Info = 16,
        Warning = 32,
        Error = 64,
        Fatal = 128,
    }
    
    public static class MessageLevelExtensions
    {
        public static MessageLevel GetLevel(this MessageLevel level)
        {
            if ((level & MessageLevel.Fatal) > 0)
                return MessageLevel.Fatal;
            if ((level & MessageLevel.Error) > 0)
                return MessageLevel.Error;
            if ((level & MessageLevel.Warning) > 0)
                return MessageLevel.Warning;
            if ((level & MessageLevel.Info) > 0)
                return MessageLevel.Info;
            if ((level & MessageLevel.Debug) > 0)
                return MessageLevel.Debug;
            if ((level & MessageLevel.Trace) > 0)
                return MessageLevel.Trace;
            return MessageLevel.None;
        }
        public static (MessageLevel,ushort) SplitEncoding(this MessageLevel level)
        {
            var lvl = level.GetLevel();
            return (lvl, (ushort)(lvl ^ level));
        }
        public static bool IsEnabled(this MessageLevel level, MessageLevel filter)
        {
            return (level & filter) == level;
        }
    }
}