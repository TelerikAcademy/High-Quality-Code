namespace AbstractFactory.Factories
{
    using System.Collections.Generic;

    using AbstractFactory.Pizzas;

    public class PizzaExtraordinaire : PizzaFactory
    {
        private const string Name = "Pizza Extraordinaire";

        public override CheesePizza MakeCheesePizza()
        {
            var ingredients = new List<string> { "rotten tomatoes", "grey cheese", "green cheese" };
            var pizza = new CheesePizza(ingredients, Name);
            return pizza;
        }

        public override Calzone MakeCalzone()
        {
            var ingredients = new List<string> { "rotten tomatoes", "greasy ham" };
            var pizza = new Calzone(ingredients, Name);
            return pizza;
        }

        public override PepperoniPizza MakePepperoniPizza()
        {
            var ingredients = new List<string> { "old salami", "green tomatoes" };
            var pizza = new PepperoniPizza(ingredients, Name);
            return pizza;
        }
    }
}
