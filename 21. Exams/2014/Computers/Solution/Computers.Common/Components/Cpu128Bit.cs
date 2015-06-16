namespace Computers.Common.Components
{
    public class Cpu128Bit : Cpu
    {
        public Cpu128Bit(byte numberOfCores)
            : base(numberOfCores)
        {
        }

        public override int GetMaxNumber()
        {
            return 2000;
        }
    }
}
