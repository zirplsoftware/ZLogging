using System;
using System.Globalization;

namespace Zirpl.Logging
{
    /// <summary>
    /// Base <see cref="ILog"/> implementation
    /// </summary>
    public abstract class LogBase :ILog
    {
        /// <summary>
        /// Enums for the Log Level
        /// </summary>
        protected enum LogLevel : byte
        {
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

        public virtual bool IsDebugEnabled
        {
            get { return this.IsLogLevelEnabled(LogLevel.Debug); }
        }

        public virtual void Debug(object message)
        {
            if (this.IsLogLevelEnabled(LogLevel.Debug))
            {
                this.WriteMessageToLog(LogLevel.Debug, message);
            }
        }

        public virtual void Debug(Exception exception, object message)
        {
            if (this.IsLogLevelEnabled(LogLevel.Debug))
            {
                this.WriteMessageToLog(LogLevel.Debug, message, exception);
            }
        }

        public virtual void DebugFormat(string format, params object[] args)
        {
            if (this.IsLogLevelEnabled(LogLevel.Debug))
            {
                this.WriteMessageToLog(LogLevel.Debug, String.Format(CultureInfo.InvariantCulture, format, args));
            }
        }

        public virtual void DebugFormat(Exception exception, string format, params object[] args)
        {
            if (this.IsLogLevelEnabled(LogLevel.Debug))
            {
                this.WriteMessageToLog(LogLevel.Debug, String.Format(CultureInfo.InvariantCulture, format, args), exception);
            }
        }

        public virtual void TryDebug(object message)
        {
            try
            {
                this.Debug(message);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual void TryDebug(Exception exception, object message)
        {
            try
            {
                this.Debug(exception, message);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual void TryDebugFormat(string format, params object[] args)
        {
            try
            {
                this.DebugFormat(format, args);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual void TryDebugFormat(Exception exception, string format, params object[] args)
        {
            try
            {
                this.DebugFormat(exception, format, args);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }
        
        public virtual bool IsInfoEnabled
        {
            get { return this.IsLogLevelEnabled(LogLevel.Info); }
        }

        public virtual void Info(object message)
        {
            if (this.IsLogLevelEnabled(LogLevel.Info))
            {
                this.WriteMessageToLog(LogLevel.Info, message);
            }
        }

        public virtual void Info(Exception exception, object message)
        {
            if (this.IsLogLevelEnabled(LogLevel.Info))
            {
                this.WriteMessageToLog(LogLevel.Info, message, exception);
            }
        }

        public virtual void InfoFormat(string format, params object[] args)
        {
            if (this.IsLogLevelEnabled(LogLevel.Info))
            {
                this.WriteMessageToLog(LogLevel.Info, String.Format(CultureInfo.InvariantCulture, format, args));
            }
        }

        public virtual void InfoFormat(Exception exception, string format, params object[] args)
        {
            if (this.IsLogLevelEnabled(LogLevel.Info))
            {
                this.WriteMessageToLog(LogLevel.Info, String.Format(CultureInfo.InvariantCulture, format, args), exception);
            }
        }

        public virtual void TryInfo(object message)
        {
            try
            {
                this.Info(message);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual void TryInfo(Exception exception, object message)
        {
            try
            {
                this.Info(exception, message);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual void TryInfoFormat(string format, params object[] args)
        {
            try
            {
                this.InfoFormat(format, args);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual void TryInfoFormat(Exception exception, string format, params object[] args)
        {
            try
            {
                this.InfoFormat(exception, format, args);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual bool IsWarnEnabled
        {
            get { return this.IsLogLevelEnabled(LogLevel.Warn); }
        }

        public virtual void Warn(object message)
        {
            if (this.IsLogLevelEnabled(LogLevel.Warn))
            {
                this.WriteMessageToLog(LogLevel.Warn, message);
            }
        }

        public virtual void Warn(Exception exception, object message)
        {
            if (this.IsLogLevelEnabled(LogLevel.Warn))
            {
                this.WriteMessageToLog(LogLevel.Warn, message, exception);
            }
        }

        public virtual void WarnFormat(string format, params object[] args)
        {
            if (this.IsLogLevelEnabled(LogLevel.Warn))
            {
                this.WriteMessageToLog(LogLevel.Warn, String.Format(CultureInfo.InvariantCulture, format, args));
            }
        }

        public virtual void WarnFormat(Exception exception, string format, params object[] args)
        {
            if (this.IsLogLevelEnabled(LogLevel.Warn))
            {
                this.WriteMessageToLog(LogLevel.Warn, String.Format(CultureInfo.InvariantCulture, format, args), exception);
            }
        }

        public virtual void TryWarn(object message)
        {
            try
            {
                this.Warn(message);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual void TryWarn(Exception exception, object message)
        {
            try
            {
                this.Warn(exception, message);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual void TryWarnFormat(string format, params object[] args)
        {
            try
            {
                this.WarnFormat(format, args);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual void TryWarnFormat(Exception exception, string format, params object[] args)
        {
            try
            {
                this.WarnFormat(exception, format, args);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual bool IsErrorEnabled
        {
            get { return this.IsLogLevelEnabled(LogLevel.Error); }
        }

        public virtual void Error(object message)
        {
            if (this.IsLogLevelEnabled(LogLevel.Error))
            {
                this.WriteMessageToLog(LogLevel.Error, message);
            }
        }

        public virtual void Error(Exception exception, object message)
        {
            if (this.IsLogLevelEnabled(LogLevel.Error))
            {
                this.WriteMessageToLog(LogLevel.Error, message, exception);
            }
        }

        public virtual void ErrorFormat(string format, params object[] args)
        {
            if (this.IsLogLevelEnabled(LogLevel.Error))
            {
                this.WriteMessageToLog(LogLevel.Error, String.Format(CultureInfo.InvariantCulture, format, args));
            }
        }

        public virtual void ErrorFormat(Exception exception, string format, params object[] args)
        {
            if (this.IsLogLevelEnabled(LogLevel.Error))
            {
                this.WriteMessageToLog(LogLevel.Error, String.Format(CultureInfo.InvariantCulture, format, args), exception);
            }
        }

        public virtual void TryError(object message)
        {
            try
            {
                this.Error(message);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual void TryError(Exception exception, object message)
        {
            try
            {
                this.Error(exception, message);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual void TryErrorFormat(string format, params object[] args)
        {
            try
            {
                this.ErrorFormat(format, args);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual void TryErrorFormat(Exception exception, string format, params object[] args)
        {
            try
            {
                this.ErrorFormat(exception, format, args);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual bool IsFatalEnabled
        {
            get { return this.IsLogLevelEnabled(LogLevel.Fatal); }
        }

        public virtual void Fatal(object message)
        {
            if (this.IsLogLevelEnabled(LogLevel.Fatal))
            {
                this.WriteMessageToLog(LogLevel.Fatal, message);
            }
        }

        public virtual void Fatal(Exception exception, object message)
        {
            if (this.IsLogLevelEnabled(LogLevel.Fatal))
            {
                this.WriteMessageToLog(LogLevel.Fatal, message, exception);
            }
        }

        public virtual void FatalFormat(string format, params object[] args)
        {
            if (this.IsLogLevelEnabled(LogLevel.Fatal))
            {
                this.WriteMessageToLog(LogLevel.Fatal, String.Format(CultureInfo.InvariantCulture, format, args));
            }
        }

        public virtual void FatalFormat(Exception exception, string format, params object[] args)
        {
            if (this.IsLogLevelEnabled(LogLevel.Fatal))
            {
                this.WriteMessageToLog(LogLevel.Fatal, String.Format(CultureInfo.InvariantCulture, format, args), exception);
            }
        }

        public virtual void TryFatal(object message)
        {
            try
            {
                this.Fatal(message);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual void TryFatal(Exception exception, object message)
        {
            try
            {
                this.Fatal(exception, message);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual void TryFatalFormat(string format, params object[] args)
        {
            try
            {
                this.FatalFormat(format, args);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }

        public virtual void TryFatalFormat(Exception exception, string format, params object[] args)
        {
            try
            {
                this.FatalFormat(exception, format, args);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                // yes, this is correct- we are eating any exceptions in the Try methods
            }
        }
    }
}