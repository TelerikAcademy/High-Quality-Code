namespace Computers.Common.Factories
{
    using System.Collections.Generic;

    using Computers.Common.Components;

    public class LenovoFactory : IComputerFactory
    {
        public const string FactoryName = "Lenovo";

        public Pc CreatePc()
        {
            return new Pc(new Cpu64Bit(2), new Ram(4), new[] { new HardDrive(2000) }, new MonochromeVideoCard());
        }

        public Server CreateServer()
        {
            return new Server(
                new Cpu128Bit(2),
                new Ram(8),
                new List<IHardDrive>
                    {
                        new RaidArray(new List<IHardDrive> { new HardDrive(500), new HardDrive(500) })
                    });
        }

        public Laptop CreateLaptop()
        {
            return new Laptop(
                new Cpu64Bit(2),
                new Ram(16),
                new[] { new HardDrive(1000) },
                new ColorfulVideoCard(),
                new LaptopBattery());
        }
    }
}