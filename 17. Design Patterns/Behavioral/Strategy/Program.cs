namespace Strategy
{
    using System;
    using System.Collections.Generic;

    public static class Program
    {
        public static void Main()
        {
            ComparerDemo();
            Console.WriteLine(new string('-', 60));
            LoggerDemo();
        }

        private static void ComparerDemo()
        {
            var list = new List<int> { 1, 3, 5, 6, 8, 19, 100, 123, 1337 };
            list.Sort((first, second) => (first % 3).CompareTo(second % 3));
            //// list.Sort((first, second) => second.CompareTo(first)); // Different strategy
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        private static void LoggerDemo()
        {
            var logger = new FileLogger("log.txt"); // ConsoleLogger();
            var doSomethingImportant = new DoSomethingImportant(logger);
            doSomethingImportant.DoTheJob();
        }
    }
}
