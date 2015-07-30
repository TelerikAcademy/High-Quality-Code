namespace LiskovSubstitutionEmployeesBefore
{
    using System.Collections.Generic;

    public class Manager : Employee
    {
        public IEnumerable<string> Documents { get; set; }
    }
}
