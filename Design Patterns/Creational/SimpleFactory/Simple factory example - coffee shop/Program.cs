namespace SimpleFactory.CoffeeShop
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var macchiato = CoffeeFactory.GetCoffee(CoffeeType.Macchiato);
            var regularCoffee = CoffeeFactory.GetCoffee(CoffeeType.Regular);
            Console.WriteLine("Macchiato - Milk content: {0} ml, Coffee content: {1} ml", macchiato.MilkContent, macchiato.CoffeeContent);
            Console.WriteLine("Regular coffee - Milk content: {0} ml, Coffee content: {1} ml", regularCoffee.MilkContent, regularCoffee.CoffeeContent);
        }
    }
}
