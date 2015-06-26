namespace Computers.Common.Factories
{
    using System.Collections.Generic;

    using Computers.Common.Components;

    public class HpFactory : IComputerFactory
    {
        public const string FactoryName = "HP";

        public Pc CreatePc()
        {
            return new Pc(new Cpu32Bit(2), new Ram(2), new[] { new HardDrive(500) }, new ColorfulVideoCard());
        }

        public Server CreateServer()
        {
            return new Server(
                new Cpu32Bit(4),
                new Ram(32),
                new List<IHardDrive>
                    {
                        new RaidArray(new List<IHardDrive> { new HardDrive(1000), new HardDrive(1000) })
                    });
        }

        public Laptop CreateLaptop()
        {
            return new Laptop(
                new Cpu64Bit(2),
                new Ram(4),
                new[] { new HardDrive(500) },
                new ColorfulVideoCard(),
                new LaptopBattery());
        }
    }
}
