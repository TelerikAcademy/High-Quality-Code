namespace Singleton
{
    using System;

    public class LogEvent
    {
        public LogEvent(string message)
        {
            this.Message = message;
            this.EventDate = DateTime.Now;
        }

        public string Message { get; private set; }

        public DateTime EventDate { get; private set; }
    }
}
