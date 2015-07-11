using System;
using Common.Logging;
using Common.Logging.Factory;

namespace Zirpl.Logging.Common
{
    /// <summary>
    /// Provides additional methods off the ILog interface
    /// </summary>
    public static class ILogExtensions
    {
        #region Debug methods

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Debug level using a callback to obtain the message
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        /// <remarks>Using this method avoids the cost of creating a message and evaluating message arguments that probably won't be logged due to loglevel settings.</remarks>
        public static bool TryDebug(this ILog log, Action<FormatMessageHandler> formatMessageCallback)
        {
            try
            {
                log.Debug(formatMessageCallback);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message object with the Common.Logging.LogLevel.Debug level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="message">The message object to log.</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        public static bool TryDebug(this ILog log, object message)
        {
            try
            {
                log.Debug(message);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Debug level using a callback to obtain the message
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        /// <remarks>Using this method avoids the cost of creating a message and evaluating message arguments that probably won't be logged due to loglevel settings.</remarks>
        public static bool TryDebug(this ILog log, Action<FormatMessageHandler> formatMessageCallback, Exception exception)
        {
            try
            {
                log.Debug(formatMessageCallback, exception);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Debug level using a callback to obtain the message
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatProvider">An System.IFormatProvider that supplies culture-specific formatting information.</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        /// <remarks>Using this method avoids the cost of creating a message and evaluating message arguments that probably won't be logged due to loglevel settings.</remarks>
        public static bool TryDebug(this ILog log, IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback)
        {
            try
            {
                log.Debug(formatProvider, formatMessageCallback);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message object with the Common.Logging.LogLevel.Debug level including the stack trace of the System.Exception passed as a parameter.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="message">The message object to log.</param>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        public static bool TryDebug(this ILog log, object message, Exception exception)
        {
            try
            {
                log.Debug(message, exception);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Debug level using a callback to obtain the message
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatProvider">An System.IFormatProvider that supplies culture-specific formatting information.</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <param name="exception">The exception to log, including its stack Debug.</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        /// <remarks>Using this method avoids the cost of creating a message and evaluating message arguments that probably won't be logged due to loglevel settings.</remarks>
        public static bool TryDebug(this ILog log, IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback, Exception exception)
        {
            try
            {
                log.Debug(formatProvider, formatMessageCallback, exception);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Debug level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="format">The format of the message object to log.System.String.Format(System.String,System.Object[])</param>
        /// <param name="args">the list of format arguments</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        [StringFormatMethod("format")]
        public static bool TryDebugFormat(this ILog log, string format, params object[] args)
        {
            try
            {
                log.DebugFormat(format, args);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Debug level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatProvider">An System.IFormatProvider that supplies culture-specific formatting information.</param>
        /// <param name="format">The format of the message object to log.System.String.Format(System.String,System.Object[])</param>
        /// <param name="args">the list of format arguments</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        [StringFormatMethod("format")]
        public static bool TryDebugFormat(this ILog log, IFormatProvider formatProvider, string format, params object[] args)
        {
            try
            {
                log.DebugFormat(formatProvider, format, args);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Debug level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="format">The format of the message object to log.System.String.Format(System.String,System.Object[])</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of format arguments</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        [StringFormatMethod("format")]
        public static bool TryDebugFormat(this ILog log, string format, Exception exception, params object[] args)
        {
            try
            {
                log.DebugFormat(format, exception, args);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Debug level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatProvider">An System.IFormatProvider that supplies culture-specific formatting information.</param>
        /// <param name="format">The format of the message object to log.System.String.Format(System.String,System.Object[])</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of format arguments</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        [StringFormatMethod("format")]
        public static bool TryDebugFormat(this ILog log, IFormatProvider formatProvider, string format, Exception exception, params object[] args)
        {
            try
            {
                log.DebugFormat(formatProvider, format, exception, args);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        #endregion






        #region Error methods

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Error level using a callback to obtain the message
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        /// <remarks>Using this method avoids the cost of creating a message and evaluating message arguments that probably won't be logged due to loglevel settings.</remarks>
        public static bool TryError(this ILog log, Action<FormatMessageHandler> formatMessageCallback)
        {
            try
            {
                log.Error(formatMessageCallback);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message object with the Common.Logging.LogLevel.Error level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="message">The message object to log.</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        public static bool TryError(this ILog log, object message)
        {
            try
            {
                log.Error(message);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Error level using a callback to obtain the message
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        /// <remarks>Using this method avoids the cost of creating a message and evaluating message arguments that probably won't be logged due to loglevel settings.</remarks>
        public static bool TryError(this ILog log, Action<FormatMessageHandler> formatMessageCallback, Exception exception)
        {
            try
            {
                log.Error(formatMessageCallback, exception);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Error level using a callback to obtain the message
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatProvider">An System.IFormatProvider that supplies culture-specific formatting information.</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        /// <remarks>Using this method avoids the cost of creating a message and evaluating message arguments that probably won't be logged due to loglevel settings.</remarks>
        public static bool TryError(this ILog log, IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback)
        {
            try
            {
                log.Error(formatProvider, formatMessageCallback);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message object with the Common.Logging.LogLevel.Error level including the stack trace of the System.Exception passed as a parameter.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="message">The message object to log.</param>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        public static bool TryError(this ILog log, object message, Exception exception)
        {
            try
            {
                log.Error(message, exception);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Error level using a callback to obtain the message
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatProvider">An System.IFormatProvider that supplies culture-specific formatting information.</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <param name="exception">The exception to log, including its stack Error.</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        /// <remarks>Using this method avoids the cost of creating a message and evaluating message arguments that probably won't be logged due to loglevel settings.</remarks>
        public static bool TryError(this ILog log, IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback, Exception exception)
        {
            try
            {
                log.Error(formatProvider, formatMessageCallback, exception);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Error level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="format">The format of the message object to log.System.String.Format(System.String,System.Object[])</param>
        /// <param name="args">the list of format arguments</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        [StringFormatMethod("format")]
        public static bool TryErrorFormat(this ILog log, string format, params object[] args)
        {
            try
            {
                log.ErrorFormat(format, args);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Error level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatProvider">An System.IFormatProvider that supplies culture-specific formatting information.</param>
        /// <param name="format">The format of the message object to log.System.String.Format(System.String,System.Object[])</param>
        /// <param name="args">the list of format arguments</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        [StringFormatMethod("format")]
        public static bool TryErrorFormat(this ILog log, IFormatProvider formatProvider, string format, params object[] args)
        {
            try
            {
                log.ErrorFormat(formatProvider, format, args);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Error level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="format">The format of the message object to log.System.String.Format(System.String,System.Object[])</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of format arguments</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        [StringFormatMethod("format")]
        public static bool TryErrorFormat(this ILog log, string format, Exception exception, params object[] args)
        {
            try
            {
                log.ErrorFormat(format, exception, args);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Error level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatProvider">An System.IFormatProvider that supplies culture-specific formatting information.</param>
        /// <param name="format">The format of the message object to log.System.String.Format(System.String,System.Object[])</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of format arguments</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        [StringFormatMethod("format")]
        public static bool TryErrorFormat(this ILog log, IFormatProvider formatProvider, string format, Exception exception, params object[] args)
        {
            try
            {
                log.ErrorFormat(formatProvider, format, exception, args);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        #endregion






        #region Fatal methods

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Fatal level using a callback to obtain the message
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        /// <remarks>Using this method avoids the cost of creating a message and evaluating message arguments that probably won't be logged due to loglevel settings.</remarks>
        public static bool TryFatal(this ILog log, Action<FormatMessageHandler> formatMessageCallback)
        {
            try
            {
                log.Fatal(formatMessageCallback);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message object with the Common.Logging.LogLevel.Fatal level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="message">The message object to log.</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        public static bool TryFatal(this ILog log, object message)
        {
            try
            {
                log.Fatal(message);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Fatal level using a callback to obtain the message
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        /// <remarks>Using this method avoids the cost of creating a message and evaluating message arguments that probably won't be logged due to loglevel settings.</remarks>
        public static bool TryFatal(this ILog log, Action<FormatMessageHandler> formatMessageCallback, Exception exception)
        {
            try
            {
                log.Fatal(formatMessageCallback, exception);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Fatal level using a callback to obtain the message
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatProvider">An System.IFormatProvider that supplies culture-specific formatting information.</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        /// <remarks>Using this method avoids the cost of creating a message and evaluating message arguments that probably won't be logged due to loglevel settings.</remarks>
        public static bool TryFatal(this ILog log, IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback)
        {
            try
            {
                log.Fatal(formatProvider, formatMessageCallback);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message object with the Common.Logging.LogLevel.Fatal level including the stack trace of the System.Exception passed as a parameter.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="message">The message object to log.</param>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        public static bool TryFatal(this ILog log, object message, Exception exception)
        {
            try
            {
                log.Fatal(message, exception);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Fatal level using a callback to obtain the message
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatProvider">An System.IFormatProvider that supplies culture-specific formatting information.</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <param name="exception">The exception to log, including its stack Fatal.</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        /// <remarks>Using this method avoids the cost of creating a message and evaluating message arguments that probably won't be logged due to loglevel settings.</remarks>
        public static bool TryFatal(this ILog log, IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback, Exception exception)
        {
            try
            {
                log.Fatal(formatProvider, formatMessageCallback, exception);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Fatal level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="format">The format of the message object to log.System.String.Format(System.String,System.Object[])</param>
        /// <param name="args">the list of format arguments</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        [StringFormatMethod("format")]
        public static bool TryFatalFormat(this ILog log, string format, params object[] args)
        {
            try
            {
                log.FatalFormat(format, args);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Fatal level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatProvider">An System.IFormatProvider that supplies culture-specific formatting information.</param>
        /// <param name="format">The format of the message object to log.System.String.Format(System.String,System.Object[])</param>
        /// <param name="args">the list of format arguments</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        [StringFormatMethod("format")]
        public static bool TryFatalFormat(this ILog log, IFormatProvider formatProvider, string format, params object[] args)
        {
            try
            {
                log.FatalFormat(formatProvider, format, args);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Fatal level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="format">The format of the message object to log.System.String.Format(System.String,System.Object[])</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of format arguments</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        [StringFormatMethod("format")]
        public static bool TryFatalFormat(this ILog log, string format, Exception exception, params object[] args)
        {
            try
            {
                log.FatalFormat(format, exception, args);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Fatal level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatProvider">An System.IFormatProvider that supplies culture-specific formatting information.</param>
        /// <param name="format">The format of the message object to log.System.String.Format(System.String,System.Object[])</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of format arguments</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        [StringFormatMethod("format")]
        public static bool TryFatalFormat(this ILog log, IFormatProvider formatProvider, string format, Exception exception, params object[] args)
        {
            try
            {
                log.FatalFormat(formatProvider, format, exception, args);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        #endregion

        #region Info methods

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Info level using a callback to obtain the message
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        /// <remarks>Using this method avoids the cost of creating a message and evaluating message arguments that probably won't be logged due to loglevel settings.</remarks>
        public static bool TryInfo(this ILog log, Action<FormatMessageHandler> formatMessageCallback)
        {
            try
            {
                log.Info(formatMessageCallback);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message object with the Common.Logging.LogLevel.Info level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="message">The message object to log.</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        public static bool TryInfo(this ILog log, object message)
        {
            try
            {
                log.Info(message);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Info level using a callback to obtain the message
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        /// <remarks>Using this method avoids the cost of creating a message and evaluating message arguments that probably won't be logged due to loglevel settings.</remarks>
        public static bool TryInfo(this ILog log, Action<FormatMessageHandler> formatMessageCallback, Exception exception)
        {
            try
            {
                log.Info(formatMessageCallback, exception);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Info level using a callback to obtain the message
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatProvider">An System.IFormatProvider that supplies culture-specific formatting information.</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        /// <remarks>Using this method avoids the cost of creating a message and evaluating message arguments that probably won't be logged due to loglevel settings.</remarks>
        public static bool TryInfo(this ILog log, IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback)
        {
            try
            {
                log.Info(formatProvider, formatMessageCallback);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message object with the Common.Logging.LogLevel.Info level including the stack trace of the System.Exception passed as a parameter.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="message">The message object to log.</param>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        public static bool TryInfo(this ILog log, object message, Exception exception)
        {
            try
            {
                log.Info(message, exception);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Info level using a callback to obtain the message
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatProvider">An System.IFormatProvider that supplies culture-specific formatting information.</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <param name="exception">The exception to log, including its stack Info.</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        /// <remarks>Using this method avoids the cost of creating a message and evaluating message arguments that probably won't be logged due to loglevel settings.</remarks>
        public static bool TryInfo(this ILog log, IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback, Exception exception)
        {
            try
            {
                log.Info(formatProvider, formatMessageCallback, exception);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Info level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="format">The format of the message object to log.System.String.Format(System.String,System.Object[])</param>
        /// <param name="args">the list of format arguments</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        [StringFormatMethod("format")]
        public static bool TryInfoFormat(this ILog log, string format, params object[] args)
        {
            try
            {
                log.InfoFormat(format, args);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Info level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatProvider">An System.IFormatProvider that supplies culture-specific formatting information.</param>
        /// <param name="format">The format of the message object to log.System.String.Format(System.String,System.Object[])</param>
        /// <param name="args">the list of format arguments</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        [StringFormatMethod("format")]
        public static bool TryInfoFormat(this ILog log, IFormatProvider formatProvider, string format, params object[] args)
        {
            try
            {
                log.InfoFormat(formatProvider, format, args);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Info level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="format">The format of the message object to log.System.String.Format(System.String,System.Object[])</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of format arguments</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        [StringFormatMethod("format")]
        public static bool TryInfoFormat(this ILog log, string format, Exception exception, params object[] args)
        {
            try
            {
                log.InfoFormat(format, exception, args);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Info level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatProvider">An System.IFormatProvider that supplies culture-specific formatting information.</param>
        /// <param name="format">The format of the message object to log.System.String.Format(System.String,System.Object[])</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of format arguments</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        [StringFormatMethod("format")]
        public static bool TryInfoFormat(this ILog log, IFormatProvider formatProvider, string format, Exception exception, params object[] args)
        {
            try
            {
                log.InfoFormat(formatProvider, format, exception, args);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        #endregion




        #region Trace methods

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Trace level using a callback to obtain the message
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        /// <remarks>Using this method avoids the cost of creating a message and evaluating message arguments that probably won't be logged due to loglevel settings.</remarks>
        public static bool TryTrace(this ILog log, Action<FormatMessageHandler> formatMessageCallback)
        {
            try
            {
                log.Trace(formatMessageCallback);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message object with the Common.Logging.LogLevel.Trace level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="message">The message object to log.</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        public static bool TryTrace(this ILog log, object message)
        {
            try
            {
                log.Trace(message);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Trace level using a callback to obtain the message
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        /// <remarks>Using this method avoids the cost of creating a message and evaluating message arguments that probably won't be logged due to loglevel settings.</remarks>
        public static bool TryTrace(this ILog log, Action<FormatMessageHandler> formatMessageCallback, Exception exception)
        {
            try
            {
                log.Trace(formatMessageCallback, exception);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Trace level using a callback to obtain the message
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatProvider">An System.IFormatProvider that supplies culture-specific formatting information.</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        /// <remarks>Using this method avoids the cost of creating a message and evaluating message arguments that probably won't be logged due to loglevel settings.</remarks>
        public static bool TryTrace(this ILog log, IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback)
        {
            try
            {
                log.Trace(formatProvider, formatMessageCallback);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message object with the Common.Logging.LogLevel.Trace level including the stack trace of the System.Exception passed as a parameter.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="message">The message object to log.</param>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        public static bool TryTrace(this ILog log, object message, Exception exception)
        {
            try
            {
                log.Trace(message, exception);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Trace level using a callback to obtain the message
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatProvider">An System.IFormatProvider that supplies culture-specific formatting information.</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <param name="exception">The exception to log, including its stack Trace.</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        /// <remarks>Using this method avoids the cost of creating a message and evaluating message arguments that probably won't be logged due to loglevel settings.</remarks>
        public static bool TryTrace(this ILog log, IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback, Exception exception)
        {
            try
            {
                log.Trace(formatProvider, formatMessageCallback, exception);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Trace level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="format">The format of the message object to log.System.String.Format(System.String,System.Object[])</param>
        /// <param name="args">the list of format arguments</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        [StringFormatMethod("format")]
        public static bool TryTraceFormat(this ILog log, string format, params object[] args)
        {
            try
            {
                log.TraceFormat(format, args);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Trace level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatProvider">An System.IFormatProvider that supplies culture-specific formatting information.</param>
        /// <param name="format">The format of the message object to log.System.String.Format(System.String,System.Object[])</param>
        /// <param name="args">the list of format arguments</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        [StringFormatMethod("format")]
        public static bool TryTraceFormat(this ILog log, IFormatProvider formatProvider, string format, params object[] args)
        {
            try
            {
                log.TraceFormat(formatProvider, format, args);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Trace level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="format">The format of the message object to log.System.String.Format(System.String,System.Object[])</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of format arguments</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        [StringFormatMethod("format")]
        public static bool TryTraceFormat(this ILog log, string format, Exception exception, params object[] args)
        {
            try
            {
                log.TraceFormat(format, exception, args);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Trace level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatProvider">An System.IFormatProvider that supplies culture-specific formatting information.</param>
        /// <param name="format">The format of the message object to log.System.String.Format(System.String,System.Object[])</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of format arguments</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        [StringFormatMethod("format")]
        public static bool TryTraceFormat(this ILog log, IFormatProvider formatProvider, string format, Exception exception, params object[] args)
        {
            try
            {
                log.TraceFormat(formatProvider, format, exception, args);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        #endregion

        #region Warn methods

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Warn level using a callback to obtain the message
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        /// <remarks>Using this method avoids the cost of creating a message and evaluating message arguments that probably won't be logged due to loglevel settings.</remarks>
        public static bool TryWarn(this ILog log, Action<FormatMessageHandler> formatMessageCallback)
        {
            try
            {
                log.Warn(formatMessageCallback);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message object with the Common.Logging.LogLevel.Warn level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="message">The message object to log.</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        public static bool TryWarn(this ILog log, object message)
        {
            try
            {
                log.Warn(message);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Warn level using a callback to obtain the message
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        /// <remarks>Using this method avoids the cost of creating a message and evaluating message arguments that probably won't be logged due to loglevel settings.</remarks>
        public static bool TryWarn(this ILog log, Action<FormatMessageHandler> formatMessageCallback, Exception exception)
        {
            try
            {
                log.Warn(formatMessageCallback, exception);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Warn level using a callback to obtain the message
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatProvider">An System.IFormatProvider that supplies culture-specific formatting information.</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        /// <remarks>Using this method avoids the cost of creating a message and evaluating message arguments that probably won't be logged due to loglevel settings.</remarks>
        public static bool TryWarn(this ILog log, IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback)
        {
            try
            {
                log.Warn(formatProvider, formatMessageCallback);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message object with the Common.Logging.LogLevel.Warn level including the stack trace of the System.Exception passed as a parameter.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="message">The message object to log.</param>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        public static bool TryWarn(this ILog log, object message, Exception exception)
        {
            try
            {
                log.Warn(message, exception);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Warn level using a callback to obtain the message
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatProvider">An System.IFormatProvider that supplies culture-specific formatting information.</param>
        /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
        /// <param name="exception">The exception to log, including its stack Warn.</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        /// <remarks>Using this method avoids the cost of creating a message and evaluating message arguments that probably won't be logged due to loglevel settings.</remarks>
        public static bool TryWarn(this ILog log, IFormatProvider formatProvider, Action<FormatMessageHandler> formatMessageCallback, Exception exception)
        {
            try
            {
                log.Warn(formatProvider, formatMessageCallback, exception);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Warn level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="format">The format of the message object to log.System.String.Format(System.String,System.Object[])</param>
        /// <param name="args">the list of format arguments</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        [StringFormatMethod("format")]
        public static bool TryWarnFormat(this ILog log, string format, params object[] args)
        {
            try
            {
                log.WarnFormat(format, args);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Warn level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatProvider">An System.IFormatProvider that supplies culture-specific formatting information.</param>
        /// <param name="format">The format of the message object to log.System.String.Format(System.String,System.Object[])</param>
        /// <param name="args">the list of format arguments</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        [StringFormatMethod("format")]
        public static bool TryWarnFormat(this ILog log, IFormatProvider formatProvider, string format, params object[] args)
        {
            try
            {
                log.WarnFormat(formatProvider, format, args);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Warn level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="format">The format of the message object to log.System.String.Format(System.String,System.Object[])</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of format arguments</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        [StringFormatMethod("format")]
        public static bool TryWarnFormat(this ILog log, string format, Exception exception, params object[] args)
        {
            try
            {
                log.WarnFormat(format, exception, args);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        /// <summary>
        /// Tries to:
        /// Log a message with the Common.Logging.LogLevel.Warn level.
        /// </summary>
        /// <param name="log">The Common.Logging.ILog object</param>
        /// <param name="formatProvider">An System.IFormatProvider that supplies culture-specific formatting information.</param>
        /// <param name="format">The format of the message object to log.System.String.Format(System.String,System.Object[])</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="args">the list of format arguments</param>
        /// <returns>True if the action did not encounter any exceptions, otherwise false</returns>
        [StringFormatMethod("format")]
        public static bool TryWarnFormat(this ILog log, IFormatProvider formatProvider, string format, Exception exception, params object[] args)
        {
            try
            {
                log.WarnFormat(formatProvider, format, exception, args);
                return true;
            }
            catch
            {
                // this purposefully catches any exceptions
                return false;
            }
        }

        #endregion
    }
}
