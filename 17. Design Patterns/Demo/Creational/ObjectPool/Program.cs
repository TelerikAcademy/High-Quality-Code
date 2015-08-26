namespace ObjectPool
{
    using System;
    using System.Threading;

    public static class Program
    {
        public static void Main()
        {
            var warehouse = new Warehouse<Equipment>();

            var equipment1 = warehouse.GetEquipment();
            equipment1.EmployeeName = "Atos";
            Console.WriteLine(
                "Equipment 1 ordered on {0:MM/dd/yyyy hh:mm:ss.fff tt} used by {1}",
                equipment1.OrderedAt,
                equipment1.EmployeeName);
            Thread.Sleep(2000);

            var equipment2 = warehouse.GetEquipment();
            equipment2.EmployeeName = "Portos";
            Console.WriteLine(
                "Equipment 2 ordered on {0:MM/dd/yyyy hh:mm:ss.fff tt} used by {1}",
                equipment2.OrderedAt,
                equipment2.EmployeeName);
            Thread.Sleep(2000);
            
            warehouse.ReleaseEquipment(equipment1);

            var equipment3 = warehouse.GetEquipment();
            equipment3.EmployeeName = "Aramis";
            Console.WriteLine(
                "Equipment 3 ordered on {0:MM/dd/yyyy hh:mm:ss.fff tt} used by {1}",
                equipment3.OrderedAt,
                equipment3.EmployeeName);
            Thread.Sleep(2000);
        }
    }
}
