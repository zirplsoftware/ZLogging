using System;

namespace Zirpl.Logging
{
    /// <summary>
    /// A factor for creating <see cref="ILog"/> objects
    /// </summary>
    public interface ILogFactory
    {
        /// <summary>
        /// Gets the <see cref="ILog"/> for the specified name
        /// </summary>
        /// <param name="name">Name of the Log</param>
        /// <returns>The <see cref="ILog"/> for the specified name</returns>
        ILog GetLog(String name);
    }
}
