namespace OpenClosedShoppingCartBefore
{
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
            this.paymentProcessor.ProcessCreditCard(this.paymentDetails, this.Cart.TotalAmount());

            base.Checkout();
        }
    }
}