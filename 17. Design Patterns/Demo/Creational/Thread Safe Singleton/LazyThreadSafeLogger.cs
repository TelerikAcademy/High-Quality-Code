namespace ThreadSafeSingleton
{
    using System;
    using System.Collections.Generic;

    public sealed class LazyThreadSafeLogger
    {
        private static readonly Lazy<LazyThreadSafeLogger> Lazy =
            new Lazy<LazyThreadSafeLogger>(() => new LazyThreadSafeLogger());

        private readonly List<LogEvent> events;

        private LazyThreadSafeLogger()
        {
            this.events = new List<LogEvent>();
        }

        public static LazyThreadSafeLogger Instance
        {
            get
            {
                return Lazy.Value;
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
