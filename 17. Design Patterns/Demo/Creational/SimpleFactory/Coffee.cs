namespace SimpleFactory
{
    public class Coffee
    {
        public Coffee(int milk, int coffee)
        {
            this.MilkContent = milk;
            this.CoffeeContent = coffee;
        }

        public int MilkContent { get; private set; }

        public int CoffeeContent { get; private set; }
    }
}
