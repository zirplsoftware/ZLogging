using System;

namespace Zirpl.Logging
{
    /// <summary>
    /// An object that can log messages and exceptions
    /// and determine what log levels are enabled
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// Logs the message in Debug severity
        /// </summary>
        /// <param name="message">The message.</param>
        void Debug(object message);

        /// <summary>
        /// Logs the message in Debug severity
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="message">The message.</param>
        void Debug(Exception exception, object message);

        /// <summary>
        /// Logs the message in Debug severity
        /// </summary>
        /// <param name="format">String to format</param>
        /// <param name="args">Args to format into the string</param>
        void DebugFormat(string format, params object[] args);

        /// <summary>
        /// Logs the message in Debug severity
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="format">String to format</param>
        /// <param name="args">Args to format into the string</param>
        void DebugFormat(Exception exception, String format, params object[] args);

        /// <summary>
        /// Logs the message in Info severity
        /// </summary>
        /// <param name="message">The message.</param>
        void Info(object message);

        /// <summary>
        /// Logs the message in Info severity
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="message">The message.</param>
        void Info(Exception exception, object message);

        /// <summary>
        /// Logs the message in Info severity
        /// </summary>
        /// <param name="format">String to format</param>
        /// <param name="args">Args to format into the string</param>
        void InfoFormat(string format, params object[] args);

        /// <summary>
        /// Logs the message in Info severity
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="format">String to format</param>
        /// <param name="args">Args to format into the string</param>
        void InfoFormat(Exception exception, string format, params object[] args);

        /// <summary>
        /// Logs the message in Warn severity
        /// </summary>
        /// <param name="message">The message.</param>
        void Warn(object message);

        /// <summary>
        /// Logs the message in Warn severity
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="message">The message.</param>
        void Warn(Exception exception, object message);

        /// <summary>
        /// Logs the message in Warn severity
        /// </summary>
        /// <param name="format">String to format</param>
        /// <param name="args">Args to format into the string</param>
        void WarnFormat(string format, params object[] args);

        /// <summary>
        /// Logs the message in Warn severity
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="format">String to format</param>
        /// <param name="args">Args to format into the string</param>
        void WarnFormat(Exception exception, string format, params object[] args);

        /// <summary>
        /// Logs the message in Error severity
        /// </summary>
        /// <param name="message">The message.</param>
        void Error(object message);

        /// <summary>
        /// Logs the message in Error severity
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="message">The message.</param>
        void Error(Exception exception, object message);

        /// <summary>
        /// Logs the message in Error severity
        /// </summary>
        /// <param name="format">String to format</param>
        /// <param name="args">Args to format into the string</param>
        void ErrorFormat(string format, params object[] args);

        /// <summary>
        /// Logs the message in Error severity
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="format">String to format</param>
        /// <param name="args">Args to format into the string</param>
        void ErrorFormat(Exception exception, string format, params object[] args);

        /// <summary>
        /// Logs the message in Fatal severity
        /// </summary>
        /// <param name="message">The message.</param>
        void Fatal(object message);

        /// <summary>
        /// Logs the message in Fatal severity
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="message">The message.</param>
        void Fatal(Exception exception, object message);

        /// <summary>
        /// Logs the message in Fatal severity
        /// </summary>
        /// <param name="format">String to format</param>
        /// <param name="args">Args to format into the string</param>
        void FatalFormat(string format, params object[] args);

        /// <summary>
        /// Logs the message in Fatal severity
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="format">String to format</param>
        /// <param name="args">Args to format into the string</param>
        void FatalFormat(Exception exception, string format, params object[] args);

        /// <summary>
        /// Gets whether or not Debug severity logging is enabled
        /// </summary>
        bool IsDebugEnabled { get; }

        /// <summary>
        /// Gets whether or not Info severity logging is enabled
        /// </summary>
        bool IsInfoEnabled { get; }

        /// <summary>
        /// Gets whether or not Warn severity logging is enabled
        /// </summary>
        bool IsWarnEnabled { get; }

        /// <summary>
        /// Gets whether or not Error severity logging is enabled
        /// </summary>
        bool IsErrorEnabled { get; }

        /// <summary>
        /// Gets whether or not Fatal severity logging is enabled
        /// </summary>
        bool IsFatalEnabled { get; }
        
        /// <summary>
        /// Logs the message in Debug severity
        /// if the log level is enabled
        /// and catches any exceptions generated
        /// </summary>
        /// <param name="message">The message.</param>
        void TryDebug(object message);

        /// <summary>
        /// Logs the message in Debug severity
        /// if the log level is enabled
        /// and catches any exceptions generated
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="message">The message.</param>
        void TryDebug(Exception exception, object message);

        /// <summary>
        /// Logs the message in Debug severity
        /// if the log level is enabled
        /// and catches any exceptions generated
        /// </summary>
        /// <param name="format">String to format</param>
        /// <param name="args">Args to format into the string</param>
        void TryDebugFormat(string format, params object[] args);

        /// <summary>
        /// Logs the message in Debug severity
        /// if the log level is enabled
        /// and catches any exceptions generated
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="format">String to format</param>
        /// <param name="args">Args to format into the string</param>
        void TryDebugFormat(Exception exception, String format, params object[] args);

        /// <summary>
        /// Logs the message in Info severity
        /// if the log level is enabled
        /// and catches any exceptions generated
        /// </summary>
        /// <param name="message">The message.</param>
        void TryInfo(object message);

        /// <summary>
        /// Logs the message in Info severity
        /// if the log level is enabled
        /// and catches any exceptions generated
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="message">The message.</param>
        void TryInfo(Exception exception, object message);
        
        /// <summary>
        /// Logs the message in Info severity
        /// if the log level is enabled
        /// and catches any exceptions generated
        /// </summary>
        /// <param name="format">String to format</param>
        /// <param name="args">Args to format into the string</param>
        void TryInfoFormat(string format, params object[] args);

        /// <summary>
        /// Logs the message in Info severity
        /// if the log level is enabled
        /// and catches any exceptions generated
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="format">String to format</param>
        /// <param name="args">Args to format into the string</param>
        void TryInfoFormat(Exception exception, string format, params object[] args);

        /// <summary>
        /// Logs the message in Warn severity
        /// if the log level is enabled
        /// and catches any exceptions generated
        /// </summary>
        /// <param name="message">The message.</param>
        void TryWarn(object message);

        /// <summary>
        /// Logs the message in Warn severity
        /// if the log level is enabled
        /// and catches any exceptions generated
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="message">The message.</param>
        void TryWarn(Exception exception, object message);

        /// <summary>
        /// Logs the message in Warn severity
        /// if the log level is enabled
        /// and catches any exceptions generated
        /// </summary>
        /// <param name="format">String to format</param>
        /// <param name="args">Args to format into the string</param>
        void TryWarnFormat(string format, params object[] args);

        /// <summary>
        /// Logs the message in Warn severity
        /// if the log level is enabled
        /// and catches any exceptions generated
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="format">String to format</param>
        /// <param name="args">Args to format into the string</param>
        void TryWarnFormat(Exception exception, string format, params object[] args);

        /// <summary>
        /// Logs the message in Error severity
        /// if the log level is enabled
        /// and catches any exceptions generated
        /// </summary>
        /// <param name="message">The message.</param>
        void TryError(object message);

        /// <summary>
        /// Logs the message in Error severity
        /// if the log level is enabled
        /// and catches any exceptions generated
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="message">The message.</param>
        void TryError(Exception exception, object message);

        /// <summary>
        /// Logs the message in Error severity
        /// if the log level is enabled
        /// and catches any exceptions generated
        /// </summary>
        /// <param name="format">String to format</param>
        /// <param name="args">Args to format into the string</param>
        void TryErrorFormat(string format, params object[] args);

        /// <summary>
        /// Logs the message in Error severity
        /// if the log level is enabled
        /// and catches any exceptions generated
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="format">String to format</param>
        /// <param name="args">Args to format into the string</param>
        void TryErrorFormat(Exception exception, string format, params object[] args);

        /// <summary>
        /// Logs the message in Fatal severity
        /// if the log level is enabled
        /// and catches any exceptions generated
        /// </summary>
        /// <param name="message">The message.</param>
        void TryFatal(object message);

        /// <summary>
        /// Logs the message in Fatal severity
        /// if the log level is enabled
        /// and catches any exceptions generated
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="message">The message.</param>
        void TryFatal(Exception exception, object message);

        /// <summary>
        /// Logs the message in Fatal severity
        /// if the log level is enabled
        /// and catches any exceptions generated
        /// </summary>
        /// <param name="format">String to format</param>
        /// <param name="args">Args to format into the string</param>
        void TryFatalFormat(string format, params object[] args);

        /// <summary>
        /// Logs the message in Fatal severity
        /// if the log level is enabled
        /// and catches any exceptions generated
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="format">String to format</param>
        /// <param name="args">Args to format into the string</param>
        void TryFatalFormat(Exception exception, string format, params object[] args);
    }
}
