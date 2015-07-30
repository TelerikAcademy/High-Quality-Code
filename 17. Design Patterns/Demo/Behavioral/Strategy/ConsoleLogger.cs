namespace Strategy
{
    using System;

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("[{0}] {1}", DateTime.Now.ToLongTimeString(), message);
        }
    }
}
