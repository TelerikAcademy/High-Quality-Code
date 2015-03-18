namespace Visitor
{
    using Visitor.EmployeesDemo;
    using Visitor.EmployeesDemo.Employees;
    using Visitor.EmployeesDemo.Visitors;

    public class Program
    {
        public static void Main()
        {
            EmployeesDemo();
        }

        private static void EmployeesDemo()
        {
            var ivan = new Clerk { Name = "Ivan", Income = 20000, VacationDays = 8 };
            var peter = new Clerk { Name = "Peter", Income = 25000, VacationDays = 14 };
            var george = new Director { Name = "George", Income = 35000, VacationDays = 16 };
            var bob = new President { Name = "Bob", Income = 45000, VacationDays = 21 };

            // Setup employee collection
            var employees = new EmployeesList();
            employees.Attach(ivan);
            employees.Attach(peter);
            employees.Attach(george);
            employees.Attach(bob);

            // Employees are 'visited'
            employees.Accept(new IncomeVisitor());
            employees.Accept(new VacationVisitor());
            bob.Accept(new IncomeVisitor());

            // We can create and apply new visitors (e.g. work from home days)
            // as well as new employee successors

            // We can create SumIncomeVisitor to collect information for us
        }
    }
}
