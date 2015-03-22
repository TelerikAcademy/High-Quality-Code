namespace State.States
{
    /// <summary>
    /// A 'ConcreteState' class
    /// <remarks>
    /// Gold indicates an interest bearing state
    /// </remarks>
    /// </summary>
    public class GoldState : State
    {
        public GoldState(Account account)
            : base(account)
        {
            this.Interest = 0.05;
            this.LowerLimit = 1000.0;
            this.UpperLimit = double.MaxValue;
        }

        public override void Deposit(double amount)
        {
            this.Account.Balance += amount;
        }

        public override void Withdraw(double amount)
        {
            this.Account.Balance -= amount;
            if (this.Account.Balance < 0.0)
            {
                this.Account.State = new RedState(this.Account);
            }

            if (this.Account.Balance < this.LowerLimit)
            {
                this.Account.State = new SilverState(this.Account);
            }
        }

        public override void PayInterest()
        {
            this.Account.Balance += this.Interest * this.Account.Balance;
        }
    }
}
