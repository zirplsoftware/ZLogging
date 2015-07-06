using System;

namespace Zirpl.Logging
{
    /// <summary>
    /// An empty <see cref="ILog"/> implementation for cases 
    /// where logging has not been configured. No messages will be logged.
    /// </summary>
    internal sealed class NullLog : LogBase
    {
        protected override void WriteMessageToLog(LogLevel logLevel, object message, Exception exception = null)
        {
        }

        protected override bool IsLogLevelEnabled(LogLevel logLevel)
        {
            return false;
        }
    }
}
