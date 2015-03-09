namespace AbstractFactory.Factories
{
    using System.Collections.Generic;

    using AbstractFactory.Pizzas;

    public class AlfreddosPlace : PizzaFactory
    {
        private const string Name = "Alfreddo's Pizza Palace";

        public override CheesePizza MakeCheesePizza()
        {
            var ingredients = new List<string>
                                  {
                                      "tomatoes",
                                      "white cheese",
                                      "yellow cheese",
                                      "blue cheese",
                                      "extra smelly cheese"
                                  };
            var pizza = new CheesePizza(ingredients, Name);
            return pizza;
        }

        public override Calzone MakeCalzone()
        {
            var ingredients = new List<string> { "tomatoes", "ham", "bacon" };
            var pizza = new Calzone(ingredients, Name);
            return pizza;
        }

        public override PepperoniPizza MakePepperoniPizza()
        {
            var ingredients = new List<string> { "tomatoes", "pepperoni", "salami" };
            var pizza = new PepperoniPizza(ingredients, Name);
            return pizza;
        }
    }
}
