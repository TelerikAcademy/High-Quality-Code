namespace LiskovSubstitutionEmployeesAfter
{
    public class Employee
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return "Name: " + this.Name;
        }
    }
}
