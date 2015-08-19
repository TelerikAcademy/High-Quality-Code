namespace OpenClosedShoppingCartBefore
{
    public interface IPaymentProcessor
    {
        void ProcessCreditCard(PaymentDetails paymentDetails, decimal amount);
    }
}