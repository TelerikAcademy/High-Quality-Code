namespace SimpleFactory
{
    public class Coffee
    {
        public Coffee(int milk, int coffee)
        {
            this.MilkContent = milk;
            this.CoffeeContent = coffee;
        }

        public int MilkContent { get; set; }

        public int CoffeeContent { get; set; }
    }
}
