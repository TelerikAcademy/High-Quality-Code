namespace Strategy.ShippingService
{
    public interface IShippingCostStrategy
    {
        double Calculate(Order order);
    }
}
