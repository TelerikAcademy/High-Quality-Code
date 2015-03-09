namespace SimpleFactory
{
    using System;

    public class CoffeeFactory
    {
        // Parameter can be string (e.g. from configuration file)
        // Also the method can be static but we won't be able to extend the class
        public Coffee GetCoffee(CoffeeType coffeeType)
        {
            // Can also be implemented using dictionary
            switch (coffeeType)
            {
                case CoffeeType.Regular:
                    // Can be subtype of Coffee
                    return new Coffee(0, 150);
                case CoffeeType.Double:
                    return new Coffee(0, 200);
                case CoffeeType.Cappuccino:
                    return new Coffee(100, 100);
                case CoffeeType.Macchiato:
                    return new Coffee(200, 100);
                default:
                    throw new ArgumentException();
            }
        }
    }
}
