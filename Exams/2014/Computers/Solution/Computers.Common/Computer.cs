namespace Computers.Common
{
    using System.Collections.Generic;

    using Computers.Common.Components;

    public abstract class Computer
    {
        protected Computer(
            ICpu cpu,
            IRam ram,
            IEnumerable<IHardDrive> hardDrives,
            IVideoCard videoCard)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDrives = hardDrives;
            this.VideoCard = videoCard;
            this.Motherboard = new Motherboard(this.Cpu, this.Ram, this.VideoCard);
        }

        public Motherboard Motherboard { get; set; }

        protected ICpu Cpu { get; private set; }

        protected IRam Ram { get; private set; }

        protected IEnumerable<IHardDrive> HardDrives { get; private set; }

        protected IVideoCard VideoCard { get; private set; }
    }
}
