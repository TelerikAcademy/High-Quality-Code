namespace OpenClosedShoppingCartBefore
{
    public abstract class Order
    {
        protected readonly Cart Cart;

        protected Order(Cart cart)
        {
            this.Cart = cart;
        }

        public virtual void Checkout()
        {
            // log the order in the database
        }
    }
}