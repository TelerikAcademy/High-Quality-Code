namespace ThreadSafeSingleton.Logger
{
    using System;
    using System.Threading;

    public class Program
    {
        public static void Main()
        {
            var log = ThreadSafeLogger.Instance;
            log.SaveToLog("message from thread 1");

            var secondThread = new Thread(x =>
                                            {
                                                var log2 = ThreadSafeLogger.Instance;
                                                log2.SaveToLog("message from thread 2");
                                                Thread.Sleep(1); // to illustrate how it works
                                            });
            secondThread.Start();

            while (secondThread.ThreadState != ThreadState.Stopped)
            {
                Console.WriteLine("Thread 2 is still working");
            }

            log.PrintLog();
        }
    }
}
