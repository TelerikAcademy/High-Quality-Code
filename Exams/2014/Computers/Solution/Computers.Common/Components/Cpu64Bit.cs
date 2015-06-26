namespace Computers.Common.Components
{
    public class Cpu64Bit : Cpu
    {
        public Cpu64Bit(byte numberOfCores)
            : base(numberOfCores)
        {
        }

        public override int GetMaxNumber()
        {
            return 1000;
        }
    }
}
