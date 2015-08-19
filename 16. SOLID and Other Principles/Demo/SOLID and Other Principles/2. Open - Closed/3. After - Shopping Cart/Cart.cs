namespace OpenClosedShoppingCartAfter
{
    using System.Collections.Generic;

    public class Cart
    {
        private readonly List<OrderItem> items;
        private readonly IPricingCalculator pricingCalculator;

        // Poor man's IOC
        public Cart() : this(new PricingCalculator())
        {
        }

        public Cart(IPricingCalculator pricingCalculator)
        {
            this.pricingCalculator = pricingCalculator;
            this.items = new List<OrderItem>();
        }

        public IEnumerable<OrderItem> Items
        {
            get { return this.items; }
        }

        public string CustomerEmail { get; set; }

        public void Add(OrderItem orderItem)
        {
            this.items.Add(orderItem);
        }

        public decimal TotalAmount()
        {
            decimal total = 0m;
            foreach (var orderItem in this.Items)
            {
                total += this.pricingCalculator.CalculatePrice(orderItem);
                
                // more rules are coming!
            }

            return total;
        }
    }
}