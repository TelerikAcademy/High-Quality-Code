namespace Computers.Common.Components
{
    using System.Collections.Generic;

    public class HardDrive : IHardDrive
    {
        private readonly Dictionary<int, string> data;
     
        public HardDrive(int capacity)
        {
            this.Capacity = capacity;
            this.data = new Dictionary<int, string>(capacity);
        }

        public int Capacity { get; private set; }

        public void SaveData(int address, string newData)
        {
            this.data[address] = newData;
        }

        public string LoadData(int address)
        {
            return this.data[address];
        }
    }
}
