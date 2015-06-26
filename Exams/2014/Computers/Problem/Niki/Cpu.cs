
using Computers1;using Computers11;using System;
using Computers8;namespace Computers4
{

    class Cpu
    {
        private readonly byte numberOfBits;

        private readonly Rammstein ram;

        private readonly HardDriver videoCard;

        static readonly Random Random = new Random();

        internal Cpu(byte numberOfCores, byte numberOfBits, Rammstein ram, HardDriver videoCard) {
            this.numberOfBits = numberOfBits;
            this.ram = ram;
            this.NumberOfCores = numberOfCores;
        }

        byte NumberOfCores { get; set; }

        public void SquareNumber()
        {
            if (this.numberOfBits == 32) SquareNumber32();
            if (this.numberOfBits == 64) SquareNumber64();
        }

        void SquareNumber32()
        {
            var data = this.ram.LoadValue();
            if (data < 0)
            {
                this.videoCard.Draw("Number too low.");
            }
            else if (data > 500)
            {
                this.videoCard.Draw("Number too high.");
            }
            else
            {
                int value = 0;
                for (int i = 0; i < data; i++)
                {
                    value += data;
                }
                this.videoCard.Draw(string.Format("Square of {0} is {1}.", data, value));
            }
        }

        void SquareNumber64()
        {
            var data = this.ram.LoadValue();
            if (data < 0)
            {
                this.videoCard.Draw("Number too low.");
            }
            else if (data > 1000)
            {
                this.videoCard.Draw("Number too high.");
            }
            else
            {
                int value = 0;
                for (int i = 0; i < data; i++)
                {
                    value += data;
                }
                this.videoCard.Draw(string.Format("Square of {0} is {1}.", data, value));
            }
        }

        internal void rand(int a, int b)
        {
            int randomNumber;
            do
            {
                randomNumber = Random.Next(0, 1000);
            }
            while (!(randomNumber >= a && randomNumber <= b));
            this.ram.SaveValue(randomNumber);
        }
    }

    class Laptop
    {
        private static void Main()
        {
            Computers computers = new Computers();
            Computers.main();
        }
    }
}
