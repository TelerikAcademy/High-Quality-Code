namespace State
{
    public static class Program
    {
        public static void Main()
        {
            var account = new Account("Jim Johnson");

            account.Deposit(500.0);
            account.Deposit(300.0);
            account.Deposit(550.0);
            account.PayInterest();
            account.Withdraw(1000.00);
            account.Withdraw(1100.00);
        }
    }
}
