namespace Observer.ClearImplementation
{
    /// <summary>
    /// The 'ConcreteSubject' class
    /// </summary>
    public class IbmStock : Stock
    {
        public IbmStock(double initialPrice)
            : base("IBM", initialPrice)
        {
        }
    }
}
