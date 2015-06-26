namespace Computers.Common.Components
{
    public class Cpu32Bit : Cpu
    {
        public Cpu32Bit(byte numberOfCores)
            : base(numberOfCores)
        {
        }

        public override int GetMaxNumber()
        {
            return 500;
        }
    }
}
