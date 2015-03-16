namespace Strategy.ShippingService
{
    public class PostalServiceShippingCostStrategy : IShippingCostStrategy
    {
        public double Calculate(Order order)
        {
            return 3.00d;
        }
    }
}
