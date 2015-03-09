namespace FactoryMethod.GsmConglomerate
{
    public abstract class Gsm
    {
        public int BatteryLife { get; set; }

        public int Weight { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public string Name { get; set; }

        public abstract void Start();
    }
}
