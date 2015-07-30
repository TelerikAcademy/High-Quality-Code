namespace OpenClosedShoppingCartAfter
{
    using System;

    public interface IPriceRule
    {
        bool IsMatch(OrderItem item);

        decimal CalculatePrice(OrderItem item);
    }
}