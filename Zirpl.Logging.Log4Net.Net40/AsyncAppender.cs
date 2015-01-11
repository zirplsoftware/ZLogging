#if !NET35CLIENT && !NET40CLIENT && !SILVERLIGHT
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
    public sealed class AsyncAppender : IAppender, IBulkAppender, IOptionHandler, IAppenderAttachable
    {
        private AppenderAttachedImpl appenderAttachedImpl;
        public string Name { get; set; }
        public FixFlags Fix { get; set; }

        public void ActivateOptions()
        {
        }


        public void Close()
        {
            // Remove all the attached appenders
            lock (this)
            {
                if (appenderAttachedImpl != null)
                {
                    appenderAttachedImpl.RemoveAllAppenders();
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
            if (appenderAttachedImpl != null)
            {
                LoggingEvent loggingEvent = state as LoggingEvent;
                if (loggingEvent != null)
                {
                    appenderAttachedImpl.AppendLoopOnAppenders(loggingEvent);
                }
                else
                {
                    LoggingEvent[] loggingEvents = state as LoggingEvent[];
                    if (loggingEvents != null)
                    {
                        appenderAttachedImpl.AppendLoopOnAppenders(loggingEvents);
                    }
                }
            }
        }

        #region IAppenderAttachable Members

        public void AddAppender(IAppender newAppender)
        {
            if (newAppender == null)
            {
                throw new ArgumentNullException("newAppender");
            }
            lock (this)
            {
                if (appenderAttachedImpl == null)
                {
                    appenderAttachedImpl = new log4net.Util.AppenderAttachedImpl();
                }
                appenderAttachedImpl.AddAppender(newAppender);
            }
        }

        public AppenderCollection Appenders
        {
            get
            {
                lock (this)
                {
                    if (appenderAttachedImpl == null)
                    {
                        return AppenderCollection.EmptyCollection;
                    }
                    else
                    {
                        return appenderAttachedImpl.Appenders;
                    }
                }
            }
        }

        public IAppender GetAppender(string name)
        {
            lock (this)
            {
                if (appenderAttachedImpl == null || name == null)
                {
                    return null;
                }

                return appenderAttachedImpl.GetAppender(name);
            }
        }

        public void RemoveAllAppenders()
        {
            lock (this)
            {
                if (appenderAttachedImpl != null)
                {
                    appenderAttachedImpl.RemoveAllAppenders();
                    appenderAttachedImpl = null;
                }
            }
        }

        public IAppender RemoveAppender(IAppender appender)
        {
            lock (this)
            {
                if (appender != null && appenderAttachedImpl != null)
                {
                    return appenderAttachedImpl.RemoveAppender(appender);
                }
            }
            return null;
        }

        public IAppender RemoveAppender(string name)
        {
            lock (this)
            {
                if (name != null && appenderAttachedImpl != null)
                {
                    return appenderAttachedImpl.RemoveAppender(name);
                }
            }
            return null;
        }

        #endregion


        public AsyncAppender()
        {
            Fix = FixFlags.All;
        }
    }
}

#endif