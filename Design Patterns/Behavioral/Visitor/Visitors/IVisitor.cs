namespace Visitor.Visitors
{
    using Visitor.Employees;

    /// <summary>
    /// The 'Visitor' interface
    /// </summary>
    public interface IVisitor
    {
        void Visit(Employee element);
    }
}
