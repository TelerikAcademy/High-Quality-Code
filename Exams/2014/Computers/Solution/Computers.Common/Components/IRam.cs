namespace Computers.Common.Components
{
    public interface IRam : IMotherboardComponent
    {
        int Amount { get; set; }

        void SaveValue(int newValue);

        int LoadValue();
    }
}
