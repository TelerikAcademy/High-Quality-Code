namespace Visitor.EmployeesDemo
{
    using System;
    using System.Collections.Generic;

    using Visitor.EmployeesDemo.Employees;
    using Visitor.EmployeesDemo.Visitors;

    /// <summary>
    /// The 'ObjectStructure' class
    /// </summary>
    internal class EmployeesList
    {
        private readonly List<Employee> employees = new List<Employee>();

        public void Attach(Employee employee)
        {
            this.employees.Add(employee);
        }

        public void Detach(Employee employee)
        {
            this.employees.Remove(employee);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (var employee in this.employees)
            {
                employee.Accept(visitor);
            }

            Console.WriteLine();
        }
    }
}
