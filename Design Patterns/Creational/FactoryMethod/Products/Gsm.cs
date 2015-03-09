namespace FactoryMethod.Products
{
    using System.Text;

    public abstract class Gsm
    {
        public int BatteryLife { get; set; }

        public int Weight { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public string Name { get; set; }

        public abstract void Start();

        public override string ToString()
        {
            var gsmAsString = new StringBuilder();
            gsmAsString.AppendFormat("Phone name: {0}", this.Name);
            gsmAsString.AppendLine();
            gsmAsString.AppendFormat("Height: {0}", this.Height);
            gsmAsString.AppendLine();
            gsmAsString.AppendFormat("Width: {0}", this.Width);
            gsmAsString.AppendLine();
            gsmAsString.AppendFormat("Weight: {0}", this.Weight);
            gsmAsString.AppendLine();
            gsmAsString.AppendFormat("Battery life: {0}", this.BatteryLife);
            gsmAsString.AppendLine();
            return gsmAsString.ToString();
        }
    }
}
