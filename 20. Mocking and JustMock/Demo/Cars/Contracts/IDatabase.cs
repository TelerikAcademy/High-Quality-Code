namespace Cars.Contracts
{
    using Cars.Models;
    using System.Collections.Generic;

    public interface IDatabase
    {
        IList<Car> Cars { get; set; }
    }
}
