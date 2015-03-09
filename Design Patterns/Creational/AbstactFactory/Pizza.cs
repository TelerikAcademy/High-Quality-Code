namespace AbstractFactory.PizzaPlaces
{
    using System.Collections.Generic;

    public abstract class Pizza
    {
        private readonly IReadOnlyCollection<string> ingredients;

        protected Pizza(IEnumerable<string> ingredients)
        {
            this.ingredients = new List<string>(ingredients);
        }

        public IEnumerable<string> Ingredients
        {
            get
            {
                return this.ingredients;
            }
        }

        public abstract string Name { get; }
    }
}
