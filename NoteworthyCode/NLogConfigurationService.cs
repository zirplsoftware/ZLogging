using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using Common.Logging;

namespace Numotion.Logging.NLog
{
    /// <summary>
    /// Implementation of the ILogConfigurationService for NLog
    /// NOTE: this class assumes the NLog config has been specified in its
    /// own file alongside the deployed application in NLog.config.  If your application
    /// needs to do this differently, this will have to be updated, or a custom implementation created
    /// </summary>
    public class NLogConfigurationService : ILogConfigurationService
    {
        /// <summary>
        /// The config file name
        /// </summary>
        public const string DefaultConfigFileName = "NLog.config";

        /// <summary>
        /// Copies the current default configuration file to the specified destination file path
        /// </summary>
        public void CopyDefaultConfigurationFile(string toFilePath)
        {
            if (string.IsNullOrEmpty(toFilePath))
            {
                throw new ArgumentNullException(nameof(toFilePath));
            }

            var fromPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), DefaultConfigFileName);
            if (!File.Exists(fromPath))
            {
                throw new FileNotFoundException("NLog configuration file not found", fromPath);
            }
            File.Copy(fromPath, toFilePath, true);
        }

        /// <summary>
        /// Loads the logging configuration file found at the specified file path
        /// </summary>
        public void LoadConfigurationFile(string configurationFilePath)
        {
            if (string.IsNullOrEmpty(configurationFilePath))
            {
                throw new ArgumentNullException(nameof(configurationFilePath));
            }

            global::NLog.LogManager.Configuration = new global::NLog.Config.XmlLoggingConfiguration(configurationFilePath);
        }

        /// <summary>
        /// Sets the min LogLevel on the logging configuration file found at the specified file path
        /// </summary>
        public void SetMinLogLevelOfAllLoggers(string configurationFilePath, LogLevel logLevel)
        {
            if (string.IsNullOrEmpty(configurationFilePath))
            {
                throw new ArgumentNullException(nameof(configurationFilePath));
            }

            switch (logLevel)
            {
                case LogLevel.All:
                case LogLevel.Trace:
                    SetMinLogLevelOfAllLoggers(configurationFilePath, global::NLog.LogLevel.Trace);
                    break;
                case LogLevel.Debug:
                    SetMinLogLevelOfAllLoggers(configurationFilePath, global::NLog.LogLevel.Debug);
                    break;
                case LogLevel.Info:
                    SetMinLogLevelOfAllLoggers(configurationFilePath, global::NLog.LogLevel.Info);
                    break;
                case LogLevel.Warn:
                    SetMinLogLevelOfAllLoggers(configurationFilePath, global::NLog.LogLevel.Warn);
                    break;
                case LogLevel.Error:
                    SetMinLogLevelOfAllLoggers(configurationFilePath, global::NLog.LogLevel.Error);
                    break;
                case LogLevel.Fatal:
                    SetMinLogLevelOfAllLoggers(configurationFilePath, global::NLog.LogLevel.Fatal);
                    break;
                case LogLevel.Off:
                    SetMinLogLevelOfAllLoggers(configurationFilePath, global::NLog.LogLevel.Off);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
            }
        }

        private void SetMinLogLevelOfAllLoggers(string configurationFilePath, global::NLog.LogLevel logLevel)
        {
            if (string.IsNullOrEmpty(configurationFilePath))
            {
                throw new ArgumentNullException(nameof(configurationFilePath));
            }

            foreach (var rule in global::NLog.LogManager.Configuration.LoggingRules)
            {
                rule.EnableLoggingForLevel(logLevel);
            }

            //Call to update existing Loggers created with GetLogger() or 
            //GetCurrentClassLogger()
            global::NLog.LogManager.ReconfigExistingLoggers();
            
            var document = new XmlDocument();
            document.Load(configurationFilePath);
            if (document.DocumentElement != null)
            {
                foreach (var node in document.DocumentElement.ChildNodes.OfType<XmlNode>().Where(o => "rules".Equals(o.Name, StringComparison.InvariantCultureIgnoreCase)))
                {
                    foreach (var childNode in node.ChildNodes.OfType<XmlNode>().Where(o => "logger".Equals(o.Name, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        var minLevelAttribute = childNode.Attributes?["minlevel"];
                        if (minLevelAttribute != null)
                        {
                            minLevelAttribute.Value = logLevel.Name;
                        }
                    }
                }

                document.Save(configurationFilePath);
            }
        }
    }
}