namespace Visitor.NetWorthDemo.Assets
{
    using Visitor.NetWorthDemo.Visitors;

    public interface IAsset
    {
        void Accept(IVisitor visitor);
    }
}
