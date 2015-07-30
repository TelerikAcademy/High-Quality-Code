namespace LiskovSubstitutionSquareBefore
{
    public class Rectangle : Shape
    {
        public virtual decimal Width { get; set; }

        public virtual decimal Height { get; set; }

        public override decimal Area
        {
            get
            {
                return this.Width * this.Height;
            }
        }
    }
}
