namespace Visitor.NetWorthDemo
{
    using System.Collections.Generic;

    using Visitor.NetWorthDemo.Assets;
    using Visitor.NetWorthDemo.Visitors;

    public class Person : IAsset
    {
        public Person()
        {
            this.Assets = new List<IAsset>();
        }

        public List<IAsset> Assets { get; private set; }

        public void Accept(IVisitor visitor)
        {
            foreach (var asset in this.Assets)
            {
                asset.Accept(visitor);
            }
        }
    }
}
