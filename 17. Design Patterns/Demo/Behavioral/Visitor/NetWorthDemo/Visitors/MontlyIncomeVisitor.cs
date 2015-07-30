namespace Visitor.NetWorthDemo.Visitors
{
    using Visitor.NetWorthDemo.Assets;

    public class MonthlyIncomeVisitor : IVisitor
    {
        public decimal Total { get; private set; }

        public void Visit(RealEstate realEstate)
        {
            this.Total += realEstate.MonthlyRent;
        }

        public void Visit(BankAccount bankAccount)
        {
            this.Total += bankAccount.Amount * bankAccount.MonthlyInterest;
        }

        public void Visit(Loan loan)
        {
            this.Total -= loan.MonthlyPayment;
        }
    }
}
