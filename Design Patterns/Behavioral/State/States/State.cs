namespace State.States
{
    /// <summary>
    /// The 'State' abstract class
    /// </summary>
    public abstract class State
    {
        protected State(Account account)
        {
            this.Account = account;
        }

        protected Account Account { get; private set; }

        protected double Interest { get; set; }

        protected double LowerLimit { get; set; }

        protected double UpperLimit { get; set; }

        public abstract void Deposit(double amount);

        public abstract void Withdraw(double amount);

        public abstract void PayInterest();
    }
}
