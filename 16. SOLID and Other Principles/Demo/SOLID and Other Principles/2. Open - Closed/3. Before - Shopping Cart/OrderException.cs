namespace OpenClosedShoppingCartBefore
{
    using System;

    public class OrderException : Exception
    {
        public OrderException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}