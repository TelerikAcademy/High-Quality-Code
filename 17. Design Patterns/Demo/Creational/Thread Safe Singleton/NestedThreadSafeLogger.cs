namespace ThreadSafeSingleton
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    public sealed class NestedThreadSafeLogger
    {
        private readonly List<LogEvent> events;

        private NestedThreadSafeLogger()
        {
            this.events = new List<LogEvent>();
        }

        public static NestedThreadSafeLogger Instance
        {
            get
            {
                return SingletonContainer.Instance;
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

        private static class SingletonContainer
        {
            internal static readonly NestedThreadSafeLogger Instance = new NestedThreadSafeLogger();

            // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
            // which will initialize the fields (Instance) just before their first use (not earlier)
            [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1409:RemoveUnnecessaryCode",
                Justification = "Reviewed. Suppression is OK here.")]
            static SingletonContainer()
            {
            }
        }
    }
}
