namespace State.States
{
    using System;

    /// <summary>
    /// A 'ConcreteState' class
    /// <remarks>
    /// Red indicates that account is overdrawn 
    /// </remarks>
    /// </summary>
    public class RedState : State
    {
        public RedState(Account account)
            : base(account)
        {
            this.Interest = 0.0;
            this.LowerLimit = -100.0;
            this.UpperLimit = 0.0;
        }

        public override void Deposit(double amount)
        {
            this.Account.Balance += amount;
            if (this.Account.Balance > this.UpperLimit)
            {
                this.Account.State = new SilverState(this.Account);
            }
        }

        public override void Withdraw(double amount)
        {
            Console.WriteLine("No funds available for withdrawal!");
        }

        public override void PayInterest()
        {
            // No interest is paid
        }
    }
}
