using System;
using log4net.Config;
using Zirpl.Logging.Log4Net.Common;

namespace Zirpl.Logging.Log4Net
{
    /// <summary>
    /// An ILogFactory implementation that creates ILogs
    /// </summary>
    public sealed class LogFactory : ILogFactory
    {
        private static Boolean _initialized;

        /// <summary>
        /// Initializes the LogManager
        /// </summary>
        internal LogFactory()
        {
            if (!log4net.LogManager.GetRepository().Configured)
            {
                XmlConfigurator.Configure();
                LogManager.GetLog<LogFactory>().DebugFormat("Loaded log4net config.");
            }
            else
            {
                LogManager.GetLog<LogFactory>().DebugFormat("log4net already configured.");
            }
        }

        /// <summary>
        /// Initialized the LogManager to use an instance of the CommonLogFactory
        /// </summary>
        public static void Initialize()
        {
            if (_initialized) return;
            LogManager.LogFactory = new LogFactory();
            _initialized = true;
        }

        /// <inheritdoc/>
        public ILog GetLog(string name)
        {
            if (!_initialized)
            {
                return new NullLog();
            }
            return new LogWrapper(name);
        }
    }
}