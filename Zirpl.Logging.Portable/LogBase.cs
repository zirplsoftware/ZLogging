using System;
using System.Globalization;

namespace Zirpl.Logging
{
    /// <summary>
    /// Base <see cref="ILog"/> implementation
    /// </summary>
    public abstract class LogBase : ILog
    {
        /// <summary>
        /// Enums for the Log Level
        /// </summary>
        protected enum LogLevel : byte
        {
            /// <summary>
            /// Trace
            /// </summary>
            Trace,
            /// <summary>
            /// Debug
            /// </summary>
            Debug,
            /// <summary>
            /// Info
            /// </summary>
            Info,
            /// <summary>
            /// Warn
            /// </summary>
            Warn,
            /// <summary>
            /// Error
            /// </summary>
            Error,
            /// <summary>
            /// Fatal
            /// </summary>
            Fatal
        }

        /// <summary>
        /// Writes a log message with the specified <paramref name="logLevel"/>
        /// </summary>
        /// <param name="logLevel">The level of the log message</param>
        /// <param name="message">The message to log</param>
        /// <param name="exception">Any exception to log</param>
        protected abstract void WriteMessageToLog(LogLevel logLevel, object message, Exception exception = null);

        /// <summary>
        /// Gets whether or not the specified <paramref name="logLevel"/> is enabled
        /// </summary>
        /// <param name="logLevel">The LogLevel to check</param>
        /// <returns>True if the level is enabled, otherwise false</returns>
        protected abstract bool IsLogLevelEnabled(LogLevel logLevel);

        public virtual bool IsTraceEnabled
        {
            get { return IsLogLevelEnabled(LogLevel.Trace); }
        }

        public virtual void Trace(object message)
        {
            if (IsLogLevelEnabled(LogLevel.Trace))
            {
                WriteMessageToLog(LogLevel.Trace, message);
            }
        }

        public virtual void Trace(Exception exception, object message = null)
        {
            if (IsLogLevelEnabled(LogLevel.Trace))
            {
                WriteMessageToLog(LogLevel.Trace, message, exception);
            }
        }

        public virtual void TraceFormat(string format, params object[] args)
        {
            if (IsLogLevelEnabled(LogLevel.Trace))
            {
                WriteMessageToLog(LogLevel.Trace, String.Format(CultureInfo.InvariantCulture, format, args));
            }
        }

        public virtual void TraceFormat(Exception exception, string format, params object[] args)
        {
            if (IsLogLevelEnabled(LogLevel.Trace))
            {
                WriteMessageToLog(LogLevel.Trace, String.Format(CultureInfo.InvariantCulture, format, args), exception);
            }
        }

        public virtual bool TryTrace(object message)
        {
            try
            {
                Trace(message);
                return true;
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                return false;
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual bool TryTrace(Exception exception, object message = null)
        {
            try
            {
                Trace(exception, message);
                return true;
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                return false;
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual bool TryTraceFormat(string format, params object[] args)
        {
            try
            {
                TraceFormat(format, args);
                return true;
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                return false;
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual bool TryTraceFormat(Exception exception, string format, params object[] args)
        {
            try
            {
                TraceFormat(exception, format, args);
                return true;
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                return false;
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }






        public virtual bool IsDebugEnabled
        {
            get { return IsLogLevelEnabled(LogLevel.Debug); }
        }

        public virtual void Debug(object message)
        {
            if (IsLogLevelEnabled(LogLevel.Debug))
            {
                WriteMessageToLog(LogLevel.Debug, message);
            }
        }

        public virtual void Debug(Exception exception, object message = null)
        {
            if (IsLogLevelEnabled(LogLevel.Debug))
            {
                WriteMessageToLog(LogLevel.Debug, message, exception);
            }
        }

        public virtual void DebugFormat(string format, params object[] args)
        {
            if (IsLogLevelEnabled(LogLevel.Debug))
            {
                WriteMessageToLog(LogLevel.Debug, String.Format(CultureInfo.InvariantCulture, format, args));
            }
        }

        public virtual void DebugFormat(Exception exception, string format, params object[] args)
        {
            if (IsLogLevelEnabled(LogLevel.Debug))
            {
                WriteMessageToLog(LogLevel.Debug, String.Format(CultureInfo.InvariantCulture, format, args), exception);
            }
        }

        public virtual bool TryDebug(object message)
        {
            try
            {
                Debug(message);
                return true;
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                return false;
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual bool TryDebug(Exception exception, object message = null)
        {
            try
            {
                Debug(exception, message);
                return true;
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                return false;
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual bool TryDebugFormat(string format, params object[] args)
        {
            try
            {
                DebugFormat(format, args);
                return true;
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                return false;
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual bool TryDebugFormat(Exception exception, string format, params object[] args)
        {
            try
            {
                DebugFormat(exception, format, args);
                return true;
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                return false;
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual bool IsInfoEnabled
        {
            get { return IsLogLevelEnabled(LogLevel.Info); }
        }

        public virtual void Info(object message)
        {
            if (IsLogLevelEnabled(LogLevel.Info))
            {
                WriteMessageToLog(LogLevel.Info, message);
            }
        }

        public virtual void Info(Exception exception, object message = null)
        {
            if (IsLogLevelEnabled(LogLevel.Info))
            {
                WriteMessageToLog(LogLevel.Info, message, exception);
            }
        }

        public virtual void InfoFormat(string format, params object[] args)
        {
            if (IsLogLevelEnabled(LogLevel.Info))
            {
                WriteMessageToLog(LogLevel.Info, String.Format(CultureInfo.InvariantCulture, format, args));
            }
        }

        public virtual void InfoFormat(Exception exception, string format, params object[] args)
        {
            if (IsLogLevelEnabled(LogLevel.Info))
            {
                WriteMessageToLog(LogLevel.Info, String.Format(CultureInfo.InvariantCulture, format, args), exception);
            }
        }

        public virtual bool TryInfo(object message)
        {
            try
            {
                Info(message);
                return true;
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                return false;
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual bool TryInfo(Exception exception, object message = null)
        {
            try
            {
                Info(exception, message);
                return true;
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                return false;
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual bool TryInfoFormat(string format, params object[] args)
        {
            try
            {
                InfoFormat(format, args);
                return true;
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                return false;
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual bool TryInfoFormat(Exception exception, string format, params object[] args)
        {
            try
            {
                InfoFormat(exception, format, args);
                return true;
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                return false;
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual bool IsWarnEnabled
        {
            get { return IsLogLevelEnabled(LogLevel.Warn); }
        }

        public virtual void Warn(object message)
        {
            if (IsLogLevelEnabled(LogLevel.Warn))
            {
                WriteMessageToLog(LogLevel.Warn, message);
            }
        }

        public virtual void Warn(Exception exception, object message = null)
        {
            if (IsLogLevelEnabled(LogLevel.Warn))
            {
                WriteMessageToLog(LogLevel.Warn, message, exception);
            }
        }

        public virtual void WarnFormat(string format, params object[] args)
        {
            if (IsLogLevelEnabled(LogLevel.Warn))
            {
                WriteMessageToLog(LogLevel.Warn, String.Format(CultureInfo.InvariantCulture, format, args));
            }
        }

        public virtual void WarnFormat(Exception exception, string format, params object[] args)
        {
            if (IsLogLevelEnabled(LogLevel.Warn))
            {
                WriteMessageToLog(LogLevel.Warn, String.Format(CultureInfo.InvariantCulture, format, args), exception);
            }
        }

        public virtual bool TryWarn(object message)
        {
            try
            {
                Warn(message);
                return true;
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                return false;
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual bool TryWarn(Exception exception, object message = null)
        {
            try
            {
                Warn(exception, message);
                return true;
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                return false;
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual bool TryWarnFormat(string format, params object[] args)
        {
            try
            {
                WarnFormat(format, args);
                return true;
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                return false;
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual bool TryWarnFormat(Exception exception, string format, params object[] args)
        {
            try
            {
                WarnFormat(exception, format, args);
                return true;
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                return false;
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual bool IsErrorEnabled
        {
            get { return IsLogLevelEnabled(LogLevel.Error); }
        }

        public virtual void Error(object message)
        {
            if (IsLogLevelEnabled(LogLevel.Error))
            {
                WriteMessageToLog(LogLevel.Error, message);
            }
        }

        public virtual void Error(Exception exception, object message = null)
        {
            if (IsLogLevelEnabled(LogLevel.Error))
            {
                WriteMessageToLog(LogLevel.Error, message, exception);
            }
        }

        public virtual void ErrorFormat(string format, params object[] args)
        {
            if (IsLogLevelEnabled(LogLevel.Error))
            {
                WriteMessageToLog(LogLevel.Error, String.Format(CultureInfo.InvariantCulture, format, args));
            }
        }

        public virtual void ErrorFormat(Exception exception, string format, params object[] args)
        {
            if (IsLogLevelEnabled(LogLevel.Error))
            {
                WriteMessageToLog(LogLevel.Error, String.Format(CultureInfo.InvariantCulture, format, args), exception);
            }
        }

        public virtual bool TryError(object message)
        {
            try
            {
                Error(message);
                return true;
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                return false;
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual bool TryError(Exception exception, object message = null)
        {
            try
            {
                Error(exception, message);
                return true;
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                return false;
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual bool TryErrorFormat(string format, params object[] args)
        {
            try
            {
                ErrorFormat(format, args);
                return true;
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                return false;
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual bool TryErrorFormat(Exception exception, string format, params object[] args)
        {
            try
            {
                ErrorFormat(exception, format, args);
                return true;
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                return false;
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual bool IsFatalEnabled
        {
            get { return IsLogLevelEnabled(LogLevel.Fatal); }
        }

        public virtual void Fatal(object message)
        {
            if (IsLogLevelEnabled(LogLevel.Fatal))
            {
                WriteMessageToLog(LogLevel.Fatal, message);
            }
        }

        public virtual void Fatal(Exception exception, object message = null)
        {
            if (IsLogLevelEnabled(LogLevel.Fatal))
            {
                WriteMessageToLog(LogLevel.Fatal, message, exception);
            }
        }

        public virtual void FatalFormat(string format, params object[] args)
        {
            if (IsLogLevelEnabled(LogLevel.Fatal))
            {
                WriteMessageToLog(LogLevel.Fatal, String.Format(CultureInfo.InvariantCulture, format, args));
            }
        }

        public virtual void FatalFormat(Exception exception, string format, params object[] args)
        {
            if (IsLogLevelEnabled(LogLevel.Fatal))
            {
                WriteMessageToLog(LogLevel.Fatal, String.Format(CultureInfo.InvariantCulture, format, args), exception);
            }
        }

        public virtual bool TryFatal(object message)
        {
            try
            {
                Fatal(message);
                return true;
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                return false;
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual bool TryFatal(Exception exception, object message = null)
        {
            try
            {
                Fatal(exception, message);
                return true;
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                return false;
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual bool TryFatalFormat(string format, params object[] args)
        {
            try
            {
                FatalFormat(format, args);
                return true;
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                return false;
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual bool TryFatalFormat(Exception exception, string format, params object[] args)
        {
            try
            {
                FatalFormat(exception, format, args);
                return true;
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                return false;
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }
    }
}