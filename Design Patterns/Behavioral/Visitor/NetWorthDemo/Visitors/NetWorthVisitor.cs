namespace Visitor.NetWorthDemo.Visitors
{
    using Visitor.NetWorthDemo.Assets;

    public class NetWorthVisitor : IVisitor
    {
        public decimal Total { get; private set; }

        public void Visit(RealEstate realEstate)
        {
            this.Total += realEstate.EstimatedValue;
        }

        public void Visit(BankAccount bankAccount)
        {
            this.Total += bankAccount.Amount;
        }

        public void Visit(Loan loan)
        {
            this.Total -= loan.Owed;
        }
    }
}
