namespace OpenClosedShoppingCartBefore
{
    using System.Collections.Generic;

    public interface IReservationService
    {
        void ReserveInventory(IEnumerable<OrderItem> items);
    }
}