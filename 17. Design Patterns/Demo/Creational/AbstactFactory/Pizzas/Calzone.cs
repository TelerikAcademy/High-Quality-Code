namespace AbstractFactory.Pizzas
{
    using System.Collections.Generic;

    public class Calzone : Pizza
    {
        private readonly string madeBy;

        public Calzone(IEnumerable<string> ingredients, string madeBy)
            : base(ingredients)
        {
            this.madeBy = madeBy;
        }

        protected override string Name
        {
            get
            {
                return string.Format("Calzone made by {0}", this.madeBy);
            }
        }
    }
}
