namespace Iterator
{
    using System;
    using System.Collections.Generic;

    using Iterator.ClearImplementation;

    public static class Program
    {
        public static void Main()
        {
            ClearImplementationDemo();
            Console.WriteLine(new string('-', 60));
            ImplementationInDotNet();
            Console.WriteLine(new string('-', 60));
            YieldExample();
        }

        private static void ClearImplementationDemo()
        {
            var aggregate = new ConcreteAggregate();
            aggregate[0] = "Item A";
            aggregate[1] = "Item B";
            aggregate[2] = "Item C";
            aggregate[3] = "Item D";

            // Create Iterator and provide aggregate
            IIterator iterator = new ConcreteIterator(aggregate);

            Console.WriteLine("Iterating over collection:");

            while (!iterator.IsDone())
            {
                Console.WriteLine(iterator.CurrentItem());
                iterator.Next();
            }
        }

        private static void ImplementationInDotNet()
        {
            var list = new List<int> { 1, 2, 3, 4 };
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        private static void YieldExample()
        {
            var evenNumbers = EvenNumbersInRange(1, 10);
            foreach (var evenNumber in evenNumbers)
            {
                Console.WriteLine(evenNumber);
            }
        }

        private static IEnumerable<int> EvenNumbersInRange(int lowerBound, int upperBound)
        {
            if (lowerBound % 2 != 0)
            {
                lowerBound++;
            }

            for (int i = lowerBound; i <= upperBound; i += 2)
            {
                yield return i;
            }
        }
    }
}
