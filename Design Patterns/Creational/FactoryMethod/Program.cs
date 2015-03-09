namespace FactoryMethod
{
    using System;

    using FactoryMethod.Manufacturers;

    public class Program
    {
        public static void Main()
        {
            WorkWithPhone(new PearComputers());
            Console.WriteLine(new string('-', 60));
            WorkWithPhone(new SamunComputers());
            Console.WriteLine(new string('-', 60));
        }

        private static void WorkWithPhone(Manufacturer manufacturer)
        {
            var phone = manufacturer.ManufactureGsm();
            Console.WriteLine(phone.ToString());
            phone.Start();
        }
    }
}
