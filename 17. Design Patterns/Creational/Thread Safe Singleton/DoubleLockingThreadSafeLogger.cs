namespace ThreadSafeSingleton
{
    using System;
    using System.Collections.Generic;

    public sealed class DoubleLockingThreadSafeLogger
    {
        private static volatile DoubleLockingThreadSafeLogger logger;

        private static object syncLock = new object();

        private readonly List<LogEvent> events;

        private DoubleLockingThreadSafeLogger()
        {
            this.events = new List<LogEvent>();
        }

        public static DoubleLockingThreadSafeLogger Instance
        {
            get
            {
                if (logger == null)
                {
                    lock (syncLock)
                    {
                        if (logger == null)
                        {
                            logger = new DoubleLockingThreadSafeLogger();
                        }
                    }
                }

                return logger;
            }
        }

        public void SaveToLog(object message)
        {
            this.events.Add(new LogEvent(message.ToString()));
        }

        public void PrintLog()
        {
            foreach (var ev in this.events)
            {
                Console.WriteLine("Time: {0}, Event: {1}", ev.EventDate.ToShortTimeString(), ev.Message);
            }
        }
    }
}
