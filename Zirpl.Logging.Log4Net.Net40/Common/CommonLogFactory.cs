using System;
using log4net.Config;

namespace Zirpl.Logging.Log4Net.Common
{
    /// <summary>
    /// An ILogFactory implementation that creates ILog using Common.Logging 
    /// Logger backings
    /// </summary>
    public sealed class CommonLogFactory : ILogFactory
    {
        private static Boolean _initialized;

        /// <summary>
        /// Initializes the LogManager
        /// </summary>
        internal CommonLogFactory()
        {
            if (!log4net.LogManager.GetRepository().Configured)
            {
                XmlConfigurator.Configure();
                LogManager.GetLog<CommonLogFactory>().DebugFormat("Loaded log4net config.");
            }
            else
            {
                LogManager.GetLog<CommonLogFactory>().DebugFormat("log4net already configured.");
            }
        }

        /// <summary>
        /// Initialized the LogManager to use an instance of the CommonLogFactory
        /// </summary>
        public static void Initialize()
        {
            if (!_initialized)
            {
                LogManager.LogFactory = new CommonLogFactory();
                _initialized = true;
            }
        }

        public ILog GetLog(string name)
        {
            if (!_initialized)
                return new NullLog();
            else
                return new CommonLogWrapper(global::Common.Logging.LogManager.GetLogger(name));
        }
    }
}