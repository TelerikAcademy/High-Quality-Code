namespace Prototype
{
    using System.Threading;

    public class Stormtrooper : StormtrooperPrototype
    {
        public Stormtrooper(string type, int height, int weight)
        {
            Thread.Sleep(3000); // Doing something slow
            this.Type = type;
            this.Height = height;
            this.Weight = weight;
        }

        public string Type { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public override Stormtrooper Clone()
        {
            // Options of cloning in .NET (http://stackoverflow.com/a/966534/1862812)
            // Clone Manually - Tedious, but high level of control
            // Clone with MemberwiseClone - Fastest but only creates a shallow copy, i.e. for reference-type fields the original object and it's clone refer to the same object.
            // Clone with Reflection - Shallow copy by default, can be re-written to do deep copy. Advantage: automated. Disadvantage: reflection is slow.
            // Clone with Serialization - Easy, automated. Give up some control and serialization is slowest of all.
            return this.MemberwiseClone() as Stormtrooper;
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Height: {1}, Weight: {2}", this.Type, this.Height, this.Weight);
        }
    }
}
