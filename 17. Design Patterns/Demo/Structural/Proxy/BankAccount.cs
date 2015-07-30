namespace ProxyPattern
{
    public class BankAccount : IBankAccount
    {
        public BankAccount()
        {
            this.Ballance = 2500;
        }

        private decimal Ballance { get; set; }

        public bool Deposit(decimal amount)
        {
            // Try to deposit
            // Do some validations
            this.Ballance += amount;

            // Deposit successful
            return true;
        }

        public bool Withdraw(decimal amount)
        {
            // Try to deposit
            // Do some validations
            // Do some more validations :)
            this.Ballance -= amount;

            // Deposit successful
            return true;
        }

        public decimal CurrentBallance()
        {
            // Do many validations
            return this.Ballance;
        }
    }
}