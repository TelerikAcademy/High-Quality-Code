namespace AbstractFactory.PizzaPlaces
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var pizzaPlace = new PizzaExtraordinaire();
            var yamYam = new OnlineDeliveryCompany(pizzaPlace);

            var cheesePizza = yamYam.DeliverCheesePizza();

            Console.WriteLine(cheesePizza.Name);
            Console.WriteLine("Ingredients: ");
            foreach (var ingredient in cheesePizza.Ingredients)
            {
                Console.WriteLine(ingredient);
            }
        }
    }
}
