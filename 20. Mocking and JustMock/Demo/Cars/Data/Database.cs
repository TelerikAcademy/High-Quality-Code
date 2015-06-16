namespace Cars
{
    using Cars.Contracts;
    using Cars.Models;
    using System.Collections.Generic;

    public class Database : IDatabase
    {
        public IList<Car> Cars { get; set; }
    }
}
