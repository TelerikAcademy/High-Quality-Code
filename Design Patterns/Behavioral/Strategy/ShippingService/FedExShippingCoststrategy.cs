namespace Strategy.ShippingService
{
    public class FedExShippingCoststrategy : IShippingCostStrategy
    {
        public double Calculate(Order order)
        {
            return 5.00d;
        }
    }
}
