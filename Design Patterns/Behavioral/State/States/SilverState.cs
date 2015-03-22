namespace State.States
{
    /// <summary>
    /// A 'ConcreteState' class
    /// <remarks>
    /// Silver indicates a non-interest bearing state
    /// </remarks>
    /// </summary>
    public class SilverState : State
    {
        public SilverState(Account account)
            : base(account)
        {
            this.Interest = 0.0;
            this.LowerLimit = 0.0;
            this.UpperLimit = 1000.0;
        }

        public override void Deposit(double amount)
        {
            this.Account.Balance += amount;
            if (this.Account.Balance > this.UpperLimit)
            {
                this.Account.State = new GoldState(this.Account);
            }
        }

        public override void Withdraw(double amount)
        {
            this.Account.Balance -= amount;
            if (this.Account.Balance < this.LowerLimit)
            {
                this.Account.State = new RedState(this.Account);
            }
        }

        public override void PayInterest()
        {
            this.Account.Balance += this.Interest * this.Account.Balance;
            if (this.Account.Balance > this.UpperLimit)
            {
                this.Account.State = new GoldState(this.Account);
            }
        }
    }
}
