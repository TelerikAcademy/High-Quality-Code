namespace Visitor.EmployeesDemo.Visitors
{
    using System;

    using Visitor.EmployeesDemo.Employees;

    /// <summary>
    /// A 'ConcreteVisitor' class
    /// </summary>
    public class IncomeVisitor : IVisitor
    {
        public void Visit(Employee employee)
        {
            if (employee != null)
            {
                // Provide 10% pay raise
                // The percentage pay raise may be given as a constructor parameter
                employee.Income *= 1.10M;
                Console.WriteLine(
                    "{0} {1}'s new income: {2:C}", employee.GetType().Name, employee.Name, employee.Income);
            }
        }
    }
}
