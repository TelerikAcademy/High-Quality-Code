namespace SimpleFactory
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            var coffeeFactory = new CoffeeFactory();
            var cappuccino = coffeeFactory.GetCoffee(CoffeeType.Cappuccino);
            var regularCoffee = coffeeFactory.GetCoffee(CoffeeType.Regular);
            Console.WriteLine("Cappuccino - Milk content: {0} ml, Coffee content: {1} ml", cappuccino.MilkContent, cappuccino.CoffeeContent);
            Console.WriteLine("Regular coffee - Milk content: {0} ml, Coffee content: {1} ml", regularCoffee.MilkContent, regularCoffee.CoffeeContent);
        }
    }
}
