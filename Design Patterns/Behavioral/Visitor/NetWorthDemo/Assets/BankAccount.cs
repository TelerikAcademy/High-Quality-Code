namespace Visitor.NetWorthDemo.Assets
{
    using Visitor.NetWorthDemo.Visitors;

    public class BankAccount : IAsset
    {
        public decimal Amount { get; set; }

        public decimal MonthlyInterest { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
