using Common.Logging;

namespace Zirpl.Logging.Common
{
    /// <summary>
    /// Provides access to manipulate the configuration file (if there is one)
    /// </summary>
    public interface ILogConfigurationService
    {
        /// <summary>
        /// Sets the min LogLevel on the logging configuration file found at the specified file path
        /// </summary>
        void SetMinLogLevelOfAllLoggers(string configurationFilePath, LogLevel logLevel);

        /// <summary>
        /// Loads the logging configuration file found at the specified file path
        /// </summary>
        void LoadConfigurationFile(string configurationFilePath);

        /// <summary>
        /// Copies the current default configuration file to the specified destination directory
        /// </summary>
        void CopyDefaultConfigurationFile(string toFilePath);
    }
}