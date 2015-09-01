namespace Observer.DotNetEvents
{
    using System;

    /// <summary>
    /// The 'Observer' interface
    /// </summary>
    /// <param name="sender">Sender of the event</param>
    /// <param name="e">Event arguments</param>
    public delegate void StockPriceChangedHandler(object sender, StockPriceChangedEventArgs e);

    /// <summary>
    /// The 'ConcreteSubject' class
    /// </summary>
    public class ObservableStock
    {
        private readonly string symbol;
        private double price;

        public ObservableStock(string symbol, double price)
        {
            this.symbol = symbol;
            this.price = price;
        }

        public event StockPriceChangedHandler StockPriceChanged;

        public double Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (Math.Abs(this.price - value) > 0.001)
                {
                    this.price = value;
                    this.Notify();
                }
            }
        }

        public string Symbol
        {
            get { return this.symbol; }
        }

        private void Notify()
        {
            if (this.StockPriceChanged != null)
            {
                this.StockPriceChanged(this, new StockPriceChangedEventArgs(this));
            }
        }
    }
}
