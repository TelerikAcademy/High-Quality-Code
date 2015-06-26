namespace Computers.Common.Components
{
    public interface IHardDrive
    {
        int Capacity { get; }

        void SaveData(int address, string newData);

        string LoadData(int address);
    }
}
