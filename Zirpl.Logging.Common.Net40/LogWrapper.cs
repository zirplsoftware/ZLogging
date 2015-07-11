using System;

namespace Zirpl.Logging.Common
{
    public sealed class LogWrapper :LogBase
    {
        private readonly global::Common.Logging.ILog _log;

        public LogWrapper(global::Common.Logging.ILog log)
        {
            this._log = log;
        }

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