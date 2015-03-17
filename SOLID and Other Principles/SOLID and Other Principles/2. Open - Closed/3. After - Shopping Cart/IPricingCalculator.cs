namespace OpenClosedShoppingCartAfter
{
    public interface IPricingCalculator
    {
        decimal CalculatePrice(OrderItem item);
    }
}