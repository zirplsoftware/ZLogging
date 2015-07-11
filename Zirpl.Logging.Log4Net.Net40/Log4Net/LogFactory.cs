using System;
using System.Reflection;
using log4net.Config;
using Zirpl.Logging.Common;

namespace Zirpl.Logging.Log4Net
{
    /// <summary>
    /// An ILogFactory implementation that creates ILogs
    /// </summary>
    public sealed class LogFactory : ILogFactory
    {
        private static readonly FieldInfo DeclaringTypeFieldInfo;
        private static readonly Type NewDeclaringType;

        static LogFactory()
        {
            // this is to ensure that locationInfo is correct
            //
            DeclaringTypeFieldInfo = typeof(global::Common.Logging.Log4Net.Log4NetLogger)
                .GetField("declaringType", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
            NewDeclaringType = typeof(LogWrapper);

            if (!log4net.LogManager.GetRepository().Configured)
            {
                XmlConfigurator.Configure();
            }
        }

        private LogFactory()
        {
        }

        /// <summary>
        /// Initialized the LogManager to use an instance of the CommonLogFactory
        /// </summary>
        public static void Initialize()
        {
            LogManager.LogFactory = new LogFactory();
        }

        /// <inheritdoc/>
        public ILog GetLog(string name)
        {

            var log = global::Common.Logging.LogManager.GetLogger(name);

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

            return new LogWrapper(log);
        }
    }
}