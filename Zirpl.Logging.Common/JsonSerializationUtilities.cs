using Newtonsoft.Json;

namespace Zirpl.Logging.Common
{
    /// <summary>
    /// Provides utility methods to convert objects to JSON
    /// </summary>
    public static class JsonSerializationUtilities
    {
        /// <summary>
        /// Converts the specified object to loggable JSON (formatted, ignoring reference loops, does not preserve references)
        /// 
        /// Use like this to avoid heavy JSON serialization operations if the log event won't be logged due to levels/logger name:
        /// <code>
        /// this.GetLog().Debug(formatHandler("Here is the data: {0}", myData.ToLoggableJson()));
        /// </code>
        /// </summary>
        public static string ToLoggableJson(this object data)
        {
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.None
            };

            return JsonConvert.SerializeObject(data, Formatting.Indented, settings);
        }
    }
}