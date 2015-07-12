using System;

namespace Zirpl.Logging.Common
{
    /// <summary>
    /// Wraps a Common.Logging.ILog in a Zirpl.Logging.ILog
    /// </summary>
    public sealed class LogWrapper :LogBase
    {
        private readonly global::Common.Logging.ILog _log;

        /// <summary>
        /// Creates a new LogWrapper
        /// </summary>
        /// <param name="log">The Common.Logging.ILog to wrap</param>
        public LogWrapper(global::Common.Logging.ILog log)
        {
            this._log = log;
        }

        /// <summary>
        /// Logs the message at the specified LogLevel
        /// </summary>
        /// <param name="logLevel">The LogLevel at which to log the message</param>
        /// <param name="message">The log message</param>
        /// <param name="exception">An optional exception</param>
        protected override void WriteMessageToLog(LogLevel logLevel, object message, Exception exception = null)
        {
            switch (logLevel)
            {
                case LogLevel.Trace:
                    if (exception != null)
                    {
                        _log.Trace(message == null ? null : message.ToString(), exception);
                    }
                    else
                    {
                        _log.Trace(message);
                    }
                    break;
                case LogLevel.Debug: 
                    if (exception != null)
                    {
                        _log.Debug(message == null ? null : message.ToString(), exception);
                    }
                    else
                    {
                        _log.Debug(message);
                    }
                    break;
                case LogLevel.Info:
                    if (exception != null)
                    {
                        _log.Info(message == null ? null : message.ToString(), exception);
                    }
                    else
                    {
                        _log.Info(message);
                    }
                    break;
                case LogLevel.Warn:
                    if (exception != null)
                    {
                        _log.Warn(message == null ? null : message.ToString(), exception);
                    }
                    else
                    {
                        _log.Warn(message);
                    }
                    break;
                case LogLevel.Error:
                    if (exception != null)
                    {
                        _log.Error(message == null ? null : message.ToString(), exception);
                    }
                    else
                    {
                        _log.Error(message);
                    }
                    break;
                case LogLevel.Fatal:
                    if (exception != null)
                    {
                        _log.Fatal(message == null ? null : message.ToString(), exception);
                    }
                    else
                    {
                        _log.Fatal(message);
                    }
                    break;
            }
        }

        /// <summary>
        /// Checks if the specified log level is enabled
        /// </summary>
        /// <param name="logLevel">The LogLevel to check</param>
        /// <returns>True if the LogLevel is enabled, otherwise false</returns>
        protected override bool IsLogLevelEnabled(LogBase.LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Trace:
                    return _log.IsTraceEnabled;
                case LogLevel.Debug:
                    return _log.IsDebugEnabled;
                case LogLevel.Info:
                    return _log.IsInfoEnabled;
                case LogLevel.Warn:
                    return _log.IsWarnEnabled;
                case LogLevel.Error:
                    return _log.IsErrorEnabled;
                case LogLevel.Fatal:
                    return _log.IsFatalEnabled;
            }
            return true;
        }
    }
}