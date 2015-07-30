namespace Visitor.NetWorthDemo.Visitors
{
    using Visitor.NetWorthDemo.Assets;

    public interface IVisitor
    {
        void Visit(RealEstate realEstate);

        void Visit(BankAccount bankAccount);

        void Visit(Loan loan);
    }
}
