namespace AbstractFactory.Pizzas
{
    using System.Collections.Generic;

    public class PepperoniPizza : Pizza
    {
        private readonly string madeBy;

        public PepperoniPizza(IEnumerable<string> ingredients, string madeBy)
            : base(ingredients)
        {
            this.madeBy = madeBy;
        }

        protected override string Name
        {
            get
            {
                return string.Format("Pepporni Pizza made by {0}", this.madeBy);
            }
        }
    }
}
