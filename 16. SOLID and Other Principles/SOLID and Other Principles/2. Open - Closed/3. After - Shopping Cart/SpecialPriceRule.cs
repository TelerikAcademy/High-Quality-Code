namespace OpenClosedShoppingCartAfter
{
    public class SpecialPriceRule : IPriceRule
    {
        public bool IsMatch(OrderItem item)
        {
            return item.Sku.StartsWith("SPECIAL");
        }

        public decimal CalculatePrice(OrderItem item)
        {
            decimal total = 0m;

            // $0.40 each; 3 for a $1.00
            total += item.Quantity * .4m;
            int setsOfThree = item.Quantity / 3;
            total -= setsOfThree * .2m;
            return total;
        }
    }
}