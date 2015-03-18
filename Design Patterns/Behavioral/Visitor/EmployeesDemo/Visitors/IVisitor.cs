namespace Visitor.EmployeesDemo.Visitors
{
    using Visitor.EmployeesDemo.Employees;

    /// <summary>
    /// The 'Visitor' interface
    /// </summary>
    public interface IVisitor
    {
        void Visit(Employee element);
    }
}
