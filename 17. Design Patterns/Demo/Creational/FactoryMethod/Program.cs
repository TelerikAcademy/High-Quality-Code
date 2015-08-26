namespace FactoryMethod
{
    using System;
    using System.Configuration;
    using System.Reflection;

    using FactoryMethod.Manufacturers;

    public static class Program
    {
        public static void Main()
        {
            WorkWithPhone(new PearComputers());
            Console.WriteLine(new string('-', 60));

            WorkWithPhone(new SamunComputers());
            Console.WriteLine(new string('-', 60));

            var factoryClassName = ConfigurationManager.AppSettings["ManufacturerFactory"];
            var manufacturer =
                Assembly.GetExecutingAssembly()
                .CreateInstance(factoryClassName) as Manufacturer;
            WorkWithPhone(manufacturer);
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
