namespace Computers.Common.Components
{
    public abstract class MotherboardComponent : IMotherboardComponent
    {
        public IMotherboard Motherboard { get; set; }
    }
}
