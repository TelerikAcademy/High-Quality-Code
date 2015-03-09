namespace AbstractFactory.PizzaPlaces
{
    using System.Collections.Generic;

    public class PizzaExtraordinaire : PizzaFactory
    {
        private const string name = "Pizza Extraordinaire";

        public string Name
        {
            get
            {
                return name;
            }
        }

        public override CheesePizza MakeCheesePizza()
        {
            var ingredients = new List<string> { "rotten tomatoes", "grey cheese", "green cheese" };
            var pizza = new CheesePizza(ingredients, this.Name);
            return pizza;
        }

        public override Calzone MakeCalzone()
        {
            var ingredients = new List<string> { "rotten tomatoes", "greasy ham" };
            var pizza = new Calzone(ingredients, this.Name);
            return pizza;
        }

        public override PepperoniPizza MakePepperoniPizza()
        {
            var ingredients = new List<string> { "old salami", "green tomatoes" };
            var pizza = new PepperoniPizza(ingredients, this.Name);
            return pizza;
        }
    }
}
