namespace Computers.Common.Components
{
    public class LaptopBattery : IBattery
    {
        private const int MaxBatteryPercentage = 100;

        public LaptopBattery()
        {
            this.Percentage = MaxBatteryPercentage / 2;
        }

        public int Percentage { get; set; }

        public void Charge(int percentage)
        {
            this.Percentage += percentage;
            if (this.Percentage > MaxBatteryPercentage)
            {
                this.Percentage = MaxBatteryPercentage;
            }

            if (this.Percentage < 0)
            {
                this.Percentage = 0;
            }
        }
    }
}