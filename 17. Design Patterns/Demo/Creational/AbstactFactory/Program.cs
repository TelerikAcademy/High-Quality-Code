namespace AbstractFactory
{
    using System;

    using AbstractFactory.Factories;

    public static class Program
    {
        public static void Main()
        {
            var pizzaPlace = new AlfreddosPlace(); // new PizzaExtraordinaire();
            var yamYam = new OnlineDeliveryCompany(pizzaPlace);

            var cheesePizza = yamYam.DeliverCheesePizza();
            Console.WriteLine(cheesePizza.ToString());

            var calzone = yamYam.DeliverCalzone();
            Console.WriteLine(calzone.ToString());

            var pepperoniPizza = yamYam.DeliverPepperoniPizza();
            Console.WriteLine(pepperoniPizza.ToString());
        }
    }
}
