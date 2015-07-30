namespace LiskovSubstitutionEmployeesAfter
{
    using System.Collections.Generic;

    public class Manager : Employee
    {
        public IEnumerable<string> Documents { get; set; }

        public override string ToString()
        {
            return base.ToString() + "; Documents: " + this.Documents.ToString();
        }
    }
}
