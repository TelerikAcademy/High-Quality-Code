namespace OpenClosedShoppingCartBefore
{
    using System.Collections.Generic;

    public class Cart
    {
        private readonly List<OrderItem> items;

        public Cart()
        {
            this.items = new List<OrderItem>();
        }

        public IEnumerable<OrderItem> Items
        {
            get { return new List<OrderItem>(this.items); }
        }

        public string CustomerEmail { get; set; }

        public void Add(OrderItem orderItem)
        {
            this.items.Add(orderItem);
        }

        public decimal TotalAmount()
        {
            decimal total = 0m;
            foreach (OrderItem orderItem in this.Items)
            {
                if (orderItem.Sku.StartsWith("EACH"))
                {
                    total += orderItem.Quantity * 5m;
                }
                else if (orderItem.Sku.StartsWith("WEIGHT"))
                {
                    // quantity is in grams, price is per kg
                    total += orderItem.Quantity * 4m / 1000;
                }
                else if (orderItem.Sku.StartsWith("SPECIAL"))
                {
                    // $0.40 each; 3 for a $1.00
                    total += orderItem.Quantity * .4m;
                    int setsOfThree = orderItem.Quantity / 3;
                    total -= setsOfThree * .2m;
                }

                // more rules are coming!
            }

            return total;
        }
    }
}