namespace Computers.Common.Components
{
    public class Motherboard : IMotherboard
    {
        public Motherboard(ICpu cpu, IRam ram, IVideoCard videoCard)
        {
            cpu.Motherboard = this;
            this.Cpu = cpu;

            ram.Motherboard = this;
            this.Ram = ram;

            videoCard.Motherboard = this;
            this.VideoCard = videoCard;
        }

        private ICpu Cpu { get; set; }

        private IRam Ram { get; set; }

        private IVideoCard VideoCard { get; set; }

        public int LoadRamValue()
        {
            return this.Ram.LoadValue();
        }

        public void SaveRamValue(int value)
        {
            this.Ram.SaveValue(value);
        }

        public void DrawOnVideoCard(string data)
        {
            this.VideoCard.Draw(data);
        }
    }
}