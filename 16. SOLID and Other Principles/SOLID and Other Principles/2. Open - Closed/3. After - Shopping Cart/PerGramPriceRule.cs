namespace OpenClosedShoppingCartAfter
{
    public class PerGramPriceRule : IPriceRule
    {
        public bool IsMatch(OrderItem item)
        {
            return item.Sku.StartsWith("WEIGHT");
        }

        public decimal CalculatePrice(OrderItem item)
        {
            return item.Quantity * 4m / 1000;
        }
    }
}