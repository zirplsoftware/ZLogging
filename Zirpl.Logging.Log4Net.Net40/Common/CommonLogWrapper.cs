#if !NET35CLIENT && !NET40CLIENT && !SILVERLIGHT
using System;
using System.Reflection;

namespace Zirpl.Logging.Log4Net.Common
{
    internal sealed class CommonLogWrapper :LogBase
    {
        private static readonly FieldInfo DeclaringTypeFieldInfo;
        private static readonly Type NewDeclaringType;
        private readonly global::Common.Logging.ILog _log;

        static CommonLogWrapper()
        {
            // this is to ensure that locationInfo is correct
            //
            DeclaringTypeFieldInfo = typeof(global::Common.Logging.Log4Net.Log4NetLogger)
                .GetField("declaringType", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
            NewDeclaringType = typeof (CommonLogWrapper);
        }

        internal CommonLogWrapper(global::Common.Logging.ILog log)
        {
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
                case LogLevel.Debug:
                    if (exception != null)
                    {
                        _log.Debug(message, exception);
                    }
                    else
                    {
                        _log.Debug(message);   
                    }
                    break;
                case LogLevel.Info:
                    if (exception != null)
                    {
                        _log.Info(message, exception);
                    }
                    else
                    {
                        _log.Info(message);
                    }
                    break;
                case LogLevel.Warn:
                    if (exception != null)
                    {
                        _log.Warn(message, exception);
                    }
                    else
                    {
                        _log.Warn(message);
                    }
                    break;
                case LogLevel.Error:
                    if (exception != null)
                    {
                        _log.Error(message, exception);
                    }
                    else
                    {
                        _log.Error(message);
                    }
                    break;
                case LogLevel.Fatal:
                    if (exception != null)
                    {
                        _log.Fatal(message, exception);
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
                case LogLevel.Debug:
                    return _log.IsDebugEnabled;
                    break;
                case LogLevel.Info:
                    return _log.IsInfoEnabled;
                    break;
                case LogLevel.Warn:
                    return _log.IsWarnEnabled;
                    break;
                case LogLevel.Error:
                    return _log.IsErrorEnabled;
                    break;
                case LogLevel.Fatal:
                    return _log.IsFatalEnabled;
                    break;
            }
            return true;
        }
    }
}

#endif