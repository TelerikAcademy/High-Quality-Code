namespace AbstractFactory.PizzaPlaces
{
    using System.Collections.Generic;

    public class AlfreddosPlace : PizzaFactory
    {
        private const string name = "Alfreddo's Pizza Palace";

        public string Name
        {
            get
            {
                return name;
            }
        }

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

            var pizza = new CheesePizza(ingredients, this.Name);
            return pizza;
        }

        public override Calzone MakeCalzone()
        {
            var ingredients = new List<string> { "tomatoes", "ham", "bacon" };

            var pizza = new Calzone(ingredients, this.Name);
            return pizza;
        }

        public override PepperoniPizza MakePepperoniPizza()
        {
            var ingredients = new List<string> { "tomatoes", "pepperoni", "salami" };

            var pizza = new PepperoniPizza(ingredients, this.Name);
            return pizza;
        }
    }
}
