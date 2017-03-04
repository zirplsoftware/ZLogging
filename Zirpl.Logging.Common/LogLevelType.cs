using Common.Logging;

namespace Zirpl.Logging.Common
{
    /// <summary>
    /// A LogLevel and Description pair
    /// </summary>
    public class LogLevelType
    {
        /// <summary>
        /// Gets/Sets the LogLevel
        /// </summary>
        public LogLevel LogLevel { get; set; }

        /// <summary>
        /// Gets/Sets the Description
        /// </summary>
        public string Description { get; set; }
    }
}