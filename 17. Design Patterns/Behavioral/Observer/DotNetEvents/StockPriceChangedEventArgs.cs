namespace Observer.DotNetEvents
{
    using System;

    public class StockPriceChangedEventArgs : EventArgs
    {
        public StockPriceChangedEventArgs(ObservableStock stock)
        {
            this.Stock = stock;
        }

        public ObservableStock Stock { get; set; }
    }
}
