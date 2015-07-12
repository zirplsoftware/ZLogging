using System;
using System.Linq;
using Common.Logging;

namespace Zirpl.Logging.Common
{
    /// <summary>
    /// Helper class that provides easy extension methods to get logs
    /// </summary>
    public static class LogManager
    {
        /// <summary>
        /// Gets the default Log
        /// </summary>
        /// <returns>The default Log</returns>
        public static ILog GetLogger()
        {
            return global::Common.Logging.LogManager.GetLogger(String.Empty);
        }

        /// <summary>
        /// Gets the ILog of the specified name
        /// </summary>
        /// <param name="name">Name of the log to get</param>
        /// <returns>The ILog</returns>
        public static ILog GetLogger(String name)
        {
            return global::Common.Logging.LogManager.GetLogger(name);
        }

        /// <summary>
        /// Gets the log for the specified type
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The log</returns>
        public static ILog GetLogger(Type type)
        {
            if (type == null)
            {
                return global::Common.Logging.LogManager.GetLogger(String.Empty);
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
        public static ILog GetLogger<TLogConsumer>(this TLogConsumer obj)
        {
            var type = typeof (TLogConsumer);
            return type.IsGenericType 
                ? global::Common.Logging.LogManager.GetLogger(type.ToGenericTypeString()) 
                : global::Common.Logging.LogManager.GetLogger<TLogConsumer>();
        }

        /// <summary>
        /// Gets the log for the specified type. This is an extension method.
        /// </summary>
        /// <typeparam name="TLogConsumer">The type of the log consumer.</typeparam>
        /// <returns>The log.</returns>
        public static ILog GetLogger<TLogConsumer>()
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
            string genericTypeName = t.GetGenericTypeDefinition().FullName;
            genericTypeName = genericTypeName.Substring(0,
                                                        genericTypeName.IndexOf('`'));
            string genericArgs = String.Join(",",
                                             t.GetGenericArguments()
                                              .Select(ToGenericTypeString).ToArray());
            return genericTypeName + "<" + genericArgs + ">";
        }
    }
}
