using System;
using System.Threading;
using log4net.Appender;
using log4net.Core;
using log4net.Util;

namespace Zirpl.Logging.Log4Net
{
    /// <summary>
    /// Appender that forwards LoggingEvents asynchronously
    /// </summary>
    /// <remarks>
    /// This appender forwards LoggingEvents to a list of attached appenders.
    /// The events are forwarded asynchronously using the ThreadPool.
    /// This allows the calling thread to be released quickly, however it does
    /// not guarantee the ordering of events delivered to the attached appenders.
    /// </remarks>
    public sealed class AsyncForwardingAppender : IAppender, IBulkAppender, IOptionHandler, IAppenderAttachable
    {
        private AppenderAttachedImpl _appenderAttachedImpl;
        public string Name { get; set; }

        /// <summary>
        /// Flags passed to the LoggingEvent.Fix property
        /// </summary>
        public FixFlags Fix { get; set; }
        
        /// <summary>
        /// Creates a new AsyncForwardingAppender instance
        /// </summary>
        public AsyncForwardingAppender()
        {
            Fix = FixFlags.All;
        }

        public void ActivateOptions()
        {
        }
        
        public void Close()
        {
            // Remove all the attached appenders
            lock (this)
            {
                if (_appenderAttachedImpl != null)
                {
                    _appenderAttachedImpl.RemoveAllAppenders();
                }
            }
        }

        public void DoAppend(LoggingEvent loggingEvent)
        {
            loggingEvent.Fix = Fix;
            ThreadPool.QueueUserWorkItem(new WaitCallback(AsyncAppend), loggingEvent);
        }

        public void DoAppend(LoggingEvent[] loggingEvents)
        {
            foreach (LoggingEvent loggingEvent in loggingEvents)
            {
                loggingEvent.Fix = Fix;
            }
            ThreadPool.QueueUserWorkItem(new WaitCallback(AsyncAppend), loggingEvents);
        }

        private void AsyncAppend(object state)
        {
            lock (this)
            {
                if (_appenderAttachedImpl != null)
                {
                    var loggingEvent = state as LoggingEvent;
                    var loggingEvents = state as LoggingEvent[];
                    if (loggingEvent != null)
                    {
                        _appenderAttachedImpl.AppendLoopOnAppenders(loggingEvent);
                    }
                    else if (loggingEvents != null)
                    {
                        _appenderAttachedImpl.AppendLoopOnAppenders(loggingEvents);
                    }
                }
            }
        }

        #region IAppenderAttachable Members

        public void AddAppender(IAppender newAppender)
        {
            if (newAppender == null) throw new ArgumentNullException("newAppender");

            lock (this)
            {
                if (_appenderAttachedImpl == null)
                {
                    _appenderAttachedImpl = new log4net.Util.AppenderAttachedImpl();
                }
                _appenderAttachedImpl.AddAppender(newAppender);
            }
        }

        public AppenderCollection Appenders
        {
            get
            {
                lock (this)
                {
                    if (_appenderAttachedImpl == null)
                    {
                        return AppenderCollection.EmptyCollection;
                    }
                    else
                    {
                        return _appenderAttachedImpl.Appenders;
                    }
                }
            }
        }

        public IAppender GetAppender(string name)
        {
            lock (this)
            {
                if (_appenderAttachedImpl == null 
                    || name == null)
                {
                    return null;
                }

                return _appenderAttachedImpl.GetAppender(name);
            }
        }

        public void RemoveAllAppenders()
        {
            lock (this)
            {
                if (_appenderAttachedImpl != null)
                {
                    _appenderAttachedImpl.RemoveAllAppenders();
                    _appenderAttachedImpl = null;
                }
            }
        }

        public IAppender RemoveAppender(IAppender appender)
        {
            lock (this)
            {
                if (appender != null
                    && _appenderAttachedImpl != null)
                {
                    return _appenderAttachedImpl.RemoveAppender(appender);
                }
            }
            return null;
        }

        public IAppender RemoveAppender(string name)
        {
            lock (this)
            {
                if (name != null 
                    && _appenderAttachedImpl != null)
                {
                    return _appenderAttachedImpl.RemoveAppender(name);
                }
            }
            return null;
        }

        #endregion

    }
}