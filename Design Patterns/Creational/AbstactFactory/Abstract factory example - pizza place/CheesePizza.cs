namespace AbstractFactory.PizzaPlaces
{
    using System.Collections.Generic;

    public class CheesePizza : Pizza
    {
        private readonly string madeBy;

        public CheesePizza(IEnumerable<string> ingredients, string madeBy)
            : base(ingredients)
        {
            this.madeBy = madeBy;
        }

        public override string Name
        {
            get
            {
                return string.Format("Cheese pizza, made by {0}", this.madeBy);
            }
        }
    }
}
