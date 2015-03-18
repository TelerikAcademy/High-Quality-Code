namespace Visitor.EmployeesDemo.Employees
{
    using Visitor.EmployeesDemo.Visitors;

    /// <summary>
    /// The 'Element' class
    /// </summary>
    public abstract class Employee
    {
        protected Employee()
        {
        }

        protected Employee(string name, decimal income, int vacationDays)
        {
            this.Name = name;
            this.Income = income;
            this.VacationDays = vacationDays;
            this.WorkFromHomeDays = 0;
        }

        public string Name { get; set; }

        public decimal Income { get; set; }

        public int VacationDays { get; set; }

        public int WorkFromHomeDays { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
