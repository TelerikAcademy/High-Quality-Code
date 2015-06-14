using System;

namespace Abstraction
{
    abstract class Figure
    {
        public virtual double Width { get; set; }
        public virtual double Height { get; set; }
        public virtual double Radius { get; set; }

        public Figure()
        {
        }

        public Figure(double radius)
        {
            this.Radius = radius;
        }

        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}
