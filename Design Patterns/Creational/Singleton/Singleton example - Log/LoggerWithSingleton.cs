namespace Singleton.Logger
{
    using System;
    using System.Collections.Generic;

    public sealed class Logger
    {
        private static readonly Logger logger = new Logger();

        private readonly List<LogEvent> events;

        private Logger()
        {
            this.events = new List<LogEvent>();
        }

        public static Logger Instance
        {
            get
            {
                return logger;
            }
        }

        public void SaveToLog(string message)
        {
            this.events.Add(new LogEvent(message));
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
