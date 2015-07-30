namespace LiskovSubstitutionEmployeesAfter
{
    using System.Collections.Generic;

    public class DetailsPrinter
    {
        private IEnumerable<Employee> employees;

        public DetailsPrinter(IEnumerable<Employee> employees)
        {
            this.employees = employees;
        }

        public void Print()
        {
            foreach (var employee in this.employees)
            {
                var details = employee.ToString();

                // print details
            }
        }
    }
}
