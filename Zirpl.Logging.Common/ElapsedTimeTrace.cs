using System;

namespace Zirpl.Logging.Common
{
    internal class ElapsedTimeTrace : IDisposable
    {
        private readonly Type _ownerType;
        private readonly string _traceName;
        private readonly DateTime _startTime;

        internal ElapsedTimeTrace(Type ownerType, string traceName, bool logStart)
        {
            _ownerType = ownerType;
            _traceName = traceName;
            _startTime = DateTime.Now;
            if (logStart)
            {
                LogManager.GetLog(_ownerType).TraceFormat("{0}: start", _traceName);
            }
        }

        public void Dispose()
        {
            var elapsedTime = DateTime.Now.Subtract(_startTime);
            LogManager.GetLog(_ownerType).Trace(format => format("{0}: end- elapsed time {1:c}", _traceName, elapsedTime));
        }
    }
}