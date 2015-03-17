namespace SingleResponsibilityShapesAfter
{
    using SingleResponsibilityShapesAfter.Contracts;

    public class Rectangle : IShape
    {
        public Rectangle(decimal width, decimal height)
        {
            this.Width = width;
            this.Height = height;
        }

        public decimal Width { get; set; }

        public decimal Height { get; set; }

        public decimal Area
        {
            get
            {
                return this.Width * this.Height;
            }
        }
    }
}
