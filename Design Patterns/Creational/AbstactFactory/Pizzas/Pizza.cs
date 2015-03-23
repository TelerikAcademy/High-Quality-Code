namespace AbstractFactory.Pizzas
{
    using System.Collections.Generic;
    using System.Text;

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

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(this.Name);
            stringBuilder.AppendLine(string.Join(", ", this.Ingredients));
            return stringBuilder.ToString();
        }
    }
}
