using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Common.Logging;

namespace Zirpl.Logging.Common
{
    /// <summary>
    /// Helper class that provides easy extension methods to get logs
    /// </summary>
    public static class LogManager
    {
        private static ILogConfigurationService _logConfigurationService;

        /// <summary>
        /// Initializes the LogManager with the provided ILogConfigurationService implementation
        /// </summary>
        /// <param name="logConfigurationService">The log configuration service</param>
        public static void Initialize(ILogConfigurationService logConfigurationService)
        {
            _logConfigurationService = logConfigurationService;
        }

        /// <summary>
        /// Gets the default Log
        /// </summary>
        /// <returns>The default Log</returns>
        public static ILog GetLog()
        {
            return global::Common.Logging.LogManager.GetLogger(string.Empty);
        }

        /// <summary>
        /// Gets the ILog of the specified name
        /// </summary>
        /// <param name="name">Name of the log to get</param>
        /// <returns>The ILog</returns>
        public static ILog GetLog(string name)
        {
            return global::Common.Logging.LogManager.GetLogger(name);
        }

        /// <summary>
        /// Gets the log for the specified type
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The log</returns>
        public static ILog GetLog(Type type)
        {
            if (type == null)
            {
                return global::Common.Logging.LogManager.GetLogger(string.Empty);
            }
            return type.IsGenericType
                ? global::Common.Logging.LogManager.GetLogger(type.ToGenericTypeString())
                : global::Common.Logging.LogManager.GetLogger(type);
        }

        /// <summary>
        /// Gets the log for the specified type. This is an extension method.
        /// </summary>
        /// <typeparam name="TLogConsumer">The type of the log consumer.</typeparam>
        /// <param name="obj">The object of the type consuming the log</param>
        /// <returns>The log.</returns>
        public static ILog GetLog<TLogConsumer>(this TLogConsumer obj)
        {
            var type = typeof(TLogConsumer);
            return type.IsGenericType
                ? global::Common.Logging.LogManager.GetLogger(type.ToGenericTypeString())
                : global::Common.Logging.LogManager.GetLogger<TLogConsumer>();
        }

        /// <summary>
        /// Gets the log for the specified type. This is an extension method.
        /// </summary>
        /// <typeparam name="TLogConsumer">The type of the log consumer.</typeparam>
        /// <returns>The log.</returns>
        public static ILog GetLog<TLogConsumer>()
        {
            var type = typeof(TLogConsumer);
            return type.IsGenericType
                ? global::Common.Logging.LogManager.GetLogger(type.ToGenericTypeString())
                : global::Common.Logging.LogManager.GetLogger<TLogConsumer>();
        }

        private static string ToGenericTypeString(this Type t)
        {
            if (!t.IsGenericType)
                return t.FullName;
            var genericTypeName = t.GetGenericTypeDefinition().FullName;
            genericTypeName = genericTypeName.Substring(0,
                                                        genericTypeName.IndexOf('`'));
            var genericArgs = string.Join(",",
                                             t.GetGenericArguments()
                                              .Select(ToGenericTypeString).ToArray());
            return genericTypeName + "<" + genericArgs + ">";
        }

        /// <summary>
        /// Sets the Min Log Level in the configuration file
        /// </summary>
        public static void SetMinLogLevel(string configurationFilePath, LogLevel logLevel)
        {
            _logConfigurationService.SetMinLogLevelOfAllLoggers(configurationFilePath, logLevel);
        }

        /// <summary>
        /// Loads the configuration from file path specified
        /// </summary>
        public static void LoadConfigurationFile(string configurationFilePath)
        {
            _logConfigurationService.LoadConfigurationFile(configurationFilePath);
        }

        /// <summary>
        /// Copies the default configuration file to the specified path
        /// </summary>
        public static void CopyDefaultConfigurationFile(string toFilePath)
        {
            _logConfigurationService.CopyDefaultConfigurationFile(toFilePath);
        }

        /// <summary>
        /// Gets all of the LogLevelTypes
        /// </summary>
        public static IEnumerable<LogLevelType> GetAllLogLevelTypes()
        {
            return new []
            {
                new LogLevelType {LogLevel = LogLevel.All, Description = "All"},
                new LogLevelType {LogLevel = LogLevel.Trace, Description = "Trace"},
                new LogLevelType {LogLevel = LogLevel.Debug, Description = "Debug"},
                new LogLevelType {LogLevel = LogLevel.Info, Description = "Info"},
                new LogLevelType {LogLevel = LogLevel.Warn, Description = "Warn"},
                new LogLevelType {LogLevel = LogLevel.Error, Description = "Error"},
                new LogLevelType {LogLevel = LogLevel.Fatal, Description = "Fatal"},
                new LogLevelType {LogLevel = LogLevel.Off, Description = "Off"}
            };
        }

        /// <summary>
        /// Starts a Trace that will log the elapsed time when disposed. Usage:
        /// <code>
        /// using (var timeTracer = this.StartElapsedTimeTrace())
        /// {
        /// }
        /// </code>
        /// </summary>
        /// <param name="owner">Owning object</param>
        /// <param name="traceName">Name of trace. Defaults to the name of the calling method</param>
        /// <param name="logStart">Whether or not to write the start of the trace to the log</param>
        public static IDisposable StartElapsedTimeTrace(this object owner, [CallerMemberName]string traceName = "", bool logStart = false)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }
            if (string.IsNullOrEmpty(traceName))
            {
                throw new ArgumentNullException(nameof(traceName));
            }

            return new ElapsedTimeTrace(owner.GetType(), traceName, logStart);
        }

        /// <summary>
        /// Starts a Trace that will log the elapsed time when disposed. Usage:
        /// <code>
        /// using (var timeTracer = LogManager.StartElapsedTimeTrace(typeof(MyClass))
        /// {
        /// }
        /// </code>
        /// </summary>
        /// <param name="ownerType">Owning type</param>
        /// <param name="traceName">Name of trace. Defaults to the name of the calling method</param>
        /// <param name="logStart">Whether or not to write the start of the trace to the log</param>
        public static IDisposable StartElapsedTimeTrace(Type ownerType, [CallerMemberName]string traceName = "", bool logStart = false)
        {
            if (ownerType == null)
            {
                throw new ArgumentNullException(nameof(ownerType));
            }
            if (string.IsNullOrEmpty(traceName))
            {
                throw new ArgumentNullException(nameof(traceName));
            }

            return new ElapsedTimeTrace(ownerType, traceName, logStart);
        }
    }
}