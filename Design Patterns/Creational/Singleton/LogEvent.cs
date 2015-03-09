namespace Singleton
{
    using System;

    public class LogEvent
    {
        private readonly string message;

        private readonly DateTime eventDate;

        public LogEvent(string message)
        {
            this.message = message;
            this.eventDate = DateTime.Now;
        }

        public string Message
        {
            get { return this.message; }
        }

        public DateTime EventDate
        {
            get { return this.eventDate; }
        }
    }
}
