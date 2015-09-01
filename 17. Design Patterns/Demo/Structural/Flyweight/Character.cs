namespace Flyweight
{
    /// <summary>
    /// The 'Flyweight' abstract class
    /// </summary>
    public abstract class Character
    {
        protected char Symbol { get; set; }

        protected int Width { get; set; }

        protected int Height { get; set; }

        protected int Ascent { get; set; }

        protected int Descent { get; set; }

        public abstract void Display(int pointSize);
    }
}
