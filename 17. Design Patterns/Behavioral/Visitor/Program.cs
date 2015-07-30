namespace Visitor
{
    using System;

    using Visitor.EmployeesDemo;
    using Visitor.EmployeesDemo.Employees;
    using Visitor.EmployeesDemo.Visitors;
    using Visitor.NetWorthDemo;
    using Visitor.NetWorthDemo.Assets;
    using Visitor.NetWorthDemo.Visitors;

    public static class Program
    {
        public static void Main()
        {
            EmployeesDemo();
            Console.WriteLine(new string('-', 60));
            NetWorthDemo();
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

        private static void NetWorthDemo()
        {
            var person = new Person();
            person.Assets.Add(new BankAccount { Amount = 10000, MonthlyInterest = 0.005M });
            person.Assets.Add(new BankAccount { Amount = 1000, MonthlyInterest = 0.01M });
            person.Assets.Add(new RealEstate { EstimatedValue = 100000, MonthlyRent = 500 });
            person.Assets.Add(new Loan { Owed = 30000, MonthlyPayment = 300 });

            var netWorthVisitor = new NetWorthVisitor();
            person.Accept(netWorthVisitor);
            Console.WriteLine("Total value of assets: {0}", netWorthVisitor.Total);

            var monthlyIncomeVisitor = new MonthlyIncomeVisitor();
            person.Accept(monthlyIncomeVisitor);
            Console.WriteLine("Total monthly income: {0}", monthlyIncomeVisitor.Total);
        }
    }
}
