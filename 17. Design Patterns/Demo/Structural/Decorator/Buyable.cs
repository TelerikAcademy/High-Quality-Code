namespace Decorator
{
    using System;

    internal class Buyable : Decorator
    {
        private readonly int price;

        public Buyable(LibraryItem item, int price)
            : base(item)
        {
            this.price = price;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("Price: $" + this.price);
        }
    }
}
