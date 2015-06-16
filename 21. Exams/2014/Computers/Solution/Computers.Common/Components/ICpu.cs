namespace Computers.Common.Components
{
    public interface ICpu : IMotherboardComponent
    {
        byte NumberOfCores { get; }

        void GenerateRandomNumber(int min, int max);

        void SquareNumber();
    }
}