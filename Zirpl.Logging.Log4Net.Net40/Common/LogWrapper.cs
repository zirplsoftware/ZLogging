using System;
using System.Reflection;

namespace Zirpl.Logging.Log4Net.Common
{
    internal sealed class LogWrapper :LogBase
    {
        private static readonly FieldInfo DeclaringTypeFieldInfo;
        private static readonly Type NewDeclaringType;
        private readonly global::Common.Logging.ILog _log;

        static LogWrapper()
        {
            // this is to ensure that locationInfo is correct
            //
            DeclaringTypeFieldInfo = typeof(global::Common.Logging.Log4Net.Log4NetLogger)
                .GetField("declaringType", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
            NewDeclaringType = typeof (LogWrapper);
        }

        internal LogWrapper(String name)
        {
            var log = global::Common.Logging.LogManager.GetLogger(name);
            this._log = log;

            // this ensures that locationinfo is correct
            //
            if (log is global::Common.Logging.Log4Net.Log4NetLogger)
            {
                // take a look at static constructor for Log4NetLogger in Reflector.
                // that field is passed to log4net logger telling it where to start
                // looking for stack info.
                // we are changing that here to make sure it starts one level higher up
                //
                DeclaringTypeFieldInfo.SetValue(log, NewDeclaringType);
            }
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