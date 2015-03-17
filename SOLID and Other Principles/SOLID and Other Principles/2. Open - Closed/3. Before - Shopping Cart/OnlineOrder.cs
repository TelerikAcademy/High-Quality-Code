namespace OpenClosedShoppingCartBefore
{
    public class OnlineOrder : Order
    {
        private readonly INotificationService notificationService;
        private readonly PaymentDetails paymentDetails;
        private readonly IPaymentProcessor paymentProcessor;
        private readonly IReservationService reservationService;

        public OnlineOrder(Cart cart, PaymentDetails paymentDetails)
            : base(cart)
        {
            this.paymentDetails = paymentDetails;
            this.paymentProcessor = new PaymentProcessor();
            this.reservationService = new ReservationService();
            this.notificationService = new NotificationService();
        }

        public override void Checkout()
        {
            this.paymentProcessor.ProcessCreditCard(this.paymentDetails, this.cart.TotalAmount());

            this.reservationService.ReserveInventory(this.cart.Items);

            this.notificationService.NotifyCustomerOrderCreated(this.cart);

            base.Checkout();
        }
    }
}
