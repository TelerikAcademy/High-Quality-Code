namespace LiskovSubstitutionSquareBefore
{
    public class Square : Rectangle
    {
        public override decimal Width
        {
            get
            {
                return base.Width;
            }

            set
            {
                base.Width = value;
                base.Height = value;
            }
        }

        public override decimal Height
        {
            get
            {
                return base.Height;
            }

            set
            {
                base.Width = value;
                base.Height = value;
            }
        }
    }
}
