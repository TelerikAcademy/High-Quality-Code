namespace OpenClosedShoppingCartBefore
{
    using System;
    using System.Collections.Generic;

    public abstract class Order
    {
        protected readonly Cart cart;

        protected Order(Cart cart)
        {
            this.cart = cart;
        }

        public virtual void Checkout()
        {
            // log the order in the database
        }
    }

    public class PoSCreditOrder : Order
    {
        private readonly PaymentDetails paymentDetails;
        private readonly IPaymentProcessor paymentProcessor;

        public PoSCreditOrder(Cart cart, PaymentDetails paymentDetails)
            : base(cart)
        {
            this.paymentDetails = paymentDetails;
            this.paymentProcessor = new PaymentProcessor();
        }

        public override void Checkout()
        {
            this.paymentProcessor.ProcessCreditCard(this.paymentDetails, this.cart.TotalAmount());

            base.Checkout();
        }
    }

    public class PoSCashOrder : Order
    {
        public PoSCashOrder(Cart cart)
            : base(cart)
        {
        }
    }

    #region PaymentProcessor
    public interface IPaymentProcessor
    {
        void ProcessCreditCard(PaymentDetails paymentDetails, decimal amount);
    }

    internal class PaymentProcessor : IPaymentProcessor
    {
        public void ProcessCreditCard(PaymentDetails paymentDetails, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region ReservationService
    public interface IReservationService
    {
        void ReserveInventory(IEnumerable<OrderItem> items);
    }

    public class ReservationService : IReservationService
    {
        public void ReserveInventory(IEnumerable<OrderItem> items)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region NotificationService

    internal interface INotificationService
    {
        void NotifyCustomerOrderCreated(Cart cart);
    }

    internal class NotificationService : INotificationService
    {
        public void NotifyCustomerOrderCreated(Cart cart)
        {
            throw new NotImplementedException();
        }
    }

    #endregion

    public class OrderException : Exception
    {
        public OrderException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}